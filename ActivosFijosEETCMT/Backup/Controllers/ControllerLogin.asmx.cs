using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ActivosFijos.Models;
using ActivosFijosEETC.Controllers;

namespace ActivosFijos.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerLogin
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerLogin : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string autentificacion(string User, string Pass)
        {
            ControllerHelper vHelper = new ControllerHelper();
            string p = vHelper.getMD5(Pass);
            string result = new ClaseUsuario().autentificarUsuario(User, vHelper.getMD5(Pass));
            HttpContext.Current.Session.Add("user", result);
          
            if (!string.IsNullOrEmpty(HttpContext.Current.Session["user"].ToString()) && result != "0x0")
            {
                ClaseUsuario objetoUsuario = new ClaseUsuario();
                List<UserEntity> List = new List<UserEntity>();
                List = objetoUsuario.ListDatosUsuario();
                UserEntity Usuario = List[0];
            
                HttpContext.Current.Session.Add("userName", Usuario.usuario);
                HttpContext.Current.Session["nombre"] = Usuario.nombre;
                HttpContext.Current.Session["apellido"] = Usuario.apellido;
                HttpContext.Current.Session["perfil"] = Usuario.IDperfil;
                HttpContext.Current.Session["fk_persona"] = Usuario.IDpersona;
            }

            return (result != "0x0") ? "Default.aspx" : result;
        }
    }
}
