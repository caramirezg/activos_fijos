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
    public partial class RegistroActivosRevaluados : System.Web.UI.Page
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
                     txtCodigoMaestroRevaluo.Text = Request.QueryString["id_revaluo_maestro"].Trim();
                     txtFechaRevaluo.Text = Convert.ToDateTime(Request.QueryString["f_revaluo"]).ToString("dd/MM/yyyy");
                     txtMotivoRevaluo.Text = Request.QueryString["motivo_revaluo"].Trim();
                     txtDisposicionRespaldo.Text = Request.QueryString["disposicion_respaldo"].Trim();

                     //Clasificadores estado 26 = PRE REVALUADO
                     if (Request.QueryString["fkc_estado_revaluo"].Trim() == "26")
                     {
                         actionActivos.Visible = true;
                     }
                     else
                     {
                         actionActivos.Visible = false;
                         _activos_existentes.Visible = false;
                         _activos_revaluados.Style.Add("width", "100%");

                     }

                 }

                 cargarGrillaActivos();
                 cargarGrillaActivosRevaluados();

             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }
        }

        private void cargarGrillaActivos()
        {
            ControllerRevaluoTecnico vObjeto = new ControllerRevaluoTecnico();

            gridActivos.DataSource = vObjeto.DatosActivos();
            gridActivos.KeyFieldName = "id";
            gridActivos.DataBind();
        }

        private void cargarGrillaActivosRevaluados()
        {
            ControllerRevaluoTecnico vObjeto = new ControllerRevaluoTecnico();

            gridDetalleRevaluo.DataSource = vObjeto.DatosActivosRevaluados(txtCodigoMaestroRevaluo.Text);
            gridDetalleRevaluo.KeyFieldName = "id";
            gridDetalleRevaluo.DataBind();
        }

        protected void btnVerRevaluos_Click(object sender, EventArgs e)
        {
            Response.Redirect("RevaluoTecnico.aspx");
        }

        protected void btnRegistrarRevaluo_Click(object sender, EventArgs e)
        {
            if (gridActivos.FocusedRowIndex > -1)
            {
                var fila = this.gridActivos.GetRow(gridActivos.FocusedRowIndex);
                string fk_activo = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                string costo_actualizado_inicial_anterior = ((System.Data.DataRowView)(fila)).Row.ItemArray[8].ToString();
         
                    string observaciones = null;
                    string textObservaciones = txtObservaciones.Text.Trim();
                    if (string.IsNullOrEmpty(textObservaciones))
                        observaciones = "SIN OBSERVACIONES";
                    else
                        observaciones = txtObservaciones.Text;

                   

                    ControllerRevaluoTecnico vObjeto = new ControllerRevaluoTecnico();

                    vObjeto.CreaRevaluoDetalle(txtCodigoMaestroRevaluo.Text, fk_activo, txtCostoAntiguo.Text, txtCostoRevaluo.Text.Replace(".", ","), txtNuevaVidaUtil.Text, observaciones,costo_actualizado_inicial_anterior);
                    cargarGrillaActivos();
                    cargarGrillaActivosRevaluados();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('El activo fue revaluado satisfactoriamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

            }
        }

        protected void btnEliminarRevaluo_Click(object sender, EventArgs e)
        {
            if (gridDetalleRevaluo.FocusedRowIndex > -1)
            {

                int vresult = 0;
                var fila = this.gridDetalleRevaluo.GetRow(gridDetalleRevaluo.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                ControllerRevaluoTecnico vObjeto = new ControllerRevaluoTecnico();

                vresult = vObjeto.EliminaRevaluoDetalle(id);
                if (vresult > 0)
                {
                    cargarGrillaActivos();
                    cargarGrillaActivosRevaluados();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('El revaluo fue eliminado correctamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

                }
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('reportes/ReporteRevaluoTecnico.aspx?idMaestroRevaluo=" + txtCodigoMaestroRevaluo.Text + "','_blank');</script>");
        }

        protected void btnRegistrarRevaluo_Click1(object sender, EventArgs e)
        {
            if (gridActivos.FocusedRowIndex > -1)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarPopup", "RevaluoModal();", true);
                var fila = this.gridActivos.GetRow(gridActivos.FocusedRowIndex);

                txtCostoAntiguo.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[6].ToString();
 
            }
        }
    }
}