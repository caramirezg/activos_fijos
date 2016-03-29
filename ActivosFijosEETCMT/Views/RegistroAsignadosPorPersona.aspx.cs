using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using iTextSharp.text.pdf;
using System.Data;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class RegistroAsignadosPorPersona : System.Web.UI.Page
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

                     txtCodigoAsignacion.Text = Request.QueryString["codigoAsignacion"].Trim();
                     txtfkResponsable.Text = Request.QueryString["fk_persona"].Trim();
                     txtDocumento.Text = Request.QueryString["documento"].Trim();
                     txtNombres.Text = Request.QueryString["nombres"].Trim();
                     txtApellidos.Text = Request.QueryString["apellidos"].Trim();
                     txtGerencia.Text = Request.QueryString["gerencia"].Trim();
                     txtFechaAsignacion.Text = DateTime.Parse(Request.QueryString["f_asignacion"].Trim()).ToString("dd/MM/yyyy");
                     txtUbicacion.Text = Request.QueryString["ubicacion"].Trim();
                     txtLinea.Text = Request.QueryString["linea"].Trim();
                     txtIdEstacion.Text = Request.QueryString["fk_estacion"].Trim();
                     txtEstacion.Text = Request.QueryString["estacion"].Trim();


                     //Clasificadores estado 10 = ESTADO ASIGNADO
                     if (Request.QueryString["fkc_estado_proceso"].Trim() == "10")
                     {
                         actionActivos.Visible = false;
                         idBarCode.Visible = true;
                         div_activos_sin_asignacion.Visible = false;
                         div_campos.Visible = false;
                     }
                     else
                     {
                         actionActivos.Visible = true;
                         idBarCode.Visible = false;
                         div_activos_sin_asignacion.Visible = true;
                         div_campos.Visible = true;
                     }


                     cargarComboEstadosActivo();



                 }
                 cargarActivosNoAsignados();
                 cargarActivosAsignados();
             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }
        }

        private void cargarActivosNoAsignados()
        {
            ControllerActivos vObjeto = new ControllerActivos();
            GridActivosPorAsignar.DataSource = controllerHelper.ToDataTable(vObjeto.DatosActivosNoAsignados());
            GridActivosPorAsignar.DataBind();
        }

        private void cargarActivosAsignados()
        {
            ControllerAsignaciones vObjeto = new ControllerAsignaciones();
            gridActivosAsignados.DataSource = controllerHelper.ToDataTable(vObjeto.DatosAsignacionesDetalle(txtCodigoAsignacion.Text));
            gridActivosAsignados.DataBind();
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
        /// <summary>
        /// Asigna un activo seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAsignarActivo_Click(object sender, EventArgs e)
        {
            if (GridActivosPorAsignar.FocusedRowIndex > -1)
            {
             
                var fila = this.GridActivosPorAsignar.GetRow(GridActivosPorAsignar.FocusedRowIndex);

                string fk_activo = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                string fk_estado_activo = ddlEstadoFisicoActivo.SelectedItem.Value;
                string observaciones;
                if (!string.IsNullOrEmpty(txtObservaciones.Text))
                    observaciones = txtObservaciones.Text;
                else
                    observaciones = "SIN OBSERVACIONES";


                ControllerAsignaciones vObjeto = new ControllerAsignaciones();

                vObjeto.CreaDetalleAsignacion(txtCodigoAsignacion.Text, fk_activo, txtfkResponsable.Text, fk_estado_activo, observaciones);
                cargarActivosAsignados();
                cargarActivosNoAsignados();

            }
        }
        /// <summary>
        /// Elimina un registro de detalle de asignacion en estado pre asignado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuitarAsignacion_Click(object sender, EventArgs e)
        {
            if (gridActivosAsignados.FocusedRowIndex > -1)
            {
                var fila = this.gridActivosAsignados.GetRow(gridActivosAsignados.FocusedRowIndex);

                string idAsignacion = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string fk_activo = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();

                ControllerAsignaciones vObjeto = new ControllerAsignaciones();
                vObjeto.EliminaDetalleAsignacion(idAsignacion,fk_activo);
                cargarActivosAsignados();
                cargarActivosNoAsignados();
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('reportes/ReporteAsignacion.aspx?idAsignacion=" + txtCodigoAsignacion.Text + "','_blank');</script>");

        }
        /// <summary>
        /// Vuelve al formulario de lista de asignaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerAsignaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("asignaciones.aspx");
        }

        /// <summary>
        /// Imprime codigos de barra de toda la asignacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrintBarcodeAll_Click(object sender, EventArgs e)
        {

            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(160, 80), 10, 10, 10, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            int i = 0;
            while (i < gridActivosAsignados.VisibleRowCount)
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
                bc.Code = this.gridActivosAsignados.GetRowValues(i, "codigo").ToString();
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

        /// <summary>
        /// Imprime codigo de barras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            if (gridActivosAsignados.FocusedRowIndex > -1)
            {
                var fila = this.gridActivosAsignados.GetRow(gridActivosAsignados.FocusedRowIndex);

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
                bc.Code = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
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
    }
}