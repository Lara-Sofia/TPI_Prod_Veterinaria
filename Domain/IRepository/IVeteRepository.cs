using Domain.Entities;
using Domain.ViewModels;


namespace Domain.IRepository
{
    public interface IVeteRepository
    {
        Veterinario GetVeteById(int id);
        List<Veterinario> GetAllVete();
        bool AddVete(VeterinarioViewModel veterinario);
        bool DeleteVeterinario(int id);
        bool UpdateVete(Veterinario userveterinario);
    }
}
