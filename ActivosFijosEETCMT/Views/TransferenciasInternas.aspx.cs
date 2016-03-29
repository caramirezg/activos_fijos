using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using ActivosFijosEETC.Models;
using System.Data;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class TransferenciasInternas : System.Web.UI.Page
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
                    div_RegistroTransferencia.Visible = false;
                    div_origen_destino.Visible = false;
                    cargarComboLineas();
                    cargarComboUbicaciones();
                    cargarComboTiposTransferencia();
                }
                cargarGrillaMaestroTransferencias();
                cargarGrillaPersonalOrigen();
                cargarGrillaPersonalDestino();
            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }
        }

        private void cargarGrillaMaestroTransferencias()
        {
            ControllerAsignacionesPorTransferencia vObjeto = new ControllerAsignacionesPorTransferencia();

            gridTransferencias.DataSource = vObjeto.DatosAsignacionesPorTransferenciaMaestro();
            gridTransferencias.KeyFieldName = "id";
            gridTransferencias.DataBind();
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
        private void cargarComboTiposTransferencia()
        {
            ddlTipoTransferencia.Items.Clear();
            ddlTipoTransferencia.Items.Add(new ListItem("Seleccione un item", "-1"));

            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlTipoTransferencia.DataSource = controllerHelper.ToDataTable(vObjeto.DatosClasificadoresByIDTipo("6"));
            ddlTipoTransferencia.DataValueField = "id";
            ddlTipoTransferencia.DataTextField = "nombre";
            ddlTipoTransferencia.DataBind();
        }

        private void cargarComboUbicaciones()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlUbicacion.DataSource = controllerHelper.ToDataTable(vObjeto.DatosClasificadoresByIDTipo("4"));
            ddlUbicacion.DataValueField = "id";
            ddlUbicacion.DataTextField = "nombre";
            ddlUbicacion.DataBind();
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

        protected void btnRegistroTransferencia_Click(object sender, EventArgs e)
        {
            cargarGrillaPersonalOrigen();
            cargarGrillaPersonalDestino();
            div_RegistroTransferencia.Visible = true;
            div_origen_destino.Visible = true;
            div_Maestro.Visible = false;
          
        }

        private void cargarGrillaPersonalOrigen()
        {
            ControllerPersonal vObjeto = new ControllerPersonal();

            gridPersonalOrigen.DataSource = controllerHelper.ToDataTable(vObjeto.ListPersonal());
            gridPersonalOrigen.KeyFieldName = "id";
            gridPersonalOrigen.DataBind();
        }

        private void cargarGrillaPersonalDestino()
        {
            ControllerPersonal vObjeto = new ControllerPersonal();

            gridPersonalDestino.DataSource = controllerHelper.ToDataTable(vObjeto.ListPersonal());
            gridPersonalDestino.KeyFieldName = "id";
            gridPersonalDestino.DataBind();
        }

        protected void ddlLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idLinea = ddlLinea.SelectedItem.Value.ToString();
            cargaEstaciones(idLinea);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (gridPersonalOrigen.FocusedRowIndex > -1 && gridPersonalDestino.FocusedRowIndex > -1)
            {
                ///personal origen
                var filaOrigen = this.gridPersonalOrigen.GetRow(gridPersonalOrigen.FocusedRowIndex);
                string fk_persona_origen = ((System.Data.DataRowView)(filaOrigen)).Row.ItemArray[0].ToString();
                string nro_documento_origen = ((System.Data.DataRowView)(filaOrigen)).Row.ItemArray[1].ToString();
                string nombres_origen = ((System.Data.DataRowView)(filaOrigen)).Row.ItemArray[2].ToString();
                string apellidos_origen = ((System.Data.DataRowView)(filaOrigen)).Row.ItemArray[3].ToString();
                string gerencia_origen = ((System.Data.DataRowView)(filaOrigen)).Row.ItemArray[5].ToString();

                ///personal destino
                var filaDestino = this.gridPersonalDestino.GetRow(gridPersonalDestino.FocusedRowIndex);
                string fk_persona_destino = ((System.Data.DataRowView)(filaDestino)).Row.ItemArray[0].ToString();
                string nro_documento_destino = ((System.Data.DataRowView)(filaDestino)).Row.ItemArray[1].ToString();
                string nombres_destino = ((System.Data.DataRowView)(filaDestino)).Row.ItemArray[2].ToString();
                string apellidos_destino = ((System.Data.DataRowView)(filaDestino)).Row.ItemArray[3].ToString();
                string gerencia_destino = ((System.Data.DataRowView)(filaDestino)).Row.ItemArray[5].ToString();

                string fk_estacion = null;
                string estacion = null;
                string linea = null;

                string dateTransferencia = Request.Form["dateFechaTransferencia"];
                string fkc_ubicacion = ddlUbicacion.SelectedItem.Value;
                string ubicacion = ddlUbicacion.SelectedItem.Text;
                string motivo = txtMotivo.Text;
                string fkc_tipo_transferencia = ddlTipoTransferencia.SelectedItem.Value;
                string tipo_transferencia = ddlTipoTransferencia.SelectedItem.Text;

                if (ddlEstacion.SelectedIndex > -1)
                {
                    fk_estacion = ddlEstacion.SelectedItem.Value;
                    estacion = ddlEstacion.SelectedItem.Text;
                    linea = ddlLinea.SelectedItem.Text;
                }
                //11=OFICINAS ADMINISTRATIVAS
                if (ddlUbicacion.SelectedItem.Value == "11")
                {
                    fk_estacion = null;
                    estacion = null;
                    linea = null;
                }

                string fkc_estado_proceso = "16";//16=ESTADO PRE TRANSFERIDO

                ControllerAsignacionesPorTransferencia vObjeto = new ControllerAsignacionesPorTransferencia();
                int vResult=vObjeto.CreaMaestroAsignacionPorTransferencia(dateTransferencia, fkc_ubicacion, fk_estacion, fk_persona_origen, fk_persona_destino,motivo,fkc_tipo_transferencia);
                if(vResult>0)
                    Response.Redirect("RegistroActivosAsignadosPorTransferencia.aspx?codigoAsignacionPorTransferencia=" + vResult + " &f_asignacion= " + dateTransferencia + " &ubicacion=" + ubicacion + " &linea=" + linea + "  " +
                    "&estacion=" + estacion + "  &fk_persona_origen= " + fk_persona_origen + " &documento_origen=" + nro_documento_origen + " &nombres_origen=" + nombres_origen + "  &apellidos_origen=" + apellidos_origen + " &gerencia_origen=" + gerencia_origen + " " +
                    "  &fk_persona_destino= " + fk_persona_destino + " &documento_destino=" + nro_documento_destino + " &nombres_destino=" + nombres_destino + "  &apellidos_destino=" + apellidos_destino + " &gerencia_destino=" + gerencia_destino + " &fkc_estado_proceso=" + fkc_estado_proceso + " &motivo="+motivo+" &fkc_tipo_transferencia="+fkc_tipo_transferencia+" &tipo_transferencia="+tipo_transferencia+"");
            }
        }

        protected void btnVerDetalleTransferencia_Click(object sender, EventArgs e)
        {
            if (gridTransferencias.FocusedRowIndex > -1)
            {
                var fila = this.gridTransferencias.GetRow(gridTransferencias.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string f_transferencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                string ubicacion = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                string linea = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                string estacion = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                string fk_persona_origen = ((System.Data.DataRowView)(fila)).Row.ItemArray[6].ToString();
                string documento_origen = ((System.Data.DataRowView)(fila)).Row.ItemArray[7].ToString();
                string nombres_origen = ((System.Data.DataRowView)(fila)).Row.ItemArray[8].ToString();
                string apellidos_origen = ((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString();
                string gerencia_origen = ((System.Data.DataRowView)(fila)).Row.ItemArray[10].ToString();
                string fk_persona_destino = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();
                string documento_destino = ((System.Data.DataRowView)(fila)).Row.ItemArray[12].ToString();
                string nombres_destino = ((System.Data.DataRowView)(fila)).Row.ItemArray[13].ToString();
                string apellidos_destino = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();
                string gerencia_destino = ((System.Data.DataRowView)(fila)).Row.ItemArray[15].ToString();
                string fkc_estado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[16].ToString();
                string estado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[17].ToString();

                string motivo = ((System.Data.DataRowView)(fila)).Row.ItemArray[18].ToString();
                string fkc_tipo_transferencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[19].ToString();
                string tipo_transferencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[20].ToString();

                Response.Redirect("RegistroActivosAsignadosPorTransferencia.aspx?codigoAsignacionPorTransferencia=" + id + " &f_asignacion= " + f_transferencia + " &ubicacion=" + ubicacion + " &linea=" + linea + "  "+
                    "&estacion=" + estacion + "  &fk_persona_origen= " + fk_persona_origen + " &documento_origen=" + documento_origen + " &nombres_origen=" + nombres_origen + "  &apellidos_origen=" + apellidos_origen + " &gerencia_origen=" + gerencia_origen + " "+
                    "  &fk_persona_destino= " + fk_persona_destino + " &documento_destino=" + documento_destino + " &nombres_destino=" + nombres_destino + "  &apellidos_destino=" + apellidos_destino + " &gerencia_destino=" + gerencia_destino + " &fkc_estado_proceso="+fkc_estado_proceso+" &motivo="+motivo+" &fkc_tipo_transferencia="+fkc_tipo_transferencia+" &tipo_transferencia="+tipo_transferencia+"");
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            if (gridTransferencias.FocusedRowIndex > -1)
            {
                var fila = this.gridTransferencias.GetRow(gridTransferencias.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string IdEstadoProceso = gridTransferencias.GetRowValues(gridTransferencias.FocusedRowIndex, "fkc_estado_proceso").ToString();
                if (IdEstadoProceso == "16")
                {
                    ControllerAsignacionesPorTransferencia vObjeto = new ControllerAsignacionesPorTransferencia();
                    int result = vObjeto.ApruebaAsignacionTransferencia(id);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Asignación aprobada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaMaestroTransferencias();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('No puede aprobar una transferencia ya aprobada').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnEliminarTransferencia_Click(object sender, EventArgs e)
        {
            if (gridTransferencias.FocusedRowIndex > -1)
            {
                var fila = this.gridTransferencias.GetRow(gridTransferencias.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[16].ToString();
                //Estado 16 estado pre transferido
                if (idEstado_proceso == "16")
                {
                    ControllerAsignacionesPorTransferencia vObjeto = new ControllerAsignacionesPorTransferencia();
                    int result = vObjeto.EliminaAsignacionTransferencia(id);
                    if (result > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Registro eliminado con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                         cargarGrillaMaestroTransferencias();
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroDanger').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('No puede eliminar un registro en estado Transferido').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void gridTransferencias_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado_proceso");
            if (value == "TRANSFERIDO")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9FECA");
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            div_RegistroTransferencia.Visible = true;
            div_RegistroTransferencia.Visible = false;
            div_origen_destino.Visible = false;
            div_Maestro.Visible = true;
        }

        protected void gridTransferencias_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "tipo_transferencia" && e.CellValue.Equals("TRANSFERENCIA POR DESVINCULACION"))     
            { 
                e.Cell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF4949");
            }
        }

     

        
    }
}