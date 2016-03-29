using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ActivosFijos.Models;

namespace ActivosFijosEETC.Models
{
    public class ClaseReservaCorrelativo
    {
        DataTable dtTable = new DataTable();
        Conexion conexion = new Conexion();

        public DataTable getDataTableReservaCorrelativos()
        {
            string query = "	select id,tabla,RIGHT('00000000' + cast(correlativo as nvarchar(10)),7)+'/'+cast(gestion as nvarchar(4)) correlativo,gestion,vigente from reservas_correlativos where activo=1 order by gestion desc, correlativo desc";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }

        public DataTable getDataTableReservaVigenteCorrelativos()
        {
            string query = "select id,tabla,RIGHT('00000000' + cast(correlativo as nvarchar(10)),7)+'/'+cast(gestion as nvarchar(4)) correlativo from reservas_correlativos where activo=1 and vigente=1 order by gestion desc, correlativo desc";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            return dtTable;
        }

        public int CreaReserva(string tabla,int correlativo,int gestion)
        {
            try
            {
                int result = 0;
                SqlConnection conn = new SqlConnection(conexion.connectionString);
                string insert = "insert into reservas_correlativos "+
                                "(tabla,correlativo,gestion,vigente,activo,usuariocreacion,fechacreacion) "+
                                "values(@tabla,@correlativo,@gestion,@vigente,@activo,@usuario,sysdatetime())";
                SqlCommand Command = new SqlCommand(insert, conn);

                Command.CommandType = CommandType.Text;

                Command.Parameters.Add(new SqlParameter("@tabla", SqlDbType.NVarChar)).Value = tabla;
                Command.Parameters.Add(new SqlParameter("@correlativo", SqlDbType.NVarChar)).Value = correlativo;
                Command.Parameters.Add(new SqlParameter("@gestion", SqlDbType.NVarChar)).Value = gestion;
                Command.Parameters.Add(new SqlParameter("@vigente", SqlDbType.Int)).Value = 1;
                Command.Parameters.Add(new SqlParameter("@activo", SqlDbType.Int)).Value = 1;
                Command.Parameters.Add(new SqlParameter("@usuario", SqlDbType.NVarChar)).Value = HttpContext.Current.Session["userName"].ToString();

                conn.Open();
                result = int.Parse(Command.ExecuteNonQuery().ToString());

                conn.Close();
                return result;

            }
            catch (Exception e)
            {
                string a = e.ToString();
                return 0;
            }
        }

        public int EliminaReserva(int id)
        {
            try
            {
                int result = 0;
                SqlConnection conn = new SqlConnection(conexion.connectionString);
                string insert = "update reservas_correlativos " +
                                "set activo=0,usuariomodificacion=@usuario,fechamodificacion=sysdatetime()" +
                                "where id=@id";
                SqlCommand Command = new SqlCommand(insert, conn);

                Command.CommandType = CommandType.Text;

                Command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                Command.Parameters.Add(new SqlParameter("@usuario", SqlDbType.NVarChar)).Value = HttpContext.Current.Session["userName"].ToString();

                conn.Open();
                result = int.Parse(Command.ExecuteNonQuery().ToString());

                conn.Close();
                return result;

            }
            catch (Exception e)
            {
                string a = e.ToString();
                return 0;
            }
        }


        public int validaExisteReserva(int correlativo,int gestion)
        {
            try
            {
                int result = 0;
                string query = "select isnull(sum(ocupadas),0) "+
					            "from ( "+
					            "select count(id) ocupadas from reservas_correlativos where activo=1 and correlativo="+correlativo+" and gestion="+gestion+" "+
					            "union all "+
					            "select count(id) from compras where activo=1 and correlativo="+correlativo+" and year(f_registro)="+gestion+" "+
					            ")vista";
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());

                if (result > 0)
                {
                    result = 0;
                }else
                {
                    result = 1;
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