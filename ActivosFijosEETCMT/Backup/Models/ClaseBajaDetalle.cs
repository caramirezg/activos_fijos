using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ActivosFijos.Models;
using System.Data.SqlClient;

namespace ActivosFijosEETC.Models
{
    public class ClaseBajaDetalle
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        public DataTable List_datosActivos(int fk_baja_maestro)
        {
            string query =
            "select row_number() over (order by vista.codigo) id,vista.* "+
             "from ( "+
             "select a.id id_activo,a.codigo,a.descripcion,a.serie,a.f_ult_act_dep from asignaciones_detalle d " +
             "inner join activos a on a.id=d.fk_activo "+
             "where d.activo=1 and d.fkc_estado_proceso=10 "+
             "union "+
             "select a.id,a.codigo,a.descripcion,a.serie,a.f_ult_act_dep from asignaciones_por_transferencias_detalle d " +
             "inner join activos a on a.id=d.fk_activo "+
             "where d.activo=1 and d.fkc_estado_proceso=10) vista "+
             "where vista.id_activo not in (select d.fk_activo from bajas_detalle d "+
                           "where d.activo=1 and fk_baja_maestro="+fk_baja_maestro+")";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }

        public DataTable List_datosActivosDadosDeBaja(int fk_baja_maestro)
        {

            string query = "select d.id,a.codigo,a.descripcion,a.serie,d.fkc_estado_proceso,c.nombre estado_proceso,d.observaciones from bajas_detalle d "+
                           "inner join activos a on a.id=d.fk_activo "+
                           "inner join clasificadores c on c.id=d.fkc_estado_proceso "+
                           "where d.activo=1 and d.fk_baja_maestro="+fk_baja_maestro+"";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }


        /// <summary>
        /// Crea un registro de detalle de baja
        /// </summary>
        /// <param name="fk_baja_maestro"></param>
        /// <param name="fk_activo"></param>
        /// <param name="observaciones"></param>
        /// <param name="fkc_estado_proceso"></param>
        /// <returns></returns>
        public int CreaBajaDetalle(int fk_baja_maestro, int fk_activo, string observaciones)
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
                    command.Parameters.Add("@fk_baja_maestro", SqlDbType.Int).Value = fk_baja_maestro;
                    command.Parameters.Add("@fk_activo", SqlDbType.Int).Value = fk_activo;
                    command.Parameters.Add("@observaciones", SqlDbType.NVarChar).Value = observaciones;
                    command.Parameters.Add("@fkc_estado_proceso", SqlDbType.Int).Value = 24;

                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                     "insert into bajas_detalle "+
                     "(fk_baja_maestro,fk_activo,observaciones,fkc_estado_proceso,activo,usuariocreacion,fechacreacion) "+
                     "values(@fk_baja_maestro,@fk_activo,@observaciones,@fkc_estado_proceso,@activo,@usuario,@fecha)";

                    command.ExecuteScalar();


                    ///Actualiza de la tabla activos el estado proceso a pre baja
                    command.CommandText =
                       "update activos set fkc_estado_proceso=24, usuariomodificacion=@usuario,fechamodificacion=@fecha " +
                       "where id in (select fk_activo from bajas_detalle where activo=1 and fk_baja_maestro=@fk_baja_maestro)";
                    command.ExecuteScalar();

                    ///Actualiza de la asignacion detalle el estado proceso a pre baja los que esten en estado asignado
                    command.CommandText =
                      "update asignaciones_detalle set fkc_estado_proceso=24, usuariomodificacion=@usuario, fechamodificacion=@fecha " +
                      "where fk_activo in (select fk_activo from bajas_detalle where activo=1 and fk_baja_maestro=@fk_baja_maestro) " +
                      "and fkc_estado_proceso=10 and activo=1";
                    command.ExecuteScalar();

                    ///Actualiza la tabla asignacion por transferencia detalle el estado proceso a pre baja cuando el estado proceso esta en estado asignado
                    command.CommandText =
                     "update asignaciones_por_transferencias_detalle set fkc_estado_proceso=24,usuariomodificacion=@usuario, fechamodificacion=@fecha " +
                     "from asignaciones_por_transferencias_detalle " +
                     "where fk_activo in (select fk_activo from bajas_detalle where activo=1 and fk_baja_maestro=@fk_baja_maestro) " +
                     "and fkc_estado_proceso=10 and activo=1";
                    command.ExecuteScalar();


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

        public int EliminaBajaDetalle(int id_baja_detalle)
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

                    command.Parameters.Add("@id", SqlDbType.Int).Value = id_baja_detalle;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Now;

                    ///Vuelve de la tabla activos el estado proceso a aprobado
                    command.CommandText =
                       "update activos set fkc_estado_proceso=10, usuariomodificacion=@usuario,fechamodificacion=@fecha " +
                       "where id = (select fk_activo from bajas_detalle where activo=1 and id=@id)";
                    command.ExecuteScalar();

                    ///Vuelve de la asignacion detalle el estado proceso a asignado los que esten en estado pre baja
                    command.CommandText =
                      "update asignaciones_detalle set fkc_estado_proceso=10, usuariomodificacion=@usuario, fechamodificacion=@fecha " +
                      "where fk_activo = (select fk_activo from bajas_detalle where activo=1 and id=@id) " +
                      "and fkc_estado_proceso=24 and activo=1";
                    command.ExecuteScalar();

                    ///Vuelve la tabla asignacion por transferencia detalle el estado proceso a asignado cuando el estado proceso esta en estado pre baja
                    command.CommandText =
                     "update asignaciones_por_transferencias_detalle set fkc_estado_proceso=10,usuariomodificacion=@usuario, fechamodificacion=@fecha " +
                     "from asignaciones_por_transferencias_detalle " +
                     "where fk_activo = (select fk_activo from bajas_detalle where activo=1 and id=@id) " +
                     "and fkc_estado_proceso=24 and activo=1";
                    command.ExecuteScalar();

                    command.CommandText =
                      "update bajas_detalle set activo=0, usuariomodificacion=@usuario,fechamodificacion=@fecha " +
                      "where id=@id";

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


        public int obtieneCountBajas()
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
                        "select COUNT(*) from bajas_detalle where fkc_estado_proceso=25 and activo=1";
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