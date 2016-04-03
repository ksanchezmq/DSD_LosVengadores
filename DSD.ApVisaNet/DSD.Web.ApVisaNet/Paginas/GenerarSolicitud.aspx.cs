using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DSD.Web.Util.ApVisaNet;
using System.Runtime.Serialization;
using System.Net.Mail;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;
using WCFCienteServices.Dominio;

public partial class Paginas_GenerarSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        datoscliente.Visible = true;
        int iCodAfiliado = int.Parse(txtCodAfiliado.Text);
        WCFClientes.ClientesServiceClient cliente = new WCFClientes.ClientesServiceClient();
        Cliente Ecliente = new Cliente();

        bool existeCliente = (bool)(cliente.ValidarExisteCliente(int.Parse(txtCodAfiliado.Text.ToString())));
        if (existeCliente)
        {
            Ecliente = cliente.ObtenerCliente(iCodAfiliado);
            txtNombres.Text = Ecliente.Nombre;
            txtDni.Text = Ecliente.Dni.ToString().Trim();
            txtRuc.Text = Ecliente.Ruc.ToString().Trim();
            txtDireccionEmp.Text = Ecliente.Direccion.Trim();
            txtCorreo.Text = Ecliente.Correo.Trim();
            RadioButtonList2.Items[1].Selected = true;
            if (RadioButtonList3.Items[0].Value == Ecliente.Tipo_pos.ToString())
            {
                RadioButtonList3.Items[0].Selected = true;
            }
            else
            {
                RadioButtonList3.Items[1].Selected = true;
            }
            datoscliente.Visible = (Ecliente.Estado == "Inactivo");
            if (Ecliente.Estado == "Activo")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "js_MostrarAlertaAtencion('Generar Solicitud de Reactivación', 'Usuario activo');", true);
            }

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create(string.Format("http://localhost:34768/SolicitudService.svc/solicitudCliente?codCliente={0}", txtCodAfiliado.Text));
                req.Method = "GET";
                var response = req.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(response);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();

                var existeSolicitud = bool.Parse(responseFromServer);

                if (existeSolicitud)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "js_MostrarAlertaAtencion('Generar Solicitud de Reactivación', 'Usted ya tiene una solicitud generada');", true);
                    datoscliente.Visible = false;
                }

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
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "js_MostrarAlertaAtencion('Generar Solicitud de Reactivación', 'Código no existe');", true);
            datoscliente.Visible = false;
        }

    }

    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
        {
            txtDireccionEmp.Enabled = true;
        }
        else
        {
            txtDireccionEmp.Enabled = false;
        //    txtDireccionEmp.Text = Valores.Cliente_uno.strDireccion2.Trim();
        }
    }

    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        try
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(txtCodAfiliado.Text);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:34768/SolicitudService.svc/solicitud");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var response = req.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(response);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            var codigoSolicitud = long.Parse(responseFromServer);

            lblAlert.Text = "Solicitud Generada Correctamente";
            lblMensaje.Text = "N° Solicitud: " + codigoSolicitud.ToString();
            showAlert(true);
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

    protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        showAlert(false);
    }

    private void showAlert(bool b)
    {
        panel1.Visible = b;
        panelAlert.Visible = b;
    }
}