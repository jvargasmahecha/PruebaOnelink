using Microsoft.Extensions.Configuration;
using PruebaOneLink.DA.TipoDocumento;
using PruebaOneLink.ET.TipoDocumento;
using System.Collections.Generic;

namespace PruebaOneLink.BL.TipoDocumento
{
    public class TipoDocumentoBL
    {
        TipoDocumentoDA tipoEmpleadoDA;
        public TipoDocumentoBL(IConfiguration configuracion)
        {
            tipoEmpleadoDA = new TipoDocumentoDA(configuracion);
        }

        public IList<TipoDocumentoET> Get()
        {
            return tipoEmpleadoDA.Get();
        }
    }
}
