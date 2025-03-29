namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }

        public ICollection<Pregnancy> Pregnancies { get; set; } = [];
    }
}
