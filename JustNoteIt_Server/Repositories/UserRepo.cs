using JustNoteIt_Server.DBContext;
using JustNoteIt_Server.Interfaces;
using JustNoteIt_Server.Models;

namespace JustNoteIt_Server.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly JustNoteItContext _dbContext;

        public UserRepo(JustNoteItContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public UserModel? GetUserById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(n => n.UserId == id);
        }

        public bool DoesUserAlreadyExist(string email)
        {
            return _dbContext.Users.Any(u => u.Email == email);
        }

        public UserModel? LoginUser(string email, string password)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public void RegisterUser(UserModel user)
        {
            _dbContext.Users.Add(user);
        }

        public void UpdateUser(UserModel user)
        {
            user.UpdatedAt = DateTime.Now;
        }

        public void DeleteUser(UserModel user)
        {
            _dbContext.Users.Remove(user);
        }
    }
}
