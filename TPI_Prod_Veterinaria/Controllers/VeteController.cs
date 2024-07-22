using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
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

        public VeteController(IVeteServices veteServices)
        {
            _veteServices = veteServices;
            
        }

        [HttpPost]
        public IActionResult Create([FromBody]  VeterinarioCreateRequest veterinarioCreateRequets)
        {
            
            var newObj = _veteServices.Create(veterinarioCreateRequets);

            return CreatedAtAction(nameof(Get), new { id = newObj.Id }, veterinarioCreateRequets);
        }

        [HttpGet("{id}")]
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

        [HttpGet]
        public ActionResult<List<VeterinarioDto>> GetAll()
        {
            return _veteServices.GetAll();
        }

        [HttpGet("Inactivos")]
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

        [HttpDelete("{id}")]
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


    }
}
