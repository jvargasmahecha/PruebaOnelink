using Microsoft.Extensions.Configuration;
using PruebaOneLink.DA.Area;
using PruebaOneLink.ET.Area;
using System.Collections.Generic;

namespace PruebaOneLink.BL.Area
{
    public class AreaBL
    {
        AreaDA areaDA;

        public AreaBL(IConfiguration connfiguracion)
        {
            areaDA = new AreaDA(connfiguracion);
        }

        public IList<AreaET> Get()
        {
            return areaDA.Get();
        }
    }
}
