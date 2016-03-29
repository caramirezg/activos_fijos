using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using ActivosFijos.Models;
using ActivosFijosEETC.Models;

namespace ActivosFijosEETC.Controllers
{


    /// <summary>
    /// Summary description for ControllerTasasCambio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerTasasCambio : System.Web.Services.WebService
    {
        ClaseTasaCambio ObjetoTasaCambio = new ClaseTasaCambio();
        /// <summary>
        /// Obtiene lista de tasas de cambio
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TasaCambioEntity> DatosTasaDolarUfv()
        {
            List<TasaCambioEntity> Lista = ObjetoTasaCambio.List_datosTasasCambio();
            return Lista;
        }
        /// <summary>
        /// Crea un registro de tasa de cambio
        /// </summary>
        /// <param name="f_tasa"></param>
        /// <param name="tasa_ufv"></param>
        /// <param name="tasa_sus"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaTasaCambio(string f_tasa,string tasa_ufv,string tasa_sus)
        {
            int Result = 0;
            Result = ObjetoTasaCambio.CreaTasaCambio(f_tasa,tasa_ufv,tasa_sus);
            return Result;
        }

         [WebMethod(EnableSession = true)]
         [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
         public int EditaTasaCambio(string id,string f_tasa, string tasa_ufv, string tasa_sus)
         {
             int Result = 0;
             Result = ObjetoTasaCambio.EditaTasaCambio(int.Parse(id),DateTime.Parse(f_tasa),Convert.ToDecimal(tasa_ufv),Convert.ToDecimal(tasa_sus));
             return Result;
         }

        /// <summary>
        /// Elimina un registro de tasa de cambio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaTasaCambio(string id)
        {
            int Result = 0;
            Result = ObjetoTasaCambio.EliminaTasaCambio(int.Parse(id));
            return Result;
        }
        /// <summary>
        /// valida que no haya duplicidad en fechas
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int validaFechaRegistrada(string fecha)
        {
            int Result = 0;
            Result = ObjetoTasaCambio.validaFechaRegistrada(fecha);
            return Result;
        }

         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int validaExistenciaFechaRegistrada(string fecha)
        {
            int Result = 0;
            Result = ObjetoTasaCambio.validaExistenciaFechaRegistrada(fecha);
            return Result;
        }

         [WebMethod(EnableSession = true)]
         [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
         public List<TasaCambioEntity> DatosTasaUfvPorFechas()
         {
             List<TasaCambioEntity> Lista = ObjetoTasaCambio.List_datosTasasUfvPorFechas();
             return Lista;
         }
        
    }
}
