using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using ActivosFijosEETC.Models;
using System.Data;
using CrystalDecisions.Shared;
using iTextSharp.text.pdf;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class RegistroActivosAsignadosPorTransferencia : System.Web.UI.Page
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
                     txtIdMaestroTransferencia.Text = Request.QueryString["codigoAsignacionPorTransferencia"].Trim();
                     fk_persona_origen.Text = Request.QueryString["fk_persona_origen"].Trim();
                     txtDocumentoOrigen.Text = Request.QueryString["documento_origen"].Trim();
                     txtNombresOrigen.Text = Request.QueryString["nombres_origen"].Trim();
                     txtApellidosOrigen.Text = Request.QueryString["apellidos_origen"].Trim();
                     txtGerenciaOrigen.Text = Request.QueryString["gerencia_origen"].Trim();

                     fk_persona_destino.Text = Request.QueryString["fk_persona_destino"].Trim();
                     txtDocumentoDestino.Text = Request.QueryString["documento_destino"].Trim();
                     txtNombresDestino.Text = Request.QueryString["nombres_destino"].Trim();
                     txtApellidosDestino.Text = Request.QueryString["apellidos_destino"].Trim();
                     txtGerenciaDestino.Text = Request.QueryString["gerencia_destino"].Trim();

                     txtMotivoTransferencia.Text = Request.QueryString["motivo"].Trim();
                     txtFkc_tipo_transferencia.Text = Request.QueryString["fkc_tipo_transferencia"].Trim();
                     txtTipoTransferencia.Text = Request.QueryString["tipo_transferencia"].Trim();

                     DateTime f_transferencia = DateTime.Parse(Request.QueryString["f_asignacion"].Trim());

                     DateTime fecha = DateTime.Parse(f_transferencia.ToString("dd/MM/yyyy"));
                     string convertido = String.Format("{0:dd/MM/yyyy}", fecha);
                     txtFechaAsignacionPorTransferencia.Text = convertido;
                     txtUbicacion.Text = Request.QueryString["ubicacion"].Trim();
                     txtLinea.Text = Request.QueryString["linea"].Trim();
                     txtEstacion.Text = Request.QueryString["estacion"].Trim();





                     //Clasificadores estado 17 = ESTADO TRANSFEREIDO
                     if (Request.QueryString["fkc_estado_proceso"].Trim() == "17")
                     {
                         btnTransferirActivo.Visible = false;
                         btnDevolverActivo.Visible = false;
                         //div_campos.Visible = false;
                         _print.Visible = true;
                         _action.Visible = false;
                         _activos_origen.Visible = false;
                         _activos_destino.Style.Add("width", "100%");

                     }
                     else
                     {
                         btnTransferirActivo.Visible = true;
                         btnDevolverActivo.Visible = true;
                         //div_campos.Visible = true;
                         _print.Visible = false;
                         _action.Visible = true;
                         _activos_origen.Visible = true;

                     }

                     cargarComboEstadosActivo();

                 }
                 cargarGrillaActivosAsignadosTransferidosOrigen();
                 cargarGrillaActivosTransferidosDestino();
             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }
        }

        /// <summary>
        /// Carga el combo de los estados fisicos de un activo
        /// </summary>
        private void cargarComboEstadosActivo()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            string tipo_clasificador = "2";//clasificador estado fisico de un activo 
            ddlEstadoFisicoActivo.DataSource = controllerHelper.ToDataTable(vObjeto.DatosClasificadoresByIDTipo(tipo_clasificador));
            ddlEstadoFisicoActivo.DataValueField = "id";
            ddlEstadoFisicoActivo.DataTextField = "nombre";
            ddlEstadoFisicoActivo.DataBind();
        }

        private void cargarGrillaActivosAsignadosTransferidosOrigen()
        {
            ControllerAsignacionesPorTransferencia vObjeto = new ControllerAsignacionesPorTransferencia();

            gridActivosOrigen.DataSource = vObjeto.DatosActivosAsignadosTransferidos(fk_persona_origen.Text);
            gridActivosOrigen.KeyFieldName = "id";
            gridActivosOrigen.DataBind();
        }

        private void cargarGrillaActivosTransferidosDestino()
        {
            ControllerAsignacionesPorTransferencia vObjeto = new ControllerAsignacionesPorTransferencia();

            gridActivosDestino.DataSource = vObjeto.DatosaActivosTransferidosPorIdMaestro(txtIdMaestroTransferencia.Text);
            gridActivosDestino.KeyFieldName = "id";
            gridActivosDestino.DataBind();
        }

        protected void btnTransferirActivo_Click(object sender, EventArgs e)
        {
            if (gridActivosOrigen.FocusedRowIndex > -1)
            {

                var filaOrigen = this.gridActivosOrigen.GetRow(gridActivosOrigen.FocusedRowIndex);
                string id_asignacion_transferencia_detalle = ((System.Data.DataRowView)(filaOrigen)).Row.ItemArray[2].ToString();
                string id_asignacion_detalle = ((System.Data.DataRowView)(filaOrigen)).Row.ItemArray[1].ToString();
                string fk_activo = ((System.Data.DataRowView)(filaOrigen)).Row.ItemArray[3].ToString();
                string tabla = ((System.Data.DataRowView)(filaOrigen)).Row.ItemArray[8].ToString();

                string fk_estado_activo = ddlEstadoFisicoActivo.SelectedItem.Value;
                string observaciones;
                if (!string.IsNullOrEmpty(txtObservaciones.Text))
                    observaciones = txtObservaciones.Text;
                else
                    observaciones = "SIN OBSERVACIONES";

                string fk_asignacion_por_transferencia_detalle = null;


                if (tabla.Equals("asignaciones_por_transferencias_detalle"))
                {
                    fk_asignacion_por_transferencia_detalle = id_asignacion_transferencia_detalle;
                }


                ControllerAsignacionesPorTransferencia vObjeto = new ControllerAsignacionesPorTransferencia();

                vObjeto.CreaDetalleAsignacionPorTransferencia(txtIdMaestroTransferencia.Text, fk_activo, fk_persona_origen.Text, fk_persona_destino.Text, fk_estado_activo, observaciones, id_asignacion_detalle, tabla, fk_asignacion_por_transferencia_detalle);
                cargarGrillaActivosAsignadosTransferidosOrigen();
                cargarGrillaActivosTransferidosDestino();
                txtObservaciones.Text = "";

            }
        }

        protected void btnDevolverActivo_Click(object sender, EventArgs e)
        {
            if (gridActivosDestino.FocusedRowIndex > -1)
            {
                var fila = this.gridActivosDestino.GetRow(gridActivosDestino.FocusedRowIndex);

                string idTransferencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();


                ControllerAsignacionesPorTransferencia vObjeto = new ControllerAsignacionesPorTransferencia();
                vObjeto.EliminaDetalleAsignacionTransferencia(idTransferencia);
                cargarGrillaActivosAsignadosTransferidosOrigen();
                cargarGrillaActivosTransferidosDestino();
            }
        }
        /// <summary>
        /// Vuelve al maestro de asignaciones por transferencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerAsignacionesPorTransferencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransferenciasInternas.aspx");
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('reportes/ReporteAsignacionPorTransferencia.aspx?idAsignacionPorTransferencia=" + txtIdMaestroTransferencia.Text + "','_blank');</script>");
        }

        DataSet DsetAsignacionesPorTransferencia = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ClaseAsignacionPorTransferenciaMaestro ReporteAsignacionTransferencia = new ClaseAsignacionPorTransferenciaMaestro();

            rep.Load(Server.MapPath("~/Views/reportes/RptAsignacionPorTransferencia.rpt"));

            DsetAsignacionesPorTransferencia = ReporteAsignacionTransferencia.ReporteAsignacionPorTransferenciaActivos(int.Parse(txtIdMaestroTransferencia.Text));
            rep.SetDataSource(DsetAsignacionesPorTransferencia);

            rep.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "Transferencias");
          
        }

        protected void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(160, 80), 10, 10, 10, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            int i = 0;
            while (i < gridActivosDestino.VisibleRowCount)
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
                bc.Code = this.gridActivosDestino.GetRowValues(i, "codigo").ToString();
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
    }
}