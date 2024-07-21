using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.IRepository;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Infra.Repository
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly ApplicationContext _context;
        public MascotaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Mascota Add(Mascota mascota) 
        {
            _context.Mascotas.Add(mascota);
            _context.SaveChanges();
            return mascota;
        }

        public List<Mascota> GetAll() 
        {
            return _context.Mascotas.Include(a => a.Cliente)
                //.Include(a => a.Diagnosticos)
                .ToList();
        }

        public Mascota? GetById(int id) 
        {
            return _context.Mascotas.Include(a => a.Cliente).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Mascota mascota)
        {
            _context.Update(mascota);
            _context.SaveChanges();
        }

        public void Delete(Mascota mascota) 
        {
            _context.Remove(mascota);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
