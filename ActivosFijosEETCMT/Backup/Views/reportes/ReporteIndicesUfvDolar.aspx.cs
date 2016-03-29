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
    public partial class ReporteIndicesUfvDolar : System.Web.UI.Page
    {

        DataSet DsetTasas = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            string fecha_inicio = Request.QueryString["fecha_inicio"].ToString();
            string fecha_fin = Request.QueryString["fecha_fin"].ToString();

            ClaseTasaCambio ReporteTasaCambio = new ClaseTasaCambio();

            rep.Load(Server.MapPath("~/Views/reportes/RptTasasCambio.rpt"));

            DsetTasas = ReporteTasaCambio.ReporteTasaUfvDolar(DateTime.Parse(fecha_inicio), DateTime.Parse(fecha_fin));
            rep.SetDataSource(DsetTasas);
            rep.SetParameterValue("fecha_inicio", DateTime.Parse(fecha_inicio).ToString("dd/MM/yyyy"));
            rep.SetParameterValue("fecha_fin", DateTime.Parse(fecha_fin).ToString("dd/MM/yyyy"));
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}