using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ActivosFijos.Models;
using ActivosFijosEETC.Models.DataSets;

namespace ActivosFijosEETC.Models
{
    public class ClaseGestionesCerradas
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        public int GenerarCierreGestión(DateTime f_cierre)
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
                     "insert into gestiones_cerradas "+
                        "(f_cierre,activo,usuariocreacion,fechacreacion) "+
                        "OUTPUT INSERTED.ID values ('" + f_cierre + "',1,'" + userName + "','" + DateTime.Now + "')";

                    int id_gestion_cerrada=int.Parse(command.ExecuteScalar().ToString());
                    /*command.CommandText =
                     "insert into actualizacion_depreciacion_gestion "+
                    "(f_cierre,fk_gestion_cerrada,fk_activo,costo_historico,costo_actualizado_inicial,depreciacion_acumulada_total,valor_neto_inicial,actualizacion_gestion,costo_total_actualizado,depreciacion_gestion,actualizacion_depreciacion_acumulada,depreciacion_acumulada,valor_neto,activo,usuariocreacion,fechacreacion) "+
                    "(select '" + f_cierre + "'," + id_gestion_cerrada + ", id,valor_inicial, costo_actualizado_inicial,depreciacion_acumulada_total,valor_neto_inicial,actualizacion_gestion, costo_total_actualizado,depreciacion_gestion,actualizacion_depreciacion_acumulada,depreciacion_acumulada,valor_neto,1,'" + userName + "','" + DateTime.Now + "' " +
                    "from activos "+
                    "where activo=1)";*/
                    command.CommandText =
                        "insert into actualizacion_depreciacion_gestion " +
                        "(f_cierre,fk_gestion_cerrada,tasa_ufv,f_registro,fk_activo,costo_historico,costo_actualizado_inicial,depreciacion_acumulada_total,valor_neto_inicial,actualizacion_gestion,costo_total_actualizado,depreciacion_gestion,actualizacion_depreciacion_acumulada,depreciacion_acumulada,valor_neto,vida_util,factor_actualizacion,f_ult_act_dep,tasa_ufv_final,dias,dias_general,activo,usuariocreacion,fechacreacion) " +
                        "select '" + f_cierre + "'," + id_gestion_cerrada + ", " +
                                        "(select case when (select count(dg.id) " +
                                                           "from actualizacion_depreciacion_gestion dg " +
                                                           "where dg.activo=1 and dg.f_cierre=(select top(1)f_cierre " +
                                                                                              "from gestiones_cerradas where activo=1 and f_cierre<'" + f_cierre + "' order by f_cierre desc) and dg.fk_activo=a.id)=0 " +
                                                "then a.tasa_ufv " +
                                                "else (select tasa_ufv from tasa_cambio t where t.f_tasa=(select top(1)f_cierre " +
                                                                                                         "from gestiones_cerradas where activo=1 and f_cierre<'" + f_cierre + "' order by f_cierre desc)) " +
                                                "end) tasa_ufv, " +
                                                "a.f_registro, " +
                    "a.id,valor_inicial, costo_actualizado_inicial,depreciacion_acumulada_total,valor_neto_inicial,actualizacion_gestion, costo_total_actualizado,depreciacion_gestion,actualizacion_depreciacion_acumulada,depreciacion_acumulada,valor_neto, " +
                    "(case when a.nueva_vida_util is null then case when a.vida_util_especifica is null then gc.vida_util else a.vida_util_especifica end else a.nueva_vida_util end) vida_util, " +
                    "(select tasa_ufv from tasa_cambio where f_tasa=a.f_ult_act_dep)/(select case when (select count(dg.id) " +
                                                                                                         "from actualizacion_depreciacion_gestion dg " +
                                                                                                         "where dg.activo=1 and dg.f_cierre=(select top(1)f_cierre " +
                                                                                                                                            "from gestiones_cerradas where activo=1 and f_cierre<'" + f_cierre + "' order by f_cierre desc) and dg.fk_activo=a.id)=0 " +
                                                                                            "then a.tasa_ufv " +
                                                                                            "else (select tasa_ufv from tasa_cambio t where t.f_tasa=(select top(1)f_cierre " +
                                                                                                                                                     "from gestiones_cerradas where activo=1 and f_cierre<'" + f_cierre + "' order by f_cierre desc)) " +
                                                                                            "end) factor_actualizacion,a.f_ult_act_dep,(select tasa_ufv from tasa_cambio where f_tasa=a.f_ult_act_dep) tasa_ufv_final, " +
                        "(datediff(day,(select case when (select count(dg.id) " +
                                                         "from actualizacion_depreciacion_gestion dg " +
                                                         "where dg.activo=1 and dg.f_cierre=(select top(1)f_cierre " +
                                                                                            "from gestiones_cerradas where activo=1 and f_cierre<'" + f_cierre + "' order by f_cierre desc) and dg.fk_activo=a.id " +
                                                                                            ")=0 " +
                                                "then a.f_registro " +
                                                "else (select top(1) dateadd(day,1,f_cierre) from gestiones_cerradas where activo=1 and f_cierre<'" + f_cierre + "' order by f_cierre desc) " +
                                                        "end),a.f_ult_act_dep)+1) dias,DATEDIFF(day,a.f_registro,a.f_ult_act_dep) +1 dias_general,1,'" + userName + "','" + DateTime.Now + "' " +
                    "from activos a " +
                    "inner join auxiliares_contables ac on a.fk_auxiliar_contable=ac.id " +
                    "inner join grupos_contables gc on gc.id=ac.fk_grupo_contable " +
                    "where a.activo=1";
                    command.ExecuteNonQuery();


