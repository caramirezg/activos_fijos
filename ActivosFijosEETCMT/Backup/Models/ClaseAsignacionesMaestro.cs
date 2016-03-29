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
    public class ClaseAsignacionesMaestro
    {

        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        public DataTable List_datosAsignacionesMaestro()
        {

            string query = "select id,f_asignacion,RIGHT('00000000' + cast(correlativo as nvarchar(10)),7)+'/'+cast(year(f_asignacion)as nvarchar(4)) correlativo,fkc_ubicacion, " +
                            "(select nombre from clasificadores c where c.id=fkc_ubicacion) ubicacion, " +
                             "fk_persona, "+
                             "(select p.documento from personal p where p.id=fk_persona) documento, " +
                                "(select p.nombres from personal p where p.id=fk_persona) nombres, " +
                                "(select p.apellidos from personal p where p.id=fk_persona) apellidos, " +
                                "(select nombre from lineas where id=(select e.fk_linea from estaciones e where id=fk_estacion)) linea, "+
		                        "fk_estacion, "+
		                        "(select e.nombre from estaciones e where e.id=fk_estacion) estacion, "+
                                "(select p.gerencia from personal p where p.id=fk_persona) gerencia, " +
		                        "fkc_estado_proceso, "+
		                        "(select nombre from clasificadores c where c.id=fkc_estado_proceso) estado_proceso, "+
		                        "activo "+
                        "from asignaciones_maestro "+
                        "where activo=1 order by fkc_estado_proceso asc,f_asignacion desc,correlativo desc";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
          
            return dtTable;
        }
        /// <summary>
        /// Crea un maestro de asignacion
        /// </summary>
        /// <param name="f_asignacion"></param>
        /// <param name="correlativo"></param>
        /// <param name="ubicacion"></param>
        /// <param name="oficina"></param>
        /// <param name="fk_persona"></param>
        /// <param name="fk_estacion"></param>
        /// <param name="fkc_estado_proceso"></param>
        /// <returns></returns>
        public int CreaAsignacionMaestro(DateTime f_asignacion, int ubicacion, string fk_persona, string fk_estacion, int fkc_estado_proceso)
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

                    command.Parameters.Add("@f_asignacion", SqlDbType.Date).Value = f_asignacion;
                    command.Parameters.Add("@correlativo", SqlDbType.VarChar).Value = DBNull.Value;
                    command.Parameters.Add("@ubicacion", SqlDbType.Int).Value = ubicacion;
                    command.Parameters.Add("@fk_persona", SqlDbType.VarChar).Value = fk_persona;
                    if(!string.IsNullOrEmpty(fk_estacion))
                        command.Parameters.Add("@fk_estacion", SqlDbType.Int).Value = fk_estacion;
                    else
                        command.Parameters.Add("@fk_estacion", SqlDbType.Int).Value = DBNull.Value;
                    command.Parameters.Add("@fkc_estado_proceso", SqlDbType.Int).Value = fkc_estado_proceso;
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = userName;
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                     "insert into asignaciones_maestro " +
                     "(f_asignacion,correlativo,fkc_ubicacion,fk_persona,fk_estacion,fkc_estado_proceso,activo,usuariocreacion,fechacreacion) " +
                     "OUTPUT INSERTED.ID values(@f_asignacion,@correlativo,@ubicacion,@fk_persona,@fk_estacion,@fkc_estado_proceso,@activo,@usuariocreacion,@fechacreacion)";

                    result=int.Parse(command.ExecuteScalar().ToString());

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
        /// Elimina un registro de asignacion maestro en estado pre asignado
        /// </summary>
        /// <param name="idAsignacion"></param>
        /// <returns></returns>
        public int EliminaAsignacionMaestro(int idAsignacion)
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
               
                    command.CommandText =
                    "update asignaciones_maestro set activo = 0, usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' where id=@idAsignacion and activo=1 ";
                    command.ExecuteNonQuery();


                    command.CommandText =
                  "update activos set fkc_estado_proceso=5, " +//5= clasificador estado proceso aprobado;
                  "usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                  "where activo=1 and id in (select fk_activo from asignaciones_detalle where fk_asignacion_maestro=@idAsignacion and activo=1)";
                   command.ExecuteNonQuery();

                    command.CommandText =
                     "update asignaciones_detalle set activo=0, usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' where fk_asignacion_maestro=@idAsignacion and activo=1";

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
        /// Cambia el estado de Pre asignado a Asignado en asignaciones_maestro y asignaciones_detalle
        /// </summary>
        /// <param name="fk_asignacion"></param>
        /// <returns></returns>
        public int ApruebaAsignacion(int fk_asignacion)
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
                        "update asignaciones_maestro set fkc_estado_proceso=10,correlativo=(select isnull(max(correlativo)+1,1) from asignaciones_maestro where activo=1 and year(f_asignacion)=(select year(f_asignacion) from asignaciones_maestro where id=" + fk_asignacion + ")), usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                        "where id=" + fk_asignacion + " " +
                        "and activo=1 ";
                    command.ExecuteNonQuery();
                    command.CommandText =
                       "update asignaciones_detalle set fkc_estado_proceso=10,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "'  " +
                        "where fk_asignacion_maestro=" + fk_asignacion + " " +
                        "and activo=1";
                    command.ExecuteNonQuery();

                    //Actualiza el estado de proceso de un activo de pre asignado a asignado
                    command.CommandText =
                     "update activos set fkc_estado_proceso=10 "+
                         "where id in (select fk_activo from asignaciones_detalle "+
                                      "where fk_asignacion_maestro=" + fk_asignacion + " and activo=1) " +
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

        public DataSet ReporteAsignacionActivos(int idAsignacionMaestro)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);


            DataTable TablaMaestro = new DataTable();
            DataTable TablaDetalle = new DataTable();
            dsRegistroAsignacion dsRegistroAsignacion = new dsRegistroAsignacion();


            dsRegistroAsignacion.Tables["asignaciones_maestro"].Clear();
            dsRegistroAsignacion.Tables["asignaciones_detalle"].Clear();

            string queryMaestro = "select id,f_asignacion,correlativo,fkc_ubicacion,fk_persona, " +
                                    "(select nombre from clasificadores c where c.id=fkc_ubicacion) ubicacion, " +
                                        "(select nombres from personal p where p.id=fk_persona)nombres, " +
                                        "(select apellidos from personal p where p.id=fk_persona)apellidos, " +
                                        "(select gerencia from personal p where p.id=fk_persona)gerencia, " +
                                        "(select area from personal p where p.id=fk_persona)area, " +
		                                "fk_estacion, "+
		                                "(select nombre from estaciones e where e.id=fk_estacion) estacion, "+
		                                "(select nombre from lineas where id=(select fk_linea from estaciones e where e.id=fk_estacion)) linea, "+
		                                "fkc_estado_proceso,activo "+
                                "from asignaciones_maestro "+
                                "where activo=1 "+
                                "and id="+idAsignacionMaestro+"";

            string queryDetalle = "select id,fk_asignacion_maestro,fk_activo,fk_persona,fkc_estado_proceso,fkc_estado_activo,observaciones,activo, "+
		                                    "(select codigo from activos a where a.id=fk_activo) codigo, "+
                                             "(select serie from activos a where a.id=fk_activo) serie, " +
		                                    "(select descripcion from activos a where a.id=fk_activo) descripcion, "+
		                                    "(select nombre from clasificadores c where c.id=fkc_estado_activo) estado_activo, "+
		                                    "(select nombre from clasificadores c where c.id=fkc_estado_proceso) estado_proceso "+
                                    "from asignaciones_detalle "+
                                    "where activo=1 and fk_asignacion_maestro="+idAsignacionMaestro+"";


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
                DateTime f_asignacion = Convert.ToDateTime(rowMaestro["f_asignacion"].ToString());
                string ubicacion = rowMaestro["ubicacion"].ToString().ToUpper();
                string fk_persona = rowMaestro["fk_persona"].ToString();
                string nombres = rowMaestro["nombres"].ToString() + " " + rowMaestro["apellidos"].ToString();
                string apellidos = rowMaestro["apellidos"].ToString();
                string gerencia = rowMaestro["gerencia"].ToString();
                string area = rowMaestro["area"].ToString();
                string estacion = rowMaestro["estacion"].ToString();
                string linea = rowMaestro["linea"].ToString();
               

                dsRegistroAsignacion.Tables["asignaciones_maestro"].Rows.Add(new object[] {
                    idAsignacionMaestro,
                    f_asignacion.ToString("dd/MM/yyyy"),
                    correlativo,
                    ubicacion,
                    fk_persona,
                    nombres,
                    apellidos,
                    gerencia,
                    area,
                    estacion,
                    linea,
                    official,
                    iniciales
                   
                     
                });
                TablaDetalle.Clear();
                TablaDetalle = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryDetalle).Tables[0];
                foreach (DataRow rowDetalle in TablaDetalle.Rows)
                {
                    string id = rowDetalle["id"].ToString();
                    string fk_asignacion_maestro = rowDetalle["fk_asignacion_maestro"].ToString();
                    string codigo = rowDetalle["codigo"].ToString();
                    string descripcion_activo = rowDetalle["descripcion"].ToString();
                    string observaciones = rowDetalle["observaciones"].ToString();
                    string estado_activo = rowDetalle["estado_activo"].ToString();
                    string serie = rowDetalle["serie"].ToString();

                    dsRegistroAsignacion.Tables["asignaciones_detalle"].Rows.Add(new object[] {
                      id,
                      fk_asignacion_maestro,
                      codigo,
                      descripcion_activo,
                      observaciones,
                      estado_activo,
                      serie

                    });
                }
            }
            return dsRegistroAsignacion;
        }

    }
}