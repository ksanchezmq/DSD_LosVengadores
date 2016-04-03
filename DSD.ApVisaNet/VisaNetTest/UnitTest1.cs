using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using WCFCienteServices.Dominio;
using System.Collections.Generic;

namespace VisaNetTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListarSolicitudes()
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://localhost:34768/SolicitudService.svc/solicitud");
                req.Method = "GET";
                var response = req.GetResponse();

                HttpStatusCode code = ((HttpWebResponse)response).StatusCode;
                Assert.AreEqual(HttpStatusCode.OK, code);

                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseFromServer = reader.ReadToEnd();

                var resultado = js.Deserialize<List<Solicitud>>(responseFromServer);
                Assert.IsTrue(resultado.Count > 0);
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                throw new Exception(error);
            }
        }

        [TestMethod]
        public void EvaluarClienteConRUCInvalido()
        {
            WCFClientes.ClientesServiceClient cliente = new WCFClientes.ClientesServiceClient();
            Cliente Ecliente = new Cliente();

            try
            {
                cliente.EvaluarCliente(dni: 43657617, ruc: "10432576175");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("RUC del Cliente no se encuentra activo en la Sunat", ex.Message);
            }
        }

        [TestMethod]
        public void EvaluarClienteConDeudas()
        {
            WCFClientes.ClientesServiceClient cliente = new WCFClientes.ClientesServiceClient();
            Cliente Ecliente = new Cliente();

            try
            {
                cliente.EvaluarCliente(dni: 43657617, ruc: "10436576175");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cliente tiene deuda registrada en SBS", ex.Message);
            }
        }

        [TestMethod]
        public void ValidarRUCContribuyente()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create(string.Format("http://localhost:34768/SunatService.svc/contribuyente/{0}", "10436576175"));
            req.Method = "GET";
            var response = req.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(response);
            string responseFromServer = reader.ReadToEnd();

            var existeRUC = bool.Parse(responseFromServer);
            Assert.IsTrue(existeRUC);
        }

        [TestMethod]
        public void ValidarRUCConFormatoIncorrecto()
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create(string.Format("http://localhost:34768/SunatService.svc/contribuyente/{0}", "ABC123456"));
                req.Method = "GET";
                req.GetResponse();
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                Assert.AreEqual(HttpStatusCode.BadRequest, code);

                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                var mensaje = js.Deserialize<string>(error);

                Assert.AreEqual("Formato de RUC incorrecto.", mensaje);
            }
        }

        [TestMethod]
        public void ValidarDNIConDeuda()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest
                        .Create(string.Format("http://localhost:34768/SBSService.svc/deuda/{0}", "43657617"));
            req.Method = "GET";
            var response = req.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(response);
            string responseFromServer = reader.ReadToEnd();

            var deuda = decimal.Parse(responseFromServer);
            var existeDeuda = deuda > 0;
            Assert.IsTrue(existeDeuda);
        }

        [TestMethod]
        public void ValidarDNIConFormatoIncorrecto()
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest
                        .Create(string.Format("http://localhost:34768/SBSService.svc/deuda/{0}", "ABC12345"));
                req.Method = "GET";
                req.GetResponse();
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                Assert.AreEqual(HttpStatusCode.BadRequest, code);

                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                var mensaje = js.Deserialize<string>(error);

                Assert.AreEqual("Formato de DNI incorrecto.", mensaje);
            }
        }

    }
}
