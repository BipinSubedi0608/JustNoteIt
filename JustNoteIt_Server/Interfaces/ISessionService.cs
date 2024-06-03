namespace JustNoteIt_Server.Interfaces
{
    public interface ISessionService
    {
        Guid? GetUserIdFromSession();
        void SetUserIdToSession(Guid userId);
        void RemoveUserIdFromSession();
    }
}
