<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdenesSalidaIngresos.aspx.cs"
    Inherits="ActivosFijosEETC.Views.OrdenesSalidaIngresos" %>

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
    <%--   <script src="js/jquery.min.js"           type="text/javascript"></script>--%>
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
     <script src="js/OrdenesSalida.js" type="text/javascript"></script>
</head>
<body class="skin-blue" onkeydown="return (event.keyCode != 116)">
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
                                    <a href="Login.aspx" class="btn btn-primary btn-flat">Sign out</a>
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
                    <i class="fa fa-sign-out"></i>Ordenes de salida<small></small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Control de activos</a></li>
                    <li class="active">Ordenes de salida</li>
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
                                <strong>Esta seguro que desea eliminar la orden de salida?</strong></p>
                            <p>
                                <small>Las ordenes de salida que se encuentren en estado aprobado no podran ser eliminadas</small>
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Cancelar</button>
                            <%--<button type="button" class="btn btn-danger" id="deleteConfirm">Delete Notification</button>--%>
                             <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                CssClass="btn btn-danger" onclick="btnEliminar_Click"
                                 />
                        </div>
                    </div>
                </div>
            </div>
           
            <section class="content">
                <div class="row" id="div_Listacompras" runat="server">
                    <div class="col-md-12">
                        <div id="div_ListaSolicitudes" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Salidas Realizadas</h3>
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
                                <asp:LinkButton ID="btnNuevaSolicitud" runat="server" Text="<span class='fa fa-plus'></span> Nueva salida"
                                    CssClass="btn btn-primary" onclick="btnNuevaSolicitud_Click" ></asp:LinkButton>
                                <asp:LinkButton ID="btnVerDetalleSolicitud" runat="server" Text="<span class='fa fa-file-text-o'></span> Ver detalle de salida"
                                    CssClass="btn btn-success" onclick="btnVerDetalleSolicitud_Click"></asp:LinkButton>
                                <asp:LinkButton ID="btnAprobarSolicitud" runat="server" Text="<span class='fa fa-thumbs-o-up'></span> Aprobar salida"
                                    CssClass="btn btn-warning" OnClientClick="return ConfirmaAprobarAsignacion();"></asp:LinkButton>
                                       <asp:LinkButton ID="btnEditarMaestro" runat="server" Text="&lt;span class='fa fa-pencil'&gt;&lt;/span&gt; Editar salida"
                                    CssClass="btn btn-default" onclick="btnEditarMaestro_Click"></asp:LinkButton>
                                <asp:LinkButton ID="btnEliminarSolicitud" runat="server" Text="<span class='fa fa-trash-o'></span> Eliminar salida"
                                    CssClass="btn btn-danger" OnClientClick="return ConfirmaElimina();"></asp:LinkButton>
                            </div>
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <div>
                                        <dx:ASPxGridView ID="gridSolicitudes" runat="server" AutoGenerateColumns="False"
                                            Width="100%" Theme="Aqua" Caption="Salidas" Font-Size="Small" 
                                            onhtmlrowprepared="gridSolicitudes_HtmlRowPrepared">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="id" VisibleIndex="0" FieldName="id" 
                                                    Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Solicitud" VisibleIndex="2" FieldName="f_solicitud"
                                                    Width="150px">
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
                                                <dx:GridViewDataTextColumn Caption="Documento" VisibleIndex="8" FieldName="documento"
                                                    Width="150px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Hasta" VisibleIndex="4" FieldName="f_hasta"
                                                    Width="150px">
                                                     <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Correlativo" FieldName="correlativo" VisibleIndex="1"
                                                    Width="100px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="fkc_estado_salida" VisibleIndex="14"
                                                    Visible="False" Width="50px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Nombres" FieldName="nombres" VisibleIndex="9"
                                                    Width="200px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Apellidos" FieldName="apellidos" VisibleIndex="10"
                                                    Width="200px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="fk_persona" Visible="False"
                                                    VisibleIndex="7" Width="50px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Motivo" FieldName="motivo" VisibleIndex="5"
                                                    Width="300px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Estado Salida" FieldName="estado_salida" VisibleIndex="16"
                                                    Width="150px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Desde" FieldName="f_desde" 
                                                    VisibleIndex="3" Width="150px">
                                                     <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Area" FieldName="area" VisibleIndex="11" 
                                                    Width="200px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Gerencia" FieldName="gerencia" 
                                                    VisibleIndex="12" Width="200px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Documento Autorización" 
                                                    FieldName="documento_autorizacion" VisibleIndex="6" Width="200px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                            <Settings ShowFilterRow="True" ShowFilterRowMenu="True" 
                                                ShowHorizontalScrollBar="True" />

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
                        <div class="row" id="div_RegistroMaestroSolicitud" runat="server">
                            <div class="col-md-12">
                                <div id="div1" class="box box-primary" runat="server">
                                    <div class="box-header">
                                        <h3 class="box-title">
                                            Registro de salida</h3>
                                    </div>
                                     
                                     <div class="box-body">
                                <div id="divDetalleDanger" class="alert alert-danger" role="alert" style="display: none">
                                    <strong>Error!</strong>
                                </div>
                                <div id="divDetalleSuccess" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Correcto!</strong>
                                </div>
                                <div id="divDetalleWarning" class="alert alert-warning" role="alert" style="display: none">
                                    <strong>Atencion!</strong>
                                </div>
                            </div>

                                    <!-- /.box-header -->
                                    <div class="box-body">
                                        <asp:LinkButton ID="btnGuardarAsignacion" runat="server" Text="<span class='fa fa-save'></span> Guardar y Continuar"
                                            CssClass="btn btn-primary"  OnClientClick="return Validar();" 
                                            onclick="btnGuardarAsignacion_Click"></asp:LinkButton>
                                        <%-- <asp:Button ID="btnGuardarAsignacion" runat="server" Text="Guardar y Continuar" CssClass="btn btn-primary"
                                            OnClick="btnGuardarAsignacion_Click" OnClientClick="return Validar();" />--%>
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                            CssClass="btn btn-default" onclick="btnCancelar_Click"
                                            />
                                    </div>
                                    <!-- /.box-body -->
                                   
                                   <div class="box-body">
                                     <div class="alert alert-info alert-dismissable">
                                        <i class="fa fa-info"></i>
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                        <b>Información!</b> Para definir el tiempo de solicitud de salida de los activos de forma indefinida deje en blanco la casilla de fecha hasta.
                                    </div>
                                    </div>
                                     <div class="box-body">
                                        <div class="row">
                                            <div class="col-xs-4">
                                                <label for="nombre">
                                                    Fecha de solicitud <font color="red">*</font>
                                                </label>
                                               
                                                    <asp:TextBox ID="txtFechaSolicitud" class="form-control" ReadOnly=true
                                                        runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-4" id="Div3" runat="server">
                                                <label for="nombre">
                                                    Fecha de desde <font color="red">*</font>
                                                </label>
                                                <input id="dateFechaDesde" type="text" name="dateFechaDesde" readonly="readonly" value=""
                                                    class="form-control" placeholder="ejemplo: 01/01/2014" />
                                            </div>
                                            <div class="col-xs-4">
                                                <label for="nombre">
                                                    Fecha de hasta
                                                </label>
                                                <input id="dateFechaHasta" type="text" name="dateFechaHasta" readonly="readonly" value=""
                                                    class="form-control" placeholder="ejemplo: 01/01/2014" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <label for="nombre">
                                                    Motivo de la salida <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtMotivoSalida" runat="server" CssClass="form-control" placeholder="ejemplo: Por trabajo fuera de la oficina"></asp:TextBox>
                                            </div>

                                           <%-- <div class="col-md-6">
                                                <label for="nombre">
                                                    Documento de autorización <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtDocumentoAutorizacion" runat="server" CssClass="form-control" placeholder="ejemplo: Nota Interna 0001/2015"></asp:TextBox>
                                            </div>--%>
                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="row" id="div_ResponsableSolicitud" runat="server">
                                <div class="col-md-12">
                                    <div id="div2" class="box box-primary" runat="server">
                                        <div class="box-header">
                                            <h3 class="box-title">
                                                Responsable que realiza la solicitud <font color="red">*</font>
                                            </h3>
                                        </div>
                                        <div class="box-body">
                                        </div>
                                        <div class="box">
                                            <div class="box-body table-responsive">
                                                <dx:ASPxGridView ID="gridPersonal" runat="server" AutoGenerateColumns="False" Caption="Personal"
                                                    EnableTheming="True" Theme="Aqua" Width="100%" KeyFieldName="id">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn VisibleIndex="0">
                                                            <ClearFilterButton Visible="True">
                                                            </ClearFilterButton>
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn Caption="Documento" FieldName="documento" VisibleIndex="2">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Nombres" FieldName="nombres" VisibleIndex="3">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Apellidos" FieldName="apellidos" VisibleIndex="4">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Gerencia" FieldName="gerencia" VisibleIndex="5">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Area" FieldName="area" VisibleIndex="6">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="1" Visible="False">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <SettingsBehavior AllowFocusedRow="True" />

<SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>

                                                    <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                                </dx:ASPxGridView>
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
                                        <strong>Esta seguro que desea aprobar la asignación?</strong></p>
                                    <p>
                                        <small>Una vez aprobada la asignación no podra realizar modificaciones ni eliminarla</small>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Cancelar</button>
                                     <asp:Button ID="btnAprobarSalida" runat="server" Text="Aprobar" 
                CssClass="btn btn-danger" onclick="btnAprobarSalida_Click"
                                        />
                                </div>
                            </div>
                        </div>
                    </div>
                         <div id="modalEditar" class="modal fade">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                        &times;</button>
                                                    <h4 class="modal-title">
                                                    <span class="fa fa-pencil"></span> Editar Solicitud
                                                        </h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- form start -->
                                                    <div class="box-body">
                                                   
                                                        <div class="row">
                                                       
                                                            <div class="col-md-12">
                                                                <label for="nombre">
                                                                    Fecha de solicitud <font color="red">*</font>
                                                                </label>
                                                                <asp:TextBox ID="txtEditaFechaSolicitud" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </div>
                                                           
                                                        </div>

                                                        <div class="row">
                                                         <div class="col-md-12"">
                                                                <label for="nombre">
                                                                    Fecha de desde <font color="red">*</font>
                                                                </label>
                                                                <input id="dateEditaFechaDesde" type="text" name="dateEditaFechaDesde" readonly="readonly" runat="server"
                                                                    value="" class="form-control" placeholder="ejemplo: 01/01/2014" />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <label for="nombre">
                                                                    Fecha de hasta
                                                                </label>
                                                                <input id="dateEditaFechaHasta" type="text" name="dateFechaHasta" readonly="readonly" runat="server"
                                                                    value="" class="form-control" placeholder="ejemplo: 01/01/2014" />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <label for="nombre">
                                                                    Motivo de la salida <font color="red">*</font>
                                                                </label>
                                                                <asp:TextBox ID="txtEditaMotivoSalida" runat="server" CssClass="form-control" placeholder="ejemplo: Por trabajo fuera de la oficina"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                                        Cerrar</button>
                                                 <asp:Button CssClass="btn btn-primary"
                                                    ID="btnGuardarEditaMaestro" runat="server"
                                                        Text="Guardar Cambios" onclick="btnGuardarEditaMaestro_Click" OnClientClick="return ValidaEdita();"
                                                     />
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


        function ValidaEdita() {
            var error = 0;
            if (document.getElementById('<%=txtEditaMotivoSalida.ClientID %>').value == '' || document.getElementById('dateEditaFechaDesde').value=='') {
                error = 1;
            }
            if (error == 0) {
                return true;
            }
            else if (error == 1) {
                alert('Valide los datos antes de grabar');
                return false;
            }

        }

        $(document).ready(function () {

            $(document).bind("contextmenu", function (e) {
                return false;
            });

            $('#dateFechaDesde').datepicker({
                format: 'dd-mm-yyyy',
                clearBtn: true,
                language: "es",
                calendarWeeks: true,
                autoclose: true,
                todayHighlight: true
            });

            $('#dateFechaHasta').datepicker({
                format: 'dd-mm-yyyy',
                clearBtn: true,
                language: "es",
                calendarWeeks: true,
                autoclose: true,
                todayHighlight: true
            });

            $('#dateEditaFechaDesde').datepicker({
                format: 'dd-mm-yyyy',
                clearBtn: true,
                language: "es",
                calendarWeeks: true,
                autoclose: true,
                todayHighlight: true
            });

            $('#dateEditaFechaHasta').datepicker({
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

        function ConfirmaAprobarAsignacion() {
            $('#AprobarConfirmModal').modal('show');
            return false;
        }


        function Validar() {
            var error = 0;

            if (document.getElementById('dateFechaDesde').value == '' || document.getElementById('<%=txtMotivoSalida.ClientID %>').value == '' ) {
                error = 1;
            }
            if (document.getElementById('dateFechaHasta').value != '') {
                from = $("#dateFechaDesde").val().split("-");
                inicio = new Date(from[2], from[1] - 1, from[0]);

                from = $("#dateFechaHasta").val().split("-");
                finalq = new Date(from[2], from[1] - 1, from[0]);

//                inicio = new Date(document.getElementById('dateFechaDesde').value);
//                finalq = new Date(document.getElementById('dateFechaHasta').value);
                if (inicio > finalq)
                    error = 2;
            }

            if (error == 0) {
                return true;
            }
            else if (error == 1) {
            $('#divDetalleWarning').text('Llene los campos obligatorios').fadeIn(800).delay(4000).fadeOut(800);
//                alert('Valide los datos antes de grabar');
                return false;
            } else if (error == 2) {
                $('#divDetalleWarning').text('La fecha desde no puede ser mayor a la fecha hasta').fadeIn(800).delay(4000).fadeOut(800);
//                alert('La fecha desde no puede ser mayor a la fecha hasta');
                return false;
            }
        }


    </script>
</body>
</html>
