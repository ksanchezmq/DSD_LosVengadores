using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFCienteServices.Dominio;
using System.ServiceModel.Web;

namespace WCFCienteServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISolicitud" in both code and config file together.
    [ServiceContract]
    public interface ISolicitudService
    {
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "solicitud")]
        long GenerarSolicitud(int codigoCliente);

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "solicitudCliente?codCliente={codigoCliente}")]
        bool ValidarSiExisteSolicitudCliente(string codigoCliente);

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "solicitud?codServicio={codigoServicio}")]
        List<Solicitud> ListarSolicitudes(string codigoServicio);

        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "solicitud/{codigoSolicitud}")]
        void ActulizarSolicitud(string codigoSolicitud, SolicitudParaGrabar solicitud);
    }
}
