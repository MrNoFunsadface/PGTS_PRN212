using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IFetusDataService
    {
        IEnumerable<FetusData> GetAll();
        FetusData GetById(int id);
        void Add(FetusData fetusData);
        void Update(FetusData fetusData);
        void Delete(int id);
    }
}
