
using Domain.Dto;
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
        VeterinarioDto GetVeteById(int id);
        List<VeterinarioDto> GetAllVete();
        bool AddVete(VeterinarioViewModel veterinario);
        bool DeleteVeterinario(int id);
        bool UpdateVete(VeterinarioViewModel userveterinario);
    }
}
