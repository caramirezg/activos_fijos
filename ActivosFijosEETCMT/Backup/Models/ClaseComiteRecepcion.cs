using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;
using System.Data.SqlClient;

namespace ActivosFijosEETC.Models
{
    public class ClaseComiteRecepcion
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

      


        /// <summary>
        /// Crea el comite de recepcion de una compra
        /// </summary>
        /// <param name="ListComiteRecepcion"></param>
        /// <returns></returns>
        public int CreaComiteRecepcionPorCompra(List<ComiteRecepcionEntity> ListComiteRecepcion)
        {
            try
            {
                using (var con = new SqlConnection(conexion.connectionString))
                {
                    con.Open();
                    int rowsAffected = 0;
                    string userName = HttpContext.Current.Session["userName"].ToString();
                    using (var cmd = new SqlCommand("insert into comite_recepcion(fk_personal,fk_compra,activo,usuariocreacion,fechacreacion) " +
                        "VALUES(@fk_personal,@fk_compra,1,'" + userName + "','" + DateTime.Now + "')", con))
                    {
                        cmd.Parameters.Add("@fk_personal", SqlDbType.VarChar);
                        cmd.Parameters.Add("@fk_compra", SqlDbType.VarChar);

                        foreach (var value in ListComiteRecepcion)
                        {
                            cmd.Parameters["@fk_personal"].Value = value.fk_personal;
                            cmd.Parameters["@fk_compra"].Value = value.fk_compra;
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

        /// <summary>
        /// Crea el comite de transferencias
        /// </summary>
        /// <param name="ListComiteRecepcion"></param>
        /// <returns></returns>
        public int CreaComiteRecepcionPorTransferencia(List<ComiteRecepcionEntity> ListComiteRecepcion)
        {
            try
            {

                using (var con = new SqlConnection(conexion.connectionString))
                {
                    con.Open();
                    int rowsAffected = 0;
                    string userName = HttpContext.Current.Session["userName"].ToString();
                    using (var cmd = new SqlCommand("insert into comite_recepcion(fk_personal,fk_transferencia,activo,usuariocreacion,fechacreacion) " +
                        "VALUES(@fk_personal,@fk_transferencia,1,'" + userName + "','" + DateTime.Now + "')", con))
                    {
                        cmd.Parameters.Add("@fk_personal", SqlDbType.VarChar);
                        cmd.Parameters.Add("@fk_transferencia", SqlDbType.VarChar);

                        foreach (var value in ListComiteRecepcion)
                        {
                            cmd.Parameters["@fk_personal"].Value = value.fk_personal;
                            cmd.Parameters["@fk_transferencia"].Value = value.fk_compra;
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