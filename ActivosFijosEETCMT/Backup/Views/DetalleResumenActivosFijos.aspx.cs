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
    public partial class DetalleResumenActivosFijos : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                _linea.Visible = false;
                _estacion.Visible = false;
                _ubicacion.Visible = false;
                cargarComboLineas();
                cargarComboUbicaciones();
                _armarMenu();
            }
        }

        private void cargarComboUbicaciones()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlUbicacion.DataSource = controllerHelper.ToDataTable(vObjeto.DatosClasificadoresByIDTipo("4"));
            ddlUbicacion.DataValueField = "id";
            ddlUbicacion.DataTextField = "nombre";
            ddlUbicacion.DataBind();
        }

        private void cargarComboLineas()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlLinea.DataSource = controllerHelper.ToDataTable(vObjeto.obtieneListLineas());
            ddlLinea.DataValueField = "id";
            ddlLinea.DataTextField = "nombre";
            ddlLinea.DataBind();
        }

        protected void ddlLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLinea.SelectedItem.Value != "0")
            {
              
                _estacion.Visible = true;
                string idLinea = ddlLinea.SelectedItem.Value.ToString();
                cargaEstaciones(idLinea);
                
            }
            else
            {
                _estacion.Visible = false;
            }
        }

        public void cargaEstaciones(string idLinea)
        {
            ddlEstacion.Items.Clear();
            ddlEstacion.Items.Add(new ListItem("Seleccione una estación", "-1"));
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlEstacion.DataSource = controllerHelper.ToDataTable(vObjeto.obtieneListEstacionesPorLinea(idLinea));
            ddlEstacion.DataValueField = "id";
            ddlEstacion.DataTextField = "nombre";
            ddlEstacion.DataBind();

        }

        protected void ddlClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClasificacion.SelectedItem.Value.Equals("generico"))
            {
                _ubicacion.Visible = false;
               
            }
            else
            {
                _ubicacion.Visible = true;
            }
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (ddlTipoReporte.SelectedItem.Value.Equals("detalle"))
            {
                if (ddlClasificacion.SelectedItem.Value.Equals("generico"))
                {
                    Response.Write("<script>window.open('reportes/ReporteDetalleActivosFijosPorGrupo.aspx','_blank');</script>");
                }
                else if (ddlClasificacion.SelectedItem.Value.Equals("ubicacion"))
                {
                    string estacion;
                    if (ddlEstacion.SelectedItem.Value.Equals("-1"))
                        estacion = "0";
                    else
                        estacion = ddlEstacion.SelectedItem.Value;
                       Response.Write("<script>window.open('reportes/ReporteDetalleActivosFijosPorGrupoDinamico.aspx?ubicacion="+ddlUbicacion.SelectedItem.Value+" &linea="+ddlLinea.SelectedItem.Value+" &estacion="+estacion+"','_blank');</script>");
                }
            }
            else if (ddlTipoReporte.SelectedItem.Value.Equals("resumen"))
            {
                if (ddlClasificacion.SelectedItem.Value.Equals("generico"))
                {
                    Response.Write("<script>window.open('reportes/ReporteResumenActivosFijosPorGrupo.aspx','_blank');</script>");

                }
                else if (ddlClasificacion.SelectedItem.Value.Equals("ubicacion"))
                {
                    string estacion;
                    if (ddlEstacion.SelectedItem.Value.Equals("-1"))
                        estacion = "0";
                    else
                        estacion = ddlEstacion.SelectedItem.Value;
                    Response.Write("<script>window.open('reportes/ReporteResumenActivosFijosPorGrupoDinamico.aspx?ubicacion=" + ddlUbicacion.SelectedItem.Value + " &linea=" + ddlLinea.SelectedItem.Value + " &estacion=" + estacion + "','_blank');</script>");
                }
            }
        }

        protected void ddlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUbicacion.SelectedItem.Value.Equals("12"))
            {
                _linea.Visible = true;
                _estacion.Visible = true;
            }
            else
            {
                _linea.Visible = false;
                _estacion.Visible = false;
            }
        }

    }
}