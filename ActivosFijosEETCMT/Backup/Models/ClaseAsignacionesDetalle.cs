using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;
using System.Data.SqlClient;

namespace ActivosFijosEETC.Models
{
    public class ClaseAsignacionesDetalle
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Crea un registro de detalle de asignacion
        /// </summary>
        /// <param name="fk_asignacion_maestro"></param>
        /// <param name="fk_activo"></param>
        /// <param name="fk_persona"></param>
        /// <param name="fkc_estado_proceso"></param>
        /// <param name="fkc_estado_activo"></param>
        /// <param name="observaciones"></param>
        /// <returns></returns>
        public int CreaAsignacionDetalle(int fk_asignacion_maestro,int fk_activo, string fk_persona,int fkc_estado_proceso, int fkc_estado_activo, string observaciones)
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

                    command.Parameters.Add("@fk_asignacion_maestro", SqlDbType.Int).Value = fk_asignacion_maestro;
                    command.Parameters.Add("@fk_activo", SqlDbType.Int).Value = fk_activo;
                    command.Parameters.Add("@fk_persona", SqlDbType.VarChar).Value = fk_persona.Trim();
                    command.Parameters.Add("@fkc_estado_proceso", SqlDbType.Int).Value = fkc_estado_proceso;
                    command.Parameters.Add("@fkc_estado_activo", SqlDbType.Int).Value = fkc_estado_activo;
                    command.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = observaciones;
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = userName;
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                     "insert into asignaciones_detalle " +
                     "(fk_asignacion_maestro,fk_activo,fk_persona,fkc_estado_proceso,fkc_estado_activo,observaciones,activo,usuariocreacion,fechacreacion) " +
                     "values(@fk_asignacion_maestro,@fk_activo,@fk_persona,@fkc_estado_proceso,@fkc_estado_activo,@observaciones,@activo,@usuariocreacion,@fechacreacion)";

                    command.ExecuteNonQuery();

                    //Actualiza el estado de proceso de un activo de aprobado a pre asignado
                    command.CommandText =
                     "update activos set fkc_estado_proceso = 9 "+//9 = clasificador pre asignado
                     "where id=@fk_activo";

                    command.ExecuteNonQuery();


                    //Actualiza el estado de activo
                    command.CommandText =
                     "update activos set fkc_estado_activo = " + fkc_estado_activo + " " +//9 = clasificador pre asignado
                     "where id=@fk_activo";

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
        /// Obtiene la lista de los activos pre asignados y asignados
        /// </summary>
        /// <returns></returns>
        public List<AsignacionesDetalleEntity> List_datosAsignacionesDetalle(int fk_asignacion_maestro)
        {
            string query = "select id,fk_asignacion_maestro,fk_activo,fk_persona,fkc_estado_proceso,fkc_estado_activo,observaciones,activo, "+
                            "(select codigo from activos a where a.id=fk_activo) codigo, "+
                            "(select descripcion from activos a where a.id=fk_activo) descripcion, " +
                            "(select nombre from clasificadores c where c.id=fkc_estado_activo) estado_activo, "+
		                    "(select nombre from clasificadores c where c.id=fkc_estado_proceso) estado_proceso "+
                            "from asignaciones_detalle "+
                            "where activo=1 and fk_asignacion_maestro="+fk_asignacion_maestro+"";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<AsignacionesDetalleEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                                     orderby AnyName.Field<int>("id")
                                                     select new AsignacionesDetalleEntity()
                                                     {
                                                         id = AnyName.Field<int>("id"),
                                                         fk_asignacion_maestro = AnyName.Field<int>("fk_asignacion_maestro"),
                                                         fk_activo = AnyName.Field<int>("fk_activo"),
                                                         codigo = AnyName.Field<string>("codigo"),
                                                         descripcion = AnyName.Field<string>("descripcion"),
                                                         fk_persona = AnyName.Field<string>("fk_persona"),
                                                         fkc_estado_proceso = AnyName.Field<int>("fkc_estado_proceso"),
                                                         estado_proceso = AnyName.Field<string>("estado_proceso"),
                                                         fkc_estado_activo = AnyName.Field<int>("fkc_estado_activo"),
                                                         estado_activo = AnyName.Field<string>("estado_activo"),
                                                         observaciones = AnyName.Field<string>("observaciones"),
                                                         activo = AnyName.Field<int>("activo")
                                                     }).ToList();
            return Lista;
        }

        /// <summary>
        /// Elimina un registro de asignacion y vuelve el estado de proceso en activos de pre asignado a aprobado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fk_activo"></param>
        /// <returns></returns>
        public int EliminaAsignacionPorActivo(int idAsignacion,int fk_activo)
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

                    command.Parameters.Add("@idAsignacion", SqlDbType.Int).Value = idAsignacion;
                    command.Parameters.Add("@fk_activo", SqlDbType.Int).Value = fk_activo;

                    command.CommandText =
                     "update asignaciones_detalle set activo=0, usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' where id=@idAsignacion";

                    command.ExecuteNonQuery();
                    command.CommandText =
                     "update activos set fkc_estado_proceso=5, "+//5= clasificador estado proceso aprobado;
                     "usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' "+
                     "where id=@fk_activo";
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

        public decimal activosAsignados()
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
                        "select COUNT(*) from activos where fkc_estado_proceso in(10,24,25) and activo=1";
                    return decimal.Parse(command.ExecuteScalar().ToString());
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
        /// Obtiene los porcentajes de activos asignados y no asignados
        /// </summary>
        /// <returns></returns>
        public DataTable List_datosPorcentajesAsignados()
        {
            string query = "select cast(cast(count(*)as decimal(18,2))*100/(select cast(count(*) as decimal(18,2)) "+
					                             "from activos where activo=1) as decimal(18,2)) "+
                            "from activos "+
                            "where activo=1 and fkc_estado_proceso=10 "+
                            "union "+
                            "select cast(cast(count(*)as decimal(18,2))*100/(select cast(count(*) as decimal(18,2)) "+
					                             "from activos where activo=1) as decimal(18,2)) "+
                            "from activos "+
                            "where activo=1 and fkc_estado_proceso!=10";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }


        

    }
}