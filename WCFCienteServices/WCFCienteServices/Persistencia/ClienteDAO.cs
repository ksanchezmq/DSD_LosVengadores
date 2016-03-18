using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WCFCienteServices.Dominio;
using System.Data.SqlClient;

namespace WCFCienteServices.Persistencia
{
    public class ClienteDAO
    {
        private string CadenaConexion = ConfigurationManager.AppSettings["sCnxSQL"].ToString();

        public Cliente Buscar(int codigo)
        {
            Cliente clienteEncontrado = null;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("uspGetCliente", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@codigo", codigo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                CodAfiliado = (int)resultado[0],
                                Nombre = (string)resultado[1],
                                Dni = (int)resultado[2],
                                Direccion = (string)resultado[3],
                                Ruc = (string)resultado[4],
                                Estado = (string)resultado[5],
                                Tipo_pos = int.Parse(resultado[6].ToString())
                            };
                        }
                    }
                }
            }
            return clienteEncontrado;
        }
    }
}