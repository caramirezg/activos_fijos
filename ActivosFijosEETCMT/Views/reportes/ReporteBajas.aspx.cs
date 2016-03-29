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
    public partial class ReporteBajas : System.Web.UI.Page
    {
        DataSet DsetBajas = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idMaestroBaja = int.Parse(Request.QueryString["idMaestroBaja"]);

            ClaseBajaMaestro ReporteBajas = new ClaseBajaMaestro();

            rep.Load(Server.MapPath("~/Views/reportes/RptBajas.rpt"));

            DsetBajas = ReporteBajas.ReporteBaja(idMaestroBaja);
            rep.SetDataSource(DsetBajas);
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}