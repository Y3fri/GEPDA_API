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
    public class SsoUsuarioAgregarController : ControllerBase
    {
        private readonly ISsoUsuarioAgregarService _ssoUsuarioAgregarService;

        public SsoUsuarioAgregarController(ISsoUsuarioAgregarService ssoUsuarioAgregarService)
        {
            _ssoUsuarioAgregarService = ssoUsuarioAgregarService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                oRespuesta.Data = _ssoUsuarioAgregarService.get();
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
                oRespuesta.Data = _ssoUsuarioAgregarService.get(Id);
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

        public IActionResult Add(SsoUsuarioAgregarRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    SsoUsuario oUsu = new SsoUsuario();
                    oUsu.UsuRol = oModel.UsuRol;
                    oUsu.UsuUniversidad = oModel.UsuUniversidad;
                    oUsu.UsuSede = oModel.UsuSede;
                    oUsu.UsuDocumento = oModel.UsuDocumento;
                    oUsu.UsuNombre = oModel.UsuNombre;
                    oUsu.UsuEmail = oModel.UsuEmail;
                    oUsu.UsuApellido = oModel.UsuApellido;
                    oUsu.UsuNickname = oModel.UsuNickname;
                    oUsu.UsuClave = Encrypt.GetSHA256(oModel.UsuClave);
                    db.SsoUsuarios.Add(oUsu);
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

        public IActionResult Edit(SsoUsuarioAgregarRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    SsoUsuario oUsu = db.SsoUsuarios.Find(oModel.UsuId);
                    oUsu.UsuRol = oModel.UsuRol;
                    oUsu.UsuUniversidad = oModel.UsuUniversidad;
                    oUsu.UsuSede = oModel.UsuSede;
                    oUsu.UsuEmail = oModel.UsuEmail;
                    oUsu.UsuDocumento = oModel.UsuDocumento;
                    oUsu.UsuNombre = oModel.UsuNombre;
                    oUsu.UsuApellido = oModel.UsuApellido;
                    oUsu.UsuNickname = oModel.UsuNickname;
                    oUsu.UsuClave = oModel.UsuClave;

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
                    SsoUsuario oUsu = db.SsoUsuarios.Find(Id);
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
