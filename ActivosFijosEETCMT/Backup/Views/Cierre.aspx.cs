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
    public partial class Cierre : System.Web.UI.Page
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
                     cargarComboGestiones();
                 }
             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }
        }

        protected void btnCerrarGestion_Click(object sender, EventArgs e)
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ControllerActivos vObjetoActivos = new ControllerActivos();

            int resultCantElaborados = vObjetoActivos.getCantActivosEstadoElaborado();
            string f_actualizacion = vObjeto.obtieneUltimaDepreciacion();
            string f_convertida=Convert.ToDateTime(f_actualizacion).ToString("dd-MM-yyyy");
            string f_cierre = Request.Form["dateFechaCierre"].ToString();
            if (f_convertida.Equals(f_cierre))
            {
                if (resultCantElaborados < 1)
                {
                    int result = vObjeto.cerrarGestion(Request.Form["dateFechaCierre"].ToString());
                    if (result > 0)
                    {
                        cargarComboGestiones();
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('La gestión ha sido cerrada exitosamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('No debe existir activos en estado elaborado').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }else
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('La fecha de cierre y la actualización deben ser las mismas').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
        }

        private void cargarComboGestiones()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlPeriodosCerrados.DataSource = controllerHelper.ToDataTable(vObjeto.obtieneListGestionesCerradas());
            ddlPeriodosCerrados.DataValueField = "id";
            ddlPeriodosCerrados.DataTextField = "f_cierre";
            ddlPeriodosCerrados.DataBind();
        }

        protected void btnVerCierre_Click(object sender, EventArgs e)
        {
            DateTime f_cierre = DateTime.Parse(ddlPeriodosCerrados.SelectedItem.Text);
            Response.Write("<script>window.open('reportes/ReporteCierreGestion.aspx?f_cierre=" + f_cierre + "','_blank');</script>");
            //Response.Redirect("reportes/ReporteCierreGestion.aspx?gestion=" + gestion + "", false);
        }

        protected void btnVerDetalleCierre_Click(object sender, EventArgs e)
        {
            DateTime f_cierre = DateTime.Parse(ddlPeriodosCerrados.SelectedItem.Text);
            Response.Write("<script>window.open('reportes/ReporteCierreGestionDetalle.aspx?f_cierre=" + f_cierre + "','_blank');</script>");

        }

      
    }
}