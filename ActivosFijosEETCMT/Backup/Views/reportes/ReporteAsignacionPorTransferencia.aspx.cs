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
    public partial class ReporteAsignacionPorTransferencia : System.Web.UI.Page
    {
        DataSet DsetAsignacionesPorTransferencia = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idAsignacionTrasnferencia = int.Parse(Request.QueryString["idAsignacionPorTransferencia"]);

            ClaseAsignacionPorTransferenciaMaestro ReporteAsignacionTransferencia = new ClaseAsignacionPorTransferenciaMaestro();

            rep.Load(Server.MapPath("~/Views/reportes/RptAsignacionPorTransferencia.rpt"));

            DsetAsignacionesPorTransferencia = ReporteAsignacionTransferencia.ReporteAsignacionPorTransferenciaActivos(idAsignacionTrasnferencia);
            rep.SetDataSource(DsetAsignacionesPorTransferencia);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}