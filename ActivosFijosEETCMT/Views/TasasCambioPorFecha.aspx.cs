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
    public partial class TasasCambioPorFecha : System.Web.UI.Page
    {
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
                    ///Roles de usuario
                   
                    //if (vPerfil.Equals("1"))
                    //{
                    //    //_solicitudesSalidas.Visible = false;
                    //    _parametrizacion.Visible = true;
                    //    _proveedores.Visible = true;
                    //    _altas.Visible = true;
                    //    _transferencias.Visible = true;
                    //    _asignaciones.Visible = true;
                    //    _depreciaciones.Visible = true;
                    //    _control_activos.Visible = true;
                    //    _cierre.Visible = true;
                    //    _apertura.Visible = true;
                    //    _reportes.Visible = true;

                    //}
                    //else if (vPerfil.Equals("2"))
                    //{
                    //    //_solicitudesSalidas.Visible = true;
                    //    _parametrizacion.Visible = false;
                    //    _proveedores.Visible = false;
                    //    _altas.Visible = false;
                    //    _transferencias.Visible = false;
                    //    _asignaciones.Visible = false;
                    //    _depreciaciones.Visible = false;
                    //    _control_activos.Visible = false;
                    //    _cierre.Visible = false;
                    //    _apertura.Visible = false;
                    //    _reportes.Visible = false;
                    //    _bajas.Visible = false;
                    //}
                    //else if (vPerfil.Equals("3"))
                    //{
                    //    //_solicitudesSalidas.Visible = false;
                    //    _parametrizacion.Visible = false;
                    //    _proveedores.Visible = false;
                    //    _altas.Visible = false;
                    //    _transferencias.Visible = false;
                    //    _asignaciones.Visible = false;
                    //    _depreciaciones.Visible = false;
                    //    _control_activos.Visible = false;
                    //    _cierre.Visible = false;
                    //    _apertura.Visible = false;
                    //    _reportes.Visible = true;
                    //    _bajas.Visible = false;

                    //    //rep_activos_con_custodio.Visible = false;
                    //    //rep_kardex.Visible = false;
                    //    //rep_activos_por_estacion_linea.Visible = false;
                    //    //rep_activos_por_responsable.Visible = false;
                    //    //rep_agrupado.Visible = false;
                    //    //rep_auxiliares_por_area.Visible = false;
                    //}

                }

                cargaGrilla();
            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }
        }

        /// <summary>
        /// Carga la grilla de tasas de cambio
        /// </summary>
        private void cargaGrilla()
        {
            ControllerTasasCambio vObjeto = new ControllerTasasCambio();
            ControllerHelper vHelper = new ControllerHelper();
            gridTasasCambio.DataSource = vHelper.ToDataTable(vObjeto.DatosTasaDolarUfv());
            gridTasasCambio.KeyFieldName = "id";
            gridTasasCambio.DataBind();
        }
        /// <summary>
        /// Muestra el reporte de tasas de cambio por fechas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["dateFechaInicio"]) && !string.IsNullOrEmpty(Request.Form["dateFechaFin"]))
            {
                string fecha_inicio = Request.Form["dateFechaInicio"];
                string fecha_fin = Request.Form["dateFechaFin"];

                Response.Write("<script>window.open('reportes/ReporteIndicesUfvDolar.aspx?fecha_inicio=" + fecha_inicio + " &fecha_fin=" + fecha_fin + " ','_blank');</script>");
            }else
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('Debe seleccionar un rango de fechas').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
        }
    }
}