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
                using (SqlCommand comando = new SqlCommand("uspObtenerCliente", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@codigo", codigo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                CodAfiliado = (int)resultado["CODAFILIADO"],
                                Nombre = (string)resultado["NOMBRE"],
                                Dni = (int)resultado["DNI"],
                                Direccion = (string)resultado["DIRECCION"],
                                Ruc = (string)resultado["RUC"],
                                Estado = (string)resultado["ESTADODESCRIPCION"],
                                Tipo_pos = int.Parse(resultado["CODTIPOPOS"].ToString()),
                                Correo = (string)resultado["CORREO"].ToString()
                            };
                        }
                    }
                }
            }
            return clienteEncontrado;
        }

        public bool ValidarExisteCliente(int codigoCliente)
        {
            bool existe;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("uspValidarCodigoCliente", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@codigo", codigoCliente));
                    existe = bool.Parse(comando.ExecuteScalar().ToString());
                }
            }
            return existe;
        }
    }
}