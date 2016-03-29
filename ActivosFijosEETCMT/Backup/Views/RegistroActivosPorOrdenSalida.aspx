<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroActivosPorOrdenSalida.aspx.cs"
    Inherits="ActivosFijosEETC.Views.RegistroActivosPorOrdenSalida" %>

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
    <!-- AdminLTE for demo purposes -->
    <script src="bootstrap/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <!-- Sparkline -->
    <script src="bootstrap/js/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- jvectormap -->
    <script src="bootstrap/js/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"
        type="text/javascript"></script>
    <!-- jQuery Knob Chart -->
    <script src="bootstrap/js/plugins/jqueryKnob/jquery.knob.js" type="text/javascript"></script>
    <!-- daterangepicker -->
    <script src="bootstrap/js/plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <!-- datepicker -->
    <script src="bootstrap/js/plugins/datepicker/bootstrap-datepicker.js" type="text/javascript"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="bootstrap/js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"
        type="text/javascript"></script>
    <!-- iCheck -->
    <script src="bootstrap/js/plugins/iCheck/icheck.min.js" type="text/javascript"></script>
    <!-- AdminLTE App -->
    <script src="bootstrap/js/AdminLTE/app.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/datatables/jquery.dataTables.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/datatables/dataTables.bootstrap.js" type="text/javascript"></script>
    <script src="js/OrdenesSalida.js" type="text/javascript"></script>

</head>
<body class="skin-blue">
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
                    <i class="fa fa-file-text-o"></i> <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label><small> </small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Control de activos fijos</a></li>
                    <li class="active">Detalle de salidas</li>
                </ol>
            </section>
            <form id="Form1" runat="server">
            <section class="content">
                <div class="row" id="div3" runat="server">
                    <div class="col-md-12">
                        <div id="div4" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Datos de la orden de salida</h3>
                            </div>

                                 <asp:ScriptManager ID="smgr" runat="server" EnablePartialRendering="true" />
                            <!-- /.box-body -->
                         <%--     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>--%>
                            <div class="box-body">
                                <asp:LinkButton ID="btnVerSolicitudes" runat="server" Text="&lt;span class='fa fa-sign-out'&gt;&lt;/span&gt; Ver salidas"
                                    CssClass="btn btn-primary" OnClick="btnVerSolicitudes_Click"></asp:LinkButton>
                             
                                    
                                <asp:LinkButton ID="btnImprimirSolicitud" runat="server" Text="<span class='fa fa-print'></span> Imprimir salida"
                                    CssClass="btn btn-warning" OnClick="btnImprimirSolicitud_Click"></asp:LinkButton>
                            </div>
                           <%--   </ContentTemplate>
                                      <Triggers>
                                      <asp:AsyncPostBackTrigger ControlID=btnEditarMaestro EventName=Click />
                                      </Triggers>
                                </asp:UpdatePanel>--%>
                            <div class="box-body">
                                <asp:TextBox ID="txtEstadoGrillaActivos" class="form-control" ReadOnly="true" Visible="false"
                                    runat="server"></asp:TextBox>
                                <div class="row">
                                    <div class="col-md-4">
                                        <label for="nombre">
                                            Fecha de solicitud
                                        </label>
                                        <asp:TextBox ID="txtIdMaestro" class="form-control" ReadOnly="true" Visible="false"
                                            runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtFechaSolicitud" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4" id="Div5" runat="server">
                                        <label for="nombre">
                                            Fecha de desde
                                        </label>
                                        <asp:TextBox ID="txtFechaDesde" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <label for="nombre">
                                            Fecha de hasta
                                        </label>
                                        <asp:TextBox ID="txtFechaHasta" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <label for="nombre">
                                            Motivo de la salida
                                        </label>
                                        <asp:TextBox ID="txtMotivoSalida" runat="server" CssClass="form-control" placeholder="ejemplo: Por trabajo fuera de la oficina"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <%--<div class="row">
                                    <div class="col-md-12">
                                        <label for="nombre">
                                            Motivo de la salida
                                        </label>
                                        <asp:TextBox ID="txtDocumentoAutorizacion" runat="server" CssClass="form-control"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>--%>
                                <div class="row">
                                    <div class="col-md-4">
                                        <label for="nombre">
                                            Documento
                                        </label>
                                        <asp:TextBox ID="txtFkPersona" runat="server" CssClass="form-control" ReadOnly="true"
                                            Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" placeholder="ejemplo: Por trabajo fuera de la oficina"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <label for="nombre">
                                            Nombres
                                        </label>
                                        <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" placeholder="ejemplo: Por trabajo fuera de la oficina"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <label for="nombre">
                                            Apellidos
                                        </label>
                                        <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder="ejemplo: Por trabajo fuera de la oficina"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label for="nombre">
                                            Área
                                        </label>
                                        <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" placeholder="ejemplo: Por trabajo fuera de la oficina"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label for="nombre">
                                            Gerencia
                                        </label>
                                        <asp:TextBox ID="txtGerencia" runat="server" CssClass="form-control" placeholder="ejemplo: Por trabajo fuera de la oficina"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-body" id="_ver" runat="server">
                    <asp:LinkButton ID="btnVerActivosPropios" runat="server" Text="<span class='fa fa-tags'></span> Ver activos asignados"
                        CssClass="btn btn-default btn-block" OnClick="btnVerActivosPropios_Click"></asp:LinkButton>
                    <asp:LinkButton ID="btnVerTodosActivos" runat="server" Text="<span class='fa fa-ellipsis-h'></span> Ver todos"
                        CssClass="btn btn-default btn-block" OnClick="btnVerTodosActivos_Click"></asp:LinkButton>
                </div>
                <div class="box-body" id="_info_1" runat="server">
                    <div class="alert alert-info alert-dismissable">
                        <i class="fa fa-info"></i>
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                            &times;</button>
                        <b>Información!</b> Seleccione un activo y haga clic en "Adicionar" para solicitar
                        la salida del activo, haga clic en "Quitar" para deshacer la accion. Puede buscar
                        todos los activos o ver solamente los activos asignados a la persona haciendo clic
                        en "Ver activos asignados"
                    </div>
                </div>
               <%-- <div class="box box-body">
                    <div class="row">
                        <div class="col-md-12">
                            <label for="nombre">
                                Observaciones <font color="red">*</font>
                            </label>
                            <asp:TextBox ID="txtObservaciones" class="form-control" placeholder="ejemplo: activo en buenas condiciones"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>--%>

           
           
                <div class="box-footer">
                    <div class="row">
                    <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <div class="col-lg-6" id="_activos_existentes" runat="server">
                            <div class="box">
                                <dx:ASPxGridView ID="gridActivos" runat="server" Width="100%" Caption="Activos" Theme="Aqua"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <dx:GridViewCommandColumn Visible="False" VisibleIndex="0" Caption=" ">
                                            <ClearFilterButton Visible="True">
                                            </ClearFilterButton>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="id" FieldName="id" VisibleIndex="1" Visible="False">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="3" 
                                            Width="20%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="4"
                                            Width="50%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                            <CellStyle HorizontalAlign="Justify">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" VisibleIndex="5" 
                                            Width="30%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="fk_activo" FieldName="fk_activo" VisibleIndex="2"
                                            Visible="False">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>

                                      

                                         <dx:GridViewDataTextColumn VisibleIndex="5" Caption=" " FieldName="adicionar">

