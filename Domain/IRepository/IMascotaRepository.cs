using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IMascotaRepository
    {
        Mascota Add(Mascota mascota);
        List<Mascota> GetAll();
        List<Mascota> GetAllInactivos();
        Mascota? GetById(int id);
        List<Mascota> GetByClienteId(int clienteid);
        void Update (Mascota mascota);

    }
}
