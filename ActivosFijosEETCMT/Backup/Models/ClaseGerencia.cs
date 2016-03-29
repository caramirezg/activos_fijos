using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ActivosFijos.Models;

namespace ActivosFijosEETC.Models
{
    public class ClaseGerencia
    {
        DataTable dtTable = new DataTable();
        Conexion conexion = new Conexion();
        /// <summary>
        /// Obtiene la lista de las gerencias
        /// </summary>
        /// <returns></returns>
        public List<GerenciaEntity> List_DatosGerencias()
        {
            string query = "select id,nombre,activo from gerencias where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            List<GerenciaEntity> List = (from AnyName in dtTable.AsEnumerable()
                                          orderby AnyName.Field<string>("nombre")
                                             select new GerenciaEntity()
                                          {
                                              id = AnyName.Field<int>("id"),
                                              nombre = AnyName.Field<string>("nombre"),
                                              activo = AnyName.Field<int>("activo")
                                          }).ToList();
            return List;
        }

      
    }
}