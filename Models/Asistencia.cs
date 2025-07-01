using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Services_Asistens.Models
{
    public class Asistencia
    {
        public int ID { get; set; }
        public string CI { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Fecha { get; set; }
        public bool Falta { get; set; }
    }
}