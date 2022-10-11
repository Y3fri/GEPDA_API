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
    public class AspiranteController : ControllerBase
    {
        private readonly IAspiranteService _aspiranteService;

        public AspiranteController(IAspiranteService aspiranteService)
        {
            _aspiranteService = aspiranteService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _aspiranteService.get();
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}/Sede")]
        [Authorize]
        public IActionResult Get(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _aspiranteService.get(Id);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}/Programa")]
        [Authorize]
        public IActionResult Gets(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _aspiranteService.gets(Id);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpPost]

        public IActionResult Add(SedeProgramaAspiranteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    SedeProgramaAspirante oPC = new SedeProgramaAspirante();
                    oPC.AspSede = oModel.AspSede;
                    oPC.AspPrograma = oModel.AspPrograma;
                    oPC.AspDni = oModel.AspDni;
                    oPC.AspMunicipio = oModel.AspMunicipio;
                    oPC.AspDocumento = oModel.AspDocumento;
                    oPC.AspNombres = oModel.AspNombres;
                    oPC.AspApellidos = oModel.AspApellidos;
                    oPC.AspBarrio = oModel.AspBarrio;
                    oPC.AspDireccion= oModel.AspDireccion;
                    oPC.AspTelefono= oModel.AspTelefono;
                    oPC.AspNota1 = oModel.AspNota1;
                    oPC.AspNota2 = oModel.AspNota2;
                    oPC.AspNota3 = oModel.AspNota3;
                    oPC.AspNota4 = oModel.AspNota4;
                    oPC.AspNota5 = oModel.AspNota5;
                    oPC.AspPromedio = oModel.AspPromedio;
                    
                    db.SedeProgramaAspirantes.Add(oPC);
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
        public IActionResult Edit(SedeProgramaAspiranteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    SedeProgramaAspirante oPC = db.SedeProgramaAspirantes.Find(oModel.AspId);
                    oPC.AspSede = oModel.AspSede;
                    oPC.AspPrograma = oModel.AspPrograma;
                    oPC.AspDni = oModel.AspDni;
                    oPC.AspMunicipio = oModel.AspMunicipio;
                    oPC.AspDocumento = oModel.AspDocumento;
                    oPC.AspNombres = oModel.AspNombres;
                    oPC.AspApellidos = oModel.AspApellidos;
                    oPC.AspBarrio = oModel.AspBarrio;
                    oPC.AspDireccion = oModel.AspDireccion;
                    oPC.AspTelefono = oModel.AspTelefono;
                    oPC.AspNota1 = oModel.AspNota1;
                    oPC.AspNota2 = oModel.AspNota2;
                    oPC.AspNota3 = oModel.AspNota3;
                    oPC.AspNota4 = oModel.AspNota4;
                    oPC.AspNota5 = oModel.AspNota5;
                    oPC.AspPromedio = (oModel.AspNota1+ oModel.AspNota2+ oModel.AspNota3+ oModel.AspNota4+ oModel.AspNota5)/5;
                    oPC.AspFecha = oModel.AspFecha;                   
                    db.Entry(oPC).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    SedeProgramaAspirante oMM = db.SedeProgramaAspirantes.Find(Id);
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
