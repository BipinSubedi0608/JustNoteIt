using System.ComponentModel.DataAnnotations;

namespace JustNoteIt_Server.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(16)]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        public string? LastName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}
