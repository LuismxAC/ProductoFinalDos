﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaLogicaNegocios;
using ClassCapaEntidades;


namespace WebProducto
{
    public partial class InicioCli : System.Web.UI.Page
    {
        ClassLogicaCarniceria objLog = new ClassLogicaCarniceria();
        string[] atrap = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            atrap = (string[])Session["Datos"];
            if (atrap != null)
            {
                lbAux.InnerHtml = atrap[1] + " " + atrap[2];
                DDlCLiente.Items.Add(new ListItem(lbAux.InnerText + " " + atrap[3], atrap[6]));
            }
            else
            {
                Response.AddHeader("Debes registrate primero", "10;URL=index.aspx");
            }
        }

        protected void click_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            GridView1.DataSource = objLog.PedidosGrid(int.Parse(atrap[6]), ref m, ref i, ref t);
            GridView1.DataBind();
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }

        protected void BtnPedido_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            Pedido np = new Pedido
            {
                FCliente = int.Parse(DDlCLiente.SelectedValue),
                FCarnicero = int.Parse(DDlCarni.SelectedValue),
                Envio = short.Parse(DDlEnvio.SelectedValue),
                Pago = DDlPago.Text.ToString()
            };
            objLog.AbrirPedido(np, ref m, ref i, ref t);
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msgbox('" + t + "', '" + i + "', '" + m + "')", true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow ren = GridView1.SelectedRow;
            string envia = ren.Cells[1].Text;
            Response.Redirect("DetallesPed.aspx?query=" + envia);
        }

    }
    
}