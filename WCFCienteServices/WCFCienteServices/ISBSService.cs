using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFCienteServices.Errores;
using WCFCienteServices.Dominio;
using System.ServiceModel.Web;

namespace WCFCienteServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClientes" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISBSService
    {
        [WebInvoke(
            Method = "GET", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json, 
            UriTemplate = "deuda/{dni}"
        )]
        decimal ObtenerDeudaPorDNI(string dni);
    }
}
