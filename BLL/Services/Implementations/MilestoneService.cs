using DAL.Entities;
using DAL.Repos.Interfaces;
using BLL.Services.Interfaces;

namespace BLL.Services.Implementations
{
    public class MilestoneService : IMilestoneService
    {
        private readonly IMilestoneRepo _milestoneRepo;

        public MilestoneService(IMilestoneRepo milestoneRepo)
        {
            _milestoneRepo = milestoneRepo;
        }

        public IEnumerable<Milestone> GetAll() =>_milestoneRepo.GetAll();
        public Milestone GetById(int id) => _milestoneRepo.GetById(id);
        public void Add(Milestone milestone) => _milestoneRepo.Add(milestone);
        public void Update(Milestone milestone) => _milestoneRepo.Update(milestone);
        public void Delete(int id) => _milestoneRepo.Delete(id);
    }
}
