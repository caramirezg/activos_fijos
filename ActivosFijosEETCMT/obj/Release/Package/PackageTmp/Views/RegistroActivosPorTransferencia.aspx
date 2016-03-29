<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroActivosPorTransferencia.aspx.cs" Inherits="ActivosFijosEETC.Views.RegistroActivosPorTransferencia" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

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

    <!-- bootstrap wysihtml5 - text editor -->
    <link href="bootstrap/css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet"
        type="text/css" />
    <!-- Theme style -->
    <link href="bootstrap/css/AdminLTE.css" rel="stylesheet" type="text/css" />
    <!-- DATA TABLES -->
    <link href="bootstrap/css/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- jQuery 2.0.2 -->
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
                                <asp:LinkButton ID="btnImprimir" runat="server" Text="<span class='fa fa-print'></span> Imprimir Transferencia" 
                                        CssClass="btn btn-warning" onclick="btnImprimir_Click"></asp:LinkButton>
                                </div>
                            <div class="box-body">
                                <asp:TextBox ID="txtCodigoTransferencia" runat="server" Visible="false" Enabled="false"></asp:TextBox>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Descripción</label>
                                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" ReadOnly=true
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-2">
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
                                            ReadOnly="true" runat="server" ></asp:TextBox>
                                    </div>
                                   <div class="col-xs-3">
                                        &nbsp;<label for="nombre">Documento de Respaldo</label><asp:TextBox ID="txtDocumentoRespaldo"
                                            CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                     <div class="col-xs-3">
                                        &nbsp;<label for="nombre">Origen</label><asp:TextBox ID="txtOrigen"
                                            CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
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
                                        </div>
                                </div>

                              
                                    <div class="row">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server"> 
                                     <ContentTemplate> 
                                        <div class="col-md-3">
                                            <label for="nombre">
                                                Grupo Contable <font color="red">*</font></label>
                                                 <asp:DropDownList ID="ddlGrupoContable" runat="server"
                                                CssClass="form-control" 
                                                AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlGrupoContable_SelectedIndexChanged"
                                                >
                                                <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                </asp:DropDownList>
                                            
                                        </div>
                                        <div class="col-md-3">
                                            <label for="nombre">
                                                Auxiliar Contable <font color="red">*</font></label>
                                          
                                                    <asp:DropDownList ID="ddlAuxiliarContable" runat="server" 
                                                        CssClass="form-control" AppendDataBoundItems="True">
                                                          <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                    </asp:DropDownList>
                                            
                                        </div>
                                        </ContentTemplate>
                                        <Triggers> 
                                        <asp:AsyncPostBackTrigger ControlID="ddlGrupoContable" EventName="SelectedIndexChanged" /> 
                                        </Triggers> 
                                        </asp:UpdatePanel>

                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
                                     <ContentTemplate> 
                                        <div class="col-md-3">
                                            <label for="nombre">
                                                Marca <font color="red">*</font></label>
                                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control" 
                                                AppendDataBoundItems="True" AutoPostBack="True" onselectedindexchanged="ddlMarca_SelectedIndexChanged" 
                                                 >
                                                  <asp:ListItem Text="Seleccione un item" Value="-1" /></asp:DropDownList>
                                        </div>

                                        <div class="col-md-3">
                                            <label for="nombre">
                                                Modelo <font color="red">*</font></label>
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
                                       
                                        <div class="col-md-3">
                                            <label for="nombre">
                                                Nro. Serie <font color="red">*</font></label>
                                           <asp:TextBox ID="txtSerie" runat="server" CssClass="form-control" placeholder="ejemplo: XYD001EF501"></asp:TextBox>

                                        </div>
                                        <div class="col-md-3">
                                            <label for="nombre">
                                                Costo Bs <font color="red">*</font></label>
                                           <dx:ASPxSpinEdit ID="spinValorInicial" ClientInstanceName="spinValorInicial" CssClass="form-control" runat="server" Number="0" MaxValue="99999999" DisplayFormatString="Bs. {0:0,0.00}" Theme="Metropolis" >
                                            
                                               <ClientSideEvents NumberChanged="function(s, e) {
	spinCostoActualizadoInicial.SetValue(spinValorInicial.GetValue());
}" />
                                            </dx:ASPxSpinEdit>
                                            
                                             <%--<asp:TextBox ID="txtValorInicial" runat="server" CssClass="form-control" placeholder="ejemplo: 1500.50 Bs"></asp:TextBox>--%>
                                        </div>
                                          <div class="col-md-3">
                                            <label for="nombre">
                                                Costo Actualizado Inicial <font color="red">*</font></label>
                                              <dx:ASPxSpinEdit ID="spinCostoActualizadoInicial" ClientInstanceName="spinCostoActualizadoInicial" CssClass="form-control" runat="server" Number="0" MaxValue="99999999" DisplayFormatString="Bs. {0:0,0.00}" Theme="Metropolis" />
                                           <%-- <asp:TextBox ID="txtCostoActualizadoInicial" runat="server" CssClass="form-control" placeholder="ejemplo: 1600.50 Bs"></asp:TextBox>--%>
                                        </div>
                                        <div class="col-md-3">
                                            <label for="nombre">
                                                Depreciación acumulada Total Inicial <font color="red">*</font></label>
                                            <dx:ASPxSpinEdit ID="spinDepreciacionAcumuladaTotalInicial" CssClass="form-control" runat="server" Number="0" MaxValue="99999999" DisplayFormatString="Bs. {0:0,0.00}" Theme="Metropolis" />
                                            <%--<asp:TextBox ID="txtDepreciacionAcumuladaTotalInicial" runat="server" CssClass="form-control" placeholder="ejemplo: 1700 Bs"></asp:TextBox>--%>
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
                           
                             <asp:LinkButton ID="btnDuplicarActivo" CssClass="btn btn-warning" runat="server" 
                                 Text="Duplicar" onclick="btnDuplicarActivo_Click"></asp:LinkButton>
                              
                             <asp:LinkButton ID="btnEliminar" CssClass="btn btn-danger" runat="server" 
                                 Text="<span class='fa fa-trash-o'></span> Eliminar" OnClientClick="return ConfirmaElimina();" 
                                 onclick="btnEliminar_Click"></asp:LinkButton>

                              
                        </div>
                        </contenttemplate>
