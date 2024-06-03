using JustNoteIt_Server.Dtos.NotesDtos;
using JustNoteIt_Server.Models;

namespace JustNoteIt_Server.Interfaces
{
    public interface INoteRepo
    {
        bool SaveChanges();
        List<NoteModel>? GetAllNotes();
        NoteModel? GetNoteById(Guid id);
        void CreateNote(NoteModel note);
        void UpdateNote(NoteModel note);
        void DeleteNote(NoteModel note);
    }
}
