using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ActivosFijos.Models;
using System.Web.Script.Services;

namespace ActivosFijos.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerMenu
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class ControllerMenu : System.Web.Services.WebService
    {
        ClaseUsuario ObjetoUsuario = new ClaseUsuario();

        /// <summary>
        /// Envío de datos de usuario
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<UserEntity> DatosUsuario()
        {
            List<UserEntity> Lista = ObjetoUsuario.ListDatosUsuario();
            return Lista;
        }
        /// <summary>
        /// Cierra la session
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool CierraSesion()
        {
            HttpContext.Current.Session.Remove("user");
            return true;
        }
        /// <summary>
        /// Mantiene la session activa
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool SesionActiva()
        {
            if (HttpContext.Current.Session["user"] != null)
            {
                string a = HttpContext.Current.Session["user"].ToString();
                return true;
            }
            else
                return false;
        }
    }
}
