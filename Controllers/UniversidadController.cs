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

        [HttpGet("{Id}/Universidad")]
        public IActionResult Get(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _universidadService.get(Id);
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
        public IActionResult Add( UniversidadRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    InformacionUniversidad oIU = new InformacionUniversidad();
                    oIU.UniMunicipio = oModel.UniMunicipio;
                    oIU.UniNombre = oModel.UniNombre;
                    oIU.UniEmailPrincipal = oModel.UniEmailPrincipal;
                    oIU.UniDireccionPrincipal = oModel.UniDireccionPrincipal;
                    oIU.UniTelefonoPrincipal = oModel.UniTelefonoPrincipal;
                    oIU.UniLogo = oModel.UniLogo;
                    db.InformacionUniversidads.Add(oIU);
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
        public IActionResult Edit(UniversidadRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    InformacionUniversidad oIU = db.InformacionUniversidads.Find(oModel.UniId);
                    oIU.UniMunicipio = oModel.UniMunicipio;
                    oIU.UniNombre = oModel.UniNombre;
                    oIU.UniEmailPrincipal = oModel.UniEmailPrincipal;
                    oIU.UniDireccionPrincipal = oModel.UniDireccionPrincipal;
                    oIU.UniTelefonoPrincipal = oModel.UniTelefonoPrincipal;
                    oIU.UniLogo = oModel.UniLogo;
                    db.Entry(oIU).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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



        [HttpDelete("{Id}")]
        [Authorize]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    InformacionUniversidad oMM = db.InformacionUniversidads.Find(Id);
                    db.Remove(oMM);
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
