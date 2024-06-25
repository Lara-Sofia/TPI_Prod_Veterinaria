using Domain.Dto;
using Domain.Entities;
using Domain.IRepository;
using Domain.ViewModels;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly ApplicationContext _ClienteReContext;
        public ClienteRepository(ApplicationContext clienteReContext)
        {
            _ClienteReContext = clienteReContext;
        }

        public ClienteDto? GetClienteById(int id)
        {
            return _ClienteReContext.Clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Activo = c.Activo

            }).FirstOrDefault();
        }
        public List<ClienteDto> GetAllCliente()
        {
            return _ClienteReContext.Clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Password = c.Password,
                Activo = c.Activo,

            }).ToList();
        }

        public bool AddCliente(ClienteViewModel cliente)
        {
            var cli = _ClienteReContext.Clientes.FirstOrDefault(x => x.Id == cliente.Id);
            if (cli != null)
            {

                return false;
            }
            
            _ClienteReContext.Clientes.Add(new Cliente
            {
                Id = cliente.Id,
                Name = cliente.Name,
                Email = cliente.Email,
                Password = cliente.Password,
                Activo = true,
            });
            _ClienteReContext.SaveChanges();
            return true;
        }

        public bool DeleteCliente(int id)
        {
            var cliente = _ClienteReContext.Clientes.FirstOrDefault(x => x.Id == id && x.Activo);
            if (cliente == null)
            {
                return false;
            }
            cliente.Activo = false;
            _ClienteReContext.SaveChanges();
            return true;
        }

        public ICollection<Mascota> GetMascotas(int clienteId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCliente(ClienteViewModel cliente)
        {
            var c = _ClienteReContext.Clientes.FirstOrDefault(x => x.Id == cliente.Id);
            if (c == null)
            {
                return false;
            }

            c.Name = cliente.Name;
            c.Email = cliente.Email;
            c.Password = cliente.Password;
            _ClienteReContext.SaveChanges();
            return true;
        }

        public bool ReActivarCliente(int id)
        {
            var c = _ClienteReContext.Clientes.FirstOrDefault(x => x.Id == id && x.Activo == false);
            if (c == null)
            {
                return false;
            }
            c.Activo = true;
            _ClienteReContext.SaveChanges();
            return true;

        }

        public ICollection<Mascota> GetMascotasByClienteId(int clienteId)
        {
            return _ClienteReContext.Mascotas.Where(m => m.ClienteId == clienteId).ToList();
        }
    }
}
