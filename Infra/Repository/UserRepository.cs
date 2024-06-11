using Domain.Entities;
using Infra.Data;

namespace Domain.Repository
{
    public class UserRepository 
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
    }
}
