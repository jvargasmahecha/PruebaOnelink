using Microsoft.Extensions.Configuration;
using PruebaOneLink.ET.Empleado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PruebaOneLink.DA.Empleado
{
    public class EmpleadoDA
    {
        string cadenaConn = string.Empty;
        public EmpleadoDA(IConfiguration configuracion)
        {
            cadenaConn = configuracion.GetConnectionString("DefaultConnection");            
        }
        public IList<EmpleadoResultET> Get()
        {
            List<EmpleadoResultET> result = new List<EmpleadoResultET>();

            using (SqlConnection cnn = new SqlConnection(cadenaConn))
            {
                SqlCommand cmd = new SqlCommand("Empleado_G", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        EmpleadoResultET empleado = new EmpleadoResultET();
                        empleado.EMId = Convert.ToInt32(dr["EMId"]);
                        empleado.EMNombre = Convert.ToString(dr["EMNombre"]);
                        empleado.EMApellido = Convert.ToString(dr["EMApellido"]);
                        empleado.TDNombre = Convert.ToString(dr["TDNombre"]);
                        empleado.EMDocumento= Convert.ToString(dr["EMDocumento"]);
                        empleado.EMTipoDocumentoId = Convert.ToInt32(dr["EMTipoDocumentoId"]);
                        empleado.SANombre = Convert.ToString(dr["SANombre"]);
                        empleado.ARId = Convert.ToInt32(dr["ARId"]);
                        empleado.ARNombre = Convert.ToString(dr["ARNombre"]);
                        empleado.EMSubAreaId = Convert.ToInt32(dr["EMSubAreaId"]);
                        empleado.EMFechaCrea = Convert.ToDateTime(dr["EMFechaCrea"]);
                        if (dr["EMFechaEdicion"] != DBNull.Value)
                            empleado.EMFechaEdicion = Convert.ToDateTime(dr["EMFechaEdicion"]);
                        result.Add(empleado);
                    }
                }
            }
            return result;
        }
        public IList<EmpleadoET> GetByDocument(string documento)
        {
            List<EmpleadoET> result = new List<EmpleadoET>();

            using (SqlConnection cnn = new SqlConnection(cadenaConn))
            {
                SqlCommand cmd = new SqlCommand("EmpleadoByDocumento_G", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pEMDocumento", documento);
                cnn.Open();
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        EmpleadoET empleado = new EmpleadoET();
                        empleado.EMId = Convert.ToInt32(dr["EMId"]);
                        empleado.EMNombre = Convert.ToString(dr["EMNombre"]);
                        empleado.EMApellido = Convert.ToString(dr["EMApellido"]);
                        empleado.EMDocumento = Convert.ToString(dr["EMDocumento"]);
                        empleado.EMTipoDocumentoId = Convert.ToInt32(dr["EMTipoDocumentoId"]);
                        empleado.EMSubAreaId = Convert.ToInt32(dr["EMSubAreaId"]);
                        empleado.EMFechaCrea = Convert.ToDateTime(dr["EMFechaCrea"]);
                        if (dr["EMFechaEdicion"] != DBNull.Value)
                            empleado.EMFechaEdicion = Convert.ToDateTime(dr["EMFechaEdicion"]);
                        result.Add(empleado);
                    }
                }
            }
            return result;
        }
        public IList<EmpleadoResultET> GetById(int id)
        {
            List<EmpleadoResultET> result = new List<EmpleadoResultET>();

            using (SqlConnection cnn = new SqlConnection(cadenaConn))
            {
                SqlCommand cmd = new SqlCommand("EmpleadoById_G", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pEMId", id);
                cnn.Open();
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        EmpleadoResultET empleado = new EmpleadoResultET();
                        empleado.EMId = Convert.ToInt32(dr["EMId"]);
                        empleado.EMNombre = Convert.ToString(dr["EMNombre"]);
                        empleado.EMApellido = Convert.ToString(dr["EMApellido"]);
                        empleado.EMDocumento = Convert.ToString(dr["EMDocumento"]);
                        empleado.EMTipoDocumentoId = Convert.ToInt32(dr["EMTipoDocumentoId"]);
                        empleado.EMSubAreaId = Convert.ToInt32(dr["EMSubAreaId"]);
                        empleado.ARId = Convert.ToInt32(dr["ARId"]);
                        empleado.EMFechaCrea = Convert.ToDateTime(dr["EMFechaCrea"]);
                        if (dr["EMFechaEdicion"] != DBNull.Value)
                            empleado.EMFechaEdicion = Convert.ToDateTime(dr["EMFechaEdicion"]);
                        result.Add(empleado);
                    }
                }
            }
            return result;
        }
        public EmpleadoET Crear(EmpleadoET empleadoET)        {
            using (SqlConnection cnn = new SqlConnection(cadenaConn))
            {
                SqlCommand cmd = new SqlCommand("Empleado_I", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                cmd.Parameters.AddWithValue("@pEMNombre", empleadoET.EMNombre);
                cmd.Parameters.AddWithValue("@pEMApellido", empleadoET.EMApellido);
                cmd.Parameters.AddWithValue("@pEMDocumento", empleadoET.EMDocumento);
                cmd.Parameters.AddWithValue("@pEMTipoDocumentoId", empleadoET.EMTipoDocumentoId);
                cmd.Parameters.AddWithValue("@pEMSubAreaId", empleadoET.EMSubAreaId);

                empleadoET.EMId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return empleadoET;

        }

        public EmpleadoET Actualizar (EmpleadoET empleadoET)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaConn))
            {
                SqlCommand cmd = new SqlCommand("Empleado_U", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                cmd.Parameters.AddWithValue("@pEMId", empleadoET.EMId);
                cmd.Parameters.AddWithValue("@pEMNombre", empleadoET.EMNombre);
                cmd.Parameters.AddWithValue("@pEMApellido", empleadoET.EMApellido);
                cmd.Parameters.AddWithValue("@pEMTipoDocumentoId", empleadoET.EMTipoDocumentoId);
                cmd.Parameters.AddWithValue("@pEMSubAreaId", empleadoET.EMSubAreaId);

                cmd.ExecuteNonQuery();
            }
            return empleadoET;

        }

        public IList<EmpleadoResultET> GetByDocumentoOrNombre(string busqueda)
        {
            List<EmpleadoResultET> result = new List<EmpleadoResultET>();

            using (SqlConnection cnn = new SqlConnection(cadenaConn))
            {
                SqlCommand cmd = new SqlCommand("EmpleadoByDocumentoOrNombre_G", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pBusqueda", busqueda);
                cnn.Open();
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        EmpleadoResultET empleado = new EmpleadoResultET();
                        empleado.EMId = Convert.ToInt32(dr["EMId"]);
                        empleado.EMNombre = Convert.ToString(dr["EMNombre"]);
                        empleado.EMApellido = Convert.ToString(dr["EMApellido"]);
                        empleado.TDNombre = Convert.ToString(dr["TDNombre"]);
                        empleado.EMDocumento = Convert.ToString(dr["EMDocumento"]);
                        empleado.EMTipoDocumentoId = Convert.ToInt32(dr["EMTipoDocumentoId"]);
                        empleado.SANombre = Convert.ToString(dr["SANombre"]);
                        empleado.ARId = Convert.ToInt32(dr["ARId"]);
                        empleado.ARNombre = Convert.ToString(dr["ARNombre"]);
                        empleado.EMSubAreaId = Convert.ToInt32(dr["EMSubAreaId"]);
                        empleado.EMFechaCrea = Convert.ToDateTime(dr["EMFechaCrea"]);
                        if (dr["EMFechaEdicion"] != DBNull.Value)
                            empleado.EMFechaEdicion = Convert.ToDateTime(dr["EMFechaEdicion"]);
                        result.Add(empleado);
                    }
                }
            }
            return result;
        }

    }
}
