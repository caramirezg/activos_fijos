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
    public partial class ReporteAsignacion : System.Web.UI.Page
    {
        DataSet DsetAsignaciones = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int idAsignacion = int.Parse(Request.QueryString["idAsignacion"]);

            ClaseAsignacionesMaestro ReporteAsignacion = new ClaseAsignacionesMaestro();

            rep.Load(Server.MapPath("~/Views/reportes/RptAsignacion.rpt"));

            DsetAsignaciones = ReporteAsignacion.ReporteAsignacionActivos(idAsignacion);
            rep.SetDataSource(DsetAsignaciones);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}