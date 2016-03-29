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
    public class ControllerPersonal
    {
        ClasePersonal ObjetoPersonal = new ClasePersonal();
        /// <summary>
        /// Controller lista del personal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<PersonalEntity> DatosPersonal()
        {
            List<PersonalEntity> Lista = ObjetoPersonal.List_datosPersonal();
            return Lista.ToList();
        }
    }
}