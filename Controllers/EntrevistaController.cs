using GEPDA_API.Models.Request;
using GEPDA_API.Models.Response;
using GEPDA_API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GEPDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrevistaController : ControllerBase
    {
        private readonly IEntrevistaService _entrevistaService;
        public EntrevistaController(IEntrevistaService entrevistaService)
        {
              _entrevistaService = entrevistaService;
        }
        [HttpGet("{Id}/Sede/{Est}")]
        public IActionResult Get(int Id,int Est)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _entrevistaService.get(Id,Est);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpGet("{Id}/Programa/{Est}")]
        public IActionResult Gets(int Id, int Est)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _entrevistaService.gets(Id, Est);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(EntrevistaRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _entrevistaService.Add(oModel);

                respuesta.Exito = 1;

            }
            catch (Exception ex)
            {

                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }


        [HttpPut]
        [Authorize]
        public IActionResult Edit(EntrevistaRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _entrevistaService.Edit(oModel);

                respuesta.Exito = 1;

            }
            catch (Exception ex)
            {

                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }
    }
}
