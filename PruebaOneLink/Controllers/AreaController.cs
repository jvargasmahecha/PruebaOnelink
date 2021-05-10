using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaOneLink.BL.Area;
using PruebaOneLink.ET.Area;
using System.Collections.Generic;

namespace PruebaOneLink.Controllers
{
    public class AreaController : Controller
    {
        AreaBL areaBL;

        public AreaController(IConfiguration configuracion)
        {
            areaBL = new AreaBL(configuracion);
        }

        [HttpGet]
        public IEnumerable<AreaET> Get()
        {
            IList<AreaET> result = areaBL.Get();
            return result;
        }
    }
}
