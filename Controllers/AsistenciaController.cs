using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web_Services_Asistens.Models;

namespace Web_Services_Asistens.Controllers
{
    public class AsistenciaController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody] Asistencia nuevo)
        {
            if (nuevo == null || string.IsNullOrEmpty(nuevo.CI) || string.IsNullOrEmpty(nuevo.Tipo))
                return BadRequest("Datos de asistencia inválidos.");

            var adaptador = new dbAsistenciaTableAdapters.TAsistenciaTableAdapter();
            DateTime fechaHoy = DateTime.Now.Date;
            TimeSpan horaActual = DateTime.Now.TimeOfDay;

            try
            {
                adaptador.InsertarValores(horaActual.ToString(@"hh\:mm\:ss"), fechaHoy.ToString("yyyy-MM-dd"), nuevo.CI, nuevo.Falta, nuevo.Tipo);
                return Ok("Asistencia registrada correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al registrar asistencia: {ex.Message}");
            }
        }
    }
}

