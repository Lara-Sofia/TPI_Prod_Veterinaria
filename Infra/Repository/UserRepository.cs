using Domain.Entities;
using Domain.IRepository;
using Infra.Data;

namespace Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User? GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return true;
            }
            _context.SaveChanges();
            return false;
        }

        public bool UpdateUser(User user)
        {
            var u = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (u != null)
            {
                return true;
            }

            u.Name = user.Name;
            u.Email = user.Email;
            u.Password = user.Password;

            _context.SaveChanges();
            return false;
        }

        public User? Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }

}
