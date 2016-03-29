using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseLinea
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de las lineas
        /// </summary>
        /// <returns></returns>
        public List<LineaEntity> List_DatosLineas()
        {
            string query = "select id,nombre,activo from lineas where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<LineaEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                       select new LineaEntity()
                                      {
                                          id = AnyName.Field<int>("id"),
                                          nombre = AnyName.Field<string>("nombre"),
                                          activo = AnyName.Field<int>("activo")
                                      }).ToList();
            return Lista;
        }
    }
}