using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Data;
using System.Text;
using System.Drawing;
using DevExpress.Web.ASPxGridView;

namespace ActivosFijosEETC.Views
{
    public partial class TasasCambio : System.Web.UI.Page
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
            if (!vPerfil.Equals("2"))//persona
            {

                if (!Page.IsPostBack)
                {
                    lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                    _armarMenu();
                }

                cargaGrilla();
            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }
        }
        /// <summary>
        /// Carga la grilla de tasas de cambio
        /// </summary>
        private void cargaGrilla()
        {
            ControllerTasasCambio vObjeto = new ControllerTasasCambio();
            ControllerHelper vHelper = new ControllerHelper();
            gridTasasCambio.DataSource = vHelper.ToDataTable(vObjeto.DatosTasaDolarUfv());
            gridTasasCambio.KeyFieldName = "id";
            gridTasasCambio.DataBind();
        }
        /// <summary>
        /// Guarda un registro de tasa de cambio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarTasaCambio_Click(object sender, EventArgs e)
        {
            ControllerTasasCambio vObjeto = new ControllerTasasCambio();
            string dateTasaCambio = Request.Form["dateFechaTasaCambio"];

            int resultValidacion = vObjeto.validaFechaRegistrada(dateTasaCambio);
            if (resultValidacion == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('Ya existe un registro de tasa de cambio en la fecha " + dateTasaCambio + "').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else
            {
                int result = vObjeto.CreaTasaCambio(dateTasaCambio, txtTasaUfv.Text, txtTasaSus.Text);
                if (result > 0)
                {
                    cargaGrilla();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
        }
        /// <summary>
        /// Elimina registro de tasa de cambio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridTasasCambio.FocusedRowIndex > -1)
            {
                var fila = this.gridTasasCambio.GetRow(gridTasasCambio.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                ControllerTasasCambio vObjeto = new ControllerTasasCambio();
                int result = vObjeto.EliminaTasaCambio(id);
                if (result == 1)
                {
                    cargaGrilla();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro eliminado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('lo sentimos, ha ocurrido un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
            }
        }

        protected void gridTasasCambio_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            string value = (string)e.GetValue("estado");
            if (value == "CERRADO")
            {
                e.Row.BackColor = ColorTranslator.FromHtml("#B9B9B9");
                e.Row.ForeColor = Color.Gray;

                ASPxGridView grid = sender as ASPxGridView;
                grid.FindRowCellTemplateControl(e.VisibleIndex, grid.Columns["editar"] as GridViewDataColumn, "btnEditar").Visible = false;
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btnSomeButton = sender as Button;
            int index = int.Parse(btnSomeButton.CommandArgument);
            string id = gridTasasCambio.GetRowValues(index, "id").ToString();
            txtEditaFecha.Text = DateTime.Parse(gridTasasCambio.GetRowValues(index, "f_tasa").ToString()).ToString("dd/MM/yyyy");
            txtEditaTasaUfv.Text = gridTasasCambio.GetRowValues(index, "tasa_ufv").ToString();
            txtEditaTasaSus.Text = gridTasasCambio.GetRowValues(index, "tasa_sus").ToString();

            txtEditaId.Text = id;

            GridViewDataColumn col = gridTasasCambio.Columns[5] as GridViewDataColumn;
            Button btnAdd = gridTasasCambio.FindRowCellTemplateControl(index, col, "btnEditar") as Button;
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btnAdd);

            string message = "modalEditar();";
            ScriptManager.RegisterClientScriptBlock(btnAdd as Control, this.GetType(), "alert", message, true);
        }

        protected void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            string id = txtEditaId.Text;

            ControllerTasasCambio vObjeto = new ControllerTasasCambio();
            int vResult = vObjeto.EditaTasaCambio(id, txtEditaFecha.Text, txtEditaTasaUfv.Text.Replace(".", ","), txtEditaTasaSus.Text.Replace(".", ","));

            string message = "modalHide();";
            ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
            cargaGrilla();

            message = "<script>javascript: $('#success').text('Tasas modificadas con exito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>";
            ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);

            message = "cargarGrafico();";
            ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "grafico", message, true);
        }

       
    }
}