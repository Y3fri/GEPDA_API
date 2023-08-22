using GEPDA_API.Models.Request;
using GEPDA_API.Models.Response;
using GEPDA_API.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GEPDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsoUsuProfeController : ControllerBase
    {
        private ISsoUsuProfeService _ssoUsuProfeService;

        public SsoUsuProfeController(ISsoUsuProfeService ssoUsuProfeService)
        {
            _ssoUsuProfeService = ssoUsuProfeService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] SsoUsuProfeRequest model)
        {
            Respuesta respuesta = new Respuesta();
            var userresponse = _ssoUsuProfeService.Auth(model);

            if (userresponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contraseña incorrecta";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Data = userresponse;
            return Ok(respuesta);
        }
    }
}
