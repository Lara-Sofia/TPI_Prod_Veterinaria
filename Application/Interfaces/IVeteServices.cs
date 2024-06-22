using Application.Models;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVeteServices
    {
        Veterinario GetVeteById(int id);
        List<Veterinario> GetAllVete();
        bool AddVete(VeterinarioViewModel veterinario);
        bool DeleteVeterinario(int id);
        bool UpdateVete(Veterinario userveterinario);
    }
}
