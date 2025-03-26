using DAL.Entities;

namespace DAL.Repos.Interfaces
{
    public interface IFetusDataRepo
    {
        IEnumerable<FetusData> GetAll();
        FetusData GetById(int id);
        void Add(FetusData fetusData);
        void Update(FetusData fetusData);
        void Delete(int id);
    }
}
