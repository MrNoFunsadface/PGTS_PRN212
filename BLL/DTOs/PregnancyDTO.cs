using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PregnancyRequestDTO
    {
        [Required(ErrorMessage = "ConceptionDate is required")]
        public DateTime ConceptionDate { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class PregnancyResponseDTO
    {
        public int Id { get; set; }
        public DateTime ConceptionDate { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }
    }
}
