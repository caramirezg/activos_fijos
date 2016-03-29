using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseArea
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de las áreas con todos los campos
        /// </summary>
        /// <returns></returns>
        public List<AreaEntity> List_DatosArea(int fk_gerencia)
        {
            string query = "select id, nombre,descripcion, fk_gerencia from areas where activo=1 and fk_gerencia="+fk_gerencia+" ";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<AreaEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                      orderby AnyName.Field<string>("nombre")
                                      select new AreaEntity()
                                      {
                                          id=AnyName.Field<int>("id"),
                                          nombre=AnyName.Field<string>("nombre"),
                                          descripcion=AnyName.Field<string>("descripcion"),
                                          fk_gerencia=AnyName.Field<int>("fk_gerencia")
                                      }).ToList();
            return Lista;
        }
    }
}