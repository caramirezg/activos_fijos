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
    public partial class Marcas : System.Web.UI.Page
    {
        DataTable dtMarcas = new DataTable();
        DataTable dtModelos = new DataTable();
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
                   
                   cargaGrillaMarcas();
                   div_modelos.Visible = false;
                   div_marcas.Visible = true;
                   _armarMenu();
               }
               cargaGrillaMarcasPorSession();
               if (gridMarcas.FocusedRowIndex > -1)
               {
                   cargaGrillaModelosPorSession();
               }

           }
           else
           {
               Response.Redirect("ActivosPorResponsable.aspx");
           }
        }
        /// <summary>
        /// Carga datos desde la base de datos a la variable de session
        /// </summary>
        private void cargaGrillaMarcas()
        {
            ControllerMarcas vObjeto = new ControllerMarcas();
            ControllerHelper vHelper = new ControllerHelper();
            dtMarcas = vHelper.ToDataTable(vObjeto.DatosMarcas());
            Session.Add("dtMarcas", dtMarcas);
            cargaGrillaMarcasPorSession();
        }
        /// <summary>
        /// Carga datos a la grilla desde la variable de session
        /// </summary>
        private void cargaGrillaMarcasPorSession()
        {
            gridMarcas.DataSource = (DataTable)Session["dtMarcas"];
            gridMarcas.KeyFieldName = "ID";
            gridMarcas.DataBind();
        }
        /// <summary>
        /// Guarda un registro de marca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            ControllerMarcas vObjeto = new ControllerMarcas();

            if (string.IsNullOrEmpty(id.Text))
            {
                    vObjeto.CreaMarca(nombreMarca.Text);
                    cargaGrillaMarcas();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
               
            }
            else
            {
                vObjeto.EditaMarca(id.Text, nombreMarca.Text);
                cargaGrillaMarcas();
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline }); </script>");
            }
        }
        /// <summary>
        /// Muestra modal para editar marcas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditaMarca_Click(object sender, EventArgs e)
        {
            if (gridMarcas.FocusedRowIndex > -1)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarPopupMarcas", "modalEditarMarcas();", true);
                var fila = this.gridMarcas.GetRow(gridMarcas.FocusedRowIndex);

                id.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                nombreMarca.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
            }

        }
        /// <summary>
        /// Elimina un registro de marca de activo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminaMarca_Click(object sender, EventArgs e)
        {
            if (gridMarcas.FocusedRowIndex > -1)
            {
                var fila = this.gridMarcas.GetRow(gridMarcas.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                ControllerMarcas vObjeto = new ControllerMarcas();
                int result = vObjeto.EliminaMarca(id);
                if (result == 1)
                {
                    cargaGrillaMarcas();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#success').text('Registro eliminado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#danger').text('lo sentimos, ha ocurrido un error, es posible que la marca tenga asignado un activo').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }

            }
        }
        /// <summary>
        /// Muestra contenido de modelos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerModelos_Click(object sender, EventArgs e)
        {
            if (gridMarcas.FocusedRowIndex > -1)
            {
                var fila = this.gridMarcas.GetRow(gridMarcas.FocusedRowIndex);
                string nombre = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                cargaGrillaModelos();
                div_modelos.Visible = true;
                div_marcas.Visible = false;
                lblModelo.Text ="MARCA: "+ nombre;
               
            }
        }

        /// <summary>
        /// Carga datos desde la base de datos a la variable de session
        /// </summary>
        private void cargaGrillaModelos()
        {
            var fila = this.gridMarcas.GetRow(gridMarcas.FocusedRowIndex);
            string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
            ControllerModelos vObjeto = new ControllerModelos();
            ControllerHelper vHelper = new ControllerHelper();
            dtModelos = vHelper.ToDataTable(vObjeto.DatosModelos(id));
            Session.Add("dtModelos", dtModelos);
            cargaGrillaModelosPorSession();
        }
        /// <summary>
        /// Carga datos a la grilla desde la variable de session
        /// </summary>
        private void cargaGrillaModelosPorSession()
        {
            gridModelos.DataSource = (DataTable)Session["dtModelos"];
            gridModelos.KeyFieldName = "ID";
            gridModelos.DataBind();
        }
        /// <summary>
        /// Muestra modal para editar un registro de modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditarModelo_Click(object sender, EventArgs e)
        {
            if (gridModelos.FocusedRowIndex > -1)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarPopup", "modalEditarModelo();", true);
                var fila = this.gridModelos.GetRow(gridModelos.FocusedRowIndex);
                txtIdModelo.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();
                txtNombreModelo.Text = ((System.Data.DataRowView)(fila)).Row.ItemArray[1].ToString();
                txtMarcaPopUp.Text = lblModelo.Text;
            }

        }
        /// <summary>
        /// Guarda un registro de modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardarModelo_Click(object sender, EventArgs e)
        {
            ControllerModelos vObjeto = new ControllerModelos();

            var fila = this.gridMarcas.GetRow(gridMarcas.FocusedRowIndex);
            string idMarca = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

            if (string.IsNullOrEmpty(txtIdModelo.Text))
            {   
               

                vObjeto.CreaModelo(txtNombreModelo.Text, idMarca);
                cargaGrillaModelos();
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#successModelos').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
            }
            else
            {
                vObjeto.EditaModelo(txtIdModelo.Text, txtNombreModelo.Text);
                cargaGrillaModelos();
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#successModelos').text('Registro guardado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline }); </script>");
            }
        }
        /// <summary>
        /// Elimina un registro de modelo de una marca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminarModelo_Click(object sender, EventArgs e)
        {
            if (gridModelos.FocusedRowIndex > -1)
            {
                var fila = this.gridModelos.GetRow(gridModelos.FocusedRowIndex);
                string id = ((System.Data.DataRowView)(fila)).Row.ItemArray[0].ToString();

                ControllerModelos vObjeto = new ControllerModelos();
                int result = vObjeto.EliminaModelo(id);
                if (result == 1)
                {
                    //Response.Redirect("GruposAuxiliares.aspx");
                    cargaGrillaModelos();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#successModelos').text('Registro eliminado con éxito').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: $('#dangerModelos').text('lo sentimos, ha ocurrido un error, es posible que el modelo tenga asignado un activo').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });</script>");
                }

            }
        }
        /// <summary>
        /// Muestra las marcas de los activos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerMarcas_Click(object sender, EventArgs e)
        {
            div_modelos.Visible = false;
            div_marcas.Visible = true;
        }
      
    }
}