<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="ActivosFijosEETC.Views.Inventario" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

      
        <script type="text/javascript">
    // <![CDATA[
            function gridPersonal_SelectionChanged(s, e) {
                s.GetSelectedFieldValues("nombres", GetSelectedFieldValuesCallback);
            }
            function GetSelectedFieldValuesCallback(values) {
                selList.BeginUpdate();
                try {
                    selList.ClearItems();
                    for (var i = 0; i < values.length; i++) {
                        selList.AddItem(values[i]);
                    }
                } finally {
                    selList.EndUpdate();
                }
                document.getElementById("selCount").innerHTML = gridPersonal.GetSelectedRowCount();
            }
      // ]]> 
    </script>

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
    <script type="text/javascript">
        document.write('<script src="js/Inventario.js" type="text/javascript"><\/script>');   
    </script>
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
    <script src="js/jquery.plugins.js" type="text/javascript"></script>
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
                   <i class="fa fa-file-text"></i> Inventario <small>Control de activos</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Inventario</a></li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div id="div_inventarioMaestro" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Maestros de Inventario</h3>
                            </div>
                             <div class="box-body">
                                <div id="errorMaestro" class="alert alert-danger" role="alert" style="display: none">
                                    <strong>Error!</strong>
                                </div>
                                <div id="warningMaestro" class="alert alert-warning" role="alert" style="display: none">
                                    <strong>Advertencia!</strong>
                                </div>
                                <div id="successMaestro" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Correcto!</strong>
                                </div>
                               
                            </div>

                            <!-- /.box-header -->
                            <div class="box-body">
                                <asp:LinkButton  ID="btnNuevoInventario" runat="server" 
                                    Text="<span class='fa fa-plus'></span> Nuevo Inventario" CssClass="btn btn-primary" 
                                    onclick="btnNuevoInventario_Click"></asp:LinkButton>
                        <%--    <asp:Button ID="btnNuevoInventario" runat="server" 
                                    Text="Nuevo Inventario" CssClass="btn btn-primary" 
                                    onclick="btnNuevoInventario_Click"></asp:Button>--%>
                              

                                <asp:LinkButton ID="btnVerInventario" runat="server" CssClass="btn btn-warning" 
                                    Text="<span class='fa fa-file-text-o'></span> Ver Inventario" onclick="btnVerInventario_Click"></asp:LinkButton>
                                <%--<asp:Button ID="btnVerInventario" runat="server" CssClass="btn btn-primary" 
                                    Text="Ver Inventario" onclick="btnVerInventario_Click" />--%>

                              
                                     <button id="btnCerrar" type="button" class="btn btn-danger" onclick="return ConfirmaCerrarInventario();">
                                    <span class='fa fa-lock'></span> Cerrar Inventario</button>

                                   <%-- <asp:Button ID="btnCerrar" runat="server" 
                                    Text="Cerrar Inventario" CssClass="btn btn-primary" 
                                     OnClientClick="return ConfirmaCerrarInventario();"/>--%>
                            </div>
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <div>
                                        <dx:ASPxGridView ID="gridInventarioMaestro" runat="server" Width="100%" AutoGenerateColumns="False"
                                            Caption="Maestros de Inventario" Theme="Aqua" 
                                            onhtmlrowprepared="gridInventarioMaestro_HtmlRowPrepared" 
                                            onhtmldatacellprepared="gridInventarioMaestro_HtmlDataCellPrepared">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="Descripcion" FieldName="descripcion" 
                                                    VisibleIndex="1">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Inventario" FieldName="f_inventario" 
                                                    VisibleIndex="2">
                                                    <PropertiesTextEdit >
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="False" 
                                                    VisibleIndex="0">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Estado" FieldName="estado_inventario" 
                                                    VisibleIndex="6">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="idEstado" FieldName="fkc_estado_inventario" 
                                                    VisibleIndex="4" Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Documento de Respaldo" 
                                                    FieldName="documento_respaldo" VisibleIndex="5">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Conclusión" FieldName="f_conclusion" 
                                                    VisibleIndex="3">
                                                    <PropertiesTextEdit DisplayFormatString="{0:dd/MM/yyyy}">
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                        </dx:ASPxGridView>
                                    </div>
                                </div>
                            </div>

                        </div>

                         <div id="_divNuevoMaestroInventario" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Nuevo Inventario</h3>
                            </div>
                              <div class="box-body">
                                  <asp:LinkButton CssClass="btn btn-primary" runat="server" Text="<span class='fa fa-save'></span> Guardar y continuar" OnClientClick="return Validar();"
                                        ID="btnGuardarInventarioMaestro" OnClick="btnGuardarInventarioMaestro_Click"></asp:LinkButton>
                            <%--   <asp:Button CssClass="btn btn-primary" runat="server" Text="Guardar y continuar" OnClientClick="return Validar();"
                                        ID="btnGuardarInventarioMaestro" OnClick="btnGuardarInventarioMaestro_Click" />--%>
                                         <asp:Button CssClass="btn btn-default" runat="server" Text="Cancelar"
                                        ID="btnVolver" onclick="btnVolver_Click"  />

                                        <div class="row">
                                            <asp:TextBox CssClass="hidden" ID="id" runat="server"></asp:TextBox>
                                            <div class="col-xs-12">
                                                <label for="nombre">
                                                    Motivo de Inventario</label>
                                                <asp:TextBox ID="txtMaestroDescripcion" CssClass="form-control" placeholder="ejemplo: Escritorios"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <label for="nombre">
                                                    Fecha 
                                                Inicio de Inventario</label>
                                                      <input id="txtMaestroFecha" type="text" name="txtMaestroFecha" value="" class="form-control"
                                                                    readonly="readonly" placeholder="ejemplo: 01/01/2014" />
                                         
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <label for="nombre">
                                                    Documento de Respaldo</label>
                                                <asp:TextBox ID="txtMaestroDocumentoRespaldo" CssClass="form-control" placeholder="Documento de conformidad 001/2014"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                        <div class=box-body>
                                        <div id="div2" class="box box-primary" >
                            <div class="box-header">
                                <h3 class="box-title">
                                    Comité Para Inventario  <font color="red">*</font></h3>
                            </div>

                                           <div class="box-body">
                                <div style="float: left; width: 20%">
                                    <div class="BottomPadding">
                                        Valores Seleccionados:
                                    </div>
                                    <dx:ASPxListBox ID="ASPxListBox1" ClientInstanceName="selList" runat="server" Height="250px"
                                        Width="100%" Theme="Aqua" />
                                    <div class="TopPadding">
                                        Cantidad Seleccionada: <span id="selCount" style="font-weight: bold">0</span>
                                    </div>
                                </div>
                                <div style="float: right; width: 78%">
                                    <dx:ASPxGridView ID="gridPersonal" ClientInstanceName="gridPersonal" runat="server"
                                        Width="100%" Theme="Aqua" KeyFieldName="ci" AutoGenerateColumns="False" EnableTheming="True"
                                        Caption="Personal" ondatabound="gridPersonal_DataBound">
                                        <Columns>
                                            <dx:GridViewCommandColumn VisibleIndex="0" ShowSelectCheckbox="True">
                                                <ClearFilterButton Visible="True">
                                                </ClearFilterButton>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataColumn FieldName="documento" VisibleIndex="2" 
                                                Caption="documento" />
                                            <dx:GridViewDataColumn FieldName="nombres" VisibleIndex="3" Caption="nombres" />
                                            <dx:GridViewDataColumn FieldName="apellidos" VisibleIndex="4" />
                                            <dx:GridViewDataColumn FieldName="area" VisibleIndex="6" Caption="area" />
                                            <dx:GridViewDataTextColumn Caption="estado" VisibleIndex="7" FieldName="estado" 
                                                Visible="False">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Gerencia" FieldName="gerencia" 
                                                VisibleIndex="4">
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
                                        <ClientSideEvents SelectionChanged="gridPersonal_SelectionChanged" />
                                        <Settings ShowFilterRow="True" />
                                        <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                    </dx:ASPxGridView>
                                </div>
                            </div>
                            </div>
                            </div>
                            </div>
                                    </div>

                         </div>



                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div id="div_inventarioDetalle" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    <asp:Label ID="lblNuevoInventario" Text="Inventario" runat="server" /></h3>
                            </div>
                            <div class="box-body">
                           
                                <asp:LinkButton ID="btnGenerarReporteInventario" runat="server" CssClass="btn btn-primary" 
                                    Text="<span class='fa fa-print'></span> Reporte Verificados Fisicamente" onclick="btnGenerarReporteInventario_Click"></asp:LinkButton>

                          <%--  <asp:Button ID="btnGenerarReporteInventario" runat="server" CssClass="btn btn-warning" 
                                    Text="<span class='fa fa-shopping-cart'></span> Reporte Verificados Fisicamente" onclick="btnGenerarReporteInventario_Click" />--%>
                                <asp:LinkButton ID="btnGenerarReporteSinVerificar" runat="server" CssClass="btn btn-warning" 
                                    Text="<span class='fa fa-print'></span> Reporte Sin Verificar Fisicamente" 
                                    onclick="btnGenerarReporteSinVerificar_Click"></asp:LinkButton>
                                   
                                <%--    <asp:Button ID="btnGenerarReporteSinVerificar" runat="server" CssClass="btn btn-warning" 
                                    Text="<span class='fa fa-shopping-cart'></span> Reporte Sin Verificar Fisicamente" 
                                    onclick="btnGenerarReporteSinVerificar_Click"  />--%>
                                <asp:LinkButton ID="btnMaestrosInventario" runat="server" CssClass="btn btn-default" 
                                    Text="<span class='fa fa-file'></span> Volver" onclick="btnMaestrosInventario_Click"></asp:LinkButton>

                            <%--    <asp:Button ID="btnMaestrosInventario" runat="server" CssClass="btn btn-default" 
                                    Text="Volver" onclick="btnMaestrosInventario_Click"  />--%>
                                     </div>
                             <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                            <div class="box-body">
                              
                                <div class="row">
                                 <div class="col-xs-12">
                                    <div class="input-group">
                                        <div class="input-group-btn">
                                        
                                            <asp:LinkButton ID="btnBuscar" runat="server" Text="<span class='fa fa-search'></span> Buscar" 
                                                CssClass="btn btn-danger" onclick="btnBuscar_Click"></asp:LinkButton>
                                           <%-- <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                                                CssClass="btn btn-danger" onclick="btnBuscar_Click"/>--%>
                                
                                        </div>
                                        <!-- /btn-group -->
                                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                               
                                    </div>
                                    </div>
                                </div>
                               
                               <div class="row">
                                <asp:TextBox ID="txtIdInventarioMaestro" CssClass="form-control" placeholder="ejemplo: Escritorios de oficina"
                                            ReadOnly="true" runat="server" Visible=false></asp:TextBox>

                                    <div class="col-xs-6">
                                        <label for="nombre">
                                            Inventario</label>
                                        <asp:TextBox ID="txtDescripcionInventario" CssClass="form-control" placeholder="ejemplo: Escritorios de oficina"
                                            ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                     <div class="col-xs-6">
                                        <label for="nombre">
                                            Fecha</label>
                                        <asp:TextBox ID="txtFechaInventario" CssClass="form-control" placeholder=""
                                            ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                             
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Documento de Respaldo</label>
                                        <asp:TextBox ID="txtDocumentoRespaldo" CssClass="form-control" placeholder="ejemplo: Escritorios de oficina"
                                            ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                   
                                </div>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Descripcion</label>
                                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" placeholder="ejemplo: Escritorios de oficina"
                                            ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-4">
                                        <label for="nombre">
                                            Documento</label>
                                        <asp:TextBox ID="txtDocumento" CssClass="form-control" placeholder="ejemplo: ES"
                                            runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-4">
                                        <label for="txtNombre">
                                            Nombres</label>
                                        <asp:TextBox ID="txtNombres" CssClass="form-control" placeholder="ejemplo: ES" runat="server"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-4">
                                        <label for="txtApellidos">
                                            Apellidos</label>
                                        <asp:TextBox ID="txtApellidos" CssClass="form-control" 
                                            placeholder="ejemplo: ES" runat="server"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6">
                                        <label for="nombre">
                                            Gerencia</label>
                                        <asp:TextBox ID="txtGerencia" CssClass="form-control" placeholder="ejemplo: ES" runat="server"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-6">
                                        <label for="txtNombre">
                                            Area</label>
                                        <asp:TextBox ID="txtArea" CssClass="form-control" placeholder="ejemplo: ES" runat="server"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6">
                                        <label for="nombre">
                                            Estado Físico</label>
                                        <asp:TextBox ID="txtEstadoOriginal" CssClass="form-control" placeholder="ejemplo: ES" runat="server"
                                            ReadOnly="true"></asp:TextBox>
                                    </div>
                                    
                                </div>

                                
                            </div>

                            </ContentTemplate>
                                    </asp:UpdatePanel>

                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                            <div class="box-body" runat="server" id="_divInventariar">
                                <div id="dangerDetalle" class="alert alert-danger" role="alert" style="display: none">
                                    <strong>Error!</strong>
                                </div>
                                 <div id="warningDetalle" class="alert alert-warning" role="alert" style="display: none">
                                    <strong>Alerta!</strong>
                                </div>
                                <div id="successDetalle" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Correcto!</strong>
                                </div>

                                <asp:LinkButton ID="btnGuardarRegistro" runat="server" CssClass="btn btn-primary" 
                                    Text="<span class='fa fa-eye'></span> Validar Físico" onclick="btnGuardarRegistro_Click"></asp:LinkButton>
                             <%--   <asp:Button ID="btnGuardarRegistro" runat="server" CssClass="btn btn-primary" 
                                    Text="Validar Físico" onclick="btnGuardarRegistro_Click" />--%>

                                <asp:LinkButton ID="btnGuardarRegistroNoFisico" runat="server" CssClass="btn btn-warning" 
                                    Text="<span class='fa fa-eye-slash'></span> Validar NO Fisico" onclick="btnGuardarRegistroNoFisico_Click"></asp:LinkButton>
                                  <%--  <asp:Button ID="btnGuardarRegistroNoFisico" runat="server" CssClass="btn btn-danger" 
                                    Text="Validar NO Fisico" onclick="btnGuardarRegistroNoFisico_Click" /> --%>
                            </div>
                            <div class="box-body">
                            <div class="row">
                                <div class="col-xs-6">
                                        <label for="txtNombre">
                                            Estado Actual</label><asp:DropDownList ID="ddlEstadoFisicoActivo" 
                                            runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                       
                                    </div>
                                    <div class="col-xs-6">
                                        <label for="nombre">
                                            Observaciones</label>
                                        <asp:TextBox ID="txtObservaciones" CssClass="form-control" 
                                            placeholder="ejemplo: ES" runat="server"
                                            ></asp:TextBox>
                                    </div>
                                    
                                </div>
                                </div>
                                 </ContentTemplate>
                                    </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <dx:ASPxGridView ID="gridInventarioDetalle" runat="server" Width="100%" AutoGenerateColumns="False"
                                        Theme="Aqua" Caption="Activos Inventariados">
                                        <Columns>
                                            <dx:GridViewCommandColumn VisibleIndex="0">
                                                <ClearFilterButton Visible="True">
                                                </ClearFilterButton>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="3">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" 
                                                VisibleIndex="4">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="documento" VisibleIndex="6" 
                                                Caption="Documento">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Nombres" VisibleIndex="7" 
                                                FieldName="nombres">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Apellidos" VisibleIndex="8" 
                                                FieldName="apellidos">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Area" VisibleIndex="9" FieldName="area">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Gerencia" VisibleIndex="10" 
                                                FieldName="gerencia">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Observaciones" FieldName="observaciones" 
                                                VisibleIndex="12">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Estado Físico Actual" 
                                                FieldName="estado_activo" VisibleIndex="11">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Verificado" FieldName="verificado" 
                                                VisibleIndex="2">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Correlativo" FieldName="correlativo" 
                                                VisibleIndex="1">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Ubicación" FieldName="ubicacion" 
                                                VisibleIndex="13">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Estación" FieldName="estacion" 
                                                VisibleIndex="14">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" VisibleIndex="5">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Settings ShowFilterRow="True" />
                                        <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                    </dx:ASPxGridView>
                                </div>
                            </div>
                            </ContentTemplate>
                                    </asp:UpdatePanel>



                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <dx:ASPxGridView ID="gridInventarioFaltante" runat="server" Width="100%" AutoGenerateColumns="False"
                                        Theme="Aqua" Caption="Activos Faltantes">
                                        <Columns>
                                            <dx:GridViewCommandColumn VisibleIndex="0">
                                                <ClearFilterButton Visible="True">
                                                </ClearFilterButton>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="1">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" 
                                                VisibleIndex="2">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="documento" VisibleIndex="4" 
                                                Caption="Documento">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Nombres" VisibleIndex="5" 
                                                FieldName="nombres">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Apellidos" VisibleIndex="6" 
                                                FieldName="apellidos">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Area" VisibleIndex="7" FieldName="area">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Gerencia" VisibleIndex="8" 
                                                FieldName="gerencia">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Ubicación" FieldName="ubicacion" 
                                                VisibleIndex="9">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Estación" FieldName="estacion" 
                                                VisibleIndex="10">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" VisibleIndex="3">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                        <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                    </dx:ASPxGridView>
                                </div>
                            </div>
                            </ContentTemplate>
                                    </asp:UpdatePanel>
                        </div>
                    </div>
                    <div id="modalMaestroInventario" class="modal fade"  data-width="760">
                        
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title">
                                        <asp:Label ID="lblTitleModal" Text="Registro de Maestro de Inventario" runat="server" />
                                    </h4>
                                </div>
                                <div class="modal-body">
                                    <!-- form start -->
                                  
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Cerrar</button>
                                   
                                </div>
                       
                    </div>
                </div>

                <div class="modal fade" id="CerrarInventarioConfirmModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title" id="H1">Notificacion de Aprobacion</h4>
            </div>
            <div class="modal-body">

            <div class="box-body">
            
             <div class="row">
                                            <div class="col-xs-12">
                                                <label for="nombre">
                                                    Fecha Conclusión</label>
                                                      <input id="txtFechaConclusion" type="text" name="txtFechaConclusion" value="" class="form-control"
                                                                    readonly="readonly" placeholder="ejemplo: 01/01/2014" />
                                         
                                            </div>
                                        </div>
            </div>

                <p><strong>Esta seguro que desea Cerrar el inventario?</strong></p>
                <p><small>
                    Una vez cerrado el inventario no podra realizar modificaciones en ese inventario</small>
                </p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                <%--<button type="button" class="btn btn-danger" id="deleteConfirm">Delete Notification</button>--%>
                <asp:Button ID="btnCerrarInventario" runat="server" CssClass="btn btn-danger" 
                                    Text="Cerrar Inventario" onclick="btnCerrarInventario_Click" />
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

        function Validar() {
            var error = 0;

            if (document.getElementById('<%=txtMaestroDescripcion.ClientID %>').value == '' || document.getElementById('txtMaestroFecha').value == '') {
                error = 1;
            }


            if (error == 0) {

                return true;

            }
            else {
                alert('Valide los datos antes de grabar');
                return false;
            }
        } 
    </script>
    <script type="text/javascript">
        window.onload = function () {
            document.onkeydown = function (e) {
                return (e.which || e.keyCode) != 116;
            };
        }
    </script>

     <script type="text/javascript">

         function ConfirmaCerrarInventario() {
             $('#CerrarInventarioConfirmModal').modal('show');
             return false;
         }
       </script>   

</body>
</html>