                    command.CommandText =
                        "update a set a.costo_actualizado_inicial=g.costo_total_actualizado " +
                         "from actualizacion_depreciacion_gestion g " +
                         "inner join activos a on a.id=g.fk_activo " +
                         "where g.f_cierre = (select max(f_cierre) from gestiones_cerradas where activo=1) " +
                         "and g.activo=1 and a.fkc_estado_proceso not in (24,25)";
                    command.ExecuteNonQuery();

                    command.CommandText =
                        "update a set a.depreciacion_acumulada_total=g.depreciacion_acumulada " +
                        "from actualizacion_depreciacion_gestion g " +
                        "inner join activos a on a.id=g.fk_activo " +
                        "where g.activo=1 and a.activo=1 and g.f_cierre=(select max(f_cierre) from gestiones_cerradas where activo=1) "+
                        "and a.fkc_estado_proceso not in (24,25) ";
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


        public List<GestionesCerradasEntity> List_datosGestionesCerradas()
        {
            string query = "select id,f_cierre,activo from gestiones_cerradas where activo=1 order by f_cierre desc";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<GestionesCerradasEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                                   select new GestionesCerradasEntity()
                                               {
                                                   id = AnyName.Field<int>("id"),
                                                   f_cierre = AnyName.Field<DateTime>("f_cierre").ToString("dd/MM/yyyy"),
                                                   activo = AnyName.Field<int>("activo"),
                                                  
                                               }).ToList();
            return Lista;
        }


        public DataSet ReporteResumenCierreGestion(DateTime f_cierre)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsResumenCierreGestion dsResumenCierre = new dsResumenCierreGestion();

            dsResumenCierre.Tables["cierre_gestion"].Clear();


            string query = "select gc.nombre grupo_contable,count(a.fk_activo) cantidad,gc.vida_util vida_util,sum(a.costo_historico) costo_historico,sum(a.costo_actualizado_inicial) costo_actualizado_inicial,sum(a.depreciacion_acumulada_total) depreciacion_acumulada_total,sum(a.valor_neto_inicial) valor_neto_inicial,sum(a.actualizacion_gestion)actualizacion_gestion,sum(a.costo_total_actualizado)costo_total_actualizado,sum(a.depreciacion_gestion)depreciacion_gestion,sum(a.actualizacion_depreciacion_acumulada)actualizacion_depreciacion_acumulada,sum(a.depreciacion_acumulada)depreciacion_acumulada,sum(a.valor_neto)valor_neto, " +
                            "(select tasa_ufv from tasa_cambio where activo=1 and f_tasa='" + f_cierre + "') tasa_ufv " +
                           "from actualizacion_depreciacion_gestion a "+
                            "inner join activos ac on ac.id=a.fk_activo "+
                            "inner join auxiliares_contables ax on ax.id=ac.fk_auxiliar_contable "+
                            "inner join grupos_contables gc on gc.id=ax.fk_grupo_contable "+
                            "where a.f_cierre='" + f_cierre + "' " +
                            "and a.activo=1 "+
                            "group by gc.nombre,gc.vida_util";


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

                dsResumenCierre.Tables["cierre_gestion"].Rows.Add(new object[] {
                     grupo_contable,
                     cantidad,
                     vida_util,
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


        public DataSet ReporteDetalleCierreActivos(DateTime f_cierre)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();
         
            dsDetalleActivosPorGrupo dsDetalleActivos = new dsDetalleActivosPorGrupo();

            dsDetalleActivos.Tables["detalle_activos_grupo"].Clear();

            

            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString,"[SP_DatosDetalleDepreciacionPorCierre]", f_cierre).Tables[0];
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
                DateTime f_ult_act_dep = f_cierre;
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                DateTime f_registro = DateTime.Parse(rowDetalle["f_registro"].ToString());
                string tasa_ufv = rowDetalle["tasa_ufv"].ToString();
                string porcentaje_depreciacion = rowDetalle["porcentaje_depreciacion"].ToString();
                string dias = rowDetalle["dias"].ToString();
                string tasa_ufv_final = rowDetalle["tasa_ufv_final"].ToString();
                string factor_actualizacion = rowDetalle["factor_actualizacion"].ToString();
                string dias_general = rowDetalle["dias_general"].ToString();

                dsDetalleActivos.Tables["detalle_activos_grupo"].Rows.Add(new object[] {
                     grupo_contable,
                     cantidad,
                     vida_util,
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
                     f_ult_act_dep.ToString("d 'de' MMMM 'de' yyyy"),
                     codigo,descripcion,
                     f_registro.ToString("dd/MM/yyyy"),
                     tasa_ufv,
                     porcentaje_depreciacion,
                     dias,
                     tasa_ufv_final,
                     decimal.Round(decimal.Parse(factor_actualizacion),5),
                     dias_general
                    });
            }
            return dsDetalleActivos;
        }
    }
}