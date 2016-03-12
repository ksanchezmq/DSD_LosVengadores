using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DSD.Web.Util.ApVisaNet;
using System.Runtime.Serialization;

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
        if (txtCodAfiliado.Text == "1")
        {
            txtApePat.Text = Valores.Cliente_uno.strApePat.Trim();
            txtApeMat.Text = Valores.Cliente_uno.strApeMat.Trim();
            txtNombres.Text = Valores.Cliente_uno.strNombres.Trim();
            txtDni.Text = Valores.Cliente_uno.strNumDocu.Trim();
            txtFono1.Text = Valores.Cliente_uno.strFono1.Trim();
            txtFono2.Text = Valores.Cliente_uno.strFono2.Trim();
            txtDireccion.Text = Valores.Cliente_uno.strDireccion.Trim();
            ddlDpto.SelectedValue = Valores.Cliente_uno.strDpto.Trim();
            ddlProvincia.SelectedValue = Valores.Cliente_uno.strProvincia.Trim();
            ddlDistrito.SelectedValue = Valores.Cliente_uno.strDistrito.Trim();
            txtRuc.Text = Valores.Cliente_uno.strRuc.Trim();
            txtFonoEmp1.Text = Valores.Cliente_uno.strFono3.Trim();
            txtFonoEmp2.Text = "";
            txtDireccionEmp.Text = Valores.Cliente_uno.strDireccion2.Trim();
            ddlDptoEmp.SelectedValue = Valores.Cliente_uno.strDpto1.Trim();
            ddlProvEmp.SelectedValue = Valores.Cliente_uno.strProvincia2.Trim();
            ddlDistritoEmp.SelectedValue = Valores.Cliente_uno.strDistrito2.Trim();
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            txtDireccion.Enabled = true;
            ddlDpto.Enabled = true;
            ddlProvincia.Enabled = true;
            ddlDistrito.Enabled = true;

            txtDireccion.Text = "";
            ddlDpto.SelectedValue = "0";
            ddlProvincia.SelectedValue = "0";
            ddlDistrito.SelectedValue = "0";
        }
        else
        {
            txtDireccion.Enabled = false;
            ddlDpto.Enabled = false;
            ddlProvincia.Enabled = false;
            ddlDistrito.Enabled = false;

            txtDireccion.Text = Valores.Cliente_uno.strDireccion.Trim();
            ddlDpto.SelectedValue = Valores.Cliente_uno.strDpto.Trim();
            ddlProvincia.SelectedValue = Valores.Cliente_uno.strProvincia.Trim();
            ddlDistrito.SelectedValue = Valores.Cliente_uno.strDistrito.Trim();
        }
    }

    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
        {
            txtDireccionEmp.Enabled = true;
            ddlDptoEmp.Enabled = true;
            ddlProvEmp.Enabled = true;
            ddlDistritoEmp.Enabled = true;

            txtDireccionEmp.Text = "";
            ddlDptoEmp.SelectedValue = "0";
            ddlProvEmp.SelectedValue = "0";
            ddlDistritoEmp.SelectedValue = "0";
        }
        else
        {
            txtDireccionEmp.Enabled = false;
            ddlDptoEmp.Enabled = false;
            ddlProvEmp.Enabled = false;
            ddlDistritoEmp.Enabled = false;

            txtDireccionEmp.Text = Valores.Cliente_uno.strDireccion2.Trim();
            ddlDptoEmp.SelectedValue = Valores.Cliente_uno.strDpto1.Trim();
            ddlProvEmp.SelectedValue = Valores.Cliente_uno.strProvincia2.Trim();
            ddlDistritoEmp.SelectedValue = Valores.Cliente_uno.strDistrito2.Trim();
        }
    }

    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        lblAlert.Text = "Solicitud Generada Correctamente";
        lblMensaje.Text = "N° Solicitud: 20";
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