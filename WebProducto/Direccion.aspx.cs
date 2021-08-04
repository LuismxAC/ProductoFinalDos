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
    public partial class Direccion : System.Web.UI.Page
    {
        ClassLogicaCarniceria objLog = null;
        string[] atrap = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objLog = new ClassLogicaCarniceria();
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

        protected void btnGuardarU_Click(object sender, EventArgs e)
        {
            Ubicacion ut = new Ubicacion
            {
                Colonia = txtCol.Text,
                Calleynumero = txtCayNu.Text,
                Municipio = txtMuni.Text,
                Ciudad = txtCiud.Text,
                Referencia = txtRef.Text,
                Caracteristica = txtCar.Text,
                CP = txtCp.Text,
                F_Cliente = int.Parse(atrap[6])
            };
            string m = "", i = "", t = "";
            objLog.InsertarUbicacion(ut, ref m, ref i, ref t);
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            gvUbi.DataSource = objLog.VerUbicaciones(ref m, ref i, ref t);
            gvUbi.DataBind();
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg3", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }

        protected void gvUbi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}