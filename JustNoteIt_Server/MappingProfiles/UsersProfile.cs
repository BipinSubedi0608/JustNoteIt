using AutoMapper;
using JustNoteIt_Server.Dtos.UsersDtos;
using JustNoteIt_Server.Models;

namespace JustNoteIt_Server.MappingProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserModel, UserReadDto>();
            CreateMap<UserLoginDto, UserModel>();
            CreateMap<UserRegisterDto, UserModel>();
            CreateMap<UserUpdateDto, UserModel>();
        }
    }
}
