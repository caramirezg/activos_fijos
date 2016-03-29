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
    public partial class Bajas : System.Web.UI.Page
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
                     div_ListaBajas.Visible = true;
                     div_RegistroMaestroBaja.Visible = false;
                     cargarComboMotivosBaja();
                 }

                 cargarGrillaBajas();

             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }

        }

        private void cargarComboMotivosBaja()
        {
            ControllerBajas vObjeto = new ControllerBajas();
            ddlMotivosbaja.DataSource = vObjeto.DatosMotivosBajasMaestro();
            ddlMotivosbaja.DataValueField = "id";
            ddlMotivosbaja.DataTextField = "motivo_baja";
            ddlMotivosbaja.DataBind();
        }

        protected void btnNuevaBaja_Click(object sender, EventArgs e)
        {
            div_ListaBajas.Visible = false;
            div_RegistroMaestroBaja.Visible = true;
        }


        private void cargarGrillaBajas()
        {
            ControllerBajas vObjeto = new ControllerBajas();

            gridBajas.DataSource = vObjeto.DatosBajasMaestro();
            gridBajas.KeyFieldName = "id";
            gridBajas.DataBind();
        }

        protected void btnGuardarBaja_Click(object sender, EventArgs e)
        {
          
            string fechaBaja = Request.Form["dateFechaBaja"];
            string id_motivoBaja = ddlMotivosbaja.SelectedItem.Value;
            string motivoBaja = ddlMotivosbaja.SelectedItem.Text;

            if (string.IsNullOrEmpty(fechaBaja) || ddlMotivosbaja.SelectedItem.Value.Equals("-1")|| string.IsNullOrEmpty(txtDocumentoRespaldo.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#div_registro_warning').text('Por favor revise los campos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else
            {
                ControllerBajas vObjeto = new ControllerBajas();
                int result = vObjeto.CreaBajaMaestro(fechaBaja, id_motivoBaja,txtDocumentoRespaldo.Text.Trim());

                if (result > 0)
                {
                    string fkc_estado_proceso = "24";
                    Response.Redirect("RegistroBajasActivos.aspx?id_baja_maestro=" + result + " &f_baja= " + fechaBaja + " &motivo_baja=" + motivoBaja + "  &fkc_estado_proceso=" + fkc_estado_proceso + " &documento_respaldo="+txtDocumentoRespaldo.Text+"");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#div_registro_danger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            div_ListaBajas.Visible = true;
            div_RegistroMaestroBaja.Visible = false;
        }

        protected void btnAprobarBaja_Click(object sender, EventArgs e)
        {
            if (gridBajas.FocusedRowIndex > -1)
            {
                var fila = this.gridBajas.GetRow(gridBajas.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string f_baja = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                //Estado 24 pre baja
                if (idEstado_proceso == "24")
                {
                    ControllerBajas vObjeto = new ControllerBajas();
                    int result = vObjeto.ApruebaBajaMaestro(id,f_baja);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Baja aprobada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaBajas();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se pueden aprobar bajas en estado PRE BAJA').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnEliminarBaja_Click(object sender, EventArgs e)
        {
            if (gridBajas.FocusedRowIndex > -1)
            {
                var fila = this.gridBajas.GetRow(gridBajas.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                //Estado 24 pre baja
                if (idEstado_proceso == "24")
                {
                    ControllerBajas vObjeto = new ControllerBajas();
                    int result = vObjeto.EliminaBajaMaestro(id);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Baja eliminada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaBajas();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se pueden Eliminar bajas en estado PRE BAJA').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnVerDetalleBaja_Click(object sender, EventArgs e)
        {
            if (gridBajas.FocusedRowIndex > -1)
            {
                var fila = this.gridBajas.GetRow(gridBajas.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                string fechaBaja = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                string motivoBaja = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                string fkc_estado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                string documento_respaldo = ((System.Data.DataRowView)(fila)).Row.ItemArray[8].ToString();

                Response.Redirect("RegistroBajasActivos.aspx?id_baja_maestro=" + id + " &f_baja= " + fechaBaja + " &motivo_baja=" + motivoBaja + "  &fkc_estado_proceso=" + fkc_estado_proceso + " &documento_respaldo=" + documento_respaldo + "");
            }
        }

        protected void gridBajas_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado_proceso");
            if (value == "BAJA")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F05555");
                e.Row.ForeColor = Color.White;
            }
        }
    }
}