using System;

namespace PruebaOneLink.ET.Empleado
{
    public class EmpleadoET
    {
        public int EMId { get; set; }
        public string EMNombre { get; set; }
        public string EMApellido { get; set; }
        public string EMDocumento { get; set; }
        public int EMTipoDocumentoId { get; set; }
        public int EMSubAreaId { get; set; }
        public DateTime EMFechaCrea { get; set; }
        public DateTime EMFechaEdicion { get; set; }
    }
}