using GEPDA_API.Models;
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
    public class UniversidadController : ControllerBase
    {
        private readonly IUniversidadService _universidadService;

        public  UniversidadController(IUniversidadService universidadService)
        {
            _universidadService =  universidadService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _universidadService.get();
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}/Universidad/{Est}")]
        public IActionResult Get(int Id,int Est)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _universidadService.get(Id,Est);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpGet("{universidad}/Logo/{fileName}/file")]
        public IActionResult GetImage(string universidad, string fileName)
        {
            var filePath = Path.Combine("Images", universidad, "Logo", fileName);
            var image = System.IO.File.OpenRead(filePath);
            return File(image, "image/jpeg");
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add( UniversidadRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {

                _universidadService.Add(oModel);
                    oRespuesta.Exito = 1;
                

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Edit(UniversidadRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                _universidadService.Edit(oModel);
                oRespuesta.Exito = 1;

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
