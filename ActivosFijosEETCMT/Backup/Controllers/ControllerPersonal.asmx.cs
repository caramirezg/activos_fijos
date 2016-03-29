using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using ActivosFijosEETC.Models;
using ActivosFijos.Models;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerPersonal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerPersonal : System.Web.Services.WebService
    {
        ClasePersonal ObjetoPersona = new ClasePersonal();

       [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaPersona(string documento,string nombres,string apellidos, string area, string gerencia,string estado)
        {
            int Result = 0;
            Result = ObjetoPersona.CreaPersona(documento,nombres,apellidos,area,gerencia,estado);
            return Result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<PersonalEntity> ListPersonal()
        {
            List<PersonalEntity> Lista = ObjetoPersona.List_datosPersonal();
            return Lista;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EditaPersona(string documento, string nombres, string apellidos, string area, string gerencia)
        {
            int Result = 0;
            Result = ObjetoPersona.EditaPersona(documento, nombres, apellidos, area, gerencia);
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int SincronizaPersonal()
        {
            int Result = 0;
            Result = ObjetoPersona.SincronizaPersonal();
            return Result;
        }
    }
}
