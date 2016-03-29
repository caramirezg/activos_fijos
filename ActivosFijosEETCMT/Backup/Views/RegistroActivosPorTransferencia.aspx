<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroActivosPorTransferencia.aspx.cs" Inherits="ActivosFijosEETC.Views.RegistroActivosPorTransferencia" %>

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
        document.write('<script src="js/Transferencias.js" type="text/javascript"><\/script>');   
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
     <script src="js/jquery.numeric.js" type="text/javascript"></script>
  

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
                   <i class="fa fa-share"></i> Activos <small>Registro de Activos por Transferencia</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Activos</a></li>
                    <li class="active">Registro de activos por Transferencia</li>
                </ol>
            </section>
            <form id="Form1" runat=server>
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    DATOS DE TRANSFERENCIA</h3>
                            </div>
                            <!-- /.box-header -->
                            <!-- form start -->
                            <div class="box-body">
                                <asp:LinkButton ID="btnVerTransferencias" runat="server" Text="<span class='fa fa-retweet'></span> Ver Transferencias" 
                                        CssClass="btn btn-primary" onclick="btnVerTransferencias_Click"></asp:LinkButton>
                                   <%-- <asp:Button ID="btnVerTransferencias" runat="server" Text="Ver Transferencias" 
                                        CssClass="btn btn-primary" onclick="btnVerTransferencias_Click" />--%>
                                <asp:LinkButton ID="btnImprimir" runat="server" Text="<span class='fa fa-print'></span> Imprimir Transferencia" 
                                        CssClass="btn btn-warning" onclick="btnImprimir_Click"></asp:LinkButton>
                                       <%--  <asp:Button ID="btnImprimir" runat="server" Text="Imprimir Transferencia" 
                                        CssClass="btn btn-primary" onclick="btnImprimir_Click" />--%>
                                </div>
                            <div class="box-body">
                                <asp:TextBox CssClass="hidden" ID="txtCodigoTransferencia" runat="server"></asp:TextBox>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Descripción</label>
                                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" ReadOnly=true
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3">
                                        <label for="nombre">
                                            Fecha de Transferencia</label>
                                       <asp:TextBox ID="txtFechaTransferencia" CssClass="form-control"
                                            ReadOnly="true" runat="server" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        &nbsp;<label for="nombre">Tasa UFV</label><asp:TextBox ID="txtTasaUFV" CssClass="form-control"
                                            ReadOnly="true" runat="server" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        &nbsp;<label for="nombre">Tasa Sus</label><asp:TextBox ID="txtTasaSus" CssClass="form-control"
                                            ReadOnly=true runat="server" ></asp:TextBox>
                                    </div>
                                   <div class="col-xs-3">
                                        &nbsp;<label for="nombre">Documento de Respaldo</label><asp:TextBox ID="txtDocumentoRespaldo"
                                            CssClass="form-control" ReadOnly=true runat="server"></asp:TextBox>
                                    </div>
                                     <div class="col-xs-3">
                                        &nbsp;<label for="nombre">Origen</label><asp:TextBox ID="txtOrigen"
                                            CssClass="form-control" ReadOnly=true runat="server"></asp:TextBox>
                                    </div>
                                </div>
                              
                            </div>
                        </div>
                        <!-- /.box-body -->
           
                            <div class="box box-primary">
                                <div class="box-header">
                                    <h3 class="box-title">
                                        DATOS DEL ACTIVO</h3>
                                </div>
                                <!-- /.box-header -->
                                <!-- form start -->
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                

                                <div class="box-body">
                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server"> 
                                     <ContentTemplate> 

                                <div class="row">
                                 <div class="col-xs-12">
                                            <label for="nombre">
                                                Descripción <font color="red">*</font></label>
                                     <asp:TextBox ID="txtDescripcionTransferenciaActivo" runat="server" CssClass="form-control" placeholder="ejemplo: Monitor marca hp color negro"></asp:TextBox>
                                    
                                         <%--  <asp:TextBox ID="txtDescripcionActivo" runat="server" CssClass="form-control" placeholder="ejemplo: Monitor marca hp color negro"></asp:TextBox>--%>
                                        </div>
                                </div>

                              
                                    <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server"> 
                                     <ContentTemplate> 
                                        <div class="col-xs-3">
                                            <label for="nombre">
                                                Grupo Contable <font color="red">*</font></label>
                                              <%--   <select id="ddlGrupoContable" name="ddlGrupoContable" class="form-control">
                                                    <option value="">Seleccione un grupo contable</option>
                                                </select>--%>
                                                 <asp:DropDownList ID="ddlGrupoContable" runat="server"
                                                CssClass="form-control" 
                                                AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlGrupoContable_SelectedIndexChanged"
                                                >
                                                <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                </asp:DropDownList>
                                            
                                        </div>
                                        <div class="col-xs-3">
                                            <label for="nombre">
                                                Auxiliar Contable <font color="red">*</font></label>
                                          
                                                    <asp:DropDownList ID="ddlAuxiliarContable" runat="server" 
                                                        CssClass="form-control" AppendDataBoundItems="True">
                                                          <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                    </asp:DropDownList>
                                               
                                    <%--     <select id="ddlAuxiliarContable" name="ddlAuxiliarContable" class="form-control">
                                                    <option value="">Seleccione un auxiliar contable</option>
                                                </select>--%>
                                            
                                        </div>
                                        </ContentTemplate>
                                        <Triggers> 
                                        <asp:AsyncPostBackTrigger ControlID="ddlGrupoContable" EventName="SelectedIndexChanged" /> 
                                        </Triggers> 
                                        </asp:UpdatePanel>

                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
                                     <ContentTemplate> 
                                        <div class="col-xs-3">
                                            <label for="nombre">
                                                Marca <font color="red">*</font></label>
                                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control" 
                                                AppendDataBoundItems="True" AutoPostBack="True" onselectedindexchanged="ddlMarca_SelectedIndexChanged" 
                                                 >
                                                  <asp:ListItem Text="Seleccione un item" Value="-1" /></asp:DropDownList>

                                          <%--    <select id="ddlMarca" name="ddlMarca" class="form-control">
                                                    <option value="">Seleccione una marca</option>
                                                </select>--%>

                                        </div>

                                        <div class="col-xs-3">
                                            <label for="nombre">
                                                Modelo <font color="red">*</font></label>
                                        <%--         <select id="ddlModelo" name="ddlModelo" class="form-control">
                                                    <option value="">Seleccione un modelo</option>
                                                </select>--%>
                                          
                                                    <asp:DropDownList ID="ddlModelo" runat="server" CssClass="form-control" 
                                                AppendDataBoundItems="True">
                                                     <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                    </asp:DropDownList>
                                               

                                        </div>
                                        </ContentTemplate>
                                         <Triggers> 
                                        <asp:AsyncPostBackTrigger ControlID="ddlMarca" EventName="SelectedIndexChanged" /> 
                                        </Triggers> 
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="row">
                                       
                                        <div class="col-xs-2">
                                            <label for="nombre">
                                                Nro. Serie <font color="red">*</font></label>
                                           <asp:TextBox ID="txtSerie" runat="server" CssClass="form-control" placeholder="ejemplo: XYD001EF501"></asp:TextBox>

                                        </div>
                                        <div class="col-xs-2">
                                            <label for="nombre">
                                                Costo Bs <font color="red">*</font></label>
                                            <asp:TextBox ID="txtValorInicial" runat="server" CssClass="form-control" placeholder="ejemplo: 1500.50 Bs"></asp:TextBox>
                                        </div>
                                        
                                    
                                      
                                         
                                    </div>
                                   </ContentTemplate>
                               </asp:UpdatePanel>
                               </div>
                          
                          <asp:updatepanel runat="server">
    <contenttemplate>
                        <div class=box-body>
                        <div id="danger" class="alert alert-danger" role="alert" style="display: none">
                                                <strong>Error!</strong>
                                                </div>
                                                <div id="success" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Correcto!</strong>
                                </div>
                                <div id="warning" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Atencion!</strong>
                                </div>
                        <div class="alert alert-info alert-dismissable">
                                        <i class="fa fa-info"></i>
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                        <b>Información! </b>Al agregar un activo nuevo se creara automáticamente su código 
                                    </div>
                                    </div>
                         <div class="box-footer" id="actionActivos" runat=server>
                             <asp:LinkButton ID="btnRegistrarActivo" CssClass="btn btn-primary" runat="server" 
                                 Text="<span class='fa fa-save'></span> Registrar Activo" onclick="btnRegistrarActivo_Click"  OnClientClick="return Validar();"></asp:LinkButton>
                            <%-- <asp:Button ID="btnRegistrarActivo" CssClass="btn btn-primary" runat="server" 
                                 Text="Registrar Activo" onclick="btnRegistrarActivo_Click"  OnClientClick="return Validar();"/>--%>
                             <asp:LinkButton ID="btnDuplicarActivo" CssClass="btn btn-warning" runat="server" 
                                 Text="Duplicar" onclick="btnDuplicarActivo_Click"></asp:LinkButton>
                               <%--  <asp:Button ID="btnDuplicarActivo" CssClass="btn btn-primary" runat="server" 
                                 Text="Duplicar" onclick="btnDuplicarActivo_Click" />--%>
                             <asp:LinkButton ID="btnEliminar" CssClass="btn btn-danger" runat="server" 
                                 Text="<span class='fa fa-trash-o'></span> Eliminar" OnClientClick="return ConfirmaElimina();" 
                                 onclick="btnEliminar_Click"></asp:LinkButton>

                              <%--   <asp:Button ID="btnEliminar" CssClass="btn btn-primary" runat="server" 
                                 Text="Eliminar" OnClientClick="return ConfirmaElimina();" 
                                 onclick="btnEliminar_Click"   />--%>
                        </div>
                        </contenttemplate>
