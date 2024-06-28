using Domain.Entities;
using Domain.IRepository;
using Infra.Data;

namespace Infra.Repository
{
    public class VeteRepository : IVeteRepository
    {
        private readonly ApplicationContext _context;
        public VeteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Veterinario Add(Veterinario veterinario)
        {
            _context.Veterinarios.Add(veterinario);
            _context.SaveChanges();
            return veterinario;
        }

        public void Delete(Veterinario voterinario)
        {
            _context.Remove(voterinario);
            _context.SaveChanges();
        }

        public List<Veterinario> GetAll()
        {
            return _context.Veterinarios.ToList();
        }

        public Veterinario? GetById(int id)
        {
            return _context.Veterinarios
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Veterinario veterinario)
        {
            _context.Update(veterinario);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        
    }

}
