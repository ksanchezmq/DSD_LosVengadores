using System.Net;
using System.ServiceModel.Web;
using WCFCienteServices.Persistencia;

namespace WCFCienteServices
{
    public class SunatService : ISunatService
    {
        public bool ValidarRUCContribuyente(string ruc)
        {
            var rucValido = new long();

            if (!long.TryParse(ruc, out rucValido))
                throw new WebFaultException<string>("Formato de RUC incorrecto.", HttpStatusCode.BadRequest);

            if (rucValido.ToString().Length != 11)
                throw new WebFaultException<string>("Longitud de RUC incorrecto.", HttpStatusCode.BadRequest);

            return new ContribuyenteDAO().ValidarRUCContribuyente(rucValido.ToString());
        }
    }
}
