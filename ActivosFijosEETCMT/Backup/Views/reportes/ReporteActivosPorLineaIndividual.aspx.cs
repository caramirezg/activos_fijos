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
    public partial class ReporteActivosPorLineaIndividual : System.Web.UI.Page
    {
        DataSet DsetLineas = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClaseActivo ReporteActivo = new ClaseActivo();

            int idLinea = int.Parse(Request.QueryString["idLinea"]);

            rep.Load(Server.MapPath("~/Views/reportes/RptActivosPorLineaIndividual.rpt"));

            DsetLineas = ReporteActivo.ReporteActivosPorLinea(idLinea);
            rep.SetDataSource(DsetLineas);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
        protected void page_unload(object sender, EventArgs e)
        {
            rep.Close();   //
            rep.Dispose(); // Para el error de limite de requerimientos alcanzado.
        }
    }
}