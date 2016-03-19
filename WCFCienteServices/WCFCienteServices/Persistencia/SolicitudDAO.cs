using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WCFCienteServices.Dominio;
using System.Data.SqlClient;

namespace WCFCienteServices.Persistencia
{
    public class SolicitudDAO
    {
        private string CadenaConexion = ConfigurationManager.AppSettings["sCnxSQL"].ToString();

        public long GenerarSolicitud(int codigoCliente)
        {
            long codigoSolicitud;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("uspGenerarSolicitudCliente", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@codigoCliente", codigoCliente));
                    codigoSolicitud = long.Parse(comando.ExecuteScalar().ToString());
                }
            }
            return codigoSolicitud;
        }

        public bool ValidarSiExisteSolicitudCliente(int codigoCliente)
        {
            bool existe;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("uspValidarSiExisteSolicitudCliente", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@codigoCliente", codigoCliente));
                    existe = bool.Parse(comando.ExecuteScalar().ToString());
                }
            }
            return existe;
        }
    }
}