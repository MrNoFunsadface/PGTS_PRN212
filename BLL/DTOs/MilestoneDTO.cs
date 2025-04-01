using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MilestoneRequestDTO
    {
        public int PregnancyId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Descriptions { get; set; }


        [Required(ErrorMessage = "Date is required")]
        public DateOnly Date { get; set; }
    }

    public class MilestoneResponseDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateOnly Date { get; set; }
    }
}