</asp:updatepanel>
                        <div class="box-footer" id="idBarCode" runat=server>
                            <asp:LinkButton ID="btnPrintBarcode" CssClass="btn btn-default" runat="server" 
                                 Text="<span class='fa fa-barcode'></span> Imprimir codigo de barras individual" 
                                onclick="btnPrintBarcode_Click"></asp:LinkButton>
                       <%-- <asp:Button ID="btnPrintBarcode" CssClass="btn btn-primary" runat="server" 
                                 Text="Imprimir codigo de barras individual" 
                                onclick="btnPrintBarcode_Click" />--%>
                            <asp:LinkButton ID="btnPrintBarcodeAll" CssClass="btn btn-primary" runat="server" 
                                 Text="<span class='fa fa-barcode'></span> Imprimir codigo de barras transferencia" onclick="btnPrintBarcodeAll_Click" ></asp:LinkButton>
                                <%-- <asp:Button ID="btnPrintBarcodeAll" CssClass="btn btn-primary" runat="server" 
                                 Text="Imprimir codigo de barras transferencia" onclick="btnPrintBarcodeAll_Click" 
                                />--%>
                        </div>
                   <asp:updatepanel runat="server">
    <contenttemplate>
                        <div class="box">
                        <div class="box-body table-responsive">
                            <dx:ASPxGridView ID="GridActivosPorTransferencia" runat="server" AutoGenerateColumns="False" 
                                EnableTheming="True" Theme="Aqua" Width="100%" KeyFieldName="id" 
                                Caption="Activos Registrados" 
                                onhtmldatacellprepared="GridActivosPorTransferencia_HtmlDataCellPrepared">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="Código Activo" VisibleIndex="1" 
                                        FieldName="codigo" Width="200px">
                                        <PropertiesTextEdit>
                                            <ValidationSettings ErrorText="Valor inválido">
                                                <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                            </ValidationSettings>
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn VisibleIndex="5" FieldName="fk_grupo_contable" 
                                        Visible="False">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Grupo Contable" VisibleIndex="6" 
                                        FieldName="grupo_contable" Width="200px">
                                        <PropertiesTextEdit>
                                            <ValidationSettings ErrorText="Valor inválido">
                                                <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                            </ValidationSettings>
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn VisibleIndex="7" FieldName="fk_auxiliar_contable" 
                                        Visible="False">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Auxiliar Contable" VisibleIndex="8" 
                                        FieldName="auxiliar_contable" Width="200px">
                                        <PropertiesTextEdit>
                                            <ValidationSettings ErrorText="Valor inválido">
                                                <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                            </ValidationSettings>
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn VisibleIndex="9" 
                                        FieldName="fk_marca" Visible="False">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Marca" VisibleIndex="10" 
                                        FieldName="marca" Width="200px">
                                        <PropertiesTextEdit>
                                            <ValidationSettings ErrorText="Valor inválido">
                                                <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                            </ValidationSettings>
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn VisibleIndex="11" FieldName="fk_modelo" 
                                        Visible="False">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Modelo" FieldName="modelo" 
                                        VisibleIndex="12" Width="200px">
                                        <PropertiesTextEdit>
                                            <ValidationSettings ErrorText="Valor inválido">
                                                <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                            </ValidationSettings>
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" 
                                        VisibleIndex="13" Width="150px">
                                        <PropertiesTextEdit>
                                            <ValidationSettings ErrorText="Valor inválido">
                                                <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                            </ValidationSettings>
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" 
                                        VisibleIndex="4" Width="300px">
                                        <PropertiesTextEdit>
                                            <ValidationSettings ErrorText="Valor inválido">
                                                <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                            </ValidationSettings>
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Fecha Registro" FieldName="f_registro" 
                                        VisibleIndex="14" Width="200px">
                                        <PropertiesTextEdit>
                                            <ValidationSettings ErrorText="Valor inválido">
                                                <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                            </ValidationSettings>
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="fkc_estado_proceso" Visible="False" 
                                        VisibleIndex="15">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Estado Proceso" FieldName="estado_proceso" 
                                        VisibleIndex="24" Width="150px">
                                        <PropertiesTextEdit>
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
                                    <dx:GridViewDataTextColumn Caption="Costo Bs" FieldName="valor_inicial" 
                                        VisibleIndex="16" Width="200px">
                                        <PropertiesTextEdit>
                                            <ValidationSettings ErrorText="Valor inválido">
                                                <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                            </ValidationSettings>
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                <Settings ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True" />
<SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>

 <Settings ShowFooter="True" />
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="valor_inicial" SummaryType="Sum" 
               DisplayFormat="Bs {0:0,0.00}" ShowInColumn="Costo Bs" />
            <dx:ASPxSummaryItem FieldName="valor_inicial_ufv" SummaryType="Sum" 
              DisplayFormat="UFV {0:0,0.0000}"  ShowInColumn="Costo UFV" />
                <dx:ASPxSummaryItem FieldName="valor_inicial_sus" SummaryType="Sum" 
              DisplayFormat="$us {0:0,0.00}"  ShowInColumn="Costo SUS" />
        </TotalSummary>

                            </dx:ASPxGridView>



                        </div>
                       </div>
                       </contenttemplate>
