using System.ComponentModel.DataAnnotations;

namespace JustNoteIt_Server.Dtos.UsersDtos
{
    public class UserRegisterDto
    {
        [Required]
        [MinLength(3)]
        public string? FirstName { get; set; }

        [MinLength(3)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(16)]
        [MinLength(8)]
        public string? Password { get; set; }
    }
}
