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
    public partial class ReporteSolicitudesSalidas : System.Web.UI.Page
    {
        DataSet DsetSolicitudes = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idMaestroSolicitudes = int.Parse(Request.QueryString["idMaestroSolicitudes"]);

            ClaseIngresoSalidaDetalle ReporteSolicitudes = new ClaseIngresoSalidaDetalle();

            rep.Load(Server.MapPath("~/Views/reportes/RptSolicitudesSalidas.rpt"));

            DsetSolicitudes = ReporteSolicitudes.ReporteSolicitudesSalida(idMaestroSolicitudes);
            rep.SetDataSource(DsetSolicitudes);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}