using AutoMapper;
using JustNoteIt_Server.Dtos.NotesDtos;
using JustNoteIt_Server.Models;

namespace JustNoteIt_Server.MappingProfiles
{
    public class NotesProfile : Profile
    {
        public NotesProfile()
        {
            CreateMap<NoteModel, NoteReadDto>();
            CreateMap<NoteCreateDto, NoteModel>();
            CreateMap<NoteUpdateDto, NoteModel>();
        }
    }
}
