using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using iTextSharp.text.pdf;
using System.Security;
using System.Security.Permissions;
using System.IO;
using ActivosFijos.Models;
using System.Data;
using System.Text;

[assembly: AllowPartiallyTrustedCallers]

namespace ActivosFijosEETC.Views
{
    public partial class RegistroActivosPorCompras : System.Web.UI.Page
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
                    txtCodigoCompra.Text = Request.QueryString["codigoCompra"];
                    txtDescripcion.Text = Request.QueryString["descripcion"];

                    txtFechaRegistro.Text = Request.QueryString["fechaRegistro"];
                    txtTasaUFV.Text = Request.QueryString["tasaUFV"].Replace(".", ",");
                    txtTasaSus.Text = Request.QueryString["tasaSus"].Replace(".", ",");
                    txtNroFactura.Text = Request.QueryString["nroFactura"];
                    txtGerenciaSolicitante.Text = Request.QueryString["gerenciaSolicitante"];

                    txtDocRespaldo.Text = Request.QueryString["docRespaldo"];

                    txtProveedor.Text = Request.QueryString["proveedor"];

                    txtIdGerenciaSolicitante.Text = Request.QueryString["idGerenciaSolicitante"];
                    txtIdProveedor.Text = Request.QueryString["idProveedor"];

                    txtIdFuenteFinanciamiento.Text = Request.QueryString["idFuenteFinanciamiento"];
                    txtFuenteFinanciamiento.Text = Request.QueryString["fuenteFinanciamiento"];
                    //Clasificadores estado 5 = ESTADO APROBADO
                    if (Request.QueryString["idEstadoProceso"] == "5")
                    {
                        actionActivos.Visible = false;
                        idBarCode.Visible = true;
                    }
                    else
                    {
                        actionActivos.Visible = true;
                        idBarCode.Visible = false;
                    }


