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
    public partial class ReporteCierreGestion : System.Web.UI.Page
    {
        DataSet DsetResumenActivos = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();


        protected void Page_Load(object sender, EventArgs e)
        {
            ClaseGestionesCerradas ReporteCierre = new ClaseGestionesCerradas();

            DateTime f_cierre = DateTime.Parse(Request.QueryString["f_cierre"]);
            string formato =Request.QueryString["formato"].ToString();

            rep.Load(Server.MapPath("~/Views/reportes/RptCierreGestion.rpt"));

            DsetResumenActivos = ReporteCierre.ReporteResumenCierreGestion(f_cierre);
            rep.SetDataSource(DsetResumenActivos);
            rep.SetParameterValue("f_cierre",f_cierre.ToString("dd 'de' MMMM 'de' yyyy"));
            if (formato=="excel")
                rep.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "REPORTE");
            else
                rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
        protected void page_unload(object sender, EventArgs e)
        {
            rep.Close();   //
            rep.Dispose(); // Para el error de limite de requerimientos alcanzado.
        }
    }
}