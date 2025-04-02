using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class MilestoneRequestDTO
    {
        [Required(ErrorMessage = "PregnancyId is required")]
        public int PregnancyId { get; set; }

        [Required(ErrorMessage = "Descriptions is required")]
        public string Descriptions { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date is required")]
        public DateOnly Date { get; set; }
    }

    public class MilestoneResponseDTO
    {
        public int Id { get; set; }
        public int PregnancyId { get; set; }
        public string Descriptions { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
    }
}
