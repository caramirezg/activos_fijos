using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using ActivosFijosEETC.Models;
using ActivosFijos.Models;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerProveedor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ControllerProveedor : System.Web.Services.WebService
    {
        ClaseProveedor ObjetoProveedor = new ClaseProveedor();
        
        /// <summary>
        /// Metodo para crear un proveedor en la base de datos de Almacen
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="telefono"></param>
        /// <param name="celular"></param>
        /// <param name="direccion"></param>
        /// <param name="nit"></param>
        /// <param name="lati"></param>
        /// <param name="longi"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int CreaProveedor(string nombre, string telefono, string celular, string direccion, string nit, string lati, string longi)
        {
            int Result = 0;
            Result = ObjetoProveedor.CreaProveedor(nombre, telefono, celular, direccion, nit, lati, longi);
            return Result;
        }
        /// <summary>
        /// Obtiene lista de todos los proveedores
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ProveedorEntity> DatosProveedores()
        {
            List<ProveedorEntity> Lista;
            Lista = ObjetoProveedor.List_DatosProveedores();
            return Lista;
        }
        /// <summary>
        /// Obtiene los datos de un proveedor por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ProveedorEntity> DatosProveedorPorID(string id)
        {
            List<ProveedorEntity> Lista;
            Lista = ObjetoProveedor.List_DatosProveedorPorID(int.Parse(id));
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
         [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int ActualizaProveedor(string id, string nombre, string telefono, string celular, string direccion, string nit, string lati, string longi)
        {
            int Result = 0;
            Result = ObjetoProveedor.ActualizaProveedor(int.Parse(id), nombre,telefono, celular, direccion, nit, lati, longi);
            return Result;
        }
       
    }
}
