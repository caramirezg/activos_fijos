using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ActivosFijos.Models;
using System.Data.SqlClient;

namespace ActivosFijosEETC.Models
{
    public class ClaseAsignacionPorTransferenciaDetalle
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de activos asignados por asignacion normal y por transferencia (ACTIVOS ORIGEN)
        /// </summary>
        /// <returns></returns>
        public DataTable List_datosActivosAsignadosTransferidosPorPersona(int fk_persona)
        {

            string query = "select row_number() over (order by vista.tabla) id,vista.* "+
                           "from( "+
                           "select ad.id id_asignacion_detalle,null id_asignacion_por_transferencia_detalle,a.id fk_activo, a.codigo,a.descripcion,a.serie,(select nombre from clasificadores c where c.id=ad.fkc_estado_proceso) estado_proceso,'asignaciones_detalle' tabla  "+
                           "from asignaciones_detalle ad "+
                           "inner join activos a on a.id=ad.fk_activo "+
                           "where ad.activo=1 and ad.fkc_estado_proceso in (10) and ad.fk_persona="+fk_persona+" "+
                           "union all "+
                           "select fk_asignacion_detalle,at.id,at.fk_activo,a.codigo,a.descripcion,a.serie,(select nombre from clasificadores c where c.id=at.fkc_estado_proceso)estado_proceso,'asignaciones_por_transferencias_detalle' tabla "+
                           "from asignaciones_por_transferencias_detalle at "+
                           "inner join activos a on a.id=at.fk_activo "+
                           "where at.activo=1 and at.fkc_estado_proceso in (10) and at.fk_persona_destino="+fk_persona+" "+
                           ") vista";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }
        /// <summary>
        /// Obtiene la lista de activos transferidos por id de maestro (ACTIVOS DESTINO)
        /// </summary>
        /// <param name="fk_asignacion_por_transferencia_maestro"></param>
        /// <returns></returns>
        public DataTable List_datosActivosTransferidosPorIdMaestro(int fk_asignacion_por_transferencia_maestro)
        {

            string query = "select at.id,at.fk_activo,a.codigo,a.descripcion,a.serie,(select c.nombre from clasificadores c where c.id=at.fkc_estado_proceso) estado_proceso,(select c.nombre from clasificadores c where c.id=at.fkc_estado_activo) estado_fisico,at.observaciones " +
                           "from asignaciones_por_transferencias_detalle at "+
                           "inner join activos a on a.id=at.fk_activo "+
                           "where at.activo=1 and at.fk_asignacion_por_transferencia_maestro=" + fk_asignacion_por_transferencia_maestro + "";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }


        public int CreaAsignacionPorTransferenciaDetalle_fromAsignaciones_detalle(int fk_asignacion_por_transferencia_maestro, int fk_activo, int fk_persona_origen, int fk_persona_destino, int fkc_estado_proceso, int fkc_estado_activo, string observaciones, int fk_asignacion_detalle, string fk_asignacion_por_transferencia_detalle)
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

                    command.Parameters.Add("@fk_asignacion_por_transferencia_maestro", SqlDbType.Int).Value = fk_asignacion_por_transferencia_maestro;
                    command.Parameters.Add("@fk_activo", SqlDbType.Int).Value = fk_activo;
                    command.Parameters.Add("@fk_persona_origen", SqlDbType.Int).Value = fk_persona_origen;
                    command.Parameters.Add("@fk_persona_destino", SqlDbType.Int).Value = fk_persona_destino;
                    command.Parameters.Add("@fkc_estado_proceso", SqlDbType.Int).Value = fkc_estado_proceso;
                    command.Parameters.Add("@fkc_estado_activo", SqlDbType.Int).Value = fkc_estado_activo;
                    command.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = observaciones;
                    if (string.IsNullOrEmpty(fk_asignacion_por_transferencia_detalle))
                        command.Parameters.Add("@fk_asignacion_por_transferencia_detalle", SqlDbType.VarChar).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@fk_asignacion_por_transferencia_detalle", SqlDbType.VarChar).Value = fk_asignacion_por_transferencia_detalle;
                    command.Parameters.Add("@fk_asignacion_detalle", SqlDbType.Int).Value = fk_asignacion_detalle;

                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = userName;
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                     "insert into asignaciones_por_transferencias_detalle " +
                     "(fk_asignacion_por_transferencia_maestro,fk_activo,fk_persona_origen,fk_persona_destino,fkc_estado_proceso,fkc_estado_activo,observaciones,fk_asignacion_por_transferencia_detalle,fk_asignacion_detalle,activo,usuariocreacion,fechacreacion) " +
                     "values(@fk_asignacion_por_transferencia_maestro,@fk_activo,@fk_persona_origen,@fk_persona_destino,@fkc_estado_proceso,@fkc_estado_activo,@observaciones,@fk_asignacion_por_transferencia_detalle,@fk_asignacion_detalle,@activo,@usuariocreacion,@fechacreacion)";

