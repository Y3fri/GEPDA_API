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
    public class CriteriosController : ControllerBase
    {
        private readonly ICriterioService _criterioService;

        public CriteriosController(ICriterioService criterioService)
        {
            _criterioService = criterioService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _criterioService.get();
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}/Programa")]
        public IActionResult Get(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _criterioService.get(Id);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}/Sede")]       
        public IActionResult Gets(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _criterioService.gets(Id);
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
        public IActionResult Add(ProgramaCriterioRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    ProgramaCriterio oPC = new ProgramaCriterio();
                    oPC.CriSede = oModel.CriSede;
                    oPC.CriPrograma = oModel.CriPrograma;
                    oPC.CriNombre = oModel.CriNombre;
                    oPC.CriDescripcion = oModel.CriDescripcion;                                       
                    db.ProgramaCriterios.Add(oPC);
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
        public IActionResult Edit(ProgramaCriterioRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    ProgramaCriterio oPC = db.ProgramaCriterios.Find(oModel.CriId);
                    oPC.CriSede = oModel.CriSede;
                    oPC.CriPrograma = oModel.CriPrograma;
                    oPC.CriNombre = oModel.CriNombre;
                    oPC.CriDescripcion = oModel.CriDescripcion;
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
                    ProgramaCriterio oMM = db.ProgramaCriterios.Find(Id);
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
