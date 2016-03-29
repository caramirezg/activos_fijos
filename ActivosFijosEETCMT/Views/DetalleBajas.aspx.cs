using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Data;
using ActivosFijosEETC.Models;
using CrystalDecisions.Shared;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class DetalleBajas : System.Web.UI.Page
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
               }
               cargarActivos();
           }
           else
           {
               Response.Redirect("ActivosPorResponsable.aspx");
           }
        }

        private void cargarActivos()
        {
            ControllerBajas vObjeto = new ControllerBajas();
            gridActivosBajas.DataSource = vObjeto.DatosDetalleActivosDadosDeBaja();
            gridActivosBajas.DataBind();
        }

        protected void btnDepreciar_Click(object sender, EventArgs e)
        {
            string fecha = Request.Form["dateFechaRegistro"];
            if (!string.IsNullOrEmpty(fecha))
            {
                ControllerTasasCambio vTasaCambio = new ControllerTasasCambio();
                int resultTasa = vTasaCambio.validaExistenciaFechaRegistrada(fecha);
                if (resultTasa > 0)
                {
                    ControllerActivos vActivo = new ControllerActivos();
                    int vResult = vActivo.ProcesoDepreciacion(fecha);
                    if (vResult > 0)
                    {
                        cargarActivos();
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Los activos se han actualizado y depreciado exitosamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('La fecha seleccionada no tiene ufv registrada').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('Debe seleccionar la fecha a depreciar').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }


        protected void btnImprimirInforme_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('reportes/ReporteDetalleActivosBajas.aspx','_blank');</script>");
        }

       
        DataSet DsetDetalleActivos = new DataSet();

        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        protected void btnExportarExcelDetalle_Click(object sender, EventArgs e)
        {
            ClaseActivo ReporteActivo = new ClaseActivo();

            rep.Load(Server.MapPath("~/Views/reportes/RptDetalleActivosBajas.rpt"));

            DsetDetalleActivos = ReporteActivo.ReporteDetalleBajasActivos();
            rep.SetDataSource(DsetDetalleActivos);
            rep.SetParameterValue("fecha", DateTime.Today.ToString("d 'de' MMMM 'de' yyyy"));

            rep.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "Detalle bajas");
        }
    }
}