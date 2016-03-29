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
    public class ClaseIngreso
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();


        /// <summary>
        /// Obtiene la lista de los ingresos maestro
        /// </summary>
        /// <returns></returns>
        public DataTable List_datosIngresosMaestro(int fk_persona,int vPerfil)
        {
            string query=null;
            if (vPerfil == 1)
            {
                query = "select i.id,i.fk_ingresos_salidas_maestro,RIGHT('00000000' + cast(i.correlativo as nvarchar(10)),7)+'/'+cast(year(i.f_ingreso)as nvarchar(4)) correlativo,i.f_ingreso,RIGHT('00000000' + cast(s.correlativo as nvarchar(10)),7)+'/'+cast(year(s.f_solicitud)as nvarchar(4)) correlativo_salida,s.f_solicitud,p.documento,p.nombres,p.apellidos,p.area,p.gerencia,i.fkc_estado_ingreso, " +
                        "(select c.nombre from clasificadores c where c.id=i.fkc_estado_ingreso) estado_ingreso " +
                        "from ingresos_maestro i inner join ingresos_salidas_maestro s on i.fk_ingresos_salidas_maestro=s.id " +
                        "inner join personal p on p.id=s.fk_persona " +
                        "where i.activo=1 order by i.fkc_estado_ingreso, i.f_ingreso desc,i.correlativo desc ";
            }
            else
            { 
                query = "select i.id,i.fk_ingresos_salidas_maestro,RIGHT('00000000' + cast(i.correlativo as nvarchar(10)),7)+'/'+cast(year(i.f_ingreso)as nvarchar(4)) correlativo,i.f_ingreso,RIGHT('00000000' + cast(s.correlativo as nvarchar(10)),7)+'/'+cast(year(s.f_solicitud)as nvarchar(4)) correlativo_salida,s.f_solicitud,p.documento,p.nombres,p.apellidos,p.area,p.gerencia,i.fkc_estado_ingreso, " +
                        "(select c.nombre from clasificadores c where c.id=i.fkc_estado_ingreso) estado_ingreso " +
                        "from ingresos_maestro i inner join ingresos_salidas_maestro s on i.fk_ingresos_salidas_maestro=s.id " +
                        "inner join personal p on p.id=s.fk_persona " +
                        "where i.activo=1 and p.id=" + fk_persona + " order by i.fkc_estado_ingreso, i.f_ingreso desc,i.correlativo desc ";
            }

            

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }
        /// <summary>
        /// Obtiene la lista de las salidas aprobadas
        /// </summary>
        /// <returns></returns>
        public DataTable List_datosSalidasAprobadas(int fk_persona, int vPerfil)
        {
             string query=null;
             if (vPerfil == 1)
             {

                  query = "select vista.* from (select m.id,RIGHT('00000000' + cast(m.correlativo as nvarchar(10)),7)+'/'+cast(year(m.f_solicitud)as nvarchar(4)) correlativo,m.f_solicitud,m.f_desde,m.f_hasta,m.motivo,m.fk_persona,p.documento,p.nombres,p.apellidos,p.area,p.gerencia,m.fkc_estado_salida,c.nombre estado_salida, " +
                                         "cast((select count(id) from ingresos_salidas_detalle dd where dd.activo=1 and dd.fk_ingresos_salidas_maestro=m.id and fkc_estado_salida in (22,23))as nvarchar(10))+'/'+cast((select count(id) from ingresos_salidas_detalle dd where dd.activo=1 and dd.fk_ingresos_salidas_maestro=m.id)as nvarchar(10))ingresos_salidas, " +
                                         "(select count(id) from ingresos_salidas_detalle dd where dd.activo=1 and dd.fk_ingresos_salidas_maestro=m.id)-(select count(id) from ingresos_salidas_detalle dd where dd.activo=1 and dd.fk_ingresos_salidas_maestro=m.id and fkc_estado_salida in (22,23)) pendientes " +
                                 "from ingresos_salidas_maestro m " +
                                 "inner join personal p on p.id=m.fk_persona " +
                                 "inner join clasificadores c on c.id=m.fkc_estado_salida where m.activo=1 " +
                                 "and fkc_estado_salida=21) vista where vista.pendientes>0 order by vista.f_solicitud desc";
             }
             else
             {
                  query = "select vista.* from (select m.id,RIGHT('00000000' + cast(m.correlativo as nvarchar(10)),7)+'/'+cast(year(m.f_solicitud)as nvarchar(4)) correlativo,m.f_solicitud,m.f_desde,m.f_hasta,m.motivo,m.fk_persona,p.documento,p.nombres,p.apellidos,p.area,p.gerencia,m.fkc_estado_salida,c.nombre estado_salida, " +
                                         "cast((select count(id) from ingresos_salidas_detalle dd where dd.activo=1 and dd.fk_ingresos_salidas_maestro=m.id and fkc_estado_salida in (22,23))as nvarchar(10))+'/'+cast((select count(id) from ingresos_salidas_detalle dd where dd.activo=1 and dd.fk_ingresos_salidas_maestro=m.id)as nvarchar(10))ingresos_salidas, " +
                                         "(select count(id) from ingresos_salidas_detalle dd where dd.activo=1 and dd.fk_ingresos_salidas_maestro=m.id)-(select count(id) from ingresos_salidas_detalle dd where dd.activo=1 and dd.fk_ingresos_salidas_maestro=m.id and fkc_estado_salida in (22,23)) pendientes " +
                                 "from ingresos_salidas_maestro m " +
                                 "inner join personal p on p.id=m.fk_persona " +
                                 "inner join clasificadores c on c.id=m.fkc_estado_salida where m.activo=1 " +
                                 "and fkc_estado_salida=21 and p.id=" + fk_persona + ") vista where vista.pendientes>0  order by vista.f_solicitud desc";
             }
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;

        }


        /// <summary>
        /// Crea el maestro de ingreso
        /// </summary>
        /// <param name="f_ingreso"></param>
        /// <param name="fk_ingresos_salidas_maestro"></param>
        /// <returns></returns>
        public int CreaIngresoMaestro(DateTime f_ingreso, int fk_ingresos_salidas_maestro)
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
                    command.Parameters.Add("@f_ingreso", SqlDbType.Date).Value = f_ingreso;
                    command.Parameters.Add("@fk_ingresos_salidas_maestro", SqlDbType.Int).Value = fk_ingresos_salidas_maestro;
                    command.Parameters.Add("@fkc_estado_ingreso", SqlDbType.Int).Value = 22;
                    command.Parameters.Add("@activo", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechacreacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "insert into ingresos_maestro " +
                        "(f_ingreso,fk_ingresos_salidas_maestro,fkc_estado_ingreso,activo,usuariocreacion,fechacreacion) " +
                        "OUTPUT INSERTED.ID values(@f_ingreso,@fk_ingresos_salidas_maestro,@fkc_estado_ingreso,@activo,@usuariocreacion,@fechacreacion)";
                 

                    result = int.Parse(command.ExecuteScalar().ToString());

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

        public int EditaIngresoMaestro(int id,DateTime f_ingreso)
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
                    command.Parameters.Add("@f_ingreso", SqlDbType.Date).Value = f_ingreso;
                   
                    command.Parameters.Add("@usuariomodificacion", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "update ingresos_maestro set f_ingreso=@f_ingreso,usuariomodificacion=@usuariomodificacion,fechamodificacion=@fechamodificacion " +
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


        public int apruebaIngreso(int id_ingreso_maestro, DateTime fecha_ingreso)
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
                    command.Parameters.Add("@id_ingreso_maestro", SqlDbType.Int).Value = id_ingreso_maestro;
                    command.Parameters.Add("@fecha_ingreso", SqlDbType.Date).Value = fecha_ingreso;
                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "update ingresos_maestro set correlativo=(select isnull(max(correlativo),0)+1 from ingresos_maestro where activo =1 and year(f_ingreso)=year(@fecha_ingreso)), fkc_estado_ingreso=23,usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion where id=@id_ingreso_maestro";
                    command.ExecuteScalar();

                    command.CommandText =
                        "update ingresos_salidas_detalle set fkc_estado_salida=23,usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion where fk_ingreso_maestro=@id_ingreso_maestro";
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


        public int eliminaIngreso(int id_ingreso_maestro)
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
                    command.Parameters.Add("@id_ingreso_maestro", SqlDbType.Int).Value = id_ingreso_maestro;
                    command.Parameters.Add("@fkc_estado_salida", SqlDbType.Int).Value = 21;//salida aprobada

                    command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fechamodificacion", SqlDbType.DateTime).Value = DateTime.Now;


                    command.CommandText =
                        "update ingresos_maestro set activo=0,usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion where id=@id_ingreso_maestro";
                    command.ExecuteScalar();

                    command.CommandText =
                        "update ingresos_salidas_detalle set fkc_estado_salida=@fkc_estado_salida,fk_ingreso_maestro=null,observaciones_ingreso=null, usuariomodificacion=@usuario,fechamodificacion=@fechamodificacion where fk_ingreso_maestro=@id_ingreso_maestro";
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


        public DataSet ReporteIngresos(int id_ingreso_maestro)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);


            DataTable TablaMaestro = new DataTable();
            DataTable TablaDetalle = new DataTable();
            dsIngresosActivos dsIngresos = new dsIngresosActivos();


            dsIngresos.Tables["ingreso_maestro"].Clear();
            dsIngresos.Tables["ingreso_detalle"].Clear();

            string queryMaestro = "select i.id,i.fk_ingresos_salidas_maestro,i.correlativo,i.f_ingreso,s.correlativo correlativo_salida,s.f_solicitud,p.documento,p.nombres,p.apellidos,p.area,p.gerencia,i.fkc_estado_ingreso, "+
	                                       "(select c.nombre from clasificadores c where c.id=i.fkc_estado_ingreso) estado_ingreso,s.f_solicitud "+
                                   "from ingresos_maestro i inner join ingresos_salidas_maestro s on i.fk_ingresos_salidas_maestro=s.id "+
                                   "inner join personal p on p.id=s.fk_persona "+
                                   "where i.id=" + id_ingreso_maestro + "";

            string queryDetalle = "select d.id,d.fk_ingreso_maestro,a.codigo,a.descripcion,a.serie,d.observaciones_ingreso "+
                                    "from ingresos_salidas_detalle d "+
                                    "inner join activos a on a.id=d.fk_activo "+
                                    "where d.activo=1 and fk_ingreso_maestro=" + id_ingreso_maestro + "";


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

                string f_solicitud=rowMaestro["f_solicitud"].ToString();
                
                DateTime fecha_solicitud_correlativo=Convert.ToDateTime(f_solicitud);

                string correlativo_salida = rowMaestro["correlativo_salida"].ToString().PadLeft(7,'0')+"/"+fecha_solicitud_correlativo.Year;

                string documento = rowMaestro["documento"].ToString();
                string nombres = rowMaestro["nombres"].ToString() +" "+ rowMaestro["apellidos"].ToString();
              
                string area = rowMaestro["area"].ToString();
                string gerencia = rowMaestro["gerencia"].ToString();
                string f_ingreso = rowMaestro["f_ingreso"].ToString();
              

                dsIngresos.Tables["ingreso_maestro"].Rows.Add(new object[] {
                    id_maestro,
                    f_ingreso,
                    correlativo_salida,
                    documento,
                    nombres,
                    area,
                    gerencia,
                    correlativo,
                    official,
                    iniciales
                
                });
                TablaDetalle.Clear();
                TablaDetalle = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryDetalle).Tables[0];
                foreach (DataRow rowDetalle in TablaDetalle.Rows)
                {
                    string id = rowDetalle["id"].ToString();
                    string fk_maestro = rowDetalle["fk_ingreso_maestro"].ToString();
                    string codigo = rowDetalle["codigo"].ToString();
                    string descripcion = rowDetalle["descripcion"].ToString();
                    string serie = rowDetalle["serie"].ToString();
                    string observaciones = rowDetalle["observaciones_ingreso"].ToString();

                    dsIngresos.Tables["ingreso_detalle"].Rows.Add(new object[] {
                      id,
                      fk_maestro,
                      codigo,
                      descripcion,
                      serie,
                      observaciones
                    });
                }
            }
            return dsIngresos;
        }

    }
}