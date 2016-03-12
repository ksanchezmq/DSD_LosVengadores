using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paginas_EvaluarSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LlenarGrilla();
        }
    }

    private void LlenarGrilla()
    {
        DataTable dttRegistro = new DataTable();
        dttRegistro.Columns.Add("Número de Solicitud");
        dttRegistro.Columns.Add("Estado");
        dttRegistro.Columns.Add("Fecha de Registro");
        dttRegistro.Columns.Add("Código de Cliente");

        DataRow row0 = dttRegistro.NewRow();
        row0[0] = "1";
        row0[1] = "En Proceso";
        row0[2] = "12/03/2016";
        row0[3] = "1";
        dttRegistro.Rows.Add(row0);
        dttRegistro.AcceptChanges();

        DataRow row = dttRegistro.NewRow();
        row[0] = "2";
        row[1] = "En Proceso";
        row[2] = "10/03/2016";
        row[3] = "2";
        dttRegistro.Rows.Add(row);
        dttRegistro.AcceptChanges();

        DataRow row2 = dttRegistro.NewRow();
        row2[0] = "3";
        row2[1] = "Pendiente";
        row2[2] = "07/03/2016";
        row2[3] = "3";
        dttRegistro.Rows.Add(row2);
        dttRegistro.AcceptChanges();

        GridView1.DataSource = dttRegistro;
        GridView1.DataBind();


    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VER")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (GridView1.Rows[index].Cells[0].Text.Trim() == "2")
            {
                txtCodCol.Text = "2";
                txtNumSol.Text = "2";
                txtNombres.Text = "Juan Perez Valdivia";
                txtDni.Text = "12345678";
                txtRUC.Text = "20123456782";
            }
            else if (GridView1.Rows[index].Cells[0].Text.Trim() == "3")
            {
                txtCodCol.Text = "3";
                txtNumSol.Text = "3";
                txtNombres.Text = "José Elias Romero";
                txtDni.Text = "87654321";
                txtRUC.Text = "20876543216";
            }
            else if (GridView1.Rows[index].Cells[0].Text.Trim() == "1")
            {
                txtCodCol.Text = "1";
                txtNumSol.Text = "1";
                txtNombres.Text = "César Elías Vicuña";
                txtDni.Text = "45964729";
                txtRUC.Text = "20459647291";
            }
            showAlert(true);
        }
    }

    private void showAlert(bool b)
    {
        panelOverlay.Visible = b;
        panelPopUpPanel.Visible = b;
    }

    protected void btnEvaluar_Click(object sender, EventArgs e)
    {
        showAlert(false);
    }
}