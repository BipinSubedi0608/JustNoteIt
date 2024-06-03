using System.ComponentModel.DataAnnotations;

namespace JustNoteIt_Server.Dtos.NotesDtos
{
    public class NoteCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
