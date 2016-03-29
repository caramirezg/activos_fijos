using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;
using System.Data.SqlClient;

namespace ActivosFijosEETC.Models
{
    public class ClaseGrupoContable
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de los grupos contables
        /// </summary>
        /// <returns></returns>
        public List<GrupoContableEntity> List_datosGruposContables() {
            string query = "select id,codigo,nombre,descripcion,vida_util,porcentaje_depreciacion, sigla, activo,depreciable,actualizable,orden from grupos_contables where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<GrupoContableEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                               orderby AnyName.Field<string>("codigo") ascending
                                               select new GrupoContableEntity()
                                               {
                                                   ID=AnyName.Field<int>("id"),
                                                   codigo=AnyName.Field<string>("codigo"),
                                                   nombre = AnyName.Field<string>("nombre"),
                                                   descripcion = AnyName.Field<string>("descripcion") +"; VIDA UTIL:"+ AnyName.Field<int>("vida_util") +" AÑOS",
                                                   vida_util = AnyName.Field<int>("vida_util"),
                                                   porcentaje_depreciacion = AnyName.Field<decimal>("porcentaje_depreciacion"),
                                                   sigla = AnyName.Field<string>("sigla"),
                                                   depreciable = AnyName.Field<int>("depreciable"),
                                                   actualizable = AnyName.Field<int>("actualizable")
                                                  
                                               }).ToList();
            return Lista;
        }

        /// <summary>
        /// Crea un registro de grupo contable
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="vida_util"></param>
        /// <param name="sigla"></param>
        /// <param name="porcentaje"></param>
        /// <returns></returns>
        public int CreaGrupoContable(string codigo,string nombre, string descripcion, string vida_util, string sigla, string porcentaje,string depreciable,string actualizable)
        {
             string userName = HttpContext.Current.Session["userName"].ToString();

 
                string insert = "insert into grupos_contables "+
                "(codigo,nombre,descripcion,vida_util,porcentaje_depreciacion,sigla,depreciable,actualizable,activo,usuariocreacion,fechacreacion) "+
                "values(@codigo,@nombre,@descripcion,@vida_util,@porcentaje,@sigla,@depreciable,@actualizable,@activo,@usuariocreacion,@fechacreacion)";


            SqlConnection sqlConnection = new SqlConnection(conexion.connectionString);
            SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);       
 
            sqlCommand.Parameters.Add("@codigo", System.Data.SqlDbType.NVarChar).Value = codigo;
            sqlCommand.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = nombre;
            sqlCommand.Parameters.Add("@descripcion", System.Data.SqlDbType.NVarChar).Value = descripcion;

            sqlCommand.Parameters.Add("@depreciable", System.Data.SqlDbType.Int).Value = int.Parse(depreciable);
            sqlCommand.Parameters.Add("@actualizable", System.Data.SqlDbType.Int).Value = int.Parse(actualizable);

            sqlCommand.Parameters.Add("@sigla", System.Data.SqlDbType.NVarChar).Value = sigla;
            sqlCommand.Parameters.Add("@activo", System.Data.SqlDbType.Int).Value =1;
            sqlCommand.Parameters.Add("@usuariocreacion", System.Data.SqlDbType.NVarChar).Value = userName;
            sqlCommand.Parameters.Add("@fechacreacion", System.Data.SqlDbType.DateTime).Value = DateTime.Now;


            if (string.IsNullOrEmpty(vida_util) || vida_util == "0")
                sqlCommand.Parameters.Add("@vida_util", System.Data.SqlDbType.Int).Value = 0;
            else
                sqlCommand.Parameters.Add("@vida_util", System.Data.SqlDbType.Int).Value = vida_util;

            if (string.IsNullOrEmpty(porcentaje) || porcentaje == "0")
                sqlCommand.Parameters.Add("@porcentaje", System.Data.SqlDbType.Decimal).Value = 0;
            else
                sqlCommand.Parameters.Add("@porcentaje", System.Data.SqlDbType.Decimal).Value = decimal.Parse(porcentaje.Replace(".", ","));



 
            sqlConnection.Open();
 
            try{            
               sqlCommand.ExecuteNonQuery();
               return 1;
            }
            catch(Exception ex){
                 string error = ex.ToString();
                return 0;
            }
            finally{
               sqlConnection.Close();
            }
        }
        /// <summary>
        /// Valida que la sigla no se repita
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
        public int validaSigla(string sigla)
        {
            try
            {
                int result = 0;
                string query = "select count(sigla) from grupos_contables where activo=1 and sigla='" + sigla + "'";
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
        /// Valida que el codigo no se repita
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public int validaCodigo(string codigo)
        {
            try
            {
                int result = 0;
                string query = "select count(codigo) from grupos_contables where activo=1 and codigo='" + codigo + "'";
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
        /// Edita los campos de nombre, descripcion y campos de auditoria de un grupo contable
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="vida_util"></param>
        /// <param name="sigla"></param>
        /// <param name="porcentaje"></param>
        /// <returns></returns>
        public int EditaGrupoContable(int id,string nombre, string descripcion, int vida_util, string sigla, decimal porcentaje,int depreciable,int actualizable)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "update grupos_contables " +
                "set nombre='" + nombre + "', descripcion='" + descripcion + "',depreciable="+depreciable+",actualizable="+actualizable+", usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
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
        /// Elimina de manera logica un registo de grupo contable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EliminaGrupoContable(int id)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string query = "select count(*) from activos a where a.fk_auxiliar_contable in (select id from auxiliares_contables where fk_grupo_contable="+id+") and activo=1";
                int resultQuery = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());

                if (resultQuery < 1)
                {
                    string update = "update grupos_contables " +
                    "set activo='0', usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
                    "where id=" + id + "";
                    result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, update);

                    string updateAuxiliares = "update auxiliares_contables " +
                    "set activo='0', usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
                    "where fk_grupo_contable=" + id + "";
                    result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, update);
                }
            
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }

        }
        /// <summary>
        /// Lista el conteo de activos por grupo contable
        /// </summary>
        /// <returns></returns>
        public List<ActivosPorGrupoEntity> List_datosActivosPorGrupo()
        {
            string query = "select gc.nombre nombre,count(a.id) count "+
		                   "from activos a "+
		                   "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable "+
		                   "inner join grupos_contables gc on gc.id=ac.fk_grupo_contable "+
		                   "where a.activo=1 "+
		                   "group by gc.nombre "+
		                   "order by count(a.id)desc";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<ActivosPorGrupoEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                                 select new ActivosPorGrupoEntity()
                                               {
                                                   grupo_contable = AnyName.Field<string>("nombre"),
                                                   count=AnyName.Field<int>("count")
                                               }).ToList();
            return Lista;
        }

        public int validaVidaUtilEspecifica(int id_grupo_contable,int vida_util_especifica)
        {
            try
            {
                int result = 0;
                string query = "select count(vida_util) from grupos_contables "+
                                "where id=" + id_grupo_contable + " and vida_util=" + vida_util_especifica + "";
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