</asp:updatepanel>
                    </div>
                  
                </div>


                 <!-- Modal HTML -->
    <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Información</h4>
                </div>
                <div class="modal-body">
                    <p>Por favor revise los datos faltantes</p>
                
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>


     <!-- Modal HTML -->
    <div id="myModal2" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Confirmación</h4>
                </div>
                <div class="modal-body">
                    <p>Está seguro que desea guardar los datos de la compra de activos?</p>
                    <p class="text-warning"><small>Si no guarda, los cambios se perderán.</small></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary">Guardar</button>
                </div>
            </div>
        </div>
    </div>


    <!-- /.box -->
    </section> 
    </form>
    </aside> </div>
    <!-- ./wrapper -->
    <script type="text/javascript">
//        function TestOnTextChange() {
//            //Your Code

//            var costo_bs = document.getElementById("txtValorInicial").value;
//            var tasa_ufv = document.getElementById("txtTasaUFV").value.toString().replace(/\,/g, '.'); 
//            var tasa_sus = document.getElementById("txtTasaSus").value.toString().replace(/\,/g, '.'); 



//            var result_ufv = parseFloat(costo_bs) / parseFloat(tasa_ufv);
//            var result_sus = parseFloat(costo_bs) / parseFloat(tasa_sus);

//            var result_ufv = Math.round(result_ufv * Math.pow(10, 5)) / Math.pow(10, 5);
//            var result_sus = Math.round(result_sus * Math.pow(10, 2)) / Math.pow(10, 2);
//            result_ufv = result_ufv.toFixed(5);
//            result_sus = result_sus.toFixed(2);

