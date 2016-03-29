<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="ActivosFijosEETC.Views.Compras" %>

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
    <script type="text/javascript">
        document.write('<script src="js/Compras.js" type="text/javascript"><\/script>');   
    </script>
    <!-- jQuery UI 1.10.3 -->
    <script src="bootstrap/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
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
    <script src="js/plugins/jquery.price_format.2.0.min.js" type="text/javascript"></script>
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
                    <i class='fa fa-shopping-cart'></i>Compras <small></small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Compras</a></li>
                    <li class="active">Registro de compras</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row" id="div_Listacompras" runat="server">
                    <div class="col-md-12">
                        <div id="div_gruposcontables" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Lista de Compras Realizadas</h3>
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
                                <asp:LinkButton ID="btnRegistroCompra" runat="server" CssClass="btn btn-primary"
                                    OnClick="btnRegistroCompra_Click" Text="<span class='fa fa-plus'></span> Nueva compra"></asp:LinkButton>
                                <asp:LinkButton ID="btnRegistrarActivos" runat="server" OnClick="btnRegistrarActivos_Click"
                                    CssClass="btn btn-success" Text="<span class='fa fa-file-text-o'></span> Ver detalle de compra"></asp:LinkButton>
                                <asp:LinkButton ID="btnAprobarCompra" runat="server" Text="<span class='fa fa-thumbs-o-up'></span> Aprobar compra"
                                    CssClass="btn btn-warning" OnClientClick="return ConfirmaAprobarCompra();"></asp:LinkButton>
                                <asp:LinkButton ID="btnAprobarConReserva" runat="server" Text="<span class='fa fa-thumbs-o-up'></span> Aprobar con reserva"
                                    CssClass="btn btn-default" OnClientClick="return ConfirmaAprobarConReserva();"></asp:LinkButton>
                                <asp:LinkButton ID="btnEliminarCompra" runat="server" Text="<span class='fa fa-trash-o'></span> Eliminar compra"
                                    CssClass="btn btn-danger" OnClientClick="return ConfirmaElimina();"></asp:LinkButton>
                            </div>
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <div>
                                        <dx:ASPxGridView ID="gridCompras" runat="server" AutoGenerateColumns="False" Width="100%"
                                            Theme="Aqua" Caption="Compras Realizadas" Font-Size="Small" OnHtmlRowPrepared="gridCompras_HtmlRowPrepared"
                                            OnCustomUnboundColumnData="gridCompras_CustomUnboundColumnData" OnCellEditorInitialize="gridCompras_CellEditorInitialize"
                                            OnHtmlDataCellPrepared="gridCompras_HtmlDataCellPrepared">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="id" VisibleIndex="0" FieldName="ID" Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Descripción" VisibleIndex="2" FieldName="descripcion"
                                                    Width="350px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Registro" VisibleIndex="3" FieldName="f_registro"
                                                    Width="100px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Monto Bs" VisibleIndex="10" UnboundType="Decimal"
                                                    FieldName="monto_bs" Width="200px">
                                                    <FooterCellStyle ForeColor="Brown" />
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Tasa Sus" VisibleIndex="5" UnboundType="Decimal"
                                                    FieldName="tasa_sus" Width="100px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Tasa UFV" VisibleIndex="4" FieldName="tasa_ufv"
                                                    Width="100px">
                                                    <PropertiesTextEdit DisplayFormatString="UFV {0:0,0.0000}">
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Nro. Factura" VisibleIndex="11" FieldName="nro_factura"
                                                    Width="100px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Documento de Respaldo" FieldName="doc_respaldo"
                                                    VisibleIndex="12" Width="200px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="id proveedor" FieldName="fk_proveedor" VisibleIndex="13"
                                                    Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="id gerencia solicitante" FieldName="fk_gerencia_solicitante"
                                                    VisibleIndex="15" Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Estado Proceso" FieldName="estado_proceso" VisibleIndex="22"
                                                    Width="100px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Gerencia Solicitante" FieldName="gerencia_solicitante"
                                                    VisibleIndex="16" Width="250px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Proveedor" FieldName="proveedor" VisibleIndex="14"
                                                    Width="150px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fuente de Financiamiento" FieldName="fuente_financiamiento"
                                                    VisibleIndex="20" Width="200px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="id estado proceso" FieldName="fkc_estado_proceso"
                                                    Visible="False" VisibleIndex="18">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Correlativo" FieldName="correlativo" VisibleIndex="1">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="costo" VisibleIndex="6" UnboundType="Decimal"
                                                    Caption="Costo Factura">
                                                    <PropertiesTextEdit DisplayFormatString="Bs. {0:0,0.00}">
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="gastos_con_credito_fiscal" VisibleIndex="8"
                                                    UnboundType="Decimal" Caption="Gastos C/CF">
                                                    <PropertiesTextEdit DisplayFormatString="Bs. {0:0,0.00}">
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Gastos S/CF" VisibleIndex="9" FieldName="gastos_sin_credito_fiscal">
                                                    <PropertiesTextEdit DisplayFormatString="$us {0:0,0.00}">
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                            <SettingsPager PageSize="20">
                                            </SettingsPager>
                                            <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowHorizontalScrollBar="True"
                                                ShowFilterRowMenu="True" />
                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                            <Settings ShowFooter="True" />
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="monto_factura" SummaryType="Sum" DisplayFormat="Bs {0:0,0.00}"
                                                    ShowInColumn="Monto Factura" />
                                                <dx:ASPxSummaryItem FieldName="monto_trece_porciento" SummaryType="Sum" DisplayFormat="Bs {0:0,0.00}"
                                                    ShowInColumn="Monto 13%" />
                                                <dx:ASPxSummaryItem FieldName="monto_bs" SummaryType="Sum" DisplayFormat="Bs {0:0,0.00}"
                                                    ShowInColumn="Monto Bs" />
                                                <dx:ASPxSummaryItem FieldName="monto_ufv" SummaryType="Sum" DisplayFormat="ufv {0:0,0.0000}"
                                                    ShowInColumn="Monto UFV" />
                                                <dx:ASPxSummaryItem FieldName="monto_sus" SummaryType="Sum" DisplayFormat="$us {0:0,0.00}"
                                                    ShowInColumn="Monto Sus" />
                                            </TotalSummary>
                                        </dx:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-body">
                    <div id="dangerCompras" class="alert alert-danger" role="alert" style="display: none">
                        <strong>Error!</strong>
                    </div>
                    <div id="successCompras" class="alert alert-success" role="alert" style="display: none">
                        <strong>Correcto!</strong>
                    </div>
                    <div id="warningCompras" class="alert alert-warning" role="alert" style="display: none">
                        <strong>Atencion!</strong>
                    </div>
                </div>
                <div class="row" id="div_RegistroCompras" runat="server">
                    <div class="col-md-12">
                        <div id="div1" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Registro de Compra</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <asp:LinkButton ID="btnGuardarCompra" runat="server" Text="<span class='fa fa-save'></span> Guardar y Continuar"
                                    CssClass="btn btn-primary" OnClick="btnGuardarCompra_Click"></asp:LinkButton>
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default"
                                    OnClick="btnCancelar_Click" />
                            </div>
                            <div class="box-body">
                                <div class="alert alert-info alert-dismissable">
                                    <i class="fa fa-info"></i>
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                                        ×</button>
                                    <b>Información!</b> Los datos de la compra permite el registro de un maestro de
                                    compra. Seleccione el campo fecha y haga click en una fecha para obtener las tasas
                                    de cambio. Si no aparecen las tasas de cambio favor reviste la parametrica en "Tasas
                                    de Cambio".
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-body">
                                <asp:TextBox CssClass="hidden" ID="id" runat="server"></asp:TextBox>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Descripción <font color="red">*</font>
                                        </label>
                                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" placeholder="ejemplo: ADQUISICION DE 3 PIZARRAS ACRILICAS Y 2 PIZARRAS DE CORCHO"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3">
                                        <label for="nombre">
                                            Fecha de Registro <font color="red">*</font>
                                        </label>
                                        <input id="dateFechaRegistro" type="text" name="dateFechaRegistro" readonly="readonly"
                                            value="" class="form-control" placeholder="ejemplo: 01/01/2014" />
                                      
                                    </div>
                                    <div class="col-xs-2">
                                        &nbsp;<label for="nombre">Tasa UFV <font color="red">*</font>
                                        </label>
                                        <asp:TextBox ID="txtTasaUFV" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        &nbsp;<label for="nombre">Tasa Dolar <font color="red">*</font>
                                        </label>
                                        <asp:TextBox ID="txtTasaDolar" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        &nbsp;<label for="nombre">Nro. Factura <font color="red">*</font>
                                        </label>
                                        <asp:TextBox ID="txtNroFactura" CssClass="form-control" placeholder="ejemplo: 123456789"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <label for="nombre">
                                            Gerencia Solicitante <font color="red">*</font>
                                        </label>
                                        
                                        <asp:DropDownList ID="ddlSolicitante" CssClass="form-control" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione un item" Value="-1" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3">
                                        &nbsp;<label for="nombre">Documento Respaldo <font color="red">*</font>
                                        </label>
                                        <asp:TextBox ID="txtDocRespaldo" CssClass="form-control" placeholder="ejemplo: 15"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <label for="nombre">
                                            Proveedor <font color="red">*</font>
                                        </label>
                                       
                                        <asp:DropDownList ID="ddlProveedores" CssClass="form-control" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione un item" Value="-1" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-3">
                                        <label for="nombre">
                                            Fuente de Financiamiento <font color="red">*</font>
                                        </label>
                                        <asp:DropDownList ID="ddlFinanciamiento" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione un item" Value="-1" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="div_comiteCompras" runat="server">
                    <div class="col-md-12">
                        <div id="div2" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Comité de Recepción <font color="red">*</font>
                                </h3>
                            </div>
                            <div class="alert alert-info alert-dismissable">
                                <i class="fa fa-info"></i>
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                                    ×</button>
                                <b>Información!</b> Busque y seleccione el personal designado para ser el comité
                                de recepción de los activos comprados.
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
                                        Caption="Personal">
                                        <Columns>
                                            <dx:GridViewCommandColumn VisibleIndex="0" ShowSelectCheckbox="True">
                                                <ClearFilterButton Visible="True">
                                                </ClearFilterButton>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataColumn FieldName="documento" VisibleIndex="2" Caption="documento" />
                                            <dx:GridViewDataColumn FieldName="nombres" VisibleIndex="3" Caption="nombres" />
                                            <dx:GridViewDataColumn FieldName="apellidos" VisibleIndex="4" />
                                            <dx:GridViewDataColumn FieldName="area" VisibleIndex="6" Caption="area" />
                                            <dx:GridViewDataTextColumn Caption="estado" VisibleIndex="7" FieldName="estado" Visible="False">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Gerencia" FieldName="gerencia" VisibleIndex="4">
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
                                    <strong>Esta seguro que desea eliminar la compra?</strong></p>
                                <p>
                                    <small>Las compras que se encuentren en estado aprobado no podran ser eliminadas</small>
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                                <%--<button type="button" class="btn btn-danger" id="deleteConfirm">Delete Notification</button>--%>
                                <asp:Button ID="Button1" runat="server" Text="Eliminar" CssClass="btn btn-danger"
                                    OnClick="btnEliminarCompra_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="AprobarConfirmModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="H1">
                                    Notificacion de Aprobacion</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <strong>Esta seguro que desea aprobar la compra?</strong></p>
                                <p>
                                    <small>Una vez aprobada la compra no podra realizar modificaciones en la compra</small>
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                                <%--<button type="button" class="btn btn-danger" id="deleteConfirm">Delete Notification</button>--%>
                                <asp:Button ID="Button2" runat="server" Text="Aprobar" CssClass="btn btn-danger"
                                    OnClick="btnAprobarCompra_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="AprobarReservaConfirmModal" tabindex="-1" role="dialog"
                    aria-labelledby="deleteLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="H2">
                                    Notificacion de Aprobacion con Reserva</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <strong>Esta seguro que desea aprobar la compra?</strong></p>
                                <p>
                                    <small>Una vez aprobada la compra no podra realizar modificaciones en la compra</small>
                                </p>
                                <div class="row">
                                    <div class="col-md-12">
                                        &nbsp;<label for="nombre">Lista de reservas vigentes <font color="red">*</font>
                                        </label>
                                        <asp:DropDownList ID="ddlReservas" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                            <asp:ListItem Text="seleccione una reserva" Value="-1" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                                <asp:Button ID="btnAprobarReserva" runat="server" Text="Aprobar" CssClass="btn btn-danger" OnClientClick="return ValidaReserva();"
                                    OnClick="btnAprobarReserva_Click" />
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

        function ValidaReserva() {
            var error = 0;

            if (document.getElementById('<%=ddlReservas.ClientID %>').value == '-1') {
                error = 1;
            }

            if (error == 0) {
                return true;
            }
            else {
                alert('Seleccione una reserva');
                return false;
            }
        }

        function ConfirmaElimina() {
            $('#deleteConfirmModal').modal('show');
            return false;

        }


        function ConfirmaAprobarCompra() {
            $('#AprobarConfirmModal').modal('show');
            return false;
        }

        function ConfirmaAprobarConReserva() {
            $('#AprobarReservaConfirmModal').modal('show');
            return false;
        }
          
    </script>
</body>
</html>
