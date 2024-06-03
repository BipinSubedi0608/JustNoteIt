using System.ComponentModel.DataAnnotations;

namespace JustNoteIt_Server.Dtos.UsersDtos
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string? email { get; set; }

        [Required]
        [MaxLength(16)]
        [MinLength(8)]
        public string? password { get; set; }
    }
}
