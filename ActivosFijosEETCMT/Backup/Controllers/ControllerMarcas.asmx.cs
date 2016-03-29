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
    /// Descripción breve de ControllerMarcas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerMarcas : System.Web.Services.WebService
    {
        ClaseMarca ObjetoMarca = new ClaseMarca();
        
        /// <summary>
        /// Obtiene la lista de marcas
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<MarcasEntity> DatosMarcas()
        {
            List<MarcasEntity> Lista = ObjetoMarca.List_datosMarcas();
            return Lista.ToList();
        }
        /// <summary>
        /// Crea un registro de marca de activo
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaMarca(string nombre)
        {
            int Result = 0;
            Result = ObjetoMarca.CreaMarca(nombre);
            return Result;
        }
        /// <summary>
        /// Edita un registro de marca de activo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EditaMarca(string id, string nombre)
        {
            int Result = 0;
            Result = ObjetoMarca.EditaMarca(int.Parse(id), nombre);
            return Result;
        }
        /// <summary>
        /// Elimina de manera logica un registro de marca
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaMarca(string id)
        {
            int Result = 0;
            Result = ObjetoMarca.EliminaMarca(int.Parse(id));
            return Result;
        }
    }
}
