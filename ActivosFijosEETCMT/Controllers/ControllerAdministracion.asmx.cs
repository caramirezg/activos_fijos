using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using ActivosFijos.Models;
using ActivosFijosEETC.Models;
using System.Data;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerAdministracion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerAdministracion : System.Web.Services.WebService
    {
        ClaseActivo ObjetoActivo = new ClaseActivo();
        ClaseArea ObjetoArea = new ClaseArea();
        ClaseUsuario ObjetoUsuario = new ClaseUsuario();
        ClaseGerencia ObjetoGerencia = new ClaseGerencia();
        ClaseClasificador ObjetoClasificador = new ClaseClasificador();
        ClaseTasaCambio ObjetoTasaCambio = new ClaseTasaCambio();
        ClaseLinea ObjetoLinea = new ClaseLinea();
        ClaseEstacion ObjetoEstacion = new ClaseEstacion();
        ClaseCompra ObjetoCompra = new ClaseCompra();
        ClaseTransferencia ObjetoTransferencia = new ClaseTransferencia();
        ClaseAsignacionesDetalle ObjetoAsignaciones = new ClaseAsignacionesDetalle();
        ClaseGestionesCerradas ObjetoCierre = new ClaseGestionesCerradas();
        ClaseGestionesAperturadas ObjetoApertura = new ClaseGestionesAperturadas();
        ClaseGrupoContable ObjetoGrupoContable = new ClaseGrupoContable();
        ClaseBajaDetalle ObjetoBaja = new ClaseBajaDetalle();
        ClaseRevaluoDetalle ObjetoRevaluo = new ClaseRevaluoDetalle();
        ClaseAsignacionPorTransferenciaDetalle ObjetoTransferenciaInternaDetalle = new ClaseAsignacionPorTransferenciaDetalle();
        ClaseMenu ObjetoMenu = new ClaseMenu();

        /// <summary>
        /// Carga datos del area de un usuario
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<AreaEntity> DatosArea(string fk_gerencia)
        {
            List<AreaEntity> Lista = ObjetoArea.List_DatosArea(int.Parse(fk_gerencia));
            return Lista;
        }

        /// <summary>
        /// Obtiene los datos de un usuario por Usuario de session
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession=true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<UserEntity> DatosUsuarioPorSession()
        {
            string vUser = HttpContext.Current.Session["user"].ToString();
            List<UserEntity> Lista;
            Lista = ObjetoUsuario.List_DatosUsuarioByID(vUser);
            return Lista;
        }
        /// <summary>
        /// Actualiza los datos del perfil de un usuario
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="IDarea"></param>
        /// <param name="IDcargo"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ActualizaUsuario(string nombre, string apellido, string IDarea, string IDcargo)
        {
            int result = 0;
            result = ObjetoUsuario.ActualizaUsuario(nombre, apellido, int.Parse(IDarea),int.Parse(IDcargo));
            return result;
        }

        /// <summary>
        /// Actualiza la informacion del password de usuario
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ActualizaPassword(string password, string passwordActual)
        {
            ControllerHelper vHelper = new ControllerHelper();
            int result = 0;
            result = ObjetoUsuario.ActualizaPassword(vHelper.getMD5(password), vHelper.getMD5(passwordActual));
            return result;
        }

        /// <summary>
        /// Obtiene lista de las gerencias
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<GerenciaEntity> DatosGerencias()
        {
            List<GerenciaEntity> Lista = ObjetoGerencia.List_DatosGerencias();
            return Lista;
        }
        /// <summary>
        /// Controller obtiene la lista de clasificadores por id de clasificador tipo
        /// </summary>
        /// <param name="idClasificadorTipo"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ClasificadorEntity> DatosClasificadoresByIDTipo(string idClasificadorTipo)
        {
            List<ClasificadorEntity> Lista = ObjetoClasificador.List_DatosClasificadoresByIdTipo(int.Parse(idClasificadorTipo));
            return Lista;
        }

        /// <summary>
        /// Obtiene la tasa del dolar de una fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public decimal obtieneTasaDolar(string fecha)
        {
            decimal result = 0;
            result = ObjetoTasaCambio.obtieneTasaDolar(fecha);
            return result;
        }
        /// <summary>
        /// Obtiene la tasa de ufv de una fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public decimal obtieneTasaUfv(string fecha)
        {
            decimal result = 0;
            result = ObjetoTasaCambio.obtieneTasaUfv(fecha);
            return result;
        }
        /// <summary>
        /// Obtiene la tasa del dolar y ufv
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TasaCambioEntity> obtieneTasaDolarUfv(string fecha)
        {
           
            List<TasaCambioEntity> Lista = ObjetoTasaCambio.obtieneTasaDolarUfv(fecha);
            return Lista;
        }


        /// <summary>
        /// Obtiene la lista de las lineas del teleferico   
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<LineaEntity> obtieneListLineas()
        {
            List<LineaEntity> Lista = ObjetoLinea.List_DatosLineas();
            return Lista;
        }
        /// <summary>
        /// Obtiene las estaciones por linea
        /// </summary>
        /// <param name="fk_linea"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<EstacionEntity> obtieneListEstacionesPorLinea(string fk_linea)
        {

            List<EstacionEntity> Lista = ObjetoEstacion.List_DatosEstacionesByLinea(int.Parse(fk_linea));
            return Lista;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public decimal obtieneActivosComprados()
        {
            decimal result = 0;
            result = ObjetoCompra.activosComprados();
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public decimal obtieneActivosTransferidos()
        {
            decimal result = 0;
            result = ObjetoTransferencia.activosTransferidos();
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public decimal obtieneActivosAsignados()
        {
            decimal result = 0;
            result = ObjetoAsignaciones.activosAsignados();
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string obtieneUltimaDepreciacion()
        {
            string result = "";
            result = ObjetoActivo.obtieneFechaUltimaDepreciacion();
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int obtieneCountBajas()
        {
            int result = 0;
            result = ObjetoBaja.obtieneCountBajas();
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int obtieneCountRevaluo()
        {
            int result = 0;
            result = ObjetoRevaluo.obtieneCountRevaluo();
            return result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int obtieneCountTransferenciasInternas()
        {
            int result = 0;
            result = ObjetoTransferenciaInternaDetalle.obtieneCountTransferenciasInternas();
            return result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int cerrarGestion(string f_cierre)
        {
            int result = 0;
            result = ObjetoCierre.GenerarCierreGestión(DateTime.Parse(f_cierre));
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int aperturarGestion(string f_apertura)
        {
            int result = 0;
            result = ObjetoApertura.GenerarAperturaGestión(DateTime.Parse(f_apertura));
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<GestionesCerradasEntity> obtieneListGestionesCerradas()
        {
            List<GestionesCerradasEntity> Lista = ObjetoCierre.List_datosGestionesCerradas();
            return Lista;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<GestionesAperturadasEntity> obtieneListGestionesAperturadas()
        {
            List<GestionesAperturadasEntity> Lista = ObjetoApertura.List_datosGestionesAperuradas();
            return Lista;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ActivosPorGrupoEntity> DatosCountActivosPorGrupo()
        {
            List<ActivosPorGrupoEntity> Lista = ObjetoGrupoContable.List_datosActivosPorGrupo();
            return Lista;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DataSet getMenu()
        {
            return ObjetoMenu.obtenerMenu();
            
        }
        
    }
}
