using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class MilestoneRequestDTO
    {
        [Required(ErrorMessage = "ProjectId is required")]
        public int PregnancyId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Descriptions { get; set; } = null!;

        [Required(ErrorMessage = "Date is required")]
        public DateOnly Date { get; set; }
    }

    public class MilestoneResponseDTO
    {
        public int Id { get; set; }
        public int PregnancyId { get; set; }
        public string Descriptions { get; set; } = null!;
        public DateOnly Date { get; set; }
    }
}