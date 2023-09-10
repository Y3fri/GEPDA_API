using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GEPDA_API.Models;
using GEPDA_API.Models.Request;
using GEPDA_API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GEPDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaIAController : ControllerBase
    {
        private readonly string _apiKey = "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";
        private readonly string _gpt3Endpoint = "https://api.openai.com/v1/chat/completions";

        [HttpPost]
        public async Task<IActionResult> Add(PruebaIARequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    string preguntaGenerada = await GenerarPreguntaAsync(oModel.IaTexto);
                    string preguntaGeneradaNormal = ExtraerPregunta(preguntaGenerada);

                    PruebaIum oPia = new PruebaIum();
                    oPia.IaUniversidad = oModel.IaUniversidad;
                    oPia.IaTitulo = oModel.IaTitulo;
                    oPia.IaTexto = oModel.IaTexto;
                    oPia.IaPregunta = preguntaGeneradaNormal;

                    // Asignar las opciones y la respuesta correcta al objeto PruebaIum
                    var (opcionA, opcionB, opcionC, opcionD, respuestaCorrecta) = ObtenerOpcionesYRespuesta(preguntaGenerada);
                    oPia.IaOpcionA = opcionA;
                    oPia.IaOpcionB = opcionB;
                    oPia.IaOpcionC = opcionC;
                    oPia.IaOpcionD = opcionD;
                    oPia.IaRespuesta = respuestaCorrecta;

                    oPia.IaImagen = oModel.IaImagen;
                    oPia.IaAudio = oModel.IaAudio;
                    oPia.IaEstado = oModel.IaEstado;

                    db.PruebaIa.Add(oPia);
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

        private async Task<string> GenerarPreguntaAsync(string texto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
                var requestData = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "system", content = "You are a helpful assistant." },
                        new { role = "user", content = "Genera una pregunta basada en el siguiente texto:\n" + texto + "\nLa pregunta debe tener un formato adecuado para una respuesta de opción múltiple. y dale la correcta, en este formato, nada mas, 'letra de la correcta).la pregunta'" },
                         new { role = "assistant", content = "Las opciones para responder son:\na)\nb)\nc)\nd)\nLa respuesta correcta es:" }
                    }
                };

                var jsonRequest = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_gpt3Endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<JObject>(jsonResponse);
                    var assistantMessage = responseObject["choices"][0]["message"]["content"].ToString();
                    Console.WriteLine(assistantMessage);
                    return assistantMessage;
                }
                else
                {
                    throw new Exception("Error al generar la pregunta.");
                }
            }
        }
        private string ExtraerPregunta(string respuestaGenerada)
        {
            // Encuentra el inicio de la pregunta (después del primer '?' encontrado)
            int inicioPregunta = respuestaGenerada.IndexOf('?', respuestaGenerada.IndexOf('?') + 1) + 1;

            // Encuentra el final de la pregunta (antes de las opciones)
            int finPregunta = respuestaGenerada.IndexOf("\na)");

            if (inicioPregunta >= 0 && finPregunta > inicioPregunta)
            {
                string pregunta = respuestaGenerada.Substring(inicioPregunta, finPregunta - inicioPregunta).Trim();
                return pregunta;
            }
            else
            {
                throw new Exception("No se pudo extraer la pregunta de la respuesta generada.");
            }
        }


        private (string opcionA, string opcionB, string opcionC, string opcionD, string respuestaCorrecta) ObtenerOpcionesYRespuesta(string preguntaGenerada)
        {
            // Extraer las opciones y la respuesta correcta del mensaje generado
            var match = Regex.Match(preguntaGenerada, @"(a\))\s(.*?)\n(b\))\s(.*?)\n(c\))\s(.*?)\n(d\))\s(.*?)\n\nLa respuesta correcta es:\s([a-d])\)\s(.*?)$");


            if (match.Success)
            {

                var opcionA = $"{match.Groups[1].Value} {match.Groups[2].Value}";
                var opcionB = $"{match.Groups[3].Value} {match.Groups[4].Value}";
                var opcionC = $"{match.Groups[5].Value} {match.Groups[6].Value}";
                var opcionD = $"{match.Groups[7].Value} {match.Groups[8].Value}";
                var respuestaCorrecta = $"{match.Groups[9].Value}) {match.Groups[10].Value}"; 

                return (opcionA, opcionB, opcionC, opcionD, respuestaCorrecta);
            }
            else
            {
                throw new Exception("No se pudo extraer las opciones y la respuesta correcta del mensaje generado.");
            }
        }
    }
}
