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
    /// Descripción breve de ControllerAuxiliaresContables
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerAuxiliaresContables : System.Web.Services.WebService
    {
        ClaseAuxiliarContable ObjetoAuxiliarContable = new ClaseAuxiliarContable();
        /// <summary>
        /// Muestra los auxiliares en base a un grupo contable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<AuxiliarContableEntity> DatosAuxiliaresContables(string id)
        {
            List<AuxiliarContableEntity> Lista = ObjetoAuxiliarContable.List_datosAuxiliaresContables(int.Parse(id));
            return Lista.ToList();
        }

        /// <summary>
        /// Valida que la sigla no se repita
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int validaSigla(string sigla,string idGrupoContable)
        {
            int Result = 0;
            Result = ObjetoAuxiliarContable.validaSigla(sigla,int.Parse(idGrupoContable));
            return Result;
        }
        /// <summary>
        /// Crea un nuevo auxiliar contable
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="sigla"></param>
        /// <param name="grupoContable"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaAuxiliarContable(string nombre, string descripcion, string sigla, string grupoContable)
        {
            int Result = 0;
            Result = ObjetoAuxiliarContable.CreaAuxiliarContable(nombre, descripcion, sigla, int.Parse(grupoContable));
            return Result;
        }
        /// <summary>
        /// Edita un registro de auxiliar contable
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="sigla"></param>
        /// <param name="idGrupoContable"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EditaGrupoContable(string id, string nombre, string descripcion, string sigla, string idGrupoContable)
        {
            int Result = 0;
            Result = ObjetoAuxiliarContable.EditaAuxiliarContable(int.Parse(id), nombre, descripcion, sigla, int.Parse(idGrupoContable));
            return Result;
        }
        /// <summary>
        /// Elimina un registro de auxiliar contable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaAuxiliarContable(string id)
        {
            int Result = 0;
            Result = ObjetoAuxiliarContable.EliminaAuxiliarContable(int.Parse(id));
            return Result;
        }

        
    }
}
