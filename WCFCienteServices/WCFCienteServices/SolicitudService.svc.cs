using System.Collections.Generic;
using System.Text;
using WCFCienteServices.Persistencia;
using System.Net;
using System.Configuration;
using WCFCienteServices.Dominio;
using System.Net.Mail;
using System.Messaging;
using WCFCienteServices.Entidad;

namespace WCFCienteServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Solicitud" in code, svc and config file together.
    public class SolicitudService : ISolicitudService
    {
        public long GenerarSolicitud(int codigoCliente)
        {
            var codigoSolicitud = new SolicitudDAO().GenerarSolicitud(codigoCliente);
            var cliente = new ClienteDAO().Buscar(codigoCliente);
            var rutaCola = @".\private$\DSD_LosVengadores";

            if (!MessageQueue.Exists(rutaCola))
            {
                MessageQueue.Create(rutaCola);
            }

            var cola = new MessageQueue(rutaCola);
            var mensaje = new Message();
            mensaje.Label = "Generar Solicitud";
            mensaje.Body = new Notificacion()
            {
                ToAddress = cliente.Correo,
                Subject = "Notificacion de Reactivacion",
                Body = "N° Solicitud: " + codigoSolicitud.ToString(),
            };

            cola.Send(mensaje);

            return codigoSolicitud;
        }

        public bool ValidarSiExisteSolicitudCliente(string codigoCliente) 
        {
            return new SolicitudDAO().ValidarSiExisteSolicitudCliente(int.Parse(codigoCliente));
        }
        
        public List<Solicitud> ListarSolicitudes(string codigoServicio)
        {
            var codServicio = string.IsNullOrEmpty(codigoServicio) ? new int?() : int.Parse(codigoServicio);
            return new SolicitudDAO().ListarSolicitudes(codServicio);
        }

        public void ActulizarSolicitud(string codigoSolicitud, SolicitudParaGrabar solicitud)
        {
            new SolicitudDAO().ActualizarSolicitud(solicitud);

            var cliente = new ClienteDAO().Buscar(solicitud.CodigoCliente);
            var rutaCola = @".\private$\DSD_LosVengadores";

            if (!MessageQueue.Exists(rutaCola))
            {
                MessageQueue.Create(rutaCola);
            }

            var cola = new MessageQueue(rutaCola);
            var mensaje = new Message();
            mensaje.Label = ((solicitud.Estado == 2 || solicitud.Estado == 3) ? "Evaluar Solicitud" : "Instalar Dispositivo");
            mensaje.Body = new Notificacion()
            {
                ToAddress = cliente.Correo,
                Subject = ((mensaje.Label == "Instalar Dispositivo") ? "Notificacion de Evaluacion" : "Notificacion de Instalación"),
                Body = "N° Solicitud: " + codigoSolicitud.ToString(),
            };

            cola.Send(mensaje);
        }
    }
}
