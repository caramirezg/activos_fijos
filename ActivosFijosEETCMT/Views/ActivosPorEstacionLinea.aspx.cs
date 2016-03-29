using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Data;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class ActivosPorEstacionLinea : System.Web.UI.Page
    {
        ControllerHelper controllerHelper = new ControllerHelper();


        protected void Page_Init(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null) { Response.Redirect("~/Views/login.aspx"); }
        }

        protected void _armarMenu()
        {
            ControllerAdministracion ObjetoAdministracion = new ControllerAdministracion();
            DataSet dsMenu = ObjetoAdministracion.getMenu();
            DataTable dtMenu = dsMenu.Tables[0];
            DataTable dtSubMenu = dsMenu.Tables[1];

            StringBuilder sb = new StringBuilder();
            //sb.Append("<ul class=" + "\"" + "sidebar-menu" + "\"" + ">");

            foreach (DataRow dr in dtMenu.Rows)
            {
                if (dr[4].ToString() == "0")
                {
                    sb.Append("<li class=" + "\"" + "active" + "\"" + "><a href=" + "\"" + dr[2].ToString() + "\"" + "><i class=" + "\"" + dr[3] + "\"" + "></i><span>" + dr[1].ToString() + " </span></a>");
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append("<li class=" + "\"" + "treeview" + "\"" + "><a href=" + "\"" + "#" + "\"" + "><i class=" + "\"" + dr[3] + "\"" + "></i><span>" + dr[1].ToString() + "</span><i class=" + "\"" + "fa fa-angle-left pull-right" + "\"" + "></i></a>");
                    sb.Append("<ul class=" + "\"" + "treeview-menu" + "\"" + ">");
                    foreach (DataRow dr1 in dtSubMenu.Rows)
                    {
                        if (dr1[1].ToString().Equals(dr[0].ToString()))
                        {
                            sb.Append("<li><a href=" + "\"" + dr1[3] + "\"" + "><i class=" + "\"" + "fa fa-angle-double-right" + "\"" + "></i>" + dr1[2] + "</a>");
                            sb.Append("</li>");
                        }
                    }
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }
            }
            _menu.InnerHtml = sb.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string vPerfil = HttpContext.Current.Session["perfil"].ToString();
            if (!vPerfil.Equals("2"))//persona
            {
                if (!Page.IsPostBack)
                {
                    lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    _armarMenu();
                    linea.Visible = false;
                    estacion.Visible = false;

                    cargarComboLineas();
                }
            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }
        }

        /// <summary>
        /// Carga el combo de lineas
        /// </summary>
        private void cargarComboLineas()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlLinea.DataSource = controllerHelper.ToDataTable(vObjeto.obtieneListLineas());
            ddlLinea.DataValueField = "id";
            ddlLinea.DataTextField = "nombre";
            ddlLinea.DataBind();
        }

        public void cargaEstaciones(string idLinea)
        {
            ddlEstacion.Items.Clear();
            ddlEstacion.Items.Add(new ListItem("Seleccione un item", "-1"));

            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlEstacion.DataSource = controllerHelper.ToDataTable(vObjeto.obtieneListEstacionesPorLinea(idLinea));
            ddlEstacion.DataValueField = "id";
            ddlEstacion.DataTextField = "nombre";
            ddlEstacion.DataBind();

        }

        protected void ddlLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idLinea = ddlLinea.SelectedItem.Value.ToString();
            cargaEstaciones(idLinea);
        }

        protected void ddlTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoReporte.SelectedItem.Value == "1")
            {
                linea.Visible = true;
                estacion.Visible = false;
            }
            else if (ddlTipoReporte.SelectedItem.Value == "2")
            {
                linea.Visible = true;
                estacion.Visible = true;
            }
            else 
            {
                linea.Visible = false;
                estacion.Visible = false;
            }
        }

        protected void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            if (ddlTipoReporte.SelectedItem.Value != "-1")
            {
                if (ddlTipoReporte.SelectedItem.Value == "1")
                {
                    if (ddlLinea.SelectedItem.Value != "-1")
                    {
                        Response.Write("<script>window.open('reportes/ReporteActivosPorLineaIndividual.aspx?idLinea=" + ddlLinea.SelectedItem.Value + "','_blank');</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('Seleccione una línea').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                    }
                }
                
                else if (ddlTipoReporte.SelectedItem.Value == "2")
                {

                    if (!string.IsNullOrEmpty(ddlEstacion.Text))
                    {
                        Response.Write("<script>window.open('reportes/ReporteActivosPorEstacionIndividual.aspx?idEstacion="+ddlEstacion.SelectedItem.Value+"','_blank');</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('Seleccione una estación').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                    }
                   
                }
                else if (ddlTipoReporte.SelectedItem.Value == "3")
                {
                    Response.Write("<script>window.open('reportes/ReporteActivosOficina.aspx','_blank');</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('Seleccione un tipo de reporte').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

                //string message = "$('#warning').text('Seleccione un tipo de reporte').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
           
        }
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}