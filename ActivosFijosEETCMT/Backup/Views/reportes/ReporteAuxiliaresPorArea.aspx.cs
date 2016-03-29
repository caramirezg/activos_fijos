using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using System.Data;
using ActivosFijosEETC.Models;

namespace ActivosFijosEETC.Views.reportes
{
    public partial class ReporteAuxiliaresPorArea : System.Web.UI.Page
    {
        DataSet DsetAuxiliares = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClaseAuxiliarContable ReporteAuxiliar = new ClaseAuxiliarContable();

            rep.Load(Server.MapPath("~/Views/reportes/RptAuxiliaresPorArea.rpt"));

            DsetAuxiliares = ReporteAuxiliar.ReporteAuxiliaresPorArea();
            rep.SetDataSource(DsetAuxiliares);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }

        protected void page_unload(object sender, EventArgs e)
        {
            rep.Close();   //
            rep.Dispose(); // Para el error de limite de requerimientos alcanzado.
        }
    }
}