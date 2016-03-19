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
        WCFClientes.ClientesClient cliente = new WCFClientes.ClientesClient();
        WCFClientes.Cliente Ecliente = new WCFClientes.Cliente();

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
        else {
            RadioButtonList3.Items[1].Selected = true;
        }

        datoscliente.Visible = (Ecliente.Estado == "Inactivo");
        if (Ecliente.Estado == "Activo")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "js_MostrarAlertaAtencion('Generar Solicitud de Reactivación', 'Usuario activo');", true);
        }

        WCFSolicitud.SolicitudClient proxySolicitud = new WCFSolicitud.SolicitudClient();
        var existeSolicitud = proxySolicitud.ValidarSiExisteSolicitudCliente(int.Parse(txtCodAfiliado.Text));

        if (existeSolicitud)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "js_MostrarAlertaAtencion('Generar Solicitud de Reactivación', 'Usted ya tiene una solicitud generada');", true);
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
        WCFSolicitud.SolicitudClient proxySolicitud = new WCFSolicitud.SolicitudClient();
        var codigoSolicitud = proxySolicitud.GenerarSolicitud(int.Parse(txtCodAfiliado.Text));

        lblAlert.Text = "Solicitud Generada Correctamente";
        lblMensaje.Text = "N° Solicitud: " + codigoSolicitud.ToString();
        showAlert(true);
       
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