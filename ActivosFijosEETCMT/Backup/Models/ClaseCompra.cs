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
    public class ClaseCompra
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();
        /// <summary>
        /// Obtiene la lista de compras de activos
        /// </summary>
        /// <returns></returns>
        public List<CompraEntity> List_datosCompras()
        {
            string query = "select RIGHT('00000000' + cast(c.correlativo as nvarchar(10)),7)+'/'+cast(year(c.f_registro)as nvarchar(4)) correlativo, c.id,c.descripcion, c.f_registro,c.tasa_ufv,c.tasa_sus, c.fk_gerencia_solicitante, "+
                           "(select g.nombre from gerencias g where g.id=c.fk_gerencia_solicitante) gerencia_solicitante, "+
                           "isnull((select sum(costo) from activos a where a.activo=1 and a.fk_compra is not null and fk_compra=c.id),0) costo, "+
                           "isnull((select sum(gastos_con_credito_fiscal) from activos a where a.activo=1 and a.fk_compra is not null and fk_compra=c.id),0) gastos_con_credito_fiscal, "+
                           "isnull((select sum(gastos_sin_credito_fiscal) from activos a where a.activo=1 and a.fk_compra is not null and fk_compra=c.id),0) gastos_sin_credito_fiscal, "+
                           "isnull((select sum(valor_inicial) from activos a where a.activo=1 and a.fk_compra is not null and fk_compra=c.id),0) monto_bs, "+
                           "c.nro_factura,c.doc_respaldo, c.fk_proveedor, "+
                           "(select p.nombre from proveedores p where p.id=c.fk_proveedor) proveedor, "+
                           "c.activo,c.fkc_estado_proceso, "+
                           "(select ca.nombre from clasificadores ca where ca.id=c.fkc_estado_proceso) estado_proceso,c.fk_fuente_financiamiento, "+
                           "(select nombre from fuente_financiamiento ff where ff.id=c.fk_fuente_financiamiento) fuente_financiamiento "+
                           "from compras c "+
                           "where c.activo=1 order by c.fkc_estado_proceso,year(c.f_registro) desc, c.correlativo desc,c.f_registro desc";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
         
            List<CompraEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                      
                                        select new CompraEntity()
                                        {
                                            ID = AnyName.Field<int>("id"),
                                            descripcion = AnyName.Field<string>("descripcion"),
                                            f_registro = AnyName.Field<DateTime>("f_registro").ToString("dd/MM/yyyy"),
                                            fk_gerencia_solicitante = AnyName.Field<int>("fk_gerencia_solicitante"),
                                            gerencia_solicitante = AnyName.Field<string>("gerencia_solicitante"),
                                            monto_bs = AnyName.Field<decimal>("monto_bs"),
                                            //monto_ufv = AnyName.Field<decimal>("monto_ufv"),
                                            //monto_sus = AnyName.Field<decimal>("monto_sus"),
                                            tasa_ufv = AnyName.Field<decimal>("tasa_ufv"),
                                            tasa_sus = AnyName.Field<decimal>("tasa_sus"),
                                            nro_factura = AnyName.Field<string>("nro_factura"),
                                            doc_respaldo = AnyName.Field<string>("doc_respaldo"),
                                            fk_proveedor = AnyName.Field<int>("fk_proveedor"),
                                            proveedor = AnyName.Field<string>("proveedor"),
                                            activo = AnyName.Field<int>("activo"),
                                            fkc_estado_proceso = AnyName.Field<int>("fkc_estado_proceso"),
                                            fk_fuente_financiamiento = AnyName.Field<int>("fk_fuente_financiamiento"),
                                            fuente_financiamiento = AnyName.Field<string>("fuente_financiamiento"),
                                            estado_proceso = AnyName.Field<string>("estado_proceso"),
                                            correlativo = AnyName["correlativo"].ToString(),
                                            costo = AnyName.Field<decimal>("costo"),
                                            gastos_con_credito_fiscal = AnyName.Field<decimal>("gastos_con_credito_fiscal"),
                                            gastos_sin_credito_fiscal = AnyName.Field<decimal>("gastos_sin_credito_fiscal")
                                        }).ToList();
            return Lista;
        }


        /// <summary>
        /// Guarda un registro de compra
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="fecha_registro"></param>
        /// <param name="unidad_solicitante"></param>
        /// <param name="tasa_ufv"></param>
        /// <param name="nro_factura"></param>
        /// <param name="nro_acta_recepcion"></param>
        /// <param name="proveedor"></param>
        /// <param name="nro_nota_remision"></param>
        /// <returns></returns>
        public int CreaCompra(string descripcion, DateTime fecha_registro, int gerencia_solicitante,int fk_fuente_financiamiento, string tasa_ufv,string tasa_sus, string nro_factura,string doc_respaldo,int proveedor)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "insert into compras " +
                "(descripcion,f_registro,fk_gerencia_solicitante,fk_fuente_financiamiento,tasa_ufv,tasa_sus,nro_factura,doc_respaldo,fk_proveedor,fkc_estado_proceso,activo,usuariocreacion,fechacreacion) " +
                "OUTPUT INSERTED.ID values('" + descripcion + "','" + fecha_registro + "'," + gerencia_solicitante + ","+fk_fuente_financiamiento+"," + tasa_ufv + ","+tasa_sus+",'" + nro_factura + "','" + doc_respaldo + "'," + proveedor + ",4,1,'" + userName + "','" + DateTime.Now + "')";
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
        /// Cambia el estado de ELABORADO a APROBADO en compras y activos
        /// </summary>
        /// <param name="fk_compra"></param>
        /// <returns></returns>
        public int ApruebaCompra(int fk_compra, DateTime f_registro, string id_correlativo_reservado=null)
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

                    if (string.IsNullOrEmpty(id_correlativo_reservado))
                    {
                        command.CommandText =


                            //"update compras set fkc_estado_proceso=5,correlativo=(select isnull(max(correlativo)+1,1) from compras where activo=1 and year(f_registro)=year('" + f_registro + "')), 
                            "update compras set fkc_estado_proceso=5,correlativo=(select dbo.f_get_correlativo_compras('"+f_registro+"')), " +
                            "usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                            "where id=" + fk_compra + " " +
                            "and activo=1 ";
                        command.ExecuteNonQuery();
                        command.CommandText =
                           "update activos set fkc_estado_proceso=5,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "'  " +
                            "where fk_compra=" + fk_compra + " " +
                            "and activo=1";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText =
                            "update compras set fkc_estado_proceso=5,correlativo=(select correlativo from reservas_correlativos where id=" + int.Parse(id_correlativo_reservado) + "), usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' " +
                            "where id=" + fk_compra + " " +
                            "and activo=1 ";
                        command.ExecuteNonQuery();
                        command.CommandText =
                           "update activos set fkc_estado_proceso=5,usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "'  " +
                            "where fk_compra=" + fk_compra + " " +
                            "and activo=1";
                        command.ExecuteNonQuery();

                        command.CommandText =
                            "update reservas_correlativos "+
                             "set vigente=0, usuariomodificacion='" + userName + "',fechamodificacion=sysdatetime() " +
                              "where id=" + int.Parse(id_correlativo_reservado) + "";
                        command.ExecuteNonQuery();
                    }
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
        /// Elimina una compra en estado elaborado y sus activos registrados
        /// </summary>
        /// <param name="fk_compra"></param>
        /// <returns></returns>
        public int EliminaCompra(int fk_compra)
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
                        "update compras set activo=0,usuariomodificacion='"+userName+"',fechamodificacion='"+DateTime.Now+"' where id="+fk_compra+"";
                    command.ExecuteNonQuery();
                    command.CommandText =
                       "update activos set activo=0, usuariomodificacion='"+userName+"',fechamodificacion='"+DateTime.Now+"' where fk_compra="+fk_compra+"";
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
        /// Genera reporte con data set tipado para una compra
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns></returns>
        public DataSet ReporteCompraActivos(int idCompra)
        {

            string nombre=HttpContext.Current.Session["nombre"].ToString();
            string apellido=HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);
           
            
            DataTable TablaMaestro = new DataTable();
            DataTable TablaDetalle = new DataTable();
            dsRegistroCompra dsRegistroCompra = new dsRegistroCompra();


            dsRegistroCompra.Tables["compras"].Clear();
            dsRegistroCompra.Tables["activos"].Clear();

            string queryMaestro="select id,correlativo,descripcion,f_registro, fk_gerencia_solicitante,nro_factura, "+
		                        "(select nombre from gerencias g where g.id=fk_gerencia_solicitante) gerencia_solicitante, "+
		                        "fk_proveedor, "+
		                        "(select nombre from proveedores p where p.id=fk_proveedor) proveedor, doc_respaldo "+
		                        "from compras where id="+idCompra+"";

            string queryDetalle = "select id, codigo, descripcion,valor_inicial,serie from activos where fk_compra="+idCompra+" and activo=1 order by codigo asc";


              TablaMaestro = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryMaestro).Tables[0];

              foreach (DataRow rowMaestro in TablaMaestro.Rows)
              {
                  
                  int correlativo=0;
                  string official="";
                  string valor= rowMaestro["correlativo"].ToString();
                  if (string.IsNullOrEmpty(valor))
                  {
                      correlativo = 0;
                      official = "ESTE NO ES UN DOCUMENTO OFICIAL";
                  }
                  else
                  {
                      correlativo = int.Parse(rowMaestro["correlativo"].ToString());
                  }
                  
                  int id_Compra = int.Parse(rowMaestro["id"].ToString());
                  //int correlativo = int.Parse(rowMaestro["correlativo"].ToString());
                  DateTime f_registro = Convert.ToDateTime(rowMaestro["f_registro"].ToString());

          
                  
                  //string f_registro=string.Format("{0:dd-MM-yyyy}", rowMaestro["f_registro"].ToString());
                  
                  string descripcion = rowMaestro["descripcion"].ToString().ToUpper();
                  string factura = rowMaestro["nro_factura"].ToString().ToUpper();

                  string gerencia_solicitante = rowMaestro["gerencia_solicitante"].ToString();
                  string proveedor = rowMaestro["proveedor"].ToString();
                  string doc_respaldo = rowMaestro["doc_respaldo"].ToString();

                  dsRegistroCompra.Tables["compras"].Rows.Add(new object[] {
                    correlativo,
                    descripcion,
                    f_registro.ToString("dd/MM/yyyy"),
                    gerencia_solicitante,
                    proveedor,
                    id_Compra,
                    factura,
                    doc_respaldo,
                    official,
                    iniciales
                    
                     
                     
                });
                  TablaDetalle.Clear();
                  TablaDetalle = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, queryDetalle).Tables[0];
                  foreach (DataRow rowDetalle in TablaDetalle.Rows)
                  {
                      string idActivo = rowDetalle["id"].ToString();
                      string codigo = rowDetalle["codigo"].ToString();
                      string descripcion_activo = rowDetalle["descripcion"].ToString();
                      decimal valor_inicial = decimal.Parse(rowDetalle["valor_inicial"].ToString());
                      string serie = rowDetalle["serie"].ToString();

                      dsRegistroCompra.Tables["activos"].Rows.Add(new object[] {
                      codigo,
                      descripcion_activo,
                      valor_inicial,
                      idActivo,
                      id_Compra,
                      serie
                      
                    
                        
                    });
                  }
              }
            return dsRegistroCompra;
        }


        public decimal activosComprados()
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
                        "select COUNT(*) from activos where fk_compra is not null and activo=1";
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

        public int obtenerUlitmoCorrelativo()
        {
            try
            {
                int result = 0;
                string query = "select max(correlativo) from compras where activo=1 and year(f_registro)=(select max(year(f_registro)) from compras where activo=1)";
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