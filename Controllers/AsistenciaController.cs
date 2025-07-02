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
            if (nuevo == null)
                return BadRequest("Datos de Asistencia Invalidos");
            var adaptador = new dbAsistenciaTableAdapters.TAsistenciaTableAdapter();
            DateTime fechaHoy = DateTime.Now.Date;
            TimeSpan horaACtual = DateTime.Now.TimeOfDay;
            try
            {
                adaptador.Insert( horaACtual, fechaHoy, nuevo.CI, nuevo.Falta);
                return Ok("Asistencia registrada correctamente. ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

