using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Services_Asistens.Models;
using System.Web.Http;
namespace Web_Services_Asistens.Controllers
{
    public class qrController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var adaptador = new dbAsistenciaTableAdapters.TQRTableAdapter();
            var tabla = adaptador.GetData();
            var lista = new List<qr>();
            foreach (var item in tabla)
            {
                lista.Add(new qr
                {
                    ID = item.ID,
                    CI = item.CI,
                    CodigoQR = item.CodigoQR,
                    FechaGeneracion = item.FechaGeneracion
                });
            }
            return Ok(lista);
        }
    }
}

