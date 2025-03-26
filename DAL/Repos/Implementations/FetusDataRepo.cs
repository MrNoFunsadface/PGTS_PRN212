using DAL.Data;
using DAL.Entities;
using DAL.Repos.Interfaces;

namespace DAL.Repos.Implementations
{
    public class FetusDataRepo : IFetusDataRepo
    {
        private readonly AppDbContext _context;

        public FetusDataRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FetusData> GetAll()
        {
            return _context.FetusDatas.ToList();
        }

        public FetusData GetById(int id)
        {
            return _context.FetusDatas.FirstOrDefault(x => x.Id == id);
        }

        public void Add(FetusData fetusData)
        {
            _context.FetusDatas.Add(fetusData);
            _context.SaveChanges();
        }

        public void Update(FetusData fetusData)
        {
            _context.FetusDatas.Update(fetusData);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var fetusData = GetById(id);
            _context.FetusDatas.Remove(fetusData);
            _context.SaveChanges();
        }
    }
}
