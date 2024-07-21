using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.Entities;
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

        public MascotaService(IMascotaRepository mascotaRepository)
        {
            _mascotaRepository = mascotaRepository;
        }

        public Mascota Create(MascotaClienteRequest mascotaClienteRequest )
        {
            var obj = new Mascota();
            obj.Name = mascotaClienteRequest.Name;
            obj.Estado = true; //true es q esta en consulta, false es que se puede ir
            obj.ClienteId = mascotaClienteRequest.ClienteId;
            return _mascotaRepository.Add(obj);
           
        }

        public List<MascotaDto> GetAll()
        {
            var list = _mascotaRepository.GetAll();
            return MascotaDto.CreateList(list);
        }

        public MascotaDto GetById(int id)
        {
            var obj = _mascotaRepository.GetById(id)
            ?? throw new NotFoundException(nameof(id));
            var dto = MascotaDto.Create(obj);
            return dto;
        }

        public void Update(int id, MascotaUpdateRequest mascotaUpdateRequest)
        {
            var obj = _mascotaRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Mascota), id);
            
            if (mascotaUpdateRequest.Name != string.Empty) obj.Name = mascotaUpdateRequest.Name;
            
            if (mascotaUpdateRequest.Estado != true) obj.Estado = mascotaUpdateRequest.Estado;
            
            if (mascotaUpdateRequest.ClientId != 0) obj.ClienteId = mascotaUpdateRequest.ClientId;

            _mascotaRepository.Update(obj);
        }

        public void Delete(int id)
        {
            var obj = _mascotaRepository.GetById(id);
            if (obj == null) throw new NotFoundException(nameof(Mascota), id);

            _mascotaRepository.Delete(obj);
        }
    }
}
