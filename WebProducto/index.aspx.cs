using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaEntidades;
using ClassCapaLogicaNegocios;

namespace WebProducto
{
    public partial class index : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            Cliente tempC = new Cliente
            {
                Nombre = txtNombre.Text,
                ApellP = txtApp.Text,
                ApellM = txtApm.Text,
                Celular = txtTel.Text.ToString(),
                Email = txtEmail.Text
            };
            string[] atrapa = objLog.CompruebaExistenciaCli(tempC, ref m, ref i, ref t);
            if (atrapa != null)
            {
                Session["Datos"] = atrapa;
            }
            else
            {
                objLog.InsertaCliente(tempC, ref m, ref i, ref t);
                string[] temp = objLog.CompruebaExistenciaCli(tempC, ref m, ref i, ref t);
                Session["Datos"] = temp;
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msgboxr('" + m + "', '" + i + "', '" + t + "', 'InicioCli.aspx')", true);
        }
    }
}