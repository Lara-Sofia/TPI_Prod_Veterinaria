using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Cliente Create(ClienteCreateRequets clienteCreateRequets);
        void Delete(int id);
        List<ClienteDto> GetAll();
        List<ClienteDto> GetAllInactivos();
        ClienteDto GetById(int id);
        void Update(int id, ClienteUpdateRequets clienteUpdateRequets);
    }
}
