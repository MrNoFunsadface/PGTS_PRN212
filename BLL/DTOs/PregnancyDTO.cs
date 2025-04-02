using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class PregnancyRequestDTO
    {
        [Required(ErrorMessage = "ConceptionDate is required")]
        public DateOnly ConceptionDate { get; set; }

        public DateOnly? DueDate { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }
    }

    public class PregnancyResponseDTO
    {
        public int Id { get; set; }
        public DateOnly ConceptionDate { get; set; }
        public DateOnly DueDate { get; set; }
        public int UserId { get; set; }
    }
}
