using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Shared;
using ActivosFijosEETC.Models;

namespace ActivosFijosEETC.Views.reportes
{
    public partial class ReporteDetalleActivosBajas : System.Web.UI.Page
    {
        DataSet DsetDetalleActivos = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClaseActivo ReporteActivo = new ClaseActivo();

            rep.Load(Server.MapPath("~/Views/reportes/RptDetalleActivosBajas.rpt"));

            DsetDetalleActivos = ReporteActivo.ReporteDetalleBajasActivos();
            rep.SetDataSource(DsetDetalleActivos);
            rep.SetParameterValue("fecha", DateTime.Today.ToString("d 'de' MMMM 'de' yyyy"));
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Detalle bajas");
            
        }
        protected void page_unload(object sender, EventArgs e)
        {
            rep.Close();   //
            rep.Dispose(); // Para el error de limite de requerimientos alcanzado.
        }
    }
}