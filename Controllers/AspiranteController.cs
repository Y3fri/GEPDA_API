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
                    oPC.AspUniversidad = oModel.AspUniversidad;
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
                    oPC.AspPromedioPruebaIa = oModel.AspPromedioPruebaIa;
                    oPC.AspPromedioEntrevista = oModel.AspPromedioEntrevista;
                    oPC.AspPromedioPrueba2 = oModel.AspPromedioPrueba2;
                    oPC.AspNotaFinal = oModel.AspNotaFinal;
                    oPC.AspEstado = oModel.AspEstado;
                    db.SedeProgramaAspirantes.Add(oPC);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

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
                    oPC.AspUniversidad = oModel.AspUniversidad;
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
                    oPC.AspPromedioPruebaIa = oModel.AspPromedioPruebaIa;
                    oPC.AspPromedioEntrevista = oModel.AspPromedioEntrevista;
                    oPC.AspPromedioPrueba2 = oModel.AspPromedioPrueba2;
                    oPC.AspNotaFinal = oModel.AspNotaFinal;
                    oPC.AspEstado = oModel.AspEstado;
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
       
    }
}
