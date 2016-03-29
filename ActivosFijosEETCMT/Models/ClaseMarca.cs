using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseMarca
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de las marcas de activos
        /// </summary>
        /// <returns></returns>
        public List<MarcasEntity> List_datosMarcas()
        {
            string query = "select id,nombre,activo from marcas where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<MarcasEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                               orderby AnyName.Field<string>("nombre")
                                        select new MarcasEntity()
                                               {
                                                   ID = AnyName.Field<int>("id"),
                                                   nombre = AnyName.Field<string>("nombre")
                                               }).ToList();
            return Lista;
        }
        /// <summary>
        /// Crea un registro de marca
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public int CreaMarca(string nombre)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "insert into marcas " +
                "(nombre,activo,usuariocreacion,fechacreacion) " +
                "values('" + nombre + "',1,'" + userName + "','" + DateTime.Now + "')";
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
        /// Edita un registro de marca de una activo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public int EditaMarca(int id, string nombre)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "update marcas " +
                "set nombre='" + nombre + "',usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
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
        /// Elimina de manera lógica un registro de marca de activo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EliminaMarca(int id)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string query = "select count(*) from activos a where a.fk_modelo in (select id from modelos where fk_marca="+id+") and activo=1";
                int resultQuery = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());

                if (resultQuery < 1)
                {
                    string update = "update marcas " +
                    "set activo='0', usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
                    "where id=" + id + "";
                    result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, update);


                    string updateAuxiliares = "update modelos " +
                   "set activo='0', usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
                   "where fk_marca=" + id + "";
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
    }
}