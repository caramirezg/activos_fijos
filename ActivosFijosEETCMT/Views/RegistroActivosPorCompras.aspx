<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroActivosPorCompras.aspx.cs"
    Inherits="ActivosFijosEETC.Views.RegistroActivosPorCompras" %>

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
    <script type="text/javascript">
        document.write('<script src="js/RegistroActivos.js" type="text/javascript"><\/script>');   
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
<%--    <script src="js/jquery.plugins.js" type="text/javascript"></script>--%>
    <script src="js/plugins/jquery.price_format.2.0.min.js" type="text/javascript"></script>
    <script src="js/jquery.numeric.js" type="text/javascript"></script>
</head>
<body class="skin-blue">
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
                    <span class='fa fa-file-text-o'></span> Activos <small>Registro de Activos por Compras</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Activos</a></li>
                    <li class="active">Registro de activos por Compras</li>
                </ol>
            </section>
            <form runat="server">

         


            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    DATOS DE COMPRA</h3>
                            </div>
                            <!-- /.box-header -->
                            <!-- form start -->
                             <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            
                            <div class="box-body">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        
                                        <asp:LinkButton ID="btnVerCompras" runat="server" Text="<span class='fa fa-shopping-cart'></span> Ver Compras" CssClass="btn btn-primary"
                                    OnClick="btnVerCompras_Click"></asp:LinkButton>

                               <%-- <asp:Button ID="btnVerCompras" runat="server" Text="Ver Compras" CssClass="btn btn-primary"
                                    OnClick="btnVerCompras_Click" />--%>
                                   
                                        <asp:LinkButton ID="btnImprimir" runat="server" Text="<span class='fa fa-print'></span> Imprimir Informe" CssClass="btn btn-warning"
                                    OnClick="btnImprimir_Click"></asp:LinkButton>
                                <%--<asp:Button ID="btnImprimir" runat="server" Text="Imprimir Informe" CssClass="btn btn-primary"
                                    OnClick="btnImprimir_Click" />--%>
                                       </ContentTemplate>
                                       <Triggers>
                                       <asp:PostBackTrigger ControlID="btnImprimir" />
                                       </Triggers>
                                </asp:UpdatePanel>    
                            </div>
                           
                            <div class="box-body">
                                <asp:TextBox  ID="txtCodigoCompra" runat="server" Visible="false" Enabled="false"></asp:TextBox>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Descripción</label>
                                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3">
                                        <label for="nombre">
                                            Fecha de Registro</label>
                                        <asp:TextBox ID="txtFechaRegistro" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        &nbsp;<label for="nombre">Tasa UFV</label><asp:TextBox ID="txtTasaUFV" CssClass="form-control"
                                            ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        &nbsp;<label for="nombre">Tasa Sus</label><asp:TextBox ID="txtTasaSus" CssClass="form-control"
                                            ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        &nbsp;<label for="nombre">Nro. Factura</label><asp:TextBox ID="txtNroFactura" CssClass="form-control"
                                            ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <label for="nombre">
                                            <asp:TextBox ID="txtIdGerenciaSolicitante" CssClass="form-control" ReadOnly="true"
                                                runat="server" Visible="False"></asp:TextBox>
                                            Gerencia Solicitante</label><asp:TextBox ID="txtGerenciaSolicitante" CssClass="form-control"
                                                ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3">
                                        &nbsp;<label for="nombre">Documento Respaldo</label><asp:TextBox ID="txtDocRespaldo"
                                            CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <label for="nombre">
                                            Proveedor</label>
                                        <asp:TextBox ID="txtIdProveedor" CssClass="form-control" ReadOnly="true" runat="server"
                                            Visible="False"></asp:TextBox>
                                        <asp:TextBox ID="txtProveedor" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtIdFuenteFinanciamiento" CssClass="form-control" ReadOnly="true"
                                            Visible="false" runat="server"></asp:TextBox>
                                        <label for="nombre">
                                            Fuente de Financiamiento</label><asp:TextBox ID="txtFuenteFinanciamiento" CssClass="form-control"
                                                ReadOnly="true" runat="server"></asp:TextBox>
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
                            <div class="box-body">
                                <!-- /.box-header -->
                                <!-- form start -->
                        
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <label for="nombre">
                                                    Descripción <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtDescripcionActivo" runat="server" CssClass="form-control" placeholder="ejemplo: Monitor marca hp color negro"></asp:TextBox>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-3">
                                                <label for="nombre">
                                                    Grupo Contable <font color="red">*</font>
                                                </label>
                                                <%--   <select id="ddlGrupoContable" name="ddlGrupoContable" class="form-control">
                                                    <option value="">Seleccione un grupo contable</option>
                                                </select>--%>
                                                <asp:DropDownList ID="ddlGrupoContable" runat="server" CssClass="form-control" AppendDataBoundItems="True"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlGrupoContable_SelectedIndexChanged">
                                                    <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                                <label for="nombre">
                                                    Auxiliar Contable <font color="red">*</font>
                                                </label>
                                                <asp:DropDownList ID="ddlAuxiliarContable" runat="server" CssClass="form-control"
                                                    AppendDataBoundItems="True">
                                                    <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                </asp:DropDownList>
                                               
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlGrupoContable" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-2">
                                                <label for="nombre">
                                                    Marca <font color="red">*</font>
                                                </label>
                                                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control" AppendDataBoundItems="True"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged">
                                                    <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2">
                                                <label for="nombre">
                                                    Modelo <font color="red">*</font>
                                                </label>
                                                <asp:DropDownList ID="ddlModelo" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                    <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2">
                                                <label for="nombre">
                                                    Nro. Serie <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtSerie" runat="server" CssClass="form-control" placeholder="ejemplo: XYD001EF501"></asp:TextBox>
                                            </div>

                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlMarca" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="row">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                              <div class="col-md-2">
                                               <div class="form-group has-warning">
                                                 <label class="control-label" for="inputWarning"><i class="fa fa-warning"></i> Vida Útil Alterna</label>
                                                <asp:TextBox ID="txtVidaUtilEspecifica" runat="server" onkeyup="TestOnTextChange()" CssClass="form-control" ToolTip="Este campos es unicamente para activos que tengan vida util diferente a la vida util genérica"
                                                    placeholder="ejemplo: 10"></asp:TextBox>
                                                    </div>
                                            </div>

                                            <div class="col-md-2">
                                                <label for="nombre">
                                                    Costo<font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtValorInicial" runat="server" onkeyup="TestOnTextChange()" CssClass="form-control"
                                                    placeholder="ejemplo: 1500.50 Bs"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                <label for="nombre">
                                                    Gastos con Crédito Fiscal <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtGastosConCreditoFiscal" runat="server" CssClass="form-control" onkeyup="TestOnTextChange();" Text="0"></asp:TextBox>
                                              
                                            </div>
                                            <div class="col-md-2">
                                                <label for="nombre">
                                                    Gastos Sin Crédito Fiscal <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtGastosSinCreditoFiscal" runat="server" CssClass="form-control" onkeyup="TestOnTextChange();" Text="0"></asp:TextBox>
                                            </div>
                                           

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                     
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                        <div class="col-md-2">
                                                <label for="nombre">
                                                    Valor Inicial <font color="red"></font>
                                                </label>
                                                <asp:TextBox ID="txtValorInicialCalculado" runat="server" CssClass="form-control" ReadOnly=true></asp:TextBox>
                                            </div>
                                            <div class="col-md-1">
                                                <label for="nombre">
                                                    Inicio Garantia</label>
                                                <input id="dateInicioGarantia" type="text" name="dateInicioGarantia" class="form-control"
                                                    runat="server"  placeholder="ejemplo: 01/01/2014" />
                                            </div>
                                            <div class="col-md-1">
                                                <label for="nombre">
                                                    Fin Garantia</label>
                                                <input id="dateFinGarantia" type="text" name="dateFinGarantia" value="" class="form-control"
                                                    runat="server" placeholder="ejemplo: 01/01/2014" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="box-body">
                                    <div id="danger" class="alert alert-danger" role="alert" style="display: none">
                                        <strong>Error!</strong>
                                    </div>
                                    <div id="success" class="alert alert-success" role="alert" style="display: none">
                                        <strong>Correcto!</strong>
                                    </div>
                                    <div id="warning" class="alert alert-success" role="alert" style="display: none">
                                        <strong>Atencion!</strong>
                                    </div>
                                    
                                     <div class="callout callout-info">
                                        <h4>Alerta Vida Util!</h4>
                                        <p>La vida util alterna debe ser llenada excepcionalmente para activos diferentes de su vida util generica</p>
                                    </div>
                                </div>
                                 <asp:UpdatePanel runat="server" ID="updateButtons">
                                    <ContentTemplate>
                                <div class="box-footer" id="idBarCode" runat="server">
                                    <asp:LinkButton ID="btnPrintBarcode" CssClass="btn btn-default" runat="server" Text="<span class='fa fa-barcode'></span> Imprimir codigo de barras individual"
                                        OnClick="btnPrintBarcode_Click"></asp:LinkButton>
                               
                                   <%-- <asp:Button ID="btnPrintBarcode" CssClass="btn btn-primary" runat="server" Text="Imprimir codigo de barras individual"
                                        OnClick="btnPrintBarcode_Click" />--%>

                                    <asp:LinkButton ID="btnPrintBarcodeAll" CssClass="btn btn-primary" runat="server" Text="<span class='fa fa-barcode'></span> Imprimir codigo de barras compra"
                                        OnClick="btnPrintBarcodeAll_Click"></asp:LinkButton>
                                 <%--   <asp:Button ID="btnPrintBarcodeAll" CssClass="btn btn-primary" runat="server" Text="Imprimir codigo de barras compra"
                                        OnClick="btnPrintBarcodeAll_Click" />--%>
                                </div>
                              
                                        <div class="box-footer" id="actionActivos" runat="server">
                                            <asp:LinkButton ID="btnRegistrarActivo" CssClass="btn btn-primary" runat="server" Text="<span class='fa fa-save'></span> Registrar Activo"
                                                OnClick="btnRegistrarActivo_Click" OnClientClick="return Validar();"></asp:LinkButton>
                                                
                                            <%--<asp:Button ID="btnRegistrarActivo" CssClass="btn btn-primary" runat="server" Text="Registrar Activo"
                                                OnClick="btnRegistrarActivo_Click" OnClientClick="return Validar();" />--%>

                                            <asp:LinkButton ID="btnDuplicarActivo" CssClass="btn btn-warning" runat="server" Text="<span class='fa fa-files-o'></span> Duplicar"
                                                OnClick="btnDuplicarActivo_Click"></asp:LinkButton>
                                         <%--   <asp:Button ID="btnDuplicarActivo" CssClass="btn btn-warning" runat="server" Text="<span class='fa fa-files-o'></span> Duplicar"
                                                OnClick="btnDuplicarActivo_Click" />--%>

                                            <asp:LinkButton ID="btnEditar" CssClass="btn btn-default" runat="server" 
                                                Text="<span class='fa fa-pencil'></span> Editar" onclick="btnEditar_Click"></asp:LinkButton>
                                                     <%--   <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" 
                                                Text="Editar" onclick="btnEditar_Click"
                                                 />--%>
                                            <asp:LinkButton ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="<span class='fa fa-trash-o'></span>  Eliminar"
                                                OnClick="btnEliminar_Click" OnClientClick="return ConfirmaElimina();"></asp:LinkButton>
                                        <%--    <asp:Button ID="btnEliminar" CssClass="btn btn-primary" runat="server" Text="Eliminar"
                                                OnClick="btnEliminar_Click" OnClientClick="return ConfirmaElimina();" />--%>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                       <asp:AsyncPostBackTrigger ControlID="btnEditar" EventName="click"/>
                                        <asp:PostBackTrigger ControlID="btnPrintBarcode" />
                                        <asp:PostBackTrigger ControlID="btnPrintBarcodeAll" />
                                    </Triggers>
                                </asp:UpdatePanel>
                        
                               

                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="box">
                                            <div class="box-body table-responsive">
                                                <dx:ASPxGridView ID="GridActivosPorCompra" runat="server" AutoGenerateColumns="False"
                                                    EnableTheming="True" Theme="Aqua" Width="100%" KeyFieldName="id" Caption="Activos Registrados"
                                                    OnCustomUnboundColumnData="GridActivosPorCompra_CustomUnboundColumnData" OnHtmlDataCellPrepared="GridActivosPorCompra_HtmlDataCellPrepared">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn VisibleIndex="0">
                                                            <ClearFilterButton Visible="True">
                                                            </ClearFilterButton>
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn Caption="Código Activo" VisibleIndex="2" FieldName="codigo"
                                                            Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="fk_grupo_contable" 
                                                            Visible="False">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                                    <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                                    </RegularExpression>
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Grupo Contable" VisibleIndex="5" FieldName="grupo_contable"
                                                            Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="8" FieldName="fk_auxiliar_contable" 
                                                            Visible="False">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                                    <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                                    </RegularExpression>
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Auxiliar Contable" VisibleIndex="9" FieldName="auxiliar_contable"
                                                            Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="10" FieldName="fk_marca" 
                                                            Visible="False">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                                    <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                                    </RegularExpression>
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Marca" VisibleIndex="11" FieldName="marca" 
                                                            Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="12" FieldName="fk_modelo" 
                                                            Visible="False">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                                    <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                                    </RegularExpression>
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Modelo" FieldName="modelo" VisibleIndex="13"
                                                            Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" VisibleIndex="14" 
                                                            Width="150px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="3"
                                                            Width="300px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Fecha Registro" FieldName="f_registro" VisibleIndex="15"
                                                            Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="fkc_estado_proceso" Visible="False" 
                                                            VisibleIndex="16">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                                    <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                                    </RegularExpression>
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Estado Proceso" FieldName="estado_proceso" VisibleIndex="28"
                                                            Width="150px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="False" 
                                                            VisibleIndex="1">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Valor Inicial" FieldName="valor_inicial" VisibleIndex="22"
                                                            Width="200px" UnboundType="Decimal">
                                                            <PropertiesTextEdit DisplayFormatString="c">
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                            <FooterCellStyle ForeColor="Brown" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Inicio Garantia" FieldName="f_inicio_garantia"
                                                            VisibleIndex="24" Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                                    <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                                    </RegularExpression>
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Fin Garantia" FieldName="f_fin_garantia" VisibleIndex="26"
                                                            Width="200px">
                                                            <PropertiesTextEdit>
                                                        
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                        
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Costo" FieldName="costo" 
                                                            VisibleIndex="17" Width="200px" UnboundType="Decimal">
                                                            <PropertiesTextEdit DisplayFormatString="Bs. {0:0,0.00}">
                                                            
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Gastos C/CF"
                                                            FieldName="gastos_con_credito_fiscal" VisibleIndex="18" Width="200px" 
                                                            UnboundType="Decimal">
                                                            <PropertiesTextEdit DisplayFormatString="Bs. {0:0,0.00}">
                                                               
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                               
                                                            </PropertiesTextEdit >
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Gastos S/CF" 
                                                            FieldName="gastos_sin_credito_fiscal" VisibleIndex="20" UnboundType="Decimal"
                                                            Width="200px">
                                                            <PropertiesTextEdit DisplayFormatString="Bs. {0:0,0.00}">
                                                              
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                              
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Vida Útil Alterna" 
                                                            FieldName="vida_util_alterna" VisibleIndex="7" Width="100px">
                                                            <PropertiesTextEdit>
                                                               
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                               
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Vida Útil Genérica" FieldName="vida_util" 
                                                            VisibleIndex="6" Width="100px">
                                                            <PropertiesTextEdit>
                                                               
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                               
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                                    <Settings ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True" ShowFooter="True"
                                                        ShowGroupPanel="True" ShowFilterRow="True" />
                                                    <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                                    <TotalSummary>
                                                     <dx:ASPxSummaryItem FieldName="costo" SummaryType="Sum" DisplayFormat="Bs {0:0,0.00}"
                                                            ShowInColumn="Costo" />
                                                             <dx:ASPxSummaryItem FieldName="gastos_con_credito_fiscal" SummaryType="Sum" DisplayFormat="Bs {0:0,0.00}"
                                                            ShowInColumn="Gastos C/CF" />
                                                        <dx:ASPxSummaryItem FieldName="gastos_sin_credito_fiscal" SummaryType="Sum" DisplayFormat="Bs {0:0,0.00}"
                                                            ShowInColumn="Gastos S/CF" />
                                                        <dx:ASPxSummaryItem FieldName="valor_inicial" SummaryType="Sum" DisplayFormat="Bs {0:0,0.00}"
                                                            ShowInColumn="Valor Inicial" />
                                                      
                                                    </TotalSummary>
                                                </dx:ASPxGridView>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <!-- Modal HTML -->
                        <div id="myModal" class="modal fade">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                            &times;</button>
                                        <h4 class="modal-title">
                                            Información</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>
                                            Por favor revise los datos faltantes</p>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-primary" data-dismiss="modal">
                                            Cerrar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Modal HTML -->
                        <div id="myModal2" class="modal fade">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                            &times;</button>
                                        <h4 class="modal-title">
                                            Confirmación</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>
                                            Está seguro que desea guardar los datos de la compra de activos?</p>
                                        <p class="text-warning">
                                            <small>Si no guarda, los cambios se perderán.</small></p>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            Cerrar</button>
                                        <button type="button" class="btn btn-primary">
                                            Guardar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.box -->



                         
                             <div id="modalEditaCompra" class="modal fade">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                        &times;</button>
                                                    <h4 class="modal-title">
                                                    <asp:label ID="lblTitleModal" text="Edición de datos del activo" runat="server" />
                                                  
                                                        </h4>
                                                </div>
                                                  <asp:UpdatePanel ID="UpdatePanel3" runat="server"> 
                                     <ContentTemplate> 

                                                <div class="modal-body">
                                                    <!-- form start -->
                                                    <div class="box-body">
                                                    <div class="row">
                                                     <asp:TextBox ID="txtEditaId" name="txtEditaId" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>

                                                            <div class="col-xs-12">
                                                                <label for="nombre">
                                                                    Código</label>
                                                                <asp:TextBox ID="txtEditaCodigo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                      
                                                        <div class="row">
                                                            <asp:TextBox ID="id" runat="server" Visible="false" Enabled="false"></asp:TextBox>
                                                            <div class="col-xs-12">
                                                                <label for="descripcion">
                                                                    Descripcion</label>
                                                                <asp:TextBox ID="txtEditaDescripcion" CssClass="form-control"  runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                             
                                          
                                                        <div class="row">
                                                            <div class="col-xs-6">
                                                                <label for="nombre">
                                                                    Marca</label>
                                                                  <asp:DropDownList ID="ddlEditaMarca" runat="server" 
                                                                    CssClass="form-control" AutoPostBack="true"
                                                                    onselectedindexchanged="ddlEditaMarca_SelectedIndexChanged" >
                                                                  
                                                                </asp:DropDownList>
                                                            </div>
                                                             <div class="col-xs-6">
                                                                <label for="nombre">
                                                                    Modelo</label>
                                                                 <asp:DropDownList ID="ddlEditaModelo" runat="server" CssClass="form-control" AppendDataBoundItems=true>
                                                                
                                                                 </asp:DropDownList>
                                                            </div>
                                                           
                                                           
                                                        </div>
                                                       
                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <label for="nombre">
                                                                    Serie</label>
                                                                <asp:TextBox ID="txtEditaSerie" CssClass="form-control" 
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-xs-4">
                                                                <label for="nombre">
                                                                    Costo Bs</label>
                                                                <asp:TextBox ID="txtEditaCosto" CssClass="form-control" onkeyup="CostoEditaOnTextChange();"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-xs-4">
                                                                <label for="nombre">
                                                                    Gastos C/CF</label>
                                                                <asp:TextBox ID="txtEditaGastosConCreditoFiscal" CssClass="form-control" onkeyup="CostoEditaOnTextChange();"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-xs-4">
                                                                <label for="nombre">
                                                                     Gastos S/CF</label>
                                                                <asp:TextBox ID="txtEditaGastosSinCreditoFiscal" CssClass="form-control" onkeyup="CostoEditaOnTextChange();"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                         <div class="row">
                                                         <div class="col-xs-12">
                                                                <label for="nombre">
                                                                     Valor Inicial</label>
                                                                <asp:TextBox ID="txtEditaValorInicialCalculado" CssClass="form-control" ReadOnly="true" 
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                         </div>
                                                         <div class="row">
                                                            <div class="col-md-6">
                                                                <label for="nombre">
                                                                    Inicio Garantía</label>
                                                                      <input id="txtEditaInicioGarantia" type="text" name="txtEditaInicioGarantia" class="form-control"
                                                    runat="server"  placeholder="ejemplo: 01/01/2014" />
                                                            
                                                            </div>
                                                            <div class="col-xs-6">
                                                                <label for="nombre">
                                                                    Fin Garantía</label>
                                                                     <input id="txtEditaFinGarantia" type="text" name="txtEditaFinGarantia" class="form-control"
                                                    runat="server"  placeholder="ejemplo: 01/01/2014" />
                                                           
                                                            </div>
                                                        </div>
                                                         
                                                    </div>
                                                </div>
                                       
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                                        Cerrar</button>
                                                       <asp:Button CssClass="btn btn-primary" ID="btnGuardarEditActivo" runat="server"
                                                        Text="Guardar Cambios" onclick="btnGuardarEditActivo_Click"  OnClientClick="return ValidaEditar();"  />
                                                </div>

                                                          </ContentTemplate>
                                           <Triggers> 
                                        <asp:AsyncPostBackTrigger ControlID="ddlEditaMarca" EventName="SelectedIndexChanged" /> 
                                        </Triggers> 
                                        </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                        
                    <div class="modal fade" id="modalSaveConfirm" tabindex="-1" role="dialog" aria-labelledby="deleteLabel"
                    aria-hidden="true">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                       <ContentTemplate>
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header bg-yellow-gradient">
                                <h4 class="modal-title">
                                  <span class="icon fa fa-warning"></span>  Advertencia</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                   Está especificando una <strong> vida util alterna. </strong> Esto significa que ya no se tomará el parametro de vida util del grupo contable 
                                   Esta seguro que desea guardar el activo con la vida util alterna?</p>
                               
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                                    <asp:Button ID="btnContinuarGuardar" runat="server" Text="Continuar" 
                            CssClass="btn btn-warning" onclick="btnContinuarGuardar_Click"
                                    />
                            </div>
                        </div>
                    </div>
                      </ContentTemplate>
                 </asp:UpdatePanel>
                </div>
              
                        
            </section>
            </form>
        </aside>
    </div>
    <!-- ./wrapper -->
    <script type="text/javascript">
        function TestOnTextChange() {
            //Your Code

            var costo = document.getElementById("txtValorInicial").value.replace(/\,/g, '.');
            var gastos_con_credito_fiscal = document.getElementById("txtGastosConCreditoFiscal").value.replace(/\,/g, '.');
            var gastos_sin_credito_fiscal = document.getElementById("txtGastosSinCreditoFiscal").value.replace(/\,/g, '.');
            var valor_inicial_calculado = ((parseFloat(costo) + parseFloat(gastos_con_credito_fiscal)) * 87)/100 + parseFloat(gastos_sin_credito_fiscal);

            $('#txtValorInicialCalculado').val(valor_inicial_calculado);

            /*
            var costo_bs = document.getElementById("txtValorInicial").value;
            var tasa_ufv = document.getElementById("txtTasaUFV").value.toString().replace(/\,/g, '.');
            var tasa_sus = document.getElementById("txtTasaSus").value.toString().replace(/\,/g, '.');


            var result_ufv = parseFloat(costo_bs) / parseFloat(tasa_ufv);
            var result_sus = parseFloat(costo_bs) / parseFloat(tasa_sus);

            var result_ufv = Math.round(result_ufv * Math.pow(10, 5)) / Math.pow(10, 5);
            var result_sus = Math.round(result_sus * Math.pow(10, 2)) / Math.pow(10, 2);
            result_ufv = result_ufv.toFixed(5);
            result_sus = result_sus.toFixed(2);
            $('#txtCostoUfv').val(result_ufv);

            $('#txtCostoUfv').priceFormat({
                prefix: '',
                thousandsSeparator: '',
                centsSeparator: ',',
                centsLimit: 5
            });



            $('#txtCostoSus').val(result_sus);
            $('#txtCostoSus').priceFormat({
                prefix: '',
                thousandsSeparator: '',
                centsSeparator: ',',
                centsLimit: 2
            });
            */
        }
    </script>


        <script type="text/javascript">
            function CostoEditaOnTextChange() {
                //Your Code

                var costo = document.getElementById("txtEditaCosto").value.replace(/\,/g, '.');
                var gastos_con_credito_fiscal = document.getElementById("txtEditaGastosConCreditoFiscal").value.replace(/\,/g, '.');
                var gastos_sin_credito_fiscal = document.getElementById("txtEditaGastosSinCreditoFiscal").value.replace(/\,/g, '.');
                var valor_inicial_calculado = ((parseFloat(costo) + parseFloat(gastos_con_credito_fiscal)) * 87) / 100 + parseFloat(gastos_sin_credito_fiscal);

                $('#txtEditaValorInicialCalculado').val(valor_inicial_calculado);

//                var costo_bs = document.getElementById("txtEditaCosto").value;
//                var tasa_ufv = document.getElementById("txtTasaUFV").value.toString().replace(/\,/g, '.');
//                var tasa_sus = document.getElementById("txtTasaSus").value.toString().replace(/\,/g, '.');

//                var result_ufv = parseFloat(costo_bs) / parseFloat(tasa_ufv);
//                var result_sus = parseFloat(costo_bs) / parseFloat(tasa_sus);

//                var result_ufv = Math.round(result_ufv * Math.pow(10, 5)) / Math.pow(10, 5);
//                var result_sus = Math.round(result_sus * Math.pow(10, 2)) / Math.pow(10, 2);
//                result_ufv = result_ufv.toFixed(5);
//                result_sus = result_sus.toFixed(2);
//                $('#txtEditaCostoUFV').val(result_ufv);

//                $('#txtEditaCostoUFV').priceFormat({
//                    prefix: '',
//                    thousandsSeparator: '',
//                    centsSeparator: ',',
//                    centsLimit: 5
//                });



//                $('#txtEditaCostoSus').val(result_sus);
//                $('#txtEditaCostoSus').priceFormat({
//                    prefix: '',
//                    thousandsSeparator: '',
//                    centsSeparator: ',',
//                    centsLimit: 2
//                });

            }
    </script>

    <script type="text/javascript">

        function Validar() {
            var error = 0;

            if (document.getElementById('<%=txtDescripcionActivo.ClientID %>').value == '' || document.getElementById('<%=ddlGrupoContable.ClientID %>').value == '-1' || document.getElementById('<%=ddlAuxiliarContable.ClientID %>').value == '-1' ||
            document.getElementById('<%=txtSerie.ClientID %>').value == '' || document.getElementById('<%=ddlMarca.ClientID %>').value == '-1' || document.getElementById('<%=ddlModelo.ClientID %>').value == '-1' ||
            document.getElementById('<%= txtValorInicial.ClientID %>').value == '' || document.getElementById('<%= txtGastosConCreditoFiscal.ClientID %>').value == '' || document.getElementById('<%= txtGastosSinCreditoFiscal.ClientID %>').value == '') {
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


        function ValidaEditar() {
            var error = 0;

            if (document.getElementById('<%=txtEditaDescripcion.ClientID %>').value == '' ||
            document.getElementById('<%=txtEditaSerie.ClientID %>').value == '' || document.getElementById('<%=ddlEditaMarca.ClientID %>').value == '-1' || document.getElementById('<%=ddlEditaModelo.ClientID %>').value == '-1' ||
            document.getElementById('<%= txtEditaCosto.ClientID %>').value == '' || document.getElementById('<%= txtEditaGastosConCreditoFiscal.ClientID %>').value == '' || document.getElementById('<%= txtEditaGastosSinCreditoFiscal.ClientID %>').value == '') {
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
        function ConfirmaElimina() {
            if (confirm("¿Está seguro de que quiere eliminar el registro?"))
                return true;
            else return false;
        }
    </script>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $('#dateInicioGarantia').datepicker({
                format: 'dd-mm-yyyy'
            });

            $('#dateFinGarantia').datepicker({
                format: 'dd-mm-yyyy'
            });


            $('#txtEditaInicioGarantia').datepicker({
                format: 'dd-mm-yyyy'
            });

            $('#txtEditaFinGarantia').datepicker({
                format: 'dd-mm-yyyy'
            });



            $('#dateInicioGarantia').datepicker()
          .on('changeDate', function (ev) {
              $(this).datepicker('hide');
          });

          $('#dateFinGarantia').datepicker()
          .on('changeDate', function (ev) {
              $(this).datepicker('hide');
          });

          $('#txtEditaInicioGarantia').datepicker()
          .on('changeDate', function (ev) {
              $(this).datepicker('hide');
          });

          $('#txtEditaFinGarantia').datepicker()
          .on('changeDate', function (ev) {
              $(this).datepicker('hide');
          });

        });
    </script>
</body>
</html>
