using Microsoft.Extensions.Configuration;
using PruebaOneLink.DA.Empleado;
using PruebaOneLink.ET.Empleado;
using System.Collections.Generic;

namespace PruebaOneLink.BL.Empleado
{
    public class EmpleadoBL
    {
        EmpleadoDA empleadoDA;
        public EmpleadoBL(IConfiguration configuracion)
        {
            empleadoDA = new EmpleadoDA(configuracion);
        }

        public IList<EmpleadoResultET> Get()
        {
            return empleadoDA.Get();
        }

        public IList<EmpleadoET> GetByDocument(string documento)
        {
            return empleadoDA.GetByDocument(documento);
        }

        public IList<EmpleadoResultET> GetById(int id)
        {
            return empleadoDA.GetById(id);
        }
        public EmpleadoET Crear(EmpleadoET empleadoET)
        {
            return empleadoDA.Crear(empleadoET);
        }

        public EmpleadoET Actualizar (EmpleadoET empleadoET)
        {
            return empleadoDA.Actualizar(empleadoET);
        }
    }
}
