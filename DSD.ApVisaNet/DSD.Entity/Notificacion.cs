using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFCienteServices.Entidad
{
    public class Notificacion
    {
        public string Body { get; set; }

        public string Subject { get; set; }

        public string ToAddress { get; set; }
    }
}