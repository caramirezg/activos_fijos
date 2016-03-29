using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseCargo
    {
        DataTable dtTable = new DataTable();
        Conexion conexion = new Conexion();

        /// <summary>
        /// Obtiene la lista de los cargos
        /// </summary>
        /// <returns></returns>
        public List<CargoEntity> List_DatosCargo()
        {
            string query = "select id, nombre, descripcion, observaciones from cargo where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];

            List<CargoEntity> ListArea = (from AnyName in dtTable.AsEnumerable()
                                          orderby AnyName.Field<string>("nombre")
                                          select new CargoEntity()
                                          {
                                              ID = AnyName.Field<int>("id"),
                                              nombre = AnyName.Field<string>("nombre"),
                                              descripcion = AnyName.Field<string>("descripcion"),
                                              observaciones = AnyName.Field<string>("observaciones")
                                          }).ToList();
            return ListArea;
        }
    }
}