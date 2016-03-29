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
    public partial class ReporteRevaluoTecnico : System.Web.UI.Page
    {
        DataSet DsetRevaluo = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idMaestroRevaluo = int.Parse(Request.QueryString["idMaestroRevaluo"]);

            ClaseRevaluoMaestro ReporteRevaluo = new ClaseRevaluoMaestro();

            rep.Load(Server.MapPath("~/Views/reportes/RptRevaluoTecnico.rpt"));

            DsetRevaluo = ReporteRevaluo.ReporteRevaluo(idMaestroRevaluo);
            rep.SetDataSource(DsetRevaluo);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}