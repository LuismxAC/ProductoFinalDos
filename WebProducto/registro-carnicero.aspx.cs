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
    public partial class registro_carnicero : System.Web.UI.Page
    {
        ClassLogicaCarniceria objLog = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLog = new ClassLogicaCarniceria();
                Session["objLog"] = objLog;
            }
            else
            {
                objLog = (ClassLogicaCarniceria)Session["objLog"];
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            Carnicero tempC = new Carnicero
            {
                Nombre = txtNombre.Text,
                Telefono = txtCel.Text.ToString(),
                Correo = txtCorreo.Text,
                Experiencia = int.Parse(txtAnios.Text)
            };
            string[] atrapa = objLog.CompruebaExistenciaCarn(tempC, ref m, ref i, ref t);
            if (atrapa != null)
            {
                Session["Datos"] = atrapa;
            }
            else
            {
                objLog.InsertaCarnicero(tempC, ref m, ref i, ref t);
                string[] temp = objLog.CompruebaExistenciaCarn(tempC, ref m, ref i, ref t);
                Session["Datos"] = temp;
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msgboxr('" + m + "', '" + i + "', '" + t + "', 'InicioCar.aspx')", true);
        }
    }
}