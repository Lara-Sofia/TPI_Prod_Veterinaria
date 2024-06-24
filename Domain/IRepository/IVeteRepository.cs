using Domain.Dto;
using Domain.Entities;
using Domain.ViewModels;


namespace Domain.IRepository
{
    public interface IVeteRepository
    {
        VeterinarioDto GetVeteById(int id);
        List<VeterinarioDto> GetAllVete();
        bool AddVete(VeterinarioViewModel veterinario);
        bool DeleteVeterinario(int id);
        bool UpdateVete(VeterinarioViewModel userveterinario);
        bool ReActivarVete(int id);

    }
}
