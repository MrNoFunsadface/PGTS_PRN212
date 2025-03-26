using DAL.Entities;

namespace DAL.Repos.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
