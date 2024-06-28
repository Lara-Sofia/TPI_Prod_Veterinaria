using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IVeteServices
    {
        Veterinario Create(VeterinarioCreateRequets veterinarioCreateRequets);
        void Delete(int id);
        List<VeterinarioDto> GetAll();
        VeterinarioDto GetById(int id);
        void Update(int id, VeterinarioUpdateRequets veterinarioUpdateRequets);
    }
}
