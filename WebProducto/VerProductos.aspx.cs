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
    public partial class VerProductos : System.Web.UI.Page
    {
        ClassLogicaCarniceria objLog = null;
        string receptor = "";
        string[] atrap = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objLog = new ClassLogicaCarniceria();
            receptor = Request.QueryString["query"].ToString();
            atrap = (string[])Session["Datos"];
            if (atrap != null)
            {
                lbAux.InnerHtml = atrap[1];
                string m = "", i = "", t = "";
                GridView1.DataSource = objLog.PedidosGrid3(int.Parse(receptor), ref m, ref i, ref t);
                GridView1.DataBind();
            }
            else
            {
                Session["Datos"] = null;
                Response.Redirect("Cerrar.aspx");
            }
        }
    }
}