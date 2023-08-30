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
    public class SedeController : ControllerBase
    {
        private readonly ISedeService _sedeService;

        public SedeController(ISedeService sedeService)
        {
            _sedeService = sedeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _sedeService.get();
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}/Sede/{Est}")]
        public IActionResult Get(int Id, int Est)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _sedeService.get(Id,Est);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpGet("{Id}/Universidad/{Est}")]
        public IActionResult Gets(int Id,int Est)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _sedeService.gets(Id,Est);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(UniversidadSedeRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    UniversidadSede oUs = new UniversidadSede();
                    oUs.SedUniversidad= oModel.SedUniversidad;
                    oUs.SedNombre = oModel.SedNombre;
                    oUs.SedEmail = oModel.SedEmail;
                    oUs.SedDireccion = oModel.SedDireccion;
                    oUs.SedTelefono = oModel.SedTelefono;
                    oUs.SedEstado = oModel.SedEstado;
                    db.UniversidadSedes.Add(oUs);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Edit(UniversidadSedeRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    UniversidadSede oUs = db.UniversidadSedes.Find(oModel.SedId);
                    oUs.SedUniversidad = oModel.SedUniversidad;
                    oUs.SedNombre = oModel.SedNombre;
                    oUs.SedEmail = oModel.SedEmail;
                    oUs.SedDireccion = oModel.SedDireccion;
                    oUs.SedTelefono = oModel.SedTelefono;
                    oUs.SedEstado = oModel.SedEstado;
                    db.Entry(oUs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



     
    }
}
