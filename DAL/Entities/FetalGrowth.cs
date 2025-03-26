using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class FetalGrowth
    {
        public int Id { get; set; }
        public int PregnancyId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public DateTime Date { get; set; }
        public Pregnancy Pregnancy { get; set; } = null!;
    }
}
