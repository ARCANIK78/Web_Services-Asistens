using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Services_Asistens.Models
{
    public class qr
    {
        public int ID { get; set; }
        public string CI { get; set; }
        public string CodigoQR { get; set; }
        public DateTime FechaGeneracion { get; set; }

    }
}