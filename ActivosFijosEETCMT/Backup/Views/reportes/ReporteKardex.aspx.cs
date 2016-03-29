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
    public partial class ReporteKardex : System.Web.UI.Page
    {
        DataSet DsetKardex = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            int fk_activo = int.Parse(Request.QueryString["id_activo"]);
            ClaseActivo ReporteKardex = new ClaseActivo();

            rep.Load(Server.MapPath("~/Views/reportes/RptKardex.rpt"));

            DsetKardex = ReporteKardex.ReporteKardex(fk_activo);
            rep.SetDataSource(DsetKardex);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }

        protected void page_unload(object sender, EventArgs e)
        {
            rep.Close();   //
            rep.Dispose(); // Para el error de limite de requerimientos alcanzado.
        }
    }
}