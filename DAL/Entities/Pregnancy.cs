using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Pregnancy
    {
        public int Id { get; set; }
        public DateTime ConceptionDate { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
