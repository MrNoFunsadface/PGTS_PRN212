namespace DAL.Entities
{
    public class Milestone
    {
        public int Id { get; set; }
        public int PregnancyId { get; set; }
        public string Descriptions { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Pregnancy Pregnancy { get; set; } = null!;
    }
}