//            $('#txtCostoUfv').val(result_ufv);
//            $('#txtCostoUfv').priceFormat({
//                prefix: '',
//                thousandsSeparator: '',
//                centsSeparator: ',',
//                centsLimit: 5
//            });
//            $('#txtCostoSus').val(result_sus);
//            $('#txtCostoSus').priceFormat({
//                prefix: '',
//                thousandsSeparator: '',
//                centsSeparator: ',',
//                centsLimit: 2
//            });
//        }
</script>

<script type="text/javascript">

    $(document).ready(function () {

        $("#txtValorInicial").numeric();

    });


    function Validar() {
        var error = 0;

        if (document.getElementById('<%=txtDescripcionTransferenciaActivo.ClientID %>').value == '' || document.getElementById('<%=ddlGrupoContable.ClientID %>').value == '-1' || document.getElementById('<%=ddlAuxiliarContable.ClientID %>').value == '-1' ||
            document.getElementById('<%=txtSerie.ClientID %>').value == '' || document.getElementById('<%=ddlMarca.ClientID %>').value == '-1' || document.getElementById('<%=ddlModelo.ClientID %>').value == '-1' ||
            document.getElementById('<%= txtValorInicial.ClientID %>').value == '') {
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

    $(function () {

        $("#txtValorInicial").Decimales();
    });

    </script>
    <script type="text/javascript">
        function ConfirmaElimina() {
            if (confirm("¿Está seguro de que quiere eliminar el registro?"))
                return true;
            else return false;
        }
    </script>
</body>
</html>