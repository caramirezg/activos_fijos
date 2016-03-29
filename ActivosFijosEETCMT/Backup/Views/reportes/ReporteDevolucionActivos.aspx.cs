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
    public partial class ReporteDevolucionActivos : System.Web.UI.Page
    {
        DataSet DsetIngresos = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int idMaestroIngresos = int.Parse(Request.QueryString["idMaestroIngresos"]);

            ClaseIngreso ReporteIngresos = new ClaseIngreso();

            rep.Load(Server.MapPath("~/Views/reportes/RptDevolucionActivos.rpt"));

            DsetIngresos = ReporteIngresos.ReporteIngresos(idMaestroIngresos);
            rep.SetDataSource(DsetIngresos);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}