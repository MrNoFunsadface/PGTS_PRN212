using DAL.Data;
using DAL.Entities;
using DAL.Repos.Interfaces;

namespace DAL.Repos.Implementations
{
    public class MilestoneRepo : IMilestoneRepo
    {
        private readonly AppDbContext _context;

        public MilestoneRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Milestone> GetAll()
        {
            return _context.Milestones.ToList();
        }

        public Milestone GetById(int id)
        {
            return _context.Milestones.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Milestone milestone)
        {
            _context.Milestones.Add(milestone);
            _context.SaveChanges();
        }

        public void Update(Milestone milestone)
        {
            _context.Milestones.Update(milestone);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var milestone = GetById(id);
            _context.Milestones.Remove(milestone);
            _context.SaveChanges();
        }
    }
}
