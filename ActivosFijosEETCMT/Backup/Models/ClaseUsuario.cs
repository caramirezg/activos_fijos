using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ActivosFijos.Models
{
    public class ClaseUsuario
    {
        Conexion conexion = new Conexion();
        
        /// <summary>
        /// Autenficia a un usuario que se loguea al sistema
        /// </summary>
        /// <param name="pUsuario">usuario</param>
        /// <param name="pClave">contraseña</param>
        /// <returns>valor verificado de si es correcto o no las credenciales</returns>
        public string autentificarUsuario(string pUsuario, string pClave)
        {
            string result;
            result = SqlHelper.ExecuteScalar(new Conexion().connectionString, "[SP_AutenticaUsuario]", pUsuario, pClave).ToString();
            return result;
        }

        /// <summary>
        /// Lista los datos de un usuario por ID
        /// </summary>
        /// <returns></returns>
        public List<UserEntity> ListDatosUsuario()
        {
            DataTable dtUsuario = new DataTable();
            int vIdUsuario = int.Parse(HttpContext.Current.Session["user"].ToString());
            dtUsuario = SqlHelper.ExecuteDataset(new Conexion().connectionString, "[SP_DatosUsuario]",vIdUsuario).Tables[0];
            List<UserEntity> Lista = (from AnyName in dtUsuario.AsEnumerable()
                                      select new UserEntity()
                                      {
                                          usuario = AnyName.Field<string>("usuario"),
                                          nombre = AnyName.Field<string>("nombre"),
                                          apellido = AnyName.Field<string>("apellido"),
                                         
                                          IDperfil = AnyName.Field<int>("perfil"),
                                          IDpersona = AnyName.Field<int>("fk_personal")
                                         
                                      }).ToList();
            return Lista;
        }

        /// <summary>
        /// Obtiene datos de usuario por session de usuario
        /// </summary>
        /// <param name="userSession"></param>
        /// <returns></returns>
        public List<UserEntity> List_DatosUsuarioByID(string userSession)
        {
            DataTable dtTable = new DataTable();
            conexion.openConnection(conexion.connectionString);
            string query="select u.id,u.usuario,u.nombre,u.apellido, "+
		                 
		                  "u.fk_perfil, "+
		                  "(select p.nombre from perfil p where p.id=fk_perfil) perfil, "+
		                  "u.activo "+
                          "from usuario u "+
                           "where u.id='"+userSession+"'"+
                            "and u.activo=1";

            dtTable= SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<UserEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                      select new UserEntity()
                                      {
                                          usuario=AnyName.Field<string>("usuario"),
                                          nombre = AnyName.Field<string>("nombre"),
                                          apellido=AnyName.Field<string>("apellido"),
                                          IDperfil=AnyName.Field<int>("fk_perfil"),
                                          perfil=AnyName.Field<string>("perfil"),
                                          estado=AnyName.Field<int>("activo")

                                      }).ToList();
            return Lista;
      
        }

        /// <summary>
        /// Actualiza los datos del perfil de usuario
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="IDarea"></param>
        /// <param name="IDcargo"></param>
        /// <returns></returns>
        public int ActualizaUsuario(string nombre, string apellido, int IDarea, int IDcargo)
        {
            try
            {
                int IDUsuario = int.Parse(HttpContext.Current.Session["user"].ToString());
                string userName = HttpContext.Current.Session["userName"].ToString();
                string update = "update usuario set nombre='" + nombre + "',apellido='" + apellido + "',usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' where id=" + IDUsuario + "";
                int result=SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, update);
                return result;
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return 0;
            }
        }
        /// <summary>
        /// Actualiza un nuevo password ingresado
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public int ActualizaPassword(string password, string passwordActual)
        {
            try
            {
                int IDUsuario = int.Parse(HttpContext.Current.Session["user"].ToString());
                string userName = HttpContext.Current.Session["userName"].ToString();
                int result = 0;
                string update = "update usuario set password='" + password + "', usuariomodificacion='" + userName + "',fechamodificacion='" + DateTime.Now + "' where id=" + IDUsuario + " and password='" + passwordActual + "'";
                result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, update);
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