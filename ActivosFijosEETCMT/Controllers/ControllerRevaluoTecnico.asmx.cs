using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using ActivosFijosEETC.Models;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerRevaluoTecnico
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerRevaluoTecnico : System.Web.Services.WebService
    {

        ClaseRevaluoMaestro vRevaluoMaestro = new ClaseRevaluoMaestro();
        ClaseRevaluoDetalle vRevaluoDetalle = new ClaseRevaluoDetalle();

        /*************REVALUO MAESTRO*************/

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosRevaluoMaestro()
        {
            DataTable dtBajasMaestro = new DataTable();
            dtBajasMaestro = vRevaluoMaestro.List_datosRevaluoMaestro();
            return dtBajasMaestro;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaRevaluoMaestro(string f_revaluo,string motivo_revaluo,string disposicion_respaldo)
        {
            int vResult = 0;
            vResult = vRevaluoMaestro.CreaRevaluoMaestro(DateTime.Parse(f_revaluo), motivo_revaluo, disposicion_respaldo);
            return vResult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ApruebaRevaluoMaestro(string id_revaluo_maestro, string f_revaluo)
        {
            int vResult = 0;
            vResult = vRevaluoMaestro.apruebaRevaluo(int.Parse(id_revaluo_maestro), DateTime.Parse(f_revaluo));
            return vResult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaRevaluoMaestro(string id_revaluo_maestro)
        {
            int vResult = 0;
            vResult = vRevaluoMaestro.eliminaRevaluo(int.Parse(id_revaluo_maestro));
            return vResult;
        }


        /*********REVALUO TECNICO DETALLE************/
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivos()
        {
            DataTable dtActivosRevaluos = new DataTable();
            dtActivosRevaluos = vRevaluoDetalle.List_datosActivos();
            return dtActivosRevaluos;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivosRevaluados(string fk_revaluo_maestro)
        {
            DataTable dtActivosRevaluos = new DataTable();
            dtActivosRevaluos = vRevaluoDetalle.List_datosActivosRevaluados(int.Parse(fk_revaluo_maestro));
            return dtActivosRevaluos;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaRevaluoDetalle(string fk_revaluo_maestro, string fk_activo, string costo_antiguo,string costo_revaluo, string nueva_vida_util,string observaciones,string costo_actualizado_inicial_anterior)
        {
            int vResult = 0;
            vResult = vRevaluoDetalle.CreaRevaluoDetalle(int.Parse(fk_revaluo_maestro), int.Parse(fk_activo), decimal.Parse(costo_antiguo), decimal.Parse(costo_revaluo), int.Parse(nueva_vida_util), observaciones, decimal.Parse(costo_actualizado_inicial_anterior));
            return vResult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaRevaluoDetalle(string id_revaluo_detalle)
        {
            int vResult = 0;
            vResult = vRevaluoDetalle.EliminaRevaluoDetalle(int.Parse(id_revaluo_detalle));
            return vResult;
        }



    }
}
