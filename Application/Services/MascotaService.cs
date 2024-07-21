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

        public List<Mascota> GetAll()
        {
            throw new NotImplementedException();
        }

        public MascotaDto GetById(int id)
        {
            var obj = _mascotaRepository.GetById(id)
            ?? throw new NotFoundException(nameof(id));
            var dto = MascotaDto.Create(obj);
            return dto;
        }

        public void Update(Mascota mascota)
        {
            
        }
    }
}
