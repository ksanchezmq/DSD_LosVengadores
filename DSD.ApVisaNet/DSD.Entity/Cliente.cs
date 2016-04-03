using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFCienteServices.Dominio
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int CodAfiliado { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public int Dni { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Ruc { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public int Tipo_pos { get; set; }

        [DataMember]
        public int Num_serie { get; set; }

        [DataMember]
        public string Correo { get; set; }

    }
}