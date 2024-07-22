using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TPI_Prod_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "VeterinarioPolicy")]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoService _diagnosticoService;

        public DiagnosticoController(IDiagnosticoService diagnosticoService)
        {
            _diagnosticoService = diagnosticoService;
        }

        [HttpPost]
        public ActionResult Create(DiagnosticoCreateRequest request)
        {
            var diagnostico = _diagnosticoService.Create(request);

            return Ok(diagnostico);
        }

        [HttpGet]
        public ActionResult<List<DiagnosticoDto>> GetAll()
        {
            return _diagnosticoService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<DiagnosticoDto> GetById([FromRoute] int id)
        {
            try
            {
                return _diagnosticoService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("mascota/{mascotaId}")]
        public ActionResult<List<DiagnosticoDto>> GetByMascotaId([FromRoute] int mascotaId)
        {
            var diagnosticos = _diagnosticoService.GetByMascotaId(mascotaId);
            return Ok(diagnosticos);
        }

        [HttpGet("veterinario/{veteId}")]
        public ActionResult<List<DiagnosticoDto>> GetByVeteId([FromRoute] int veteId)
        {
            var diagnosticos = _diagnosticoService.GetByVeteId(veteId);
            return Ok(diagnosticos);
        }
    }
}
