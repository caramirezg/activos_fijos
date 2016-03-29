using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ActivosFijos.Models
{
    public class UserEntity
    {
        public string usuario { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public string perfil { get; set; }
        public int estado { get; set; }
        public int IDusuario { get; set; }
        public int IDarea { get; set; }
        public int IDcargo { get; set; }
        public int IDperfil { get; set; }
        public int IDpersona { get; set; }

    }

    public class ProveedorEntity
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public int unidad { get; set; }
        public string nit { get; set; }
        public string lati { get; set; }
        public string longi { get; set; }
        public int estado { get; set; }
    }

    public class AreaEntity 
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int fk_gerencia { get; set; }
    }

    public class CargoEntity
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string observaciones { get; set; }
    }

    public class GrupoContableEntity
    {
        public int ID { get; set; }
        public string codigo { get; set; }       
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string sigla { get; set; }
        public int vida_util { get; set; }
        public decimal porcentaje_depreciacion { get; set; }
        public int count { get; set; }
        public int depreciable { get; set; }
        public int actualizable { get; set; }
        public int orden { get; set; }
 
    }

    public class AuxiliarContableEntity
    {
        public int ID { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string sigla { get; set; }
        public int fk_grupocontable { get; set; }
        public string grupo_contable { get; set; }
        public int activo { get; set; }
    }

    public class MarcasEntity
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public int activo { get; set; }
    }

    public class ModeloEntity
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public int fk_marca { get; set; }
        public string marca { get; set; }
        public int activo { get; set; }
    }

    public class CompraEntity
    {
        public int ID { get; set; }
        public string descripcion { get; set; }
        public string f_registro { get; set; }
        public int fk_gerencia_solicitante { get; set; }
        public string gerencia_solicitante { get; set; }

        public decimal monto_bs { get; set; }
        public decimal monto_ufv { get; set; }
        public decimal monto_sus { get; set; }
        public decimal tasa_sus { get; set; }
        public decimal tasa_ufv { get; set; }
        public string nro_factura { get; set; }
        public string doc_respaldo { get; set; }
        public int fk_proveedor { get; set; }
        public string proveedor { get; set; }
        public int fkc_estado_proceso { get; set; }
        public string estado_proceso { get; set; }
        public int activo { get; set; }
        public int fk_fuente_financiamiento { get; set; }
        public string fuente_financiamiento { get; set; }
        public string correlativo { get; set; }
        public decimal costo { get; set; }
        public decimal gastos_con_credito_fiscal { get; set; }
        public decimal gastos_sin_credito_fiscal { get; set; }
    }

    public class TransferenciaEntity
    {
        public int id { get; set; }
        public string correlativo { get; set; }
        public string descripcion { get; set; }
        public string f_transferencia { get; set; }
        public string origen { get; set; }
        public decimal monto_bs { get; set; }
        public decimal monto_ufv { get; set; }
        public decimal monto_sus { get; set; }
        public decimal tasa_sus { get; set; }
        public decimal tasa_ufv { get; set; }
        public int fkc_estado_proceso { get; set; }
        public string estado_proceso { get; set; }
        public string doc_respaldo { get; set; }
        public int activo { get; set; }
    }

    public class PersonalEntity
    {
        public int id { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string area { get; set; }
        public string gerencia { get; set; }
        public string estado { get; set; }
        public string cargo { get; set; }
    }

    public class ComiteRecepcionEntity
    {
         
        public int id { get; set; }
        public string fk_personal { get; set; }
        public int fk_compra { get; set; }
        public int activo { get; set; }
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public ComiteRecepcionEntity()
        {

        }
        
        /// <summary>
        /// constructor compras ci y fk_compra
        /// </summary>
        /// <param name="ci"></param>
        /// <param name="fk_compra"></param>
        public ComiteRecepcionEntity(string _fk_personal, int _fk_compra)
            {
                fk_personal = _fk_personal;
                fk_compra = _fk_compra;
            }

    }

    public class GerenciaEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int activo { get; set; }
    }
  
    public class ActivoEntity
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public int fk_fuente_financiamiento { get; set; }
        public string fuente_financiamiento { get; set; }
        public int fk_grupo_contable { get; set; }
        public string grupo_contable { get; set; }
        public int fk_auxiliar_contable { get; set; }
        public string auxiliar_contable { get; set; }
        public int correlativo { get; set; }
        public int fk_marca { get; set; }
        public string marca { get; set; }
        public int fk_modelo { get; set; }
        public string modelo { get; set; }
        public string serie { get; set; }
        public string descripcion { get; set; }
        public string f_registro { get; set; }
        public int fkc_estado_activo { get; set; }
        public string estado_activo { get; set; }
        public int fkc_estado_proceso { get; set; }
        public string estado_proceso { get; set; }
        public decimal tasa_ufv { get; set; }
        public decimal tasa_sus { get; set; }
        public decimal valor_inicial { get; set; }
        public decimal valor_inicial_ufv { get; set; }
        public decimal valor_inicial_sus { get; set; }
        public int fk_compra { get; set; }
        public int fk_donacion { get; set; }
        public int fk_transferencia { get; set; }
        public int fk_proveedor { get; set; }
        public int fkc_tipo_adquisicion { get; set; }
        public string f_baja { get; set; }
        public string f_actualizacion { get; set; }
        public string f_ultima_depreciacion { get; set; }
        public string f_inicio_garantia { get; set; }
        public string f_fin_garantia { get; set; }
        public int activo { get; set; }
        public decimal costo_actualizado_inicial { get; set; }
        public decimal depreciacion_acumulada_total { get; set; }
        public decimal valor_neto_inicial { get; set; }
        public decimal actualizacion_gestion { get; set; }
        public decimal costo_total_actualizado { get; set; }
        public decimal depreciacion_gestion { get; set; }
        public decimal actualizacion_depreciacion_acumulada { get; set; }
        public decimal depreciacion_acumulada { get; set; }
        public decimal valor_neto { get; set; }
        public int vida_util { get; set; }
        public decimal costo { get; set; }
        public decimal gastos_con_credito_fiscal { get; set; }
        public decimal gastos_sin_credito_fiscal { get; set; }
        public string vida_util_alterna { get; set; }
        public decimal costo_actualizado_inicial_historico { get; set; }
        public decimal depreciacion_acumulada_total_historico { get; set; }

       
    }


    public class ClasificadorEntity
    {
        public int id { get; set; }
        public int fk_clasificador { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int activo { get; set; }
    }

    public class TasaCambioEntity
    {
        public int id { get; set; }
        public decimal tasa_ufv { get; set; }
        public decimal tasa_sus { get; set; }
        public string f_tasa { get; set; }
        public int activo { get; set; }
        public string estado { get; set; }
    }


    public class FuenteFinanciamientoEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string sigla { get; set; }
        public int activo { get; set; }
    }

    public class AsignacionesMaestroEntity
    {
        public int id { get; set; }
        public string f_asignacion { get; set; }
        public string correlativo { get; set; }
        public int fkc_ubicacion { get; set; }
        public string ubicacion { get; set; }
        public string fk_persona { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public  System.Nullable<int> fk_estacion { get; set; }
        public string estacion { get; set; }
        public string gerencia { get; set; }
        public int fkc_estado_proceso { get; set; }
        public string estado_proceso { get; set; }
        public int activo { get; set; }
    }
 
    public class AsignacionesDetalleEntity
    {
       
        public int id { get; set; }
        public int fk_asignacion_maestro { get; set; }
        public int fk_activo { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string fk_persona { get; set; }
        public int fkc_estado_proceso { get; set; }
        public string estado_proceso { get; set; }
        public int fkc_estado_activo { get; set; }
        public string estado_activo { get; set; }
        public string observaciones { get; set; }
        public int activo { get; set; }
    }

    public class LineaEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int activo { get; set; }
    }

    public class EstacionEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int fk_linea { get; set; }
        public int activo { get; set; }
    }

    public class GestionesCerradasEntity
    {
        public int id { get; set; }
        public string f_cierre { get; set; }
        public int activo { get; set; }
    }

    public class GestionesAperturadasEntity
    {
        public int id { get; set; }
        public string f_apertura { get; set; }
        public int activo { get; set; }
    }


    /************ENTITY CHARTS***************/

    public class ActivosPorGrupoEntity
    {
        public string grupo_contable { get; set; }
        public int count { get; set; }
       
    }


    public class InventarioMaestroEntity
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string f_inventario { get; set; }
        public int fkc_estado_inventario { get; set; }
        public string estado_inventario { get; set; }
        public string documento_respaldo { get; set; }
      
        public string f_conclusion { get; set; }
    }


    public class ComiteInventarioEntity
    {

        public int id { get; set; }
        public int fk_inventario_maestro { get; set; }
        public int fk_persona { get; set; }
        public int activo { get; set; }



        public ComiteInventarioEntity()
        {

        }

        /// <summary>
        /// constructor compras ci y fk_compra
        /// </summary>
        /// <param name="ci"></param>
        /// <param name="fk_compra"></param>
        public ComiteInventarioEntity(int _fk_persona, int _fk_inventario_maestro)
        {
            fk_persona = _fk_persona;
            fk_inventario_maestro = _fk_inventario_maestro;
        }

       

    }
}