                    command.ExecuteNonQuery();

                    ///Actualiza el estado de proceso de un activo de asignado a pre asignado
                    command.CommandText =
                     "update activos set fkc_estado_proceso = 9 " +//9 = clasificador pre asignado
                     "where id=@fk_activo";

                    command.ExecuteNonQuery();


                    ///Actualiza el estado fisico del activo
                    command.CommandText =
                     "update activos set fkc_estado_activo = " + fkc_estado_activo + " " +
                     "where id=@fk_activo";

                    command.ExecuteNonQuery();


                    ///Actualiza el estado de proceso de asignaciones a pre transferido: 16 ESTADO PRE TRANSFERIDO
                    command.CommandText =
                     "update asignaciones_detalle set fkc_estado_proceso=16 "+
                     "where id=@fk_asignacion_detalle";

                    command.ExecuteNonQuery();



                    /// Attempt to commit the transaction.
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


        public int CreaAsignacionPorTransferenciaDetalle_fromTransferencias_detalle(int fk_asignacion_por_transferencia_maestro, int fk_activo, int fk_persona_origen, int fk_persona_destino, int fkc_estado_proceso, int fkc_estado_activo, string observaciones, int fk_asignacion_detalle, int fk_asignacion_por_transferencia_detalle)
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

                    command.Parameters.Add("@fk_asignacion_por_transferencia_maestro", SqlDbType.Int).Value = fk_asignacion_por_transferencia_maestro;
                    command.Parameters.Add("@fk_activo", SqlDbType.Int).Value = fk_activo;
                    command.Parameters.Add("@fk_persona_origen", SqlDbType.Int).Value = fk_persona_origen;
                    command.Parameters.Add("@fk_persona_destino", SqlDbType.Int).Value = fk_persona_destino;
                    command.Parameters.Add("@fkc_estado_proceso", SqlDbType.Int).Value = fkc_estado_proceso;
                    command.Parameters.Add("@fkc_estado_activo", SqlDbType.Int).Value = fkc_estado_activo;
                    command.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = observaciones;
                    command.Parameters.Add("@fk_asignacion_por_transferencia_detalle", SqlDbType.Int).Value = fk_asignacion_por_transferencia_detalle;
                    command.Parameters.Add("@fk_asignacion_detalle", SqlDbType.Int).Value = fk_asignacion_detalle;

                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = userName;
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                     "insert into asignaciones_por_transferencias_detalle " +
                     "(fk_asignacion_por_transferencia_maestro,fk_activo,fk_persona_origen,fk_persona_destino,fkc_estado_proceso,fkc_estado_activo,observaciones,fk_asignacion_por_transferencia_detalle,fk_asignacion_detalle,activo,usuariocreacion,fechacreacion) " +
                     "values(@fk_asignacion_por_transferencia_maestro,@fk_activo,@fk_persona_origen,@fk_persona_destino,@fkc_estado_proceso,@fkc_estado_activo,@observaciones,@fk_asignacion_por_transferencia_detalle,@fk_asignacion_detalle,@activo,@usuariocreacion,@fechacreacion)";

                    command.ExecuteNonQuery();

                    ///Actualiza el estado de proceso de un activo de asignado a pre asignado
                    command.CommandText =
                     "update activos set fkc_estado_proceso = 9 " +//9 = clasificador pre asignado
                     "where id=@fk_activo";

