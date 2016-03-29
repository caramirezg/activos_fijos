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
    public class ClaseTransferencia
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de las tranferencias vigentes
        /// </summary>
        /// <returns></returns>
        public List<TransferenciaEntity> List_datosTransferencias()
        {
            string query = "select id,RIGHT('00000000' + cast(correlativo as nvarchar(10)),7)+'/'+cast(year(f_transferencia)as nvarchar(4)) correlativo ,descripcion,f_transferencia,origen,tasa_sus,tasa_ufv,fkc_estado_proceso, "+
                            "(select ca.nombre from clasificadores ca where ca.id=fkc_estado_proceso) estado_proceso, "+
                            "isnull((select sum(valor_inicial) from activos a where a.activo=1 and a.fk_transferencia is not null and fk_transferencia=t.id),0) monto_bs, "+
                            "doc_respaldo,activo from transferencias t where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<TransferenciaEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                               orderby AnyName.Field<int>("fkc_estado_proceso"), AnyName.Field<DateTime>("f_transferencia") descending, AnyName.Field<string>("correlativo") descending
                                               select new TransferenciaEntity()
                                               {
                                                   id = AnyName.Field<int>("id"),
                                                   correlativo = AnyName.Field<string>("correlativo"),
                                                   descripcion = AnyName.Field<string>("descripcion"),
                                                   f_transferencia = AnyName.Field<DateTime>("f_transferencia").ToString("dd/MM/yyyy"),
                                                   origen = AnyName.Field<string>("origen"),
                                                   monto_bs = AnyName.Field<decimal>("monto_bs"),
                                                   tasa_sus = AnyName.Field<decimal>("tasa_sus"),
                                                   tasa_ufv = AnyName.Field<decimal>("tasa_ufv"),
                                                   fkc_estado_proceso = AnyName.Field<int>("fkc_estado_proceso"),
                                                   estado_proceso = AnyName.Field<string>("estado_proceso"),
                                                   doc_respaldo = AnyName.Field<string>("doc_respaldo"),
                                                   activo = AnyName.Field<int>("activo")
                                               }).ToList();
            return Lista;
        }

        /// <summary>
        /// Crea un registro de transferencia
        /// </summary>
        /// <param name="correlativo"></param>
        /// <param name="descripcion"></param>
        /// <param name="f_transferencia"></param>
        /// <param name="origen"></param>
        /// <returns></returns>
        public int CreaTransferencia(string correlativo,string descripcion, string f_transferencia, string origen,string tasa_sus, string tasa_ufv,int fkc_estado_proceso,string doc_respaldo)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "insert into transferencias " +
                "(correlativo,descripcion,f_transferencia,origen,tasa_sus,tasa_ufv,fkc_estado_proceso,doc_respaldo,activo,usuariocreacion,fechacreacion) " +
                "OUTPUT INSERTED.ID values('" + correlativo + "','" + descripcion + "','" + f_transferencia + "','" + origen + "'," + tasa_sus + "," + tasa_ufv + "," + fkc_estado_proceso + ",'" + doc_respaldo + "',1,'" + userName + "','" + DateTime.Now + "')";
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, insert).ToString());

                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }

        }
        /// <summary>
        /// Apruba una transferencia en estado elaborado ademas de sus activos asignados
        /// </summary>
        /// <param name="fk_transferencia"></param>
        /// <returns></returns>
        public int ApruebaTransferencia(int fk_transferencia,DateTime f_transferencia)
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

                    command.CommandText =
                        "update transferencias set fkc_estado_proceso=5,correlativo=(select isnull(max(correlativo)+1,1) from transferencias where activo=1 and year(f_transferencia)=year('" + f_transferencia + "')), usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                        "where id=" + fk_transferencia + " " + 
                        "and activo=1 ";
                    command.ExecuteNonQuery();
                    command.CommandText =
                       "update activos set fkc_estado_proceso=5,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "'  " +
                        "where fk_transferencia=" + fk_transferencia + " " +
                        "and activo=1";
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
        /// Elimina un registro de transferncia en estado elaborado y sus activos asignados en estado elaborado
        /// </summary>
        /// <param name="fk_transferencia"></param>
        /// <returns></returns>
        public int EliminaTransferencia(int fk_transferencia)
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

                    command.CommandText =
                        "update transferencias set activo=0,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' where id=" + fk_transferencia + "";
                    command.ExecuteNonQuery();
                    command.CommandText =
                       "update activos set activo=0, usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' where fk_transferencia=" + fk_transferencia + "";
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
        /// Genera reporte con dataset tipado para una transferencia
        /// </summary>
        /// <param name="idTransferencia"></param>
        /// <returns></returns>
        public DataSet ReporteTransferenciaActivos(int idTransferencia)
        {
            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);
            
            DataTable TablaMaestro = new DataTable();
            DataTable TablaDetalle = new DataTable();
            dsRegistroTransferencia dsRegistroTransferencia = new dsRegistroTransferencia();


            dsRegistroTransferencia.Tables["transferencias"].Clear();
            dsRegistroTransferencia.Tables["activos"].Clear();

            string queryMaestro = "select id,correlativo,descripcion,f_transferencia,origen,doc_respaldo from transferencias where id="+idTransferencia+"";

            string queryDetalle = "select id, codigo, descripcion,valor_inicial,costo_actualizado_inicial_historico,depreciacion_acumulada_total_historico from activos where fk_transferencia=" + idTransferencia + " and activo=1 order by codigo asc";


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
                
                
                int id_Transferencia = int.Parse(rowMaestro["id"].ToString());
                //string correlativo = rowMaestro["correlativo"].ToString();
                DateTime f_transferencia = Convert.ToDateTime(rowMaestro["f_transferencia"].ToString());
                string descripcion = rowMaestro["descripcion"].ToString().ToUpper();
                string origen = rowMaestro["origen"].ToString().ToUpper();
                string doc_respaldo = rowMaestro["doc_respaldo"].ToString();


                dsRegistroTransferencia.Tables["transferencias"].Rows.Add(new object[] {
                   id_Transferencia,
                   correlativo,
                   descripcion,
                   f_transferencia.ToString("dd/MM/yyyy"),
                   origen,
                   doc_respaldo,
                   official,
                   iniciales
                     
                });
                TablaDetalle.Clear();
                TablaDetalle = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryDetalle).Tables[0];
                foreach (DataRow rowDetalle in TablaDetalle.Rows)
                {
                    int idActivo = int.Parse(rowDetalle["id"].ToString());
                    string codigo = rowDetalle["codigo"].ToString();
                    string descripcion_activo = rowDetalle["descripcion"].ToString();
                    decimal valor_inicial = decimal.Parse(rowDetalle["valor_inicial"].ToString());
                    decimal costo_actualizado_inicial = decimal.Parse(rowDetalle["costo_actualizado_inicial_historico"].ToString());
                    decimal depreciacion_acumulada_inicial = decimal.Parse(rowDetalle["depreciacion_acumulada_total_historico"].ToString());

                    dsRegistroTransferencia.Tables["activos"].Rows.Add(new object[] {
                      idActivo,
                      codigo,
                      descripcion_activo,
                      valor_inicial,
                      id_Transferencia,
                      costo_actualizado_inicial,
                      depreciacion_acumulada_inicial
                    });
                }
            }
            return dsRegistroTransferencia;
        }

        public decimal activosTransferidos()
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
                    "select COUNT(*) from activos where fk_transferencia is not null and activo=1";
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
    }
}