<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>

                                                <DataItemTemplate>
                                                    <asp:Button ID="btnAdicionar" runat="server" CssClass="btn btn-primary"
                                                    CommandArgument="<%# Container.VisibleIndex %>" OnClick="btnAdicionar_Click"
                                                      Text="Adicionar" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>

                                    </Columns>
                                    <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                    <Settings ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True" VerticalScrollableHeight="400" />
                                    <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control"></SettingsBehavior>
                                    <Settings ShowVerticalScrollBar="True" ShowHorizontalScrollBar="True" VerticalScrollableHeight="400"
                                        ShowFilterRow="True"></Settings>
                                    <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                </dx:ASPxGridView>
                            </div>
                        
                        </div>
                        
                        </ContentTemplate>
                       
                        </asp:UpdatePanel>
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="col-lg-6" id="_activos_solicitados" runat="server">
                            <div class="box">
                                <dx:ASPxGridView ID="gridActivosSalida" runat="server" Width="100%" Caption="Activos Egresados"
                                    Theme="Aqua" AutoGenerateColumns="False" KeyFieldName="id">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Visible="False">
                                            <ClearFilterButton Visible="True">
                                            </ClearFilterButton>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="id" FieldName="id" VisibleIndex="1" 
                                            Visible="False">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="fk_activo" FieldName="fk_activo" VisibleIndex="2"
                                            Visible="False">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="3" 
                                            Width="20%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="4"
                                            Width="40%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                            <CellStyle HorizontalAlign="Justify">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" VisibleIndex="5" 
                                            Width="20%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Observaciones" FieldName="observaciones_salida"
                                            VisibleIndex="6" Width="20%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>

                                       

                                           <dx:GridViewDataTextColumn VisibleIndex="6" Caption=" " FieldName="quitar">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                                <DataItemTemplate>
                                                    <asp:Button ID="btnquitar" runat="server" CssClass="btn btn-danger"
                                                    CommandArgument="<%# Container.VisibleIndex %>" OnClick="btnquitar_Click"
                                                      Text="Quitar" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFooter="True" ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True"
                                        VerticalScrollableHeight="400" ShowFilterRow="True" />
                                    <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                </dx:ASPxGridView>
                            </div>
                        </div>
                         </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </section>
               <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                    <ContentTemplate>
                <div id="modalAdicionar" class="modal fade">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                        &times;</button>
                                                    <h4 class="modal-title">
                                                    Activo Solicitado
                                                        </h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- form start -->
                                                    <div class="box-body">
                                                   
                                                        <div class="row">
                                                            <asp:TextBox ID="txtCodigoAdicionar" runat="server" Enabled=false Visible="false"></asp:TextBox>
                                                            <div class="col-xs-12">
                                                                <label for="nombre">
                                                                    Observaciones <font color="red">*</font>
                                                                </label>
                                                                <asp:TextBox ID="txtObservaciones" class="form-control" placeholder="ejemplo: activo en buenas condiciones"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                                        Cerrar</button>
                                                   <asp:Button CssClass="btn btn-primary"
                                                    ID="btnGuardarAdicionar" runat="server"
                                                        Text="Adicionar" onclick="btnGuardarAdicionar_Click"
                                                     />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                      </ContentTemplate>
                        </asp:UpdatePanel>                  
            </form>
        </aside>
    </div>

    <!-- ./wrapper -->
</body>
</html>
<script type="text/javascript">

  
    function ConfirmaElimina() {
        if (confirm("¿Está seguro de que quiere eliminar el registro?"))
            return true;
        else return false;
    }

   

</script>
