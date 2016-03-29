using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseModelo
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de los modelos de una marca
        /// </summary>
        /// <returns></returns>
        public List<ModeloEntity> List_datosModelos(int idMarca)
        {
            string query = "select mo.id,mo.nombre,mo.fk_marca,(select ma.nombre from marcas ma where ma.id=mo.fk_marca) marca,mo.activo from modelos mo where mo.activo=1 and fk_marca="+idMarca+"";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<ModeloEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                        orderby AnyName.Field<int>("id")
                                        select new ModeloEntity()
                                        {
                                            ID = AnyName.Field<int>("id"),
                                            nombre = AnyName.Field<string>("nombre"),
                                            fk_marca = AnyName.Field<int>("fk_marca"),
                                            marca = AnyName.Field<string>("marca")
                                        }).ToList();
            return Lista;
        }
        /// <summary>
        /// Crea un registro de modelo
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public int CreaModelo(string nombre, int idMarca)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "insert into modelos " +
                "(nombre,fk_marca,activo,usuariocreacion,fechacreacion) " +
                "values('" + nombre + "'," + idMarca + ",1,'" + userName + "','" + DateTime.Now + "')";
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
        /// Edita un registro de modelo de una activo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public int EditaModelo(int id, string nombre)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "update modelos " +
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
        /// Elimina de manera lógica un registro de modelo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EliminaModelo(int id)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();


                int result = 0;
                string query = "select count(*) from activos where activo=1 and fk_modelo=" + id + "";
                int resultQuery = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());

                if (resultQuery < 1)
                {
                  
                    string insert = "update modelos " +
                    "set activo='0', usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
                    "where id=" + id + "";
                    result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, insert);
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