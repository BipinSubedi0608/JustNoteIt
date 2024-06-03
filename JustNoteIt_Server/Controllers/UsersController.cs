using AutoMapper;
using JustNoteIt_Server.Dtos.UsersDtos;
using JustNoteIt_Server.Interfaces;
using JustNoteIt_Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustNoteIt_Server.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;

        public UsersController(IUserRepo userRepo, IMapper mapper, ISessionService sessionService)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _sessionService = sessionService;
        }

        //[HttpGet("check")]
        //public ActionResult Check()
        //{
        //    return Ok(_sessionService.GetUserIdFromSession() != null ? "Logged In" : "Not Logged In");
        //}


        [HttpPost("register", Name = "Register")]
        public ActionResult<UserReadDto> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
        {
            if (userRegisterDto == null)
            {
                return BadRequest("The request body cannot be null");
            }

            if (_userRepo.DoesUserAlreadyExist(userRegisterDto.Email!))
            {
                return BadRequest("User already exists");
            }

            var userModel = _mapper.Map<UserModel>(userRegisterDto!);

            _userRepo.RegisterUser(userModel);
            _userRepo.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return Ok(userReadDto);
        }



        [HttpPost("login", Name = "Login")]
        public ActionResult<UserReadDto> LoginUser([FromBody] UserLoginDto userLoginDto)
        {
            if (userLoginDto == null)
            {
                return BadRequest("The request body cannot be null");
            }

            var user = _userRepo.LoginUser(userLoginDto.email!, userLoginDto.password!);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            _sessionService.SetUserIdToSession(user.UserId);

            return Ok(user);
        }



        [HttpPost("logout", Name = "Logout")]
        public ActionResult LogoutUser()
        {
            if (_sessionService.GetUserIdFromSession() == null)
            {
                return Unauthorized("User not logged in");
            }

            _sessionService.RemoveUserIdFromSession();
            return Ok("Logout successful");
        }



        [HttpPut(Name = "UpdateUser")]
        public ActionResult<UserReadDto> UpdateUser([FromBody] UserUpdateDto userUpdateDto)
        {
            if (userUpdateDto == null)
            {
                return BadRequest("The request body cannot be null");
            }

            Guid? id = _sessionService.GetUserIdFromSession();

            if (id == null)
            {
                return Unauthorized("User not logged in");
            }

            var userToBeUpdated = _userRepo.GetUserById(id.Value);

            if (userToBeUpdated == null)
            {
                return NotFound("User not found");
            }

            _mapper.Map(userUpdateDto, userToBeUpdated);
            _userRepo.UpdateUser(userToBeUpdated);
            _userRepo.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userToBeUpdated);

            return Ok(userReadDto);
        }

        //[HttpDelete("{id}", Name = "DeleteUser")]
        //public ActionResult DeleteUser(Guid id)
        //{
        //    var userToBeDeleted = _userRepo.GetUserById(id);

        //    if (userToBeDeleted == null)
        //    {
        //        return NotFound();
        //    }

        //    _userRepo.DeleteUser(userToBeDeleted);
        //    _userRepo.SaveChanges();

        //    return NoContent();
        //}
    }
}
