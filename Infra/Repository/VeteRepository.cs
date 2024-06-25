using Domain.Dto;
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

        public VeterinarioDto? GetVeteById(int id)
        {
            return _context.Veterinarios.Select(v => new VeterinarioDto
            {
                Id = v.Id,
                Name = v.Name,
                Email = v.Email,
                Matricula = v.Matricula,
                Activo = v.Activo

            }).FirstOrDefault();
        }

        public List<VeterinarioDto> GetAllVete()
        {
            return _context.Veterinarios.Select(v => new VeterinarioDto
            {
                Id = v.Id,
                Name = v.Name,
                Email = v.Email,
                Matricula = v.Matricula,
                Activo = v.Activo,

            }).ToList();
        }

        public (bool, string) AddVete(VeterinarioViewModel veterinario)
        {

            var vete = _context.Veterinarios.FirstOrDefault(p => p.Id == veterinario.Id);

            if (vete != null)
            {

                return (false, "Id existente");
            }
            // Verifica si ya existe un veterinario con la misma Matricula
            if (_context.Veterinarios.Any(p => p.Matricula == veterinario.Matricula))
            {
                return (false, "Matricula existente");
            }
            _context.Veterinarios.Add(new Veterinario
            {
                Id = veterinario.Id,
                Name = veterinario.Name,
                Matricula = veterinario.Matricula,
                Email = veterinario.Email,
                Password = veterinario.Password,
                Activo = true,
            });
            _context.SaveChanges();
            return (true, null);
        }


        public bool DeleteVeterinario(int id)
        {
            var user = _context.Veterinarios.FirstOrDefault(x => x.Id == id && x.Activo);
            if (user == null)
            {
                return false;
            }
            user.Activo = false;
            _context.SaveChanges();
            return true;
        }

        public bool UpdateVete(VeterinarioViewModel userVeterinario)
        {
            var u = _context.Veterinarios.FirstOrDefault(x => x.Id == userVeterinario.Id);
            if (u == null)
            {
                return false;
            }

            u.Name = userVeterinario.Name;
            u.Email = userVeterinario.Email;
            u.Password = userVeterinario.Password;
            u.Matricula = userVeterinario.Matricula;

            _context.SaveChanges();
            return true;
        }

        public bool ReActivarVete(int id) 
        {
            var user = _context.Veterinarios.FirstOrDefault(x => x.Id == id && x.Activo == false);
            if (user == null)
            {
                return false;
            }
            user.Activo = true;
            _context.SaveChanges();
            return true;

        }

    }

}
