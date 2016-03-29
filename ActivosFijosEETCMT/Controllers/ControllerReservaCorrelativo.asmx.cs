using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using ActivosFijosEETC.Models;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerReservaCorrelativo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerReservaCorrelativo : System.Web.Services.WebService
    {
        ClaseReservaCorrelativo vReservaCorrelativo = new ClaseReservaCorrelativo();
        
        [WebMethod(EnableSession = true)]
        public DataTable getDataTableReservaCorrelativos()
        {
            return vReservaCorrelativo.getDataTableReservaCorrelativos();
        }

        [WebMethod(EnableSession = true)]
        public DataTable getDataTableReservaVigenteCorrelativos()
        {
            return vReservaCorrelativo.getDataTableReservaVigenteCorrelativos();
        }

        [WebMethod(EnableSession = true)]
        public int CreaReserva(string tabla, string correlativo, string gestion)
        {
            return vReservaCorrelativo.CreaReserva(tabla,int.Parse(correlativo),int.Parse(gestion));
        }

        [WebMethod(EnableSession = true)]
        public int EliminaReserva(string id)
        {
            return vReservaCorrelativo.EliminaReserva(int.Parse(id));
        }

        [WebMethod(EnableSession = true)]
        public int validaExisteReserva(string correlativo,string gestion)
        {
            return vReservaCorrelativo.validaExisteReserva(int.Parse(correlativo),int.Parse(gestion));
        }
    }
}
