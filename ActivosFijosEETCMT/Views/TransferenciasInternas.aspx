<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferenciasInternas.aspx.cs" Inherits="ActivosFijosEETC.Views.TransferenciasInternas" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

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
                    <i class="fa fa-retweet"></i> Asignación por Transferencia <small>Transferencias entre personal</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li class="active">Transferencias</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row" id="div_Listacompras" runat="server">
                    <div class="col-md-12">
                        <div id="div_Maestro" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Transferencias realizadas</h3>
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
                                <asp:LinkButton ID="btnRegistroTransferencia" runat="server" 
                                    Text="<span class='fa fa-plus'></span> Nueva transferencia" CssClass="btn btn-primary" onclick="btnRegistroTransferencia_Click"></asp:LinkButton>
                             <%--   <asp:Button ID="btnRegistroTransferencia" runat="server" 
                                    Text="Registro de transferencia" CssClass="btn btn-primary" onclick="btnRegistroTransferencia_Click"
                                 />--%>
                                 <asp:LinkButton ID="btnVerDetalleTransferencia" runat="server" 
                                    Text="<span class='fa fa-file-text-o'></span> Ver detalle de transferencia" CssClass="btn btn-success" onclick="btnVerDetalleTransferencia_Click" ></asp:LinkButton>
                              <%--  <asp:Button ID="btnVerDetalleTransferencia" runat="server" 
                                    Text="Ver detalle de transferencia" CssClass="btn btn-primary" onclick="btnVerDetalleTransferencia_Click" 
                                  />--%>
                                  <asp:LinkButton ID="btnAprobarTransferencia" runat="server" 
                                    Text="<span class='fa fa-thumbs-o-up'></span> Aprobar transferencia" CssClass="btn btn-warning" 
                                    OnClientClick="return ConfirmaAprobarAsignacion();" ></asp:LinkButton>
                                  <%--  <asp:Button ID="btnAprobarTransferencia" runat="server" 
                                    Text="Aprobar transferencia" CssClass="btn btn-primary" 
                                    OnClientClick="return ConfirmaAprobarAsignacion();" 
                                     />--%>
                                <asp:LinkButton  ID="btnEliminarTransferencia" runat="server" 
                                    Text="<span class='fa fa-trash-o'></span> Eliminar transferencia" CssClass="btn btn-danger" 
                                     OnClientClick="return ConfirmaElimina();" ></asp:LinkButton>
                                   <%--  <asp:Button ID="btnEliminarTransferencia" runat="server" 
                                    Text="Eliminar transferencia" CssClass="btn btn-primary" 
                                     OnClientClick="return ConfirmaElimina();" 
                                   />--%>
                            </div>
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">

                                 <div>
                                     <dx:ASPxGridView ID="gridTransferencias" runat="server" 
                                         AutoGenerateColumns="False" Width="100%" Theme="Metropolis" 
                                         Caption="Asignaciones por Transferencia" 
                                         onhtmlrowprepared="gridTransferencias_HtmlRowPrepared" 
                                         onhtmldatacellprepared="gridTransferencias_HtmlDataCellPrepared" EnableTheming="True">
                                         <Columns>
                                             <dx:GridViewDataTextColumn Caption="id" VisibleIndex="0" FieldName="id" 
                                                 Visible="False">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="correlativo" VisibleIndex="1" 
                                                 FieldName="correlativo" Width="100px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Ubicacion" VisibleIndex="6" 
                                                 FieldName="ubicacion" Width="200px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Estación" VisibleIndex="8" 
                                                 FieldName="estacion" Width="200px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="id_persona_origen" VisibleIndex="9" 
                                                 FieldName="fk_persona_origen" Visible="False">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="id_persona_destino" VisibleIndex="14" 
                                                 FieldName="fk_persona_destino" Visible="False">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Estado Proceso" VisibleIndex="21" 
                                                 FieldName="estado_proceso" Width="150px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Fecha Transferencia" 
                                                 FieldName="f_transferencia" VisibleIndex="2" Width="100px">
                                                 <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Documento Origen" 
                                                 FieldName="documento_origen" VisibleIndex="10" Width="100px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Nombres Origen" FieldName="nombres_origen" 
                                                 VisibleIndex="11" Width="200px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Apellidos Origen" 
                                                 FieldName="apellidos_origen" VisibleIndex="12" Width="200px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Gerencia Origen" 
                                                 FieldName="gerencia_origen" VisibleIndex="13" Width="250px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Documento Destino" 
                                                 FieldName="documento_destino" VisibleIndex="15" Width="100px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Nombres Destino" 
                                                 FieldName="nombres_destino" VisibleIndex="16" Width="200px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Apellidos Destino" 
                                                 FieldName="apellidos_destino" VisibleIndex="17" Width="200px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Gerencia Destino" 
                                                 FieldName="gerencia_destino" VisibleIndex="18" Width="250px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Línea" FieldName="linea" VisibleIndex="7" 
                                                 Width="200px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="fkc_estado_proceso" VisibleIndex="19" 
                                                 Visible="False">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Motivo de la transferencia" 
                                                 FieldName="motivo" VisibleIndex="3" Width="250px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="fkc_tipo_transferencia" Visible="False" 
                                                 VisibleIndex="4">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Tipo Transferencia" 
                                                 FieldName="tipo_transferencia" VisibleIndex="5" Width="200px">
                                                 <PropertiesTextEdit>
                                                     <ValidationSettings ErrorText="Valor inválido">
                                                         <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                     </ValidationSettings>
                                                 </PropertiesTextEdit>
                                             </dx:GridViewDataTextColumn>
                                         </Columns>
                                         <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                         <Settings ShowHorizontalScrollBar="True" ShowFilterRow="True" 
                                             ShowFilterRowMenu="True" />
<SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                     </dx:ASPxGridView>
                                 </div>
                                </div>
                            </div>
                        </div>
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
                                <asp:LinkButton ID="btnGuardar" runat="server" Text="<span class='fa fa-save'></span> Guardar y Continuar" 
                                    CssClass="btn btn-primary" onclick="btnGuardar_Click" OnClientClick="return Validar();"></asp:LinkButton>
                               <%-- <asp:Button ID="btnGuardar" runat="server" Text="Guardar y Continuar" 
                                    CssClass="btn btn-primary" onclick="btnGuardar_Click" OnClientClick="return Validar();"
                                     />--%>
                                     <asp:LinkButton ID="btnCancelar" runat="server" Text="Cancelar" 
                                    CssClass="btn btn-default" onclick="btnCancelar_Click"></asp:LinkButton>
                               <%-- <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                    CssClass="btn btn-primary" onclick="btnCancelar_Click"  />--%>
                            </div>
                            
                            <!-- /.box-body -->
                          <div class="box-body">
                                        <asp:TextBox ID="id" runat="server" Visible="false" Enabled="false"></asp:TextBox>
                                        <div class="row">
                                            <div class="col-xs-3">
                                                <label for="nombre">
                                                    Fecha de Transferencia <font color="red">*</font>
                                                </label>
                                                <input id="dateFechaTransferencia" type="text" name="dateFechaTransferencia" readonly="readonly"
                                                    value="" class="form-control" placeholder="ejemplo: 01/01/2014" />
                                            </div>
                                            <div class="col-xs-3" id="Div3" runat="server">
                                                <label for="nombre">
                                                    Ubicación <font color="red">*</font>
                                                </label>
                                                <asp:DropDownList ID="ddlUbicacion" CssClass="form-control" runat="server" AppendDataBoundItems="true"
                                                    onchange="HideEstaciones(this);">
                                                    <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                </asp:DropDownList>
                                            </div>
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div class="col-xs-3" id="linea">
                                                        <label for="nombre">
                                                            Línea <font color="red">*</font>
                                                        </label>
                                                        <asp:DropDownList ID="ddlLinea" CssClass="form-control" runat="server" AutoPostBack="True"
                                                            AppendDataBoundItems="true" 
                                                            onselectedindexchanged="ddlLinea_SelectedIndexChanged" >
                                                            <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-xs-3" id="estacion">
                                                        <label for="nombre">
                                                            Estación <font color="red">*</font>
                                                        </label>
                                                        <asp:DropDownList ID="ddlEstacion" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-8">
                                                <label for="nombre">
                                                    Motivo de la transferencia <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control" placeholder="ejemplo: por desvinculación de la empresa"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-4">
                                                <label for="nombre">
                                                   Tipo de transferencia <font color="red">*</font>
                                                </label>
                                                 <asp:DropDownList ID="ddlTipoTransferencia" CssClass="form-control" runat="server" AppendDataBoundItems=true>
                                                     <asp:ListItem Value="-1">Seleccione un item</asp:ListItem>
                                                        </asp:DropDownList>
                                            </div>
                                        </div>


                                    </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="div_origen_destino" runat="server">
                    <div class="col-md-6">
                        <div id="div2" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    ORIGEN  <font color="red">*</font></h3>
                            </div>
                             <div class="alert alert-info alert-dismissable">
                                        <i class="fa fa-info"></i>
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                        <b>Información!</b> Busque y seleccione el la persona ORIGEN que va a transferir los activos.
                                    </div>
                       <div class=" box-body">
                           <dx:ASPxGridView ID="gridPersonalOrigen" runat="server" Width="100%" 
                               AutoGenerateColumns="False" Caption="Personal Origen" EnableTheming="True" 
                               Theme="Aqua">
                               <Columns>
                                   <dx:GridViewCommandColumn VisibleIndex="0">
                                       <ClearFilterButton Visible="True">
                                       </ClearFilterButton>
                                   </dx:GridViewCommandColumn>
                                   <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="False" 
                                       VisibleIndex="1">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Doc. Identidad" FieldName="documento" 
                                       VisibleIndex="2">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Nombres" FieldName="nombres" 
                                       VisibleIndex="3">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Apellidos" FieldName="apellidos" 
                                       VisibleIndex="4">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Area" FieldName="area" VisibleIndex="5">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Gerencia" FieldName="gerencia" 
                                       VisibleIndex="6">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Estado" FieldName="estado" VisibleIndex="7" 
                                       Visible="False">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                               </Columns>
                               <SettingsBehavior AllowFocusedRow="True" />
                               <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
<SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                           </dx:ASPxGridView>
                       </div>
                        </div>
                    </div>
              


                    <div class="col-md-6">
                        <div id="div5" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    DESTINO  <font color="red">*</font></h3>
                            </div>
                             <div class="alert alert-info alert-dismissable">
                                        <i class="fa fa-info"></i>
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                        <b>Información!</b> Busque y seleccione el la persona DESTINO que va a transferir los activos.
                                    </div>
                       <div class=" box-body">
                           <dx:ASPxGridView ID="gridPersonalDestino" runat="server" Width="100%" 
                               AutoGenerateColumns="False" Caption="Personal Destino" EnableTheming="True" 
                               Theme="Aqua">
                               <Columns>
                                   <dx:GridViewCommandColumn VisibleIndex="0">
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
                                   <dx:GridViewDataTextColumn Caption="Doc. Identidad" FieldName="documento" 
                                       VisibleIndex="2">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Nombres" FieldName="nombres" 
                                       VisibleIndex="3">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Apellidos" FieldName="apellidos" 
                                       VisibleIndex="4">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Area" FieldName="area" VisibleIndex="5">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Gerencia" FieldName="gerencia" 
                                       VisibleIndex="6">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Estado" FieldName="estado" VisibleIndex="7" 
                                       Visible="False">
                                       <PropertiesTextEdit>
                                           <ValidationSettings ErrorText="Valor inválido">
                                               <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                           </ValidationSettings>
                                       </PropertiesTextEdit>
                                   </dx:GridViewDataTextColumn>
                               </Columns>
                               <SettingsBehavior AllowFocusedRow="True" />
                               <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
<SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                           </dx:ASPxGridView>
                       </div>
                        </div>
                    </div>
                </div>


    <div class="modal fade" id="deleteConfirmModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title" id="deleteLabel">Notificacion de eliminacion</h4>
            </div>
            <div class="modal-body">
                <p><strong>Esta seguro que desea eliminar la transferencia?</strong></p>
                <p><small>
                    Las transferencias que se encuentren en estado TRANSFERIDO No podran ser eliminadas</small>
                </p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                <%--<button type="button" class="btn btn-danger" id="deleteConfirm">Delete Notification</button>--%>
                <asp:Button ID="btnEliminar" runat="server" 
                                    Text="Eliminar" CssClass="btn btn-danger"   onclick="btnEliminarTransferencia_Click"
                                   />
            </div>
        </div>
    </div>
</div>


<div class="modal fade" id="AprobarConfirmModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title" id="H1">Notificacion de Aprobacion</h4>
            </div>
            <div class="modal-body">
                <p><strong>Esta seguro que desea aprobar la Transferencia?</strong></p>
                <p><small>
                    Una vez aprobada la transferencia No podra realizar modificaciones en la Transferencia</small>
                </p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                <%--<button type="button" class="btn btn-danger" id="deleteConfirm">Delete Notification</button>--%>
                <asp:Button ID="btnAprobar" runat="server" 
                                    Text="Aprobar" CssClass="btn btn-danger" onclick="btnAprobar_Click" 
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
        function HideEstaciones(ddlId) {
            var ControlName = document.getElementById(ddlId.id);

            if (ControlName.value == 11)  //it depends on which value Selection do u want to hide or show your textbox 
            {
                document.getElementById('linea').style.display = 'none';
                document.getElementById('estacion').style.display = 'none';

            }
            else {
                document.getElementById('linea').style.display = '';
                document.getElementById('estacion').style.display = '';

            }
        }



        $(document).ready(function () {

            $('#dateFechaTransferencia').datepicker({
                format: 'dd-mm-yyyy',
                clearBtn: true,
                language: "es",
                calendarWeeks: true,
                autoclose: true,
                todayHighlight: true
            });
        });
    </script>

    <script type="text/javascript">

        function ConfirmaAprobarAsignacion() {
            $('#AprobarConfirmModal').modal('show');
            return false;
        }

        function ConfirmaElimina() {
            $('#deleteConfirmModal').modal('show');
            return false;

        }

        function Validar() {
            var error = 0;

            if (document.getElementById('dateFechaTransferencia').value == '' || document.getElementById('<%=ddlUbicacion.ClientID %>').value == '-1' || document.getElementById('<%=ddlTipoTransferencia.ClientID %>').value == '-1' || document.getElementById('<%=txtMotivo.ClientID %>').value == '') {
                error = 1;
            }

            if ((document.getElementById('<%=ddlUbicacion.ClientID %>').value != '11' && document.getElementById('<%=ddlLinea.ClientID %>').value == '-1') || (document.getElementById('<%=ddlTipoTransferencia.ClientID %>').value == '-1' || document.getElementById('<%=txtMotivo.ClientID %>').value == '')) {
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
</body>
</html>
