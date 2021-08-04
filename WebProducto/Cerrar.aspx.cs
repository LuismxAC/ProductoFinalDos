using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProducto
{
    public partial class Cerrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Datos"] = null;
            Session["objLog"] = null;
            Response.Redirect("index.aspx");
            //cerrar
        }
    }
}