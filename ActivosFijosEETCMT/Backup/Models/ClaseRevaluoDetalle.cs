using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;
using System.Data.SqlClient;

namespace ActivosFijosEETC.Models
{
    public class ClaseRevaluoDetalle
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        public DataTable List_datosActivos()
        {
            string query =
            "select row_number() over (order by vista.codigo) id,vista.* "+
             "from ( "+ 
             "select a.id fk_activo,a.codigo,a.descripcion,a.serie,a.valor_inicial,a.valor_neto,a.f_ult_act_dep,a.costo_actualizado_inicial from asignaciones_detalle d "+
             "inner join activos a on a.id=d.fk_activo "+
             "where d.activo=1 and d.fkc_estado_proceso=10 "+
             "union "+
             "select a.id,a.codigo,a.descripcion,a.serie,a.valor_inicial,a.valor_neto,a.f_ult_act_dep,a.costo_actualizado_inicial from asignaciones_por_transferencias_detalle d "+
             "inner join activos a on a.id=d.fk_activo "+
             "where d.activo=1 and d.fkc_estado_proceso=10) vista ";
             
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }


        public DataTable List_datosActivosRevaluados(int fk_revaluo_maestro)
        {
            string query =
            "select d.id,d.fk_activo, a.codigo,a.descripcion,a.serie,d.costo_antiguo,d.costo_revaluo,d.nuevo_costo,d.nueva_vida_util,d.costo_actualizado_inicial_anterior,d.observaciones, fkc_estado_revaluo,(select c.nombre from clasificadores c where c.id=fkc_estado_revaluo) estado_revaluo "+
                           "from revaluos_detalle d "+
                           "inner join activos a on a.id=d.fk_activo "+
                           "where d.fk_revaluo_maestro="+fk_revaluo_maestro+" and d.activo=1";

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }


        public int CreaRevaluoDetalle(int fk_revaluo_maestro, int fk_activo, decimal costo_antiguo, decimal costo_revaluo, int nueva_vida_util, string observaciones, decimal costo_actualizado_inicial_anterior)
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
                    command.Parameters.Add("@fk_revaluo_maestro", SqlDbType.Int).Value = fk_revaluo_maestro;
                    command.Parameters.Add("@fk_activo", SqlDbType.Int).Value = fk_activo;
                    command.Parameters.Add("@costo_antiguo", SqlDbType.Decimal).Value = costo_antiguo;
                    command.Parameters.Add("@costo_revaluo", SqlDbType.Decimal).Value = costo_revaluo;
                    command.Parameters.Add("@nueva_vida_util", SqlDbType.Int).Value = nueva_vida_util;
                    command.Parameters.Add("@fkc_estado_revaluo", SqlDbType.Int).Value = 26;//26 = PRE REVALUADO
                    command.Parameters.Add("@observaciones", SqlDbType.NVarChar).Value = observaciones;
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Now;

                    command.Parameters.Add("@costo_actualizado_inicial_anterior", SqlDbType.Decimal).Value = costo_actualizado_inicial_anterior;
                    


                    command.CommandText =
                     "insert into revaluos_detalle " +
                     "(fk_revaluo_maestro,fk_activo,costo_antiguo,costo_revaluo,nuevo_costo,nueva_vida_util,fkc_estado_revaluo,observaciones,costo_actualizado_inicial_anterior,activo,usuariocreacion,fechacreacion) " +
                     "values(@fk_revaluo_maestro,@fk_activo,@costo_antiguo,@costo_revaluo,@costo_antiguo+@costo_revaluo,@nueva_vida_util,@fkc_estado_revaluo,@observaciones,@costo_actualizado_inicial_anterior,@activo,@usuario,@fecha)";

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


        public int EliminaRevaluoDetalle(int id_revaluo_detalle)
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

                    command.Parameters.Add("@id", SqlDbType.Int).Value = id_revaluo_detalle;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Now;

                   
                    command.CommandText =
                      "update revaluos_detalle set activo=0, usuariomodificacion=@usuario,fechamodificacion=@fecha " +
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



        public int obtieneCountRevaluo()
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
                        "select COUNT(*) from revaluos_detalle where fkc_estado_revaluo=27 and activo=1";
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