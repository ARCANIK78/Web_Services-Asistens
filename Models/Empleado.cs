using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Services_Asistens.Models
{
    public class Empleado
    {
        public string CI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Celular { get; set; }
        public String Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}