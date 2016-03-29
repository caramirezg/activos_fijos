using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;
using System.Data.SqlClient;
using ActivosFijosEETC.Models.DataSets;

namespace ActivosFijosEETC.Models
{
    public class ClaseInventarioDetalle
    {
        Conexion conexion = new Conexion();



        public DataTable List_datosInventarioDetalle(int fk_inventario_maestro)
        {
            DataTable dtTable = new DataTable();
            string query = "select vista.* "+
                            "from  "+
                            "( "+
			                    "select i.correlativo,i.id,a.codigo,a.descripcion,a.serie,p.documento,p.nombres,p.apellidos,gerencia,area,c.nombre ubicacion,e.nombre estacion, "+
				                    "(select nombre from clasificadores cl where cl.id=i.fkc_estado_activo_actual) estado_activo,i.observaciones,(case I.verificado_fisicamente when 1 then 'SI' when 0 then 'NO' end) verificado "+
			                    "from inventario_detalle i "+
				                     "inner join activos a on a.id=fk_activo "+
				                     "inner join asignaciones_detalle ad on ad.fk_activo=a.id "+
				                     "inner join asignaciones_maestro am on am.id=ad.fk_asignacion_maestro "+
				                     "left join estaciones e on e.id=am.fk_estacion "+
				                     "inner join clasificadores c on c.id=am.fkc_ubicacion "+
				                     "inner join personal p on p.id=ad.fk_persona "+
                                 "where a.activo=1 and ad.activo=1 "+
                                       "and i.fk_inventario_maestro="+fk_inventario_maestro+" and ad.fkc_estado_proceso=10 "+
                                 "union "+
                                 "select i.correlativo,i.id,a.codigo,a.descripcion,a.serie,'SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR', "+
					                    "(select nombre from clasificadores cl where cl.id=i.fkc_estado_activo_actual) estado_activo,i.observaciones,(case I.verificado_fisicamente when 1 then 'SI' when 0 then 'NO' end) verificado "+
			                     "from inventario_detalle i "+
                                        "inner join activos a on a.id=i.fk_activo "+
                                 "where a.activo=1 and a.fkc_estado_proceso=5 "+
                                       "and i.fk_inventario_maestro="+fk_inventario_maestro+" "+
                                 "union "+
                                 "select i.correlativo,i.id,a.codigo,a.descripcion,a.serie,p.documento,p.nombres,p.apellidos,gerencia,area,c.nombre ubicacion,e.nombre estacion, "+
                                       "(select nombre from clasificadores cl where cl.id=i.fkc_estado_activo_actual) estado_activo,i.observaciones,(case I.verificado_fisicamente when 1 then 'SI' when 0 then 'NO' end) verificado "+
                                 "from inventario_detalle i "+
                                 "inner join activos a on a.id=fk_activo "+
                                 "inner join asignaciones_por_transferencias_detalle at on at.fk_activo=a.id "+
                                 "inner join asignaciones_por_transferencias_maestro am on am.id=at.fk_asignacion_por_transferencia_maestro "+
                                 "inner join personal p on p.id=at.fk_persona_destino "+
                                 "left join estaciones e on e.id=am.fk_estacion "+
                                 "inner join clasificadores c on c.id=am.fkc_ubicacion "+
                                 "where a.activo=1 and at.activo=1 "+
                                       "and i.fk_inventario_maestro="+fk_inventario_maestro+" and at.fkc_estado_proceso=10 "+
                             ") vista order by vista.id desc";
                              
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }

        public DataTable get_inventarioDetalleByCodigo(string codigo)
        {
            DataTable dtTable = new DataTable();

            string query = "select a.codigo,a.descripcion,p.documento,p.nombres,p.apellidos,p.area,p.gerencia, "+
	                               "(select id from clasificadores cl where cl.id=a.fkc_estado_activo) fkc_estado_activo, "+
	                               "(select nombre from clasificadores cl where cl.id=a.fkc_estado_activo) estado_activo "+
                            "from asignaciones_detalle ad "+
                            "inner join personal p on p.id=ad.fk_persona "+
                            "inner join activos a on a.id=fk_activo "+
                            "where a.codigo="+codigo+" "+
                            "and a.activo=1 and ad.activo=1 and ad.fkc_estado_proceso=10 "+
                            "union "+
                            "select a.codigo,a.descripcion,'SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR', "+
	                               "(select id from clasificadores cl where cl.id=a.fkc_estado_activo) fkc_estado_activo, "+
	                               "(select nombre from clasificadores cl where cl.id=a.fkc_estado_activo) estado_activo "+
                            "from activos a "+
                            "where a.codigo="+codigo+" "+
                            "and a.activo=1 and a.fkc_estado_proceso=5 "+
                            "union "+
                            "select a.codigo,a.descripcion,p.documento,p.nombres,p.apellidos,p.area,p.gerencia, "+
	                               "(select id from clasificadores cl where cl.id=a.fkc_estado_activo) fkc_estado_activo, "+
	                               "(select nombre from clasificadores cl where cl.id=a.fkc_estado_activo) estado_activo "+
                            "from asignaciones_por_transferencias_detalle at "+
                            "inner join personal p on p.id=at.fk_persona_destino "+
                            "inner join activos a on a.id=fk_activo "+
                            "where a.codigo="+codigo+" "+
                            "and a.activo=1 and at.activo=1 and at.fkc_estado_proceso=10";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }

