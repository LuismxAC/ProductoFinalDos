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
    public partial class InicioCar : System.Web.UI.Page
    {
        ClassLogicaCarniceria objLog = null;
        string[] atrap = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objLog = new ClassLogicaCarniceria();
            atrap = (string[])Session["Datos"];
            if (atrap != null)
            {
                lbAux.InnerHtml = atrap[1];
            }
            else
            {
                Session["Datos"] = null;
                Response.Redirect("Cerrar.aspx");
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            GridView1.DataSource = objLog.CLientesGrid(ref m, ref i, ref t);
            GridView1.DataBind();
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg3", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }

        protected void btnPCER_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            GridView2.DataSource = objLog.Pedidoscobroelrepartidor(ref m, ref i, ref t);
            GridView2.DataBind();
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg8", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }

        protected void btnPDUC_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            GridView3.DataSource = objLog.Pedidosespachouncarnicero(ref m, ref i, ref t);
            GridView3.DataBind();
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg10", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow ren = GridView1.SelectedRow;
            string envia = ren.Cells[1].Text;
            Response.Redirect("VerPedidos.aspx?query=" + envia);
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Repartidor.aspx");
        }
    }
}