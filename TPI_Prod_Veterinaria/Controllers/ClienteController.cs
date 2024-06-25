using Application.Interfaces;
using Application.Services;
using Domain.Dto;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TPI_Prod_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("GetAllCliente")]
        public ActionResult<List<ClienteDto?>> GetAllCliente()
        {
            var response = _clienteService.GetAllCliente();

            if (!response.Any())
            {
                return NotFound("No se encontraron recursos en la base de datos");
            }

            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<ClienteDto?> GetClienteById([FromRoute] int id)
        {
            var cliente = _clienteService.GetClienteById(id);

            if (cliente == null)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return Ok(cliente);
        }

        [HttpGet("clientes/{clienteId}/mascotas")]
        public IActionResult GetMascotas(int clienteId)
        {
            // Obtener las mascotas del cliente desde el repositorio
            var mascotas = _clienteService.GetMascotasByClienteId(clienteId);

            // Verificar si se encontraron mascotas
            if (mascotas == null || !mascotas.Any())
            {
                return NotFound(new { Message = "No se encontraron mascotas para este cliente." });
            }

            // Devolver las mascotas en formato JSON
            return Ok(mascotas);
        }

        [HttpPost("CreateCliente")]
        public IActionResult AddCliente([FromBody] ClienteViewModel cliente)
        {
            var created = _clienteService.AddCliente(cliente);

            if (!created)
            {
                return BadRequest("Id existente");
            }

            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string apiAndEndpointUrl = $"api/Producto/GetById";
            string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{cliente.Id}";

            return Created(locationUrl, cliente);
        }

        [HttpPut("UpdateCliente")]
        public IActionResult UpdateCliente([FromBody] ClienteViewModel cliente)
        {
            var updated = _clienteService.UpdateCliente(cliente);

            if (!updated)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return Ok();
        }

        [HttpDelete("DeleteCliente/{id}")]
        public IActionResult DeleteCliente([FromRoute] int id)
        {
            var deleted = _clienteService.DeleteCliente(id);

            if (!deleted)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return NoContent();
        }

        [HttpPut("ReActivarCliente/{id}")]
        public IActionResult ReActivarCliente([FromRoute] int id)
        {
            var reactive = _clienteService.ReActivarCliente(id);

            if (!reactive)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return Ok();
        }


    }
}
