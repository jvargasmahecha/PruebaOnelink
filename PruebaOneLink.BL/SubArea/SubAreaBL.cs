using Microsoft.Extensions.Configuration;
using PruebaOneLink.DA.SubArea;
using PruebaOneLink.ET.SubArea;
using System.Collections.Generic;

namespace PruebaOneLink.BL.SubArea
{
    public class SubAreaBL
    {
        SubAreaDA subAreaDA;

        public SubAreaBL(IConfiguration configuracion)
        {
            subAreaDA = new SubAreaDA(configuracion);
        }

        public IList<SubAreaET> GetByAreaId(int areaId)
        {
            return subAreaDA.GetByAreaId(areaId);
        }
    }
}
