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
    /// Descripción breve de ControllerCargos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerCargos : System.Web.Services.WebService
    {

        ClaseCargo ObjetoCargo = new ClaseCargo();

        /// <summary>
        /// Obtiene la lista de los cargos
        /// </summary>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<CargoEntity> DatosCargo()
        {
            List<CargoEntity> List;
            List = ObjetoCargo.List_DatosCargo();
            return List;
        }
    }
}
