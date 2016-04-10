using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WCFCienteServices.Dominio;
using System.Data.SqlClient;

namespace WCFCienteServices.Persistencia
{
    public class ContribuyenteDAO
    {
        private string CadenaConexion = ConfigurationManager.AppSettings["sCnxSQLSunat"].ToString();
        
        public bool ValidarRUCContribuyente(string ruc)
        {
            bool existe;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("uspValidarRUCContribuyente", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@RUC", ruc));
                    existe = bool.Parse(comando.ExecuteScalar().ToString());
                }
            }
            return existe;
        }
    }
}