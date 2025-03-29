using DAL.Entities;
using DAL.Repos.Interfaces;

namespace BLL.Services
{
    public class PregnancyService
    {
        private readonly IPregnancyRepo _pregnancyRepo;

        public PregnancyService(IPregnancyRepo pregnancyRepo)
        {
            _pregnancyRepo = pregnancyRepo;
        }

        public IEnumerable<Pregnancy> GetAll() => _pregnancyRepo.GetAll();
        public Pregnancy GetById(int id) => _pregnancyRepo.GetById(id);
        public void Add(Pregnancy pregnancy) => _pregnancyRepo.Add(pregnancy);
        public void Update(Pregnancy pregnancy) => _pregnancyRepo.Update(pregnancy);
        public void Delete(int id) => _pregnancyRepo.Delete(id);
    }
}
