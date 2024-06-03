using System.ComponentModel.DataAnnotations;

namespace JustNoteIt_Server.Dtos.UsersDtos
{
    public class UserUpdateDto
    {
        [Required]
        [MaxLength(16)]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [MinLength(3)]
        public string? LastName { get; set; } = string.Empty;
    }
}
