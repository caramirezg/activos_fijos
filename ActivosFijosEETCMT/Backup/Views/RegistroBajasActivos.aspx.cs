using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivosFijosEETC.Controllers;
using System.Data;
using System.Text;

namespace ActivosFijosEETC.Views
{
    public partial class RegistroBajasActivos : System.Web.UI.Page
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
                    txtIdMaestro.Text = Request.QueryString["id_baja_maestro"].Trim();
                    txtFechaBaja.Text = Convert.ToDateTime(Request.QueryString["f_baja"]).ToString("dd/MM/yyyy");
                    txtMotivoBaja.Text = Request.QueryString["motivo_baja"].Trim();
                    txtDocumentoRespaldo.Text = Request.QueryString["documento_respaldo"].Trim();


                    //Clasificadores estado 24 = PRE BAJA
                    if (Request.QueryString["fkc_estado_proceso"].Trim() == "24")
                    {
                        _action.Visible = true;
                    }
                    else
                    {
                        _action.Visible = false;
                        _activos_existentes.Visible = false;
                        _activos_baja.Style.Add("width", "100%");
                        _info_1.Visible = false;
                    }
                }

                cargarGrillaActivos();
                cargarGrillaActivosBajas();

            }
            else
            {
                Response.Redirect("ActivosPorResponsable.aspx");
            }
        }

        private void cargarGrillaActivos()
        {
            ControllerBajas vObjeto = new ControllerBajas();

            gridActivos.DataSource = vObjeto.DatosActivos(txtIdMaestro.Text);
            gridActivos.KeyFieldName = "id";
            gridActivos.DataBind();
        }

        private void cargarGrillaActivosBajas()
        {
            ControllerBajas vObjeto = new ControllerBajas();

            gridActivosBajas.DataSource = vObjeto.DatosActivosBajas(txtIdMaestro.Text);
            gridActivosBajas.KeyFieldName = "id";
            gridActivosBajas.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (gridActivos.FocusedRowIndex > -1)
            {
                var fila = this.gridActivos.GetRow(gridActivos.FocusedRowIndex);
                string fk_activo = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                string f_ult_act_dep = ((System.Data.DataRowView)(fila)).Row.ItemArray[5].ToString();
                string fecha_actualizacion = Convert.ToDateTime(f_ult_act_dep).ToString("dd/MM/yyyy");

                if (fecha_actualizacion.Trim() == txtFechaBaja.Text.Trim())
                {
                    string observaciones = null;
                    string textObservaciones = txtObservaciones.Text.Trim();
                    if (string.IsNullOrEmpty(textObservaciones))
                        observaciones = "SIN OBSERVACIONES";
                    else
                        observaciones = txtObservaciones.Text;

                    string fk_baja_maestro = txtIdMaestro.Text;

                    ControllerBajas vObjeto = new ControllerBajas();

                    vObjeto.CreaBajaDetalle(fk_baja_maestro, fk_activo, observaciones);
                    cargarGrillaActivos();
                    cargarGrillaActivosBajas();

                    //string message = "$('#success').text('El activo se dio de baja satisfactoriamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('El activo se dio de baja satisfactoriamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

                }
                else
                {
                    //string message = "$('#warning').text('La fecha de baja debe ser la misma que la fecha de actualización').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });";
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#warning').text('La fecha de baja debe ser la misma que la fecha de actualización').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }

            }
        }

        protected void btnquitar_Click(object sender, EventArgs e)
        {
            if (gridActivosBajas.FocusedRowIndex > -1)
            {

                int vresult = 0;
                var fila = this.gridActivosBajas.GetRow(gridActivosBajas.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                ControllerBajas vObjeto = new ControllerBajas();

                vresult = vObjeto.EliminaBajaDetalle(id);
                if (vresult > 0)
                {
                    cargarGrillaActivos();
                    cargarGrillaActivosBajas();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('La baja del activo fue revertida correctamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('Lo sentimos hubo un error').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                
                }
            }
        }

        protected void btnImprimirBajas_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('reportes/ReporteBajas.aspx?idMaestroBaja=" + txtIdMaestro.Text + "','_blank');</script>");
        }

        protected void btnVerBajas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bajas.aspx");
        }

       
    }
}