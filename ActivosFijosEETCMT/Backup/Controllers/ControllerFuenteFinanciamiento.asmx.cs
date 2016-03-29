using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ActivosFijos.Models;
using System.Web.Script.Services;
using ActivosFijosEETC.Models;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerFuenteFinanciamiento
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerFuenteFinanciamiento : System.Web.Services.WebService
    {
        ClaseFuenteFinanciamiento ObjetoFuenteFinanciamiento = new ClaseFuenteFinanciamiento();

        /// <summary>
        /// Obtiene la lista de las fuentes de financiamiento
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<FuenteFinanciamientoEntity> DatosFuentesFinanciamiento()
        {
            List<FuenteFinanciamientoEntity> Lista;
            Lista = ObjetoFuenteFinanciamiento.List_datosFuenteFinanciamiento();
            return Lista;
        }
    }
}
