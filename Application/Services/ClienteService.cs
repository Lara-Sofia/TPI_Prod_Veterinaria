using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.Entities;
using Domain.Exceptions;
using Domain.IRepository;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;


        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository; 

        }

        public List<ClienteDto> GetAll()
        {
            var list = _clienteRepository.GetAll();
            return ClienteDto.CreateList(list);
        }

        public ClienteDto GetById(int id)
        {
            var obj = _clienteRepository.GetById(id)
                ?? throw new NotFoundException(nameof(id)); //como un if
            var dto = ClienteDto.Create(obj);
            return dto;
        }

        public Cliente Create(ClienteCreateRequets clienteCreateRequets)
        {
            var obj = new Cliente();
            obj.Name = clienteCreateRequets.Name;
            obj.Email = clienteCreateRequets.Email;
            obj.Password = clienteCreateRequets.Password;
            return _clienteRepository.Add(obj);
        }

        public void Update(int id, ClienteUpdateRequets clienteUpdateRequets)
        {
            var obj = _clienteRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Cliente), id);

            if (clienteUpdateRequets.Name != string.Empty) obj.Name = clienteUpdateRequets.Name;

            if (clienteUpdateRequets.Email != string.Empty) obj.Email = clienteUpdateRequets.Email;

            if (clienteUpdateRequets.Password != string.Empty) obj.Password = clienteUpdateRequets.Password;

            _clienteRepository.Update(obj);
        }

        public void Delete(int id)
        {
            var obj = _clienteRepository.GetById(id);

            if (obj == null) throw new NotFoundException(nameof(Cliente), id);

            _clienteRepository.Delete(obj);
        }
    }
}
