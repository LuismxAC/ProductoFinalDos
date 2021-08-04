using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaLogicaNegocios;
using ClassCapaEntidades;

namespace WebProducto
{
    public partial class DetallesPed : System.Web.UI.Page
    {
        ClassLogicaCarniceria objLog = null;
        string receptor = "";
        string[] atrap = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnDetails.Visible = false;
            objLog = new ClassLogicaCarniceria();
            receptor = Request.QueryString["query"].ToString();
            atrap = (string[])Session["Datos"];
            if (atrap != null)
            {
                lbAux.InnerHtml = atrap[1] + " " + atrap[2];
            }
            else
            {
                Session["Datos"] = null;
                Response.Redirect("Cerrar.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string t = "", i = "", m = "";
            Productos np = new Productos
            {
                Nombre = txtProducto.Text,
                Peso = int.Parse(txtPeso.Text),
                Cantidad = int.Parse(txtCantidad.Text),
                Nota = txtNota.Text,
                FPedido = int.Parse(receptor)
            };
            objLog.InsertarProducto(np, ref m, ref i, ref t);
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            btnDetails.Visible = true;
            string m = "", i = "", t = "";
            GridView1.DataSource = objLog.ProductosGrid(int.Parse(receptor), ref m, ref i, ref t);
            GridView1.DataBind();
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg3", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            EntregaPedido EPn = new EntregaPedido
            {
                F_Pedido = int.Parse(receptor)
            };
            objLog.FinalizarPedido(EPn, ref m, ref i, ref t);
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg4", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
            Panel1.Visible = false;
            btnDetails.Visible = true;
            btnFin.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            GridView1.DataSource = objLog.VerEntrega(int.Parse(receptor), ref m, ref i, ref t);
            GridView1.DataBind();
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg3", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }
    }
}