using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseClasificador
    {
        DataTable dtTable = new DataTable();
        Conexion conexion = new Conexion();

        /// <summary>
        /// Obtiene la lista de los clasificadores de un tipo de clasificador
        /// </summary>
        /// <param name="idClasificadorTipo"></param>
        /// <returns></returns>
        public List<ClasificadorEntity> List_DatosClasificadoresByIdTipo(int idClasificadorTipo)
        {
            string query = "select id,fk_clasificador,nombre,descripcion,activo from clasificadores where fk_clasificador="+idClasificadorTipo+" and activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            List<ClasificadorEntity> List = (from AnyName in dtTable.AsEnumerable()
                                             orderby AnyName.Field<string>("nombre")
                                                 select new ClasificadorEntity()
                                             {
                                                 id = AnyName.Field<int>("id"),
                                                 fk_clasificador = AnyName.Field<int>("fk_clasificador"),
                                                 nombre = AnyName.Field<string>("nombre"),
                                                 descripcion = AnyName.Field<string>("descripcion"),
                                                 activo = AnyName.Field<int>("activo")
                                             }).ToList();
            return List;
        }
    }
}