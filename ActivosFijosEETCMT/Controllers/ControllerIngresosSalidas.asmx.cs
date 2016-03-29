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
    /// Descripción breve de ControllerIngresosSalidas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerIngresosSalidas : System.Web.Services.WebService
    {
        
        ClaseIngresoSalidaMaestro vIngresoSalidaMaestro = new ClaseIngresoSalidaMaestro();
        ClaseIngresoSalidaDetalle vIngresoSalidaDetalle = new ClaseIngresoSalidaDetalle();
        ClaseIngreso vIngreso = new ClaseIngreso();

        /// <summary>
        /// Solicitud maestro para salida de un activo
        /// </summary>
        /// <param name="fk_persona"></param>
        /// <param name="f_solicitud"></param>
        /// <param name="f_desde"></param>
        /// <param name="f_hasta"></param>
        /// <param name="motivo"></param>
        /// <param name="fkc_estado_salida"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaIngresoSalidaMaestro(string fk_persona,string f_solicitud,string f_desde,string f_hasta,string motivo,string fkc_estado_salida)
        {
            int vResult = 0;
            vResult = vIngresoSalidaMaestro.CreaIngresoSalidaMaestro(int.Parse(fk_persona), DateTime.Parse(f_solicitud), DateTime.Parse(f_desde), f_hasta, motivo, int.Parse(fkc_estado_salida));
            return vResult;
        }
        /// <summary>
        /// Solicitud detalle para salida de un activo
        /// </summary>
        /// <param name="fk_ingresos_salidas_maestro"></param>
        /// <param name="fk_activo"></param>
        /// <param name="fkc_estado_salida"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaIngresoSalidaDetalle(string fk_ingresos_salidas_maestro, string fk_activo, string fkc_estado_salida,string observaciones)
        {
            int vResult = 0;
            vResult = vIngresoSalidaDetalle.CreaIngresoSalidaDetalle(int.Parse(fk_ingresos_salidas_maestro), int.Parse(fk_activo), int.Parse(fkc_estado_salida), observaciones);
            return vResult;
        }

        /// <summary>
        /// Obtiene la lista del maestro de solicitudes de ordenes de salida de activos
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosSolicitudesMaestro(string fk_persona,string vPerfil)
        {
            DataTable dtSolicitudMaestro = new DataTable();
            dtSolicitudMaestro = vIngresoSalidaMaestro.List_datosSolicitudesMaestro(int.Parse(fk_persona),int.Parse(vPerfil));
            return dtSolicitudMaestro;
        }
        /// <summary>
        /// Obtiene todos los activos
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosTodosActivos()
        {
            DataTable dtSolicitudDetalle = new DataTable();
            dtSolicitudDetalle = vIngresoSalidaDetalle.List_datosTodosActivos();
            return dtSolicitudDetalle;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivosPorPersona(string fk_persona)
        {
            DataTable dtSolicitudDetalle = new DataTable();
            dtSolicitudDetalle = vIngresoSalidaDetalle.List_datosActivosAsignadosTransferidosPorPersona(int.Parse(fk_persona));
            return dtSolicitudDetalle;
        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivosSolicitados(string fk_ingreso_salida_maestro)
        {
            DataTable dtActivosSolicitados = new DataTable();
            dtActivosSolicitados = vIngresoSalidaDetalle.List_datosActivosSolicitados(int.Parse(fk_ingreso_salida_maestro));
            return dtActivosSolicitados;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaDetalleSolicitud(string id)
        {
            int vresult = 0;
            vresult = vIngresoSalidaDetalle.EliminaIngresoSalidaDetalle(int.Parse(id));
            return vresult;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ApruebaSalida(string id,string fecha_solicitud)
        {
            int vresult = 0;
            vresult = vIngresoSalidaMaestro.apruebaSalida(int.Parse(id), DateTime.Parse(fecha_solicitud));
            return vresult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaSalida(string id)
        {
            int vresult = 0;
            vresult = vIngresoSalidaMaestro.eliminaSalida(int.Parse(id));
            return vresult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EditaSalidaMaestro(string id, string f_desde, string f_hasta, string motivo)
        {
            int vresult = 0;
            vresult = vIngresoSalidaMaestro.EditaSalidaMaestro(int.Parse(id), DateTime.Parse(f_desde), f_hasta, motivo);
            return vresult;
        }


        //******************INGRESOS MAESTRO*********************
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivosIngresados(string fk_persona,string vPerfil)
        {
            DataTable dtActivosSolicitados = new DataTable();
            dtActivosSolicitados = vIngreso.List_datosIngresosMaestro(int.Parse(fk_persona), int.Parse(vPerfil));
            return dtActivosSolicitados;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosSalidasAprobadas(string fk_persona,string vPerfil)
        {
            DataTable dtSalidasAprobadas = new DataTable();
            dtSalidasAprobadas = vIngreso.List_datosSalidasAprobadas(int.Parse(fk_persona), int.Parse(vPerfil));
            return dtSalidasAprobadas;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaIngresoMaestro(string f_ingreso, string fk_ingresos_salidas_maestro)
        {
            int vResult = 0;
            vResult = vIngreso.CreaIngresoMaestro(DateTime.Parse(f_ingreso), int.Parse(fk_ingresos_salidas_maestro));
            return vResult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EditaIngresoMaestro(string f_ingreso, string fk_ingresos_salidas_maestro)
        {
            int vResult = 0;
            vResult = vIngreso.CreaIngresoMaestro(DateTime.Parse(f_ingreso), int.Parse(fk_ingresos_salidas_maestro));
            return vResult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ApruebaIngreso(string id_ingreso_maestro, string fecha_ingreso)
        {
            int vresult = 0;
            vresult = vIngreso.apruebaIngreso(int.Parse(id_ingreso_maestro), DateTime.Parse(fecha_ingreso));
            return vresult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaIngreso(string id_ingreso_maestro)
        {
            int vresult = 0;
            vresult = vIngreso.eliminaIngreso(int.Parse(id_ingreso_maestro));
            return vresult;
        }


        /**********INGRESOS DETALLE**************/


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivosPrestados(string id_maestro_salida)
        {
            DataTable dtActivosPrestados = new DataTable();
            dtActivosPrestados = vIngresoSalidaDetalle.List_datosActivosPrestados(int.Parse(id_maestro_salida));
            return dtActivosPrestados;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivosDevueltos(string id_maestro_ingreso)
        {
            DataTable dtActivosDevueltos = new DataTable();
            dtActivosDevueltos = vIngresoSalidaDetalle.List_datosActivosDevueltos(int.Parse(id_maestro_ingreso));
            return dtActivosDevueltos;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int DevuelveActivoPrestado(string id_ingresos_maestro, string id_salidas_detalle,string observaciones)
        {
            int vResult = 0;
            vResult = vIngresoSalidaDetalle.DevuelveActivoPrestado(int.Parse(id_ingresos_maestro),int.Parse(id_salidas_detalle),observaciones);
            return vResult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int QuitarDevolucionActivoPrestado(string id_salidas_detalle)
        {
            int vResult = 0;
            vResult = vIngresoSalidaDetalle.QuitarDevolucionActivoPrestado(int.Parse(id_salidas_detalle));
            return vResult;
        }

    }
}
