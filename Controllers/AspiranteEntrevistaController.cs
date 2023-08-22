using GEPDA_API.Models;
using GEPDA_API.Models.Response;
using GEPDA_API.Models.Services;
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

                using (var db = new GEPDA_BDContext())
                {
                    var entrevistasConPrograma = db.Entrevista
                        .Include(e => e.EntProgramaNavigation) // Incluye la relación a SedePrograma
                        .ToList();

                    foreach (var entrevista in entrevistasConPrograma)
                    {
                        var aspirantesMismoPrograma = db.SedeProgramaAspirantes
                            .Where(a => a.AspPrograma == entrevista.EntPrograma)
                            .ToList();

                        foreach (var aspirante in aspirantesMismoPrograma)
                        {
                            var relacionExistente = db.AspiranteEntrevista
                                .Any(r => r.IdAspirante == aspirante.AspId && r.IdEntrevista == entrevista.EntId);

                            if (!relacionExistente)
                            {
                                var nuevaRelacion = new AspiranteEntrevistum
                                {
                                    IdAspirante = aspirante.AspId,
                                    IdEntrevista = entrevista.EntId,
                                    Nota = null
                                };

                                db.AspiranteEntrevista.Add(nuevaRelacion);
                            }
                        }
                    }

                    db.SaveChanges();
                }
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
