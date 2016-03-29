using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ActivosFijos.Models;
using System.Data.SqlClient;
using ActivosFijosEETC.Models.DataSets;

namespace ActivosFijosEETC.Models
{
    public class ClaseIngresoSalidaDetalle
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// obtiene la lista de todos los activos
        /// </summary>
        /// <returns></returns>
        public DataTable List_datosTodosActivos()
        {
            string query =
            "select row_number() over (order by vista.fk_activo) id,vista.* "+
            "from ( "+
            "select id fk_activo,codigo,descripcion,serie from activos where activo=1 and fkc_estado_proceso=10"+
            ") vista "+
            "where vista.fk_activo not in ( select fk_activo from ingresos_salidas_detalle where activo=1 and fkc_estado_salida in (20,21,22))";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }

        /// <summary>
        /// Obtiene los activos asignados y transferidos por persona 
        /// </summary>
        /// <param name="fk_persona"></param>
        /// <returns></returns>
        public DataTable List_datosActivosAsignadosTransferidosPorPersona(int fk_persona)
        {

            string query = "select row_number() over (order by vista.tabla) id,vista.* " +
                           "from( " +
                           "select ad.id id_asignacion_detalle,null id_asignacion_por_transferencia_detalle,a.id fk_activo, a.codigo,a.descripcion,a.serie,(select nombre from clasificadores c where c.id=ad.fkc_estado_proceso) estado_proceso,'asignaciones_detalle' tabla  " +
                           "from asignaciones_detalle ad " +
                           "inner join activos a on a.id=ad.fk_activo " +
                           "where ad.activo=1 and ad.fkc_estado_proceso in (10) and ad.fk_persona=" + fk_persona + " " +
                           "union all " +
                           "select fk_asignacion_detalle,at.id,at.fk_activo,a.codigo,a.descripcion,a.serie,(select nombre from clasificadores c where c.id=at.fkc_estado_proceso)estado_proceso,'asignaciones_por_transferencias_detalle' tabla " +
                           "from asignaciones_por_transferencias_detalle at " +
                           "inner join activos a on a.id=at.fk_activo " +
                           "where at.activo=1 and at.fkc_estado_proceso in (10) and at.fk_persona_destino=" + fk_persona + " " +
                           ") vista "+
                           "where vista.fk_activo not in ( select fk_activo from ingresos_salidas_detalle where activo=1 and fkc_estado_salida in (20,21))";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtTable;
        }

        public DataTable List_datosActivosSolicitados(int fk_ingreso_salida_maestro)
        {
            string query =
            "select d.id,d.fk_activo,a.codigo,a.descripcion,a.serie,d.observaciones_salida  from ingresos_salidas_detalle d "+
            "inner join activos a on a.id=d.fk_activo "+
            "where d.activo=1 and d.fk_ingresos_salidas_maestro=" + fk_ingreso_salida_maestro + "";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }

        /// <summary>
        /// Crea un registro del detalle de ingresos salidas (solicitudes)
        /// </summary>
        /// <param name="fk_ingresos_salidas_maestro"></param>
        /// <param name="fk_activo"></param>
        /// <param name="fkc_estado_salida"></param>
        /// <returns></returns>
        public int CreaIngresoSalidaDetalle(int fk_ingresos_salidas_maestro, int fk_activo, int fkc_estado_salida,string observaciones)
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
                    command.Parameters.Add("@fk_ingresos_salidas_maestro", SqlDbType.Int).Value = fk_ingresos_salidas_maestro;
                    command.Parameters.Add("@fk_activo", SqlDbType.Int).Value = fk_activo;
                    command.Parameters.Add("@fkc_estado_salida", SqlDbType.Int).Value = fkc_estado_salida;
                    command.Parameters.Add("@observaciones", SqlDbType.NVarChar).Value = observaciones;
                 
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                     "insert into ingresos_salidas_detalle " +
                     "(fk_ingresos_salidas_maestro,fk_activo,fkc_estado_salida,observaciones_salida,activo,usuariocreacion,fechacreacion) " +
                     "OUTPUT INSERTED.ID values(@fk_ingresos_salidas_maestro,@fk_activo,@fkc_estado_salida,@observaciones,@activo,@usuariocreacion,@fechacreacion)";

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
        /// Elimina un registro del detalle solicitud
        /// </summary>
        /// <param name="id_detalle"></param>
        /// <returns></returns>
        public int EliminaIngresoSalidaDetalle(int id_detalle)
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

