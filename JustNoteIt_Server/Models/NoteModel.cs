using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustNoteIt_Server.Models
{
    public class NoteModel
    {
        [Key]
        [Required]
        public Guid NoteId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}
