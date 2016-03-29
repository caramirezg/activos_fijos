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
    /// Descripción breve de ControllerModelos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class ControllerModelos : System.Web.Services.WebService
    {

        ClaseModelo ObjetoModelo = new ClaseModelo();

        /// <summary>
        /// Obtiene la lista de los modelos de una marca
        /// </summary>
        /// <param name="idMarca"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ModeloEntity> DatosModelos(string idMarca)
        {
            List<ModeloEntity> Lista = ObjetoModelo.List_datosModelos(int.Parse(idMarca));
            return Lista.ToList();
        }
    
        /// <summary>
        /// Controllador de creacion de modelo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="idMarca"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaModelo(string nombre,string idMarca)
        {
            int Result = 0;
            Result = ObjetoModelo.CreaModelo(nombre,int.Parse(idMarca));
            return Result;
        }
        /// <summary>
        /// Edita un registro de modelo de activo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EditaModelo(string id, string nombre)
        {
            int Result = 0;
            Result = ObjetoModelo.EditaModelo(int.Parse(id), nombre);
            return Result;
        }
        /// <summary>
        /// Elimina de manera logica un registro de modelo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaModelo(string id)
        {
            int Result = 0;
            Result = ObjetoModelo.EliminaModelo(int.Parse(id));
            return Result;
        }
    }
}
