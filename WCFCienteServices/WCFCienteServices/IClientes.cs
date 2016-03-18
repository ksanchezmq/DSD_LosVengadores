using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFCienteServices.Errores;
using WCFCienteServices.Dominio;

namespace WCFCienteServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClientes" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IClientes
    {
        [FaultContract(typeof(ClienteExcepciones))]
        [OperationContract]
        Cliente ObtenerCliente(int codigo); 
    }
}
