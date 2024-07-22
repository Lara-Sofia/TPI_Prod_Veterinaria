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
    [Authorize(Policy = "ClientePolicy")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClienteCreateRequets clienteCreateRequets)
        {
            var newObj = _clienteService.Create(clienteCreateRequets);

            return CreatedAtAction(nameof(Get), new { id = newObj.Id }, clienteCreateRequets);
        }

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

        [HttpGet]
        public ActionResult<List<ClienteDto>> GetAll()
        {
            return _clienteService.GetAll();
        }

        [HttpGet("Inactivos")]
        public ActionResult<List<ClienteDto>> GetAllInactivos()
        {
            return _clienteService.GetAllInactivos();
        }

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

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
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
    }
}
