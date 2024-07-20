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
        public IActionResult Create([FromBody]  VeterinarioCreateRequets veterinarioCreateRequets)
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
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<VeterinarioDto>> GetAll()
        {
            return _veteServices.GetAll();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] VeterinarioUpdateRequets veterinarioUpdateRequets)
        {

            try
            {
                _veteServices.Update(id, veterinarioUpdateRequets);
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

        [HttpGet("test-authorization")]
        public IActionResult TestAuthorization()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Ok(claims);
        }


    }
}
