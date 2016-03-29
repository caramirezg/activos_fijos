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
    /// Descripción breve de ControllerComiteRecepcion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerComiteRecepcion : System.Web.Services.WebService
    {
        ClaseComiteRecepcion ObjetoComiteRecepcion = new ClaseComiteRecepcion();

        /// <summary>
        /// Controller creacion de comite de recepcion por compra
        /// </summary>
        /// <param name="ListComiteRecepcion"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaComiteRecepcionPorCompra(List<ComiteRecepcionEntity> ListComiteRecepcion)
        {
            int Result = 0;
            Result = ObjetoComiteRecepcion.CreaComiteRecepcionPorCompra(ListComiteRecepcion);
            return Result;
        }

        /// <summary>
        /// Controller creacion de comite de recepcion por transferencia
        /// </summary>
        /// <param name="ListComiteRecepcion"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaComiteRecepcionPorTransferencia(List<ComiteRecepcionEntity> ListComiteRecepcion)
        {
            int Result = 0;
            Result = ObjetoComiteRecepcion.CreaComiteRecepcionPorTransferencia(ListComiteRecepcion);
            return Result;
        }
    }
}
