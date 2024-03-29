﻿using GEPDA_API.Models;
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
    public class ProgramaController : ControllerBase
    {
        private readonly IProgramaService _programaService;

        public ProgramaController(IProgramaService programaService)
        {
            _programaService = programaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _programaService.get();
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}/Programa/{Est}")]
        public IActionResult Get(int Id, int Est)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _programaService.get(Id,Est);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}/Sede/{Est}")]
        public IActionResult Gets(int Id, int Est)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _programaService.gets(Id, Est);
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{Id}/Universidad/{Est}")]
        public IActionResult Getis(int Id,int Est)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _programaService.getis(Id,Est);
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
        public IActionResult Add(SedeProgramaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    SedePrograma oSP = new SedePrograma();
                    oSP.ProSede = oModel.ProSede;
                    oSP.ProUniversidad = oModel.ProUniversidad;
                    oSP.ProNombre = oModel.ProNombre;
                    oSP.ProDescripcion = oModel.ProDescripcion;
                    oSP.ProEstado = oModel.ProEstado;
                    db.SedeProgramas.Add(oSP);
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
        public IActionResult Edit(SedeProgramaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    SedePrograma oSP = db.SedeProgramas.Find(oModel.ProId);
                    oSP.ProSede = oModel.ProSede;
                    oSP.ProUniversidad = oModel.ProUniversidad;
                    oSP.ProNombre = oModel.ProNombre;
                    oSP.ProDescripcion = oModel.ProDescripcion;
                    oSP.ProEstado = oModel.ProEstado;
                    db.Entry(oSP).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
