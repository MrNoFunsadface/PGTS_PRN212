using DAL.Data;
using DAL.Entities;
using DAL.Repos.Interfaces;

namespace DAL.Repos.Implementations
{
    public class PregnancyRepo : IPregnancyRepo
    {
        private readonly AppDbContext _context;

        public PregnancyRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pregnancy> GetAll()
        {
            return _context.Pregnancies.ToList();
        }

        public Pregnancy GetById(int id)
        {
            return _context.Pregnancies.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Pregnancy pregnancy)
        {
            _context.Pregnancies.Add(pregnancy);
            _context.SaveChanges();
        }

        public void Update(Pregnancy pregnancy)
        {
            _context.Pregnancies.Update(pregnancy);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var pregnancy = GetById(id);
            _context.Pregnancies.Remove(pregnancy);
            _context.SaveChanges();
        }
    }
}
