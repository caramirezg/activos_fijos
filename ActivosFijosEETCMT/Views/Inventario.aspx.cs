using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Data;
using System.Drawing;
using ActivosFijos.Models;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class Inventario : System.Web.UI.Page
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
                this.txtCodigo.Focus();

                if (!Page.IsPostBack)
                {
                    lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    div_inventarioMaestro.Visible = true;
                    div_inventarioDetalle.Visible = false;
                    _divNuevoMaestroInventario.Visible = false;
                    cargarComboEstadosActivo();
                    _armarMenu();
                }


                if (div_inventarioDetalle.Visible == true)
                {
                    cargaGrillaDetalle();
                    cargaGrillaFaltantes();
                }
                else
                {
                    cargaGrilla();
                    cargarGrillaPersonal();
                }

            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }
             
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


        private void cargarComboEstadosActivo()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            string tipo_clasificador = "2";//clasificador estado fisico de un activo 
            ddlEstadoFisicoActivo.DataSource = controllerHelper.ToDataTable(vObjeto.DatosClasificadoresByIDTipo(tipo_clasificador));
            ddlEstadoFisicoActivo.DataValueField = "id";
            ddlEstadoFisicoActivo.DataTextField = "nombre";
            ddlEstadoFisicoActivo.DataBind();
        }

        private void cargaGrilla()
        {
            ControllerInventario vObjeto = new ControllerInventario();
            ControllerHelper vHelper = new ControllerHelper();
            gridInventarioMaestro.DataSource = vHelper.ToDataTable(vObjeto.DatosMaestroInventario());
            gridInventarioMaestro.KeyFieldName = "id";
            gridInventarioMaestro.DataBind();
        }

        private void cargaGrillaDetalle()
        {
            ControllerInventario vObjeto = new ControllerInventario();
            ControllerHelper vHelper = new ControllerHelper();
            gridInventarioDetalle.DataSource = vObjeto.DatosinventarioDetalle(txtIdInventarioMaestro.Text);
            gridInventarioDetalle.KeyFieldName = "id";
            gridInventarioDetalle.DataBind();
        }

        private void cargaGrillaFaltantes()
        {
            ControllerInventario vObjeto = new ControllerInventario();
            ControllerHelper vHelper = new ControllerHelper();
            gridInventarioFaltante.DataSource = vObjeto.DatosinventarioFaltante(txtIdInventarioMaestro.Text);
            gridInventarioFaltante.KeyFieldName = "id";
            gridInventarioFaltante.DataBind();
        }

        protected void btnGuardarInventarioMaestro_Click(object sender, EventArgs e)
        {
            gridPersonal.FilterExpression="";

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


            if (count > 0)
            {
               
                string fecha = Request.Form["txtMaestroFecha"];
                ControllerInventario vObjeto = new ControllerInventario();
                int result = vObjeto.CreaInventario(txtMaestroDescripcion.Text, fecha,txtMaestroDocumentoRespaldo.Text);
                if (result > 0)
                {

                    int i = 0;
                    List<ComiteInventarioEntity> ListComiteInventario = new List<ComiteInventarioEntity>();
                    while (i <= gridPersonal.VisibleRowCount)
                    {
                        if (this.gridPersonal.Selection.IsRowSelected(i))
                        {
                            ///insertamos datos si la fila está seleccionada
                            ListComiteInventario.Add(new ComiteInventarioEntity(int.Parse(this.gridPersonal.GetRowValues(i, "id").ToString()), result));
                        }
                        i = i + 1;
                    }


                    ControllerComiteInventario vObjetoComite = new ControllerComiteInventario();
                    int resultComite = vObjetoComite.CreaComiteInvenario(ListComiteInventario);
                    if (resultComite > 0)
                    {
                       
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#successMaestro').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        div_inventarioMaestro.Visible = false;
                        div_inventarioDetalle.Visible = true;
                        _divNuevoMaestroInventario.Visible = false;


                        txtIdInventarioMaestro.Text = result.ToString();
                        txtDescripcionInventario.Text = txtMaestroDescripcion.Text;
                        txtFechaInventario.Text = Request.Form["txtMaestroFecha"];
                        txtDocumentoRespaldo.Text = txtMaestroDocumentoRespaldo.Text;

                        cargaGrillaDetalle();
                        cargaGrillaFaltantes();
                       

                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#dangerMaestro').text('Lo sentimos hubo un problema al registrar la comisión de inventario').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#dangerMaestro').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else
            { 
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warningCompras').text('Debe seleccionar al menos una persona como comite para el inventario').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnVerInventario_Click(object sender, EventArgs e)
        {
            
            
            var fila = this.gridInventarioMaestro.GetRow(gridInventarioMaestro.FocusedRowIndex);
            txtIdInventarioMaestro.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
            txtDescripcionInventario.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
            txtFechaInventario.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
            txtDocumentoRespaldo.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
            

            div_inventarioMaestro.Visible = false;
            div_inventarioDetalle.Visible = true;
            cargaGrillaDetalle();
            cargaGrillaFaltantes();

            if (((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString() == "14")//14 clasificador inventario cerrado
                _divInventariar.Visible = false;
            else
                _divInventariar.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            DataTable dtActivo = new DataTable();
            ControllerInventario vObjeto = new ControllerInventario();
            dtActivo=vObjeto.get_inventarioDetalleByCodigo(txtCodigo.Text);
            if (dtActivo.Rows.Count == 1)
            {
                txtDescripcion.Text = dtActivo.Rows[0][1].ToString();
                txtDocumento.Text = dtActivo.Rows[0][2].ToString();
                txtNombres.Text = dtActivo.Rows[0][3].ToString();
                txtApellidos.Text = dtActivo.Rows[0][4].ToString();
                txtArea.Text = dtActivo.Rows[0][5].ToString();
                txtGerencia.Text = dtActivo.Rows[0][6].ToString();
                txtEstadoOriginal.Text = dtActivo.Rows[0][8].ToString();
                if (!string.IsNullOrEmpty(dtActivo.Rows[0][7].ToString()))
                ddlEstadoFisicoActivo.SelectedValue = dtActivo.Rows[0][7].ToString();
                
            }
        }

        private void LimpiarDetalle()
        {
            txtDescripcion.Text = "";
            txtDocumento.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtGerencia.Text = "";
            txtArea.Text = "";
            txtEstadoOriginal.Text = "";
            txtObservaciones.Text = "";
            txtCodigo.Text = "";
        }

        protected void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            guardarDetalle( sender,1);
        }

        public void guardarDetalle(object sender,int tipo_validacion)
        {

            ControllerInventario vObjeto = new ControllerInventario();
            ControllerActivos vActivo = new ControllerActivos();

            int validaCodigo = vActivo.validaExistenciaActivo(txtCodigo.Text);
            if (validaCodigo > 0)
            {

                int validaExistencia = vObjeto.ValidaActivoControlado(txtCodigo.Text, txtIdInventarioMaestro.Text);
                if (validaExistencia < 1)
                {
                    int result = vObjeto.CreaDetalleInventario(txtIdInventarioMaestro.Text, txtCodigo.Text, ddlEstadoFisicoActivo.SelectedValue, txtObservaciones.Text,tipo_validacion);
                    if (result > 0)
                    {
                        cargaGrillaDetalle();
                        cargaGrillaFaltantes();
                        LimpiarDetalle();

                        string message = "$('#successDetalle').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    else
                    {
                        string message = "$('#dangerDetalle').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "$('#warningDetalle').text('El registro ya fue registrado anteriormente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                }
            }
            else
            {
                string message = "$('#warningDetalle').text('El codigo introducido no existe').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }

        protected void btnGenerarReporteInventario_Click(object sender, EventArgs e)
        {
            string tipo_reporte="verificado";
            Response.Write("<script>window.open('reportes/ReporteInventario.aspx?fk_inventario_maestro=" + txtIdInventarioMaestro.Text + " &tipo_reporte=" + tipo_reporte + "','_blank');</script>");
        }

        protected void btnMaestrosInventario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventario.aspx");
        }

        protected void btnCerrarInventario_Click(object sender, EventArgs e)
        {
            if (gridInventarioMaestro.FocusedRowIndex > -1)
            {
                string fechaConclusion = Request.Form["txtFechaConclusion"].ToString();
                if (!string.IsNullOrEmpty(fechaConclusion))
                {
                    var fila = this.gridInventarioMaestro.GetRow(gridInventarioMaestro.FocusedRowIndex);

                    ControllerInventario vObjeto = new ControllerInventario();
                    if (((System.Data.DataRowView)(fila)).Row.ItemArray[6].ToString().Equals("01/01/1900"))
                    {
                        int result = vObjeto.CerrarInventario(((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString(), fechaConclusion);
                        if (result > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#successMaestro').text('Inventario cerrado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                            cargaGrilla();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#dangerMaestro').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

                        }
                    }else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warningMaestro').text('El inventario ya fue cerrado').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warningMaestro').text('Debe seleccionar una fecha de conclusión').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                    
            }
        }

        protected void gridInventarioMaestro_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado_inventario");
            if (value == "INVENTARIO CERRADO")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#5882FA");
                e.Row.ForeColor = Color.White;
            }
        }

        protected void btnNuevoInventario_Click(object sender, EventArgs e)
        {
            div_inventarioMaestro.Visible = false;
            div_inventarioDetalle.Visible = false;
            _divNuevoMaestroInventario.Visible = true;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            div_inventarioMaestro.Visible = true;
            div_inventarioDetalle.Visible = false;
            _divNuevoMaestroInventario.Visible = false;
        }

        protected void btnGenerarReporteSinVerificar_Click(object sender, EventArgs e)
        {
            string tipo_reporte = "no_verificado";
            Response.Write("<script>window.open('reportes/ReporteInventario.aspx?fk_inventario_maestro=" + txtIdInventarioMaestro.Text + " &tipo_reporte="+tipo_reporte+"','_blank');</script>");
        }

        protected void btnGuardarRegistroNoFisico_Click(object sender, EventArgs e)
        {
            guardarDetalle(sender, 0);
        }

        protected void gridPersonal_DataBound(object sender, EventArgs e)
        {
            //if (!gridPersonal.IsCallback && gridPersonal.VisibleRowCount == 1)
                
        }

        protected void gridInventarioMaestro_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "f_conclusion")
            {
                if (e.CellValue.Equals("01/01/1900"))
                e.Cell.Text = "SIN CONCLUIR";

                //e.Cell.ForeColor = Color.Red;
            }
        }
             
    }
}