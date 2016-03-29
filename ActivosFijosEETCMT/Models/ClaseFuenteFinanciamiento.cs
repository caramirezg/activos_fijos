using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;

namespace ActivosFijosEETC.Models
{
    public class ClaseFuenteFinanciamiento
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de las fuentes de financiamiento
        /// </summary>
        /// <returns></returns>
        public List<FuenteFinanciamientoEntity> List_datosFuenteFinanciamiento()
        {
            string query = "select id,nombre,descripcion,sigla,activo from fuente_financiamiento " +
                          "where activo=1";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<FuenteFinanciamientoEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                        orderby AnyName.Field<string>("sigla")
                                                      select new FuenteFinanciamientoEntity()
                                        {
                                            id = AnyName.Field<int>("id"),
                                            nombre = AnyName.Field<string>("nombre"),
                                            descripcion = AnyName.Field<string>("descripcion"),
                                            sigla = AnyName.Field<string>("sigla"),
                                            activo = AnyName.Field<int>("activo")
                                        }).ToList();
            return Lista;
        }
    }
}