</asp:updatepanel>
                        <div class="box-footer" id="idBarCode" runat=server>
                            <asp:LinkButton ID="btnPrintBarcode" CssClass="btn btn-default" runat="server" 
                                 Text="<span class='fa fa-barcode'></span> Imprimir codigo de barras individual" 
                                onclick="btnPrintBarcode_Click"></asp:LinkButton>
                      
                            <asp:LinkButton ID="btnPrintBarcodeAll" CssClass="btn btn-primary" runat="server" 
                                 Text="<span class='fa fa-barcode'></span> Imprimir codigo de barras transferencia" onclick="btnPrintBarcodeAll_Click" ></asp:LinkButton>
                              
                        </div>
                   <asp:updatepanel runat="server">
    <contenttemplate>
                        <div class="box">
                        <div class="box-body table-responsive">
                            <dx:ASPxGridView ID="GridActivosPorTransferencia" runat="server" AutoGenerateColumns="False" 
                                EnableTheming="True" Theme="Metropolis" Width="100%" KeyFieldName="id" 
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
                                        VisibleIndex="26" Width="150px">
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
                                    <dx:GridViewDataTextColumn Caption="Costo Actualizado_inicial" FieldName="costo_actualizado_inicial_historico" VisibleIndex="24">
                                    <PropertiesTextEdit DisplayFormatString="Bs {0:0,0.00}"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Depreciacion Acumulada Inicial" FieldName="depreciacion_acumulada_total_historico" VisibleIndex="25">
                                     
                                        <PropertiesTextEdit  DisplayFormatString="Bs {0:0,0.00}"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                <Settings ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True" />
<SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>

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




              <!-- modal validacion -->
            <div class="modal fade" id="validaModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel"
                aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header bg-yellow-gradient">
                            <h4 class="modal-title" id="H1">
                                <span class="icon fa fa-info"></span>Información</h4>
                        </div>
                        <div class="modal-body">
                            <p>
                                <ul>
                                    <label id="labelId">
                                    </label>
                                </ul>
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Aceptar</button>
                        </div>
                    </div>
                </div>
            </div>


    <!-- /.box -->
    </section> 
    </form>
    </aside>
    </div>
    <!-- ./wrapper -->
    <script type="text/javascript">

    </script>

    <script type="text/javascript">

        //$(document).ready(function () {

        //    $("#txtValorInicial").numeric();
        //    $("#txtCostoActualizadoInicial").numeric();
        //    $("#txtDepreciacionAcumuladaTotalInicial").numeric();

        //});


        function Validar() {
            var mensaje = '';
            var error = 0;

            if (document.getElementById('<%=txtDescripcionTransferenciaActivo.ClientID %>').value == '') {
                mensaje = mensaje + '<li> El campo <strong>Descripción</strong> es obligatorio </li><br>'
                error = 1;
            }
            if (document.getElementById('<%=ddlGrupoContable.ClientID %>').value == '-1') {
                mensaje = mensaje + '<li> El campo <strong>Grupo Contable</strong> es obligatorio </li><br>'
                error = 1;
            }
            if (document.getElementById('<%=ddlAuxiliarContable.ClientID %>').value == '-1') {
                mensaje = mensaje + '<li> El campo <strong>Auxiliar Contable</strong> es obligatorio </li><br>'
                error = 1;
            }
          
            if (document.getElementById('<%=ddlMarca.ClientID %>').value == '-1') {
                mensaje = mensaje + '<li> El campo <strong>Marca</strong> es obligatorio </li><br>'
                error = 1;
            }
            if (document.getElementById('<%=ddlModelo.ClientID %>').value == '-1') {
                mensaje = mensaje + '<li> El campo <strong>Modelo</strong> es obligatorio </li><br>'
                error = 1;
            }
            if (document.getElementById('<%=txtSerie.ClientID %>').value == '') {
                mensaje = mensaje + '<li> El campo <strong>Serie</strong> es obligatorio </li><br>'
                error = 1;
            }
            if (document.getElementById('<%=spinValorInicial.ClientID %>').value == '') {
                mensaje = mensaje + '<li> El campo <strong>Costo Bs</strong> es obligatorio </li><br>'
                error = 1;
            }
            if (document.getElementById('<%=spinCostoActualizadoInicial.ClientID %>').value == '') {
                mensaje = mensaje + '<li> El campo <strong>Costo actualizado inicial</strong> es obligatorio </li><br>'
                error = 1;
            }
            if (document.getElementById('<%=spinDepreciacionAcumuladaTotalInicial.ClientID %>').value == '') {
                mensaje = mensaje + '<li> El campo <strong>Depreciación acumulada total</strong> es obligatorio </li><br>'
                error = 1;
            }

            if (error == 0) {
                return true;
            }
            else {
                $('#validaModal').modal('show');
                document.getElementById('labelId').innerHTML = mensaje;
                return false;
            }
        }


        $(function () {

            $("#txtValorInicial").Decimales();
            $("#txtCostoActualizadoInicial").Decimales();
            $("#txtDepreciacionAcumuladaTotalInicial").Decimales();
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
