using Domain.Entities;
using Domain.IRepository;
using Domain.ViewModels;
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

        public List<Veterinario> GetAllVete()
        {
            return _context.Veterinarios.ToList();
        }

        public bool AddVete(VeterinarioViewModel veterinario)
        {
            
            var vete = _context.Veterinarios.FirstOrDefault(p => p.Id == veterinario.Id);

            if (vete != null)
            {
                return false;
            }
            _context.Veterinarios.Add(new Veterinario
            {
                Id = vete.Id,
                Name = veterinario.Name,
                Matricula   = veterinario.Matricula,
                Email = veterinario.Email,
                Password = veterinario.Password,   
            });
            _context.SaveChanges();
            return true;
        }

        public bool DeleteVeterinario(int id)
        {
            var user = _context.Veterinarios.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return true;
            }
            _context.SaveChanges();
            return false;
        }

        public bool UpdateVete(Veterinario userVeterinario)
        {
            var u = _context.Veterinarios.FirstOrDefault(x => x.Id == userVeterinario.Id);
            if (u != null)
            {
                return true;
            }

            u.Name = userVeterinario.Name;
            u.Email = userVeterinario.Email;
            u.Password = userVeterinario.Password;

            _context.SaveChanges();
            return false;
        }

    }

}
