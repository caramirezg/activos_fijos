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
    public partial class ReporteAperturaGestion : System.Web.UI.Page
    {
        DataSet DsetResumenActivos = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();


        protected void Page_Load(object sender, EventArgs e)
        {
            ClaseGestionesAperturadas ReporteApertura= new ClaseGestionesAperturadas();

            DateTime f_apertura = DateTime.Parse(Request.QueryString["f_apertura"]);

            rep.Load(Server.MapPath("~/Views/reportes/RptAperturaGestion.rpt"));

            DsetResumenActivos = ReporteApertura.ReporteResumenAperturaGestion(f_apertura);
            rep.SetDataSource(DsetResumenActivos);
            rep.SetParameterValue("f_apertura", f_apertura.ToString("dd 'de' MMMM 'de' yyyy"));
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
        protected void page_unload(object sender, EventArgs e)
        {
            rep.Close();   //
            rep.Dispose(); // Para el error de limite de requerimientos alcanzado.
        }
    }
}