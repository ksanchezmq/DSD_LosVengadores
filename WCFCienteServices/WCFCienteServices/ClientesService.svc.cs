using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using WCFCienteServices.Dominio;
using WCFCienteServices.Errores;
using WCFCienteServices.Persistencia;

namespace WCFCienteServices
{
    public class ClientesService : IClientesService
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

        public void EvaluarCliente(int dni, string ruc)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create(string.Format("http://localhost:34768/SunatService.svc/contribuyente/{0}", ruc));
                req.Method = "GET";
                var response = req.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(response);
                string responseFromServer = reader.ReadToEnd();

                var existeRUC = bool.Parse(responseFromServer);

                //solo si existe registro de contribuyente se debe validar si el cliente tiene deuda en registrada en SBS
                if (existeRUC)
                {
                    req = (HttpWebRequest)WebRequest
                        .Create(string.Format("http://localhost:34768/SBSService.svc/deuda/{0}", dni));
                    req.Method = "GET";
                    response = req.GetResponse().GetResponseStream();
                    reader = new StreamReader(response);
                    responseFromServer = reader.ReadToEnd();

                    var deuda = decimal.Parse(responseFromServer);
                    var existeDeuda = deuda > 0;

                    if (existeDeuda) {
                        throw new FaultException("Cliente tiene deuda registrada en SBS");
                    }

                    return;
                }

                throw new FaultException("RUC del Cliente no se encuentra activo en la Sunat");
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                throw new FaultException(error);
            }
        }

        #endregion
    }
}
