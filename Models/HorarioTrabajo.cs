using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Services_Asistens.Models
{
    public class HorarioTrabajo
    {
        public DateTime HoraEntradaAM {  get; set; }
        public DateTime HoraSalidaAM { get; set; }
        public DateTime HoraEntradaPM { get; set; }
        public DateTime HOraSalidaPM { get; set; }
    }
}