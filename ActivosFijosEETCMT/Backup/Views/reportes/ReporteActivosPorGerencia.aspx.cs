using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Models;
using CrystalDecisions.Shared;
using System.Data;

namespace ActivosFijosEETC.Views.reportes
{
    public partial class ReporteActivosPorGerencia : System.Web.UI.Page
    {
        DataSet DsetCompras = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClaseActivo ReporteActivo = new ClaseActivo();

            rep.Load(Server.MapPath("~/Views/reportes/RptActivosPorGerencia.rpt"));

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