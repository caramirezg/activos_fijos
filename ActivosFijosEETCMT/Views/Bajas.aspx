<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bajas.aspx.cs" Inherits="ActivosFijosEETC.Views.Bajas" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="bootstrap/datepicker/css/datepicker.css" rel="stylesheet" type="text/css" />
    <!-- bootstrap 3.0.2 -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <link href="bootstrap/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons -->
    <link href="bootstrap/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <!-- Morris chart -->
    <link href="bootstrap/css/morris/morris.css" rel="stylesheet" type="text/css" />
    <!-- jvectormap -->
    <link href="bootstrap/css/jvectormap/jquery-jvectormap-1.2.2.css" rel="stylesheet"
        type="text/css" />
    <!-- Date Picker -->
    <link href="bootstrap/css/datepicker/datepicker3.css" rel="stylesheet" type="text/css" />
    <!-- Daterange picker -->
    <link href="bootstrap/css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet"
        type="text/css" />
    <!-- bootstrap wysihtml5 - text editor -->
    <link href="bootstrap/css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet"
        type="text/css" />
    <!-- Theme style -->
    <link href="bootstrap/css/AdminLTE.css" rel="stylesheet" type="text/css" />
    <!-- DATA TABLES -->
    <link href="bootstrap/css/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- jQuery 2.0.2 -->
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <!-- jQuery UI 1.10.3 -->
    <script src="bootstrap/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <!-- Sparkline -->
    <script src="bootstrap/js/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- daterangepicker -->
    <script src="bootstrap/js/plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <!-- datepicker -->
    <script src="bootstrap/js/plugins/datepicker/bootstrap-datepicker.js" type="text/javascript"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="bootstrap/js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"
        type="text/javascript"></script>
    <!-- AdminLTE App -->
    <script src="bootstrap/js/AdminLTE/app.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/datatables/jquery.dataTables.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/datatables/dataTables.bootstrap.js" type="text/javascript"></script>
