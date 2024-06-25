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
    public interface IClienteService
    {
        ClienteDto GetClienteById(int id);
        List<ClienteDto> GetAllCliente();
        ICollection<Mascota> GetMascotasByClienteId(int clienteId);
        bool DeleteCliente(int id);
        bool AddCliente(ClienteViewModel cliente);
        bool UpdateCliente(ClienteViewModel cliente);
        bool ReActivarCliente(int id);
    }
}
