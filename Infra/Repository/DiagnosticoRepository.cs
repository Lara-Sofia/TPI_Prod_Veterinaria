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
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly ApplicationContext _context;
        public DiagnosticoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Diagnostico Add(Diagnostico diagnostico)
        {
            throw new NotImplementedException();
        }

        public void Delete(Diagnostico diagnostico)
        {
            throw new NotImplementedException();
        }

        public List<Diagnostico> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Diagnostico diagnostico)
        {
            throw new NotImplementedException();
        }
        
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
