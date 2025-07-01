using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web_Services_Asistens.Controllers
{
    public class AsistenciaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}