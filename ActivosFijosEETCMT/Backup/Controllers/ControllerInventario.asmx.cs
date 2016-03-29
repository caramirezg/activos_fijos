using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ActivosFijosEETC.Models;
using System.Web.Script.Services;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerInventario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerInventario : System.Web.Services.WebService
    {
        ClaseInventarioMaestro ObjetoInventarioMaestro = new ClaseInventarioMaestro();
        ClaseInventarioDetalle ObjetoInventarioDetalle = new ClaseInventarioDetalle();

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<InventarioMaestroEntity> DatosMaestroInventario()
        {
            List<InventarioMaestroEntity> Lista = ObjetoInventarioMaestro.List_datosInventarioMaestro();
            return Lista.ToList();
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaInventario(string descripcion, string fecha,string documentoRespaldo)
        {
            int Result = 0;
            Result = ObjetoInventarioMaestro.CreaMaestroInventario(descripcion, DateTime.Parse(fecha), documentoRespaldo);
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable get_inventarioDetalleByCodigo(string codigo)
        {
            DataTable dtResult = new DataTable();
            dtResult = ObjetoInventarioDetalle.get_inventarioDetalleByCodigo(codigo);
            return dtResult;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaDetalleInventario(string fk_inventario,string codigo,string fkc_estado_activo_actual, string observaciones,int tipo_validacion)
        {
            int Result = 0;
            Result = ObjetoInventarioDetalle.CreaDetalleInventario(int.Parse(fk_inventario),codigo,int.Parse(fkc_estado_activo_actual),observaciones,tipo_validacion);
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosinventarioDetalle(string fk_inventario_maestro)
        {
            DataTable dtResult = new DataTable();
            dtResult = ObjetoInventarioDetalle.List_datosInventarioDetalle(int.Parse(fk_inventario_maestro));
            return dtResult;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ValidaActivoControlado(string codigo, string fk_inventario_maestro)
        {
            int Result = 0;
            Result = ObjetoInventarioDetalle.validaActivoControlado(codigo,int.Parse(fk_inventario_maestro));
            return Result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosinventarioFaltante(string fk_inventario_maestro)
        {
            DataTable dtResult = new DataTable();
            dtResult = ObjetoInventarioDetalle.List_datosInventarioFaltante(int.Parse(fk_inventario_maestro));
            return dtResult;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CerrarInventario(string fk_inventario_maestro,string fecha_conclusion)
        {
            int Result = 0;
            Result = ObjetoInventarioMaestro.CerrarInventario(int.Parse(fk_inventario_maestro),DateTime.Parse(fecha_conclusion));
            return Result;
        }
    }
}
