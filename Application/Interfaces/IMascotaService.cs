using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMascotaService
    {
        Mascota Create(MascotaCreateRequest mascotaClienteRequest);
        List<MascotaDto> GetAll();
        List<MascotaDto> GetAllInactivos();
        MascotaDto? GetById(int id);
        void Update(int id, MascotaUpdateRequest mascotaUpdateRequest);
    }
}