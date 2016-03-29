using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Data;
using System.Reflection;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class GruposAuxiliares : System.Web.UI.Page
    {
        DataTable dtGruposContables = new DataTable();
        DataTable dtGruposAuxiliares = new DataTable();
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
                     cargaGrillaGruposContables();
                     div_auxiliares.Visible = false;
                 }

                 cargaGrillaGruposContablesPorSession();
                 if (gridGruposContables.FocusedRowIndex > -1)
                 {
                     cagarAuxiliaresSession();
                 }
             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }
        }
        /// <summary>
        /// Carga la grilla de grupos contables
        /// </summary>
        private void cargaGrillaGruposContables()
        {

            ControllerGruposContables vObjeto = new ControllerGruposContables();
            dtGruposContables = controllerHelper.ToDataTable(vObjeto.DatosGruposContables());
            Session.Add("dtGruposContables", dtGruposContables);
        }

        private void cargaGrillaGruposContablesPorSession()
        {
            gridGruposContables.DataSource = (DataTable)Session["dtGruposContables"];
            gridGruposContables.KeyFieldName = "ID";
            gridGruposContables.DataBind();
        }
        /// <summary>
        /// Muestra datos para editar un auxiliar contable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditarAuxiliar_Click(object sender, EventArgs e)
        {
            if (gridAuxiliaresContables.FocusedRowIndex > -1)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarPopup", "modalEditar();", true);
                var fila = this.gridAuxiliaresContables.GetRow(gridAuxiliaresContables.FocusedRowIndex);
                id.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                nombre.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                descripcion.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                sigla.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString();
            }
        }

        /// <summary>
        /// Muestra los auxiliares de un grupo contable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerAuxiliares_Click(object sender, EventArgs e)
        {
            if (gridGruposContables.FocusedRowIndex > -1)
            {
                var fila = this.gridGruposContables.GetRow(gridGruposContables.FocusedRowIndex);
                cargarAuxiliares();
                lblAuxiliarContable.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString() + " " + ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                div_gruposcontables.Visible = false;
                div_auxiliares.Visible = true;
            }
        }

        private void cargarAuxiliares() 
        {
            var fila = this.gridGruposContables.GetRow(gridGruposContables.FocusedRowIndex);
            string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
            ControllerAuxiliaresContables vObjeto = new ControllerAuxiliaresContables();
            dtGruposAuxiliares = controllerHelper.ToDataTable(vObjeto.DatosAuxiliaresContables(id));
            Session.Add("dtAuxiliaresContables", dtGruposAuxiliares);
            gridAuxiliaresContables.DataSource = (DataTable)Session["dtAuxiliaresContables"];
            gridAuxiliaresContables.KeyFieldName = "ID";
            gridAuxiliaresContables.DataBind();
        }

        /// <summary>
        /// Carga los datos de auxiliares contables de la session actual
        /// </summary>
        private void cagarAuxiliaresSession() 
        {
            gridAuxiliaresContables.DataSource = (DataTable)Session["dtAuxiliaresContables"];
            gridAuxiliaresContables.KeyFieldName = "ID";
            gridAuxiliaresContables.DataBind();
        }
        /// <summary>
        /// Vuelve a la pantalla de grupos contables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerGruposContables_Click(object sender, EventArgs e)
        {
            div_gruposcontables.Visible = true;
            div_auxiliares.Visible = false;
        }
        /// <summary>
        /// Guarda los datos de un grupo auxiliar contable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarAuxiliaresContables_Click(object sender, EventArgs e)
        {
            ControllerAuxiliaresContables vObjeto = new ControllerAuxiliaresContables();

            var fila = this.gridGruposContables.GetRow(gridGruposContables.FocusedRowIndex);
            string idGrupoContable = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

            if (string.IsNullOrEmpty(id.Text))
            {
                if (vObjeto.validaSigla(sigla.Text,idGrupoContable) == 1)
                {
                    int result = vObjeto.CreaAuxiliarContable(nombre.Text, descripcion.Text, sigla.Text, idGrupoContable);
                    if (result > 0)
                    {
                        cargarAuxiliares();
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                    }else
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Ya existe un auxiliar contable con la misma sigla, por favor digite otra sigla').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
            }
            else
            {
                vObjeto.EditaGrupoContable(id.Text, nombre.Text, descripcion.Text, sigla.Text, idGrupoContable);
                cargarAuxiliares();
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline }); windows.location='Default.aspx';</script>");
            }
        }
        /// <summary>
        /// Elimina un registro de auxiliar contable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridAuxiliaresContables.FocusedRowIndex > -1)
            {
                var fila = this.gridAuxiliaresContables.GetRow(gridAuxiliaresContables.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                ControllerAuxiliaresContables vObjeto = new ControllerAuxiliaresContables();
                int result = vObjeto.EliminaAuxiliarContable(id);
                if (result == 1)
                {
                    cargarAuxiliares();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro eliminado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('El registro no puede ser eliminado, es posible que el auxiliar contable ya este asignado a un activo').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }

            }
        }

        protected void gridGruposContables_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "porcentaje_depreciacion")
                e.DisplayText = String.Format("{0:d}", e.Value) + " %";
            if (e.Column.FieldName == "vida_util")
                e.DisplayText = String.Format("{0:d}", e.Value) + " años"; 
        }
       
    }
}