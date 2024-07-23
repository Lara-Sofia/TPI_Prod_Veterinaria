using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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

            return Ok($"El diagnostico se ha creado con exito y su Id es {diagnostico}");
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
                return NotFound($"El diagnostico con ID {id} no se ha encontrado, intenta con otro");
            }
        }

        [HttpGet("mascota/{mascotaId}")]
        public ActionResult<List<DiagnosticoDto>> GetByMascotaId([FromRoute] int mascotaId)
        {
            try
            {
                var diagnosticos = _diagnosticoService.GetByMascotaId(mascotaId);
                return Ok(diagnosticos);
            }
            catch (NotFoundException ex)
            {
                return NotFound($"No se han encontrado diagnosticos para la mascota con id {mascotaId}");
            }
            catch (Exception ex)
            {
                return BadRequest($"No se ha encontrado una mascota con id {mascotaId}");
            }
            
        }

        [HttpGet("veterinario/{veteId}")]
        public ActionResult<List<DiagnosticoDto>> GetByVeteId([FromRoute] int veteId)
        {
            try 
            { 
                var diagnosticos = _diagnosticoService.GetByVeteId(veteId);
                return Ok(diagnosticos);
            }
            catch (NotFoundException ex)
            {
                return NotFound($"No se han encontrado diagnosticos por el veterinario con id {veteId}");
            }
            catch (Exception ex)
            {
                return BadRequest($"No se ha encontrado un veterinario con id {veteId}");
            }

        }

        
    }
}
