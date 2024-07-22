using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDiagnosticoService
    {
        int Create(DiagnosticoCreateRequest diagnosticoCreateRequest);
        List<DiagnosticoDto> GetAll();
        DiagnosticoDto GetById(int id);
        List<DiagnosticoDto> GetByMascotaId(int mascotaId);
        List<DiagnosticoDto> GetByVeteId(int veteId);
    }
}
