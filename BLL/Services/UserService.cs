using DAL.Entities;
using DAL.Repos.Interfaces;

namespace BLL.Services
{
    public class UserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public IEnumerable<User> GetAll() =>_userRepo.GetAll();
        public User GetById(int id) => _userRepo.GetById(id);
        public void Add(User user) => _userRepo.Add(user);
        public void Update(User user) => _userRepo.Update(user);
        public void Delete(int id) => _userRepo.Delete(id);
    }
}
