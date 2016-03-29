using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Drawing;
using System.Data;
using System.Text;


namespace ActivosFijosEETC.Views
{
    public partial class RevaluoTecnico : System.Web.UI.Page
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
                     div_ListaRevaluos.Visible = true;
                     div_RegistroMaestroRevaluo.Visible = false;

                 }

                 cargarGrillaRevaluo();
             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }
        }

        private void cargarGrillaRevaluo()
        {
            ControllerRevaluoTecnico vObjeto = new ControllerRevaluoTecnico();

            gridRevaluo.DataSource = vObjeto.DatosRevaluoMaestro();
            gridRevaluo.KeyFieldName = "id";
            gridRevaluo.DataBind();
        }

        protected void btnNuevoRevaluo_Click(object sender, EventArgs e)
        {
            div_ListaRevaluos.Visible = false;
            div_RegistroMaestroRevaluo.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            div_ListaRevaluos.Visible = true;
            div_RegistroMaestroRevaluo.Visible = false;
        }

        protected void btnVerDetalleRevaluo_Click(object sender, EventArgs e)
        {
            if (gridRevaluo.FocusedRowIndex > -1)
            {
                var fila = this.gridRevaluo.GetRow(gridRevaluo.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                string f_revaluo = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                string motivo_revaluo = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                string disposicion_respaldo = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                string fkc_estado_revaluo = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();

                Response.Redirect("RegistroActivosRevaluados.aspx?id_revaluo_maestro=" + id + " &f_revaluo= " + f_revaluo + " &motivo_revaluo=" + motivo_revaluo + " &disposicion_respaldo=" + disposicion_respaldo + " &fkc_estado_revaluo=" + fkc_estado_revaluo + "");
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            if (gridRevaluo.FocusedRowIndex > -1)
            {
                var fila = this.gridRevaluo.GetRow(gridRevaluo.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string f_revaluo = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                string idEstado_revaluo = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                //Estado 26 pre revaluado
                if (idEstado_revaluo == "26")
                {
                    ControllerRevaluoTecnico vObjeto = new ControllerRevaluoTecnico();
                    int result = vObjeto.ApruebaRevaluoMaestro(id, f_revaluo);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Revaluo aprobado con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaRevaluo();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se pueden aprobar revaluos en estado PRE REVALUADO').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridRevaluo.FocusedRowIndex > -1)
            {
                var fila = this.gridRevaluo.GetRow(gridRevaluo.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                //Estado 26 pre revaluado
                if (idEstado_proceso == "26")
                {
                    ControllerRevaluoTecnico vObjeto = new ControllerRevaluoTecnico();
                    int result = vObjeto.EliminaRevaluoMaestro(id);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Revaluo eliminado con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaRevaluo();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se pueden Eliminar revaluos en estado PRE REVALUADO').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnGuardarRevaluo_Click(object sender, EventArgs e)
        {
            string fechaRevaluo = Request.Form["dateFechaRevaluo"];
            string motivoRevaluo = txtMotivoRevaluo.Text;
            string disposicion_respaldo = txtDocumentoRespaldo.Text;

            if (string.IsNullOrEmpty(fechaRevaluo) || motivoRevaluo.Equals("") || string.IsNullOrEmpty(disposicion_respaldo))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#div_registro_warning').text('Por favor revise los campos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else
            {
                ControllerRevaluoTecnico vObjeto = new ControllerRevaluoTecnico();
                int result = vObjeto.CreaRevaluoMaestro(fechaRevaluo, motivoRevaluo, disposicion_respaldo);

                if (result > 0)
                {
                    string fkc_estado_revaluo = "26";
                    Response.Redirect("RegistroActivosRevaluados.aspx?id_revaluo_maestro=" + result + " &f_revaluo= " + fechaRevaluo + " &motivo_revaluo=" + motivoRevaluo + " &disposicion_respaldo=" + disposicion_respaldo + " &fkc_estado_revaluo=" + fkc_estado_revaluo + "");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#div_registro_danger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void gridRevaluo_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado_revaluo");
            if (value == "REVALUADO")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#FACB33");
                e.Row.ForeColor = Color.Black;
            }
        }
    }
}