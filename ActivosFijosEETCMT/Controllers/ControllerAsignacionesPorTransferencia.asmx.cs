using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using ActivosFijosEETC.Models;
using System.Data;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerAsignacionesPorTransferencia
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerAsignacionesPorTransferencia : System.Web.Services.WebService
    {

        ClaseAsignacionPorTransferenciaMaestro vMaestro = new ClaseAsignacionPorTransferenciaMaestro();
        ClaseAsignacionPorTransferenciaDetalle vDetalle = new ClaseAsignacionPorTransferenciaDetalle();

        /// <summary>
        /// Obtiene la lista de los maestros de asignaciones por transferencia
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosAsignacionesPorTransferenciaMaestro()
        {
            DataTable dt = vMaestro.List_datosAsignacionesPorTransferenciaMaestro();
            return dt;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaMaestroAsignacionPorTransferencia(string f_transferencia, string fkc_ubicacion,string fk_estacion,string fk_persona_origen,string fk_persona_destino,string motivo, string fkc_tipo_transferencia)
        {
            int Result = 0;
            int fkc_estado_proceso = 16;//ESTADO PRE TRANSFERIDO
            Result = vMaestro.CreaAsignacionPorTransferenciaMaestro(DateTime.Parse(f_transferencia), int.Parse(fkc_ubicacion), fk_estacion, int.Parse(fk_persona_origen), int.Parse(fk_persona_destino), fkc_estado_proceso,motivo,int.Parse(fkc_tipo_transferencia));
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivosAsignadosTransferidos(string fk_persona)
        {
            DataTable dt = vDetalle.List_datosActivosAsignadosTransferidosPorPersona(int.Parse(fk_persona));
            return dt;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosaActivosTransferidosPorIdMaestro(string fk_asignacion_por_transferencia_maestro)
        {
            DataTable dt = vDetalle.List_datosActivosTransferidosPorIdMaestro(int.Parse(fk_asignacion_por_transferencia_maestro));
            return dt;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaDetalleAsignacionPorTransferencia(string fk_asignacion_por_transferencia_maestro, string fk_activo, string fk_persona_origen, string fk_persona_destino, string fkc_estado_activo, string observaciones, string fk_asignacion_detalle, string tabla, string fk_asignacion_por_transferencia_detalle )
        {
            int result = 0;
            if (tabla.Equals("asignaciones_detalle"))
            {
                int fkc_estado_proceso = 9;//ESTADO PRE ASIGNADO
                result = vDetalle.CreaAsignacionPorTransferenciaDetalle_fromAsignaciones_detalle(int.Parse(fk_asignacion_por_transferencia_maestro), int.Parse(fk_activo), int.Parse(fk_persona_origen), int.Parse(fk_persona_destino), fkc_estado_proceso, int.Parse(fkc_estado_activo), observaciones, int.Parse(fk_asignacion_detalle), fk_asignacion_por_transferencia_detalle);
              
            }
            else {
                int fkc_estado_proceso = 9;//ESTADO PRE ASIGNADO
                result = vDetalle.CreaAsignacionPorTransferenciaDetalle_fromTransferencias_detalle(int.Parse(fk_asignacion_por_transferencia_maestro), int.Parse(fk_activo), int.Parse(fk_persona_origen), int.Parse(fk_persona_destino), fkc_estado_proceso, int.Parse(fkc_estado_activo), observaciones, int.Parse(fk_asignacion_detalle), int.Parse(fk_asignacion_por_transferencia_detalle));
            }
            return result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaDetalleAsignacionTransferencia(string idTransferencia)
        {
            int Result = 0;
            Result = vDetalle.EliminaTransferenciaPorActivo(int.Parse(idTransferencia));
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ApruebaAsignacionTransferencia(string idTransferenciaMaestro)
        {
            int Result = 0;
            Result = vMaestro.ApruebaAsignacionPorTransferencia(int.Parse(idTransferenciaMaestro));
            return Result;
        }
        /// <summary>
        /// Elimina el maestro y detalle de asignación
        /// </summary>
        /// <param name="idTransferencia"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaAsignacionTransferencia(string idTransferenciaMaestro)
        {
            int Result = 0;
            Result = vMaestro.EliminaAsignacionPorTransferencia(int.Parse(idTransferenciaMaestro));
            return Result;
        }



    }
}
