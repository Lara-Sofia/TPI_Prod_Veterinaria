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
    [Authorize(Policy = "VeterinarioPolicy")]
    public class VeteController : ControllerBase
    {
        //inyectamos servicio

        private readonly IVeteServices _veteServices;
        private readonly IClienteService _clienteService;

        public VeteController(IVeteServices veteServices, IClienteService clienteService)
        {
            _veteServices = veteServices;
            _clienteService = clienteService;
        }

        [HttpPost("veterinario")]
        public IActionResult Create([FromBody] VeterinarioCreateRequest veterinarioCreateRequets)
        {

            var newObj = _veteServices.Create(veterinarioCreateRequets);

            return CreatedAtAction(nameof(Get), new { id = newObj.Id }, veterinarioCreateRequets);
        }

        [HttpGet("veterinario/{id}")]
        public ActionResult<VeterinarioDto> Get([FromRoute] int id)
        {
            //ver
            try
            {
                return _veteServices.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound($"El veterinario con ID {id} no se ha encontrado, intenta con otro");
            }
        }

        [HttpGet("veterinarios")]
        public ActionResult<List<VeterinarioDto>> GetAll()
        {
            return _veteServices.GetAll();
        }

        [HttpGet("veterinariosInactivos")]
        public ActionResult<List<VeterinarioDto>> GetAllInactivos()
        {
            return _veteServices.GetAllInactivos();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] VeterinarioUpdateRequest veterinarioUpdateRequest)
        {

            try
            {
                _veteServices.Update(id, veterinarioUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("veterinarios/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _veteServices.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        //Desde aca, los Endpoints son pertenecientes a ClienteService

        [HttpDelete("clientes/{id}")]
        public IActionResult DeleteCliente([FromRoute] int id)
        {
            try
            {
                _clienteService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("cliente")]
        public ActionResult<List<ClienteDto>> GetAllClientes()
        {
            return _clienteService.GetAll();
        }

        [HttpGet("clientesInactivos")]
        public ActionResult<List<ClienteDto>> GetAllClientesInactivos()
        {
            return _clienteService.GetAllInactivos();
        }

    }
}
