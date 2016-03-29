<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transferencias.aspx.cs"
    Inherits="ActivosFijosEETC.Views.Transferencias" %>

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
        document.write('<script src="js/Tranferencias.js" type="text/javascript"><\/script>');   
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
    <script src="js/plugins/jquery.price_format.2.0.min.js" type="text/javascript"></script>
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
                   <i class="fa fa-retweet"></i> Transferencias <small></small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Transferencias</a></li>
                    <li class="active">Registro de Transferencia</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row" id="div_ListaTransferencias" runat="server">
                    <div class="col-md-12">
                        <div id="div_gruposcontables" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Lista de Transferencias realizadas</h3>
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
                                <asp:LinkButton ID="btnRegistroTransferencia" runat="server" Text="<span class='fa fa-plus'></span> Registro de transferencia"
                                    CssClass="btn btn-primary" OnClick="btnRegistroTransferencia_Click"></asp:LinkButton>
                               <%-- <asp:Button ID="btnRegistroTransferencia" runat="server" Text="Registro de transferencia"
                                    CssClass="btn btn-primary" OnClick="btnRegistroTransferencia_Click" />--%>
                                <asp:LinkButton ID="btnRegistrarActivos" runat="server" Text="<span class='fa fa-file-text-o'></span> Ver detalle de transferencia"
                                    CssClass="btn btn-success" OnClick="btnRegistrarActivos_Click"></asp:LinkButton>
                                <%--<asp:Button ID="btnRegistrarActivos" runat="server" Text="Ver detalle de transferencia"
                                    CssClass="btn btn-primary" OnClick="btnRegistrarActivos_Click" />--%>
                                <asp:LinkButton ID="btnAprobarTransferencia" runat="server" Text="<span class='fa fa-thumbs-o-up'></span> Aprobar Transferencia"
                                    CssClass="btn btn-warning" OnClientClick="return ConfirmaAprobarTransferencia();"></asp:LinkButton>
                                <%--<asp:Button ID="btnAprobarTransferencia" runat="server" Text="Aprobar Transferencia"
                                    CssClass="btn btn-primary" OnClientClick="return ConfirmaAprobarTransferencia();" />--%>

                                <asp:LinkButton ID="btnEliminarTransferencia" runat="server" Text="<span class='fa fa-trash-o'></span> Eliminar Transferencia"
                                    CssClass="btn btn-danger" OnClientClick="return ConfirmaElimina();"></asp:LinkButton>
                               <%-- <asp:Button ID="btnEliminarTransferencia" runat="server" Text="Eliminar Transferencia"
                                    CssClass="btn btn-primary" OnClientClick="return ConfirmaElimina();" />--%>
                            </div>
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <%--    <div id='jqxWidget'>
                                <div id="jqxgrid">
                                </div>
                            </div>--%>
                                    <div>
                                        <dx:ASPxGridView ID="gridTranferencia" runat="server" AutoGenerateColumns="False"
                                            Width="100%" Theme="Metropolis" Caption="Transferencias Realizadas" Font-Size="Small"
                                            OnHtmlRowPrepared="gridTranferencia_HtmlRowPrepared" 
                                            onhtmldatacellprepared="gridTranferencia_HtmlDataCellPrepared" EnableTheming="True">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="id" VisibleIndex="0" FieldName="ID" Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Descripción" VisibleIndex="2" FieldName="descripcion"
                                                    Width="450px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Transferencia" VisibleIndex="3" FieldName="f_transferencia"
                                                    Width="150px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="origen" Caption="Origen" VisibleIndex="4" 
                                                    Width="300px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Monto Bs" VisibleIndex="5" FieldName="monto_bs"
                                                    Width="200px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Tasa Sus" VisibleIndex="11" FieldName="tasa_sus"
                                                    Width="100px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Tasa UFV" VisibleIndex="8" FieldName="tasa_ufv"
                                                    Width="100px">
                                                    <PropertiesTextEdit>
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
                                                <dx:GridViewDataTextColumn Caption="Doc. Respaldo" FieldName="doc_respaldo" VisibleIndex="15"
                                                    Width="250px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Estado Proceso" VisibleIndex="18" FieldName="estado_proceso"
                                                    Width="160px">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular"></RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="id estado proceso" FieldName="fkc_estado_proceso"
                                                    Visible="False" VisibleIndex="16">
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
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                            <SettingsPager PageSize="20">
                                            </SettingsPager>
                                            <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowHorizontalScrollBar="True" />
                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                        <Settings ShowFooter="True" />
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="monto_bs" SummaryType="Sum"  DisplayFormat="Bs {0:0,0.00}"
                                                ShowInColumn="Monto Bs" />
                                             <dx:ASPxSummaryItem FieldName="monto_ufv" SummaryType="Sum"   DisplayFormat="ufv {0:0,0.0000}"
                                                ShowInColumn="Monto UFV" />
                                              <dx:ASPxSummaryItem FieldName="monto_sus" SummaryType="Sum"   DisplayFormat="$us {0:0,0.00}"
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
                    <div id="dangerTransferencias" class="alert alert-danger" role="alert" style="display: none">
                        <strong>Error!</strong>
                    </div>
                    <div id="successTransferencias" class="alert alert-success" role="alert" style="display: none">
                        <strong>Correcto!</strong>
                    </div>
                    <div id="warningTransferencias" class="alert alert-warning" role="alert" style="display: none">
                        <strong>Atencion!</strong>
                    </div>
                </div>
                <div class="row" id="div_RegistroTransferencia" runat="server">
                    <div class="col-md-12">
                        <div id="div1" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Registro de Transferencia</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <asp:LinkButton ID="btnGuardarTransferencia" runat="server" Text="<span class='fa fa-save'></span> Guardar y Continuar"
                                    CssClass="btn btn-primary" OnClick="btnGuardarTransferencia_Click"></asp:LinkButton>
                              <%--  <asp:Button ID="btnGuardarTransferencia" runat="server" Text="Guardar y Continuar"
                                    CssClass="btn btn-primary" OnClick="btnGuardarTransferencia_Click" />--%>
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default"
                                    OnClick="btnCancelar_Click" />
                            </div>
                            <!-- /.box-body -->
                            <div class="box-body">
                                <asp:TextBox  ID="id" runat="server" Visible="false" Enabled="false"></asp:TextBox>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Descripción <font color="red">*</font>
                                        </label>
                                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" placeholder="ejemplo: TRANSFERENCIA DE 3 PIZARRAS ACRILICAS Y 2 PIZARRAS DE CORCHO"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <label for="nombre">
                                            Fecha de Transferencia <font color="red">*</font>
                                        </label>
                                        <input id="dateFechaTransferencia" type="text" name="dateFechaTransferencia" value="" readonly=readonly
                                            class="form-control" placeholder="ejemplo: 01/01/2014" />
                                       
                                    </div>
                                    <div class="col-md-2">
                                        &nbsp;<label for="nombre">Tasa UFV <font color="red">*</font>
                                        </label>
                                        <asp:TextBox ID="txtTasaUFV" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        &nbsp;<label for="nombre">Tasa Dolar <font color="red">*</font>
                                        </label>
                                        <asp:TextBox ID="txtTasaDolar" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        &nbsp;<label for="nombre">Origen<font color="red">*</font></label><asp:TextBox ID="txtOrigen" CssClass="form-control"
                                            placeholder="ejemplo: Ministerio de obras públicas" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        &nbsp;<label for="nombre">Documento Respaldo<font color="red">*</font></label><asp:TextBox ID="txtDocRespaldo"
                                            CssClass="form-control" placeholder="ejemplo:Ref. Informe 01105" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="div_comiteTransferencia" runat="server">
                    <div class="col-md-12">
                        <div id="div2" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Comité de Recepción de Transferencia<font color="red">*</font></h3>
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
                                        Width="100%" Theme="Metropolis" KeyFieldName="ci" AutoGenerateColumns="False" EnableTheming="True"
                                        Caption="Personal">
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
                                            <dx:GridViewDataTextColumn Caption="estado" VisibleIndex="8">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Gerencia" FieldName="gerencia" 
                                                VisibleIndex="5">
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
                                    <strong>Esta seguro que desea eliminar la transferencia?</strong></p>
                                <p>
                                    <small>Las Transferencias que se encuentren en estado aprobado no podran ser eliminadas</small>
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                                <%--<button type="button" class="btn btn-danger" id="deleteConfirm">Delete Notification</button>--%>
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"
                                    OnClick="btnEliminar_Click" />
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
                                    <strong>Esta seguro que desea aprobar la transferencia?</strong></p>
                                <p>
                                    <small>Una vez aprobada la transferencia no podra realizar modificaciones ni eliminar
                                        la transferencia ni en sus activos asignados</small>
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                                <%--<button type="button" class="btn btn-danger" id="deleteConfirm">Delete Notification</button>--%>
                                <asp:Button ID="txtAprobar" runat="server" OnClick="btnAprobarTransferencia_Click"
                                    Text="Aprobar" CssClass="btn btn-danger" />
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
        function ConfirmaElimina() {
            $('#deleteConfirmModal').modal('show');
            return false;

        }
        function ConfirmaAprobarTransferencia() {
            $('#AprobarConfirmModal').modal('show');
            return false;
        }
    </script>
</body>
</html>
