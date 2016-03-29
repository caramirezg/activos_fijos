using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data.SqlClient;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseComiteInventario
    {

        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();


        public int CreaComiteInventario(List<ComiteInventarioEntity> ListComiteInventario)
        {
            try
            {
                using (var con = new SqlConnection(conexion.connectionString))
                {
                    con.Open();
                    int rowsAffected = 0;
                    string userName = HttpContext.Current.Session["userName"].ToString();
                    using (var cmd = new SqlCommand("insert into inventario_comision(fk_inventario_maestro,fk_persona,activo,usuariocreacion,fechacreacion) " +
                        "VALUES(@fk_inventario_maestro,@fk_persona,1,'" + userName + "','" + DateTime.Now + "')", con))
                    {
                        cmd.Parameters.Add("@fk_inventario_maestro", SqlDbType.Int);
                        cmd.Parameters.Add("@fk_persona", SqlDbType.Int);

                        foreach (var value in ListComiteInventario)
                        {
                            cmd.Parameters["@fk_inventario_maestro"].Value = value.fk_inventario_maestro;
                            cmd.Parameters["@fk_persona"].Value = value.fk_persona;
                            rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }
                    return rowsAffected;
                }

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }

    }
}