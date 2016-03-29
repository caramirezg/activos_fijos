using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ActivosFijosEETC.Models;
using CrystalDecisions.Shared;

namespace ActivosFijosEETC.Views.reportes
{
    public partial class ReporteTransferencia : System.Web.UI.Page
    {
        DataSet DsetTransferencia = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idTransferencia = int.Parse(Request.QueryString["idTransferencia"]);

            ClaseTransferencia ReporteCompra = new ClaseTransferencia();

            rep.Load(Server.MapPath("~/Views/reportes/RptTransferencia.rpt"));

            DsetTransferencia = ReporteCompra.ReporteTransferenciaActivos(idTransferencia);
            rep.SetDataSource(DsetTransferencia);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }

        protected void page_unload(object sender, EventArgs e)
        {
            rep.Close();   //
            rep.Dispose(); // Para el error de limite de requerimientos alcanzado.
        }
    }
}