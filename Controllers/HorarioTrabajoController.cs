using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web_Services_Asistens.Models;

namespace Web_Services_Asistens.Controllers
{
    public class HorarioTrabajoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
           var adaptador = new dbAsistenciaTableAdapters.THorarioTrabajoTableAdapter();
            var tabla = adaptador.GetData();
            if (tabla.Count == 0)
                return NotFound();

            var horario = tabla[0];
            return Ok(new
            {
                EntradaAM = horario.HoraEntradaAM.ToString(),
                SalidaAM = horario.HoraSalidaAM.ToString(),
                EntradaPM = horario.HoraEntradaPM.ToString(),
                SalidaPM = horario.HoraSalidaPM.ToString()
            });
        }
    }
}