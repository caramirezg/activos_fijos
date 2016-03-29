using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijos.Controllers;

namespace ActivosFijosEETC.Views
{
    public partial class login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtIngreso_Click(object sender, EventArgs e)
        {
            ControllerLogin vController = new ControllerLogin();
            string result=vController.autentificacion(user.Text, pass.Text);
            if (result == "0x0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#PassError').text('Usuario/contraseña incorrectos').fadeIn(800).delay(4000).fadeOut(800);</script>");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}