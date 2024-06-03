using AutoMapper;
using JustNoteIt_Server.Dtos.NotesDtos;
using JustNoteIt_Server.Interfaces;
using JustNoteIt_Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustNoteIt_Server.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/notes")]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepo _noteRepo;
        private readonly IMapper _mapper;

        public NotesController(INoteRepo noteRepo, IMapper mapper)
        {
            _noteRepo = noteRepo;
            _mapper = mapper;
        }



        //Get request to api/notes
        [HttpGet(Name = "GetAllNotes")]
        public ActionResult<List<NoteReadDto>> GetAllNotes()
        {
            try
            {
                var notes = _noteRepo.GetAllNotes();
                return Ok(_mapper.Map<List<NoteReadDto>>(notes));
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }



        //Get request to api/notes/{id}
        [HttpGet("{id}", Name = "GetNoteById")]
        public ActionResult<List<NoteReadDto>> GetNoteById(Guid id)
        {
            try
            {
                var note = _noteRepo.GetNoteById(id);
                if (note == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<NoteReadDto>(note));
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }



        //Post request to api/notes
        [HttpPost(Name = "CreateNote")]
        public ActionResult<NoteReadDto> CreateNote(NoteCreateDto noteCreateDto)
        {
            if (noteCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                var noteModel = _mapper.Map<NoteModel>(noteCreateDto);

                _noteRepo.CreateNote(noteModel);
                _noteRepo.SaveChanges();

                var noteReadDto = _mapper.Map<NoteReadDto>(noteModel);

                return Ok(noteReadDto);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }



        //Put request to api/notes/{id}
        [HttpPut("{id}", Name = "UpdateNote")]
        public ActionResult<NoteReadDto> UpdateNote(Guid id, NoteUpdateDto noteUpdateDto)
        {
            var noteToBeUpdated = _noteRepo.GetNoteById(id);
            if (noteToBeUpdated == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(noteUpdateDto, noteToBeUpdated);
                _noteRepo.UpdateNote(noteToBeUpdated);
                _noteRepo.SaveChanges();

                var noteReadDto = _mapper.Map<NoteReadDto>(noteToBeUpdated);

                return Ok(noteReadDto);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }



        //Delete request to api/notes/{id}
        [HttpDelete("{id}", Name = "DeleteNote")]
        public ActionResult DeleteNote(Guid id)
        {
            var noteToBeDeleted = _noteRepo.GetNoteById(id);
            if (noteToBeDeleted == null)
            {
                return NotFound();
            }

            try
            {
                _noteRepo.DeleteNote(noteToBeDeleted);
                _noteRepo.SaveChanges();

                return NoContent();
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
