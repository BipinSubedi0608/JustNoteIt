using JustNoteIt_Server.Models;

namespace JustNoteIt_Server.Interfaces
{
    public interface IUserRepo
    {
        bool SaveChanges();
        void RegisterUser(UserModel user);
        UserModel? LoginUser(string email, string password);
        void UpdateUser(UserModel user);
        void DeleteUser(UserModel user);
        UserModel? GetUserById(Guid id);
        bool DoesUserAlreadyExist(string email);
    }
}
