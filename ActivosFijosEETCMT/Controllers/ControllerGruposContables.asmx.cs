using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ActivosFijosEETC.Models;
using ActivosFijos.Models;
using System.Web.Script.Services;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerGruposContables
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerGruposContables : System.Web.Services.WebService
    {
        ClaseGrupoContable ObjetoGrupoContable = new ClaseGrupoContable();

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<GrupoContableEntity> DatosGruposContables()
        {
            List<GrupoContableEntity> Lista = ObjetoGrupoContable.List_datosGruposContables();
            return Lista.ToList();
        }
        /// <summary>
        /// Crea un nuevo grupo contable
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="vida_util"></param>
        /// <param name="sigla"></param>
        /// <param name="porcentaje"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaGrupoContable(string codigo,string nombre, string descripcion, string vida_util, string sigla, string porcentaje,string depreciable,string actualizable)
        {
            int Result = 0;
            Result = ObjetoGrupoContable.CreaGrupoContable(codigo,nombre, descripcion, vida_util, sigla, porcentaje,depreciable,actualizable);
            return Result;
        }
        /// <summary>
        /// Valida que la sigla no se repita
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int validaSigla(string sigla)
        {
            int Result = 0;
            Result = ObjetoGrupoContable.validaSigla(sigla);
            return Result;
        }

        /// <summary>
        /// valida que el codigo no se repita
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int validaCodigo(string codigo)
        {
            int Result = 0;
            Result = ObjetoGrupoContable.validaCodigo(codigo);
            return Result;
        }
        /// <summary>
        /// Edita los datos de un grupo contable
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="vida_util"></param>
        /// <param name="sigla"></param>
        /// <param name="porcentaje"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EditaGrupoContable(string id,string nombre, string descripcion, string vida_util, string sigla, string porcentaje,string depreciable,string actualizable)
        {
            int Result = 0;
            Result = ObjetoGrupoContable.EditaGrupoContable(int.Parse(id),nombre, descripcion, int.Parse(vida_util), sigla, decimal.Parse(porcentaje),int.Parse(depreciable),int.Parse(actualizable));
            return Result;
        }
        /// <summary>
        /// Elimina un registro de grupo contable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaGrupoContable(string id)
        {
            int Result = 0;
            Result = ObjetoGrupoContable.EliminaGrupoContable(int.Parse(id));
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int verificaVidaUtilEspecifica(string id_grupo_contable,string vida_util_especifica)
        {
            int Result = 0;
            Result = ObjetoGrupoContable.validaVidaUtilEspecifica(int.Parse(id_grupo_contable),int.Parse(vida_util_especifica));
            return Result;
        }
    }
}