</head>
<body class="skin-blue" onkeydown="return (event.keyCode != 116)">
              <script>
                  function CierraSesion() {
                      $.ajax({

                          type: "POST",
                          url: "../Controllers/ControllerLogin.asmx/CierraSesion",
                          data: "{}",
                          contentType: "application/json; chartset:utf-8",
                          dataType: "json",
                          async: false,
                          success: function (result) {
                              if (result.d) {
                                  window.location = 'Login.aspx';
                              }
                          },
                          error: function (XMLHttpRequest, textStatus, errorThrown) {
                              alert(textStatus + ": " + XMLHttpRequest.responseText);
                          },
                          async: true
                      });
                  }
   </script>
     <!-- header logo: style can be found in header.less -->
    <header class="header">
        <a href="Default.aspx" class="logo">
            <!-- Add the class icon to your logo image or logo icon to add the margining -->
            <p>
                <strong>Sistema de Activos Fijos</strong></p>
        </a>
        <!-- Header Navbar: style can be found in header.less -->
        <nav class="navbar navbar-static-top" role="navigation">
            <!-- Sidebar toggle button-->
            <a href="#" class="navbar-btn sidebar-toggle" data-toggle="offcanvas" role="button">
                <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                    class="icon-bar"></span><span class="icon-bar"></span></a>
            <div class="navbar-right">
                <ul class="nav navbar-nav">
                    <!-- User Account: style can be found in dropdown.less -->
                    <li class="dropdown user user-menu"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="glyphicon glyphicon-user"></i><span>
                            <asp:Label ID="lblUsuario2" Text="text" runat="server" />
                            <i class="caret"></i></span></a>
                        <ul class="dropdown-menu">
                            <!-- Menu Footer-->
                            <li class="user-footer">
                                <div class="pull-left">
                                    <a href="Perfil.aspx" class="btn btn-default btn-flat">Perfil</a>
                                </div>
                                <div class="pull-right">
                                     <a href="#" class="btn btn-primary btn-flat" onclick="CierraSesion();">Sign out</a>
                                </div>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
    </header>
    <div class="wrapper row-offcanvas row-offcanvas-left">
        <!-- Left side column. contains the logo and sidebar -->
        <aside class="left-side sidebar-offcanvas">
            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">
                <!-- Sidebar user panel -->
                <div class="user-panel">
                    <img src="img/logo.png" class="img-thumbnail" alt="User Image" />
                    <div class="pull-left image">
                    </div>
                    <div class="pull-left info">
                        <p>
                            <asp:Label ID="lblUsuario" Text="text" runat="server" /></p>
                        <a href="#"><i class="fa fa-circle text-success"></i>Online </a>
                    </div>
                </div>
                <!-- /.search form -->
                <!-- sidebar menu: : style can be found in sidebar.less -->
               <ul id="_menu" class="sidebar-menu" runat="server">
                </ul>
            </section>
            <!-- /.sidebar -->
        </aside>
        <!-- Right side column. Contains the navbar and content of the page -->
        <aside class="right-side">
            <section class="content-header">
                <h1>
                    <i class="fa fa-trash-o"></i> Bajas<small></small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li class="active">Bajas</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <div class="modal fade" id="deleteConfirmModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel"
                aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="deleteLabel">
                                Notificacion de eliminacion</h4>
                        </div>
                        <div class="modal-body">
                            <p>
                                <strong>Esta seguro que desea eliminar la baja?</strong></p>
                            <p>
                                <small>Las bajas que se encuentren en estado asignado no podran ser eliminadas</small>
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Cancelar</button>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"
                                OnClick="btnEliminarBaja_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <section class="content">
                <div class="row" id="div_ListaBajas" runat="server">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Bajas realizadas</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <div id="divMaestroDanger" class="alert alert-danger" role="alert" style="display: none">
                                    <strong>Error!</strong>
                                </div>
                                <div id="divMaestroSuccess" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Correcto!</strong>
                                </div>
                                <div id="divMaestroWarning" class="alert alert-warning" role="alert" style="display: none">
                                    <strong>Atencion!</strong>
                                </div>
                            </div>
                            <div class="box-body">
                                <asp:LinkButton ID="btnNuevaBaja" runat="server" Text="<span class='fa fa-plus'></span> Nueva baja"
                                    CssClass="btn btn-primary" OnClick="btnNuevaBaja_Click"></asp:LinkButton>
                                <asp:LinkButton ID="btnVerDetalleBaja" runat="server" Text="<span class='fa fa-file-text-o'></span> Ver detalle de baja"
                                    CssClass="btn btn-success" OnClick="btnVerDetalleBaja_Click"></asp:LinkButton>
                                <asp:LinkButton ID="btnAprobarBaja" runat="server" Text="<span class='fa fa-thumbs-o-up'></span> Aprobar baja"
                                    CssClass="btn btn-warning" OnClientClick="return ConfirmaAprobarBaja();"></asp:LinkButton>
                                <asp:LinkButton ID="btnEliminarBaja" runat="server" Text="<span class='fa fa-trash-o'></span> Eliminar baja"
                                    CssClass="btn btn-danger" OnClientClick="return ConfirmaElimina();"></asp:LinkButton>
                            </div>
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <div>
                                        <dx:ASPxGridView ID="gridBajas" runat="server" AutoGenerateColumns="False" Width="100%"
                                            Theme="Aqua" Caption="Bajas" Font-Size="Small" 
                                            onhtmlrowprepared="gridBajas_HtmlRowPrepared">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="id" VisibleIndex="0" FieldName="id" Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Baja" VisibleIndex="2" FieldName="f_baja"
                                                    Width="20%">
                                                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Correlativo" FieldName="correlativo" VisibleIndex="1"
                                                    Width="20%">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="fkc_estado_proceso" VisibleIndex="16" Visible="False"
                                                    Width="50px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Estado Proceso" FieldName="estado_proceso" VisibleIndex="18"
                                                    Width="20%">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Motivo Baja" FieldName="motivo_baja" VisibleIndex="3"
                                                    Width="40%">
                                                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Cantidad Bajas" FieldName="count_bajas" 
                                                    VisibleIndex="14">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Documento Respaldo" 
                                                    FieldName="documento_respaldo" VisibleIndex="12">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                            <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowHorizontalScrollBar="True" />
                                            <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control"></SettingsBehavior>
                                            <Settings ShowFilterRow="True" ShowFilterRowMenu="True"></Settings>
                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                        </dx:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-body">
                    <div id="dangerSolicitudes" class="alert alert-danger" role="alert" style="display: none">
                        <strong>Error!orrecto!</strong>
                    </div>
                    <div id="warningSolicitudes" class="alert alert-warning" role="alert" style="display: none">
                        <strong>Atencion!</strong>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="row" id="div_RegistroMaestroBaja" runat="server">
                        <div class="col-md-12">
                            <div id="div1" class="box box-primary" runat="server">
                                <div class="box-header">
                                    <h3 class="box-title">
                                        Registro de Baja</h3>
                                </div>

                                <div class="box-body">
                                    <div id="div_registro_danger" class="alert alert-danger" role="alert" style="display: none">
                                        <strong>Error!</strong>
                                    </div>
                                    <div id="div_registro_success" class="alert alert-success" role="alert" style="display: none">
                                        <strong>Correcto!</strong>
                                    </div>
                                    <div id="div_registro_warning" class="alert alert-warning" role="alert" style="display: none">
                                        <strong>Atencion!</strong>
                                    </div>
                                </div>

                                <!-- /.box-header -->
                                <div class="box-body">
                                    <asp:LinkButton ID="btnGuardarBaja" runat="server" Text="<span class='fa fa-save'></span> Guardar y Continuar"
                                        CssClass="btn btn-primary" OnClientClick="return Validar();" OnClick="btnGuardarBaja_Click"></asp:LinkButton>
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default"
                                        OnClick="btnCancelar_Click" />
                                </div>
                                <!-- /.box-body -->
                               <div class="box-body">
                                    <div class="alert alert-info alert-dismissable">
                                        <i class="fa fa-info"></i>
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                                            &times;</button>
                                        <b>Información!</b> El motivo de baja heredará en todos los activos que vaya a dar
                                        de baja para el documento generado.
                                    </div>
                                    </div>
                                     <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-6" id="Div3" runat="server">
                                            <label for="nombre">
                                                Fecha de baja <font color="red">*</font>
                                            </label>
                                            <input id="dateFechaBaja" type="text" name="dateFechaBaja" readonly="readonly" value=""
                                                class="form-control" placeholder="ejemplo: 01/01/2015" />
                                        </div>
                                        <div class="col-md-6">
                                            <label for="nombre">
                                                Motivo de baja
                                            </label>
                                            <asp:DropDownList ID="ddlMotivosbaja" CssClass="form-control" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Text="Seleccione un item" Value="-1" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                    <div class="col-md-12">
                                            <label for="nombre">
                                                Documento de respaldo
                                            </label>
                                            <asp:TextBox ID="txtDocumentoRespaldo" runat="server" CssClass="form-control" placeholder="ejemplo: Documento de respaldo Nro 001"></asp:TextBox>
                                           
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="AprobarConfirmModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="H2">
                                    Notificacion de Aprobacion</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <strong>Esta seguro que desea aprobar la baja?</strong></p>
                                <p>
                                    <small>Una vez aprobada la baja no podra realizar modificaciones ni eliminarla</small>
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                                <asp:Button ID="btnAprobarSalida" runat="server" Text="Aprobar" CssClass="btn btn-danger"
                                    OnClick="btnAprobarBaja_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            </form>
        </aside>
    </div>
    <!-- ./wrapper -->
    <script type="text/javascript">

        $(document).ready(function () {

            $(document).bind("contextmenu", function (e) {
                return false;
            });

            $('#dateFechaBaja').datepicker({
                format: 'dd-mm-yyyy',
                clearBtn: true,
                language: "es",
                calendarWeeks: true,
                autoclose: true,
                todayHighlight: true
            });

        });


        function ConfirmaElimina() {
            $('#deleteConfirmModal').modal('show');
            return false;
        }

        function ConfirmaAprobarBaja() {
            $('#AprobarConfirmModal').modal('show');
            return false;
        }

    </script>
</body>
</html>
