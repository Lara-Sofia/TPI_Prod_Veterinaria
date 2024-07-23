using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Application.Services;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TPI_Prod_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMascotaService _mascotaService;
        private readonly IDiagnosticoService _diagnosticoService;
        public ClienteController(IClienteService clienteService, IMascotaService mascotaService, IDiagnosticoService diagnosticoService)
        {
            _clienteService = clienteService;
            _mascotaService = mascotaService;
            _diagnosticoService = diagnosticoService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody] ClienteCreateRequets clienteCreateRequets)
        {
            var newObj = _clienteService.Create(clienteCreateRequets);

            return CreatedAtAction(nameof(Get), new { id = newObj.Id }, clienteCreateRequets);
        }

        [Authorize(Policy = "VeterinarioPolicy")]
        [HttpGet("{id}")]
        public ActionResult<ClienteDto> Get([FromRoute] int id)
        {
            //ver
            try
            {
                return _clienteService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound($"El cliente con ID {id} no se ha encontrado, intenta con otro");
            }
        }

        [Authorize(Policy = "ClientePolicy")]
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ClienteUpdateRequets clienteUpdateRequets)
        {

            try
            {
                _clienteService.Update(id, clienteUpdateRequets);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [Authorize(Policy = "ClientePolicy")]
        [HttpGet("mascotas/{clienteId}")]
        public ActionResult<List<MascotaDto>> GetMascotasByClienteId([FromRoute] int clienteId)
        {
            try
            {
                var mascotas = _mascotaService.GetByClienteId(clienteId);
                return Ok(mascotas);
            }
            catch (NotFoundException ex)
            {
                return NotFound($"No se han encontrado mascotas para el cliente con id {clienteId}");
            }
            catch (Exception ex)
            {
                return BadRequest($"No se ha encontrado una cliente con id {clienteId}");
            }

        }

        [Authorize(Policy = "ClientePolicy")]
        [HttpGet("diagnosticos/{mascotaId}")]
        public ActionResult<List<DiagnosticoDto>> GetDiagnosticoByMascotaId([FromRoute] int mascotaId)
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
    }
}
