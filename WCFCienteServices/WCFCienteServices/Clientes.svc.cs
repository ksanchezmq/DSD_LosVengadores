using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFCienteServices.Dominio;
using WCFCienteServices.Errores;
using WCFCienteServices.Persistencia;

namespace WCFCienteServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Clientes" en el código, en svc y en el archivo de configuración a la vez.
    public class Clientes : IClientes
    {

        #region Miembros de IClientes
        private ClienteDAO clienteDAO = new ClienteDAO();

        public Cliente ObtenerCliente(int codigo)
        {
            if (clienteDAO.Buscar(codigo) == null)
            {
                throw new FaultException<ClienteExcepciones>(new ClienteExcepciones()
                {
                    codigo = "101",
                    descripcion = "Código no existe."
                }, new FaultReason("Error al buscar cliente"));
            }
            return clienteDAO.Buscar(codigo);
        }

        public bool ValidarExisteCliente(int codigoCliente)
        {
            return new ClienteDAO().ValidarExisteCliente(codigoCliente);
        }

        #endregion
    }
}
