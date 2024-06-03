using JustNoteIt_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace JustNoteIt_Server.DBContext
{
    public class JustNoteItContext : DbContext
    {
        public JustNoteItContext(DbContextOptions<JustNoteItContext> options) : base(options)
        {
        }

        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
