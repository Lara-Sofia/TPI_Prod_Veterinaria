using Domain.Entities;
using Domain.IRepository;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
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
            _context.Diagnosticos.Add(diagnostico);
            _context.SaveChanges();
            return diagnostico;

        }

        public List<Diagnostico> GetAll()
        {
            return _context.Diagnosticos.Include(d  => d.Mascota).ThenInclude(d => d.Cliente).Include(d => d.DiagnosticoLineas).ToList();
        }
        

        public Diagnostico GetById(int id)
        {
             return _context.Diagnosticos.Include(d => d.Mascota).ThenInclude(d => d.Cliente).Include(d => d.DiagnosticoLineas).FirstOrDefault(d => d.Id == id);
        }

        public List<Diagnostico> GetByMascotaId(int mascotaId)
        {
            return _context.Diagnosticos.Include(d => d.Mascota).ThenInclude(d => d.Cliente).Include(d => d.DiagnosticoLineas).Where(d => d.MascotaId == mascotaId).ToList();
        }

        public List<Diagnostico> GetByVeteId(int veteId)
        {
            return _context.Diagnosticos.Include(d => d.Mascota).ThenInclude(d => d.Cliente).Include(d => d.DiagnosticoLineas).Where(d => d.VeterinarioId == veteId).ToList();
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
