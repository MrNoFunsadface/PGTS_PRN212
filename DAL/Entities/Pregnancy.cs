namespace DAL.Entities
{
    public class Pregnancy
    {
        public int Id { get; set; }
        public DateTime ConceptionDate { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<FetusData> FetusDatas { get; set; } = [];
        public ICollection<Milestone> Milestones { get; set; } = [];
    }
}
