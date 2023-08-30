using GEPDA_API.Models;
using GEPDA_API.Models.Request;
using GEPDA_API.Models.Response;
using GEPDA_API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspiranteEntrevistaController : ControllerBase
    {
        private readonly IAspiranteEntrevista _aspiranteEntrevista;
        public AspiranteEntrevistaController(IAspiranteEntrevista aspiranteEntrevista)
        {
            _aspiranteEntrevista = aspiranteEntrevista;
        }
        [HttpGet("{Id}/{Est}")]
        public IActionResult Get(int Id, int Est)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _aspiranteEntrevista.Get(Id, Est);


                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpGet("{idAspirante}")]
        public IActionResult GetInterviews(int idAspirante)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {

                    oRespuesta.Data = _aspiranteEntrevista.Gets(idAspirante);
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
        public IActionResult Edit(AspiranteEntrevistaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    AspiranteEntrevistum oPC = db.AspiranteEntrevista.Find(oModel.Id);
                    oPC.IdEntrevista = oModel.IdEntrevista;
                    oPC.IdAspirante = oModel.IdAspirante;
                    oPC.Nota = oModel.Nota;
                    oPC.FechaEntre = DateTime.Now.ToString("yyyy/MM/dd 'Hora' HH:mm");
                    db.Entry(oPC).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                    // Buscar todas las entrevistas del mismo aspirante
                    List<AspiranteEntrevistum> entrevistasDelMismoAspirante = db.AspiranteEntrevista
                        .Where(e => e.IdAspirante == oModel.IdAspirante)
                        .ToList();

                    // Calcular el promedio de las notas
                    double? sumaNotas = 0;
                    foreach (var entrevista in entrevistasDelMismoAspirante)
                    {
                        sumaNotas += entrevista.Nota;
                    }
                    double? promedioNotas = entrevistasDelMismoAspirante.Count > 0
                    ? sumaNotas / entrevistasDelMismoAspirante.Count
                    : null; // Si no hay entrevistas, el promedio será nulo

                    SedeProgramaAspirante oP = db.SedeProgramaAspirantes.SingleOrDefault(e => e.AspId == oModel.IdAspirante);
                    oP.AspPromedioEntrevista = promedioNotas;
                    db.Entry(oP).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
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
