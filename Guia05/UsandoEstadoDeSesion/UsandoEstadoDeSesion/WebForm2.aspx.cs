using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoEstadoDeSesion
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null) {
                Label1.Text = String.Format(
                "Bienvenido, la variable de sesion es: {0}", Session["Login"]);
                Label2.Text = String.Format(
                "La variable de aplicacion es: {0}", Application["App"]);
            }
            else
                Response.Redirect("WebForm1.aspx");
        }
        protected void Button1_Click(
        object sender, EventArgs e)
        {
            Session.Remove("Login");
            Application.Remove("App");
            Response.Redirect("WebForm1.aspx");
        }

    }
}