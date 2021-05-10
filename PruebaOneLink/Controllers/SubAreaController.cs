using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaOneLink.BL.SubArea;
using PruebaOneLink.ET.SubArea;
using System.Collections.Generic;

namespace PruebaOneLink.Controllers
{
    public class SubAreaController : Controller
    {
        SubAreaBL subAreaBL;

        public SubAreaController(IConfiguration configuracion)
        {
            subAreaBL = new SubAreaBL(configuracion);
        }
        public IEnumerable<SubAreaET> GetByAreaId (int id)
        {
            IList<SubAreaET> result = subAreaBL.GetByAreaId(id);
            return result;
        }
        
    }
}
