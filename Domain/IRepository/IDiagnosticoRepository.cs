using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IDiagnosticoRepository
    {
        Diagnostico Add(Diagnostico diagnostico);
        List<Diagnostico> GetAll();
        Diagnostico GetById(int id);
        List<Diagnostico> GetByMascotaId(int mascotaId);
        List<Diagnostico> GetByVeteId(int veteId);
        void SaveChanges();
    }
}
