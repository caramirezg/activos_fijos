using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ActivosFijosEETC.Models;
using System.Web.Script.Services;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerActivos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerActivos : System.Web.Services.WebService
    {

        ClaseActivo ObjetoActivo = new ClaseActivo();
        ControllerHelper vHelper = new ControllerHelper();
        //*******************POR COMPRAS***************************

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaActivoPorCompra(string fk_fuente_financiamiento, string fk_auxiliar_contable,string fk_modelo, string serie, string descripcion, string f_registro, string valor_inicial,string valor_actual,string fk_compra,string fk_proveedor,string fkc_tipo_adquisicion,string tasa_ufv,string tasa_sus,string gasto_con_credito_fiscal,string gasto_sin_credito_fiscal,string f_inicio_garantia,string f_fin_garantia,string vida_util_alterna)
        {
            int Result = 0;
            string correlativo=ObjetoActivo.obtieneCorrelativo(int.Parse(fk_fuente_financiamiento),int.Parse(fk_auxiliar_contable));
            string codigo=ObjetoActivo.generaCodigoActivo(int.Parse(fk_fuente_financiamiento), int.Parse(fk_auxiliar_contable),correlativo);
            int fkc_estado_activo = 3;//ESTADO ACTIVO
            int fkc_estado_proceso = 4;//ESTADO ELABORADO
            Result = ObjetoActivo.CreaActivo(codigo,correlativo,int.Parse(fk_fuente_financiamiento),int.Parse(fk_auxiliar_contable), int.Parse(fk_modelo), serie, descripcion, DateTime.Parse(f_registro), fkc_estado_activo,fkc_estado_proceso,decimal.Parse(tasa_ufv),decimal.Parse(tasa_sus), Convert.ToDecimal(valor_inicial), Convert.ToDecimal(valor_actual),decimal.Parse(gasto_con_credito_fiscal),decimal.Parse(gasto_sin_credito_fiscal), int.Parse(fk_compra), int.Parse(fk_proveedor), int.Parse(fkc_tipo_adquisicion),f_inicio_garantia,f_fin_garantia,vida_util_alterna);
            return Result;
        }
        /// <summary>
        /// Obtiene la lista de activos de una compra determinada
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ActivoEntity> DatosActivosPorCompra(string idCompra)
        {
            List<ActivoEntity> Lista = ObjetoActivo.List_datosActivosPorCompra(int.Parse(idCompra));
            return Lista.ToList();
        }
        /// <summary>
        /// Elimina un activo actualizando los montos de compras
        /// </summary>
        /// <param name="idActivo"></param>
        /// <param name="idCompra"></param>
        /// <param name="valor_inicial_bs">costo activo en bs</param>
        /// <param name="valor_inicial_ufv">costo activo en ufv</param>
        /// <param name="valor_inicial_sus">costo activo en sus</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaActivoPorCompra(string idActivo)
        {
            int Result = 0;
            Result = ObjetoActivo.EliminaActivo(int.Parse(idActivo));
            return Result;
        }


        //*******************POR TRANSFERENCIA***************************


        /// <summary>
        /// Crea un activo por transferencia
        /// </summary>
        /// <param name="fk_fuente_financiamiento"></param>
        /// <param name="fk_auxiliar_contable"></param>
        /// <param name="fk_modelo"></param>
        /// <param name="serie"></param>
        /// <param name="descripcion"></param>
        /// <param name="f_registro"></param>
        /// <param name="valor_inicial"></param>
        /// <param name="valor_actual"></param>
        /// <param name="fk_transferencia"></param>
        /// <param name="fkc_tipo_adquisicion"></param>
        /// <param name="tasa_ufv"></param>
        /// <param name="tasa_sus"></param>
        /// <param name="valor_inicial_ufv"></param>
        /// <param name="valor_actual_ufv"></param>
        /// <param name="valor_inicial_sus"></param>
        /// <param name="valor_actual_sus"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaActivoPorTransferencia(string fk_fuente_financiamiento, string fk_auxiliar_contable, string fk_modelo, string serie, string descripcion, string f_registro, string valor_inicial,string costo_actualizado_inicial,string depreciacion_acumulada_total, string fk_transferencia,  string fkc_tipo_adquisicion, string tasa_ufv, string tasa_sus)
        {
            int Result = 0;
            string correlativo = ObjetoActivo.obtieneCorrelativo(int.Parse(fk_fuente_financiamiento), int.Parse(fk_auxiliar_contable));
            string codigo = ObjetoActivo.generaCodigoActivo(int.Parse(fk_fuente_financiamiento), int.Parse(fk_auxiliar_contable), correlativo);
            int fkc_estado_activo = 3;//ESTADO ACTIVO SE ADICIONA EN ASIGNACIONES
            int fkc_estado_proceso = 4;//ESTADO ELABORADO
            Result = ObjetoActivo.CreaActivoPorTransferencia(codigo, correlativo, int.Parse(fk_fuente_financiamiento), int.Parse(fk_auxiliar_contable), int.Parse(fk_modelo), serie, descripcion, DateTime.Parse(f_registro), fkc_estado_activo, fkc_estado_proceso, decimal.Parse(tasa_ufv), decimal.Parse(tasa_sus), decimal.Parse(valor_inicial),decimal.Parse(costo_actualizado_inicial),decimal.Parse(depreciacion_acumulada_total), int.Parse(fk_transferencia), int.Parse(fkc_tipo_adquisicion));
            return Result;
        }
        /// <summary>
        /// Obtiene list de activos por transferencia
        /// </summary>
        /// <param name="idTransferencia"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ActivoEntity> DatosActivosPorTransferencia(string idTransferencia)
        {
            List<ActivoEntity> Lista = ObjetoActivo.List_datosActivosPorTransferencia(int.Parse(idTransferencia));
            return Lista.ToList();
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int EliminaActivoPorTransferencia(string idActivo)
        {
            int Result = 0;
            Result = ObjetoActivo.EliminaActivoPorTransferencia(int.Parse(idActivo));
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ActivoEntity> DatosActivosNoAsignados()
        {
            List<ActivoEntity> Lista = ObjetoActivo.List_datosActivosNoAsignados();
            return Lista.ToList();
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosExistenciasActivos()
        {
            DataTable dtExistencias = new DataTable();
            dtExistencias = ObjetoActivo.List_datosExistenciaActivos();
            return dtExistencias;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataTable DatosDepreciacionActivos()
        {
            DataTable dtActivos = new DataTable();
            dtActivos = ObjetoActivo.List_datosDepreciacionActivos();
            return dtActivos;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ProcesoDepreciacion(string fecha)
        {
            int Result = 0;
            Result = ObjetoActivo.DepreciacionActivos(DateTime.Parse(fecha));
            return Result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int getCantActivosEstadoElaborado()
        {
            int Result = 0;
            Result = ObjetoActivo.getCantActivosEstadoElaborado();
            return Result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int validaExistenciaActivo(string codigo)
        {
            int Result = 0;
            Result = ObjetoActivo.validaExisteActivo(codigo);
            return Result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ModificaActivoCompras(string idActivo,string fk_compra, string descripcion, string marca, string modelo, string serie, string costo_bs, string gastos_con_credito_fiscal, string gastos_sin_credito_fiscal, string f_inicio_garantia, string f_fin_garantia)
        {
            int Result = 0;
            Result = ObjetoActivo.ModificaActivoCompra(int.Parse(idActivo), int.Parse(fk_compra), descripcion, int.Parse(marca),int.Parse(modelo),serie,decimal.Parse(costo_bs),decimal.Parse(gastos_con_credito_fiscal), decimal.Parse(gastos_sin_credito_fiscal),f_inicio_garantia,f_fin_garantia);
            return Result;
        }


        /******RETURN JSON******/
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string dataTableActivosPorMarca()
        {
            DataTable dtCantActivosPorMarca = new DataTable();
            String daresult = null;
            dtCantActivosPorMarca = ObjetoActivo.List_datosCantActivosPorMarca();
            DataSet ds = new DataSet();
            ds.Tables.Add(dtCantActivosPorMarca.Copy());
            daresult = vHelper.DataSetToJSON(ds);
            return daresult;
        }


    }
}
