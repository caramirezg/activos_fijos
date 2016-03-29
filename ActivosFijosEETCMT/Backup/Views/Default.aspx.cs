using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Text;
using System.Data;

namespace ActivosFijosEETC.Views
{
    public partial class Default : System.Web.UI.Page
    {
        protected void _armarMenu()
        {
            ControllerAdministracion ObjetoAdministracion = new ControllerAdministracion();
            DataSet dsMenu= ObjetoAdministracion.getMenu();
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

        //protected void _roles_menu()
        //{
        //    ///Roles de usuario
        //    string vPerfil = HttpContext.Current.Session["perfil"].ToString();
        //    if (vPerfil.Equals("1"))//administrador
        //    {
        //        _parametrizacion.Visible = true;
        //        _proveedores.Visible = true;
        //        _altas.Visible = true;
        //        _transferencias.Visible = true;
        //        _asignaciones.Visible = true;
        //        _depreciaciones.Visible = true;
        //        _control_activos.Visible = true;
        //        _cierre.Visible = true;
        //        _apertura.Visible = true;
        //        _reportes.Visible = true;

        //    }
        //    else if (vPerfil.Equals("2"))//persona
        //    {

        //        _bajas.Visible = false;
        //        _parametrizacion.Visible = false;
        //        _proveedores.Visible = false;
        //        _altas.Visible = false;
        //        _transferencias.Visible = false;
        //        _asignaciones.Visible = false;
        //        _depreciaciones.Visible = false;
        //        _control_activos.Visible = false;
        //        _cierre.Visible = false;
        //        _apertura.Visible = false;
        //        _reportes.Visible = false;
        //        _menu.Visible = false;
        //    }
        //    else if (vPerfil.Equals("3"))//auditor
        //    {

        //        _bajas.Visible = false;
        //        _parametrizacion.Visible = false;
        //        _proveedores.Visible = false;
        //        _altas.Visible = false;
        //        _transferencias.Visible = false;
        //        _asignaciones.Visible = false;
        //        _depreciaciones.Visible = false;
        //        _control_activos.Visible = false;
        //        _cierre.Visible = false;
        //        _apertura.Visible = false;
        //        _reportes.Visible = true;
        //        _contenido.Visible = false;
        //    }
        
        //}

        protected void Page_Init(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null) { Response.Redirect("~/Views/login.aspx"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string vPerfil = HttpContext.Current.Session["perfil"].ToString();
            if (!vPerfil.Equals("2"))//persona
            {

                if (!Page.IsPostBack)
                {
                  
                    if (vPerfil.Equals("1"))//persona
                    {
                        lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                        lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                        _armarMenu();
                    }
                    else
                    {
                        Response.Redirect("ActivosPorResponsable.aspx");
                    }

                }

                ControllerAdministracion vObjeto = new ControllerAdministracion();
                lblCompras.Text = vObjeto.obtieneActivosComprados().ToString();
                lblTransferencias.Text = vObjeto.obtieneActivosTransferidos().ToString();
                lblAsignaciones.Text = vObjeto.obtieneActivosAsignados().ToString();
                lblBajas.Text = vObjeto.obtieneCountBajas().ToString();
                lblRevaluo.Text = vObjeto.obtieneCountRevaluo().ToString();
                lblUltimaDepreciacion.Text = Convert.ToDateTime(vObjeto.obtieneUltimaDepreciacion()).ToString("dd/MM/yyyy");
                lblTransferenciasInternas.Text = vObjeto.obtieneCountTransferenciasInternas().ToString();

            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }
        }
    }
}