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
    public partial class RegistroActivosPorOrdenSalida : System.Web.UI.Page
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

                    if (Request.QueryString["correlativo"].Trim().Equals("0"))
                    {
                        lblTitulo.Text = "ORDEN DE SALIDA";
                    }
                    else
                    {
                        lblTitulo.Text = "ORDEN DE SALIDA N° "+ Request.QueryString["correlativo"].Trim();
                    }

                    txtIdMaestro.Text = Request.QueryString["codigoOrdenSalidaMaestro"].Trim();
                    txtFechaSolicitud.Text = Convert.ToDateTime(Request.QueryString["f_solicitud"]).ToString("dd/MM/yyyy");
                    txtFechaDesde.Text = Convert.ToDateTime(Request.QueryString["f_desde"].Trim()).ToString("dd/MM/yyyy");
                    string fecha_hasta = (Request.QueryString["f_hasta"].Trim());
                    if (!string.IsNullOrEmpty(fecha_hasta))
                        txtFechaHasta.Text = Convert.ToDateTime(Request.QueryString["f_hasta"].Trim()).ToString("dd/MM/yyyy");
                    txtMotivoSalida.Text = Request.QueryString["motivo"].Trim();
                    txtFkPersona.Text = Request.QueryString["fk_persona"].Trim();
                    txtDocumento.Text = Request.QueryString["documento"].Trim();
                    txtNombres.Text = Request.QueryString["nombres"].Trim();
                    txtApellidos.Text = Request.QueryString["apellidos"].Trim();
                    txtArea.Text = Request.QueryString["area"].Trim();
                    txtGerencia.Text = Request.QueryString["gerencia"].Trim();
                    //txtDocumentoAutorizacion.Text = Request.QueryString["documento_autorizacion"].Trim();

                    if (vPerfil.Equals("1"))
                    {
                        cargaGrillaTodosActivos();
                        txtEstadoGrillaActivos.Text = "todos";

                    }
                    else if (vPerfil.Equals("2"))
                    {
                        cargarGrillaActivosPorPersona();
                        txtEstadoGrillaActivos.Text = "por_persona";
                    }
                }

                cargaGrillaSolicitudActivosSalida();

                if (txtEstadoGrillaActivos.Text.Equals("por_persona"))
                {
                    cargarGrillaActivosPorPersona();
                }
                else
                {
                    cargaGrillaTodosActivos();
                }


                //Clasificadores estado 20 = SALIDA SOLICITADA
                if (Request.QueryString["fkc_estado_salida"].Trim() == "20")
                {
                    
                    //_action.Visible = true;
                }
                else
                {
                    _activos_existentes.Visible = false;
                    gridActivos.Columns["adicionar"].Visible = false;
                    gridActivosSalida   .Columns["quitar"].Visible = false;
                    _activos_solicitados.Style.Add("width", "100%");
                    _info_1.Visible = false;
                    _ver.Visible = false;

                    //_action.Visible = false;
                   
                }
        }
        /// <summary>
        /// carga todos los activos
        /// </summary>
        private void cargaGrillaTodosActivos()
        {
            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

           gridActivos.DataSource = vObjeto.DatosTodosActivos();
           gridActivos.KeyFieldName = "id";
           gridActivos.DataBind();
        }

        private void cargaGrillaSolicitudActivosSalida()
        {
            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

            gridActivosSalida.DataSource = vObjeto.DatosActivosSolicitados(txtIdMaestro.Text);
            gridActivosSalida.KeyFieldName = "id";
            gridActivosSalida.DataBind();
        }

        /// <summary>
        /// carga los activos de una persona
        /// </summary>
        private void cargarGrillaActivosPorPersona()
        {
            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

            gridActivos.DataSource = vObjeto.DatosActivosPorPersona(txtFkPersona.Text);
            gridActivos.KeyFieldName = "id";
            gridActivos.DataBind();
        }

        protected void btnImprimirSolicitud_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('reportes/ReporteSolicitudesSalidas.aspx?idMaestroSolicitudes=" + txtIdMaestro.Text + "','_blank');</script>");
        }

       

        protected void btnVerActivosPropios_Click(object sender, EventArgs e)
        {
            cargarGrillaActivosPorPersona();
            txtEstadoGrillaActivos.Text = "por_persona";
        }

        protected void btnVerTodosActivos_Click(object sender, EventArgs e)
        {
            cargaGrillaTodosActivos();
            txtEstadoGrillaActivos.Text = "todos";
        }

        protected void btnVerSolicitudes_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdenesSalidaIngresos.aspx");
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {

            Button btnSomeButton = sender as Button;
            int index = int.Parse(btnSomeButton.CommandArgument);
            string fk_activo = gridActivos.GetRowValues(index, "fk_activo").ToString();

            txtCodigoAdicionar.Text = fk_activo;

            GridViewDataColumn col = gridActivos.Columns[6] as GridViewDataColumn;
            Button btnAdd = gridActivos.FindRowCellTemplateControl(index,col,"btnAdicionar") as Button;
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btnAdd);


            //ClientScript.RegisterStartupScript(GetType(), "mostrarPopup", "modalAdicionar();", true);

            string message = "modalAdicionar();";
            ScriptManager.RegisterClientScriptBlock(btnAdd as Control, this.GetType(), "alert", message, true);

            //ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", message, true);
        
        }

        protected void btnquitar_Click(object sender, EventArgs e)
        {
            Button btnSomeButton = sender as Button;
            int index = int.Parse(btnSomeButton.CommandArgument);
            string id = gridActivosSalida.GetRowValues(index, "id").ToString();

            int vresult = 0;
            //var fila = this.gridActivosSalida.GetRow(gridActivosSalida.FocusedRowIndex);
            //string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

            vresult = vObjeto.EliminaDetalleSolicitud(id);
            if (vresult > 0)
            {
                cargaGrillaSolicitudActivosSalida();

                if (txtEstadoGrillaActivos.Text.Equals("por_persona"))
                {
                    cargarGrillaActivosPorPersona();
                }
                else
                {
                    cargaGrillaTodosActivos();
                }
            }
        }

        protected void btnGuardarAdicionar_Click(object sender, EventArgs e)
        {
            string fk_activo = txtCodigoAdicionar.Text;
            string observaciones = null;
            string textObservaciones = txtObservaciones.Text.Trim();
            if (string.IsNullOrEmpty(textObservaciones))
                observaciones = "SIN OBSERVACIONES";
            else
                observaciones = txtObservaciones.Text;

            string fk_ingreso_salida_maestro = txtIdMaestro.Text;
            string fkc_estado_salida = "20";///estado solicitado

            ControllerIngresosSalidas vObjeto = new ControllerIngresosSalidas();

            vObjeto.CreaIngresoSalidaDetalle(fk_ingreso_salida_maestro, fk_activo, fkc_estado_salida, observaciones);

            if (txtEstadoGrillaActivos.Text.Equals("por_persona"))
                cargarGrillaActivosPorPersona();
            else
                cargaGrillaTodosActivos();

            cargaGrillaSolicitudActivosSalida();

            string message = "modalHide();";
            ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", message, true);
    
            
        }
    }
}