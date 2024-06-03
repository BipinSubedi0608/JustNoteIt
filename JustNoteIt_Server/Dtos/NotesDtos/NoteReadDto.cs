using System.ComponentModel.DataAnnotations;

namespace JustNoteIt_Server.Dtos.NotesDtos
{
    public class NoteReadDto
    {
        [Key]
        [Required]
        public Guid NoteId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}
