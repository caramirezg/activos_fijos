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
    /// Descripción breve de ControllerCompras
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerCompras : System.Web.Services.WebService
    {
        ClaseCompra ObjetoCompra = new ClaseCompra();

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public List<AuxiliarContableEntity> DatosAuxiliaresContables(string id)
        //{
        //    List<AuxiliarContableEntity> Lista = ObjetoAuxiliarContable.List_datosAuxiliaresContables(int.Parse(id));
        //    return Lista.ToList();
        //}

        /// <summary>
        /// Controllador que envia datos para guardar un registro de compra
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="fecha_registro"></param>
        /// <param name="unidad_solicitante"></param>
        /// <param name="tasa_ufv"></param>
        /// <param name="nro_factura"></param>
        /// <param name="nro_acta_recepcion"></param>
        /// <param name="proveedor"></param>
        /// <param name="nro_nota_remision"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaCompra(string descripcion, string fecha_registro, string unidad_solicitante,string fk_fuente_financiamiento, string tasa_ufv, string tasa_sus,string nro_factura, string doc_respaldo, string proveedor)
        {
            int Result = 0;
            Result = ObjetoCompra.CreaCompra(descripcion, DateTime.Parse(fecha_registro), int.Parse(unidad_solicitante), int.Parse(fk_fuente_financiamiento), tasa_ufv, tasa_sus, nro_factura, doc_respaldo, int.Parse(proveedor));
            return Result;
        }
        /// <summary>
        /// Controllador que obtiene los datos de compras
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<CompraEntity> DatosCompras()
        {
            List<CompraEntity> Lista = ObjetoCompra.List_datosCompras();
            return Lista.ToList();
        }
        /// <summary>
        /// Cambia el estado de compra y activos de elaborado a aprobado
        /// </summary>
        /// <param name="fk_compra"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ApruebaCompra(string fk_compra, string f_registro,string id_correlativo_reservado=null)
        {
            int Result = 0;
            Result = ObjetoCompra.ApruebaCompra(int.Parse(fk_compra),DateTime.Parse(f_registro), id_correlativo_reservado);
            return Result;
        }
        /// <summary>
        /// Elimina una compra y sus activos en estado elaborado 
        /// </summary>
        /// <param name="fk_compra"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaCompra(string fk_compra)
        {
            int Result = 0;
            Result = ObjetoCompra.EliminaCompra(int.Parse(fk_compra));
            return Result;
        }

        [WebMethod(EnableSession = true)]
        public int obtenerUlitmoCorrelativo()
        {
            int Result = 0;
            Result = ObjetoCompra.obtenerUlitmoCorrelativo();
            return Result;
        }
    }
}
