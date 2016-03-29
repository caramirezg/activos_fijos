using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ActivosFijosEETC.Controllers;
using System.Reflection;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class GruposContables : System.Web.UI.Page
    {
        DataTable dtGruposContables = new DataTable();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null) { Response.Redirect("~/Views/Login.aspx"); }
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
                    cargaGrilla();
                    _armarMenu();
                }
                cargaGrillaPorSession();
            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        private void cargaGrilla() {

            ControllerGruposContables vObjeto = new ControllerGruposContables();
            dtGruposContables=ToDataTable(vObjeto.DatosGruposContables());
            Session.Add("dtGruposContables", dtGruposContables);
        }

        private void cargaGrillaPorSession()
        {
            gridGruposContables.DataSource = (DataTable)Session["dtGruposContables"];
            gridGruposContables.KeyFieldName = "ID";
            gridGruposContables.DataBind();
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        /// <summary>
        /// Guarda un registro de grupo contable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarGrupoContable_Click(object sender, EventArgs e)
        {
            ControllerGruposContables vObjeto = new ControllerGruposContables();
           

            if (string.IsNullOrEmpty(id.Text))
            {
                if (vObjeto.validaSigla(sigla.Text) == 1)
                {
                    if (vObjeto.validaCodigo(txtCodigoGrupo.Text) == 1)
                    {

                        int result = vObjeto.CreaGrupoContable(txtCodigoGrupo.Text, nombre.Text, descripcion.Text, vida_util.Text, sigla.Text, porcentaje.Text, ddlDepreciable.SelectedItem.Value, ddlActualizable.SelectedItem.Value);
                        if (result > 0)
                        {
                            
                            cargaGrilla();
                            cargaGrillaPorSession();
                            string message = "$('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                            ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                            
                            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        }
                        else
                        {
                            string message = "$('#danger').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                            ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                        }
                    }
                    else
                    {
                        string message = "$('#danger').text('Ya existe un grupo contable con el mismo código, por favor digite otra código').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                        //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Ya existe un grupo contable con el mismo código, por favor digite otra código').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                    }
                }
                else
                {
                    string message = "$('#danger').text('Ya existe un grupo contable con la misma sigla, por favor digite otra sigla').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Ya existe un grupo contable con la misma sigla, por favor digite otra sigla').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
            }
            else
            {
               

                vObjeto.EditaGrupoContable(id.Text, nombre.Text, descripcion.Text, vida_util.Text, sigla.Text, porcentaje.Text, ddlDepreciable.SelectedItem.Value, ddlActualizable.SelectedItem.Value);
                cargaGrilla();
                cargaGrillaPorSession();
                string message = "$('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                //ClientScript.RegisterClientScriptBlock(this.GetType(), "myScript","<script>javascript: $('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline }); windows.location='Default.aspx';</script>");
            }
            string close = "modalHide();";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "mostrarPopup", close, true);
         

        }

        /// <summary>
        /// Limpia los campos
        /// </summary>
        protected void limpiarCampos() { 
        nombre.Text="";
        descripcion.Text="";
        vida_util.Text="";
        sigla.Text="";
        porcentaje.Text = "";
        }
        /// <summary>
        /// Muestra los datos para editar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridGruposContables.FocusedRowIndex > -1)
            {
                //ClientScript.RegisterStartupScript(GetType(), "mostrarPopup", "modalEditar();", true);}string message = "modalEditar();";
                string message = "modalEditar();";
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
                var fila = this.gridGruposContables.GetRow(gridGruposContables.FocusedRowIndex);

                id.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                txtCodigoGrupo.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                nombre.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                descripcion.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                sigla.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
                vida_util.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                porcentaje.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[6].ToString();
                ddlActualizable.SelectedValue = ((System.Data.DataRowView)(fila)).Row.ItemArray[9].ToString();
                ddlDepreciable.SelectedValue = ((System.Data.DataRowView)(fila)).Row.ItemArray[8].ToString();


            }
        }
        /// <summary>
        /// Elimina un registro de grupo contable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridGruposContables.FocusedRowIndex > -1)
            {
                var fila = this.gridGruposContables.GetRow(gridGruposContables.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                
                ControllerGruposContables vObjeto = new ControllerGruposContables();
                int result = vObjeto.EliminaGrupoContable(id);
                if (result == 1)
                {
                    cargaGrilla();
                    cargaGrillaPorSession();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro eliminado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('El registro no puede ser eliminado, es posible que el grupo contable ya este asignado a un activo').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
            
            }
        }

        protected void gridGruposContables_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "porcentaje_depreciacion")
                e.DisplayText = String.Format("{0:d}", e.Value)+" %";
            if (e.Column.FieldName == "vida_util")
                e.DisplayText = String.Format("{0:d}", e.Value) + " años"; 
           
        }

        protected void gridGruposContables_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "depreciable" || e.DataColumn.FieldName=="actualizable")
            {
                if (e.CellValue.Equals("1"))
                {
                    e.Cell.Text="SI";
                }else if(e.CellValue.Equals("0"))
                {
                    e.Cell.Text="NO";
                }
            }
        }
    }
}