using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Models;
using System.Data;
using CrystalDecisions.Shared;

namespace ActivosFijosEETC.Views.reportes
{
    public partial class ReporteActivosPorLinea : System.Web.UI.Page
    {
        DataSet DsetCompras = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClaseActivo ReporteActivo = new ClaseActivo();

            rep.Load(Server.MapPath("~/Views/reportes/RptActivosPorLinea.rpt"));

            DsetCompras = ReporteActivo.ReporteActivosPorGrupo();
            rep.SetDataSource(DsetCompras);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }

        protected void page_unload(object sender, EventArgs e)
        {
            rep.Close();   //
            rep.Dispose(); // Para el error de limite de requerimientos alcanzado.
        }
    }
}