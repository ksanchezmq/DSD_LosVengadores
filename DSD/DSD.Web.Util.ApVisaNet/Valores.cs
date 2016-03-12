using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DSD.Web.Util.ApVisaNet
{
    public class Valores
    {
        public struct Perfiles
        {
            public static int USU_PERFIL = ConfigurationManager.AppSettings["USU_PERFIL"] == null ? 0 : Convert.ToInt32(ConfigurationManager.AppSettings["USU_PERFIL"]);
        }

        public struct Cliente_uno
        {
            public static string strApePat = "Elías";
            public static string strApeMat = "Vicuña";
            public static string strNombres = "César Augusto";
            public static string strNumDocu = "45964729";
            public static string strFono1 = "2740866";
            public static string strFono2 = "988202432";
            public static string strDireccion = "Av. Caminos del Inca 3020. Dpto 101";
            public static string strDpto = "1";
            public static string strProvincia = "1";
            public static string strDistrito = "1";
            public static string strRuc = "20459647291";
            public static string strFono3 = "2587489";
            public static string strDireccion2 = "Av. Javier Prado Este 520";
            public static string strDpto1 = "1";
            public static string strProvincia2 = "1";
            public static string strDistrito2 = "2";
        }
    }
}
