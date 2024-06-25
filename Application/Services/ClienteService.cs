using Application.Interfaces;
using ConsultaAlumnos.Domain.Exceptions;
using Domain.Dto;
using Domain.Entities;
using Domain.IRepository;
using Domain.ViewModels;


namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository; 
        }
        public List<ClienteDto?> GetAllCliente()
        {
            return _clienteRepository.GetAllCliente();
        }

        public ClienteDto GetClienteById(int id)
        {
            return _clienteRepository.GetClienteById(id);
        }

        public bool AddCliente(ClienteViewModel cliente)
        {
            return _clienteRepository.AddCliente(cliente);
        }

        public bool DeleteCliente(int id)
        {
            var obj = _clienteRepository.GetClienteById(id);
            if (obj == null)
            {
                throw new NotFoundException(nameof(Veterinario), id);
            }
            return _clienteRepository.DeleteCliente(id);
        }

        public ICollection<Mascota> GetMascotasByClienteId(int clienteId)
        {
            return _clienteRepository.GetMascotasByClienteId(clienteId);
        }

        public bool ReActivarCliente(int id)
        {
            var obj = _clienteRepository.GetClienteById(id);
            if (obj == null)
            {
                throw new NotFoundException(nameof(Cliente), id);
            }
            return _clienteRepository.ReActivarCliente(id);
        }

        public bool UpdateCliente(ClienteViewModel cliente)
        {
            return _clienteRepository.UpdateCliente(cliente);
        }
    }
}
