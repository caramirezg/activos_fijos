using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ActivosFijos.Models;
using iTextSharp.text.pdf;

namespace ActivosFijosEETC.Views
{
    public partial class ImprimirCodigosDesdeExcel : System.Web.UI.Page
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            List_datosActivos();
        }

        public void List_datosActivos()
        {
            string query =
            "select f1 id,f2 codigo from Hoja2$";

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

             gridActivos.DataSource = dtTable;
             gridActivos.KeyFieldName = "id";
             gridActivos.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(160, 80), 10, 10, 10, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            int i = 0;
            while (i < gridActivos.VisibleRowCount)
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
                bc.Code = this.gridActivos.GetRowValues(i, "codigo").ToString();
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