namespace DAL.Entities
{
    public class Pregnancy
    {
        public int Id { get; set; }
        public DateOnly ConceptionDate { get; set; }
        public DateOnly? DueDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<FetusData> FetusDatas { get; set; } = [];
        public ICollection<Milestone> Milestones { get; set; } = [];
    }
}
