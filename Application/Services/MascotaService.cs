using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.Entities;
using Domain.Enum;
using Domain.Exceptions;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MascotaService : IMascotaService
    {
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IClienteRepository _clienteRepository;

        public MascotaService(IMascotaRepository mascotaRepository, IClienteRepository clienteRepository)
        {
            _mascotaRepository = mascotaRepository;
            _clienteRepository = clienteRepository; 
        }

        public Mascota Create(MascotaCreateRequest mascotaClienteRequest )
        {
            var obj = new Mascota();
            obj.Name = mascotaClienteRequest.Name;
            obj.Estado = EstadoMascota.EnConsulta; //1 es q esta en consulta, 2 es que se puede ir
            obj.Animal = mascotaClienteRequest.Animal;
            obj.ClienteId = mascotaClienteRequest.ClienteId;
            return _mascotaRepository.Add(obj);

        }

        public List<MascotaDto> GetAll()
        {
            var list = _mascotaRepository.GetAll();
            return MascotaDto.CreateList(list);
        }

        public List<MascotaDto> GetAllInactivos()
        {
            var list = _mascotaRepository.GetAllInactivos();
            return MascotaDto.CreateList(list);
        }

        public MascotaDto GetById(int id)
        {
            var obj = _mascotaRepository.GetById(id)
            ?? throw new NotFoundException(nameof(id));
            var dto = MascotaDto.Create(obj);
            return dto;
        }

        public List<MascotaDto> GetByClienteId(int clienteId)
        {
            var obj = _clienteRepository.GetById(clienteId);
            if (obj == null)
            {
                throw new Exception(nameof(clienteId));
            }
            else
            {
                var mascotas = _mascotaRepository.GetByClienteId(clienteId);
                var dto = mascotas.Select(m => MascotaDto.Create(m)).ToList();

                if (dto.Count == 0)
                { throw new NotFoundException(nameof(clienteId)); }

                return dto;
            }

        }

        public void Update(int id, MascotaUpdateRequest mascotaUpdateRequest)
        {
            var obj = _mascotaRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Mascota), id);
            
            if (mascotaUpdateRequest.Name != string.Empty) obj.Name = mascotaUpdateRequest.Name;
            
            if (mascotaUpdateRequest.Estado != EstadoMascota.EnConsulta) obj.Estado = mascotaUpdateRequest.Estado;
            
            if (mascotaUpdateRequest.ClientId != 0) obj.ClienteId = mascotaUpdateRequest.ClientId;

            if (mascotaUpdateRequest.Activo != true) obj.Activo = mascotaUpdateRequest.Activo;

            _mascotaRepository.Update(obj);
        }

    }
}
