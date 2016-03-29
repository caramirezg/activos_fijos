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
    public class ClaseGestionesAperturadas
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();


        public int GenerarAperturaGestión(DateTime f_apertura)
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
                     "insert into gestiones_aperturadas " +
                        "(f_apertura,activo,usuariocreacion,fechacreacion) " +
                        "OUTPUT INSERTED.ID values ('" + f_apertura + "',1,'" + userName + "','" + DateTime.Now + "')";
                         

                    int id_gestion_aperturada = int.Parse(command.ExecuteScalar().ToString());
                    command.CommandText =
                     "insert into actualizacion_depreciacion_apertura " +
                    "(f_apertura,fk_activo,costo_historico,costo_actualizado_inicial,depreciacion_acumulada_total,valor_neto_inicial,actualizacion_gestion,costo_total_actualizado,depreciacion_gestion,actualizacion_depreciacion_acumulada,depreciacion_acumulada,valor_neto,activo,usuariocreacion,fechacreacion) " +
                    "(select '"+f_apertura+"', id,valor_inicial, costo_actualizado_inicial,depreciacion_acumulada_total,valor_neto_inicial,0, 0,0,0,0,0,1,'" + userName + "','" + DateTime.Now + "' " +
                    "from activos " +
                    "where activo=1)";
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

        public List<GestionesAperturadasEntity> List_datosGestionesAperuradas()
        {
            string query = "select id,f_apertura,activo from gestiones_aperturadas where activo=1 order by f_apertura";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<GestionesAperturadasEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                                      select new GestionesAperturadasEntity()
                                                   {
                                                       id = AnyName.Field<int>("id"),
                                                       f_apertura = AnyName.Field<DateTime>("f_apertura").ToString("dd/MM/yyyy"),
                                                       activo = AnyName.Field<int>("activo"),

                                                   }).ToList();
            return Lista;
        }

        public DataSet ReporteResumenAperturaGestion(DateTime f_apertura)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsResumenAperturaGestion dsResumenCierre = new dsResumenAperturaGestion();

            dsResumenCierre.Tables["apertura_gestion"].Clear();


            string query = "select gc.nombre grupo_contable,count(a.fk_activo) cantidad,gc.vida_util vida_util,sum(a.costo_historico) costo_historico,sum(a.costo_actualizado_inicial) costo_actualizado_inicial,sum(a.depreciacion_acumulada_total) depreciacion_acumulada_total,sum(a.valor_neto_inicial) valor_neto_inicial,sum(a.actualizacion_gestion)actualizacion_gestion,sum(a.costo_total_actualizado)costo_total_actualizado,sum(a.depreciacion_gestion)depreciacion_gestion,sum(a.actualizacion_depreciacion_acumulada)actualizacion_depreciacion_acumulada,sum(a.depreciacion_acumulada)depreciacion_acumulada,sum(a.valor_neto)valor_neto, " +
                            "(select tasa_ufv from tasa_cambio where activo=1 and f_tasa='" + f_apertura + "') tasa_ufv " +
                           "from actualizacion_depreciacion_apertura a " +
                            "inner join activos ac on ac.id=a.fk_activo " +
                            "inner join auxiliares_contables ax on ax.id=ac.fk_auxiliar_contable " +
                            "inner join grupos_contables gc on gc.id=ax.fk_grupo_contable " +
                            "where a.f_apertura='" + f_apertura + "' " +
                            "and a.activo=1 " +
                            "group by gc.nombre,gc.vida_util ";


            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                string grupo_contable = rowDetalle["grupo_contable"].ToString();
                string cantidad = rowDetalle["cantidad"].ToString();
                string vida_util = rowDetalle["vida_util"].ToString();
                string costo_historico = rowDetalle["costo_historico"].ToString();
                string costo_actualizado_inicial = rowDetalle["costo_actualizado_inicial"].ToString();
                string depreciacion_acumulada_total = rowDetalle["depreciacion_acumulada_total"].ToString();
                string valor_neto_inicial = rowDetalle["valor_neto_inicial"].ToString();
                string actualizacion_gestion = rowDetalle["actualizacion_gestion"].ToString();
                string costo_total_actualizado = rowDetalle["costo_total_actualizado"].ToString();
                string depreciacion_gestion = rowDetalle["depreciacion_gestion"].ToString();
                string actualizacion_depreciacion_acumulada = rowDetalle["actualizacion_depreciacion_acumulada"].ToString();
                string depreciacion_acumulada = rowDetalle["depreciacion_acumulada"].ToString();
                string valor_neto = rowDetalle["valor_neto"].ToString();
                string tasa_ufv = rowDetalle["tasa_ufv"].ToString();
                tasa_ufv = tasa_ufv + " Bs.";

                dsResumenCierre.Tables["apertura_gestion"].Rows.Add(new object[] {
                     grupo_contable,
                     int.Parse(cantidad),
                     int.Parse(vida_util),
                     decimal.Parse(costo_historico),
                     decimal.Parse(costo_actualizado_inicial),
                     decimal.Parse(depreciacion_acumulada_total),
                     decimal.Parse(valor_neto_inicial),
                     decimal.Parse(actualizacion_gestion),
                     decimal.Parse(costo_total_actualizado),
                     decimal.Parse(depreciacion_gestion),
                     decimal.Parse(actualizacion_depreciacion_acumulada),
                     decimal.Parse(depreciacion_acumulada),
                     decimal.Parse(valor_neto),
                     iniciales,
                     tasa_ufv
                    });
            }
            return dsResumenCierre;
        }
    }
}