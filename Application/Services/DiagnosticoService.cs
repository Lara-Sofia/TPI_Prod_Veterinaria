using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.Entities;
using Domain.Exceptions;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly IDiagnosticoRepository _diagnosticoRepository;
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IVeteRepository _veteRepository;

        public DiagnosticoService (IDiagnosticoRepository diagnosticoRepository, IMascotaRepository mascotaRepository, IVeteRepository veteRepository)
        {
            _diagnosticoRepository = diagnosticoRepository;
            _mascotaRepository = mascotaRepository;
            _veteRepository = veteRepository;

        }

        public int Create(DiagnosticoCreateRequest diagnosticoCreateRequest)
        {
            var diagnostico = new Diagnostico
            {
                MascotaId = diagnosticoCreateRequest.MascotaId,
                VeterinarioId = diagnosticoCreateRequest.VeterinarioId,
                DiagnosticoLineas = diagnosticoCreateRequest.DiagnosticoLineasDto.Select(lineaDto => new DiagnosticoLinea
                {
                    Description = lineaDto.Description,
                }).ToList()
            };

            var diagagregado = _diagnosticoRepository.Add(diagnostico);

            return diagagregado.Id;
        }

        public List<DiagnosticoDto> GetAll()
        {
            var list = _diagnosticoRepository.GetAll();
            return DiagnosticoDto.CreateList(list); ;
        }

        public DiagnosticoDto GetById(int id) 
        {
            var obj = _diagnosticoRepository.GetById(id)
            ?? throw new NotFoundException(nameof(id));
            var dto = DiagnosticoDto.Create(obj);
            return dto;
        }

        public List<DiagnosticoDto> GetByMascotaId(int mascotaId)
        {
            var obj = _mascotaRepository.GetById(mascotaId);
            if (obj == null)
            { 
                throw new Exception(nameof(mascotaId));
            }
            else 
            { 
                var diagnosticos = _diagnosticoRepository.GetByMascotaId(mascotaId);
                var dto = diagnosticos.Select(d => DiagnosticoDto.Create(d)).ToList();
            
                if (dto.Count == 0) 
                { throw new NotFoundException(nameof(mascotaId));}
            
                return dto;
            }
            
        }

        public List<DiagnosticoDto> GetByVeteId(int veteId)
        {
            var obj = _veteRepository.GetById(veteId);
            if (obj == null)
            {
                throw new Exception(nameof(veteId));
            }
            else
            {
                var diagnosticos = _diagnosticoRepository.GetByVeteId(veteId);
                var dto = diagnosticos.Select(d => DiagnosticoDto.Create(d)).ToList();

                if (dto.Count == 0)
                { throw new NotFoundException(nameof(veteId)); }

                return dto;
            }
            
        }

    }
}