                    command.Parameters.Add("@id", SqlDbType.Int).Value = id_detalle;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;

                    command.CommandText =
                        "update ingresos_salidas_detalle set activo=0,usuariocreacion=@usuariocreacion,fechacreacion= @fechacreacion where id=@id";

                    result = int.Parse(command.ExecuteNonQuery().ToString());

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
        /// Genera el reporte para la solicitud de salida de un activo fijo
        /// </summary>
        /// <param name="idMaestroSolicitud"></param>
        /// <returns></returns>
        public DataSet ReporteSolicitudesSalida(int idMaestroSolicitud)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);


            DataTable TablaMaestro = new DataTable();
            DataTable TablaDetalle = new DataTable();
            dsSalidasActivos dsSalidaActivo = new dsSalidasActivos();


            dsSalidaActivo.Tables["salida_maestro"].Clear();
            dsSalidaActivo.Tables["salida_detalle"].Clear();

            string queryMaestro = "select m.id,correlativo,p.documento,p.nombres,p.apellidos,p.area,p.gerencia, m.f_solicitud,m.f_desde,m.f_hasta,m.motivo,m.documento_autorizacion from ingresos_salidas_maestro m "+
                                    "inner join personal p  on p.id=m.fk_persona "+
                                    "where m.id=" + idMaestroSolicitud + "";

            string queryDetalle = "select d.id,d.fk_ingresos_salidas_maestro,a.codigo,a.descripcion,a.serie,(select c.nombre from clasificadores c where c.id=a.fkc_estado_activo) estado_fisico,d.observaciones_salida "+
                                    "from ingresos_salidas_detalle d "+
                                    "inner join activos a on a.id=d.fk_activo "+
                                    "where fk_ingresos_salidas_maestro=" + idMaestroSolicitud + " and d.activo=1";


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
                string documento = rowMaestro["documento"].ToString();
                string nombres = rowMaestro["nombres"].ToString() + " " + rowMaestro["apellidos"].ToString();
                string apellidos = rowMaestro["apellidos"].ToString();
                string area = rowMaestro["area"].ToString();
                string gerencia = rowMaestro["gerencia"].ToString();
                string motivo = rowMaestro["motivo"].ToString();
                string f_solicitud = rowMaestro["f_solicitud"].ToString();
                string f_desde = rowMaestro["f_desde"].ToString();
                string f_hasta = rowMaestro["f_hasta"].ToString();
                string documento_autorizacion = rowMaestro["documento_autorizacion"].ToString();

                string f_salida_hasta = null;

                if (!string.IsNullOrEmpty(f_hasta))
                {
                    DateTime f_convertido = Convert.ToDateTime(f_hasta);
                    DateTime fecha = DateTime.Parse(f_convertido.ToString("dd/MM/yyyy"));
                    string convertido = String.Format("{0:dd/MM/yyyy}", fecha);
                    f_salida_hasta = convertido;
                }
                else
                    f_salida_hasta = "INDEFINIDO";
              
             
                dsSalidaActivo.Tables["salida_maestro"].Rows.Add(new object[] {
                    id_maestro,
                    correlativo_maestro,
                    documento,
                    nombres,
                    apellidos,
                    area,
                    gerencia,
                    motivo,
                    official,
                    iniciales,
                    f_solicitud,
                    f_desde,
                    f_salida_hasta,
                    documento_autorizacion
                });
                TablaDetalle.Clear();
                TablaDetalle = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryDetalle).Tables[0];
                foreach (DataRow rowDetalle in TablaDetalle.Rows)
                {
                    string id = rowDetalle["id"].ToString();
                    string fk_maestro = rowDetalle["fk_ingresos_salidas_maestro"].ToString();
                    string codigo = rowDetalle["codigo"].ToString();
                    string descripcion = rowDetalle["descripcion"].ToString();
                    string serie = rowDetalle["serie"].ToString();
                    string estado_fisico = rowDetalle["estado_fisico"].ToString();
                    string observaciones = rowDetalle["observaciones_salida"].ToString();
                  

                    dsSalidaActivo.Tables["salida_detalle"].Rows.Add(new object[] {
                      id,
                      fk_maestro,
                      codigo,
                      descripcion,
                      serie,
                      estado_fisico,
                      observaciones
                    });
                }
            }
            return dsSalidaActivo;
        }

        /********INGRESOS**************/


        /// <summary>
        /// Obtiene la lista de activos en estado salida aprobada de un maestro de salida
        /// </summary>
        /// <param name="id_maestro_salida"></param>
        /// <returns></returns>
        public DataTable List_datosActivosPrestados(int id_maestro_salida)
        {
            string query = "select d.id,a.codigo,a.descripcion,a.serie "+
            "from ingresos_salidas_detalle d "+
            "inner join activos a on a.id=d.fk_activo "+
            "where d.fk_ingresos_salidas_maestro=" + id_maestro_salida + " and d.activo=1 " +
            "and fkc_estado_salida=21";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }

        /// <summary>
        /// Obtiene la lista de los activos devueltos
        /// </summary>
        /// <param name="id_maestro_ingreso"></param>
        /// <returns></returns>
        public DataTable List_datosActivosDevueltos(int id_maestro_ingreso)
        {
            string query = "select d.id,a.codigo,a.descripcion,a.serie,(select c.nombre from clasificadores c where c.id=d.fkc_estado_salida) estado_salida,d.observaciones_salida,d.observaciones_ingreso "+
                            "from ingresos_salidas_detalle d "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "where d.activo =1 and d.fk_ingreso_maestro=" + id_maestro_ingreso + "";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }

        /// <summary>
        /// Devuelve un activo prestado (paso de estado salida aprobada a pre ingreso)
        /// </summary>
        /// <param name="id_ingresos_maestro"></param>
        /// <param name="id_salidas_detalle"></param>
        /// <returns></returns>
        public int DevuelveActivoPrestado(int id_ingresos_maestro,int id_salidas_detalle,string observaciones)
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
                    command.Parameters.Add("@id_ingresos_maestro", SqlDbType.Int).Value = id_ingresos_maestro;
                    command.Parameters.Add("@id_salidas_detalle", SqlDbType.Int).Value = id_salidas_detalle;
                    command.Parameters.Add("@observaciones", SqlDbType.NVarChar).Value = observaciones;
                    command.Parameters.Add("@usuariomodificacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "update ingresos_salidas_detalle set fk_ingreso_maestro=@id_ingresos_maestro,fkc_estado_salida=22,observaciones_ingreso=@observaciones,usuariomodificacion=@usuariomodificacion,fechamodificacion=@fechamodificacion " +
                            "where id=@id_salidas_detalle";

                    result = command.ExecuteNonQuery();

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
        /// Vuelve al estado anterior la devolucion de un activo (paso de estado pre ingresado a salida aprobada)
        /// </summary>
        /// <param name="id_salidas_detalle"></param>
        /// <returns></returns>
        public int QuitarDevolucionActivoPrestado(int id_salidas_detalle)
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
                    command.Parameters.Add("@id_salidas_detalle", SqlDbType.Int).Value = id_salidas_detalle;
                    command.Parameters.Add("@usuariomodificacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "update ingresos_salidas_detalle set fk_ingreso_maestro=null,fkc_estado_salida=21,observaciones_ingreso=null,usuariomodificacion=@usuariomodificacion,fechamodificacion=@fechamodificacion " +
                            "where id=@id_salidas_detalle";

                    result = command.ExecuteNonQuery();

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

    }
}