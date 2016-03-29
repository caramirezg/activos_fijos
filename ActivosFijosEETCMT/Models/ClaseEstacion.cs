using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseEstacion
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de las estaciones
        /// </summary>
        /// <returns></returns>
        public List<EstacionEntity> List_DatosEstacionesByLinea(int fk_linea)
        {
            string query = "select id,nombre,fk_linea,activo from estaciones where activo=1 and fk_linea=" + fk_linea + "";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<EstacionEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                          select new EstacionEntity()
                                       {
                                           id = AnyName.Field<int>("id"),
                                           nombre = AnyName.Field<string>("nombre"),
                                           activo = AnyName.Field<int>("activo")
                                       }).ToList();
            return Lista;
        }
    }
}