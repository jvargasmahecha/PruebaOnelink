using Microsoft.Extensions.Configuration;
using PruebaOneLink.ET.SubArea;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PruebaOneLink.DA.SubArea
{
    public class SubAreaDA
    {
        string cadenaConn = string.Empty;

        public SubAreaDA(IConfiguration configuracion)
        {
            cadenaConn = configuracion.GetConnectionString("DefaultConnection");
        }

        public IList<SubAreaET> GetByAreaId (int areaId)
        {
            List<SubAreaET> result = new List<SubAreaET>();

            using (SqlConnection cnn = new SqlConnection(cadenaConn))
            {
                SqlCommand cmd = new SqlCommand("SubAreaByAreaId_G", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pSAAreaID", areaId);
                cnn.Open();
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SubAreaET subAreaET = new SubAreaET();
                        subAreaET.SAId = Convert.ToInt32(dr["SAId"]);
                        subAreaET.SANombre = Convert.ToString(dr["SANombre"]);
                        subAreaET.SAAreaId = Convert.ToInt32(dr["SAAreaId"]);
                        subAreaET.SAFechaCrea = Convert.ToDateTime(dr["SAFechaCrea"]);
                        if (dr["SAFechaEdicion"] != DBNull.Value)
                            subAreaET.SAFechaEdicion = Convert.ToDateTime(dr["SAFechaEdicion"]);
                        result.Add(subAreaET);
                    }
                }
                return result;
            }
        }
    }
}
