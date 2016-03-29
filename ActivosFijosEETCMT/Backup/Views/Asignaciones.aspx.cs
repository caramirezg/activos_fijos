using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Drawing;
using System.Data;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class Asignaciones : System.Web.UI.Page
    {
        ControllerHelper controllerHelper = new ControllerHelper();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null) { Response.Redirect("~/Views/login.aspx"); }
        }

        protected void _armarMenu()
        {
            ControllerAdministracion ObjetoAdministracion = new ControllerAdministracion();
            DataSet dsMenu = ObjetoAdministracion.getMenu();
            DataTable dtMenu = dsMenu.Tables[0];
            DataTable dtSubMenu = dsMenu.Tables[1];

            StringBuilder sb = new StringBuilder();
            //sb.Append("<ul class=" + "\"" + "sidebar-menu" + "\"" + ">");

            foreach (DataRow dr in dtMenu.Rows)
            {
                if (dr[4].ToString() == "0")
                {
                    sb.Append("<li class=" + "\"" + "active" + "\"" + "><a href=" + "\"" + dr[2].ToString() + "\"" + "><i class=" + "\"" + dr[3] + "\"" + "></i><span>" + dr[1].ToString() + " </span></a>");
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append("<li class=" + "\"" + "treeview" + "\"" + "><a href=" + "\"" + "#" + "\"" + "><i class=" + "\"" + dr[3] + "\"" + "></i><span>" + dr[1].ToString() + "</span><i class=" + "\"" + "fa fa-angle-left pull-right" + "\"" + "></i></a>");
                    sb.Append("<ul class=" + "\"" + "treeview-menu" + "\"" + ">");
                    foreach (DataRow dr1 in dtSubMenu.Rows)
                    {
                        if (dr1[1].ToString().Equals(dr[0].ToString()))
                        {
                            sb.Append("<li><a href=" + "\"" + dr1[3] + "\"" + "><i class=" + "\"" + "fa fa-angle-double-right" + "\"" + "></i>" + dr1[2] + "</a>");
                            sb.Append("</li>");
                        }
                    }
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }
            }
            _menu.InnerHtml = sb.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             string vPerfil = HttpContext.Current.Session["perfil"].ToString();
             if (!vPerfil.Equals("2"))//persona
             {

                 if (!Page.IsPostBack)
                 {
                     lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                     lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                     _armarMenu();
                     div_ListaAsignaciones.Visible = true;
                     div_RegistroMaestroAsignacion.Visible = false;
                     div_ResponsableAsignado.Visible = false;
                     cargarGrillaPersonal();
                     cargarComboLineas();
                     cargarComboUbicaciones();
                     //linea.Visible = false;
                     //estacion.Visible = false;
                 }

                 cargaGrillaAsignaciones();

                 if (div_ResponsableAsignado.Visible == true)
                     cargarGrillaPersonal();
             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }

        }
        /// <summary>
        /// Carga el combo de lineas
        /// </summary>
        private void cargarComboLineas()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlLinea.DataSource = controllerHelper.ToDataTable(vObjeto.obtieneListLineas());
            ddlLinea.DataValueField = "id";
            ddlLinea.DataTextField = "nombre";
            ddlLinea.DataBind();
        }

        private void cargarComboUbicaciones()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlUbicacion.DataSource = controllerHelper.ToDataTable(vObjeto.DatosClasificadoresByIDTipo("4"));
            ddlUbicacion.DataValueField = "id";
            ddlUbicacion.DataTextField = "nombre";
            ddlUbicacion.DataBind();
        }

        /// <summary>
        /// Carga la grilla del personal
        /// </summary>
        private void cargarGrillaPersonal()
        {
            ControllerPersonal vObjeto = new ControllerPersonal();

            gridPersonal.DataSource = controllerHelper.ToDataTable(vObjeto.ListPersonal());
            gridPersonal.KeyFieldName = "documento";
            gridPersonal.DataBind();
        }

        private void cargaGrillaAsignaciones()
        {
            ControllerAsignaciones vObjeto = new ControllerAsignaciones();

        
            gridAsignaciones.DataSource = vObjeto.DatosAsignacionesMaestro();
            gridAsignaciones.KeyFieldName = "id";
            gridAsignaciones.DataBind();

       
        }
        /// <summary>
        /// Muestra los campos para una nueva asignacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistroAsignacion_Click(object sender, EventArgs e)
        {
            div_ListaAsignaciones.Visible = false;
            div_RegistroMaestroAsignacion.Visible = true;
            div_ResponsableAsignado.Visible = true;
        }

        /// <summary>
        /// Guarda el registro de maestro de asignacion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarAsignacion_Click(object sender, EventArgs e)
        {
            if (gridPersonal.FocusedRowIndex > -1)
            {
                var fila = this.gridPersonal.GetRow(gridPersonal.FocusedRowIndex);
                string fk_persona = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string nro_documento = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                string nombres = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                string apellidos = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                string gerencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                string fkc_estado_proceso = "9";//9=ESTADO PRE ASIGNADO

                string fk_estacion=null;
                string estacion = null;
                string linea = null;

                string dateAsignacion = Request.Form["dateFechaAsignacion"];
                string fkc_ubicacion = ddlUbicacion.SelectedItem.Value;
                string ubicacion = ddlUbicacion.SelectedItem.Text;
                if (ddlEstacion.SelectedIndex > -1)
                {
                    fk_estacion = ddlEstacion.SelectedItem.Value;
                    estacion = ddlEstacion.SelectedItem.Text;
                    linea = ddlLinea.SelectedItem.Text;
                }
               //11=OFICINAS ADMINISTRATIVAS
                if (ddlUbicacion.SelectedItem.Value == "11")
                {
                    fk_estacion = null;
                    estacion = null;
                    linea = null;
                }

                ControllerAsignaciones vObjetoAsignaciones = new ControllerAsignaciones();
                int resultComite = vObjetoAsignaciones.CreaMaestroAsignacion(dateAsignacion, fkc_ubicacion, fk_persona, fk_estacion);

                if(resultComite>0)
                    Response.Redirect("RegistroAsignadosPorPersona.aspx?codigoAsignacion=" + resultComite + " &f_asignacion= " + dateAsignacion + " &ubicacion=" + ubicacion + " &fk_persona= " + fk_persona + " &nombres=" + nombres + " &apellidos=" + apellidos + " &linea=" + linea + " &estacion=" + estacion + " &gerencia=" + gerencia + " &documento=" + nro_documento + " &fk_estacion=" + fk_estacion + " &fkc_estado_proceso=" + fkc_estado_proceso + "");
            }
        }

        protected void ddlLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idLinea = ddlLinea.SelectedItem.Value.ToString();
            cargaEstaciones(idLinea);
        }

        public void cargaEstaciones(string idLinea)
        {
            ddlEstacion.Items.Clear();
            ddlEstacion.Items.Add(new ListItem("Seleccione un item", "-1"));

            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlEstacion.DataSource = controllerHelper.ToDataTable(vObjeto.obtieneListEstacionesPorLinea(idLinea));
            ddlEstacion.DataValueField = "id";
            ddlEstacion.DataTextField = "nombre";
            ddlEstacion.DataBind();

        }

        protected void btnAsignarActivos_Click(object sender, EventArgs e)
        {
            if (gridAsignaciones.FocusedRowIndex > -1)
            {
                var fila = this.gridAsignaciones.GetRow(gridAsignaciones.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string f_asignacion = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                string ubicacion = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                string fk_persona = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                string nro_documento = ((System.Data.DataRowView)(fila)).Row.ItemArray[6].ToString();
                string nombres = ((System.Data.DataRowView)(fila)).Row.ItemArray[7].ToString();
                string apellidos = ((System.Data.DataRowView)(fila)).Row.ItemArray[8].ToString();
                string linea = ((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString();
                string fk_estacion = ((System.Data.DataRowView)(fila)).Row.ItemArray[10].ToString();
                string estacion = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();
                string gerencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[12].ToString();
                string fkc_estado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[13].ToString();
                string estado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[14].ToString();

                Response.Redirect("RegistroAsignadosPorPersona.aspx?codigoAsignacion=" + id + " &f_asignacion= " + f_asignacion + " &ubicacion=" + ubicacion + " &fk_persona= " + fk_persona + " &nombres=" + nombres + " &apellidos=" + apellidos + " &fk_estacion=" + fk_estacion + " &linea=" + linea + " &estacion=" + estacion + " &gerencia=" + gerencia + " &fkc_estado_proceso=" + fkc_estado_proceso + " &estado_proceso=" + estado_proceso + " &documento=" + nro_documento + "");
            }
        }

     
        /// <summary>
        /// Vuelve al listado de asignaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            div_ListaAsignaciones.Visible = true;
            div_RegistroMaestroAsignacion.Visible = false;
            div_ResponsableAsignado.Visible = false;

        }
        /// <summary>
        /// Elimina un maestro de asignacion en estado pre asignado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminarAsignacion_Click(object sender, EventArgs e)
        {
            if (gridAsignaciones.FocusedRowIndex > -1)
            {
                var fila = this.gridAsignaciones.GetRow(gridAsignaciones.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[13].ToString();
                //Estado 9 estado pre asignado
                if (idEstado_proceso == "9")
                {
                    ControllerAsignaciones vObjeto = new ControllerAsignaciones();
                    int result = vObjeto.EliminaMaestroAsignacion(id);
                    if (result > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Registro eliminado con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargaGrillaAsignaciones();
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroDanger').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('No puede eliminar un registro en estado asignado').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }
        /// <summary>
        /// Aprueba una asignacion de estado pre asignado a asignado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAprobarAsignacion_Click(object sender, EventArgs e)
        {
            if (gridAsignaciones.FocusedRowIndex > -1)
            {
                var fila = this.gridAsignaciones.GetRow(gridAsignaciones.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[13].ToString();
                if (idEstado_proceso == "9")
                {
                    ControllerAsignaciones vObjeto = new ControllerAsignaciones();
                    int result = vObjeto.ApruebaAsignacion(id);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Asignación aprobada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargaGrillaAsignaciones();
                    }
                } else 
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('La asignacion ya fue aprobada').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void gridAsignaciones_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado_proceso");
            if (value == "ASIGNADO")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#79658B");
                e.Row.ForeColor = Color.White;
            }
        }

      

   

        
    }
}