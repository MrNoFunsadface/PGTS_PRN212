using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FetusDataRequestDTO
    {
        [Required(ErrorMessage = "PregnancyId is required")]
        public int PregnancyId { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Height is required")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "HeadCircumference is required")]
        public decimal HeadCircumference { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateOnly Date { get; set; }
    }

    public class FetusDataResponseDTO
    {
        public int Id { get; set; }
        public int PregnancyId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal HeadCircumference { get; set; }
        public DateOnly Date { get; set; }
    }
}
