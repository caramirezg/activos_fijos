using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ConexionAlmacenes
    {
        private string _connectionString;
        public string connectionString {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        /// <summary>
        /// Cadena de conexion
        /// </summary>
        public ConexionAlmacenes()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["ConexionAlmacenesEETC"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Abre la conexion a la base de datos
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public SqlConnection openConnection(string connectionString) 
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(connectionString);
                MyConnection.Open();
                return MyConnection;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        /// <summary>
        /// Cierra la conexion a la base de datos
        /// </summary>
        /// <param name="MyConnection"></param>
        public void closeConnection(SqlConnection MyConnection) 
        {
            try
            {
                if (MyConnection.State == ConnectionState.Open)
                    MyConnection.Close();
            }
            catch (Exception ex)
            {
                throw(new Exception(ex.Message));
            }
        }
    }
}