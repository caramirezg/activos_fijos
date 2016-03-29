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
    public class ClaseRevaluoMaestro
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        public DataTable List_datosRevaluoMaestro()
        {

            string query = "select m.id,RIGHT('00000000' + cast(m.correlativo as nvarchar(10)),7)+'/'+cast(year(m.f_revaluo)as nvarchar(4)) correlativo,m.f_revaluo,motivo_revaluo,disposicion_respaldo,fkc_estado_revaluo,(select c.nombre from clasificadores c where c.id=fkc_estado_revaluo) estado_revaluo "+
                            "from revaluos_maestro m "+
                            "where m.activo=1 order by m.fkc_estado_revaluo, m.f_revaluo desc, m.correlativo desc";

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }


        public int CreaRevaluoMaestro(DateTime f_revaluo, string motivo_revaluo, string disposicion_respaldo)
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
                    command.Parameters.Add("@f_revaluo", SqlDbType.Date).Value = f_revaluo;
                    command.Parameters.Add("@motivo_revaluo", SqlDbType.NVarChar).Value = motivo_revaluo;
                    command.Parameters.Add("@fkc_estado_revaluo", SqlDbType.Int).Value = 26;//26 : ESTADO PRE REVALUADO
                    command.Parameters.Add("@disposicion_respaldo", SqlDbType.NVarChar).Value = disposicion_respaldo;

                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "insert into revaluos_maestro " +
                        "(f_revaluo,motivo_revaluo,disposicion_respaldo,fkc_estado_revaluo,activo,usuariocreacion,fechacreacion) " +
                        "OUTPUT INSERTED.ID values(@f_revaluo,@motivo_revaluo,@disposicion_respaldo,@fkc_estado_revaluo,@activo,@usuariocreacion,@fechacreacion)";


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


        public int apruebaRevaluo(int id_revaluo_maestro, DateTime fecha_revaluo)
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
                    command.Parameters.Add("@id_revaluo_maestro", SqlDbType.Int).Value = id_revaluo_maestro;
                    command.Parameters.Add("@fecha_revaluo", SqlDbType.Date).Value = fecha_revaluo;
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;

                    ///Actualiza el estado del maestro a REVALUADO y asigna un correlativo
                    command.CommandText =
                        "update revaluos_maestro set correlativo=(select isnull(max(correlativo),0)+1 from revaluos_maestro where activo =1 and year(f_revaluo)=year(@fecha_revaluo)), fkc_estado_revaluo=27, usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion " +
                        "where id=@id_revaluo_maestro";
                    command.ExecuteNonQuery();

                    ///Actualiza el detalle a estado REVALUADO
                    command.CommandText =
                        "update revaluos_detalle set fkc_estado_revaluo=27, usuariomodificacion=@usuario, fechamodificacion=@fechamodificacion " +
                        "where fk_revaluo_maestro=@id_revaluo_maestro and activo = 1";
                    command.ExecuteNonQuery();

                    ///Actualiza en la tabla activos el valor antes del revaluo y la nueva vida util
                    command.CommandText =
                          "update a set a.costo_actualizado_inicial_anterior=a.costo_actualizado_inicial,a.nueva_vida_util=d.nueva_vida_util " +
                          "from activos a " +
                          "inner join revaluos_detalle d on d.fk_activo=a.id " +
                          "where a.activo=1 and d.activo=1 and fk_revaluo_maestro=@id_revaluo_maestro";
                    command.ExecuteNonQuery();

                    ///Actualiza en la tabla activos el costo actualizado inicial al nuevo costo revaluado
                    command.CommandText =
                        "update a set a.costo_actualizado_inicial=d.nuevo_costo " +
                          "from activos a " +
                          "inner join revaluos_detalle d on d.fk_activo=a.id " +
                          "where a.activo=1 and d.activo=1 and fk_revaluo_maestro=@id_revaluo_maestro";
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


        public int eliminaRevaluo(int id_revaluo_maestro)
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
                    command.Parameters.Add("@id_revaluo_maestro", SqlDbType.Int).Value = id_revaluo_maestro;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    ///Elimina el maestro de baja
                    command.CommandText =
                        "update revaluos_maestro set activo=0,usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion " +
                        "where id=@id_revaluo_maestro";
                    command.ExecuteScalar();

                    ///Elimina el detalle de baja
                    command.CommandText =
                        "update revaluos_detalle set activo=0, usuariomodificacion=@usuario, fechamodificacion=@fechamodificacion " +
                        "where fk_revaluo_maestro=@id_revaluo_maestro and activo = 1";
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


        public DataSet ReporteRevaluo(int idMaestroRevaluo)
        {
            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);


            DataTable TablaMaestro = new DataTable();
            DataTable TablaDetalle = new DataTable();
            dsRevaluoTecnico dsRevaluo = new dsRevaluoTecnico();


            dsRevaluo.Tables["revaluo_maestro"].Clear();
            dsRevaluo.Tables["revaluo_detalle"].Clear();

            string queryMaestro = "select id,f_revaluo,correlativo,motivo_revaluo,disposicion_respaldo "+
                                   "from revaluos_maestro where id=" + idMaestroRevaluo + "";

            string queryDetalle = "select d.id,d.fk_revaluo_maestro,a.codigo,a.descripcion,a.serie,d.nuevo_costo,d.nueva_vida_util,d.observaciones "+
                                   "from revaluos_detalle d "+
                                   "inner join activos a on a.id=d.fk_activo "+
                                   "where d.fk_revaluo_maestro=" + idMaestroRevaluo + " " +
                                   "and d.activo=1";


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
                string f_revaluo = rowMaestro["f_revaluo"].ToString();
                string motivo_revaluo = rowMaestro["motivo_revaluo"].ToString();
                string disposicion_respaldo = rowMaestro["disposicion_respaldo"].ToString();

                dsRevaluo.Tables["revaluo_maestro"].Rows.Add(new object[] {
                    id_maestro,
                    f_revaluo,
                    correlativo_maestro,
                    motivo_revaluo,
                    disposicion_respaldo,
                    iniciales,
                    official
                    
                });
                TablaDetalle.Clear();
                TablaDetalle = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryDetalle).Tables[0];
                foreach (DataRow rowDetalle in TablaDetalle.Rows)
                {
                    string id = rowDetalle["id"].ToString();
                    string fk_maestro = rowDetalle["fk_revaluo_maestro"].ToString();
                    string codigo = rowDetalle["codigo"].ToString();
                    string descripcion = rowDetalle["descripcion"].ToString();
                    string serie = rowDetalle["serie"].ToString();
                    string nuevo_costo = rowDetalle["nuevo_costo"].ToString();
                    string nueva_vida_util = rowDetalle["nueva_vida_util"].ToString();
                    string observaciones = rowDetalle["observaciones"].ToString();


                    dsRevaluo.Tables["revaluo_detalle"].Rows.Add(new object[] {
                      id,
                      fk_maestro,
                      codigo,
                      descripcion,
                      serie,
                      nuevo_costo,
                      nueva_vida_util,
                      observaciones
                    });
                }
            }
            return dsRevaluo;
        }

    }
}