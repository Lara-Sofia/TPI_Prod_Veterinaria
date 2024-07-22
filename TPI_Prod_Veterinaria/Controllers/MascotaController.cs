using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Application.Services;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TPI_Prod_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "VeterinarioPolicy")]
    public class MascotaController : ControllerBase
    {
       private readonly IMascotaService _mascotaService;

        public MascotaController(IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] MascotaCreateRequest mascotaClienteRequest)
        {

            var newObj = _mascotaService.Create(mascotaClienteRequest);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<MascotaDto> Get([FromRoute] int id)
        {
            //ver
            try
            {
                return _mascotaService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<MascotaDto>> GetAll()
        {
            return _mascotaService.GetAll();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] MascotaUpdateRequest mascotaUpdateRequest)
        {
            try
            {
                _mascotaService.Update(id, mascotaUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
