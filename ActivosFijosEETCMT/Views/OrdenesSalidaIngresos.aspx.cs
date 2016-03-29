using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using DevExpress.Web.ASPxGridView;
using System.Drawing;
using System.Data;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class OrdenesSalidaIngresos : System.Web.UI.Page
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
          
                if (!Page.IsPostBack)
                {

                    lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    _armarMenu();

                
                    div_ListaSolicitudes.Visible = true;
                    div_RegistroMaestroSolicitud.Visible = false;
                    div_ResponsableSolicitud.Visible = false;


                    if (vPerfil.Equals("1"))
                    {
                        gridPersonal.Settings.ShowFilterRow = true;
                        gridPersonal.Settings.ShowFilterRowMenu = true;
                        gridPersonal.Settings.ShowHeaderFilterButton = true;
                    }
                    else if (vPerfil.Equals("2"))
                    {
                        gridPersonal.Settings.ShowFilterRow = false;
                        gridPersonal.Settings.ShowFilterRowMenu = false;
                        gridPersonal.Settings.ShowHeaderFilterButton = false;
                        this.btnAprobarSolicitud.Visible = false;
                        
                    }
                }

                cargarGrillaSolicitudesMaestro();
             

                if (div_ResponsableSolicitud.Visible == true)
                    cargarGrillaPersonal();

                
         
        }

        private void cargarGrillaSolicitudesMaestro()
        {
            string vFk_persona = HttpContext.Current.Session["fk_persona"].ToString();
            string vPerfil = HttpContext.Current.Session["perfil"].ToString();

            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

            gridSolicitudes.DataSource = vObjeto.DatosSolicitudesMaestro(vFk_persona, vPerfil);
            gridSolicitudes.KeyFieldName = "id";
            gridSolicitudes.DataBind();
        }


        /// <summary>
        /// Carga la grilla del personal
        /// </summary>
        private void cargarGrillaPersonal()
        {
            ControllerPersonal vObjeto = new ControllerPersonal();


            gridPersonal.DataSource = controllerHelper.ToDataTable(vObjeto.ListPersonal());
            gridPersonal.KeyFieldName = "documento";
            gridPersonal.DataBind();

            string vPerfil = HttpContext.Current.Session["perfil"].ToString();
            string vFk_persona = HttpContext.Current.Session["fk_persona"].ToString();
            if (vPerfil.Equals("2"))
            {
                gridPersonal.FilterExpression = "[id] = " + vFk_persona + "";
            }
        }

        protected void btnNuevaSolicitud_Click(object sender, EventArgs e)
        {
            div_ListaSolicitudes.Visible = false;
            div_RegistroMaestroSolicitud.Visible = true;
            div_ResponsableSolicitud.Visible = true;
            cargarGrillaPersonal();
            txtFechaSolicitud.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        protected void btnGuardarAsignacion_Click(object sender, EventArgs e)
        {
           
                string fechaSolicitud = txtFechaSolicitud.Text;
                string fechaDesde = Request.Form["dateFechaDesde"];
                string fechaHasta = Request.Form["dateFechaHasta"];
                string motivo = txtMotivoSalida.Text;
                //string documento_autorizacion=txtDocumentoAutorizacion.Text;
                string fkc_estado_salida = "20";///20=SALIDA SOLICITADA
                string persona=null;
                string documento = null;
                string nombres = null;
                string apellidos = null;
                string area = null;
                string gerencia = null;

                string vPerfil = HttpContext.Current.Session["perfil"].ToString();
                string vFk_persona = HttpContext.Current.Session["fk_persona"].ToString();
                if (vPerfil.Equals("2") && gridPersonal.FocusedRowIndex > -1)
                {
                    persona = vFk_persona.ToString();

                    var fila = this.gridPersonal.GetRow(gridPersonal.FocusedRowIndex);
                    documento = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                    nombres = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                    apellidos = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                    area = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                    gerencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                }
                else if(gridPersonal.FocusedRowIndex > -1)
                {
                    var fila = this.gridPersonal.GetRow(gridPersonal.FocusedRowIndex);
                    string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                    documento = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                    nombres = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                    apellidos = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                    area = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                    gerencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                  
                    persona = id;
                }

                if (string.IsNullOrEmpty(fechaSolicitud) || string.IsNullOrEmpty(fechaDesde) ||  string.IsNullOrEmpty(persona) || string.IsNullOrEmpty(txtMotivoSalida.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Por favor revise los campos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                {
                    string correlativo = "0";
                    ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();
                    int result = vObjeto.CreaIngresoSalidaMaestro(persona, fechaSolicitud, fechaDesde, fechaHasta, motivo, fkc_estado_salida);

                    if (result > 0)
                    {
                        Response.Redirect("RegistroActivosPorOrdenSalida.aspx?codigoOrdenSalidaMaestro=" + result + " &correlativo=" + correlativo + " &f_solicitud= " + fechaSolicitud + " &f_desde=" + fechaDesde + " &f_hasta=" + fechaHasta + "  " +
                    "&motivo=" + motivo + "  &fk_persona= " + persona + " &documento=" + documento + " &nombres=" + nombres + "  &apellidos=" + apellidos + " &area=" + area + " " +
                    "&gerencia= " + gerencia + " &fkc_estado_salida=" + fkc_estado_salida + "");
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroDanger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            div_ListaSolicitudes.Visible = true;
            div_RegistroMaestroSolicitud.Visible = false;
            div_ResponsableSolicitud.Visible = false;
        }

        protected void btnVerDetalleSolicitud_Click(object sender, EventArgs e)
        {
            if (gridSolicitudes.FocusedRowIndex > -1)
            {
                var fila = this.gridSolicitudes.GetRow(gridSolicitudes.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                string f_solicitud = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                string f_desde = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                string f_hasta = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                string motivo = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                string fk_persona = ((System.Data.DataRowView)(fila)).Row.ItemArray[6].ToString();
                string documento = ((System.Data.DataRowView)(fila)).Row.ItemArray[7].ToString();
                string nombres = ((System.Data.DataRowView)(fila)).Row.ItemArray[8].ToString();
                string apellidos = ((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString();
                string area = ((System.Data.DataRowView)(fila)).Row.ItemArray[10].ToString();
                string gerencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();
                string fkc_estado_salida = ((System.Data.DataRowView)(fila)).Row.ItemArray[12].ToString();
                string documento_autorizacion = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();
                string correlativo = gridSolicitudes.GetRowValues(gridSolicitudes.FocusedRowIndex, "correlativo").ToString();

                if (string.IsNullOrEmpty(correlativo))
                    correlativo = "0";

                Response.Redirect("RegistroActivosPorOrdenSalida.aspx?codigoOrdenSalidaMaestro=" + id + " &correlativo=" + correlativo + " &f_solicitud= " + f_solicitud + " &f_desde=" + f_desde + " &f_hasta=" + f_hasta + "  " +
                    "&motivo=" + motivo + "  &fk_persona= " + fk_persona + " &documento=" + documento + " &nombres=" + nombres + "  &apellidos=" + apellidos + " &area=" + area + " " +
                    "  &gerencia= " + gerencia + " &fkc_estado_salida=" + fkc_estado_salida + " &documento_autorizacion=" + documento_autorizacion + "");
            }
        }

        protected void btnAprobarSalida_Click(object sender, EventArgs e)
        {
            if (gridSolicitudes.FocusedRowIndex > -1)
            {
                var fila = this.gridSolicitudes.GetRow(gridSolicitudes.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string f_solicitud = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[12].ToString();
                //Estado 20 salida solicitada
                if (idEstado_proceso == "20")
                {
                    ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();
                    int result = vObjeto.ApruebaSalida(id, f_solicitud);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Solicitud aprobada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaSolicitudesMaestro();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se pueden aprobar salidas en estado solicitado').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridSolicitudes.FocusedRowIndex > -1)
            {
                var fila = this.gridSolicitudes.GetRow(gridSolicitudes.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[12].ToString();
                //Estado 20 salida solicitada
                if (idEstado_proceso == "20")
                {
                    ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();
                    int result = vObjeto.EliminaSalida(id);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Solicitud eliminada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaSolicitudesMaestro();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se pueden Eliminar salidas en estado solicitado').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void gridSolicitudes_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado_salida");
            if (value == "SALIDA APROBADA")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#BC911C");
                e.Row.ForeColor = Color.White;
            }
        }

        protected void btnEditarMaestro_Click(object sender, EventArgs e)
        {
            if (gridSolicitudes.FocusedRowIndex > -1)
            {
                if (gridSolicitudes.GetRowValues(gridSolicitudes.FocusedRowIndex, "fkc_estado_salida").ToString() == "20")
                {
                string message = "modalEditar();";
                ScriptManager.RegisterStartupScript(sender as Control, this.GetType(), "alert", message, true);

                txtEditaFechaSolicitud.Text = Convert.ToDateTime(gridSolicitudes.GetRowValues(gridSolicitudes.FocusedRowIndex, "f_solicitud").ToString()).ToString("dd/MM/yyyy");
                dateEditaFechaDesde.Value = Convert.ToDateTime(gridSolicitudes.GetRowValues(gridSolicitudes.FocusedRowIndex, "f_desde").ToString()).ToString("dd/MM/yyyy");
                if (string.IsNullOrEmpty(gridSolicitudes.GetRowValues(gridSolicitudes.FocusedRowIndex, "f_hasta").ToString()))
                    dateEditaFechaHasta.Value = null;
                else
                    dateEditaFechaHasta.Value = Convert.ToDateTime(gridSolicitudes.GetRowValues(gridSolicitudes.FocusedRowIndex, "f_hasta").ToString()).ToString("dd/MM/yyyy");
                txtEditaMotivoSalida.Text = gridSolicitudes.GetRowValues(gridSolicitudes.FocusedRowIndex, "motivo").ToString();
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se puede editar ordenes de salida en estado SOLICITADO').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnGuardarEditaMaestro_Click(object sender, EventArgs e)
        {
            if (gridSolicitudes.FocusedRowIndex > -1)
            {
                

                    ControllerIngresosSalidas objetoSalidas = new ControllerIngresosSalidas();
                    int vResult = objetoSalidas.EditaSalidaMaestro(gridSolicitudes.GetRowValues(gridSolicitudes.FocusedRowIndex, "id").ToString(), Request.Form["dateEditaFechaDesde"].ToString().Trim(), Request.Form["dateEditaFechaHasta"].ToString().Trim(), txtEditaMotivoSalida.Text.ToString().Trim());
                    if (vResult == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Solicitud editada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaSolicitudesMaestro();
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroDanger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

                
            }
        }

    }
}