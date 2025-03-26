using DAL.Entities;

namespace DAL.Repos.Interfaces
{
    public interface IMilestoneRepo
    {
        IEnumerable<Milestone> GetAll();
        Milestone GetById(int id);
        void Add(Milestone milestone);
        void Update(Milestone milestone);
        void Delete(int id);
    }
}
