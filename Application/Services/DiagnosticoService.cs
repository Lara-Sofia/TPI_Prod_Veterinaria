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

        public DiagnosticoService (IDiagnosticoRepository diagnosticoRepository)
        {
            _diagnosticoRepository = diagnosticoRepository;
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
            var diagnosticos = _diagnosticoRepository.GetByMascotaId(mascotaId);
            return diagnosticos.Select(d => DiagnosticoDto.Create(d)).ToList();
        }

        public List<DiagnosticoDto> GetByVeteId(int veteId)
        {
            var diagnosticos = _diagnosticoRepository.GetByVeteId(veteId);
            return diagnosticos.Select(d => DiagnosticoDto.Create(d)).ToList();
        }

    }
}
