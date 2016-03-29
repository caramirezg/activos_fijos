using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ActivosFijosEETC.Models;
using System.Web.Script.Services;
using ActivosFijos.Models;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerComiteInventario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerComiteInventario : System.Web.Services.WebService
    {

        ClaseComiteInventario ObjetoComiteRecepcion = new ClaseComiteInventario();

        /// <summary>
        /// Controller creacion de comite de recepcion por compra
        /// </summary>
        /// <param name="ListComiteRecepcion"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaComiteInvenario(List<ComiteInventarioEntity> ListComiteRecepcion)
        {
            int Result = 0;
            Result = ObjetoComiteRecepcion.CreaComiteInventario(ListComiteRecepcion);
            return Result;
        }
    }
}
