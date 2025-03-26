using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PregnancyId { get; set; }
        public int DoctorId { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Pregnancy Pregnancy { get; set; } = null!;
        public User Doctor { get; set; } = null!;
    }
}
