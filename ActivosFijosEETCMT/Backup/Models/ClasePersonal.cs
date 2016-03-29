using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClasePersonal
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();
        /// <summary>
        /// Muestra la lista de todo el personal
        /// </summary>
        /// <returns></returns>
        public List<PersonalEntity> List_datosPersonal()
        {
            List<PersonalEntity> Lista;
            string vFk_persona = HttpContext.Current.Session["fk_persona"].ToString();
            string vPerfil = HttpContext.Current.Session["perfil"].ToString();

            if (vPerfil == "1" || vPerfil =="4")
            {
                string query = "select id,documento,nombres,apellidos,gerencia,area,cargo,estado from personal";
                dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
                 Lista = (from AnyName in dtTable.AsEnumerable()
                                              orderby AnyName.Field<string>("apellidos")
                                              select new PersonalEntity()
                                                      {
                                                          id = AnyName.Field<int>("id"),
                                                          documento = AnyName.Field<string>("documento"),
                                                          nombres = AnyName.Field<string>("nombres"),
                                                          apellidos = AnyName.Field<string>("apellidos"),
                                                          area = AnyName.Field<string>("area"),
                                                          gerencia = AnyName.Field<string>("gerencia"),
                                                          cargo = AnyName.Field<string>("cargo"),
                                                          estado = AnyName.Field<string>("estado")
                                                      }).ToList();
            }
            else 
            {

                string query = "select id,documento,nombres,apellidos,gerencia,area,estado from personal where id="+vFk_persona+"";
                dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
                Lista = (from AnyName in dtTable.AsEnumerable()
                                              orderby AnyName.Field<string>("apellidos")
                                              select new PersonalEntity()
                                              {
                                                  id = AnyName.Field<int>("id"),
                                                  documento = AnyName.Field<string>("documento"),
                                                  nombres = AnyName.Field<string>("nombres"),
                                                  apellidos = AnyName.Field<string>("apellidos"),
                                                  area = AnyName.Field<string>("area"),
                                                  gerencia = AnyName.Field<string>("gerencia"),
                                                  estado = AnyName.Field<string>("estado")
                                              }).ToList();
            }

            return Lista;
        }


        /// <summary>
        /// Crea un registro en la tabla personal
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="nombres"></param>
        /// <param name="apellidos"></param>
        /// <param name="area"></param>
        /// <param name="gerencia"></param>
        /// <param name="cargo"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public int CreaPersona(string documento, string nombres, string apellidos,string area,string gerencia, string estado)
        {
            try
            {
                int result = 0;
                string insert = "insert into personal (documento,nombres,apellidos,area,gerencia,estado) " +
                "values('" + documento + "','" + nombres + "','" + apellidos + "','" + area + "','" + gerencia + "','" + estado + "')";
                result = int.Parse(SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, insert).ToString());

                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }

        }

        /// <summary>
        /// Edita un registro de persona
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="nombres"></param>
        /// <param name="apellidos"></param>
        /// <param name="area"></param>
        /// <param name="gerencia"></param>
        /// <param name="cargo"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public int EditaPersona(string documento, string nombres, string apellidos, string area, string gerencia)
        {
            try
            {
                int result = 0;
                string insert = "update personal " +
                "set nombres='" + nombres + "', apellidos='" + apellidos + "',area='" + area + "', gerencia='" + gerencia + "' " +
                "where documento=" + documento + "";
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
        /// Sincroniza con la base de datos de recursos humanos
        /// </summary>
        /// <returns></returns>
        public int SincronizaPersonal()
        {
            try
            {
                int result = 0;
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, "[SP_SincronizaPersonal]").ToString());
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