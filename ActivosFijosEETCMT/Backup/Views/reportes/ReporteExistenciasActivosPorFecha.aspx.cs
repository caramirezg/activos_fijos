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
    public partial class ReporteExistenciasActivosPorFecha : System.Web.UI.Page
    {

        DataSet DsetExistencias = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            string fecha_inicio = Request.QueryString["fecha_inicio"].ToString().Trim();
            string fecha_fin = Request.QueryString["fecha_fin"].ToString().Trim();

            ClaseActivo ReporteActivos = new ClaseActivo();

            rep.Load(Server.MapPath("~/Views/reportes/rptExistenciasActivosPorFechas.rpt"));

            DsetExistencias = ReporteActivos.ReporteExistenciasActivosPorFecha(fecha_inicio, fecha_fin);
            rep.SetDataSource(DsetExistencias);
            if (string.IsNullOrEmpty(fecha_inicio) & !string.IsNullOrEmpty(fecha_fin))
                rep.SetParameterValue("fecha", " Hasta: " + DateTime.Parse(fecha_fin).ToString("dd/MM/yyyy"));
            else if (!string.IsNullOrEmpty(fecha_inicio) & string.IsNullOrEmpty(fecha_fin))
                rep.SetParameterValue("fecha", " Desde: " + DateTime.Parse(fecha_inicio).ToString("dd/MM/yyyy"));
            else if (string.IsNullOrEmpty(fecha_inicio) & string.IsNullOrEmpty(fecha_fin))
                rep.SetParameterValue("fecha", "Todas las existencias");
            else if (!string.IsNullOrEmpty(fecha_inicio) & !string.IsNullOrEmpty(fecha_fin))
                rep.SetParameterValue("fecha", " Desde: " + DateTime.Parse(fecha_inicio).ToString("dd/MM/yyyy") + " Hasta: " + DateTime.Parse(fecha_fin).ToString("dd/MM/yyyy"));

            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}