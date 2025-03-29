using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IMilestoneService
    {
        IEnumerable<Milestone> GetAll();
        Milestone GetById(int id);
        void Add(Milestone milestone);
        void Update(Milestone milestone);
        void Delete(int id);
    }
}
