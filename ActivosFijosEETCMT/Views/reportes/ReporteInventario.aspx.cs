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
    public partial class ReporteInventario : System.Web.UI.Page
    {
        DataSet DsetInventario = new DataSet();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idInventarioMaestro = int.Parse(Request.QueryString["fk_inventario_maestro"]);
            string tipoReporte = Request.QueryString["tipo_reporte"].ToString();


            ClaseInventarioDetalle ReporteInventario = new ClaseInventarioDetalle();

            rep.Load(Server.MapPath("~/Views/reportes/RptInventario.rpt"));



            DsetInventario = ReporteInventario.ReporteInventarioActivos(idInventarioMaestro, tipoReporte);
            rep.SetDataSource(DsetInventario);
            rep.Subreports["RptSubComisionInventario.rpt"].SetDataSource(DsetInventario.Tables["comision_inventario"]);
            if (tipoReporte == "verificado")
            {
                rep.SetParameterValue("titulo", "VERIFICADOS FISICAMENTE");
            }
            else
            {
                rep.SetParameterValue("titulo", "SIN VERIFICAR FISICAMENTE");
            }
      
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "REPORTE");
        }
    }
}