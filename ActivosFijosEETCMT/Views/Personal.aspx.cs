using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using DevExpress.Web.ASPxGridView;
using System.Data;
using System.Text;


namespace ActivosFijosEETC.Views
{
    public partial class Personal : System.Web.UI.Page
    {
        ControllerHelper controllerHelper = new ControllerHelper();
        ControllerPersonal controllerPersonal = new ControllerPersonal();
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
                     cargaGerencias();
                 }

                 cargaGridPersonal();
             }
             else
             {
                 Response.Redirect("ActivosPorResponsable.aspx");
             }
        }
        /// <summary>
        /// Carga la lista de personal
        /// </summary>
        private void cargaGridPersonal()
        {
            ControllerPersonal vObjeto = new ControllerPersonal();
            gridPersonas.DataSource = controllerHelper.ToDataTable(vObjeto.ListPersonal());
            gridPersonas.KeyFieldName = "documento";
            gridPersonas.DataBind();
        }
        /// <summary>
        /// Muestra datos para editar una persona
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditaPersona_Click(object sender, EventArgs e)
        {
            if (gridPersonas.FocusedRowIndex > -1)
            {
                ddlGerencia.Items.Clear();
                ddlArea.Items.Clear();
                ClientScript.RegisterStartupScript(GetType(), "mostrarPopup", "modalEditar();", true);
                txtDocumento.ReadOnly = true;
                var fila = this.gridPersonas.GetRow(gridPersonas.FocusedRowIndex);
                txtDocumento.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                txtNombres.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[2].ToString();
                txtApellidos.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[3].ToString();
                cargaGerencias();

                ListItem li = ddlGerencia.Items.FindByText(((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString());
                if (li != null)
                {
                    ddlGerencia.SelectedIndex = ddlGerencia.Items.IndexOf(ddlGerencia.Items.FindByText(((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString()));
                    cargaAreas(li.Value);
                    ListItem la = ddlArea.Items.FindByText(((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString());
                    if (la != null)
                    {
                        ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText(((System.Data.DataRowView)(fila)).Row.ItemArray[4].ToString()));
                     
                    }
                    else
                    {
                        ddlArea.SelectedItem.Text = "";
                    }
                }
                else
                {
                    ddlGerencia.SelectedItem.Text = "";
                }

               
              
            }
        }
        /// <summary>
        /// Guarda un registro de persona
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarPersona_Click(object sender, EventArgs e)
        {
            ControllerPersonal vObjeto = new ControllerPersonal();

            var fila = this.gridPersonas.GetRow(gridPersonas.FocusedRowIndex);
            string documento = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

            string gerencia = ddlGerencia.SelectedItem.Text;
            string area = null;
            if (gerencia != "GERENCIA EJECUTIVA")
            {
                area = ddlArea.SelectedItem.Text;
            }
            else
            {
                area = "GERENCIA EJECUTIVA";
            }


            if (txtDocumento.ReadOnly == false)
            {
                int result = vObjeto.CreaPersona(txtDocumento.Text, txtNombres.Text, txtApellidos.Text, area, gerencia, "ACTIVO");
                if (result > 0)
                {
                    cargaGridPersonal();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else
            {
                int result = vObjeto.EditaPersona(txtDocumento.Text, txtNombres.Text, txtApellidos.Text, area, gerencia);
                if (result > 0)
                {
                    cargaGridPersonal();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline }); windows.location='Default.aspx';</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

            }
        }
        /// <summary>
        /// Carga los departamentos de una gerencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlGerencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idGerencia = ddlGerencia.SelectedItem.Value.ToString();
            cargaAreas(idGerencia);

        }
        /// <summary>
        /// Carga las areas de una gerencia
        /// </summary>
        /// <param name="idGerencia"></param>
        private void cargaAreas(string idGerencia) 
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlArea.DataSource = controllerHelper.ToDataTable(vObjeto.DatosArea(idGerencia));
            ddlArea.DataValueField = "id";
            ddlArea.DataTextField = "nombre";
            ddlArea.DataBind();
        }
        /// <summary>
        /// Carga los datos de gerencias
        /// </summary>
        /// <param name="idGerencia"></param>
        private void cargaGerencias()
        {
            ControllerAdministracion vObjeto = new ControllerAdministracion();
            ddlGerencia.DataSource = controllerHelper.ToDataTable(vObjeto.DatosGerencias());
            ddlGerencia.DataValueField = "id";
            ddlGerencia.DataTextField = "nombre";
            ddlGerencia.DataBind();
        }

        protected void gridPersonas_Init(object sender, EventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;
            foreach (GridViewColumn column in gridView.Columns)
            {
                if (column is GridViewDataColumn)
                {
                    ((GridViewDataColumn)column).Settings.AutoFilterCondition = AutoFilterCondition.Contains;
                }
            }
        }

        protected void btnSincronizarPersonal_Click(object sender, EventArgs e)
        {
            int result = controllerPersonal.SincronizaPersonal();
            if (result == 1)
            {
                cargaGridPersonal();
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('La sincronización se ha realizado exitosamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline }); windows.location='Default.aspx';</script>");
            }
            else if (result == 2)
            {
                cargaGridPersonal();
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('Se realizó la sincronización pero existe incoherencia con el sistema de recursos humanos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline }); windows.location='Default.aspx';</script>");
            }
        }


    }
}