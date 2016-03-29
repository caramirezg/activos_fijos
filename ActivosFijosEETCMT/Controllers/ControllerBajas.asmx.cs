using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ActivosFijosEETC.Models;
using System.Web.Script.Services;
using System.Data;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerBajas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerBajas : System.Web.Services.WebService
    {

        ClaseBajaMaestro vBajaMaestro = new ClaseBajaMaestro();
        ClaseBajaDetalle vBajaDetalle = new ClaseBajaDetalle();
        ClaseActivo vActivo = new ClaseActivo();

        /*********BAJAS MAESTRO************/

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosBajasMaestro()
        {
            DataTable dtBajasMaestro = new DataTable();
            dtBajasMaestro = vBajaMaestro.List_datosBajasMaestro();
            return dtBajasMaestro;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosMotivosBajasMaestro()
        {
            DataTable dtMotivosBaja = new DataTable();
            dtMotivosBaja = vBajaMaestro.List_datosMotivosBajas();
            return dtMotivosBaja;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaBajaMaestro(string f_baja, string fkc_motivo_baja,string documento_respaldo)
        {
            int vResult = 0;
            vResult = vBajaMaestro.CreaBajaMaestro(DateTime.Parse(f_baja),int.Parse(fkc_motivo_baja),documento_respaldo);
            return vResult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ApruebaBajaMaestro(string id_baja_maestro, string f_baja)
        {
            int vResult = 0;
            vResult = vBajaMaestro.apruebaBaja(int.Parse(id_baja_maestro),DateTime.Parse(f_baja));
            return vResult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaBajaMaestro(string id_baja_maestro)
        {
            int vResult = 0;
            vResult = vBajaMaestro.eliminaBaja(int.Parse(id_baja_maestro));
            return vResult;
        }

        /*********BAJAS DETALLE************/


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivos(string id_baja_maestro)
        {
            DataTable dtActivos = new DataTable();
            dtActivos = vBajaDetalle.List_datosActivos(int.Parse(id_baja_maestro));
            return dtActivos;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosActivosBajas(string id_baja_maestro)
        {
            DataTable dtActivosBaja = new DataTable();
            dtActivosBaja = vBajaDetalle.List_datosActivosDadosDeBaja(int.Parse(id_baja_maestro));
            return dtActivosBaja;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaBajaDetalle(string id_baja_maestro, string fk_activo, string observaciones)
        {
            int vResult = 0;
            vResult = vBajaDetalle.CreaBajaDetalle(int.Parse(id_baja_maestro),int.Parse(fk_activo),observaciones);
            return vResult;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaBajaDetalle(string id_baja_detalle)
        {
            int vResult = 0;
            vResult = vBajaDetalle.EliminaBajaDetalle(int.Parse(id_baja_detalle));
            return vResult;
        }

        /*************DETALLE DE BAJAS******************/

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosDetalleActivosDadosDeBaja()
        {
            DataTable dtActivosBaja = new DataTable();
            dtActivosBaja = vActivo.List_datosActivosDadosDeBaja();
            return dtActivosBaja;
        }
    }
}
