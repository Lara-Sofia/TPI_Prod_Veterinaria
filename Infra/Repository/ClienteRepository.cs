using Domain.Entities;
using Domain.IRepository;
using Infra.Data;

namespace Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly ApplicationContext _context;
        public ClienteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Cliente Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public void Delete(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente? GetById(int id)
        {
            return _context.Clientes
               .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Cliente cliente)
        {

            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
