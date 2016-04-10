using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.ComponentModel;
using WCFCienteServices.Dominio;
using System.Text;

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

            var resultado = js.Deserialize<List<Solicitud>>(responseFromServer);//.Where(q=> q.EstadoDescripcion == "Registrado").ToList();
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

            if (GridView1.Rows[index].Cells[1].Text.Trim() != "Registrado")
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "mensaje", "js_MostrarAlertaAtencion('Evaluar Dispositivo', 'Estado incorrecto');", true);
                return;
            }

            txtCodCol.Text = GridView1.Rows[index].Cells[3].Text.Trim();
            txtNumSol.Text = GridView1.Rows[index].Cells[0].Text.Trim();
            txtNombres.Text = Server.HtmlDecode(GridView1.Rows[index].Cells[4].Text.Trim());
            txtDni.Text = GridView1.Rows[index].Cells[5].Text.Trim();
            txtRUC.Text = GridView1.Rows[index].Cells[6].Text.Trim();
            
            showAlert(true);
        }
    }

    private void showAlert(bool b)
    {
        panelOverlay.Visible = b;
        panelPopUpPanel.Visible = b;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        LlenarGrilla();
        showAlert(false);
    }

    protected void btnEvaluar_Click(object sender, EventArgs e)
    {
        WCFClientes.ClientesServiceClient cliente = new WCFClientes.ClientesServiceClient();
        Cliente Ecliente = new Cliente();
        SolicitudParaGrabar solicitud;

        try
        {
            cliente.EvaluarCliente(int.Parse(txtDni.Text), txtRUC.Text);
            solicitud = new SolicitudParaGrabar()
            {
                CodigoSolicitud = long.Parse(txtNumSol.Text),
                CodigoCliente = int.Parse(txtCodCol.Text),
                Estado = 2,
                Observacion = "Solicitud en proceso."
            };
        }
        catch (Exception ex)
        {
            solicitud = new SolicitudParaGrabar()
            {
                CodigoSolicitud = long.Parse(txtNumSol.Text),
                CodigoCliente = int.Parse(txtCodCol.Text),
                Estado = 3,
                Observacion = ex.Message
            };
        }
        

        JavaScriptSerializer js = new JavaScriptSerializer();
        string postdata = js.Serialize(solicitud);

        byte[] data = Encoding.UTF8.GetBytes(postdata);
        HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create(string.Format("http://localhost:34768/SolicitudService.svc/solicitud/{0}", txtNumSol.Text));
        req.Method = "PUT";
        req.ContentLength = data.Length;
        req.ContentType = "application/json";
        var reqStream = req.GetRequestStream();
        reqStream.Write(data, 0, data.Length);
        var response = req.GetResponse();
        HttpStatusCode code = ((HttpWebResponse)response).StatusCode;

        LlenarGrilla();
        showAlert(false);
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        showAlert(false);
    }
}