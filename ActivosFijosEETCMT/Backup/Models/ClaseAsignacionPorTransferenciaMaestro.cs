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
    public class ClaseAsignacionPorTransferenciaMaestro
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();


        public DataTable List_datosAsignacionesPorTransferenciaMaestro()
        {

            string query = "select id,f_transferencia,RIGHT('00000000' + cast(correlativo as nvarchar(10)),7)+'/'+cast(year(f_transferencia)as nvarchar(4)) correlativo, " +
	                               "(select c.nombre from clasificadores c where c.id=t.fkc_ubicacion) ubicacion, "+
	                               "(select nombre from lineas where id=(select e.fk_linea from estaciones e where id=fk_estacion)) linea, "+
	                               "(select e.nombre from estaciones e where e.id=fk_estacion) estacion, "+
	                               "fk_persona_origen, "+
	                               "(select p.documento from personal p where p.id=fk_persona_origen) documento_origen, "+
	                               "(select p.nombres from personal p where p.id=fk_persona_origen) nombres_origen, "+
	                               "(select p.apellidos from personal p where p.id=fk_persona_origen) apellidos_origen, "+
	                               "(select p.gerencia from personal p where p.id=fk_persona_origen) gerencia_origen, "+
	                               "fk_persona_destino, "+
	                               "(select p.documento from personal p where p.id=fk_persona_destino) documento_destino, "+
	                               "(select p.nombres from personal p where p.id=fk_persona_destino) nombres_destino, "+
	                               "(select p.apellidos from personal p where p.id=fk_persona_destino) apellidos_destino, "+
	                               "(select p.gerencia from personal p where p.id=fk_persona_destino) gerencia_destino, "+
	                               "fkc_estado_proceso, "+
	                               "(select nombre from clasificadores c where c.id=fkc_estado_proceso) estado_proceso,t.motivo,t.fkc_tipo_transferencia, "+
                                   "(select nombre from clasificadores c where c.id=t.fkc_tipo_transferencia) tipo_transferencia "+
                            "from asignaciones_por_transferencias_maestro t where activo=1 order by estado_proceso,f_transferencia desc,correlativo desc";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }


        public int CreaAsignacionPorTransferenciaMaestro(DateTime f_transferencia, int fkc_ubicacion, string fk_estacion, int fk_persona_origen, int fk_persona_destino, int fkc_estado_proceso,string motivo, int fkc_tipo_transferencia)
        {
            using (SqlConnection connection = new SqlConnection(conexion.connectionString))
            {
                connection.Open();
                int result = 0;
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

                    command.Parameters.Add("@f_transferencia", SqlDbType.Date).Value = f_transferencia;
                    command.Parameters.Add("@correlativo", SqlDbType.VarChar).Value = DBNull.Value;
                    command.Parameters.Add("@fkc_ubicacion", SqlDbType.Int).Value = fkc_ubicacion;
                    if (!string.IsNullOrEmpty(fk_estacion))
                        command.Parameters.Add("@fk_estacion", SqlDbType.Int).Value = fk_estacion;
                    else
                        command.Parameters.Add("@fk_estacion", SqlDbType.Int).Value = DBNull.Value;

                    command.Parameters.Add("@fk_persona_origen", SqlDbType.Int).Value = fk_persona_origen;
                    command.Parameters.Add("@fk_persona_destino", SqlDbType.Int).Value = fk_persona_destino;
                  
                    command.Parameters.Add("@fkc_estado_proceso", SqlDbType.Int).Value = fkc_estado_proceso;

                    command.Parameters.Add("@motivo", SqlDbType.NVarChar).Value = motivo;
                    command.Parameters.Add("@fkc_tipo_transferencia", SqlDbType.Int).Value = fkc_tipo_transferencia;

                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = userName;
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                     "insert into asignaciones_por_transferencias_maestro " +
                     "(f_transferencia,correlativo,fkc_ubicacion,fk_estacion,fk_persona_origen,fk_persona_destino,fkc_estado_proceso,motivo,fkc_tipo_transferencia,activo,usuariocreacion,fechacreacion) " +
                     "OUTPUT INSERTED.ID values(@f_transferencia,@correlativo,@fkc_ubicacion,@fk_estacion,@fk_persona_origen,@fk_persona_destino,@fkc_estado_proceso,@motivo,@fkc_tipo_transferencia,@activo,@usuariocreacion,@fechacreacion)";

                    result = int.Parse(command.ExecuteScalar().ToString());

                    // Attempt to commit the transaction.
                    transaction.Commit();

                    return result;
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
        /// Aprueba una asignacion por transferencia
        /// </summary>
        /// <param name="id_maestroAsignacionTransferencia"></param>
        /// <returns></returns>
        public int ApruebaAsignacionPorTransferencia(int id_maestroAsignacionTransferencia)
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

                    ///Actualiza el estado proceso a transferido y crea el correlativo en el maestro de asignacion por transferencia
                    command.CommandText =
                        "update asignaciones_por_transferencias_maestro set fkc_estado_proceso=17,correlativo= (select isnull(max(correlativo)+1,1) from asignaciones_por_transferencias_maestro where activo=1 and  year(f_transferencia)=(select year(m.f_transferencia) from asignaciones_por_transferencias_maestro m where m.id=" + id_maestroAsignacionTransferencia + ")),usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                        "where id="+id_maestroAsignacionTransferencia+" ";
                                
                    command.ExecuteNonQuery();

                    ///Actualiza el estado proceso a asignado en el detalle de asignacion por transferencia
                     command.CommandText =
                        "update asignaciones_por_transferencias_detalle set fkc_estado_proceso=10,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "'  " +
                        "where activo=1 and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + "";
                                
                    command.ExecuteNonQuery();

                    ///Actualiza el estado proceso de asignacion detalle a transferido (cuando el detalle es de la tabla asignaciones)
                    command.CommandText =
                         "update asignaciones_detalle set fkc_estado_proceso=17,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "'  " +
                         "where id in (select fk_asignacion_detalle from asignaciones_por_transferencias_detalle "+
                                       "where activo=1 and fk_asignacion_por_transferencia_detalle is null and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + ")";
                                
                    command.ExecuteNonQuery();

                    ///Actualiza el estado proceso de asignacion detalle por transferencia a transferido (cuando el detalle es de la tabla asignaciones por transferencia)
                    command.CommandText =
                          "update asignaciones_por_transferencias_detalle set fkc_estado_proceso=17,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                          "where id in (select fk_asignacion_por_transferencia_detalle from asignaciones_por_transferencias_detalle " +
                                        "where activo=1 and fk_asignacion_por_transferencia_detalle is not null and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + ")";
                                
                    command.ExecuteNonQuery(); 

                    ///Actualiza el estado proceso de activos a asignado 
                    command.CommandText =
                          "update activos set fkc_estado_proceso=10,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                          "where id in (select fk_activo from asignaciones_por_transferencias_detalle "+
                                        "where activo=1 and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + ")";
                                
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
        /// Elimina una asignacion por transferencia
        /// </summary>
        /// <param name="id_maestroAsignacionTransferencia"></param>
        /// <returns></returns>
        public int EliminaAsignacionPorTransferencia(int id_maestroAsignacionTransferencia)
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

                    ///Elimina el maestro de asignación por transferencia cambiando el estado activo a 0
                    command.CommandText =
                        "update asignaciones_por_transferencias_maestro set activo=0,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' "+
                        "where id=" + id_maestroAsignacionTransferencia + " and fkc_estado_proceso=16";

                    command.ExecuteNonQuery();

                    ///Actualiza el estado proceso de asignacion detalle a asignado (cuando el detalle es de la tabla asignaciones)
                    command.CommandText =
                         "update asignaciones_detalle set fkc_estado_proceso=10,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                         "where id in (select fk_asignacion_detalle from asignaciones_por_transferencias_detalle " +
                                      "where activo=1 and fk_asignacion_por_transferencia_detalle is null and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + ") " +
                         "and fkc_estado_proceso=16";

                    command.ExecuteNonQuery();

                    ///Actualiza el estado proceso de asignacion detalle por transferencia a asignado (cuando el detalle es de la tabla asignaciones por transferencia)
                    command.CommandText =
                          "update asignaciones_por_transferencias_detalle set fkc_estado_proceso=10,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                          "where id in (select fk_asignacion_por_transferencia_detalle from asignaciones_por_transferencias_detalle " +
                                        "where activo=1 and fk_asignacion_por_transferencia_detalle is not null and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + ")";

                    command.ExecuteNonQuery();

                    ///Actualiza el estado proceso de activos a asignado 
                    command.CommandText =
                          "update activos set fkc_estado_proceso=10,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                          "where id in (select fk_activo from asignaciones_por_transferencias_detalle " +
                                        "where activo=1 and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + ")";

                    command.ExecuteNonQuery();


                    ///Actualiza el estado fisico de un activo en la tabla activos al estado anterior (tabla asignaciones_detalle)
                    command.CommandText =
                    "update a set a.fkc_estado_activo=(select ad.fkc_estado_activo from asignaciones_detalle ad " +
                                                            "where ad.id in(select fk_asignacion_detalle " +
                                                                        "from asignaciones_por_transferencias_detalle " +
                                                                        "where activo=1 and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + " and  fk_asignacion_por_transferencia_detalle is null) " +
                                                            "and a.id=ad.fk_activo " +
                                                            ") " +
                    "from activos a " +
                    "where a.id in (select ad.fk_activo from asignaciones_detalle ad " +
                                                            "where ad.id in(select fk_asignacion_detalle " +
                                                                        "from asignaciones_por_transferencias_detalle " +
                                                                        "where activo=1 and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + " and  fk_asignacion_por_transferencia_detalle is null) " +
                                                            ")";
                    command.ExecuteNonQuery();

                    ///Actualiza el estado fisico de un activo en la tabla activos al estado anterior (tabla asignaciones_por_transferencias_detalle)
                    command.CommandText =
                   "update a set a.fkc_estado_activo=(select at.fkc_estado_activo from asignaciones_por_transferencias_detalle at " +
                                                            "where at.id in(select fk_asignacion_por_transferencia_detalle " +
                                                                        "from asignaciones_por_transferencias_detalle " +
                                                                        "where activo=1 and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + " and  fk_asignacion_por_transferencia_detalle is not null) " +
                                                            "and a.id=at.fk_activo " +
                                                            ") " +
                    "from activos a " +
                    "where a.id in (select at.fk_activo from asignaciones_por_transferencias_detalle at " +
                                                            "where at.id in(select fk_asignacion_por_transferencia_detalle " +
                                                                        "from asignaciones_por_transferencias_detalle " +
                                                                        "where activo=1 and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + " and  fk_asignacion_por_transferencia_detalle is not null) " +
                                                            ")";
                    command.ExecuteNonQuery();  


                    ///Elimina el detalle de asignacion por transferencia cambiando el estado activo a 0
                    command.CommandText =
                       "update asignaciones_por_transferencias_detalle set activo=0,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "'  " +
                       "where activo=1 and fk_asignacion_por_transferencia_maestro=" + id_maestroAsignacionTransferencia + "";

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
        /// Reporte activos asignados por transferencia
        /// </summary>
        /// <param name="idAsignacionMaestro"></param>
        /// <returns></returns>
        public DataSet ReporteAsignacionPorTransferenciaActivos(int idAsignacionMaestro)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);


            DataTable TablaMaestro = new DataTable();
            DataTable TablaDetalle = new DataTable();
            dsAsignacionPorTransferencia dsRegistroAsignacionPorTransferencia = new dsAsignacionPorTransferencia();


            dsRegistroAsignacionPorTransferencia.Tables["asignacion_por_transferencia_maestro"].Clear();
            dsRegistroAsignacionPorTransferencia.Tables["asignacion_por_transferencia_detalle"].Clear();

            string queryMaestro = "select id,f_transferencia,correlativo,fkc_ubicacion, "+
                                    "(select nombre from clasificadores c where c.id=fkc_ubicacion) ubicacion, "+
                                     "fk_persona_origen, "+
                                        "(select nombres from personal p where p.id=fk_persona_origen)nombres_origen, "+
                                        "(select apellidos from personal p where p.id=fk_persona_origen)apellidos_origen, "+
                                        "(select gerencia from personal p where p.id=fk_persona_origen)gerencia_origen, "+
                                        "(select area from personal p where p.id=fk_persona_origen)area_origen, "+
                                        "fk_persona_destino, "+
                                        "(select nombres from personal p where p.id=fk_persona_destino)nombres_destino, "+
                                        "(select apellidos from personal p where p.id=fk_persona_destino)apellidos_destino, "+
                                        "(select gerencia from personal p where p.id=fk_persona_destino)gerencia_destino, "+
                                        "(select area from personal p where p.id=fk_persona_destino)area_destino, "+
                                        "fk_estacion, "+
                                        "(select nombre from estaciones e where e.id=fk_estacion) estacion, "+
                                        "(select nombre from lineas where id=(select fk_linea from estaciones e where e.id=fk_estacion)) linea, "+
                                        "fkc_estado_proceso,activo,motivo,fkc_tipo_transferencia,(select c.nombre from clasificadores c where c.id=fkc_tipo_transferencia ) tipo_transferencia " +
                                "from asignaciones_por_transferencias_maestro "+
                                "where activo=1 "+
                                "and id=" + idAsignacionMaestro + "";

            string queryDetalle = "select id,fk_asignacion_por_transferencia_maestro,fk_activo,fkc_estado_proceso,fkc_estado_activo,observaciones,activo, "+
                                            "(select codigo from activos a where a.id=fk_activo) codigo, "+
                                            "(select serie from activos a where a.id=fk_activo) serie, "+
                                            "(select descripcion from activos a where a.id=fk_activo) descripcion, "+
                                            "(select nombre from clasificadores c where c.id=fkc_estado_activo) estado_activo, "+
                                            "(select nombre from clasificadores c where c.id=fkc_estado_proceso) estado_proceso "+
                                   "from asignaciones_por_transferencias_detalle "+
                                   "where activo=1 and fk_asignacion_por_transferencia_maestro=" + idAsignacionMaestro + "";


            TablaMaestro = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryMaestro).Tables[0];

            foreach (DataRow rowMaestro in TablaMaestro.Rows)
            {

                int correlativo = 0;
                string official = "";
                string valor = rowMaestro["correlativo"].ToString();
                if (string.IsNullOrEmpty(valor))
                {
                    correlativo = 0;
                    official = "ESTE NO ES UN DOCUMENTO OFICIAL";
                }
                else
                {
                    correlativo = int.Parse(rowMaestro["correlativo"].ToString());
                }

                int id_Asignacion = int.Parse(rowMaestro["id"].ToString());
                DateTime f_asignacion = Convert.ToDateTime(rowMaestro["f_transferencia"].ToString());
                string ubicacion = rowMaestro["ubicacion"].ToString().ToUpper();
                string fk_persona_origen = rowMaestro["fk_persona_origen"].ToString();
                string nombres_origen = rowMaestro["nombres_origen"].ToString() + " " + rowMaestro["apellidos_origen"].ToString();
                string apellidos_origen = rowMaestro["apellidos_origen"].ToString();
                string gerencia_origen = rowMaestro["gerencia_origen"].ToString();
                string area_origen = rowMaestro["area_origen"].ToString();

                string fk_persona_destino = rowMaestro["fk_persona_destino"].ToString();
                string nombres_destino = rowMaestro["nombres_destino"].ToString() + " " + rowMaestro["apellidos_destino"].ToString();
                string apellidos_destino = rowMaestro["apellidos_destino"].ToString();
                string gerencia_destino = rowMaestro["gerencia_destino"].ToString();
                string area_destino = rowMaestro["area_destino"].ToString();
                string estacion = rowMaestro["estacion"].ToString();
                string linea = rowMaestro["linea"].ToString();
                string motivo = rowMaestro["motivo"].ToString();
                string tipo_transferencia = rowMaestro["tipo_transferencia"].ToString();


                dsRegistroAsignacionPorTransferencia.Tables["asignacion_por_transferencia_maestro"].Rows.Add(new object[] {
                    idAsignacionMaestro,
                    f_asignacion.ToString("dd/MM/yyyy"),
                    correlativo,
                    ubicacion,
                    fk_persona_origen,
                    nombres_origen,
                    apellidos_origen,
                    gerencia_origen,
                    area_origen,
                    estacion,
                    linea,
                    official,
                    iniciales,
                    fk_persona_destino,
                    nombres_destino,
                    apellidos_destino,
                    gerencia_destino,
                    area_destino,
                    motivo,
                    tipo_transferencia
                   
                     
                });
                TablaDetalle.Clear();
                TablaDetalle = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryDetalle).Tables[0];
                foreach (DataRow rowDetalle in TablaDetalle.Rows)
                {
                    string id = rowDetalle["id"].ToString();
                    string fk_asignacion_por_transferencia_maestro = rowDetalle["fk_asignacion_por_transferencia_maestro"].ToString();
                    string codigo = rowDetalle["codigo"].ToString();
                    string descripcion_activo = rowDetalle["descripcion"].ToString();
                    string observaciones = rowDetalle["observaciones"].ToString();
                    string estado_activo = rowDetalle["estado_activo"].ToString();
                    string serie = rowDetalle["serie"].ToString();

                    dsRegistroAsignacionPorTransferencia.Tables["asignacion_por_transferencia_detalle"].Rows.Add(new object[] {
                      id,
                      fk_asignacion_por_transferencia_maestro,
                      codigo,
                      descripcion_activo,
                      observaciones,
                      estado_activo,
                      serie

                    });
                }
            }
            return dsRegistroAsignacionPorTransferencia;
        }
    }
}