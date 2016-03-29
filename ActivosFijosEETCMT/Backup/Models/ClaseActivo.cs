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
    public class ClaseActivo
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Crea un registro de activo fijo
        /// </summary>
        /// <param name="fk_auxiliar_contable"></param>
        /// <param name="fk_modelo"></param>
        /// <param name="serie"></param>
        /// <param name="descripcion"></param>
        /// <param name="f_registro"></param>
        /// <param name="fkc_estado_activo"></param>
        /// <param name="valor_inicial"></param>
        /// <param name="valor_actual"></param>
        /// <param name="fk_compra"></param>
        /// <param name="fk_proveedor"></param>
        /// <param name="fkc_tipo_adquisicion"></param>
        /// <param name="fk_persona"></param>
        /// <param name="fk_encargado"></param>
        /// <param name="fkc_unidad_medida"></param>
        /// <param name="f_ultima_actualizacion"></param>
        /// <param name="f_baja"></param>
        /// <param name="f_ultima_depreciacion"></param>
        /// <returns></returns>
        public int CreaActivo(string codigo, string correlativo, int fk_fuente_financiamiento, int fk_auxiliar_contable, int fk_modelo, string serie, string descripcion, DateTime f_registro, int fkc_estado_activo, int fkc_estado_proceso, decimal tasa_ufv, decimal tasa_sus, decimal valor_inicial, decimal valor_actual, decimal gastos_con_credito_fiscal,decimal gastos_sin_credito_fiscal, int fk_compra,int fk_proveedor, int fkc_tipo_adquisicion, string f_inicio_garantia, string f_fin_garantia,string vida_util_alterna)
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

                    command.Parameters.Add("@tasa_ufv", SqlDbType.Decimal).Value = tasa_ufv;
                    command.Parameters.Add("@tasa_sus", SqlDbType.Decimal).Value = tasa_sus;
                    command.Parameters.Add("@costo", SqlDbType.Decimal).Value = decimal.Round(valor_inicial, 5);
                    command.Parameters.Add("@gastos_con_credito_fiscal", SqlDbType.Decimal).Value = decimal.Round(gastos_con_credito_fiscal, 5);
                    command.Parameters.Add("@gastos_sin_credito_fiscal", SqlDbType.Decimal).Value = decimal.Round(gastos_sin_credito_fiscal, 5);
                    command.Parameters.Add("@valor_inicial", SqlDbType.Decimal).Value = decimal.Round(((valor_inicial+gastos_con_credito_fiscal)*87/100)+gastos_sin_credito_fiscal,5);
                    if(string.IsNullOrEmpty(vida_util_alterna))
                        command.Parameters.Add("@vida_util_alterna", SqlDbType.Int).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@vida_util_alterna", SqlDbType.Int).Value = vida_util_alterna;


                    command.CommandText =
                     "insert into activos " +
                     "(codigo,fk_fuente_financiamiento,fk_auxiliar_contable,correlativo,fk_modelo,serie,descripcion,f_registro,fkc_estado_proceso,tasa_ufv,tasa_sus,costo,gastos_con_credito_fiscal,gastos_sin_credito_fiscal,valor_inicial,fk_compra,fk_proveedor,fkc_tipo_adquisicion,f_inicio_garantia,f_fin_garantia,costo_actualizado_inicial,vida_util_especifica,activo,usuariocreacion,fechacreacion) " +
                     "values('" + codigo + "'," + fk_fuente_financiamiento + "," + fk_auxiliar_contable + "," + correlativo + "," + fk_modelo + ",'" + serie + "','" + descripcion + "','" + f_registro + "'," + fkc_estado_proceso + ",@tasa_ufv,@tasa_sus,@costo,@gastos_con_credito_fiscal,@gastos_sin_credito_fiscal,@valor_inicial," + fk_compra + "," + fk_proveedor + "," + fkc_tipo_adquisicion + ",'" + f_inicio_garantia + "','" + f_fin_garantia + "',@valor_inicial,@vida_util_alterna,1,'" + userName + "','" + DateTime.Now + "')";
                
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
        /// modifica datos de un activo en compras
        /// </summary>
        /// <param name="fk_compra"></param>
        /// <param name="descripcion"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="serie"></param>
        /// <param name="costo_bs"></param>
        /// <param name="costo_ufv"></param>
        /// <param name="costo_sus"></param>
        /// <param name="f_inicio_garantia"></param>
        /// <param name="f_fin_garantia"></param>
        /// <returns></returns>
        public int ModificaActivoCompra(int idActivo,int fk_compra, string descripcion, int marca,int modelo,string serie,decimal costo_bs,decimal gastos_con_credito_fiscal, decimal gastos_sin_credito_fiscal,string f_inicio_garantia,string f_fin_garantia)
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

                    command.Parameters.Add("@idActivo", SqlDbType.Int).Value = idActivo;
                    command.Parameters.Add("@fk_compra", SqlDbType.Int).Value = fk_compra;
                    command.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
                    command.Parameters.Add("@marca", SqlDbType.Int).Value = marca;
                    command.Parameters.Add("@modelo", SqlDbType.Int).Value = modelo;
                    command.Parameters.Add("@serie", SqlDbType.NVarChar).Value =serie;
                    command.Parameters.Add("@costo", SqlDbType.Decimal).Value = decimal.Round(costo_bs, 5);
                    command.Parameters.Add("@gastos_con_credito_fiscal", SqlDbType.Decimal).Value = gastos_con_credito_fiscal;
                    command.Parameters.Add("@gastos_sin_credito_fiscal", SqlDbType.Decimal).Value = gastos_sin_credito_fiscal;
                    command.Parameters.Add("@valor_inicial", SqlDbType.Decimal).Value = ((costo_bs+gastos_con_credito_fiscal)*87/100)+gastos_sin_credito_fiscal;
                   
                    command.Parameters.Add("@f_inicio_garantia", SqlDbType.NVarChar).Value = f_inicio_garantia;
                    command.Parameters.Add("@f_fin_garantia", SqlDbType.NVarChar).Value = f_fin_garantia;


                    command.CommandText =
                     "update activos set costo_actualizado_inicial=@valor_inicial,descripcion=@descripcion, fk_modelo=@modelo, serie=@serie,costo=@costo,gastos_con_credito_fiscal=@gastos_con_credito_fiscal,gastos_sin_credito_fiscal=@gastos_sin_credito_fiscal,valor_inicial=@valor_inicial, f_inicio_garantia=@f_inicio_garantia,f_fin_garantia=@f_fin_garantia, usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
                     "where id=@idActivo";
                    

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
        /// Genera el codigo de un activo fijo
        /// </summary>
        /// <param name="fk_auxiliar_contable"></param>
        /// <returns></returns>
        public string generaCodigoActivo(int fk_fuente_financiamiento, int fk_auxiliar_contable,string correlativo)
        {
            string result = "";
            //string query = "select '591'+"+
            //    "(select sigla from fuente_financiamiento where activo=1 and id=" + fk_fuente_financiamiento + ")+"+
            //    "(select codigo from grupos_contables "+
            //    "where id=(select fk_grupo_contable from auxiliares_contables where activo=1 and id="+fk_auxiliar_contable+") "+
            //    "and activo=1)"+
            //    "+(select codigo from auxiliares_contables where activo=1 and id=" + fk_auxiliar_contable + ")+'" + correlativo + "'";

            string query = "select '591'+" +
               "(select sigla from fuente_financiamiento where activo=1 and id=" + fk_fuente_financiamiento + ")+" +
               "(select codigo from grupos_contables " +
               "where id=(select fk_grupo_contable from auxiliares_contables where activo=1 and id=" + fk_auxiliar_contable + ") " +
               "and activo=1)" +
               "+'" + correlativo + "'";
            result = SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString();
            return result;
        }
        /// <summary>
        /// Obtiene el correlativo de un auxiliar contable
        /// </summary>
        /// <param name="fk_auxiliar_contable"></param>
        /// <returns></returns>
        public string obtieneCorrelativo(int fk_fuente_financiamiento,int fk_auxiliar_contable)
        {
            string result = "";
            //string query = "select RIGHT('00000' + CAST(ISNULL(max(CAST(correlativo AS INT) )+1,'1') AS VARCHAR(10)), 5) "+
            //                "from activos "+
            //                "where fk_auxiliar_contable="+fk_auxiliar_contable+" "+
            //                "and fk_fuente_financiamiento=" + fk_fuente_financiamiento + " " +
            //                "and activo=1";

            //string query = " select  top (1)vista.codigo from "+
            // "( "+
            // "select distinct RIGHT('00000' + CAST(ISNULL(CAST(a.correlativo+1 AS INT),'1') AS VARCHAR(10)), 5) codigo "+
            //                "from activos a "+
            //                "where fk_auxiliar_contable="+fk_auxiliar_contable+" "+
            //                "and fk_fuente_financiamiento="+fk_fuente_financiamiento+" "+
            //                "and activo=1 "+      
            //                "and not exists (select correlativo "+
            //                                "from activos b "+
            //                                "where fk_auxiliar_contable="+fk_auxiliar_contable+" "+
            //                                "and fk_fuente_financiamiento="+fk_fuente_financiamiento+" "+
            //                                "and activo=1 "+
            //                                "and b.correlativo=a.correlativo+1) "+    
            //                                "union "+
            //               "select distinct RIGHT('00000' + CAST(ISNULL(max(CAST(correlativo AS INT) )+1,'1') AS VARCHAR(10)), 5) codigo "+
            //                "from activos "+ 
            //                "where fk_auxiliar_contable="+fk_auxiliar_contable+" "+
            //               "and fk_fuente_financiamiento="+fk_fuente_financiamiento+" "+
            //               "and activo=1 "+
            //               "union "+
            //               "select distinct RIGHT('00000' + CAST(ISNULL(1,'1') AS VARCHAR(10)), 5) codigo "+
            //               "from activos a "+
            //               "where fk_auxiliar_contable="+fk_auxiliar_contable+" "+
            //               "and fk_fuente_financiamiento="+fk_fuente_financiamiento+" "+
            //               "and activo=1 "+
            //               "and not exists (select 1 "+
            //                                "from activos b "+
            //                                "where fk_auxiliar_contable="+fk_auxiliar_contable+" "+
            //                                "and fk_fuente_financiamiento="+fk_fuente_financiamiento+" "+
            //                                "and activo=1 "+
            //                                "and b.correlativo=1) "+
            //    ") vista "+
            //    "order by codigo asc";

            string queryGrupoContable = "select fk_grupo_contable from auxiliares_contables where id=" + fk_auxiliar_contable + "";


            int fk_grupo_contable = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, queryGrupoContable).ToString());

            string query = "select  top (1)vista.codigo from " +
             "( " +
             "select distinct RIGHT('00000' + CAST(ISNULL(CAST(a.correlativo+1 AS INT),'1') AS VARCHAR(10)), 5) codigo " +
                            "from activos a " +
                            "where (select fk_grupo_contable from auxiliares_contables where id=a.fk_auxiliar_contable)=" + fk_grupo_contable + "" +
                            "and fk_fuente_financiamiento="+fk_fuente_financiamiento+" " +
                            "and activo=1  " +
                            "and not exists (select correlativo " +
                                            "from activos b " +
                                            "where (select fk_grupo_contable from auxiliares_contables where id=b.fk_auxiliar_contable)=" + fk_grupo_contable + "" +
                                            "and fk_fuente_financiamiento=" + fk_fuente_financiamiento + " " +
                                            "and activo=1 " +
                                            "and b.correlativo=a.correlativo+1) " +
                                            "union " +
                           "select distinct RIGHT('00000' + CAST(ISNULL(max(CAST(correlativo AS INT) )+1,'1') AS VARCHAR(10)), 5) codigo " +
                           "from activos a " +
                           "where (select fk_grupo_contable from auxiliares_contables where id=a.fk_auxiliar_contable)=" + fk_grupo_contable + " " +
                           "and fk_fuente_financiamiento=" + fk_fuente_financiamiento + " " +
                           "and activo=1 " +
                           "union " +
                           "select distinct RIGHT('00000' + CAST(ISNULL(1,'1') AS VARCHAR(10)), 5) codigo " +
                           "from activos a " +
                           "where (select fk_grupo_contable from auxiliares_contables where id=a.fk_auxiliar_contable)=" + fk_grupo_contable + " " +
                           "and fk_fuente_financiamiento=" + fk_fuente_financiamiento + " " +
                           "and activo=1 " +
                           "and not exists (select 1 " +
                                            "from activos b " +
                                            "where (select fk_grupo_contable from auxiliares_contables where id=b.fk_auxiliar_contable)="+fk_grupo_contable+" " +
                                            "and fk_fuente_financiamiento=" + fk_fuente_financiamiento + " " +
                                            "and activo=1 " +
                                            "and b.correlativo=1) " +
                ") vista " +
                "order by codigo asc";

            result = SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString();
            return result;
        }
        /// <summary>
        /// Obtiene la lista de activos por compra
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns></returns>
        public List<ActivoEntity> List_datosActivosPorCompra(int idCompra)
        {
            string query =
        "select a.id,a.codigo,a.correlativo,a.fk_fuente_financiamiento, "+
		"(select ff.nombre from fuente_financiamiento ff where ff.id=a.fk_fuente_financiamiento) fuente_financiamiento, "+
		"(select fk_grupo_contable from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable ) fk_grupo_contable, "+
		"(select gc.nombre from grupos_contables gc where gc.id=(select fk_grupo_contable from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable )) grupo_contable, "+
		"(select gc.vida_util from grupos_contables gc where gc.id=(select fk_grupo_contable from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable )) vida_util, "+
		"a.vida_util_especifica vida_util_alterna, "+
        "a.fk_auxiliar_contable, "+
		"(select ac.nombre from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable) auxiliar_contable, "+
		"(select fk_marca from modelos m where m.id=a.fk_modelo) fk_marca, "+
		"(select nombre from marcas m where m.id=(select fk_marca from modelos m where m.id=a.fk_modelo)) marca, "+
		"a.fk_modelo, "+
		"(select m.nombre from modelos m where m.id=a.fk_modelo) modelo, "+
		"a.serie,a.descripcion,a.f_registro,a.fkc_estado_activo, "+
		"(select c.nombre from clasificadores c where c.id=a.fkc_estado_activo) estado_activo, "+
		"a.fkc_estado_proceso, "+
		"(select c.nombre from clasificadores c where c.id=a.fkc_estado_proceso) estado_proceso, "+
		"a.tasa_ufv,a.tasa_sus,a.costo,a.gastos_con_credito_fiscal,a.gastos_sin_credito_fiscal, "+
		"a.valor_inicial,a.fk_compra,a.fk_proveedor, "+
        "(select p.nombre from proveedores p where p.id=a.fk_proveedor) proveedor, "+
		"a.fkc_tipo_adquisicion, "+
		"(select c.nombre from clasificadores c where c.id=a.fkc_tipo_adquisicion) tipo_adquisicion,a.f_inicio_garantia,a.f_fin_garantia "+
        "from activos a "+
        "where a.fk_compra="+idCompra+" "+
        "and a.activo=1";

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<ActivoEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                        orderby  AnyName.Field<string>("codigo") ascending
                                        select new ActivoEntity()
                                                  {
                                                      id = AnyName.Field<int>("id"),
                                                      codigo = AnyName.Field<string>("codigo"),
                                                      fk_fuente_financiamiento=AnyName.Field<int>("fk_fuente_financiamiento"),
                                                      fuente_financiamiento = AnyName.Field<string>("fuente_financiamiento"),
                                                      fk_grupo_contable = AnyName.Field<int>("fk_grupo_contable"),
                                                      grupo_contable = AnyName.Field<string>("grupo_contable"),
                                                      vida_util = AnyName.Field<int>("vida_util"),
                                                      vida_util_alterna = AnyName["vida_util_alterna"].ToString(),
                                                      fk_auxiliar_contable = AnyName.Field<int>("fk_auxiliar_contable"),
                                                      auxiliar_contable = AnyName.Field<string>("auxiliar_contable"),
                                                      correlativo = AnyName.Field<int>("correlativo"),
                                                      fk_marca = AnyName.Field<int>("fk_marca"),
                                                      marca = AnyName.Field<string>("marca"),
                                                      fk_modelo = AnyName.Field<int>("fk_modelo"),
                                                      modelo = AnyName.Field<string>("modelo"),
                                                      serie = AnyName.Field<string>("serie"),
                                                      descripcion = AnyName.Field<string>("descripcion"),
                                                      f_registro = AnyName.Field<DateTime>("f_registro").ToString("dd/MM/yyyy"),
                                                      fkc_estado_proceso = AnyName.Field<int>("fkc_estado_proceso"),
                                                      estado_proceso = AnyName.Field<string>("estado_proceso"),
                                                      tasa_ufv = AnyName.Field<decimal>("tasa_ufv"),
                                                      tasa_sus = AnyName.Field<decimal>("tasa_sus"),
                                                      costo = AnyName.Field<decimal>("costo"),
                                                      gastos_con_credito_fiscal = AnyName.Field<decimal>("gastos_con_credito_fiscal"),
                                                      gastos_sin_credito_fiscal = AnyName.Field<decimal>("gastos_sin_credito_fiscal"),
                                                      valor_inicial = AnyName.Field<decimal>("valor_inicial"),
                                                      f_inicio_garantia = AnyName.Field<DateTime>("f_inicio_garantia").ToString("dd/MM/yyyy"),
                                                      f_fin_garantia = AnyName.Field<DateTime>("f_fin_garantia").ToString("dd/MM/yyyy"),
                                                  }).ToList();
            return Lista;
        }

        /// <summary>
        /// Obtiene la lista de activos agrupado por marca
        /// </summary>
        /// <returns></returns>
        public DataTable List_datosCantActivosPorMarca()
        {
            string query =
            "select ma.nombre,count(*) from "+
            "(select id,fk_modelo "+
            "from activos "+
            "where activo=1 "+
            ") vista "+
            "inner join modelos mo on mo.id=vista.fk_modelo "+
            "inner join marcas ma on ma.id=mo.fk_marca "+
            "group by ma.nombre ";

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }


        /// <summary>
        /// Elimina un activo por compra cuando el estado esta en elaborado
        /// </summary>
        /// <param name="idActivo"></param>
        /// <returns></returns>
        public int EliminaActivo(int idActivo)
        {
            using (SqlConnection connection = new SqlConnection(conexion.connectionString))
            {
                
                
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                //command.Parameters.Add("@valor_inicial", SqlDbType.Decimal).Value = valor_inicial_bs;

                //command.Parameters.Add("@valor_inicial_ufv", SqlDbType.Decimal).Value = valor_inicial_ufv;

                //command.Parameters.Add("@valor_inicial_sus", SqlDbType.Decimal).Value = valor_inicial_sus;

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
                     "update activos set activo=0,usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' where id=" + idActivo + "";

                    command.ExecuteNonQuery();
                    //command.CommandText =
                    // "update compras set monto_bs=monto_bs-@valor_inicial ,monto_ufv=monto_ufv-@valor_inicial_ufv,monto_sus=monto_sus-@valor_inicial_sus, " +
                    // "usuariomodificacion='"+userName+"', fechamodificacion='"+DateTime.Now+"' "+
                    // "where activo=1 " +
                    // "and id=" + idCompra + "";
                    //command.ExecuteNonQuery();

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
        /// Crea un activo por transferencia
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="correlativo"></param>
        /// <param name="fk_fuente_financiamiento"></param>
        /// <param name="fk_auxiliar_contable"></param>
        /// <param name="fk_modelo"></param>
        /// <param name="serie"></param>
        /// <param name="descripcion"></param>
        /// <param name="f_registro"></param>
        /// <param name="fkc_estado_activo"></param>
        /// <param name="fkc_estado_proceso"></param>
        /// <param name="tasa_ufv"></param>
        /// <param name="tasa_sus"></param>
        /// <param name="valor_inicial"></param>
        /// <param name="valor_actual"></param>
        /// <param name="valor_inicial_ufv"></param>
        /// <param name="valor_actual_ufv"></param>
        /// <param name="valor_inicial_sus"></param>
        /// <param name="valor_actual_sus"></param>
        /// <param name="fk_transferencia"></param>
        /// <param name="fkc_tipo_adquisicion"></param>
        /// <returns></returns>
        public int CreaActivoPorTransferencia(string codigo, string correlativo, int fk_fuente_financiamiento, int fk_auxiliar_contable, int fk_modelo, string serie, string descripcion, DateTime f_registro, int fkc_estado_activo, int fkc_estado_proceso, decimal tasa_ufv, decimal tasa_sus, decimal valor_inicial, int fk_transferencia,  int fkc_tipo_adquisicion)
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


                    command.Parameters.Add("@tasa_ufv", SqlDbType.Decimal).Value = tasa_ufv;
                    command.Parameters.Add("@tasa_sus", SqlDbType.Decimal).Value = tasa_sus;

                   

                    command.Parameters.Add("@costo", SqlDbType.Decimal).Value = decimal.Round(valor_inicial, 5);
                    //command.Parameters.Add("@valor_actual", SqlDbType.Decimal).Value = decimal.Round(valor_actual, 5);
                    command.Parameters.Add("@gastos_con_credito_fiscal", SqlDbType.Decimal).Value = 0;
                    //command.Parameters.Add("@valor_actual_ufv", SqlDbType.Decimal).Value = valor_actual_ufv;
                    command.Parameters.Add("@gastos_sin_credito_fiscal", SqlDbType.Decimal).Value = 0;
                    //command.Parameters.Add("@valor_actual_sus", SqlDbType.Decimal).Value = valor_actual_sus;

                    command.CommandText =
                     "insert into activos " +
                     "(codigo,fk_fuente_financiamiento,fk_auxiliar_contable,correlativo,fk_modelo,serie,descripcion,f_registro,fkc_estado_proceso,tasa_ufv,tasa_sus,valor_inicial,gastos_con_credito_fiscal,gastos_sin_credito_fiscal,fk_transferencia,fkc_tipo_adquisicion,costo_actualizado_inicial,activo,usuariocreacion,fechacreacion) " +
                     "values('" + codigo + "'," + fk_fuente_financiamiento + "," + fk_auxiliar_contable + "," + correlativo + "," + fk_modelo + ",'" + serie + "','" + descripcion + "','" + f_registro + "'," + fkc_estado_proceso + ",@tasa_ufv,@tasa_sus,@costo,@gastos_con_credito_fiscal,@gastos_sin_credito_fiscal," + fk_transferencia + "," + fkc_tipo_adquisicion + ",@costo,1,'" + userName + "','" + DateTime.Now + "')";

                    command.ExecuteNonQuery();
                    //command.CommandText =
                    // "update transferencias set monto_bs=monto_bs+ @valor_inicial,monto_ufv=monto_ufv+@valor_inicial_ufv,monto_sus=monto_sus+@valor_inicial_sus " +
                    // "where activo=1 " +
                    // "and id=" + fk_transferencia + "";
                    //command.ExecuteNonQuery();

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
        /// Obtiene lista de activos por transferencia
        /// </summary>
        /// <param name="idTransferencia"></param>
        /// <returns></returns>
        public List<ActivoEntity> List_datosActivosPorTransferencia(int idTransferencia)
        {
            string query =
        "select a.id,a.codigo,a.fk_fuente_financiamiento, " +
        "(select ff.nombre from fuente_financiamiento ff where ff.id=a.fk_fuente_financiamiento) fuente_financiamiento, " +
        "(select fk_grupo_contable from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable ) fk_grupo_contable, " +
        "(select gc.nombre from grupos_contables gc where gc.id=(select fk_grupo_contable from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable )) grupo_contable, " +
        "a.fk_auxiliar_contable, " +
        "(select ac.nombre from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable) auxiliar_contable, " +
        "a.correlativo, " +
        "(select fk_marca from modelos m where m.id=a.fk_modelo) fk_marca, " +
        "(select nombre from marcas m where m.id=(select fk_marca from modelos m where m.id=a.fk_modelo)) marca, " +
        "a.correlativo,a.fk_modelo, " +
        "(select m.nombre from modelos m where m.id=a.fk_modelo) modelo, " +
        "a.serie,a.descripcion,a.f_registro,a.fkc_estado_activo, " +
        "(select c.nombre from clasificadores c where c.id=a.fkc_estado_activo) estado_activo, " +
        "a.fkc_estado_proceso, " +
        "(select c.nombre from clasificadores c where c.id=a.fkc_estado_proceso) estado_proceso, " +
        "a.tasa_ufv,a.tasa_sus, " +
        "a.valor_inicial, " +
        "a.fkc_tipo_adquisicion, " +
        "(select c.nombre from clasificadores c where c.id=a.fkc_tipo_adquisicion) tipo_adquisicion,a.activo " +
        "from activos a " +
        "where a.fk_transferencia=" + idTransferencia + " " +
        "and a.activo=1";

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<ActivoEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                        orderby AnyName.Field<string>("codigo") ascending
                                        select new ActivoEntity()
                                        {
                                            id = AnyName.Field<int>("id"),
                                            codigo = AnyName.Field<string>("codigo"),
                                            fk_fuente_financiamiento = AnyName.Field<int>("fk_fuente_financiamiento"),
                                            fuente_financiamiento = AnyName.Field<string>("fuente_financiamiento"),
                                            fk_grupo_contable = AnyName.Field<int>("fk_grupo_contable"),
                                            grupo_contable = AnyName.Field<string>("grupo_contable"),
                                            fk_auxiliar_contable = AnyName.Field<int>("fk_auxiliar_contable"),
                                            auxiliar_contable = AnyName.Field<string>("auxiliar_contable"),
                                            correlativo = AnyName.Field<int>("correlativo"),
                                            fk_marca = AnyName.Field<int>("fk_marca"),
                                            marca = AnyName.Field<string>("marca"),
                                            fk_modelo = AnyName.Field<int>("fk_modelo"),
                                            modelo = AnyName.Field<string>("modelo"),
                                            serie = AnyName.Field<string>("serie"),
                                            descripcion = AnyName.Field<string>("descripcion"),
                                            f_registro = AnyName.Field<DateTime>("f_registro").ToString("dd/MM/yyyy"),
                                            //fkc_estado_activo = AnyName.Field<int>("fkc_estado_activo"),
                                            //estado_activo = AnyName.Field<string>("estado_activo"),
                                            fkc_estado_proceso = AnyName.Field<int>("fkc_estado_proceso"),
                                            estado_proceso = AnyName.Field<string>("estado_proceso"),
                                            tasa_ufv = AnyName.Field<decimal>("tasa_ufv"),
                                            tasa_sus = AnyName.Field<decimal>("tasa_sus"),
                                            //valor_actual = AnyName.Field<decimal>("valor_actual"),
                                            valor_inicial = AnyName.Field<decimal>("valor_inicial"),
                                          
                                            //valor_actual_ufv = AnyName.Field<decimal>("valor_actual_ufv"),
                                           
                                            //valor_actual_sus = AnyName.Field<decimal>("valor_actual_sus")
                                        }).ToList();
            return Lista;
        }

        /// <summary>
        /// Elimina un activo y actualiza sus montos en transferencias
        /// </summary>
        /// <param name="idActivo"></param>
        /// <param name="idTransferencia"></param>
        /// <param name="valor_inicial_bs"></param>
        /// <param name="valor_inicial_ufv"></param>
        /// <param name="valor_inicial_sus"></param>
        /// <returns></returns>
        public int EliminaActivoPorTransferencia(int idActivo)
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

                    //command.Parameters.Add("@valor_inicial", SqlDbType.Decimal).Value = valor_inicial_bs;
                    //command.Parameters.Add("@valor_inicial_ufv", SqlDbType.Decimal).Value = valor_inicial_ufv;
                    //command.Parameters.Add("@valor_inicial_sus", SqlDbType.Decimal).Value = valor_inicial_sus;

                    command.CommandText =
                     "update activos set activo=0, usuariomodificacion='" + userName + "',fechamodificacion='"+DateTime.Now+"' where id=" + idActivo + "";

                    command.ExecuteNonQuery();
                    //command.CommandText =
                    // "update transferencias set monto_bs=monto_bs-@valor_inicial ,monto_ufv=monto_ufv-@valor_inicial_ufv,monto_sus=monto_sus-@valor_inicial_sus, " +
                    // "usuariomodificacion='"+userName+"', fechamodificacion='"+DateTime.Now+"'"+
                    // "where activo=1 " +
                    // "and id=" + idTransferencia + "";
                    //command.ExecuteNonQuery();

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



        public List<ActivoEntity> List_datosActivosNoAsignados()
        {
            string query =
        "select a.id,a.codigo,a.fk_fuente_financiamiento, " +
        "(select ff.nombre from fuente_financiamiento ff where ff.id=a.fk_fuente_financiamiento) fuente_financiamiento, " +
        "(select fk_grupo_contable from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable ) fk_grupo_contable, " +
        "(select gc.nombre from grupos_contables gc where gc.id=(select fk_grupo_contable from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable )) grupo_contable, " +
        "a.fk_auxiliar_contable, " +
        "(select ac.nombre from auxiliares_contables ac where ac.id=a.fk_auxiliar_contable) auxiliar_contable, " +
        "a.correlativo, " +
        "(select fk_marca from modelos m where m.id=a.fk_modelo) fk_marca, " +
        "(select nombre from marcas m where m.id=(select fk_marca from modelos m where m.id=a.fk_modelo)) marca, " +
        "a.correlativo,a.fk_modelo, " +
        "(select m.nombre from modelos m where m.id=a.fk_modelo) modelo, " +
        "a.serie,a.descripcion,a.f_registro,a.fkc_estado_activo, " +
        "(select c.nombre from clasificadores c where c.id=a.fkc_estado_activo) estado_activo, " +
        "a.fkc_estado_proceso, " +
        "(select c.nombre from clasificadores c where c.id=a.fkc_estado_proceso) estado_proceso, " +
        "a.tasa_ufv,a.tasa_sus, " +
        "a.valor_inicial,a.fk_compra,a.fk_proveedor, " +
        "(select p.nombre from proveedores p where p.id=a.fk_proveedor) proveedor, " +
        "a.fkc_tipo_adquisicion, " +
        "(select c.nombre from clasificadores c where c.id=a.fkc_tipo_adquisicion) tipo_adquisicion,a.f_inicio_garantia,a.f_fin_garantia,a.activo " +
        "from activos a " +
        "where a.fkc_estado_proceso=5" +
        "and a.activo=1";

            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<ActivoEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                        orderby AnyName.Field<string>("codigo") ascending
                                        select new ActivoEntity()
                                        {
                                            id = AnyName.Field<int>("id"),
                                            codigo = AnyName.Field<string>("codigo"),
                                            fk_fuente_financiamiento = AnyName.Field<int>("fk_fuente_financiamiento"),
                                            fuente_financiamiento = AnyName.Field<string>("fuente_financiamiento"),
                                            fk_grupo_contable = AnyName.Field<int>("fk_grupo_contable"),
                                            grupo_contable = AnyName.Field<string>("grupo_contable"),
                                            fk_auxiliar_contable = AnyName.Field<int>("fk_auxiliar_contable"),
                                            auxiliar_contable = AnyName.Field<string>("auxiliar_contable"),
                                            correlativo = AnyName.Field<int>("correlativo"),
                                            fk_marca = AnyName.Field<int>("fk_marca"),
                                            marca = AnyName.Field<string>("marca"),
                                            fk_modelo = AnyName.Field<int>("fk_modelo"),
                                            modelo = AnyName.Field<string>("modelo"),
                                            serie = AnyName.Field<string>("serie"),
                                            descripcion = AnyName.Field<string>("descripcion"),
                                            fkc_estado_proceso = AnyName.Field<int>("fkc_estado_proceso"),
                                            estado_proceso = AnyName.Field<string>("estado_proceso"),
                                            tasa_ufv = AnyName.Field<decimal>("tasa_ufv"),
                                            tasa_sus = AnyName.Field<decimal>("tasa_sus"),
                                            //valor_actual = AnyName.Field<decimal>("valor_actual"),
                                            valor_inicial = AnyName.Field<decimal>("valor_inicial"),
                                           
                                            //valor_actual_ufv = AnyName.Field<decimal>("valor_actual_ufv"),
                                           
                                            //valor_actual_sus = AnyName.Field<decimal>("valor_actual_sus"),
                                           
                                        }).ToList();
            return Lista;
        }

        /// <summary>
        /// Obtiene los activos existentes
        /// </summary>
        /// <returns></returns>
        public DataTable List_datosExistenciaActivos()
        {
            string query =
            "select id,codigo,descripcion,serie,f_registro from activos where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }

        /// <summary>
        /// Obtiene el reporte de activos por responsable
        /// </summary>
        /// <param name="fk_persona"></param>
        /// <returns></returns>
        public DataSet ReporteActivosPorResponsable(string fk_persona)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);


            DataTable TablaActivosPorResponsable = new DataTable();

            dsActivosPorResponsable dsActivosPorResponsable = new dsActivosPorResponsable();



            dsActivosPorResponsable.Tables["activos_responsables"].Clear();

    
            string query = "select a.fk_persona, "+
                            "(select documento from personal where id = a.fk_persona) documento, " +
	                                   "(select nombres from personal where id = a.fk_persona) nombres, "+
                                       "(select apellidos from personal where id = a.fk_persona) apellidos, " +
                                       "(select gerencia from personal where id = a.fk_persona) gerencia, " +
                                       "(select area from personal where id = a.fk_persona) area, " +
	                                   "a.fk_activo, "+
	                                   "(select codigo from activos where id=a.fk_activo) codigo, "+
	                                   "(select descripcion from activos where id=a.fk_activo) descripcion "+
                                "from asignaciones_detalle a where a.activo=1 and a.fkc_estado_proceso=10 "+
                                "and a.fk_persona='" + fk_persona + "' "+
                                "UNION "+
                                "select t.fk_persona_destino, "+
                                "(select documento from personal where id = t.fk_persona_destino) documento, "+
	                                   "(select nombres from personal where id = t.fk_persona_destino) nombres, "+ 
                                       "(select apellidos from personal where id = t.fk_persona_destino) apellidos, "+ 
                                       "(select gerencia from personal where id = t.fk_persona_destino) gerencia, "+
                                       "(select area from personal where id = t.fk_persona_destino) area, "+
	                                   "t.fk_activo, "+
	                                   "(select codigo from activos where id=t.fk_activo) codigo, "+
	                                   "(select descripcion from activos where id=t.fk_activo) descripcion "+
                                "from asignaciones_por_transferencias_detalle t where t.activo=1 and t.fkc_estado_proceso=10 "+
                                "and t.fk_persona_destino='" + fk_persona + "'";


        
                TablaActivosPorResponsable.Clear();
                TablaActivosPorResponsable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
                foreach (DataRow rowDetalle in TablaActivosPorResponsable.Rows)
                {
                 
                    //string fk_persona = rowDetalle["fk_persona"].ToString();
                    
                    string nombres = rowDetalle["nombres"].ToString();
                    string apellidos = rowDetalle["apellidos"].ToString();
                    string gerencia = rowDetalle["gerencia"].ToString();
                    string area = rowDetalle["area"].ToString();
                    string fk_activo = rowDetalle["fk_activo"].ToString();
                    string codigo = rowDetalle["codigo"].ToString();
                    string descripcion = rowDetalle["descripcion"].ToString();
                    string nro_documento = rowDetalle["documento"].ToString();

                    dsActivosPorResponsable.Tables["activos_responsables"].Rows.Add(new object[] {
                      fk_persona,
                      nombres,
                      apellidos,
                      gerencia,
                      area,
                      fk_activo,
                      codigo,
                      descripcion,
                      nro_documento,
                      iniciales


                    });
                }
                return dsActivosPorResponsable;
            }


        /// <summary>
        /// Obtiene reporte de activos asignados para agrupar
        /// </summary>
        /// <returns></returns>
        public DataSet ReporteActivosPorGrupo()
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);


            DataTable TablaActivosPorGrupo= new DataTable();

            dsActivosPorGrupos dsActivosPorGrupo = new dsActivosPorGrupos();



            dsActivosPorGrupo.Tables["activos_asignados"].Clear();


            string query = "select p.documento fk_persona, p.nombres,p.apellidos,p.gerencia,p.area,ac.id fk_activo,ac.codigo,ac.descripcion, ac.fk_auxiliar_contable, ax.nombre auxiliar_contable, "+
									   "ac.fk_modelo,m.nombre modelo,m.fk_marca,ma.nombre marca,ax.fk_grupo_contable,g.nombre grupo_contable, am.fk_estacion, "+
                                       "isnull((select nombre from estaciones e where e.id=am.fk_estacion),'OFICINAS ADMINISTRATIVAS') estacion, " +
									   "(select fk_linea from estaciones e where e.id=am.fk_estacion) fk_linea, "+
                                       "isnull((select nombre from lineas l where l.id=(select fk_linea from estaciones e where e.id=am.fk_estacion)),'OFICINAS ADMINISTRATIVAS') linea " +
                                "from asignaciones_detalle a "+
                                "inner join asignaciones_maestro am on am.id=a.fk_asignacion_maestro "+
                                "inner join activos ac on a.fk_activo=ac.id "+
                                "inner join personal p on p.id=a.fk_persona "+
                                "inner join auxiliares_contables ax on ax.id=ac.fk_auxiliar_contable "+
                                "inner join grupos_contables g on g.id=ax.fk_grupo_contable "+
                                "inner join modelos m on m.id=ac.fk_modelo "+
                                "inner join marcas ma on ma.id=m.fk_marca "+
                                "where a.activo=1 and a.fkc_estado_proceso=10 "+
                                "union "+
                                  "select p.documento fk_persona_destino, p.nombres,p.apellidos,p.gerencia,p.area,ac.id fk_activo,ac.codigo,ac.descripcion, ac.fk_auxiliar_contable, ax.nombre auxiliar_contable, "+
									   "ac.fk_modelo,m.nombre modelo,m.fk_marca,ma.nombre marca,ax.fk_grupo_contable,g.nombre grupo_contable, am.fk_estacion, "+
                                       "isnull((select nombre from estaciones e where e.id=am.fk_estacion),'OFICINAS ADMINISTRATIVAS') estacion, " +
									   "(select fk_linea from estaciones e where e.id=am.fk_estacion) fk_linea, "+
                                       "isnull((select nombre from lineas l where l.id=(select fk_linea from estaciones e where e.id=am.fk_estacion)),'OFICINAS ADMINISTRATIVAS') linea " +
                                "from asignaciones_por_transferencias_detalle a "+
                                "inner join asignaciones_por_transferencias_maestro am on am.id=a.fk_asignacion_por_transferencia_maestro "+
                                "inner join activos ac on a.fk_activo=ac.id "+
                                "inner join personal p on p.id=a.fk_persona_destino "+
                                "inner join auxiliares_contables ax on ax.id=ac.fk_auxiliar_contable "+
                                "inner join grupos_contables g on g.id=ax.fk_grupo_contable "+
                                "inner join modelos m on m.id=ac.fk_modelo "+
                                "inner join marcas ma on ma.id=m.fk_marca "+
                                "where a.activo=1 and a.fkc_estado_proceso=10";


            TablaActivosPorGrupo.Clear();
            TablaActivosPorGrupo = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivosPorGrupo.Rows)
            {
                string fk_persona = rowDetalle["fk_persona"].ToString();
                string nombres = rowDetalle["nombres"].ToString();
                string apellidos = rowDetalle["apellidos"].ToString();
                string gerencia = rowDetalle["gerencia"].ToString();
                string area = rowDetalle["area"].ToString();
                string fk_activo = rowDetalle["fk_activo"].ToString();
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                string fk_auxiliar_contable = rowDetalle["fk_auxiliar_contable"].ToString();
                string auxiliar_contable = rowDetalle["auxiliar_contable"].ToString();
                string fk_modelo = rowDetalle["fk_modelo"].ToString();
                string modelo = rowDetalle["modelo"].ToString();
                string fk_marca = rowDetalle["fk_marca"].ToString();
                string marca = rowDetalle["marca"].ToString();
                string fk_grupo_contable = rowDetalle["fk_grupo_contable"].ToString();
                string grupo_contable = rowDetalle["grupo_contable"].ToString();

                string fk_estacion = rowDetalle["fk_estacion"].ToString();
                string estacion = rowDetalle["estacion"].ToString();
                string fk_linea = rowDetalle["fk_linea"].ToString();
                string linea = rowDetalle["linea"].ToString();

                dsActivosPorGrupo.Tables["activos_asignados"].Rows.Add(new object[] {
                      fk_persona,
                      nombres,
                      apellidos,
                      gerencia,
                      area,
                      fk_activo,
                      codigo,
                      descripcion,
                      fk_auxiliar_contable,
                      auxiliar_contable,
                      fk_modelo,
                      modelo,
                      fk_marca,
                      marca,
                      fk_grupo_contable,
                      grupo_contable,
                      fk_estacion,
                      estacion,
                      fk_linea,
                      linea
                    });
            }
            return dsActivosPorGrupo;
        }



        //********************ACTIVOS POR ESTACION - LINEA - OFICINA****************************/


        /// <summary>
        /// Reporte de activos por estacion
        /// </summary>
        /// <param name="idEstacion"></param>
        /// <returns></returns>
        public DataSet ReporteActivosPorEstacion(int idEstacion)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsActivosPorEstacion dsActivosPorEstacion = new dsActivosPorEstacion();

            dsActivosPorEstacion.Tables["activos_estaciones"].Clear();


            string query = "select p.gerencia,p.area,p.documento,p.nombres,p.apellidos, a.id,a.codigo,a.descripcion,a.f_registro,e.nombre estacion "+
                            "from asignaciones_detalle d "+
                            "inner join asignaciones_maestro m on m.id=d.fk_asignacion_maestro "+
                            "inner join estaciones e on m.fk_estacion=e.id "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join personal p on p.id=d.fk_persona "+
                            "where m.activo=1 and d.activo=1 "+
                            "and d.fkc_estado_proceso=10 "+
                            "and e.id=" + idEstacion + " " +
                            "union "+
                            "select p.gerencia,p.area,p.documento,p.nombres,p.apellidos, a.id,a.codigo,a.descripcion,a.f_registro,e.nombre estacion "+
                            "from asignaciones_por_transferencias_detalle d "+
                            "inner join asignaciones_por_transferencias_maestro m on m.id=d.fk_asignacion_por_transferencia_maestro "+
                            "inner join estaciones e on m.fk_estacion=e.id "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join personal p on p.id=d.fk_persona_destino "+
                            "where m.activo=1 and d.activo=1 "+
                            "and d.fkc_estado_proceso=10 "+
                            "and e.id=" + idEstacion + "";


            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                string id = rowDetalle["id"].ToString();
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                string f_registro = rowDetalle["f_registro"].ToString();
                string estacion = rowDetalle["estacion"].ToString();
                string gerencia = rowDetalle["gerencia"].ToString();
                string area = rowDetalle["area"].ToString();
                string documento = rowDetalle["documento"].ToString();
                string nombres = rowDetalle["nombres"].ToString();
                string apellidos = rowDetalle["apellidos"].ToString();
                dsActivosPorEstacion.Tables["activos_estaciones"].Rows.Add(new object[] {
                     id,
                     codigo,
                     descripcion,
                     f_registro,
                     estacion,
                     iniciales,
                     gerencia,
                     area,
                     documento,
                     nombres,
                     apellidos
                    });
            }
            return dsActivosPorEstacion;
        }

        /// <summary>
        /// Reporte activos por linea
        /// </summary>
        /// <param name="idLinea"></param>
        /// <returns></returns>
        public DataSet ReporteActivosPorLinea(int idLinea)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsActivosPorLinea dsActivosPorLinea = new dsActivosPorLinea();

            dsActivosPorLinea.Tables["activos_lineas"].Clear();


            string query = "select p.gerencia,p.area,p.documento,p.nombres,p.apellidos, a.id,a.codigo,a.descripcion,a.f_registro,l.nombre linea "+
                            "from asignaciones_detalle d "+
                            "inner join asignaciones_maestro m on m.id=d.fk_asignacion_maestro "+
                            "inner join estaciones e on m.fk_estacion=e.id "+
                            "inner join lineas l on l.id=e.fk_linea "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join personal p on p.id=d.fk_persona "+
                            "where m.activo=1 and d.activo=1 "+
                            "and d.fkc_estado_proceso=10 "+
                            "and l.id=" + idLinea + " " +
                            "union "+
                            "select p.gerencia,p.area,p.documento,p.nombres,p.apellidos, a.id,a.codigo,a.descripcion,a.f_registro,l.nombre linea "+
                            "from asignaciones_por_transferencias_detalle d "+
                            "inner join asignaciones_por_transferencias_maestro m on m.id=d.fk_asignacion_por_transferencia_maestro "+
                            "inner join estaciones e on m.fk_estacion=e.id "+
                            "inner join lineas l on l.id=e.fk_linea "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join personal p on p.id=d.fk_persona_destino "+
                            "where m.activo=1 and d.activo=1 "+
                            "and d.fkc_estado_proceso=10 "+
                            "and l.id=" + idLinea + "";


            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                string id = rowDetalle["id"].ToString();
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                string f_registro = rowDetalle["f_registro"].ToString();
                string linea = rowDetalle["linea"].ToString();
                string gerencia = rowDetalle["gerencia"].ToString();
                string area = rowDetalle["area"].ToString();
                string documento = rowDetalle["documento"].ToString();
                string nombres = rowDetalle["nombres"].ToString();
                string apellidos = rowDetalle["apellidos"].ToString();
                dsActivosPorLinea.Tables["activos_lineas"].Rows.Add(new object[] {
                     id,
                     codigo,
                     descripcion,
                     f_registro,
                     linea,
                     iniciales,
                     gerencia,
                     area,
                     documento,
                     nombres,
                     apellidos
                    });
            }
            return dsActivosPorLinea;
        }

        /// <summary>
        /// Obtiene las existencias entre dos fechas
        /// </summary>
        /// <param name="f_inicio"></param>
        /// <param name="f_fin"></param>
        /// <returns></returns>
        public DataSet ReporteExistenciasActivosPorFecha(string fecha_inicio,string fecha_fin)
        {
          
           
            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsExistenciasActivos dsActivos = new dsExistenciasActivos();

            dsActivos.Tables["activos"].Clear();



            string query = "select id,codigo,descripcion,serie,f_registro from activos " +
                        "where activo=1 and f_registro between isnull(@fecha_inicio,'1900-01-01') and isnull (@fecha_fin,'9999-12-31')";
 
            SqlConnection sqlConnection = new SqlConnection(conexion.connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

          

            if(fecha_inicio == "")
                sqlCommand.Parameters.Add("@fecha_inicio", System.Data.SqlDbType.NVarChar).Value = System.Data.SqlTypes.SqlString.Null;
            else
                sqlCommand.Parameters.Add("@fecha_inicio", System.Data.SqlDbType.NVarChar).Value = DateTime.Parse(fecha_inicio);


            if (fecha_fin == "")
                sqlCommand.Parameters.Add("@fecha_fin", System.Data.SqlDbType.NVarChar).Value = System.Data.SqlTypes.SqlString.Null;
            else
                sqlCommand.Parameters.Add("@fecha_fin", System.Data.SqlDbType.NVarChar).Value = DateTime.Parse(fecha_fin);

       
 
            sqlConnection.Open();
 
            try{
                SqlDataAdapter da = new SqlDataAdapter();
                TablaActivos.Clear();
                da.SelectCommand = sqlCommand;
                da.Fill(TablaActivos);
            }
            catch(Exception exc){
               throw new Exception("Error al consultar datos", exc);
            }
            finally{
               sqlConnection.Close();
            }

            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                string id = rowDetalle["id"].ToString();
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                string serie = rowDetalle["serie"].ToString();
                string f_registro = rowDetalle["f_registro"].ToString();
                dsActivos.Tables["activos"].Rows.Add(new object[] {
                     id,
                     codigo,
                     descripcion,
                     serie,
                     f_registro,
                     iniciales
                     
                    });
            }
            return dsActivos;
        }


        public DataSet ReporteActivosOficina()
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsActivosOficina dsActivosOficina = new dsActivosOficina();

            dsActivosOficina.Tables["activos_oficina"].Clear();


            string query = "select p.gerencia,p.area,p.documento,p.nombres,p.apellidos, a.id,a.codigo,a.descripcion,a.f_registro "+
                            "from asignaciones_detalle d "+
                            "inner join asignaciones_maestro m on m.id=d.fk_asignacion_maestro "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join personal p on p.id=d.fk_persona "+
                            "where m.activo=1 and d.activo=1 "+
                            "and d.fkc_estado_proceso=10 "+
                            "union "+
                            "select p.gerencia,p.area,p.documento,p.nombres,p.apellidos, a.id,a.codigo,a.descripcion,a.f_registro "+
                            "from asignaciones_por_transferencias_detalle d "+
                            "inner join asignaciones_por_transferencias_maestro m on m.id=d.fk_asignacion_por_transferencia_maestro "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join personal p on p.id=d.fk_persona_destino "+
                            "where m.activo=1 and d.activo=1 "+
                            "and d.fkc_estado_proceso=10 "+
                            "order by apellidos,nombres";


            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                string id = rowDetalle["id"].ToString();
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                string f_registro = rowDetalle["f_registro"].ToString();
                string gerencia = rowDetalle["gerencia"].ToString();
                string area = rowDetalle["area"].ToString();
                string documento = rowDetalle["documento"].ToString();
                string nombres = rowDetalle["nombres"].ToString();
                string apellidos = rowDetalle["apellidos"].ToString();
                dsActivosOficina.Tables["activos_oficina"].Rows.Add(new object[] {
                     id,
                     codigo,
                     f_registro,
                     iniciales,
                     gerencia,
                     area,
                     documento,
                     nombres,
                     apellidos,
                     descripcion
                    });
            }
            return dsActivosOficina;
        }

        /// <summary>
        /// Resumen de activos por grupo (depreciaciones, actualizaciones)
        /// </summary>
        /// <returns></returns>
        public DataSet ReporteResumenActivosPorGrupo()
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            DataRow row;

            dsResumenActivosPorGrupo dsResumenActivos = new dsResumenActivosPorGrupo();

            dsResumenActivos.Tables["resumen_activos_grupo"].Clear();


            string query = "select gc.nombre grupo_contable, count(a.codigo) cantidad,gc.vida_util vida_util,sum(a.valor_inicial)costo_historico,sum(a.costo_actualizado_inicial) costo_actualizado_inicial ,sum(a.depreciacion_acumulada_total) depreciacion_acumulada_total, " +
                                 "sum(a.valor_neto_inicial) valor_neto_inicial,sum(a.actualizacion_gestion) actualizacion_gestion,sum(a.costo_total_actualizado) costo_total_actualizado,sum(a.depreciacion_gestion) depreciacion_gestion,sum(a.actualizacion_depreciacion_acumulada) actualizacion_depreciacion_acumulada,sum(a.depreciacion_acumulada) depreciacion_acumulada,isnull(sum(valor_neto),0) valor_neto, a.f_ult_act_dep f_ult_act_dep,gc.orden,(select tasa_ufv from tasa_cambio where f_tasa=a.f_ult_act_dep) tasa_ufv_final " +
                          "from activos a " +
                          "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable " +
                          "inner join grupos_contables gc on gc.id=ac.fk_grupo_contable " +
                          "where a.activo=1 and fkc_estado_proceso not in (24,25) " +
                          "group by gc.orden,gc.nombre,gc.vida_util,a.f_ult_act_dep order by gc.orden";


            //string query = "select gc.nombre grupo_contable, count(a.codigo) cantidad,gc.vida_util vida_util,sum(adg.costo_historico)costo_historico,sum(adg.costo_actualizado_inicial) costo_actualizado_inicial ,sum(adg.depreciacion_acumulada_total) depreciacion_acumulada_total, " +
            //                                             "sum(adg.valor_neto_inicial) valor_neto_inicial,sum(adg.actualizacion_gestion) actualizacion_gestion,sum(adg.costo_total_actualizado) costo_total_actualizado,sum(adg.depreciacion_gestion) depreciacion_gestion,sum(adg.actualizacion_depreciacion_acumulada) actualizacion_depreciacion_acumulada,sum(adg.depreciacion_acumulada) depreciacion_acumulada,isnull(sum(adg.valor_neto),0) valor_neto, '31/12/2014' f_ult_act_dep,gc.orden,(select tasa_ufv from tasa_cambio where f_tasa='31/12/2014') tasa_ufv_final " +
            //            "from actualizacion_depreciacion_gestion adg " +
            //            "inner join activos a on a.id=adg.fk_activo " +
            //            "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable " +
            //            "inner join grupos_contables gc on gc.id=ac.fk_grupo_contable " +
            //            "where a.activo=1 and adg.f_cierre='31/12/2014' " +
                        //"group by gc.orden,gc.nombre,gc.vida_util,a.f_ult_act_dep order by gc.orden";

            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];


            string query_ultima_actualizacion = "select max(f_ult_act_dep) f_ult_act_dep  from activos where activo=1 and fkc_estado_proceso not in (24,25)";

            row = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query_ultima_actualizacion).Tables[0].Rows[0];


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
                DateTime f_ult_act_dep = DateTime.Parse(row["f_ult_act_dep"].ToString());
                //DateTime f_ult_act_dep = DateTime.Parse(rowDetalle["f_ult_act_dep"].ToString());
                string tasa_ufv_final = rowDetalle["tasa_ufv_final"].ToString();

                dsResumenActivos.Tables["resumen_activos_grupo"].Rows.Add(new object[] {
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
                     tasa_ufv_final
                    });
            }
            return dsResumenActivos;
        }

        /// <summary>
        /// Obtiene la lista de los activos y sus campos de depreciacion y actualizacion
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns></returns>
        public DataTable List_datosDepreciacionActivos()
        {
            DataTable dtActivos = new DataTable();
            //string query = "select a.f_ult_act_dep,a.id,a.tasa_ufv,a.f_registro,gc.nombre grupo_contable,a.codigo,a.descripcion,gc.vida_util,a.valor_inicial costo_historico, a.costo_actualizado_inicial,a.depreciacion_acumulada_total,a.valor_neto_inicial,a.actualizacion_gestion,a.costo_total_actualizado,a.depreciacion_gestion,a.actualizacion_depreciacion_acumulada,depreciacion_acumulada,valor_neto " +
            //                "from activos a " +
            //                "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable " +
            //                "inner join grupos_contables gc on gc.id=ac.fk_grupo_contable " +
            //                "where a.activo=1 and fkc_estado_proceso not in (24,25)";
            dtActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.StoredProcedure, "[SP_DatosDetalleDepreciacion]").Tables[0];
            //dtActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtActivos;
        }
        /// <summary>
        /// Obtiene la lista de activos dados de baja
        /// </summary>
        /// <returns></returns>
        public DataTable List_datosActivosDadosDeBaja()
        {
            DataTable dtActivos = new DataTable();
            string query = "select a.id,a.codigo,a.descripcion,a.f_registro,bm.f_baja,mb.motivo_baja,bd.observaciones,a.tasa_ufv,gc.nombre grupo_contable,gc.vida_util vida_util,a.valor_inicial costo_historico,a.costo_actualizado_inicial costo_actualizado_inicial ,a.depreciacion_acumulada_total depreciacion_acumulada_total, "+
                                 "a.valor_neto_inicial valor_neto_inicial,a.actualizacion_gestion actualizacion_gestion,a.costo_total_actualizado costo_total_actualizado,gc.porcentaje_depreciacion porcentaje_depreciacion,datediff(day,a.f_registro,a.f_ult_act_dep)+1 dias,a.depreciacion_gestion depreciacion_gestion,a.actualizacion_depreciacion_acumulada actualizacion_depreciacion_acumulada,a.depreciacion_acumulada depreciacion_acumulada,isnull(valor_neto,0) valor_neto, a.f_ult_act_dep f_ult_act_dep,gc.orden,(select tasa_ufv from tasa_cambio where f_tasa=a.f_ult_act_dep) tasa_ufv_final,(select tasa_ufv from tasa_cambio where f_tasa=a.f_ult_act_dep)/a.tasa_ufv factor_actualizacion, "+
                                 "(select tasa_ufv from tasa_cambio where activo=1 and f_tasa=bm.f_baja) ufv_baja "+
                          "from activos a "+
                          "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable "+
                          "inner join grupos_contables gc on gc.id=ac.fk_grupo_contable "+
                          "inner join bajas_detalle bd on bd.fk_activo=a.id "+
                          "inner join bajas_maestro bm on bm.id=bd.fk_baja_maestro "+
                          "inner join motivos_baja mb on mb.id=bm.fkc_motivo_baja "+
                          "where bd.activo=1 and bd.fkc_estado_proceso in (25) "+
                          "order by gc.orden";

            dtActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            return dtActivos;
        }


        /// <summary>
        /// Deprecia los activos a una fecha determinada
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public int DepreciacionActivos(DateTime fecha)
        {
            try
            {
                int result = 0;
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, "[p_algoritmo_depreciacion_actualizacion]", fecha).ToString());
                return result;
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return 0;
            }
        }

        /// <summary>
        /// Obtiene la cantidad de activos en estado elaborado
        /// </summary>
        /// <returns></returns>
        public int getCantActivosEstadoElaborado()
        {
            try
            {
                int result = 0;
                string query = "select count(*) from activos "+
		                   "where fkc_estado_proceso=4 "+
		                   "and activo=1";
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());
               
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }



        /// <summary>
        /// Detalle de activos por grupo (depreciaciones, actualizaciones)
        /// </summary>
        /// <returns></returns>
        public DataSet ReporteDetalleActivosPorGrupo()
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();
            DataRow row;

            dsDetalleActivosPorGrupo dsDetalleActivos = new dsDetalleActivosPorGrupo();

            dsDetalleActivos.Tables["detalle_activos_grupo"].Clear();

            string query_ultima_actualizacion = "select max(f_ult_act_dep) f_ult_act_dep  from activos where activo=1 and fkc_estado_proceso not in (24,25)";

           // string query_ultima_actualizacion = "select '31/12/2014' f_ult_act_dep  from activos where activo=1 and fkc_estado_proceso not in (24,25)";

            row=SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query_ultima_actualizacion).Tables[0].Rows[0];

            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.StoredProcedure, "[SP_DatosDetalleDepreciacion]").Tables[0];
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
                DateTime f_ult_act_dep = DateTime.Parse(row["f_ult_act_dep"].ToString());
                //DateTime f_ult_act_dep = DateTime.Parse(rowDetalle["f_ult_act_dep"].ToString());
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
                     dias_general,
                     null,
                     null
                    });
            }
            return dsDetalleActivos;
        }

        /// <summary>
        /// Obtiene el reporte del detalle de bajas de activos fijos
        /// </summary>
        /// <returns></returns>
        public DataSet ReporteDetalleBajasActivos()
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();
            DataRow row;
            dsDetalleBajasActivos dsDetalleActivos = new dsDetalleBajasActivos();

            dsDetalleActivos.Tables["detalle_bajas_activos"].Clear();

            string query_ultima_actualizacion = "select max(f_ult_act_dep) f_ult_act_dep  from activos where activo=1 and fkc_estado_proceso not in (25)";

            row = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query_ultima_actualizacion).Tables[0].Rows[0];


            string query = "select a.id,a.codigo,a.descripcion,a.f_registro,bm.f_baja,mb.motivo_baja,bd.observaciones,(select tasa_ufv from tasa_cambio where f_tasa='01/01/'+cast(year(a.f_ult_act_dep) as nvarchar(4))) tasa_ufv,gc.nombre grupo_contable, a.codigo,gc.vida_util vida_util,a.valor_inicial costo_historico,a.costo_actualizado_inicial costo_actualizado_inicial ,a.depreciacion_acumulada_total depreciacion_acumulada_total, " +
                                 "a.valor_neto_inicial valor_neto_inicial,a.actualizacion_gestion actualizacion_gestion,a.costo_total_actualizado costo_total_actualizado,gc.porcentaje_depreciacion porcentaje_depreciacion,(datediff(day,(select case when (select count(dg.id) " +
                                                                                                                                                                                                                                                                            "from actualizacion_depreciacion_gestion dg " +
                                                                                                                                                                                                                                                                            "where dg.activo=1 and dg.gestion=year(a.f_ult_act_dep)-1 and dg.fk_activo=a.id " +
                                                                                                                                                                                                                                                                            ")=0 then a.f_registro " +
                                                                                                                                                                                                                                                          "else '01/01/'+cast(year(a.f_ult_act_dep) as nvarchar(4))+'' end),a.f_ult_act_dep)+1)dias,a.depreciacion_gestion depreciacion_gestion,a.actualizacion_depreciacion_acumulada actualizacion_depreciacion_acumulada,a.depreciacion_acumulada depreciacion_acumulada,isnull(valor_neto,0) valor_neto, a.f_ult_act_dep f_ult_act_dep,gc.orden,(select tasa_ufv from tasa_cambio where f_tasa=a.f_ult_act_dep) tasa_ufv_final,(select tasa_ufv from tasa_cambio where f_tasa=a.f_ult_act_dep)/(select tasa_ufv from tasa_cambio where f_tasa='01/01/'+cast(year(a.f_ult_act_dep) as nvarchar(4))) factor_actualizacion,a.actualizacion_gestion, " +
                                 "(select tasa_ufv from tasa_cambio where activo=1 and f_tasa=bm.f_baja) ufv_baja " +
                          "from activos a " +
                          "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable " +
                          "inner join grupos_contables gc on gc.id=ac.fk_grupo_contable " +
                          "inner join bajas_detalle bd on bd.fk_activo=a.id " +
                          "inner join bajas_maestro bm on bm.id=bd.fk_baja_maestro " +
                          "inner join motivos_baja mb on mb.id=bm.fkc_motivo_baja " +
                          "where a.activo=1 and bm.activo=1 and a.fkc_estado_proceso in (25) " +
                          "order by gc.orden";

            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                string grupo_contable = rowDetalle["grupo_contable"].ToString();
                

                string vida_util = rowDetalle["vida_util"].ToString();
                string costo_historico = rowDetalle["costo_historico"].ToString();
                string f_baja = rowDetalle["f_baja"].ToString();
                string observaciones = rowDetalle["observaciones"].ToString();
                string motivo_baja = rowDetalle["motivo_baja"].ToString();
                string costo_actualizado_inicial = rowDetalle["costo_actualizado_inicial"].ToString();
                string depreciacion_acumulada_total = rowDetalle["depreciacion_acumulada_total"].ToString();
                string valor_neto_inicial = rowDetalle["valor_neto_inicial"].ToString();
                string actualizacion_gestion = rowDetalle["actualizacion_gestion"].ToString();
                string costo_total_actualizado = rowDetalle["costo_total_actualizado"].ToString();
                string depreciacion_gestion = rowDetalle["depreciacion_gestion"].ToString();
                string actualizacion_depreciacion_acumulada = rowDetalle["actualizacion_depreciacion_acumulada"].ToString();
                string depreciacion_acumulada = rowDetalle["depreciacion_acumulada"].ToString();
                string valor_neto = rowDetalle["valor_neto"].ToString();
                DateTime f_ult_act_dep = DateTime.Parse(row["f_ult_act_dep"].ToString());

                //DateTime f_ult_act_dep = DateTime.Parse(rowDetalle["f_ult_act_dep"].ToString());
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                DateTime f_registro = DateTime.Parse(rowDetalle["f_registro"].ToString());
                string tasa_ufv = rowDetalle["tasa_ufv"].ToString();//ufv 01/01/gestion de baja
                string porcentaje_depreciacion = rowDetalle["porcentaje_depreciacion"].ToString();
                string dias = rowDetalle["dias"].ToString();
                string tasa_ufv_final = rowDetalle["tasa_ufv_final"].ToString();
                string factor_actualizacion = rowDetalle["factor_actualizacion"].ToString();
                string ufv_baja = rowDetalle["ufv_baja"].ToString();

                dsDetalleActivos.Tables["detalle_bajas_activos"].Rows.Add(new object[] {
                     grupo_contable,
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
                     f_baja,
                     motivo_baja,
                     observaciones,
                     ufv_baja
                    });
            }
            return dsDetalleActivos;
        }

        /// <summary>
        /// valida si existe un codigo de activo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public int validaExisteActivo(string codigo)
        {
            try
            {
                int result = 0;
                string query = "select count(*) "+ 
                                "from activos "+
                                "where activo=1 "+
                                 "and codigo='"+codigo+"'";
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());

                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }

        /// <summary>
        /// Obtiene el reporte de todos los activos con sus custodios
        /// </summary>
        /// <returns></returns>
        public DataSet ReporteActivosConCustodio()
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsActivosConCustodio dsActivos = new dsActivosConCustodio();

            dsActivos.Tables["activos"].Clear();


            string query = "select vista.* from ( "+
                "select a.id,a.codigo,a.descripcion,a.serie,p.documento,p.nombres,p.apellidos,gerencia,area "+
                             "from activos a "+
                             "inner join asignaciones_detalle ad on ad.fk_activo=a.id "+
                             "inner join personal p on p.id=ad.fk_persona "+
                             "where a.activo=1 and ad.activo=1 and ad.fkc_estado_proceso=10"+
                             "union "+
                            "select a.id,a.codigo,a.descripcion,a.serie,'SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR','SIN ASIGNAR' "+
                            "from activos a "+
                            "where "+
                             "a.activo=1 and a.fkc_estado_proceso=5 "+
                             "union "+
                             "select a.id,a.codigo,a.descripcion,a.serie,p.documento,p.nombres,p.apellidos,gerencia,area "+
                             "from activos a "+
                             "inner join asignaciones_por_transferencias_detalle at on at.fk_activo=a.id "+
                             "inner join personal p on p.id=at.fk_persona_destino "+
                             "where a.activo=1 and at.activo=1  and at.fkc_estado_proceso =10 "+
                              ") vista order by vista.codigo asc";


            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                string id = rowDetalle["id"].ToString();
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                string serie = rowDetalle["serie"].ToString();
                string documento = rowDetalle["documento"].ToString();
                string nombres = rowDetalle["nombres"].ToString();
                string apellidos = rowDetalle["apellidos"].ToString();
                string gerencia = rowDetalle["gerencia"].ToString();
                string area = rowDetalle["area"].ToString();


                dsActivos.Tables["activos"].Rows.Add(new object[] {
                     id,
                     codigo,
                     descripcion,
                     serie,
                     documento,
                     nombres,
                     apellidos,
                     gerencia,
                     area,
                     iniciales,
                   
                    });
            }
            return dsActivos;
        }
        /// <summary>
        /// Obtiene la fecha de la ultima depreciacion
        /// </summary>
        /// <returns></returns>
        public string obtieneFechaUltimaDepreciacion()
        {
            try
            {
                string result = "";
                string query = "select max(f_ult_act_dep) from activos where activo=1";
                result =SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString();
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return "";
            }
        }


        public DataSet ReporteKardex(int fk_activo)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsKardex dsActivos = new dsKardex();

            dsActivos.Tables["kardex"].Clear();


            string query = "select vista.* from "+
                            "( "+
                            "select f_registro,codigo,descripcion,serie,'SIN ASIGNAR' origen,'SIN ASIGNAR' destino,'SIN ESTADO' estado_activo,CASE WHEN fk_compra IS NOT NULL AND fk_transferencia IS NULL THEN 'COMPRA' WHEN fk_compra IS NULL AND fk_transferencia IS NOT NULL THEN 'TRANSFERENCIA EXTERNA' END accion, 1 orden from activos "+
                            "where activo = 1 and id="+fk_activo+" "+
                            "union "+
                            "select m.f_asignacion,a.codigo,a.descripcion,a.serie,'ALMACEN ACTIVOS FIJOS' origen,p.documento+', '+p.nombres +' '+ p.apellidos+', '+p.area destino, "+
		                            "(select c.nombre from clasificadores c  where c.id=d.fkc_estado_activo), "+
		                            "'ASIGNACION',2 "+
                            "from asignaciones_detalle d "+
                            "inner join activos a on a.id="+fk_activo+" "+
                            "inner join asignaciones_maestro m on m.id=d.fk_asignacion_maestro "+
                            "inner join personal p on p.id=d.fk_persona "+
                            "where d.activo=1 and d.fk_activo="+fk_activo+" "+
                            "union "+
                            "select m.f_transferencia,a.codigo,a.descripcion,a.serie, "+
                            "(select p.documento+', '+p.nombres +' '+ p.apellidos+', '+p.area destino  from personal p where p.id=d.fk_persona_origen) origen, "+
                            "( select p.documento+', '+p.nombres +' '+ p.apellidos+', '+p.area from personal p where p.id=d.fk_persona_destino) destino, "+
                            "(select c.nombre from clasificadores c  where c.id=d.fkc_estado_activo), "+
                            "'TRANSFERENCIA' ,3 "+
                            "from asignaciones_por_transferencias_detalle d "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join asignaciones_por_transferencias_maestro m on m.id=d.fk_asignacion_por_transferencia_maestro "+
                            "where d.activo=1 and d.fk_activo="+fk_activo+" "+
                            "union "+
                            "select bm.f_baja,a.codigo,a.descripcion,a.serie,'SIN ORIGEN','SIN DESTINO','SIN ESTADO','BAJA',4 "+
                            "from bajas_detalle bd "+
                            "inner join activos a on a.id=bd.fk_activo "+
                            "inner join bajas_maestro bm on bm.id=bd.fk_baja_maestro "+
                            "where bd.activo=1 and fk_activo="+fk_activo+" "+
                            ") vista "+
                            "order by vista.orden";


            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                DateTime f_registro =DateTime.Parse(rowDetalle["f_registro"].ToString());
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                string serie = rowDetalle["serie"].ToString();
                string origen = rowDetalle["origen"].ToString();
                string destino = rowDetalle["destino"].ToString();
                string estado_activo = rowDetalle["estado_activo"].ToString();
                string accion = rowDetalle["accion"].ToString();
               


                dsActivos.Tables["kardex"].Rows.Add(new object[] {
                     f_registro.ToString("dd/MM/yyyy"),
                     codigo,
                     descripcion,
                     serie,
                     origen,
                     destino,
                     estado_activo,
                     accion
                   
                   
                    });
            }
            return dsActivos;
        }


        public DataSet ReporteDetalleActivosPorGrupoDinamico(int ubicacion,int linea,int estacion)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();
            DataRow row;

            dsDetalleActivosPorGrupo dsDetalleActivos = new dsDetalleActivosPorGrupo();

            dsDetalleActivos.Tables["detalle_activos_grupo"].Clear();

            string query_ultima_actualizacion = "select max(f_ult_act_dep) f_ult_act_dep  from activos where activo=1 and fkc_estado_proceso not in (24,25)";

            row = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query_ultima_actualizacion).Tables[0].Rows[0];

            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, "[SP_DatosDetalleDepreciacionDinamico]",ubicacion,linea,estacion).Tables[0];
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
                DateTime f_ult_act_dep = DateTime.Parse(row["f_ult_act_dep"].ToString());
                string codigo = rowDetalle["codigo"].ToString();
                string descripcion = rowDetalle["descripcion"].ToString();
                DateTime f_registro = DateTime.Parse(rowDetalle["f_registro"].ToString());
                string tasa_ufv = rowDetalle["tasa_ufv"].ToString();
                string porcentaje_depreciacion = rowDetalle["porcentaje_depreciacion"].ToString();
                string dias = rowDetalle["dias"].ToString();
                string tasa_ufv_final = rowDetalle["tasa_ufv_final"].ToString();
                string factor_actualizacion = rowDetalle["factor_actualizacion"].ToString();
                string dias_general = rowDetalle["dias_general"].ToString();
                string fk_agrupador = rowDetalle["fk_agrupador"].ToString();
                string agrupador = rowDetalle["agrupador"].ToString();

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
                     dias_general,
                     fk_agrupador,
                     agrupador
                    });
            }
            return dsDetalleActivos;
        }


        public DataSet ReporteResumenActivosPorGrupoDinamico(int ubicacion, int linea, int estacion)
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            DataRow row;

            dsResumenActivosPorGrupo dsResumenActivos = new dsResumenActivosPorGrupo();

            dsResumenActivos.Tables["resumen_activos_grupo"].Clear();


            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, "[SP_DatosResumenDepreciacionDinamico]",ubicacion,linea,estacion).Tables[0];


            string query_ultima_actualizacion = "select max(f_ult_act_dep) f_ult_act_dep  from activos where activo=1 and fkc_estado_proceso not in (24,25)";

            row = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query_ultima_actualizacion).Tables[0].Rows[0];


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
                DateTime f_ult_act_dep = DateTime.Parse(row["f_ult_act_dep"].ToString());
                string tasa_ufv_final = rowDetalle["tasa_ufv_final"].ToString();
                string fk_agrupador = rowDetalle["fk_agrupador"].ToString();
                string agrupador = rowDetalle["agrupador"].ToString();
                string costo_factura = rowDetalle["costo_factura"].ToString();
                dsResumenActivos.Tables["resumen_activos_grupo"].Rows.Add(new object[] {
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
                     tasa_ufv_final,
                     fk_agrupador,
                     agrupador,
                     decimal.Parse(costo_factura)
                    });
            }
            return dsResumenActivos;
        }

    }
}