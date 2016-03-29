using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;
using System.Data.SqlClient;

namespace ActivosFijosEETC.Models
{
    public class ClaseInventarioMaestro
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();


        public List<InventarioMaestroEntity> List_datosInventarioMaestro()
        {
            string query = "select id,descripcion,f_inventario,fkc_estado_inventario,(select nombre from clasificadores c where c.id=fkc_estado_inventario)estado,documento_respaldo,f_conclusion,activo from inventario_maestro where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<InventarioMaestroEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                                   select new InventarioMaestroEntity()
                                               {
                                                   id = AnyName.Field<int>("id"),
                                                   descripcion = AnyName.Field<string>("descripcion"),
                                                   f_inventario = AnyName.Field<DateTime>("f_inventario").ToString("dd/MM/yyyy"),
                                                   fkc_estado_inventario = AnyName.Field<int>("fkc_estado_inventario"),
                                                   estado_inventario = AnyName.Field<string>("estado"),
                                                   documento_respaldo = AnyName.Field<string>("documento_respaldo"),
                                                   f_conclusion = AnyName.Field<DateTime>("f_conclusion").ToString("dd/MM/yyyy")
                                               }).ToList();
            return Lista;
        }


        /// <summary>
        /// Crea un nuevo registro de inventario
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public int CreaMaestroInventario(string descripcion, DateTime fecha, string documentoRespaldo)
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

                    command.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
                    command.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                    command.Parameters.Add("@documento_respaldo", SqlDbType.NVarChar).Value = documentoRespaldo;

                    command.CommandText =
                     "insert into inventario_maestro " +
                     "(descripcion,f_inventario,f_conclusion,fkc_estado_inventario,documento_respaldo,activo,usuariocreacion,fechacreacion) " +
                     "OUTPUT INSERTED.ID values(@descripcion,@fecha,'',13,@documento_respaldo,1,'" + userName + "','" + DateTime.Now + "')";

                    int result =int.Parse(command.ExecuteScalar().ToString());

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

        public int CerrarInventario(int fk_inventario_maestro,DateTime fecha_conclusion)
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
                        "update inventario_maestro set fkc_estado_inventario=14,f_conclusion='"+fecha_conclusion+"',usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                        "where id=" + fk_inventario_maestro + " ";

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


    }

    
        

}