using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFCienteServices.Dominio
{
    [DataContract]
    public class Solicitud
    {
        [DataMember]
        public long CodigoSolicitud { get; set; }

        [DataMember]
        public string EstadoDescripcion { get; set; }

        [DataMember]
        public string FechaHora { get; set; }

        [DataMember]
        public int CodigoAfiliado { get; set; }

        [DataMember]
        public string NombreCliente { get; set; }

        [DataMember]
        public int DNI { get; set; }

        [DataMember]
        public string RUC { get; set; }

    }

    [DataContract]
    public class SolicitudParaGrabar
    {
        [DataMember]
        public int CodigoCliente { get; set; }

        [DataMember]
        public long CodigoSolicitud { get; set; }

        [DataMember]
        public int Estado { get; set; }
        
        [DataMember]
        public string Observacion { get; set; }
    }
}