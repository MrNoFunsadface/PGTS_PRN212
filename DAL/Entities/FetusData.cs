namespace DAL.Entities
{
    public class FetusData
    {
        public int Id { get; set; }
        public int PregnancyId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal HeadCircumference { get; set; }
        public DateTime Date { get; set; }
        public Pregnancy Pregnancy { get; set; } = null!;
    }
}
