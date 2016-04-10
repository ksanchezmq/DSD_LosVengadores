using System.Net;
using System.ServiceModel.Web;
using WCFCienteServices.Persistencia;

namespace WCFCienteServices
{
    public class SBSService : ISBSService
    {
        public decimal ObtenerDeudaPorDNI(string dni)
        {
            var dniValido = 0;

            if (!int.TryParse(dni, out dniValido))
                throw new WebFaultException<string>("Formato de DNI incorrecto.", HttpStatusCode.BadRequest);
            
            if (dniValido.ToString().Length != 8)
                throw new WebFaultException<string>("Longitud de DNI incorrecto.", HttpStatusCode.BadRequest);

            return new DeudorDAO().ObtenerDeudaPorDNI(dniValido);
        }
    }
}