        /// <summary>
        /// Crea un registro del detalle de inventario
        /// </summary>
        /// <param name="fk_inventario"></param>
        /// <param name="codigo"></param>
        /// <param name="fkc_estado_activo_actual"></param>
        /// <returns></returns>
        public int CreaDetalleInventario(int fk_inventario, string codigo, int fkc_estado_activo_actual,string observaciones,int tipo_validacion)
        {
            using (SqlConnection connection = new SqlConnection(conexion.connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction();

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    string userName = HttpContext.Current.Session["userName"].ToString();

                    command.Parameters.Add("@fk_inventario", SqlDbType.Int).Value = fk_inventario;
                    command.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo;
                    command.Parameters.Add("@fkc_estado_activo_actual", SqlDbType.Int).Value = fkc_estado_activo_actual;
                    command.Parameters.Add("@observaciones", SqlDbType.NVarChar).Value = observaciones;
                    command.Parameters.Add("@tipo_validacion", SqlDbType.Int).Value = tipo_validacion;

                    command.CommandText =
                     "insert into inventario_detalle " +
                     "(correlativo,fk_inventario_maestro,fk_activo,fkc_estado_activo_actual,observaciones,verificado_fisicamente,activo,usuariocreacion,fechacreacion) " +
                     "values((select isnull(max(correlativo)+1,1) from inventario_detalle where activo=1 and fk_inventario_maestro=@fk_inventario),@fk_inventario,(select id from activos where activo=1 and codigo=@codigo),@fkc_estado_activo_actual,@observaciones,@tipo_validacion,1,'" + userName + "','" + DateTime.Now + "')";

                    command.ExecuteNonQuery();


                    command.CommandText =
                        "update activos set fkc_estado_activo=@fkc_estado_activo_actual "+
                        "where id=(select id from activos where activo=1 and codigo=@codigo)";

                    command.ExecuteNonQuery();

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    // Attempt to roll back the transaction. 
                    try
                    {
                        transaction.Rollback();
                        return 0;
                    }
                    catch (Exception ex2)
                    {
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Valida que un activo no se vuelva a controlar
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public int validaActivoControlado(string codigo, int fk_inventario_maestro)
        {
            try
            {
                int result = 0;
                string query = " select count(id) from inventario_detalle "+
                                 "where fk_inventario_maestro=" + fk_inventario_maestro + " " +
                                 "and fk_activo=(select id from activos where activo=1 and codigo='" + codigo + "') " +
                                 "and activo=1";
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());
                
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }

        public DataTable List_datosInventarioFaltante(int fk_inventario_maestro)
        {
            DataTable dtTable = new DataTable();
            //string query =
            //    " select vista.* from( " +
            //                    "select a.id,a.codigo,a.descripcion,p.documento,p.nombres,p.apellidos,p.area,p.gerencia " +
            //                    "from asignaciones_detalle ad " +
            //                    "inner join personal p on p.id=ad.fk_persona " +
            //                    "inner join activos a on a.id=fk_activo " +
            //                    "where " +
            //                    "a.activo=1 and ad.activo=1 and ad.fkc_estado_proceso in (10) " +
            //                    "UNION " +
            //                    "select a.id,a.codigo,a.descripcion,'SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR' " +
            //                    "from activos a " +
            //                    "where " +
            //                    "a.activo=1 and a.fkc_estado_proceso=5 " +
            //                    "UNION " +
            //                    "select a.id,a.codigo,a.descripcion,p.documento,p.nombres,p.apellidos,p.area,p.gerencia " +
            //                    "from asignaciones_por_transferencias_detalle at " +
            //                    "inner join personal p on p.id=at.fk_persona_destino " +
            //                    "inner join activos a on a.id=fk_activo " +
            //                    "where a.activo=1 and at.activo=1 and at.fkc_estado_proceso in (10) " +

            //                    ")vista " +
            //                    "where vista.id not in (select i.fk_activo from inventario_detalle i where i.fk_inventario_maestro=" + fk_inventario_maestro + " and activo=1) ";

            string query =
                "select vista.* from( " +
                                "select a.id,a.codigo,a.descripcion,a.serie,p.documento,p.nombres,p.apellidos,p.area,p.gerencia,c.nombre ubicacion,e.nombre estacion " +
                                "from asignaciones_detalle ad " +
                                "inner join asignaciones_maestro am on am.id=ad.fk_asignacion_maestro " +
                                "inner join personal p on p.id=ad.fk_persona " +
                                "inner join activos a on a.id=fk_activo " +
                                "inner join clasificadores c on c.id=am.fkc_ubicacion " +
                                "left join estaciones e on e.id=am.fk_estacion " +
                                "where " +
                                "a.activo=1 and ad.activo=1 and ad.fkc_estado_proceso in (10) " +
                                "UNION " +
                                "select a.id,a.codigo,a.descripcion,a.serie,'SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR' " +
                                "from activos a " +
                                "where " +
                                "a.activo=1 and a.fkc_estado_proceso=5 " +
                                "UNION " +
                                "select a.id,a.codigo,a.descripcion,a.serie,p.documento,p.nombres,p.apellidos,p.area,p.gerencia,c.nombre ubicacion,e.nombre estacion " +
                                "from asignaciones_por_transferencias_detalle at " +
                                "inner join asignaciones_por_transferencias_maestro am on am.id=at.fk_asignacion_por_transferencia_maestro " +
                                "inner join personal p on p.id=at.fk_persona_destino " +
                                "inner join activos a on a.id=fk_activo " +
                                "inner join clasificadores c on c.id=am.fkc_ubicacion " +
                                "left join estaciones e on e.id=am.fk_estacion " +
                                "where a.activo=1 and at.activo=1 and at.fkc_estado_proceso in (10) " +
                                ")vista " +
                                "where vista.id not in (select i.fk_activo from inventario_detalle i where i.fk_inventario_maestro=" + fk_inventario_maestro + " and activo=1)";
                            

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }

        /// <summary>
        /// Obtiene el reporte de inventario de activos
        /// </summary>
        /// <param name="fk_inventario_maestro"></param>
        /// <returns></returns>
        public DataSet ReporteInventarioActivos(int fk_inventario_maestro, string tipo_reporte)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaComision = new DataTable();
            DataTable TablaMaestro = new DataTable();
            DataTable TablaDetalle = new DataTable();
            dsInventario dsInventario = new dsInventario();

            dsInventario.Tables["comision_inventario"].Clear();
            dsInventario.Tables["inventario_maestro"].Clear();
            dsInventario.Tables["inventario_detalle"].Clear();

            string queryComision = " select documento,nombres,apellidos,gerencia,area "+
                                      "from inventario_comision ic "+
                                      "inner join personal p on p.id=ic.fk_persona "+
                                      "where fk_inventario_maestro=" + fk_inventario_maestro + "";

            string queryMaestro = "select id,descripcion,f_inventario,documento_respaldo,f_conclusion from inventario_maestro "+
                                   "where id=" + fk_inventario_maestro + "";
            
            string queryDetalle = null;
            
            if (tipo_reporte == "verificado")
            {
                 queryDetalle = "select i.id,i.correlativo,a.codigo,a.descripcion,c.nombre estado_activo,i.observaciones " +
                                  "from inventario_detalle i " +
                                  "inner join activos a on a.id=i.fk_activo " +
                                  "inner join clasificadores c on c.id=i.fkc_estado_activo_actual " +
                                  "where fk_inventario_maestro=" + fk_inventario_maestro + " " +
                                  "and i.activo=1 and a.activo=1 " +
                                  "and i.verificado_fisicamente=1 " +
                                  "order by i.correlativo asc";
            }
            else
            {
                 queryDetalle = "select i.id,i.correlativo,a.codigo,a.descripcion,c.nombre estado_activo,i.observaciones " +
                                      "from inventario_detalle i " +
                                      "inner join activos a on a.id=i.fk_activo " +
                                      "inner join clasificadores c on c.id=i.fkc_estado_activo_actual " +
                                      "where fk_inventario_maestro=" + fk_inventario_maestro + " " +
                                      "and i.activo=1 and a.activo=1 " +
                                      "and i.verificado_fisicamente=0 " +
                                      "order by i.correlativo asc";
            }
            
        

            TablaComision = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryComision).Tables[0];


            foreach (DataRow rowDetalle in TablaComision.Rows)
            {

                string nombres = rowDetalle["nombres"].ToString();
                string apellidos = rowDetalle["apellidos"].ToString();
                string area = rowDetalle["area"].ToString();
                string gerencia = rowDetalle["gerencia"].ToString();
                string documento = rowDetalle["documento"].ToString();
                dsInventario.Tables["comision_inventario"].Rows.Add(new object[] {
                      nombres,
                      apellidos,
                      area,
                      gerencia,
                      documento
                    
                    });
            }




            TablaMaestro = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryMaestro).Tables[0];

            foreach (DataRow rowMaestro in TablaMaestro.Rows)
            {

                int id_maestro = int.Parse(rowMaestro["id"].ToString());
                string descripcion = rowMaestro["descripcion"].ToString();
                DateTime f_inventario = Convert.ToDateTime(rowMaestro["f_inventario"].ToString());
                string documento_respaldo = rowMaestro["documento_respaldo"].ToString();
                DateTime f_conclusion = Convert.ToDateTime(rowMaestro["f_conclusion"].ToString());

                f_conclusion = DateTime.Parse(f_conclusion.ToString("dd/MM/yyyy"));

                string conclusion = f_conclusion.ToString();

                if (conclusion.Equals("01/01/1900 0:00:00"))
                    conclusion = "";
                else
                {

                    string convertido = String.Format("{0:dd/MM/yyyy}", f_conclusion);
                    conclusion = convertido;

                }
                dsInventario.Tables["inventario_maestro"].Rows.Add(new object[] {
                    id_maestro,
                    descripcion,
                    f_inventario.ToString("dd/MM/yyyy"),
                    iniciales,
                    documento_respaldo,
                    conclusion
                });
                TablaDetalle.Clear();
                TablaDetalle = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryDetalle).Tables[0];
                foreach (DataRow rowDetalle in TablaDetalle.Rows)
                {
                    int id_detalle = int.Parse(rowDetalle["id"].ToString());
                    string descripcion_detalle = rowDetalle["descripcion"].ToString();
                    string codigo = rowDetalle["codigo"].ToString();
                    string estado = rowDetalle["estado_activo"].ToString();
                    string observaciones = rowDetalle["observaciones"].ToString();
                    int correlativo = int.Parse(rowDetalle["correlativo"].ToString());

                    dsInventario.Tables["inventario_detalle"].Rows.Add(new object[] {
                      id_detalle,
                      fk_inventario_maestro,
                      codigo,
                      descripcion_detalle,
                      estado,
                      observaciones,
                      correlativo
                    });
                }
            }
            return dsInventario;
        }


    }
}