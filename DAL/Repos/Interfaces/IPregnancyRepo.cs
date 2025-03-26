using DAL.Entities;

namespace DAL.Repos.Interfaces
{
    public interface IPregnancyRepo
    {
        IEnumerable<Pregnancy> GetAll();
        Pregnancy GetById(int id);
        void Add(Pregnancy pregnancy);
        void Update(Pregnancy pregnancy);
        void Delete(int id);
    }
}
