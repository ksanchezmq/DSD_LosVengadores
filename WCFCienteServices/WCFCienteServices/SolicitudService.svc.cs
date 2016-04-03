using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFCienteServices.Persistencia;
using System.Net;
using System.Configuration;
using WCFCienteServices.Dominio;

namespace WCFCienteServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Solicitud" in code, svc and config file together.
    public class SolicitudService : ISolicitudService
    {
        public long GenerarSolicitud(int codigoCliente)
        {
            var codigoSolicitud = new SolicitudDAO().GenerarSolicitud(codigoCliente);
            EnviarNotificacion(codigoCliente, codigoSolicitud);
            return codigoSolicitud;
        }

        public bool ValidarSiExisteSolicitudCliente(string codigoCliente) 
        {
            return new SolicitudDAO().ValidarSiExisteSolicitudCliente(int.Parse(codigoCliente));
        }

        private void EnviarNotificacion(int codigoCliente, long codigoSolicitud) 
        {
            var cliente = new ClienteDAO().Buscar(codigoCliente);

            var fromAddress = ConfigurationManager.AppSettings["UserNameSMTP"];
            var toAddress = cliente.Correo;
            var fromPassword = ConfigurationManager.AppSettings["PasswordSMTP"];
            var subject = "Notificacion de Reactivacion";
            var body = "N° Solicitud: " + codigoSolicitud.ToString();
            
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = ConfigurationManager.AppSettings["EmailServer"];
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }

            try
            {
                smtp.Send(fromAddress, toAddress, subject, body);
            }
            catch (Exception)
            {
                //logear  error
            }
        }

        public List<Solicitud> ListarSolicitudes(string codigoServicio)
        {
            var codServicio = string.IsNullOrEmpty(codigoServicio) ? new int?() : int.Parse(codigoServicio);
            return new SolicitudDAO().ListarSolicitudes(codServicio);
        }

        public void ActulizarSolicitud(string codigoSolicitud, SolicitudParaGrabar solicitud)
        {
            new SolicitudDAO().ActualizarSolicitud(solicitud);
        }
    }
}
