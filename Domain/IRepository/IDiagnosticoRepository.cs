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
        void Delete (Diagnostico diagnostico);
        void Update (Diagnostico diagnostico);
        List<Diagnostico> GetAll();
        void SaveChanges();
    }
}
