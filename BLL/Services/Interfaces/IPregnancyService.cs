using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IPregnancyService
    {
        IEnumerable<Pregnancy> GetAll();
        Pregnancy GetById(int id);
        void Add(Pregnancy pregnancy);
        void Update(Pregnancy pregnancy);
        void Delete(int id);
    }
}
