using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;


namespace ActivosFijosEETC.Views
{
    public partial class Kardex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             string vPerfil = HttpContext.Current.Session["perfil"].ToString();
             if (!vPerfil.Equals("2"))//persona
             {

                 cargaGrillaActivos();


                 if (!Page.IsPostBack)
                 {
                     lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                     lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                     ///Roles de usuario
                    
                     if (vPerfil.Equals("1"))
                     {
                         //_solicitudesSalidas.Visible = false;
                         _parametrizacion.Visible = true;
                         _proveedores.Visible = true;
                         _altas.Visible = true;
                         _transferencias.Visible = true;
                         _asignaciones.Visible = true;
                         _depreciaciones.Visible = true;
                         _control_activos.Visible = true;
                         _cierre.Visible = true;
                         _apertura.Visible = true;
                         _reportes.Visible = true;

                     }
                     else if (vPerfil.Equals("2"))
                     {
                         //_solicitudesSalidas.Visible = true;
                         _parametrizacion.Visible = false;
                         _proveedores.Visible = false;
                         _altas.Visible = false;
                         _transferencias.Visible = false;
                         _asignaciones.Visible = false;
                         _depreciaciones.Visible = false;
                         _control_activos.Visible = false;
                         _cierre.Visible = false;
                         _apertura.Visible = false;
                         _reportes.Visible = false;
                         _bajas.Visible = false;
                     }
                     else if (vPerfil.Equals("3"))
                     {
                         //_solicitudesSalidas.Visible = false;
                         _parametrizacion.Visible = false;
                         _proveedores.Visible = false;
                         _altas.Visible = false;
                         _transferencias.Visible = false;
                         _asignaciones.Visible = false;
                         _depreciaciones.Visible = false;
                         _control_activos.Visible = false;
                         _cierre.Visible = false;
                         _apertura.Visible = false;
                         _reportes.Visible = true;
                         _bajas.Visible = false;


                         //rep_activos_con_custodio.Visible = false;
                         //rep_kardex.Visible = false;
                         //rep_activos_por_estacion_linea.Visible = false;
                         //rep_activos_por_responsable.Visible = false;
                         //rep_agrupado.Visible = false;
                         //rep_auxiliares_por_area.Visible = false;
                     }
                 }

             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }
            
        }

        private void cargaGrillaActivos()
        {
            ControllerActivos vObjeto = new ControllerActivos();
            gridActivos.DataSource = vObjeto.DatosExistenciasActivos();
            gridActivos.KeyFieldName = "id";
            gridActivos.DataBind();
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (gridActivos.FocusedRowIndex > -1)
            {
                var fila = this.gridActivos.GetRow(gridActivos.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
               
                Response.Redirect("reportes/ReporteKardex.aspx?id_activo=" + id + "");
            }
        }

       
    }
}