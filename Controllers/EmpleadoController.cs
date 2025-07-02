using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web_Services_Asistens.Models;
using WS_asistens.services;

namespace Web_Services_Asistens.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var adaptador = new dbAsistenciaTableAdapters.TEmpleadoTableAdapter();
            var tabla = adaptador.GetData();
            var lista = new List<Empleado>();
            foreach (var item in tabla)
            {
                lista.Add(new Empleado
                {
                    CI = item.CI,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Celular = item.Celular,
                    Direccion = item.Direccion,
                    FechaNacimiento = item.FechaNacimiento
                });
            }
            return Ok(lista);
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] Empleado nuevo)
        {
            if (nuevo == null)
                return BadRequest("Datos Empleado invalido");
            var adaptador = new dbAsistenciaTableAdapters.TEmpleadoTableAdapter();
            var adaptadorQR = new dbAsistenciaTableAdapters.TQRTableAdapter();

            try
            {
                var empleadoExistente = adaptador.GetData();
                bool existe = empleadoExistente.Any(e => e.CI == nuevo.CI);
                if(existe)
                {
                    return BadRequest($"Ya existe un empleado con CI {nuevo.CI}.");
                }
                adaptador.Insert(
                    nuevo.CI,
                    nuevo.Nombre,
                    nuevo.Apellido,
                    nuevo.Celular,
                    nuevo.Direccion,
                    nuevo.FechaNacimiento

                 );
                string contenidoQR = $"CI={nuevo.CI}";
                string codigoQR = GeneradorQR.GenerarQR(contenidoQR);
                DateTime fechaGenerada = DateTime.Now;
                adaptadorQR.Insert(nuevo.CI, codigoQR, fechaGenerada);

                return Ok("Empleado Insertado Correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}