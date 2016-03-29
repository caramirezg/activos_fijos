using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Data;
using ActivosFijos.Models;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Text;




namespace ActivosFijosEETC.Views
{
    public partial class Compras : System.Web.UI.Page
    {
        ControllerHelper controllerHelper = new ControllerHelper();
        ControllerReservaCorrelativo controllerReservaCorrelativo = new ControllerReservaCorrelativo();
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
                    div_Listacompras.Visible = true;
                    div_RegistroCompras.Visible = false;
                    div_comiteCompras.Visible = false;
                    cargarGrillaPersonal();
                    cargarComboGerenciasSolicitantes();
                    cargarComboProveedores();
                    cargarComboFuenteFinanciamiento();
                    cargarComboReservas();
                }

                if (div_Listacompras.Visible == true)
                    cargarGrillaCompras();

                if (div_comiteCompras.Visible == true)
                    cargarGrillaPersonal();
            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }
        }

        private void cargarComboReservas()
        {
            ControllerProveedor vObjeto = new ControllerProveedor();
            ddlReservas.Items.Clear();
            ddlReservas.Items.Add(new ListItem("seleccione una reserva", "-1"));
            ddlReservas.DataSource = controllerReservaCorrelativo.getDataTableReservaVigenteCorrelativos();
            ddlReservas.DataValueField = "id";
            ddlReservas.DataTextField = "correlativo";
            ddlReservas.DataBind();
        }

        /// <summary>
        /// Carga el combo de fuente de financiamiento
        /// </summary>
        private void cargarComboFuenteFinanciamiento()
        {
            ControllerFuenteFinanciamiento vObjeto = new ControllerFuenteFinanciamiento();
            ddlFinanciamiento.DataSource = controllerHelper.ToDataTable(vObjeto.DatosFuentesFinanciamiento());
            ddlFinanciamiento.DataValueField = "id";
            ddlFinanciamiento.DataTextField = "nombre";
            ddlFinanciamiento.DataBind();
        }
        /// <summary>
        /// carga el combo de proveedores
        /// </summary>
        private void cargarComboProveedores()
        {
            ControllerProveedor vObjeto = new ControllerProveedor();
            ddlProveedores.DataSource = controllerHelper.ToDataTable(vObjeto.DatosProveedores());
            ddlProveedores.DataValueField = "id";
            ddlProveedores.DataTextField = "nombre";
            ddlProveedores.DataBind();
        }
        /// <summary>
        /// carga el combo de gerencias solicitantes
        /// </summary>
        private void cargarComboGerenciasSolicitantes()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlSolicitante.DataSource=controllerHelper.ToDataTable(vObjeto.DatosGerencias());
            ddlSolicitante.DataValueField = "id";
            ddlSolicitante.DataTextField = "nombre";
            ddlSolicitante.DataBind();
        }
        /// <summary>
        /// Cargar la grilla compras
        /// </summary>
        private void cargarGrillaCompras()
        {
            ControllerCompras vObjeto = new ControllerCompras();
           
            gridCompras.DataSource = controllerHelper.ToDataTable(vObjeto.DatosCompras());
            gridCompras.KeyFieldName = "ID";
            gridCompras.DataBind();
        }

        /// <summary>
        /// Carga la grilla del personal
        /// </summary>
        private void cargarGrillaPersonal()
        {
            ControllerPersonal vObjeto = new ControllerPersonal();

            gridPersonal.DataSource = controllerHelper.ToDataTable(vObjeto.ListPersonal());
            gridPersonal.KeyFieldName = "id";
            gridPersonal.DataBind();
        }

        /// <summary>
        /// Muestra los campos para registrar una compra nueva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistroCompra_Click(object sender, EventArgs e)
        {
            cargarGrillaPersonal();
            div_Listacompras.Visible = false;
            div_RegistroCompras.Visible = true;
            div_comiteCompras.Visible = true;
          
        }
        /// <summary>
        /// Guarda un registro de compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            gridPersonal.FilterExpression = "";   
            
            //string dateRegistro = Request.Form["dateFechaRegistro"];
                //string ddlProveedor = Request.Form["ddlProveedor"];
                //string ddlGerenciaSolicitante = Request.Form["ddlGerenciaSolicitante"];

            string dateRegistro = Request.Form["dateFechaRegistro"];
            string tasa_ufv = Request.Form["txtTasaUFV"].Replace(",", ".");
            string tasa_dolar = Request.Form["txtTasaDolar"].Replace(",", ".");


            string ddlProveedor = ddlProveedores.SelectedValue;
            string ddlGerenciaSolicitante = ddlSolicitante.SelectedValue;
            string ddlFuenteFinanciamiento = ddlFinanciamiento.SelectedValue;
            string nombreProveedor = ddlProveedores.SelectedItem.Text;
            string nombreSolicitante = ddlSolicitante.SelectedItem.Text;
            string nombreFuenteFinanciamiento = ddlFinanciamiento.SelectedItem.Text;
                
                //string a = ddlGerenciaSolicitante.SelectedItem.Value.ToString();
                
                //string ddlGerenciaSolicitante=ddlGerenciaSolicitante   


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


            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(tasa_ufv)||string.IsNullOrEmpty(tasa_dolar) || string.IsNullOrEmpty(txtNroFactura.Text) || string.IsNullOrEmpty(txtDocRespaldo.Text) ||
                     string.IsNullOrEmpty(dateRegistro) || string.IsNullOrEmpty(ddlGerenciaSolicitante) || ddlGerenciaSolicitante == "-1" || string.IsNullOrEmpty(ddlProveedor) || ddlProveedor == "-1" || string.IsNullOrEmpty(ddlFuenteFinanciamiento) || ddlFuenteFinanciamiento=="-1")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warningCompras').text('Por favor revise los campos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else if (count > 0)
            {
                ControllerCompras vObjeto = new ControllerCompras();
                int result = vObjeto.CreaCompra(txtDescripcion.Text, dateRegistro, ddlGerenciaSolicitante, ddlFuenteFinanciamiento, tasa_ufv, tasa_dolar, txtNroFactura.Text, txtDocRespaldo.Text, ddlProveedor);
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
                    int resultComite = vObjetoComite.CreaComiteRecepcionPorCompra(ListComiteRecepcion);
                    if (resultComite > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#successCompras').text('Compra Realizada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

                        Response.Redirect("RegistroActivosPorCompras.aspx?codigoCompra=" + result + " &descripcion= " + txtDescripcion.Text.Trim() + " &idFuenteFinanciamiento="+ddlFuenteFinanciamiento+" &fuenteFinanciamiento=" + nombreFuenteFinanciamiento + " &fechaRegistro= " + dateRegistro + " &tasaUFV=" + tasa_ufv + " &tasaSus=" + tasa_dolar + " &nroFactura=" + txtNroFactura.Text + " &idGerenciaSolicitante=" + ddlGerenciaSolicitante + " &docRespaldo=" + txtDocRespaldo.Text + " &idProveedor=" + ddlProveedor + " &proveedor=" + nombreProveedor + " &gerenciaSolicitante=" + nombreSolicitante + ""); 
                    
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#dangerCompras').text('Lo sentimos hubo un problema al registrar el comite de recepción').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#dangerCompras').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warningCompras').text('Debe seleccionar al menos una persona como comite de recepción').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }
        /// <summary>
        /// Vuelve a la lista de compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            div_Listacompras.Visible = true;
            div_RegistroCompras.Visible = false;
            div_comiteCompras.Visible = false;
        }
        /// <summary>
        /// Registra los activos de una compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistrarActivos_Click(object sender, EventArgs e)
        {
            if (gridCompras.FocusedRowIndex > -1)
            {
                var fila = this.gridCompras.GetRow(gridCompras.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string descripcion= ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                string fechaRegistro = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                string idgerenciaSolicitante = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                string gerenciaSolicitante = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                string TasaSus = ((System.Data.DataRowView)(fila)).Row.ItemArray[8].ToString();
                string TasaUFV = ((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString();
                string factura = ((System.Data.DataRowView)(fila)).Row.ItemArray[10].ToString();
                string doc_respaldo = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();
                string idproveedor = ((System.Data.DataRowView)(fila)).Row.ItemArray[12].ToString();
                string proveedor = ((System.Data.DataRowView)(fila)).Row.ItemArray[13].ToString();
                string fkc_estado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();
                string idFuenteFinanciamiento = ((System.Data.DataRowView)(fila)).Row.ItemArray[17].ToString();
                string fuenteFinanciamiento = ((System.Data.DataRowView)(fila)).Row.ItemArray[18].ToString();
                Response.Redirect("RegistroActivosPorCompras.aspx?codigoCompra=" + id + " &descripcion= " + descripcion + " &idFuenteFinanciamiento="+idFuenteFinanciamiento+" &fuenteFinanciamiento="+fuenteFinanciamiento+" &fechaRegistro= " + fechaRegistro + " &tasaUFV=" + TasaUFV + " &tasaSus="+TasaSus+" &nroFactura=" + factura + " &gerenciaSolicitante=" + gerenciaSolicitante + " &docRespaldo=" + doc_respaldo + " &proveedor=" + proveedor + " &idProveedor="+idproveedor+" &idGerenciaSolicitante="+idgerenciaSolicitante+" &idEstadoProceso="+fkc_estado_proceso+""); 
            }
        }

        protected void gridCompras_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado_proceso");
            if (value == "APROBADO")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#5882FA");
                e.Row.ForeColor = Color.White;
            }
        }
        /// <summary>
        /// Aprueba una compra Elaborado a Aprobado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAprobarCompra_Click(object sender, EventArgs e)
        {
            if (gridCompras.FocusedRowIndex > -1)
            {
                var fila = this.gridCompras.GetRow(gridCompras.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();
                string f_registro = gridCompras.GetRowValues(gridCompras.FocusedRowIndex, "f_registro").ToString();
                //Estado 4 estado elaborado
                 if (idEstado_proceso == "4")
                 {
                     ControllerCompras vObjeto = new ControllerCompras();
                     int result = vObjeto.ApruebaCompra(id,f_registro);
                     if (result == 1)
                     {
                         ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Compra aprobada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                         cargarGrillaCompras();
                     }
                 }
                 else
                     ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('No puede aprobar una compra ya aprobada').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
           
        }
        /// <summary>
        /// Elimina una compra en estado elaborado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminarCompra_Click(object sender, EventArgs e)
        {
            if (gridCompras.FocusedRowIndex > -1)
            {
                var fila = this.gridCompras.GetRow(gridCompras.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();
                //Estado 4 estado elaborado
                if (idEstado_proceso == "4") 
                {
                    ControllerCompras vObjeto = new ControllerCompras();
                    int result=vObjeto.EliminaCompra(id);
                    if (result > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Registro eliminado con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaCompras();
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroDanger').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('No puede eliminar una compra en estado aprobado').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void gridCompras_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs e)
        {
            //if (e.Column.FieldName == "monto_bs")
            //{
            //    decimal valor_inicial = (decimal)e.GetListSourceFieldValue("monto_inicial_bs");
            //    e.Value = valor_inicial;
            //    e.Value = string.Format("$us {0:0,0.00}", (decimal)e.Value);
            //}
            //if (e.Column.FieldName == "monto_ufv")
            //{
            //    decimal valor_inicial_ufv = (decimal)e.GetListSourceFieldValue("monto_inicial_ufv");
            //    e.Value = valor_inicial_ufv;
            //}
            //if (e.Column.FieldName == "monto_sus")
            //{
            //    decimal valor_inicial_sus = (decimal)e.GetListSourceFieldValue("monto_inicial_sus");
            //    e.Value = valor_inicial_sus;
            //}
        }
      
        protected void gridCompras_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            //if (e.Column.FieldName == "monto_bs")
            //{
            //    e.Editor.Value = string.Format("$us {0:0,0.00}", (decimal)e.Value);
            //}
        }

        protected void gridCompras_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "costo")
            {
                e.Cell.Text = string.Format("Bs. {0:0,0.00}", Convert.ToDecimal(e.CellValue));

                //e.Cell.ForeColor = Color.Red;
            }
            if (e.DataColumn.FieldName == "gastos_con_credito_fiscal")
            {
                e.Cell.Text = string.Format("Bs. {0:0,0.00}", Convert.ToDecimal(e.CellValue));

                //e.Cell.ForeColor = Color.Red;
            }
            if (e.DataColumn.FieldName == "gastos_sin_credito_fiscal")
            {
                e.Cell.Text = string.Format("Bs. {0:0,0.00}", Convert.ToDecimal(e.CellValue));

                //e.Cell.ForeColor = Color.Red;
            }
            
            if (e.DataColumn.FieldName == "monto_bs")
            {
                e.Cell.Text = string.Format("Bs. {0:0,0.00}", Convert.ToDecimal(e.CellValue));

                //e.Cell.ForeColor = Color.Red;
            }
            if (e.DataColumn.FieldName == "monto_ufv")
            {
                e.Cell.Text = string.Format("UFV. {0:0,0.0000}", Convert.ToDecimal(e.CellValue));

                //e.Cell.ForeColor = Color.Red;
            }
            if (e.DataColumn.FieldName == "monto_sus")
            {
                e.Cell.Text = string.Format("$us. {0:0,0.00}", Convert.ToDecimal(e.CellValue));

                //e.Cell.ForeColor = Color.Red;
            }
        }

        protected void btnAprobarReserva_Click(object sender, EventArgs e)
        {
            if (gridCompras.FocusedRowIndex > -1)
            {
                var fila = this.gridCompras.GetRow(gridCompras.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();
                string f_registro = gridCompras.GetRowValues(gridCompras.FocusedRowIndex, "f_registro").ToString();
                //Estado 4 estado elaborado
                if (idEstado_proceso == "4")
                {
                    ControllerCompras vObjeto = new ControllerCompras();
                    int result = vObjeto.ApruebaCompra(id, f_registro,ddlReservas.SelectedItem.Value);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Compra aprobada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaCompras();
                        cargarComboReservas();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('No puede aprobar una compra ya aprobada').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }
    }
}