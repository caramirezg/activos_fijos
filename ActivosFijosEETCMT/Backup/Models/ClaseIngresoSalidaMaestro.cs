using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ActivosFijos.Models;

namespace ActivosFijosEETC.Models
{
    public class ClaseIngresoSalidaMaestro
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de maestro de ordenes de salida
        /// </summary>
        /// <returns></returns>
        public DataTable List_datosSolicitudesMaestro(int fk_persona,int vPerfil)
        {
            string query=null;
            if (vPerfil == 1)
            {
                 query = "select m.id,RIGHT('00000000' + cast(m.correlativo as nvarchar(10)),7)+'/'+cast(year(m.f_solicitud)as nvarchar(4)) correlativo,m.f_solicitud,m.f_desde,m.f_hasta,m.motivo,m.fk_persona,p.documento,p.nombres,p.apellidos,p.area,p.gerencia,m.fkc_estado_salida,c.nombre estado_salida,m.documento_autorizacion from ingresos_salidas_maestro m " +
                               "inner join personal p on p.id=m.fk_persona " +
                               "inner join clasificadores c on c.id=m.fkc_estado_salida where m.activo=1 " +
                               "order by m.fkc_estado_salida, m.f_solicitud desc,m.correlativo desc";

             
            }
            else
            {
                 query = "select m.id,RIGHT('00000000' + cast(m.correlativo as nvarchar(10)),7)+'/'+cast(year(m.f_solicitud)as nvarchar(4)) correlativo,m.f_solicitud,m.f_desde,m.f_hasta,m.motivo,m.fk_persona,p.documento,p.nombres,p.apellidos,p.area,p.gerencia,m.fkc_estado_salida,c.nombre estado_salida,m.documento_autorizacion from ingresos_salidas_maestro m " +
                                  "inner join personal p on p.id=m.fk_persona " +
                                  "inner join clasificadores c on c.id=m.fkc_estado_salida "+
                                  "where m.activo=1 and p.id=" + fk_persona + " " +
                                  "order by m.fkc_estado_salida, m.f_solicitud desc,m.correlativo desc";
            }

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }


        /// <summary>
        /// Crea el maestro de ingreso salida de activos (Solicitudes para salida de un activo)
        /// </summary>
        /// <param name="fk_persona"></param>
        /// <param name="f_solicitud"></param>
        /// <param name="f_desde"></param>
        /// <param name="f_hasta"></param>
        /// <param name="motivo"></param>
        /// <param name="fkc_estado_salida"></param>
        /// <returns></returns>
        public int CreaIngresoSalidaMaestro(int fk_persona,DateTime f_solicitud,DateTime f_desde,string f_hasta,string motivo,int fkc_estado_salida)
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
                    command.Parameters.Add("@fk_persona", SqlDbType.Int).Value = fk_persona;
                    command.Parameters.Add("@f_solicitud", SqlDbType.Date).Value = f_solicitud;
                    command.Parameters.Add("@f_desde", SqlDbType.Date).Value = f_desde;

                    if(!string.IsNullOrEmpty(f_hasta))
                        command.Parameters.Add("@f_hasta", SqlDbType.Date).Value = f_hasta;
                    else
                        command.Parameters.Add("@f_hasta", SqlDbType.Date).Value = DBNull.Value;

                    command.Parameters.Add("@motivo", SqlDbType.NVarChar).Value = motivo;
                
                    command.Parameters.Add("@fkc_estado_salida", SqlDbType.Int).Value = fkc_estado_salida;
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                     "insert into ingresos_salidas_maestro " +
                     "(fk_persona,f_solicitud,f_desde,f_hasta,motivo,fkc_estado_salida,activo,usuariocreacion,fechacreacion) " +
                     "OUTPUT INSERTED.ID values(@fk_persona,@f_solicitud,@f_desde,@f_hasta,@motivo,@fkc_estado_salida,@activo,@usuariocreacion,@fechacreacion)";

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

        public int EditaSalidaMaestro(int id, DateTime f_desde, string f_hasta, string motivo)
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

                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@f_desde", SqlDbType.Date).Value = f_desde;

                    if (!string.IsNullOrEmpty(f_hasta))
                        command.Parameters.Add("@f_hasta", SqlDbType.Date).Value = f_hasta;
                    else
                        command.Parameters.Add("@f_hasta", SqlDbType.Date).Value = DBNull.Value;

                    command.Parameters.Add("@motivo", SqlDbType.NVarChar).Value = motivo;
                    command.Parameters.Add("@usuariomodificacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "update ingresos_salidas_maestro set f_desde=@f_desde, f_hasta=@f_hasta,motivo=@motivo,usuariomodificacion=@usuariomodificacion, fechamodificacion=@fechamodificacion " +
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


        public int apruebaSalida(int id_salida_maestro,DateTime fecha_solicitud)
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
                    command.Parameters.Add("@id_salida_maestro", SqlDbType.Int).Value = id_salida_maestro;
                    command.Parameters.Add("@fecha_solicitud", SqlDbType.Date).Value = fecha_solicitud;
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "update ingresos_salidas_maestro set correlativo=(select isnull(max(correlativo),0)+1 from ingresos_salidas_maestro where activo =1 and year(f_solicitud)=year(@fecha_solicitud)), fkc_estado_salida=21,aprobado_por=@usuario,usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion where id=@id_salida_maestro";
                    command.ExecuteScalar();

                    command.CommandText =
                        "update ingresos_salidas_detalle set fkc_estado_salida=21,usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion where fk_ingresos_salidas_maestro=@id_salida_maestro";
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


        public int eliminaSalida(int id_salida_maestro)
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
                    command.Parameters.Add("@id_salida_maestro", SqlDbType.Int).Value = id_salida_maestro;

                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "update ingresos_salidas_maestro set activo=0,usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion where id=@id_salida_maestro";
                    command.ExecuteScalar();

                    command.CommandText =
                        "update ingresos_salidas_detalle set activo=0,usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion where fk_ingresos_salidas_maestro=@id_salida_maestro";
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


    
    }
}