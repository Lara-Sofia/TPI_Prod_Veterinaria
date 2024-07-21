using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Application.Services;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace TPI_Prod_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
       private readonly IMascotaService _mascotaService;

        public MascotaController(IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] MascotaClienteRequest mascotaClienteRequets)
        {

            var newObj = _mascotaService.Create(mascotaClienteRequets);

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

    }
}
