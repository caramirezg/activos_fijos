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
    public partial class ReservasCorrelativos : System.Web.UI.Page
    {
        ControllerReservaCorrelativo controllerReservaCorrelativo = new ControllerReservaCorrelativo();
        ControllerCompras controllerCompras = new ControllerCompras();
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
            if (!Page.IsPostBack)
            {
                lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                txtGestion.Text = DateTime.Now.Year.ToString();
                _armarMenu();
            }
            cargarGridReservasCorrelativos();
        }


        private void cargarGridReservasCorrelativos()
        {
            gridReservas.DataSource = controllerReservaCorrelativo.getDataTableReservaCorrelativos();
            gridReservas.KeyFieldName = "id";
            gridReservas.DataBind();
        }

        protected void btnGenerarReserva_Click(object sender, EventArgs e)
        {

            int validaExisteReserva = controllerReservaCorrelativo.validaExisteReserva(txtCorrelativo.Text, txtGestion.Text);
            if (validaExisteReserva == 1)
            {
                int result = controllerReservaCorrelativo.CreaReserva(ddlModulo.SelectedItem.Value, txtCorrelativo.Text, txtGestion.Text);
                if (result > 0)
                {
                    cargarGridReservasCorrelativos();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Reserva realizada con exito').fadeIn(800).delay(4000).fadeOut(800);</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800);</script>");
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('No se puede reservar el correlativo, es posible que ya esté siendo utilizado').fadeIn(800).delay(4000).fadeOut(800);</script>");

        }

        protected void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            Button btnSomeButton = sender as Button;
            int index = int.Parse(btnSomeButton.CommandArgument);
            string id = gridReservas.GetRowValues(index, "id").ToString();

           

            int result = controllerReservaCorrelativo.EliminaReserva(gridReservas.GetRowValues(index, "id").ToString());
                if (result > 0)
                {
                    cargarGridReservasCorrelativos();
                    ClientScript.RegisterStartupScript(this.GetType(), "delete", "<script>javascript: $('#success').text('Reserva eliminada con exito').fadeIn(800).delay(4000).fadeOut(800);</script>");
                }
            
        }

        protected void gridReservas_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
            int value = (int)e.GetValue("vigente");
            if (value == 0)
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#B9B9B9");
                e.Row.ForeColor = Color.Gray;
                ASPxGridView grid = sender as ASPxGridView;
                grid.FindRowCellTemplateControl(e.VisibleIndex, grid.Columns[4] as GridViewDataColumn, "btnEliminarReserva").Visible = false;
            }
        }

        protected void gridReservas_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs e)
        {
         
        }

        protected void gridReservas_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "vigente")
            {
                if (e.CellValue.Equals(1))
                {
                    e.Cell.Text = "VIGENTE";
                }else
                {
                    e.Cell.Text = "NO VIGENTE";
                }
            }
        }
    }
}