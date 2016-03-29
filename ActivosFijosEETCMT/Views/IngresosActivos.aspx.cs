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
    public partial class IngresosActivos : System.Web.UI.Page
    {
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

                if (!Page.IsPostBack)
                {

                    lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    _armarMenu();

                    div_ListaIngresos.Visible = true;
                    div_RegistroMaestroIngreso.Visible = false;

                  
                    if (vPerfil.Equals("2"))
                    {
                       
                        this.btnAprobar.Visible = false;
                    }

                }

                cargarGrillaIngresos();
                cargarGrillaSalidasAprobadas();
            
           
        }

        private void cargarGrillaIngresos()
        {
            string vFk_persona = HttpContext.Current.Session["fk_persona"].ToString();
            string vPerfil = HttpContext.Current.Session["perfil"].ToString();
            
            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

            gridIngresos.DataSource = vObjeto.DatosActivosIngresados(vFk_persona, vPerfil);
            gridIngresos.KeyFieldName = "id";
            gridIngresos.DataBind();
        }

        protected void btnNuevoIngreso_Click(object sender, EventArgs e)
        {
            div_ListaIngresos.Visible = false;
            div_RegistroMaestroIngreso.Visible = true;
            cargarGrillaSalidasAprobadas();
            txtFechaIngreso.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void cargarGrillaSalidasAprobadas()
        {
            string vFk_persona = HttpContext.Current.Session["fk_persona"].ToString();
            string vPerfil = HttpContext.Current.Session["perfil"].ToString();

            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

            gridSalidas.DataSource = vObjeto.DatosSalidasAprobadas(vFk_persona, vPerfil);
            gridSalidas.KeyFieldName = "id";
            gridSalidas.DataBind();
        }

        protected void btnAprobarIngreso_Click(object sender, EventArgs e)
        {
            if (gridIngresos.FocusedRowIndex > -1)
            {
                var fila = this.gridIngresos.GetRow(gridIngresos.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string f_solicitud = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();
                //Estado 22 PRE INGRESADO
                if (idEstado_proceso == "22")
                {
                    ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();
                    int result = vObjeto.ApruebaIngreso(id, f_solicitud);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Ingreso aprobado con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaIngresos();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se pueden aprobar ingresos en estado PRE-INGRESADO').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnEliminarIngreso_Click(object sender, EventArgs e)
        {
            if (gridIngresos.FocusedRowIndex > -1)
            {
                var fila = this.gridIngresos.GetRow(gridIngresos.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string idEstado_proceso = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();
                //Estado 22 PRE-INGRESADO
                if (idEstado_proceso == "22")
                {
                    ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();
                    int result = vObjeto.EliminaIngreso(id);
                    if (result == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Solicitud eliminada con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        cargarGrillaIngresos();
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se pueden Eliminar ingresos en estado PRE-INGRESADO').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            div_ListaIngresos.Visible = true;
            div_RegistroMaestroIngreso.Visible = false;
        }

        protected void btnVerDetalleIngreso_Click(object sender, EventArgs e)
        {
            if (gridIngresos.FocusedRowIndex > -1)
            {
                var fila = this.gridIngresos.GetRow(gridIngresos.FocusedRowIndex);
             
                string id_maestro_ingresos = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string id_maestro_salidas = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                string fecha_ingreso = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                string documento = ((System.Data.DataRowView)(fila)).Row.ItemArray[6].ToString();
                string nombres = ((System.Data.DataRowView)(fila)).Row.ItemArray[7].ToString();
                string apellidos = ((System.Data.DataRowView)(fila)).Row.ItemArray[8].ToString();
                string area = ((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString();
                string gerencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[10].ToString();
                string fkc_estado_ingreso = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();

                string correlativo = gridIngresos.GetRowValues(gridIngresos.FocusedRowIndex, "correlativo").ToString();
                if (string.IsNullOrEmpty(correlativo))
                    correlativo = "0";


                Response.Redirect("RegistroActivosPorIngreso.aspx?id_maestro_ingresos=" + id_maestro_ingresos + " &correlativo=" + correlativo + " &id_maestro_salidas= " + id_maestro_salidas + " &fecha_ingreso=" + fecha_ingreso + " &documento=" + documento + "  " +
                    "&nombres=" + nombres + "  &apellidos= " + apellidos + " &area=" + area + " &gerencia=" + gerencia + "  &fkc_estado_ingreso=" + fkc_estado_ingreso + "");
            }
        }

        protected void btnGuardarIngreso_Click(object sender, EventArgs e)
        {

            string fechaIngreso = txtFechaIngreso.Text;


            if (gridSalidas.FocusedRowIndex > -1)
            {
                var fila = this.gridSalidas.GetRow(gridSalidas.FocusedRowIndex);
               
                string id_maestro_salidas = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                string documento = ((System.Data.DataRowView)(fila)).Row.ItemArray[7].ToString();
                string nombres = ((System.Data.DataRowView)(fila)).Row.ItemArray[8].ToString();
                string apellidos = ((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString();
                string area = ((System.Data.DataRowView)(fila)).Row.ItemArray[10].ToString();
                string gerencia = ((System.Data.DataRowView)(fila)).Row.ItemArray[11].ToString();
                string fkc_estado_ingreso="22";//22 ESTADO PRE INGRESADO
                string correlativo = null;

                if (string.IsNullOrEmpty(fechaIngreso))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Por favor revise los campos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                {
                    ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();
                    int result = vObjeto.CreaIngresoMaestro(fechaIngreso, id_maestro_salidas);

                    if (result > 0)
                    {
                        Response.Redirect("RegistroActivosPorIngreso.aspx?id_maestro_ingresos=" + result + " &correlativo=" + correlativo + " &id_maestro_salidas= " + id_maestro_salidas + " &fecha_ingreso=" + txtFechaIngreso.Text + " &documento=" + documento + "  " +
                       "&nombres=" + nombres + "  &apellidos= " + apellidos + " &area=" + area + " &gerencia=" + gerencia + "  &fkc_estado_ingreso=" + fkc_estado_ingreso + "");
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroDanger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
            }
        }

        protected void gridIngresos_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado_ingreso");
            if (value == "INGRESADO")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#29A9A0");
                e.Row.ForeColor = Color.White;
            }
        }

        protected void btnEditarMaestro_Click(object sender, EventArgs e)
        {
            if (gridIngresos.FocusedRowIndex > -1)
            {
                if (gridIngresos.GetRowValues(gridIngresos.FocusedRowIndex, "fkc_estado_ingreso").ToString() == "22")
                {
                    string message = "modalEditar();";
                    ScriptManager.RegisterStartupScript(sender as Control, this.GetType(), "alert", message, true);
                    dateEditaFechaIngreso.Value = Convert.ToDateTime(gridIngresos.GetRowValues(gridIngresos.FocusedRowIndex, "f_ingreso").ToString()).ToString("dd/MM/yyyy");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroWarning').text('Solo se puede editar ingresos en estado PRE-INGRESADO').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }

        protected void btnGuardarEditaMaestro_Click(object sender, EventArgs e)
        {
            if (gridIngresos.FocusedRowIndex > -1)
            {
                ControllerIngresosSalidas objetoSalidas = new ControllerIngresosSalidas();
                int vResult = objetoSalidas.EditaIngresoMaestro(Request.Form["dateEditaFechaIngreso"].ToString().Trim(),gridIngresos.GetRowValues(gridIngresos.FocusedRowIndex, "id").ToString());
                if (vResult == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroSuccess').text('Ingreso editado con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                    cargarGrillaIngresos();
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#divMaestroDanger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }
    }
}