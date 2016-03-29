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
    public class ClaseBajaMaestro
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();


        public DataTable List_datosBajasMaestro()
        {

            string query = "select m.id,RIGHT('00000000' + cast(m.correlativo as nvarchar(10)),7)+'/'+cast(year(m.f_baja)as nvarchar(4)) correlativo,m.f_baja,fkc_motivo_baja,(select b.motivo_baja from motivos_baja b where b.id=m.fkc_motivo_baja) motivo_baja,m.fkc_estado_proceso,(select c.nombre from clasificadores c where c.id=m.fkc_estado_proceso) estado_proceso,(select count(bd.id) from bajas_detalle bd where bd.fk_baja_maestro=m.id and bd.activo=1) count_bajas,documento_respaldo " +
                            "from bajas_maestro m "+
                            "where m.activo=1 order by m.fkc_estado_proceso, m.f_baja desc,m.correlativo desc"; 

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }

        public DataTable List_datosMotivosBajas()
        {
            string query = "select id,motivo_baja from motivos_baja where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }

        /// <summary>
        /// Crea un registro de baja 
        /// </summary>
        /// <param name="f_baja"></param>
        /// <param name="fkc_motivo_baja"></param>
        /// <returns></returns>
        public int CreaBajaMaestro(DateTime f_baja, int fkc_motivo_baja, string documento_respaldo)
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
                    command.Parameters.Add("@f_baja", SqlDbType.Date).Value = f_baja;
                    command.Parameters.Add("@fkc_motivo_baja", SqlDbType.Int).Value = fkc_motivo_baja;
                    command.Parameters.Add("@fkc_estado_proceso", SqlDbType.Int).Value = 24;//24 : ESTADO PRE BAJA
                    command.Parameters.Add("@documento_respaldo", SqlDbType.NVarChar).Value = documento_respaldo;
                   
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "insert into bajas_maestro "+
                        "(f_baja,fkc_motivo_baja,fkc_estado_proceso,documento_respaldo,activo,usuariocreacion,fechacreacion) "+
                        "OUTPUT INSERTED.ID values(@f_baja,@fkc_motivo_baja,@fkc_estado_proceso,@documento_respaldo,@activo,@usuariocreacion,@fechacreacion)";
                    

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
        /// Aprueba la baja
        /// </summary>
        /// <param name="id_bajas_maestro"></param>
        /// <param name="fecha_baja"></param>
        /// <returns></returns>
        public int apruebaBaja(int id_bajas_maestro, DateTime fecha_baja)
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
                    command.Parameters.Add("@id_bajas_maestro", SqlDbType.Int).Value = id_bajas_maestro;
                    command.Parameters.Add("@fecha_baja", SqlDbType.Date).Value = fecha_baja;
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;

                    ///Actualiza el estado del maestro a baja y asigna un correlativo
                    command.CommandText =
                        "update bajas_maestro set correlativo=(select isnull(max(correlativo),0)+1 from bajas_maestro where activo =1 and year(f_baja)=year(@fecha_baja)), fkc_estado_proceso=25, usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion " +
                        "where id=@id_bajas_maestro";
                    command.ExecuteScalar();

                    ///Actualiza el detalle a estado baja
                    command.CommandText =
                        "update bajas_detalle set fkc_estado_proceso=25, usuariomodificacion=@usuario, fechamodificacion=@fechamodificacion "+
                        "where fk_baja_maestro=@id_bajas_maestro and activo = 1";
                    command.ExecuteScalar();

                    ///Actualiza de la tabla activos el estado proceso a baja
                    command.CommandText =
                       "update activos set fkc_estado_proceso=25, usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion "+
                       "where id in (select fk_activo from bajas_detalle where activo=1 and fk_baja_maestro=@id_bajas_maestro) and fkc_estado_proceso=24";
                    command.ExecuteScalar();

                    ///Actualiza de la asignacion detalle el estado proceso a baja los que esten en estado pre baja
                    command.CommandText =
                      "update asignaciones_detalle set fkc_estado_proceso=25, usuariomodificacion=@usuario, fechamodificacion=@fechamodificacion "+
                      "where fk_activo in (select fk_activo from bajas_detalle where activo=1 and fk_baja_maestro=@id_bajas_maestro) " +
                      "and fkc_estado_proceso=24 and activo=1";
                    command.ExecuteScalar();

                    ///Actualiza la tabla asignacion por transferencia detalle el estado proceso a baja cuando el estado proceso esta en estado pre baja
                    command.CommandText =
                     "update asignaciones_por_transferencias_detalle set fkc_estado_proceso=25 "+
                     "from asignaciones_por_transferencias_detalle "+
                     "where fk_activo in (select fk_activo from bajas_detalle where activo=1 and fk_baja_maestro=@id_bajas_maestro) " +
                     "and fkc_estado_proceso=24 and activo=1";
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

        /// <summary>
        /// Elimina un registro en estado pre baja
        /// </summary>
        /// <param name="id_baja_maestro"></param>
        /// <returns></returns>
        public int eliminaBaja(int id_baja_maestro)
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
                    command.Parameters.Add("@id_baja_maestro", SqlDbType.Int).Value = id_baja_maestro;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    ///Vuelve al estado asignado en la tabla de activos
                    command.CommandText =
                      "update activos set fkc_estado_proceso=10, usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion " +
                      "where id in (select fk_activo from bajas_detalle where activo=1 and fk_baja_maestro=@id_baja_maestro) and fkc_estado_proceso=24";
                    command.ExecuteScalar();

                    ///Vuelve al estado asignado en la tabla asignaciones detalle los activos que esten en estado PRE BAJA
                    command.CommandText =
                     "update asignaciones_detalle set fkc_estado_proceso=10, usuariomodificacion=@usuario, fechamodificacion=@fechamodificacion " +
                     "where fk_activo in (select fk_activo from bajas_detalle where activo=1 and fk_baja_maestro=@id_baja_maestro) " +
                     "and activo=1 and fkc_estado_proceso=24";
                    command.ExecuteScalar();

                    ///Vuelve al estado asignado en la tabla asignacion por transferencia detalle los activos que esten en estado PRE BAJA
                    command.CommandText =
                     "update asignaciones_por_transferencias_detalle set fkc_estado_proceso=10 " +
                     "from asignaciones_por_transferencias_detalle " +
                     "where fk_activo in (select fk_activo from bajas_detalle where activo=1 and fk_baja_maestro=@id_baja_maestro) " +
                     "and fkc_estado_proceso=24 and activo=1";
                    command.ExecuteScalar();

                    ///Elimina el maestro de baja
                    command.CommandText =
                        "update bajas_maestro set activo=0,usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion " +
                        "where id=@id_baja_maestro";
                    command.ExecuteScalar();

                    ///Elimina el detalle de baja
                    command.CommandText =
                        "update bajas_detalle set activo=0, usuariomodificacion=@usuario, fechamodificacion=@fechamodificacion " +
                        "where fk_baja_maestro=@id_baja_maestro and activo = 1";
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

        public DataSet ReporteBaja(int idMaestroBaja)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);


            DataTable TablaMaestro = new DataTable();
            DataTable TablaDetalle = new DataTable();
            dsBajas dsBaja = new dsBajas();


            dsBaja.Tables["baja_maestro"].Clear();
            dsBaja.Tables["baja_detalle"].Clear();

            string queryMaestro = "select m.id,m.correlativo,m.f_baja,m.fkc_motivo_baja,(select motivo_baja from motivos_baja b where b.id=m.fkc_motivo_baja) motivo_baja "+
                                   "from bajas_maestro m "+
                                   "where m.activo=1 and m.id=" + idMaestroBaja + "";

            string queryDetalle = "select d.id,d.fk_baja_maestro,a.codigo,a.descripcion,a.serie,d.observaciones "+
                                   "from bajas_detalle d "+
                                   "inner join activos a on a.id=d.fk_activo "+
                                   "where d.activo=1 and d.fk_baja_maestro=" + idMaestroBaja + "";


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

                int id_maestro = int.Parse(rowMaestro["id"].ToString());
                string correlativo_maestro = rowMaestro["correlativo"].ToString();
                string f_baja = rowMaestro["f_baja"].ToString();
                string motivo_baja = rowMaestro["motivo_baja"].ToString();



                dsBaja.Tables["baja_maestro"].Rows.Add(new object[] {
                    id_maestro,
                    correlativo_maestro,
                    f_baja,
                    motivo_baja,
                    official,
                    iniciales
                });
                TablaDetalle.Clear();
                TablaDetalle = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryDetalle).Tables[0];
                foreach (DataRow rowDetalle in TablaDetalle.Rows)
                {
                    string id = rowDetalle["id"].ToString();
                    string fk_maestro = rowDetalle["fk_baja_maestro"].ToString();
                    string codigo = rowDetalle["codigo"].ToString();
                    string descripcion = rowDetalle["descripcion"].ToString();
                    string serie = rowDetalle["serie"].ToString();
                    string observaciones = rowDetalle["observaciones"].ToString();


                    dsBaja.Tables["baja_detalle"].Rows.Add(new object[] {
                      id,
                      fk_maestro,
                      codigo,
                      descripcion,
                      serie,
                      observaciones
                    });
                }
            }
            return dsBaja;
        }

    }
}