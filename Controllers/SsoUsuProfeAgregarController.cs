using GEPDA_API.Models;
using GEPDA_API.Models.Request;
using GEPDA_API.Models.Response;
using GEPDA_API.Models.Services;
using GEPDA_API.Models.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GEPDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsoUsuProfeAgregarController : ControllerBase
    {
        private readonly ISsoUsuProfeAgregarService _ssoUsuProfeAgregarService;

        public SsoUsuProfeAgregarController(ISsoUsuProfeAgregarService ssoUsuProfeAgregarService)
        {
            _ssoUsuProfeAgregarService = ssoUsuProfeAgregarService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                oRespuesta.Data = _ssoUsuProfeAgregarService.get();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                oRespuesta.Data = _ssoUsuProfeAgregarService.get(Id);
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

        public IActionResult Add(SsoUsuProfeAgregarRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    SsoUsuProfe oUsu = new SsoUsuProfe();                    
                    oUsu.UsuPPrograma = oModel.UsuPPrograma;
                    oUsu.UsuPSede = oModel.UsuPSede;
                    oUsu.UsuPDocumento = oModel.UsuPDocumento;
                    oUsu.UsuPNombre = oModel.UsuPNombre;
                    oUsu.UsuPEmail = oModel.UsuPEmail;
                    oUsu.UsuPTelefono = oModel.UsuPTelefono;
                    oUsu.UsuPApellido = oModel.UsuPApellido;
                    oUsu.UsuPNickname = oModel.UsuPNickname;
                    oUsu.UsuPClave = Encrypt.GetSHA256(oModel.UsuPClave);
                    db.SsoUsuProves.Add(oUsu);
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

        public IActionResult Edit(SsoUsuProfeAgregarRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    SsoUsuProfe oUsu = db.SsoUsuProves.Find(oModel.UsuPId);
                    oUsu.UsuPPrograma = oModel.UsuPPrograma;
                    oUsu.UsuPSede = oModel.UsuPSede;
                    oUsu.UsuPDocumento = oModel.UsuPDocumento;
                    oUsu.UsuPNombre = oModel.UsuPNombre;
                    oUsu.UsuPEmail = oModel.UsuPEmail;
                    oUsu.UsuPTelefono = oModel.UsuPTelefono;
                    oUsu.UsuPApellido = oModel.UsuPApellido;
                    oUsu.UsuPNickname = oModel.UsuPNickname;
                    oUsu.UsuPClave = oModel.UsuPClave;

                    db.Entry(oUsu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    SsoUsuProfe oUsu = db.SsoUsuProves.Find(Id);
                    db.Remove(oUsu);
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