                    cargarComboGruposContables();
                    cargarComboMarcas();
                }
                cargarActivosPorCompra();
            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }


            //validate numeric

            string validate1 = "$('#txtValorInicial').numeric();";
            string validate2 = "$('#txtGastosConCreditoFiscal').numeric();";
            string validate3 = "$('#txtGastosSinCreditoFiscal').numeric();";
            string validate4 = "$('#txtVidaUtilEspecifica').numeric(false);";
            string validate5 = "$('#txtEditaCosto').numeric();";
            string validate6 = "$('#txtEditaGastosConCreditoFiscal').numeric();";
            string validate7 = "$('#txtEditaGastosSinCreditoFiscal').numeric();";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "validate1", validate1, true);
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "validate2", validate2, true);
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "validate3", validate3, true);
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "validate4", validate4, true);
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "validate5", validate5, true);
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "validate6", validate6, true);
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "validate7", validate7, true);

            
   


        }
        /// <summary>
        /// Carga el combo de marcas
        /// </summary>
        private void cargarComboMarcas()
        {
            ControllerMarcas vObjeto = new ControllerMarcas();
            ddlMarca.DataSource = controllerHelper.ToDataTable(vObjeto.DatosMarcas());
            ddlMarca.DataValueField = "ID";
            ddlMarca.DataTextField = "nombre";
            ddlMarca.DataBind();
        }
        /// <summary>
        /// Carga el combo de grupos contables
        /// </summary>
        private void cargarComboGruposContables()
        {
            ControllerGruposContables vObjeto = new ControllerGruposContables();
            ddlGrupoContable.DataSource = controllerHelper.ToDataTable(vObjeto.DatosGruposContables());
            ddlGrupoContable.DataValueField = "ID";
            ddlGrupoContable.DataTextField = "descripcion";
            ddlGrupoContable.DataBind();
        }
        /// <summary>
        /// Registra un activo fijo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistrarActivo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVidaUtilEspecifica.Text))
            {
                guardarActivo(sender, e);
            }
            else
            {
                 ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert","modalConfirmSave()", true);
            }
        }

        private void guardarActivo(object sender, EventArgs e)
        {
         ControllerActivos vObjeto = new ControllerActivos();

                string fk_auxiliar_contable = Request.Form["ddlAuxiliarContable"];
                string fk_modelo = Request.Form["ddlModelo"];
                string serie = txtSerie.Text;
                string descripcion = txtDescripcionActivo.Text;
                string f_registro = txtFechaRegistro.Text;
                string valor_inicial = txtValorInicial.Text.Replace(".", ",");
                string valor_actual = txtValorInicial.Text.Replace(".", ","); ;//obtiene el mismo valor inicial
                string gasto_con_credito_fiscal = txtGastosConCreditoFiscal.Text.Replace(".", ",");
                string gasto_sin_credito_fiscal = txtGastosSinCreditoFiscal.Text.Replace(".", ",");
                string fk_compra = txtCodigoCompra.Text;
                string fk_proveedor = txtIdProveedor.Text;
                string fk_fuente_financiamiento = txtIdFuenteFinanciamiento.Text;
                string fkc_tipo_adquisicion = "1";//COMPRA DIRECTA
                string tasa_ufv = txtTasaUFV.Text;
                string tasa_sus = txtTasaSus.Text;

                string f_inicio_garantia = Request.Form["dateInicioGarantia"];
                string f_fin_garantia = Request.Form["dateFinGarantia"];

                string vida_util_alterna=null;
                if (!string.IsNullOrEmpty(txtVidaUtilEspecifica.Text))
                    vida_util_alterna = txtVidaUtilEspecifica.Text;

                int result = vObjeto.CreaActivoPorCompra(fk_fuente_financiamiento, fk_auxiliar_contable, fk_modelo, serie, descripcion, f_registro, valor_inicial, valor_actual, fk_compra, fk_proveedor, fkc_tipo_adquisicion, tasa_ufv, tasa_sus, gasto_con_credito_fiscal, gasto_sin_credito_fiscal, f_inicio_garantia, f_fin_garantia,vida_util_alterna);
                if (result > 0)
                {
                    string message = "$('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    limpiaCamposActivo();
                }
                else
                {
                    string message = "$('#danger').text('Lo Sentimos Hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo Sentimos Hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

                }
                cargarActivosPorCompra();
        }


        /// <summary>
        /// Limpia los campos del activo registrado
        /// </summary>
        private void limpiaCamposActivo()
        {
            txtDescripcionActivo.Text = "";
            ddlGrupoContable.SelectedIndex = -1;
            ddlAuxiliarContable.SelectedIndex = -1;
            ddlMarca.SelectedIndex = -1;
            ddlModelo.SelectedIndex = -1;
            txtSerie.Text="";
            txtValorInicial.Text="";
            txtGastosConCreditoFiscal.Text = "0";
            txtGastosSinCreditoFiscal.Text = "0";
            dateInicioGarantia.Value = "";
            dateFinGarantia.Value = "";
        }
        /// <summary>
        /// Carga el combop de auxiliares contables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlGrupoContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idGrupoContable = ddlGrupoContable.SelectedItem.Value.ToString();
            cargaAuxiliaresContables(idGrupoContable);
        }

        public void cargaAuxiliaresContables(string idGrupoContable)
        {
            ddlAuxiliarContable.Items.Clear();
            ddlAuxiliarContable.Items.Add(new ListItem("Seleccione un item", "-1"));

            ControllerAuxiliaresContables vObjeto = new ControllerAuxiliaresContables();
            ddlAuxiliarContable.DataSource = controllerHelper.ToDataTable(vObjeto.DatosAuxiliaresContables(idGrupoContable));
            ddlAuxiliarContable.DataValueField = "ID";
            ddlAuxiliarContable.DataTextField = "nombre";
            ddlAuxiliarContable.DataBind();
        
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idMarca = ddlMarca.SelectedItem.Value.ToString();
            cargaModelos(idMarca);
        }

        public void cargaModelos(string idMarca)
        {
            ddlModelo.Items.Clear();
            ddlModelo.Items.Add(new ListItem("Seleccione un item", "-1"));
            ControllerModelos vObjeto = new ControllerModelos();
            ddlModelo.DataSource = controllerHelper.ToDataTable(vObjeto.DatosModelos(idMarca));
            ddlModelo.DataValueField = "ID";
            ddlModelo.DataTextField = "nombre";
            ddlModelo.DataBind();
        }

        private void cargarActivosPorCompra()
        {
            ControllerActivos vObjeto = new ControllerActivos();
            GridActivosPorCompra.DataSource = controllerHelper.ToDataTable(vObjeto.DatosActivosPorCompra( txtCodigoCompra.Text));
            GridActivosPorCompra.DataBind();
        }
        /// <summary>
        /// Duplica un activo seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDuplicarActivo_Click(object sender, EventArgs e)
        {
            if (GridActivosPorCompra.FocusedRowIndex > -1)
            {
                var fila = this.GridActivosPorCompra.GetRow(GridActivosPorCompra.FocusedRowIndex);
                ddlGrupoContable.SelectedValue= ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                cargaAuxiliaresContables(((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString());
                ddlAuxiliarContable.SelectedValue = ((System.Data.DataRowView)(fila)).Row.ItemArray[6].ToString();
                ddlMarca.SelectedValue = ((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString();
                cargaModelos(((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString());
                ddlModelo.SelectedValue = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();
                txtSerie.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[13].ToString();
                txtDescripcionActivo.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();

                string valor_inicial = ((System.Data.DataRowView)(fila)).Row.ItemArray[46].ToString(); ;
                decimal numero;
                decimal.TryParse(valor_inicial, out numero);

                numero = decimal.Round(numero, 2);
                txtValorInicial.Text = numero.ToString();

                txtGastosConCreditoFiscal.Text = GridActivosPorCompra.GetRowValues(GridActivosPorCompra.FocusedRowIndex, "gastos_con_credito_fiscal").ToString();
                txtGastosSinCreditoFiscal.Text = GridActivosPorCompra.GetRowValues(GridActivosPorCompra.FocusedRowIndex, "gastos_sin_credito_fiscal").ToString();
                this.dateInicioGarantia.Value = ((System.Data.DataRowView)(fila)).Row.ItemArray[33].ToString();
                this.dateFinGarantia.Value = ((System.Data.DataRowView)(fila)).Row.ItemArray[34].ToString();
                txtVidaUtilEspecifica.Text = GridActivosPorCompra.GetRowValues(GridActivosPorCompra.FocusedRowIndex, "vida_util_alterna").ToString();
                txtValorInicialCalculado.Text = GridActivosPorCompra.GetRowValues(GridActivosPorCompra.FocusedRowIndex, "valor_inicial").ToString();
            }
        }
        /// <summary>
        /// Muestra el formulario de lista de compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("compras.aspx");
        }
        /// <summary>
        /// Elimina un registro de activo actualizando montos en compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var fila = this.GridActivosPorCompra.GetRow(GridActivosPorCompra.FocusedRowIndex);
            string idActivo = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

            //string valor_inicial = ((System.Data.DataRowView)(fila)).Row.ItemArray[22].ToString();
            string idCompra=txtCodigoCompra.Text;
            //string valor_inicial_ufv = ((System.Data.DataRowView)(fila)).Row.ItemArray[24].ToString();
            //string valor_inicial_sus = ((System.Data.DataRowView)(fila)).Row.ItemArray[26].ToString();
            string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[18].ToString();
            //Estado 4 estado elaborado
            if (idEstado_proceso == "4")
            {
                ControllerActivos vObjeto = new ControllerActivos();
                int result = vObjeto.EliminaActivoPorCompra(idActivo);
                if (result > 0)
                {
                    string message = "$('#success').text('Registro Eliminado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro Eliminado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline }); </script>");
                }
                else
                {
                    string message = "$('#danger').text('Lo Sentimos Hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo Sentimos Hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                    cargarActivosPorCompra();
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('No puede eliminar un activo en estado aprobado').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
           
        }
        /// <summary>
        /// Imprime el informe de compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            //Response.Redirect("reportes/ReporteCompra.aspx?idCompra=" + txtCodigoCompra.Text + "");
            Response.Write("<script>window.open('reportes/ReporteCompra.aspx?idCompra=" + txtCodigoCompra.Text + "','_blank');</script>");
        }
        /// <summary>
        /// Imprime codigo de barras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            if (GridActivosPorCompra.FocusedRowIndex > -1)
            {
                var fila = this.GridActivosPorCompra.GetRow(GridActivosPorCompra.FocusedRowIndex);

                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(160, 80), 10, 10, 10, 0);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();


                 PdfContentByte cb1 = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                cb1.SetFontAndSize(bf, 6);
                cb1.BeginText();
                cb1.SetTextMatrix(6, 65);
                cb1.ShowText("Empresa Estatal de Transporte Por Cable 'Mi Teleferico'");
                cb1.EndText();

                iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                bc.TextAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                bc.Code = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                bc.StartStopText = false;
                bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                bc.Extended = true;

                iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                      iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

                cb.SetTextMatrix(2f, 3.0f);
                img.ScaleToFit(200, 54);
                img.SetAbsolutePosition(8, 6);
                img.WidthPercentage = 10;
                cb.AddImage(img);

           

            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" +
                                           "filename=barcode.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

            }
        }

        protected void GridActivosPorCompra_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "valor_inicial")
            {
                decimal valor_inicial = (decimal)e.GetListSourceFieldValue("valor_inicial");

                e.Value = valor_inicial;
            }
        }

        protected void GridActivosPorCompra_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "costo")
            {
                e.Cell.Text = string.Format("Bs. {0:0,0.00}", Convert.ToDecimal(e.CellValue));
            }
            if (e.DataColumn.FieldName == "gastos_con_credito_fiscal")
            {
                e.Cell.Text = string.Format("Bs. {0:0,0.00}", Convert.ToDecimal(e.CellValue));
            }
            if (e.DataColumn.FieldName == "gastos_sin_credito_fiscal")
            {
                e.Cell.Text = string.Format("Bs. {0:0,0.00}", Convert.ToDecimal(e.CellValue));
            }

            if (e.DataColumn.FieldName == "valor_inicial")
            {
                e.Cell.Text = string.Format("Bs. {0:0,0.00}", Convert.ToDecimal(e.CellValue));
            }
           
        }
        /// <summary>
        /// Imprime codigos de barra de toda la compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrintBarcodeAll_Click(object sender, EventArgs e)
        {

            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(160, 80), 10, 10, 10, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            int i = 0;
            while (i < GridActivosPorCompra.VisibleRowCount)
            {
                if (i != 0)
                    pdfDoc.NewPage();

                PdfContentByte cb1 = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                cb1.SetFontAndSize(bf, 6);
                cb1.BeginText();
                cb1.SetTextMatrix(6, 65);
                cb1.ShowText("Empresa Estatal de Transporte Por Cable 'Mi Teleferico'");
                cb1.EndText();

                iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                bc.TextAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                bc.Code = this.GridActivosPorCompra.GetRowValues(i, "codigo").ToString();
                bc.StartStopText = false;
                bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                bc.Extended = true;

                iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                      iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

                cb.SetTextMatrix(2f, 3.0f);
                img.ScaleToFit(200, 54);
                img.SetAbsolutePosition(8, 6);
                img.WidthPercentage = 10;
                cb.AddImage(img);

                i = i + 1;
            }

            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" +
                                           "filename=barcode.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (GridActivosPorCompra.FocusedRowIndex > -1)
            {
                var fila = this.GridActivosPorCompra.GetRow(GridActivosPorCompra.FocusedRowIndex);

                string id=((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string codigo=((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                string descripcion = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();

                txtEditaId.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                txtEditaCodigo.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
       
                txtEditaDescripcion.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();
                cargarComboEditaMarcas();
                ddlEditaMarca.SelectedValue = ((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString();
                cargaComboEditaModelo(ddlEditaMarca.SelectedValue);
                ddlEditaModelo.SelectedValue = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();
                txtEditaSerie.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[13].ToString();
                txtEditaCosto.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[46].ToString();
                txtEditaGastosConCreditoFiscal.Text = GridActivosPorCompra.GetRowValues(GridActivosPorCompra.FocusedRowIndex, "gastos_con_credito_fiscal").ToString();
                txtEditaGastosSinCreditoFiscal.Text = GridActivosPorCompra.GetRowValues(GridActivosPorCompra.FocusedRowIndex, "gastos_sin_credito_fiscal").ToString();
                txtEditaValorInicialCalculado.Text = GridActivosPorCompra.GetRowValues(GridActivosPorCompra.FocusedRowIndex, "valor_inicial").ToString();
                this.txtEditaInicioGarantia.Value= ((System.Data.DataRowView)(fila)).Row.ItemArray[33].ToString();
                this.txtEditaFinGarantia.Value=((System.Data.DataRowView)(fila)).Row.ItemArray[34].ToString();

                string message = "modalEditaCompra();";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "mostrarPopup", message, true);

            }
        }

        private void cargarComboEditaMarcas()
        {
            ControllerMarcas vObjeto = new ControllerMarcas();
            ddlEditaMarca.DataSource = controllerHelper.ToDataTable(vObjeto.DatosMarcas());
            ddlEditaMarca.DataValueField = "ID";
            ddlEditaMarca.DataTextField = "nombre";
            ddlEditaMarca.DataBind();
        }

        protected void ddlEditaMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idMarca = ddlEditaMarca.SelectedItem.Value;
            cargaComboEditaModelo(idMarca);

          
        }

        private void cargaComboEditaModelo(string idMarca)
        {
            ddlEditaModelo.Items.Clear();
            ddlEditaModelo.Items.Add(new ListItem("Seleccione un item", "-1"));
            ControllerModelos vObjeto = new ControllerModelos();
            ddlEditaModelo.DataSource = controllerHelper.ToDataTable(vObjeto.DatosModelos(idMarca));
            ddlEditaModelo.DataValueField = "ID";
            ddlEditaModelo.DataTextField = "nombre";
            ddlEditaModelo.DataBind();
        }

        protected void btnGuardarEditActivo_Click(object sender, EventArgs e)
        {
            ControllerActivos vObjeto = new ControllerActivos();

            string id_activo = txtEditaId.Text;
            string fk_compra=txtCodigoCompra.Text;
            string descripcion=txtEditaDescripcion.Text;
            string marca=ddlEditaMarca.SelectedValue;
            string modelo=ddlEditaModelo.SelectedValue;
            string serie=txtEditaSerie.Text;
            string costo_bs = txtEditaCosto.Text.Replace(".", ",");
            string gastos_con_credito_fiscal = txtEditaGastosConCreditoFiscal.Text.Replace(".", ",");
            string gastos_sin_credito_fiscal = txtEditaGastosSinCreditoFiscal.Text.Replace(".", ",");
            string f_inicio_garantia=Request.Form["txtEditaInicioGarantia"];
            string f_fin_garantia=Request.Form["txtEditaFinGarantia"];

            int result = vObjeto.ModificaActivoCompras(id_activo,fk_compra, descripcion, marca, modelo, serie, costo_bs, gastos_con_credito_fiscal, gastos_sin_credito_fiscal, f_inicio_garantia, f_fin_garantia);
            if (result > 0)
            {

                string message = "$('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                limpiaCamposActivo();

            }
            else
            {
                string message = "$('#danger').text('Lo Sentimos Hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            }
            string close = "$('#modalEditaCompra').modal('hide');";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "mostrarPopup", close, true);
            cargarActivosPorCompra();
        }

        protected void btnContinuarGuardar_Click(object sender, EventArgs e)
        {
            guardarActivo(sender, e);
            string close = "$('#modalSaveConfirm').modal('hide');";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "modalConfirmSave", close, true);
        }

        
    }
}