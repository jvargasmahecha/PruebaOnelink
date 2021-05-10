using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaOneLink.BL.Empleado;
using PruebaOneLink.ET.Empleado;
using System.Collections.Generic;

namespace PruebaOneLink.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoBL empleadoBL;

        public EmpleadoController(IConfiguration configuration)
        {
            empleadoBL = new EmpleadoBL(configuration);
        }

        public ActionResult Index()
        {
            return View();
        }
           

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<EmpleadoResultET> Get()
        {
            IList<EmpleadoResultET> result = empleadoBL.Get();
            return result;
        }

        [HttpGet]
        public IEnumerable<EmpleadoET> GetByDocument(string id)
        {
            IList<EmpleadoET> result = empleadoBL.GetByDocument(id);
            return result;
        }

        [HttpGet]
        public IEnumerable<EmpleadoResultET> GetById(int id)
        {
            IList<EmpleadoResultET> result = empleadoBL.GetById(id);
            return result;
        }


        [HttpPost]
        public EmpleadoET Create([FromBody] EmpleadoET empleado)
        {
            if (empleado == null)
                return null;
            return empleadoBL.Crear(empleado);
        }

        [HttpPost]
        public void Update([FromBody] EmpleadoET empleado)
        {
            empleadoBL.Actualizar(empleado);
        }

        [HttpPost]
        public IEnumerable<EmpleadoResultET> GetByDocumentoOrNombre ([FromBody] OpcionesBusquedaET busqueda)
        {
            IList<EmpleadoResultET> result = empleadoBL.GetByDocumentoOrNombre(busqueda.Busqueda);
            return result;
        }
    }
}
