using Application.Interfaces;
using Domain.Dto;
using Domain.Entities;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TPI_Prod_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeteController : ControllerBase
    {
        //inyectamos servicio

        private readonly IVeteServices _veteServices;
        public VeteController(IVeteServices veteServices)
        {
            _veteServices = veteServices;
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<VeterinarioDto?> GetVeteById([FromRoute] int id)
        {
            var veterinario = _veteServices.GetVeteById(id);

            if (veterinario == null)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return Ok(veterinario);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<VeterinarioDto?>> GetAllVete()
        {
            var response = _veteServices.GetAllVete();

            if (!response.Any())
            {
                return NotFound("No se encontraron recursos en la base de datos");
            }

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult AddVete([FromBody] VeterinarioViewModel veterinario)
        {
            var (created, errorMessage) = _veteServices.AddVete(veterinario);

            if (!created)
            {
                return BadRequest(errorMessage);
            }

            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string apiAndEndpointUrl = $"api/Producto/GetById";
            string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{veterinario.Id}";

            return Created(locationUrl, veterinario);
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody] VeterinarioViewModel veterinario)
        {
            var updated = _veteServices.UpdateVete(veterinario);

            if (!updated)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var deleted = _veteServices.DeleteVeterinario(id);

            if (!deleted)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return NoContent();
        }

        [HttpPut("ReActivar/{id}")]
        public IActionResult ReActivarVete([FromRoute] int id) 
        {
            var reactive = _veteServices.ReActivarVete(id);

            if (!reactive)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return Ok();
        }
    }
}
