using Microsoft.Extensions.Configuration;
using PruebaOneLink.ET.Area;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PruebaOneLink.DA.Area
{
    public class AreaDA
    {
        string cadenaConn = string.Empty;

        public AreaDA(IConfiguration configuracion)
        {
            cadenaConn = configuracion.GetConnectionString("DefaultConnection");

        }

        public IList<AreaET> Get()
        {
            List<AreaET> result = new List<AreaET>();

            using (SqlConnection cnn = new SqlConnection(cadenaConn))
            {
                SqlCommand cmd = new SqlCommand("Area_G", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AreaET areaET = new AreaET();
                        areaET.ARId = Convert.ToInt32(dr["ARId"]);
                        areaET.ARNombre = Convert.ToString(dr["ARNombre"]);
                        areaET.ARFechaCrea = Convert.ToDateTime(dr["ARFechaCrea"]);
                        if (dr["ARFechaEdicion"] != DBNull.Value)
                            areaET.ARFechaEdicion = Convert.ToDateTime(dr["ARFechaEdicion"]);
                        result.Add(areaET);
                    }
                }
                return result;
            }

        }
    }
}
