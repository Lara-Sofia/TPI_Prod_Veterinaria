using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMascotaService
    {
        Mascota Create(MascotaClienteRequest mascotaClienteRequest);
        List<Mascota> GetAll();
        MascotaDto? GetById(int id);
        void Update(Mascota mascota);
    }
}