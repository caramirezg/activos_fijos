using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ActivosFijos.Models;

namespace ActivosFijosEETC.Models
{

    public class ClaseMenu
    {

        Conexion conexion = new Conexion();
        DataSet dsMenu = new DataSet();
        DataTable dtMenu = new DataTable();
        DataTable dtSubMenu = new DataTable();
        public DataSet obtenerMenu()
        {
            using (SqlConnection connection = new SqlConnection(conexion.connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.Add("@perfil", SqlDbType.Int).Value = HttpContext.Current.Session["perfil"].ToString();
                    cmd.CommandText="select m.id,m.menu,m.accion,m.icono,(select count(s.id) from submenus s where s.fk_menu=m.id) count_submenus " +
                                    "from menus m " +
                                    "inner join perfil_menu nm on nm.fk_menu=m.id " +
                                    "where fk_perfil=@perfil " +
                                    "order by m.indice";
               
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(dtMenu);

                    cmd.CommandText = "select sm.id,sm.fk_menu,sm.submenu,sm.accion " +
                                            "from submenus sm " +
                                            "inner join menus m on m.id=sm.fk_menu " +
                                            "inner join perfil_menu nm on nm.fk_menu=m.id " +
                                            "where fk_perfil=@perfil";
                    da.Fill(dtSubMenu);

                    // Detach the SqlParameters from the command object, so they can be used again
                    cmd.Parameters.Clear();
                    connection.Close();
                }

            }

            dsMenu.Tables.Add(dtMenu);
            dsMenu.Tables.Add(dtSubMenu);
        
            return dsMenu;
      
        }
    }
}