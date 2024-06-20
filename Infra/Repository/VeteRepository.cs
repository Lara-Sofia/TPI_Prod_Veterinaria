using Domain.Entities;
using Domain.IRepository;
using Infra.Data;

namespace Domain.Repository
{
    public class VeteRepository : IVeteRepository
    {
        private readonly ApplicationContext _context;
        public VeteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Veterinario? GetVeteById(int id)
        {
            return _context.Veterinarios.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public int AddVete(Veterinario userVete)
        {
            _context.Veterinarios.Add(userVete);
            _context.SaveChanges();
            return userVete.Id;
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

        public bool UpdateClientes(Cliente userCliente)
        {
            var u = _context.Veterinarios.FirstOrDefault(x => x.Id == userCliente.Id);
            if (u != null)
            {
                return true;
            }

            u.Name = userCliente.Name;
            u.Email = userCliente.Email;
            u.Password = userCliente.Password;

            _context.SaveChanges();
            return false;
        }

    }

}
