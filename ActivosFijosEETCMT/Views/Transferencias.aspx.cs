using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using ActivosFijos.Models;
using System.Drawing;
using System.Data;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class Transferencias : System.Web.UI.Page
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
                div_ListaTransferencias.Visible = true;
                cargarGrillaPersonal();
                div_RegistroTransferencia.Visible = false;

                div_comiteTransferencia.Visible = false;
            }
            if (div_ListaTransferencias.Visible == true)
                cargarGrillaTransferencias();

            if (div_comiteTransferencia.Visible == true)
                cargarGrillaPersonal();

        }
        else
        {
            Response.Redirect("ActivosPorResponsable.aspx");
        }
        }

        private void cargarGrillaPersonal()
        {
            ControllerPersonal vObjeto = new ControllerPersonal();

            gridPersonal.DataSource = controllerHelper.ToDataTable(vObjeto.ListPersonal());
            gridPersonal.KeyFieldName = "id";
            gridPersonal.DataBind();
        }
        /// <summary>
        /// Muestra divs para registro de maestro de transferencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistroTransferencia_Click(object sender, EventArgs e)
        {
            div_ListaTransferencias.Visible = false;
            div_RegistroTransferencia.Visible = true;
            div_comiteTransferencia.Visible = true;
        }

        /// <summary>
        /// Aprueba una transferencia en estado elaborado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAprobarTransferencia_Click(object sender, EventArgs e)
        {
            if (gridTranferencia.FocusedRowIndex > -1)
            {
                var fila = this.gridTranferencia.GetRow(gridTranferencia.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string IdEstado_proceso = gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "fkc_estado_proceso").ToString();
                string f_transferencia = gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "f_transferencia").ToString();
                //Estado 4 estado elaborado
                if (IdEstado_proceso == "4")
                {
                    ControllerTransferencia vObjeto = new ControllerTransferencia();
                    int result = vObjeto.ApruebaTransferencia(id, f_transferencia);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Transferencia aprobada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaTransferencias();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('No puede aprobar una transferencia ya aprobada').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }
        /// <summary>
        /// Carga grilla transferencias
        /// </summary>
        private void cargarGrillaTransferencias()
        {
            ControllerTransferencia vObjeto = new ControllerTransferencia();

            gridTranferencia.DataSource = controllerHelper.ToDataTable(vObjeto.DatosTransferencias());
            gridTranferencia.KeyFieldName = "id";
            gridTranferencia.DataBind();
            
        }

        protected void btnGuardarTransferencia_Click(object sender, EventArgs e)
        {
            gridPersonal.FilterExpression = "";   

            string dateFechaTransferencia = Request.Form["dateFechaTransferencia"];
            string tasa_ufv = Request.Form["txtTasaUFV"].Replace(",", ".");
            string tasa_dolar = Request.Form["txtTasaDolar"].Replace(",", ".");

        

            //verificamos si hay comite seleccionado
            int j = 0;
            int count = 0;
            while (j <= gridPersonal.VisibleRowCount)
            {
                if (this.gridPersonal.Selection.IsRowSelected(j))
                {
                    count = count + 1;
                }
                j = j + 1;
            }


            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(tasa_ufv) || string.IsNullOrEmpty(tasa_dolar) ||  string.IsNullOrEmpty(txtDocRespaldo.Text)
                    || string.IsNullOrEmpty(txtOrigen.Text) || string.IsNullOrEmpty(dateFechaTransferencia))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warningTransferencias').text('Por favor revise los campos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else if (count > 0)
            {
                ControllerTransferencia vObjeto = new ControllerTransferencia();
                string estado_proceso = "4";//4= estado elaborado
                int result = vObjeto.CreaTransferencia(null,txtDescripcion.Text,dateFechaTransferencia,txtOrigen.Text,tasa_dolar,tasa_ufv,estado_proceso,txtDocRespaldo.Text);
                ///Registro comité de recepción

                if (result > 0)
                {
                    int i = 0;
                    List<ComiteRecepcionEntity> ListComiteRecepcion = new List<ComiteRecepcionEntity>();
                    while (i <= gridPersonal.VisibleRowCount)
                    {
                        if (this.gridPersonal.Selection.IsRowSelected(i))
                        {
                            ///insertamos datos si la fila está seleccionada
                            ListComiteRecepcion.Add(new ComiteRecepcionEntity(this.gridPersonal.GetRowValues(i, "id").ToString(), result));
                        }
                        i = i + 1;
                    }
                    ///mandamos la lista al controlador
                    ControllerComiteRecepcion vObjetoComite = new ControllerComiteRecepcion();
                    int resultComite = vObjetoComite.CreaComiteRecepcionPorTransferencia(ListComiteRecepcion);
                    if (resultComite > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#successTransferencias').text('Transferencia Realizada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");


                        string codigoTransferencia = HttpUtility.UrlEncode(controllerHelper.Encrypt(result.ToString()));
                        string descripcion = HttpUtility.UrlEncode(controllerHelper.Encrypt(txtDescripcion.Text.Trim().ToString()));
                        string fechaTransferencia = HttpUtility.UrlEncode(controllerHelper.Encrypt(dateFechaTransferencia));
                        string ufv = HttpUtility.UrlEncode(controllerHelper.Encrypt(tasa_ufv));
                        string sus = HttpUtility.UrlEncode(controllerHelper.Encrypt(tasa_dolar));
                        string documento_respaldo = HttpUtility.UrlEncode(controllerHelper.Encrypt(txtDocRespaldo.Text));
                        string origen = HttpUtility.UrlEncode(controllerHelper.Encrypt(txtOrigen.Text));
                        string IdEstadpProceso = HttpUtility.UrlEncode(controllerHelper.Encrypt(estado_proceso));

                        Response.Redirect(string.Format("../Views/RegistroActivosPorTransferencia.aspx?codigoTransferencia={0}&descripcion={1}&fechaTransferencia={2}&tasaUFV={3}&tasaSus={4}&docRespaldo={5}&origen={6}&idEstadoProceso={7}",
                                                      codigoTransferencia, descripcion, fechaTransferencia, ufv, sus, documento_respaldo, origen, IdEstadpProceso));
                        //Response.Redirect("RegistroActivosPorTransferencia.aspx?codigoTransferencia=" + codigoTransferencia + " &descripcion= " + descripcion + " &fechaTransferencia= " + fechaTransferencia + " &tasaUFV=" + ufv + " &tasaSus=" + sus + "   &docRespaldo=" + documento_respaldo + " &origen=" + origen + " &idEstadoProceso=" + IdEstadpProceso + "");

                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#dangerTransferencias').text('Lo sentimos hubo un problema al registrar el comite de recepción').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#dangerTransferencias').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warningTransferencias').text('Debe seleccionar al menos una persona como comite de recepción').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            div_ListaTransferencias.Visible = true;
            div_RegistroTransferencia.Visible = false;
            div_comiteTransferencia.Visible = false;
        }
        /// <summary>
        /// Muestra los registros de los activos de la transferencia seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistrarActivos_Click(object sender, EventArgs e)
        {
            if (gridTranferencia.FocusedRowIndex > -1)
            {
                string id = HttpUtility.UrlEncode(controllerHelper.Encrypt(gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "id").ToString()));
                string descripcion = HttpUtility.UrlEncode(controllerHelper.Encrypt(gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "descripcion").ToString()));
                string fechaTransferencia = HttpUtility.UrlEncode(controllerHelper.Encrypt(gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "f_transferencia").ToString()));
                string origen = HttpUtility.UrlEncode(controllerHelper.Encrypt(gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "origen").ToString()));
                string TasaSus = HttpUtility.UrlEncode(controllerHelper.Encrypt(gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "tasa_sus").ToString()));
                string TasaUFV = HttpUtility.UrlEncode(controllerHelper.Encrypt(gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "tasa_ufv").ToString()));
                string docRespaldo = HttpUtility.UrlEncode(controllerHelper.Encrypt(gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "doc_respaldo").ToString()));
                string fkc_estado_proceso = HttpUtility.UrlEncode(controllerHelper.Encrypt(gridTranferencia.GetRowValues(gridTranferencia.FocusedRowIndex, "fkc_estado_proceso").ToString()));

                Response.Redirect(string.Format("../Views/RegistroActivosPorTransferencia.aspx?codigoTransferencia={0}&descripcion={1}&fechaTransferencia={2}&tasaUFV={3}&tasaSus={4}&docRespaldo={5}&origen={6}&idEstadoProceso={7}",
                                                        id, descripcion, fechaTransferencia, TasaUFV, TasaSus, docRespaldo, origen, fkc_estado_proceso));

                //Response.Redirect("RegistroActivosPorTransferencia.aspx?codigoTransferencia=" + id + " &descripcion= " + descripcion + "  &fechaTransferencia= " + fechaTransferencia + " &tasaUFV=" + TasaUFV + " &tasaSus=" + TasaSus + " &docRespaldo=" + docRespaldo + " &origen=" + origen + " &idEstadoProceso=" + fkc_estado_proceso + "");
            }
        }
        /// <summary>
        /// Elimina un registro de transferencia en estado elaborado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridTranferencia.FocusedRowIndex > -1)
            {
                var fila = this.gridTranferencia.GetRow(gridTranferencia.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[10].ToString();
                //Estado 4 estado elaborado
                if (idEstado_proceso == "4")
                {
                    ControllerTransferencia vObjeto = new ControllerTransferencia();
                    int result = vObjeto.EliminaTransferencia(id);
                    if (result > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Registro eliminado con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaTransferencias();
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroDanger').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('No puede eliminar una transferencia en estado aprobado').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void gridTranferencia_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado_proceso");
            if (value == "APROBADO")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#47A354");
                e.Row.ForeColor = Color.White;
            }
        }

        protected void gridTranferencia_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "monto_bs")
            {
                e.Cell.Text = string.Format("Bs. {0:0,0.00}", Convert.ToDecimal(e.CellValue));
            }
            if (e.DataColumn.FieldName == "monto_ufv")
            {
                e.Cell.Text = string.Format("UFV. {0:0,0.0000}", Convert.ToDecimal(e.CellValue));
            }
            if (e.DataColumn.FieldName == "monto_sus")
            {
                e.Cell.Text = string.Format("$us. {0:0,0.00}", Convert.ToDecimal(e.CellValue));
            }
        }
    }
}