                    command.ExecuteNonQuery();


                    ///Actualiza el estado fisico del activo
                    command.CommandText =
                     "update activos set fkc_estado_activo = " + fkc_estado_activo + " " +
                     "where id=@fk_activo";

                    command.ExecuteNonQuery();


                    ///Actualiza el estado de proceso de transferencias detalle a pre transferido: 16 ESTADO PRE TRANSFERIDO
                    command.CommandText =
                     "update asignaciones_por_transferencias_detalle set fkc_estado_proceso=16 " +
                     "where id=@fk_asignacion_por_transferencia_detalle";

                    command.ExecuteNonQuery();



                    /// Attempt to commit the transaction.
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
        /// Elimina un activo transferido y vuelve al estado anterior
        /// </summary>
        /// <param name="idTransferencia"></param>
        /// <returns></returns>
        public int EliminaTransferenciaPorActivo(int idTransferencia)
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

                    ///Elimina el detalle de transferencia por id
                    command.CommandText =
                     "update asignaciones_por_transferencias_detalle "+
                     "set activo=0,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' where id=" + idTransferencia + "";

                    command.ExecuteNonQuery();

                    ///Obtiene si el origen del detalle de transferencia es de asignacion o de la misma transferencia
                     command.CommandText =
                     "select case when fk_asignacion_por_transferencia_detalle is null then '0' else 1 end "+
			         "from asignaciones_por_transferencias_detalle "+
                     "where id=" + idTransferencia + "";

                     int resultTabla=int.Parse(command.ExecuteScalar().ToString());

                    ///cuando es por asignacion_detalle
                     if (resultTabla == 0)
                     {
                         ///Cambia el estado proceso a asignado en la tabla asignacion detalle
                         command.CommandText =
                         "update asignaciones_detalle set fkc_estado_proceso=10,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                         "where id=(select fk_asignacion_detalle " +
                                   "from asignaciones_por_transferencias_detalle " +
                                   "where id=" + idTransferencia + ")";

                         command.ExecuteNonQuery();

                         ///Cambia el estado de la tabla activos el estado a asignado y el estado fisico al anterior encontrado en la tabla de asignacion_detalle
                         command.CommandText =
                        "update activos set fkc_estado_proceso=10, fkc_estado_activo=(select fkc_estado_activo from asignaciones_detalle where id=(select fk_asignacion_detalle from asignaciones_por_transferencias_detalle where id=" + idTransferencia + ")),usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                        "where id=( select fk_activo " +
                               "from asignaciones_por_transferencias_detalle " +
                               "where id=" + idTransferencia + ")";

                         command.ExecuteNonQuery();
                     }
                     else
                     {
                         ///Cambia el estado proceso a asignado en la tabla asignaciones_por_transferencias_detalle
                         command.CommandText =
                            "update asignaciones_por_transferencias_detalle set fkc_estado_proceso=10,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                            "where id=(select fk_asignacion_por_transferencia_detalle " +
                                      "from asignaciones_por_transferencias_detalle " +
                                      "where id=" + idTransferencia + ")";

                         command.ExecuteNonQuery();

                         ///Cambia el estado de la tabla activos el estado a asignado y el estado fisico al anterior encontrado en la tabla de asignaciones_por_transferencias_detalle
                         command.CommandText =
                        "update activos set fkc_estado_proceso=10, fkc_estado_activo=(select fkc_estado_activo from asignaciones_por_transferencias_detalle where id=(select fk_asignacion_por_transferencia_detalle from asignaciones_por_transferencias_detalle where id="+idTransferencia+")),usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                        "where id=( select fk_activo " +
                               "from asignaciones_por_transferencias_detalle " +
                               "where id=" + idTransferencia + ")";

                         command.ExecuteNonQuery();
                     }

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


        public int obtieneCountTransferenciasInternas()
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
                    command.CommandText =
                        "select COUNT(*) from asignaciones_por_transferencias_detalle where activo=1 ";
                    return int.Parse(command.ExecuteScalar().ToString());
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
    }
}