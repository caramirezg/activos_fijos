using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosFijos.Models;
using System.Data;
using ActivosFijosEETC.Models.DataSets;

namespace ActivosFijosEETC.Models
{
    public class ClaseAuxiliarContable
    {
        Conexion conexion = new Conexion();
        DataTable dtTable = new DataTable();

        /// <summary>
        /// Obtiene la lista de los grupos contables
        /// </summary>
        /// <returns></returns>
        public List<AuxiliarContableEntity> List_datosAuxiliaresContables(int id)
        {
            string query = "select a.codigo, a.id,a.nombre,a.descripcion,a.sigla,a.fk_grupo_contable, "+
		"(select g.nombre from grupos_contables g where g.id=a.fk_grupo_contable) grupo_contable, "+
		"activo "+
        "from auxiliares_contables a "+
        "where a.activo=1 "+
        "and a.fk_grupo_contable="+id+"";
            dtTable = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            List<AuxiliarContableEntity> Lista = (from AnyName in dtTable.AsEnumerable()
                                               orderby AnyName.Field<string>("codigo") ascending
                                                  select new AuxiliarContableEntity()
                                               {
                                                   ID = AnyName.Field<int>("id"),
                                                   codigo=AnyName.Field<string>("codigo"),
                                                   nombre = AnyName.Field<string>("nombre"),
                                                   descripcion = AnyName.Field<string>("descripcion"),
                                                   sigla = AnyName.Field<string>("sigla"),
                                                   fk_grupocontable = AnyName.Field<int>("fk_grupo_contable"),
                                                   grupo_contable = AnyName.Field<string>("grupo_contable"),
                                                   activo = AnyName.Field<int>("activo")
                                               }).ToList();
            return Lista;
        }

        /// <summary>
        /// Valida que la sigla no se repita
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
        public int validaSigla(string sigla, int idGrupoContable)
        {
            try
            {
                int result = 0;
                string query = "select count(sigla) from auxiliares_contables where activo=1 and sigla='" + sigla + "' and fk_grupo_contable="+idGrupoContable+"";
                result = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());
                if (result > 0)
                    result = 0;
                else
                    result = 1;
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }
        }
        /// <summary>
        /// Crea un nuevo grupo auxiliar contable
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="sigla"></param>
        /// <param name="grupoContable"></param>
        /// <returns></returns>
        public int CreaAuxiliarContable(string nombre, string descripcion, string sigla, int grupoContable)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                string query = "select RIGHT('000' + CAST(ISNULL(max(CAST(codigo AS INT) )+1,'1') AS VARCHAR(10)), 3) from auxiliares_contables where fk_grupo_contable="+grupoContable+" and activo=1";
                string codigo = SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString();


                int result = 0;
                string insert = "insert into auxiliares_contables " +
                "(codigo,nombre,descripcion,sigla,fk_grupo_contable,activo,usuariocreacion,fechacreacion) " +
                "values('"+codigo+"','" + nombre + "','" + descripcion + "','" + sigla + "'," + grupoContable + ",1,'" + userName + "','" + DateTime.Now + "')";
                result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, insert);
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;

            }
        }
        /// <summary>
        /// Edita un registro de grupo contable
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="sigla"></param>
        /// <param name="idGrupoContable"></param>
        /// <returns></returns>
        public int EditaAuxiliarContable(int id, string nombre, string descripcion, string sigla, int idGrupoContable)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                int result = 0;
                string insert = "update auxiliares_contables " +
                "set nombre='" + nombre + "', descripcion='" + descripcion + "', usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
                "where id=" + id + "";
                result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, insert);
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }

        }
        /// <summary>
        /// Elimina un registro de auxiliar contable de manera logica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EliminaAuxiliarContable(int id)
        {
            try
            {
                string userName = HttpContext.Current.Session["userName"].ToString();

                 int result = 0;
                string query = "select count(*) from activos where activo=1 and fk_auxiliar_contable="+id+"";
                int resultQuery = int.Parse(SqlHelper.ExecuteScalar(conexion.connectionString, CommandType.Text, query).ToString());

                if (resultQuery < 1)
                {
                    string insert = "update auxiliares_contables " +
                    "set activo='0', usuariomodificacion='" + userName + "', fechamodificacion='" + DateTime.Now + "' " +
                    "where id=" + id + "";
                    result = SqlHelper.ExecuteNonQuery(conexion.connectionString, CommandType.Text, insert);
                }
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return 0;
            }

        }

        public DataSet ReporteAuxiliaresPorArea()
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsAuxiliaresPorArea dsAuxiliares = new dsAuxiliaresPorArea();

            dsAuxiliares.Tables["auxiliares_area"].Clear();

            string query = "select p.area, ac.nombre auxiliar,count(ac.id) cantidad from asignaciones_detalle d "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable "+
                            "inner join personal p on p.id=fk_persona "+
                            "where d.fkc_estado_proceso=10 and d.activo=1 "+
                            "group by ac.nombre,p.area "+
                            "UNION "+
                            "select p.area, ac.nombre,count(ac.id) cantidad from asignaciones_por_transferencias_detalle d "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable "+
                            "inner join personal p on p.id=d.fk_persona_destino "+
                            "where d.fkc_estado_proceso=10 and d.activo=1 "+
                            "group by ac.nombre,p.area";


            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                string area = rowDetalle["area"].ToString();
                string auxiliar = rowDetalle["auxiliar"].ToString();
                string cantidad = rowDetalle["cantidad"].ToString();



                dsAuxiliares.Tables["auxiliares_area"].Rows.Add(new object[] {
                     area,
                     auxiliar,
                     cantidad
                   
                    });
            }
            return dsAuxiliares;
        }


        public DataSet ReporteAuxiliaresGeneral()
        {

            string nombre = HttpContext.Current.Session["nombre"].ToString();
            string apellido = HttpContext.Current.Session["apellido"].ToString();

            string iniciales = nombre.Substring(0, 1) + apellido.Substring(0, 1);

            DataTable TablaActivos = new DataTable();

            dsAuxiliaresPorArea dsAuxiliares = new dsAuxiliaresPorArea();

            dsAuxiliares.Tables["auxiliares_area"].Clear();

            string query = "select ac.nombre auxiliar,count(ac.id) cantidad from asignaciones_detalle d "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable "+
                            "inner join personal p on p.id=fk_persona "+
                            "where d.fkc_estado_proceso=10 and d.activo=1 "+
                            "group by ac.nombre "+
                            "UNION "+
                            "select ac.nombre,count(ac.id) cantidad from asignaciones_por_transferencias_detalle d "+
                            "inner join activos a on a.id=d.fk_activo "+
                            "inner join auxiliares_contables ac on ac.id=a.fk_auxiliar_contable "+
                            "inner join personal p on p.id=d.fk_persona_destino "+
                            "where d.fkc_estado_proceso=10 and d.activo=1 "+
                            "group by ac.nombre";


            TablaActivos.Clear();
            TablaActivos = SqlHelper.ExecuteDataset(conexion.connectionString, CommandType.Text, query).Tables[0];
            foreach (DataRow rowDetalle in TablaActivos.Rows)
            {
                
                string auxiliar = rowDetalle["auxiliar"].ToString();
                string cantidad = rowDetalle["cantidad"].ToString();

                dsAuxiliares.Tables["auxiliares_area"].Rows.Add(new object[] {
                     null,
                     auxiliar,
                     cantidad
                   
                    });
            }
            return dsAuxiliares;
        }
       
    }
}