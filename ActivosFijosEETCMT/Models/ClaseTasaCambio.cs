using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;
using ActivosFijosEETC.Models.DataSets;
using System.Data.SqlClient;

namespace ActivosFijosEETC.Models
{
    public class ClaseTasaCambio
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();
        /// <summary>
        /// obtiene la lista de las tasas de cambio
        /// </summary>
        /// <returns></returns>
        public List<TasaCambioEntity> List_datosTasasCambio()
        {
            string query = "select id,f_tasa,tasa_ufv,tasa_sus,activo, (case when  f_tasa<=(select isnull(max(f_cierre),'01/01/1900') from gestiones_cerradas where activo=1) then 'CERRADO' else 'VIGENTE' end) estado "+
                            "from tasa_cambio "+
                            "where activo=1 "+
                            "order by f_tasa desc";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<TasaCambioEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                            select new TasaCambioEntity()
                                               {
                                                   id = AnyName.Field<int>("id"),
                                                   tasa_ufv = AnyName.Field<decimal>("tasa_ufv"),
                                                   tasa_sus = AnyName.Field<decimal>("tasa_sus"),
                                                   f_tasa=AnyName.Field<DateTime>("f_tasa").ToString("dd/MM/yyyy"),
                                                   activo = AnyName.Field<int>("activo"),
                                                   estado=AnyName.Field<string>("estado")
                                                
                                               }).ToList();
            return Lista;
        }

        public List<TasaCambioEntity> List_datosTasasUfvPorFechas()
        {
            string query = "select id,f_tasa,tasa_ufv "+
                            "from tasa_cambio "+
                            "where activo=1 and f_tasa between '01/01/2015' and '31/12/2015' "+
                            "order by f_tasa asc";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<TasaCambioEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                            select new TasaCambioEntity()
                                            {
                                                id = AnyName.Field<int>("id"),
                                                tasa_ufv = AnyName.Field<decimal>("tasa_ufv"),
                                                f_tasa = AnyName.Field<DateTime>("f_tasa").ToString("yyyy-MM-dd"),
 
                                            }).ToList();
            return Lista;
        }


        /// <summary>
        /// Obtiene el valor de la tasa de cambio del dolar
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public decimal obtieneTasaDolar(string fecha)
        {
            try
            {
                decimal result = 0;
                string query = "select top 1 tasa_sus from tasa_cambio where activo=1 and f_tasa='"+fecha+"'";
                result = decimal.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }
        /// <summary>
        /// Obtiene el valor de la tasa de cambio de ufv
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public decimal obtieneTasaUfv(string fecha)
        {
            try
            {
                decimal result = 0;
                string query = "select top 1 tasa_sus from tasa_cambio where activo=1 and f_tasa='" + fecha + "'";
                result = decimal.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }

        /// <summary>
        /// Obtiene la tasa de cambio del dolar y de ufv en una lista
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<TasaCambioEntity> obtieneTasaDolarUfv(string fecha)
        {
           
                decimal result = 0;
                string query = "select top 1 tasa_sus,tasa_ufv from tasa_cambio where activo=1 and f_tasa='" + fecha + "'";
    
                dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
                List<TasaCambioEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                                select new TasaCambioEntity()
                                                      {
                                                          tasa_sus = AnyName.Field<decimal>("tasa_sus"),
                                                          tasa_ufv = AnyName.Field<decimal>("tasa_ufv")
                                                      }).ToList();
                return Lista;
            
        }
        /// <summary>
        /// Crea un nuevo registro de tasa de cambio
        /// </summary>
        /// <param name="f_tasa"></param>
        /// <param name="tasa_cambio_ufv"></param>
        /// <param name="tasa_cambio_sus"></param>
        /// <returns></returns>
        public int CreaTasaCambio(string f_tasa,string tasa_cambio_ufv,string tasa_cambio_sus)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "insert into tasa_cambio " +
                "(f_tasa,tasa_ufv,tasa_sus,activo,usuariocreacion,fechacreacion) " +
                "values('" + f_tasa + "'," + tasa_cambio_ufv + "," + tasa_cambio_sus + ",1,'" + userName + "','" + DateTime.Now + "')";
                result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, insert);
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }

        public int EditaTasaCambio(int id,DateTime f_tasa,decimal tasa_cambio_ufv, decimal tasa_cambio_sus)
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

                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@f_tasa", SqlDbType.Date).Value = f_tasa;
                    command.Parameters.Add("@tasa_ufv", SqlDbType.Decimal).Value = tasa_cambio_ufv;
                    command.Parameters.Add("@tasa_sus", SqlDbType.Decimal).Value = tasa_cambio_sus;
                    command.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = HttpContext.Current.Session["userName"].ToString();
                    command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Now;
                    
                    command.CommandText =
                     "update tasa_cambio "+
                        "set tasa_ufv=@tasa_ufv,tasa_sus=@tasa_sus,usuariomodificacion=@usuario,fechamodificacion=@fecha " +
                        "where id=@id";

                    command.ExecuteNonQuery();

                    command.CommandText =
                        "update activos " +
                        "set tasa_ufv=@tasa_ufv, tasa_sus=@tasa_sus, usuariomodificacion=@usuario,fechamodificacion=@fecha " +
                        "where f_registro=@f_tasa and activo=1";
                    command.ExecuteNonQuery();

                    command.CommandText=
                        "update compras " +
                        "set tasa_ufv=@tasa_ufv, tasa_sus=@tasa_sus, usuariomodificacion=@usuario,fechamodificacion=@fecha " +
                        "where f_registro=@f_tasa and activo=1";
                    command.ExecuteNonQuery();

                    command.CommandText=
                        "update transferencias " +
                        "set tasa_ufv=@tasa_ufv, tasa_sus=@tasa_sus, usuariomodificacion=@usuario,fechamodificacion=@fecha " +
                        "where f_transferencia=@f_tasa and activo=1";
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

        public int EliminaTasaCambio(int id)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "update tasa_cambio " +
                "set activo='0', usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
                "where id=" + id + "";
                result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, insert);
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }

        }

        /// <summary>
        /// valida que no haya tasa de cambio en determinada fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public int validaFechaRegistrada(string fecha)
        {
            try
            {
                int result = 0;
                string query = "  select count(*) from tasa_cambio where f_tasa='"+fecha+"' and activo=1";
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());
                if (result > 0)
                    result = 0;
                else
                    result = 1;
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }

        /// <summary>
        /// Obtiene reporte de tasas de cambio de un rango de fechas
        /// </summary>
        /// <param name="fecha_inicio"></param>
        /// <param name="fecha_fin"></param>
        /// <returns></returns>
        public DataSet ReporteTasaUfvDolar(DateTime fecha_inicio, DateTime fecha_fin)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);


            DataTable TablaTasas = new DataTable();

            dsTasas dsTasas = new dsTasas();

            dsTasas.Tables["tasa_cambio"].Clear();


            string query = "select id,f_tasa,tasa_ufv,tasa_sus,  month(f_tasa) mes_numero, UPPER(DATENAME(month, f_tasa)) mes_literal " +
                            "from tasa_cambio "+
                            "where f_tasa between '" + fecha_inicio + "' and '"+fecha_fin+"' " +
                            "and activo=1 "+
                            "order by f_tasa asc";

            TablaTasas.Clear();
            TablaTasas = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaTasas.Rows)
            {
                

                string id = rowDetalle["id"].ToString();
                DateTime f_tasa = Convert.ToDateTime(rowDetalle["f_tasa"].ToString());
                string tasa_ufv = rowDetalle["tasa_ufv"].ToString();
                string tasa_sus = rowDetalle["tasa_sus"].ToString();
                string mes_numero = rowDetalle["mes_numero"].ToString();
                string mes_literal = rowDetalle["mes_literal"].ToString();

                dsTasas.Tables["tasa_cambio"].Rows.Add(new object[] {
                      id,
                      f_tasa.ToString("dd/MM/yyyy"),
                      tasa_ufv,
                      tasa_sus,
                      iniciales,
                      mes_numero,
                      mes_literal
                    });
            }
            return dsTasas;
        }

        /// <summary>
        /// Valida si existe datos de tasa de cambio en una fecha determinada
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public int validaExistenciaFechaRegistrada(string fecha)
        {
            try
            {
                int result = 0;
                string query = "select count(*) from tasa_cambio where f_tasa='" + fecha + "' and activo=1";
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());
                
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }

            
    }
}