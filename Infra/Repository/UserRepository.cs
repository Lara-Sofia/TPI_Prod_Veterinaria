using Domain.Entities;
using Domain.IRepository;
using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public  class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository (ApplicationContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetByEmail(string email)
        {
            return _context.Users
               .FirstOrDefault(x => x.Email == email);
        }
    }
}
