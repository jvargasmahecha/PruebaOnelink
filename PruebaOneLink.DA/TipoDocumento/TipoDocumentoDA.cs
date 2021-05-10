using Microsoft.Extensions.Configuration;
using PruebaOneLink.ET.TipoDocumento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PruebaOneLink.DA.TipoDocumento
{
    public class TipoDocumentoDA
    {
        string cadenaConn = string.Empty;

        public TipoDocumentoDA(IConfiguration configuracion)
        {
           cadenaConn = configuracion.GetConnectionString("DefaultConnection");

        }

        public IList<TipoDocumentoET> Get()
        {
            List<TipoDocumentoET> result = new List<TipoDocumentoET>();

            using (SqlConnection cnn = new SqlConnection(cadenaConn))
            {
                SqlCommand cmd = new SqlCommand("TipoDocumento_G", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TipoDocumentoET tipoDocumentoET = new TipoDocumentoET();
                        tipoDocumentoET.TDId = Convert.ToInt32(dr["TDId"]);
                        tipoDocumentoET.TDNombre = Convert.ToString(dr["TDNombre"]);
                        tipoDocumentoET.TDFechaCrea = Convert.ToDateTime(dr["TDFechaCrea"]);
                        if (dr["TDFechaEdicion"] != DBNull.Value)
                            tipoDocumentoET.TDFechaEdicion = Convert.ToDateTime(dr["TDFechaEdicion"]);
                        result.Add(tipoDocumentoET);
                    }
                }
                return result;
            }
        }
    }
}
