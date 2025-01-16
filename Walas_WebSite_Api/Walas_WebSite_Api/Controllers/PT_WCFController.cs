using Application.Dto.WCF.Dto;
using Domain.Services.WCF;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walas_WebSite_Api.Controllers
{
    [Route("api/WCF")]
    [ApiController]
    public class PT_WCFController : ControllerBase
    {
        private readonly WCFService _WCFService;

        public PT_WCFController(WCFService wcfService)
        {
            _WCFService = wcfService;
        }

        [HttpPost]
        public IActionResult RegistrarPersona([FromBody] UsuarioDto personaDto)
        {
            try
            {
                _WCFService.RegistrarPersona(personaDto);
                return Ok("Persona registrada correctamente.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
