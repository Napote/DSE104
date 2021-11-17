using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoEstadoDeSesion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
                Response.Redirect("WebForm2.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Add("Login", TextBox1.Text);
            Application.Add("App", TextBox2.Text); 
            Response.Redirect("WebForm2.aspx");
        }

    }
}