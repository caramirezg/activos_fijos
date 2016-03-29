using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using ActivosFijos.Models;
using ActivosFijosEETC.Models;
using System.Data;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerAsignaciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerAsignaciones : System.Web.Services.WebService
    {
        ClaseAsignacionesMaestro Objeto = new ClaseAsignacionesMaestro();
        ClaseAsignacionesDetalle ObjetoDetalleAsignacion = new ClaseAsignacionesDetalle();
        ControllerHelper vHelper = new ControllerHelper();
        //****************ASIGNACIONES MAESTRO************************

        /// <summary>
        /// Obtiene la lista de los maestros de asignaciones
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosAsignacionesMaestro()
        {
            DataTable dt = Objeto.List_datosAsignacionesMaestro();
            return dt;
        }


        /// <summary>
        /// crea un registro de maestro de asignacion
        /// </summary>
        /// <param name="f_asignacion"></param>
        /// <param name="correlativo"></param>
        /// <param name="ubicacion"></param>
        /// <param name="oficina"></param>
        /// <param name="fk_persona"></param>
        /// <param name="fk_estacion"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaMaestroAsignacion(string f_asignacion, string ubicacion, string fk_persona, string fk_estacion)
        {
            int Result = 0;
           
            int fkc_estado_proceso = 9;//ESTADO PRE ASIGNADO
            Result = Objeto.CreaAsignacionMaestro(DateTime.Parse(f_asignacion), int.Parse(ubicacion), fk_persona, fk_estacion, fkc_estado_proceso);
            return Result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaMaestroAsignacion(string idAsignacion)
        {
            int Result = 0;
            Result = Objeto.EliminaAsignacionMaestro(int.Parse(idAsignacion));
            return Result;
        }

        /// <summary>
        /// Aprueba una asignacion en estado pre asignado
        /// </summary>
        /// <param name="idAsignacion"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ApruebaAsignacion(string idAsignacion)
        {
            int Result = 0;
            Result = Objeto.ApruebaAsignacion(int.Parse(idAsignacion));
            return Result;
        }

        //****************ASIGNACIONES DETALLE************************

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaDetalleAsignacion(string fk_asignacion_maestro, string fk_activo, string fk_persona, string fkc_estado_activo, string observaciones)
        {
            int Result = 0;
            int fkc_estado_proceso = 9;//ESTADO PRE ASIGNADO
            Result = ObjetoDetalleAsignacion.CreaAsignacionDetalle(int.Parse(fk_asignacion_maestro),int.Parse(fk_activo),fk_persona,fkc_estado_proceso,int.Parse(fkc_estado_activo),observaciones);
            return Result;
        }
        
        /// <summary>
        /// Obtiene la lista de los activos pre asignados y asignados de un maestro de asignacion
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<AsignacionesDetalleEntity> DatosAsignacionesDetalle(string fk_asignacion_maestro)
        {
            List<AsignacionesDetalleEntity> Lista = ObjetoDetalleAsignacion.List_datosAsignacionesDetalle(int.Parse(fk_asignacion_maestro));
            return Lista.ToList();
        }
        /// <summary>
        /// Elimina un registro del detalle de asignacion en estado pre asignado, volviendo el estado de proceso en activos a aprobado
        /// </summary>
        /// <param name="idAsignacion"></param>
        /// <param name="fk_activo"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaDetalleAsignacion(string idAsignacion,string fk_activo)
        {
            int Result = 0;
            Result = ObjetoDetalleAsignacion.EliminaAsignacionPorActivo(int.Parse(idAsignacion),int.Parse(fk_activo));
            return Result;
        }

        /******RETURN JSON*******/
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string dataTablePorcentajeAsignados()
        {
            DataTable dtCantActivosPorMarca = new DataTable();
            String daresult = null;
            dtCantActivosPorMarca = ObjetoDetalleAsignacion.List_datosPorcentajesAsignados();
            DataSet ds = new DataSet();
            ds.Tables.Add(dtCantActivosPorMarca.Copy());
            daresult = vHelper.DataSetToJSON(ds);
            return daresult;
        }
    }
}
