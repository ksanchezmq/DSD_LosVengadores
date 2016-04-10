using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using WCFCienteServices.Dominio;
using System.ComponentModel;

public partial class Paginas_ConsultarSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LlenarGrilla();
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        LlenarGrilla();
        showAlert(false);
    }

    private void LlenarGrilla()
    {
        try
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create(string.Format("http://localhost:34768/SolicitudService.svc/solicitud?codServicio={0}", txtNumSolicitud.Text));
            req.Method = "GET";
            var response = req.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(response);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            var resultado = js.Deserialize<List<Solicitud>>(responseFromServer);
            GridView1.DataSource = ConvertToDataTable<Solicitud>(resultado);
            GridView1.DataBind();
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

    public DataTable ConvertToDataTable<T>(IList<T> data)
    {
        PropertyDescriptorCollection properties =
           TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }
        return table;

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VER")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            txtCodCol.Text = GridView1.Rows[index].Cells[3].Text.Trim();
            txtNumSol.Text = GridView1.Rows[index].Cells[0].Text.Trim();
            txtNombres.Text = Server.HtmlDecode(GridView1.Rows[index].Cells[4].Text.Trim());
            txtDni.Text = GridView1.Rows[index].Cells[5].Text.Trim();
            txtRUC.Text = GridView1.Rows[index].Cells[6].Text.Trim();

            showAlert(true);
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        showAlert(false);
    }

    private void showAlert(bool b)
    {
        panelOverlay.Visible = b;
        panelPopUpPanel.Visible = b;
    }
}