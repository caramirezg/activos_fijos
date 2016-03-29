using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseProveedor
    {
        /// <summary>
        /// Cadena de conexion sistema de almacenes
        /// </summary>
        Conexion conexion = new Conexion();
        DataSet dsDataSet = new DataSet();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Adiciona un nuevo proveedor (conexión con la tabla proveedores de almacenes)
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="telefono"></param>
        /// <param name="celular"></param>
        /// <param name="direccion"></param>
        /// <param name="nit"></param>
        /// <param name="lati"></param>
        /// <param name="longi"></param>
        /// <returns></returns>
        public int CreaProveedor(string nombre, string telefono, string celular, string direccion, string nit, string lati, string longi)
        {
            try
            {
                int result = 0;
                string userName = HttpContext.Current.Session["userName"].ToString();
                string insert = "insert into proveedores " +
               "(nombre,telefono,celular,direccion,nit,latitud,longitud,activo,usuariocreacion,fechacreacion) " +
               "values('" + nombre + "','" + telefono + "','" + celular + "','" + direccion + "','" + nit + "','" + lati + "','" + longi + "',1,'" + userName + "','" + DateTime.Now + "')";
                result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, insert);
                return result;
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return 0;
            }
        }
        /// <summary>
        /// Retorna la lista de todos los proveedores (conexión con la tabla de la bd de almacenes)
        /// </summary>
        /// <returns></returns>
        public List<ProveedorEntity> List_DatosProveedores()
        {
            string consulta = "select id,nombre,telefono,celular,direccion,nit,latitud,longitud,activo from proveedores where activo =1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, consulta).Tables[0];

            List<ProveedorEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                           orderby AnyName.Field<string>("nombre")
                                           select new ProveedorEntity()
                                           {
                                               ID = AnyName.Field<int>("id"),
                                               nombre = AnyName.Field<string>("nombre").ToUpper(),
                                               celular = AnyName.Field<string>("celular"),
                                               telefono = AnyName.Field<string>("telefono"),
                                               direccion = AnyName.Field<string>("direccion").ToUpper(),
                                               nit = AnyName.Field<string>("nit"),
                                               lati = AnyName.Field<string>("latitud"),
                                               longi = AnyName.Field<string>("longitud")
                                           }).ToList();
            return Lista;
        }

        /// <summary>
        /// Obtiene los datos de un proveedor por ID (conexión con la tabla de la bd de almacenes)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ProveedorEntity> List_DatosProveedorPorID(int id)
        {
            string consulta = "select nombre,telefono,celular,direccion,nit,latitud,longitud,activo from proveedores where id=" + id + " and activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, consulta).Tables[0];

            List<ProveedorEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                           select new ProveedorEntity()
                                           {
                                               nombre = AnyName.Field<string>("nombre").ToUpper(),
                                               telefono = AnyName.Field<string>("telefono"),
                                               celular = AnyName.Field<string>("celular"),
                                               direccion = AnyName.Field<string>("direccion").ToUpper(),
                                               nit = AnyName.Field<string>("nit").ToUpper(),
                                               lati = AnyName.Field<string>("latitud"),
                                               longi = AnyName.Field<string>("longitud")
                                           }).ToList();
            return Lista;
        }

        /// <summary>
        /// Actualiza los datos de un proveedor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="telefono"></param>
        /// <param name="celular"></param>
        /// <param name="direccion"></param>
        /// <param name="nit"></param>
        /// <param name="lati"></param>
        /// <param name="longi"></param>
        /// <returns></returns>
        public int ActualizaProveedor(int id, string nombre, string telefono, string celular, string direccion, string nit, string lati, string longi)
        {
            try
            {
                int result = 0;
                string userName = HttpContext.Current.Session["userName"].ToString();
                string update = "update proveedores " +
                    "set nombre='" + nombre + "', telefono='" + telefono + "',celular='" + celular + "',direccion='" + direccion + "',nit='" + nit + "',latitud='" + lati + "',longitud='" + longi + "', " +
                    "usuariomodificacion='"+userName+"',fechamodificacion='"+DateTime.Now+"' "+
                    "where id=" + id + "";

                result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, update);
                return result;
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return 0;
            }
        }
    }
}