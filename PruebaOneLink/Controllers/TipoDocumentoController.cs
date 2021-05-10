using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaOneLink.BL.TipoDocumento;
using PruebaOneLink.ET.TipoDocumento;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaOneLink.Controllers
{
    public class TipoDocumentoController : Controller
    {
        TipoDocumentoBL tipoDocumentoBL;

        public TipoDocumentoController(IConfiguration configuracion)
        {
            tipoDocumentoBL = new TipoDocumentoBL(configuracion);
        }

        [HttpGet]
        public IEnumerable<TipoDocumentoET> Get()
        {
            IList<TipoDocumentoET> result = tipoDocumentoBL.Get();
            return result;
        }                
    }
}
