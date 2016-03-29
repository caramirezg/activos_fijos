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
    /// Descripción breve de ControllerTransferencia
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerTransferencia : System.Web.Services.WebService
    {

        ClaseTransferencia ObjetoTransferencia = new ClaseTransferencia();

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaTransferencia(string correlativo,string descripcion,string f_transferencia,string origen, string tasa_sus,string tasa_ufv,string fkc_estado_proceso,string doc_respaldo)
        {
            int Result = 0;
            Result = ObjetoTransferencia.CreaTransferencia(correlativo,descripcion,f_transferencia,origen,tasa_sus,tasa_ufv,int.Parse(fkc_estado_proceso),doc_respaldo);
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ApruebaTransferencia(string fk_transferencia,string f_transferencia)
        {
            int Result = 0;
            Result = ObjetoTransferencia.ApruebaTransferencia(int.Parse(fk_transferencia),DateTime.Parse(f_transferencia));
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaTransferencia(string fk_transferencia)
        {
            int Result = 0;
            Result = ObjetoTransferencia.EliminaTransferencia(int.Parse(fk_transferencia));
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TransferenciaEntity> DatosTransferencias()
        {
            List<TransferenciaEntity> Lista = ObjetoTransferencia.List_datosTransferencias();
            return Lista.ToList();
        }
    }
}
