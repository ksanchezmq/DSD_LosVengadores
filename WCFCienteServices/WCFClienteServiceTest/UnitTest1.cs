using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace WCFClienteServiceTest
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_ObtenerCliente()
        {
            ClientesWS.ClientesClient proxy = new ClientesWS.ClientesClient();
            ClientesWS.Cliente clienteABuscar = proxy.ObtenerCliente(1);
            Assert.AreEqual(1, clienteABuscar.CodAfiliado);
        }

        [TestMethod]
        public void Test2_ObtenerClienteNoExiste()
        {
            ClientesWS.ClientesClient proxy = new ClientesWS.ClientesClient();
            try
            {
                ClientesWS.Cliente clienteABuscar = proxy.ObtenerCliente(5);
            }
            catch(FaultException<ClientesWS.ClienteExcepciones> error)
            {
                Assert.AreEqual("Error al buscar cliente", error.Reason.ToString());
                Assert.AreEqual(error.Detail.codigo, "101");
                Assert.AreEqual(error.Detail.descripcion, "Código de Afiliado no existe, por favor registrarse.");
            }
        }
    }
}
