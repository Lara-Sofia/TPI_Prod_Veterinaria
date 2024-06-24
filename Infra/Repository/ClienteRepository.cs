using Domain.Entities;
using Domain.IRepository;
using Domain.ViewModels;
using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class clienteRepository : IClienteRepository
    {

        private readonly ApplicationContext _ClienteReContext;
        public clienteRepository(ApplicationContext clienteReContext)
        {
            _ClienteReContext = clienteReContext;
        }

        public bool AddCliente(ClienteViewModel cliente)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Mascota> GetMascotas(int clienteId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCliente(int id)
        {
            throw new NotImplementedException();
        }
    }
}
