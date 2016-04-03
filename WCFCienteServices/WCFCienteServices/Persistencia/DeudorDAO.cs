using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WCFCienteServices.Dominio;
using System.Data.SqlClient;

namespace WCFCienteServices.Persistencia
{
    public class DeudorDAO
    {
        private string CadenaConexion = ConfigurationManager.AppSettings["sCnxSQLSBS"].ToString();
        
        public decimal ObtenerDeudaPorDNI(int dni)
        {
            decimal resultado;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("uspObtenerDeudaPorDNI", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@DNI", dni));
                    resultado = (decimal)comando.ExecuteScalar();
                }
            }
            return resultado;
        }
    }
}