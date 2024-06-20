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
    public class clienteRepository : IClienteRepository
    {

        private readonly ApplicationContext _ClienteReContext;
        public clienteRepository(ApplicationContext clienteReContext)
        {
            _ClienteReContext = clienteReContext;
        }

        public ICollection<Mascota> GetMascotas(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
