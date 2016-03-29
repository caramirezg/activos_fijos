using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Data;
using System.Text;
using DevExpress.Web.ASPxGridView;

namespace ActivosFijosEETC.Views
{
    public partial class RegistroActivosPorIngreso : System.Web.UI.Page
    {


        protected void Page_Init(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null) { Response.Redirect("~/Views/login.aspx"); }

            string vPerfil = HttpContext.Current.Session["perfil"].ToString();
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

                     if (Request.QueryString["correlativo"].Trim().Equals("0"))
                     {
                         lblTitulo.Text = "INGRESO";
                     }
                     else
                     {
                         lblTitulo.Text = "INGRESO N° " + Request.QueryString["correlativo"].Trim();
                     }


                     lblUsuario.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                     lblUsuario2.Text = HttpContext.Current.Session["nombre"].ToString() + " " + HttpContext.Current.Session["apellido"].ToString();
                     _armarMenu();
                     txt_id_maestro_ingreso.Text = Request.QueryString["id_maestro_ingresos"].Trim();
                     txt_id_maestro_salida.Text = Request.QueryString["id_maestro_salidas"].Trim();
                     txtFechaIngreso.Text = Convert.ToDateTime(Request.QueryString["fecha_ingreso"]).ToString("dd/MM/yyyy");
                     txtDocumento.Text = Request.QueryString["documento"].Trim();
                     txtNombres.Text = Request.QueryString["nombres"].Trim();
                     txtApellidos.Text = Request.QueryString["apellidos"].Trim();
                     txtArea.Text = Request.QueryString["area"].Trim();
                     txtGerencia.Text = Request.QueryString["gerencia"].Trim();
                     string fkc_estado_ingreso = Request.QueryString["fkc_estado_ingreso"].Trim();
                 }

                 cargaGrillaActivosPrestados();
                 cargaGrillaActivosIngresados();

                 //Clasificadores estado 22 = ESTADO PRE INGRESADO
                 if (Request.QueryString["fkc_estado_ingreso"].Trim() == "22")
                 {
                     //_action.Visible = true;
                 }
                 else
                 {
                     //_action.Visible = false;
                     gridActivosPrestados.Columns["adicionar"].Visible = false;
                     gridActivosIngresados.Columns["quitar"].Visible = false;
                     _activos_prestados.Visible = false;
                     _activos_devueltos.Style.Add("width", "100%");

                     //_observaciones.Visible = false;
                 }
        }

        private void cargaGrillaActivosPrestados()
        {
            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

            gridActivosPrestados.DataSource = vObjeto.DatosActivosPrestados(txt_id_maestro_salida.Text);
            gridActivosPrestados.KeyFieldName = "id";
            gridActivosPrestados.DataBind();
        }


        private void cargaGrillaActivosIngresados()
        {
            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

            gridActivosIngresados.DataSource = vObjeto.DatosActivosDevueltos(txt_id_maestro_ingreso.Text);
            gridActivosIngresados.KeyFieldName = "id";
            gridActivosIngresados.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Button btnSomeButton = sender as Button;
            int index = int.Parse(btnSomeButton.CommandArgument);
            string id_detalle_salida = gridActivosPrestados.GetRowValues(index, "id").ToString();

            txtCodigoAdicionar.Text = id_detalle_salida;

            GridViewDataColumn col = gridActivosPrestados.Columns[6] as GridViewDataColumn;
            Button btnAdd = gridActivosPrestados.FindRowCellTemplateControl(index, col, "btnAdicionar") as Button;
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btnAdd);

            string message = "modalAdicionar();";
            ScriptManager.RegisterClientScriptBlock(btnAdd as Control, this.GetType(), "alert", message, true);




              
            
        }

        protected void btnquitar_Click(object sender, EventArgs e)
        {
            if (gridActivosIngresados.FocusedRowIndex > -1)
            {
                var fila = this.gridActivosIngresados.GetRow(gridActivosIngresados.FocusedRowIndex);
                string id_detalle_salida = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();
                vObjeto.QuitarDevolucionActivoPrestado(id_detalle_salida);

                cargaGrillaActivosIngresados();
                cargaGrillaActivosPrestados();
            }
        }

        protected void btnVerIngresos_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresosActivos.aspx");
        }

        protected void btnImprimirIngreso_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('reportes/ReporteDevolucionActivos.aspx?idMaestroIngresos=" + txt_id_maestro_ingreso.Text + "','_blank');</script>");
            
        }

        protected void btnGuardarAdicionar_Click(object sender, EventArgs e)
        {
            string id_detalle_salida = txtCodigoAdicionar.Text;

            string observaciones = null;
            string textObservaciones = txtObservaciones.Text.Trim();
            if (string.IsNullOrEmpty(textObservaciones))
                observaciones = "SIN OBSERVACIONES";
            else
                observaciones = txtObservaciones.Text;
            var fila = this.gridActivosPrestados.GetRow(gridActivosPrestados.FocusedRowIndex);
           
            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();
            vObjeto.DevuelveActivoPrestado(txt_id_maestro_ingreso.Text, id_detalle_salida, observaciones);

            cargaGrillaActivosIngresados();
            cargaGrillaActivosPrestados();

            string message = "modalHide();";
            ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
        }
    }
}