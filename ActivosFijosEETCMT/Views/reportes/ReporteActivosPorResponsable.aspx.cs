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
    public partial class ReporteActivosPorResponsable : System.Web.UI.Page
    {
        DataSet DsetActivosPorResponsable = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            string documento = Request.QueryString["documento"].ToString();

            ClaseActivo ActivosPorResponsable = new ClaseActivo();

            rep.Load(Server.MapPath("~/Views/reportes/RptActivosPorResponsable.rpt"));

            DsetActivosPorResponsable = ActivosPorResponsable.ReporteActivosPorResponsable(documento);
            rep.SetDataSource(DsetActivosPorResponsable);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}