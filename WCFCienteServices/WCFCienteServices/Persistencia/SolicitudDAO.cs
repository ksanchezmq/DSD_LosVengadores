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

        public List<Solicitud> ListarSolicitudes(int? codigoSolicitud)
        {
            var resultado  = new List<Solicitud>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("uspObtenerSolicitudes", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@codigoSolicitud", codigoSolicitud));
                    var dr = comando.ExecuteReader();
                    
                    while (dr.Read()) {
                        resultado.Add(new Solicitud {
                            CodigoSolicitud = (long)dr["CODIGOSOLICITUD"],
                            EstadoDescripcion = dr["ESTADODESCRIPTION"].ToString(),
                            FechaHora = dr["FECHAHORA"].ToString(),
                            CodigoAfiliado = (int)dr["CODAFILIADO"],
                            NombreCliente = dr["NOMBRECLIENTE"].ToString(),
                            DNI = (int)dr["DNI"],
                            RUC = dr["RUC"].ToString()
                        });
                    }
                }
            }
            return resultado;
        }

        public void ActualizarSolicitud(SolicitudParaGrabar solicitud)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("uspActualizarSolicitud", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@codigoSolicitud", solicitud.CodigoSolicitud));
                    comando.Parameters.Add(new SqlParameter("@codigoEstado", solicitud.Estado));
                    comando.Parameters.Add(new SqlParameter("@observacion", solicitud.Observacion));

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}