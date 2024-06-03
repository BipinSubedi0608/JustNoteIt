using JustNoteIt_Server.DBContext;
using JustNoteIt_Server.Interfaces;
using JustNoteIt_Server.Models;

namespace JustNoteIt_Server.Repositories
{
    public class NoteRepo : INoteRepo
    {
        private readonly JustNoteItContext _dbContext;
        private readonly ISessionService _sessionService;
        private readonly Guid? currentUserId;

        public NoteRepo(JustNoteItContext dbContext, ISessionService sessionService)
        {
            _dbContext = dbContext;
            _sessionService = sessionService;
            currentUserId = _sessionService.GetUserIdFromSession();
        }

        private void EnsureUserIsLoggedIn()
        {
            if (currentUserId == null)
            {
                throw new Exception("User not logged in");
            }
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public List<NoteModel>? GetAllNotes()
        {
            EnsureUserIsLoggedIn();
            return [.. _dbContext.Notes.Where(n => n.UserId == currentUserId)];
        }

        public NoteModel? GetNoteById(Guid id)
        {
            EnsureUserIsLoggedIn();
            return _dbContext.Notes.FirstOrDefault(n => n.NoteId == id);
        }

        public void CreateNote(NoteModel note)
        {
            EnsureUserIsLoggedIn();
            note.UserId = currentUserId!.Value;
            _dbContext.Notes.Add(note);
        }

        public void UpdateNote(NoteModel note)
        {
            EnsureUserIsLoggedIn();
            note.UpdatedAt = DateTime.Now;
        }

        public void DeleteNote(NoteModel note)
        {
            EnsureUserIsLoggedIn();
            _dbContext.Notes.Remove(note);
        }
    }
}
