<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleBajas.aspx.cs" Inherits="ActivosFijosEETC.Views.DetalleBajas" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
       <script src="js/jquery.plugins.js"       type="text/javascript"></script>
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
                   <span class="ion ion-trash-b"></span> Bajas <small>Detalle de activos dados de baja</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li class="active">Detalle de activos dados de baja</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Detalle de activos dados de baja</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-header">
                                <div id="danger" class="alert alert-danger" role="alert" style="display: none">
                                    <strong>Error!</strong>
                                </div>
                                <div id="success" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Correcto!</strong>
                                </div>
                                 <div id="warning" class="alert alert-warning" role="alert" style="display: none">
                                    <strong>Advertencia!</strong>
                                </div>
                                  </div>
                                <div class="box-body">
                                         <div class="btn-group">
                                            <asp:LinkButton ID="btnImprimirInforme" 
                                            Text="<span class='fa fa-print'></span> Imprimir Resumen por grupo" CssClass="btn btn-warning"
                                            runat="server" onclick="btnImprimirInforme_Click"></asp:LinkButton>
                                            <button type="button" class="btn btn-warning dropdown-toggle" data-toggle="dropdown">
                                                <span class="caret"></span>
                                                <span class="sr-only">Toggle Dropdown</span>
                                            </button>
                                            <ul class="dropdown-menu" role="menu">
                                                <li><asp:LinkButton ID="LinkButton1" 
                                                    Text="Imprimir Detalle de bajas"
                                                    runat="server" onclick="btnImprimirInforme_Click"></asp:LinkButton></li>
                                                <li><asp:LinkButton ID="btnExportarExcel" runat="server" 
                                                    Text="Exportar detalle a excel" 
                                                     onclick="btnExportarExcelDetalle_Click"></asp:LinkButton></li>
                                               
                                              
                                            </ul>
                                        </div>

                                   

                                </div>
                              
                            
                            <!-- /.box-body -->
                            <div class="box-body">
                                <dx:ASPxGridView ID="gridActivosBajas" runat="server" 
                                    AutoGenerateColumns="False" 
                                    Caption="Detalle de depreciación y actualización de activos" KeyFieldName="id" 
                                    Theme="Aqua" Width="100%">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Visible="False">
                                            <ClearFilterButton Visible="True">
                                            </ClearFilterButton>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="2">
                                            <PropertiesTextEdit>
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" 
                                            VisibleIndex="3" Width="400px">
                                            <PropertiesTextEdit>
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                                

<Style HorizontalAlign="Justify">
                                                </Style>
                                            
</PropertiesTextEdit>
                                            <CellStyle HorizontalAlign="Justify">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Grupo Contable" FieldName="grupo_contable" 
                                            VisibleIndex="1" Width="250px">
                                            <PropertiesTextEdit>
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Vida Util" FieldName="vida_util" 
                                            VisibleIndex="6">
                                            <PropertiesTextEdit>
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Costo Historico" 
                                            FieldName="costo_historico" VisibleIndex="7">
                                            
                                          
                                                      
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}"> 
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Costo Actualizado Inicial" 
                                            FieldName="costo_actualizado_inicial" VisibleIndex="8" Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Deprec. Acum. Total" 
                                            FieldName="depreciacion_acumulada_total" VisibleIndex="9" Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Valor Neto Inicial" 
                                            FieldName="valor_neto_inicial" VisibleIndex="10" Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Actualizacion Gestion" 
                                            FieldName="actualizacion_gestion" VisibleIndex="11" Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Costo Total Actualizado" 
                                            FieldName="costo_total_actualizado" VisibleIndex="12" Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Depreciación Gestión" 
                                            FieldName="depreciacion_gestion" VisibleIndex="13" Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Actualización Dep. Acum." 
                                            FieldName="actualizacion_depreciacion_acumulada" VisibleIndex="14" 
                                            Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Depreciación Acumulada" 
                                            FieldName="depreciacion_acumulada" VisibleIndex="15" Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Valor Neto" FieldName="valor_neto" 
                                            VisibleIndex="16" Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:0,0.00}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Fecha última corrida" 
                                            FieldName="f_ult_act_dep" VisibleIndex="17" Width="150px">
                                            <PropertiesTextEdit DisplayFormatString="{0:dd/MM/yyyy}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Tasa Ufv" FieldName="tasa_ufv" 
                                            VisibleIndex="5">
                                            <PropertiesTextEdit>
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Fecha Historica" FieldName="f_registro" 
                                            VisibleIndex="4">
                                            <PropertiesTextEdit DisplayFormatString="{0:dd/MM/yyyy}">
                                                
<ValidationSettings ErrorText="Valor inválido">
                                                    
<RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                
</ValidationSettings>
                                            
</PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Fecha de Baja" VisibleIndex="19">
                                            <propertiestextedit>
<validationsettings errortext="Valor inválido">
<regularexpression errortext="Falló la validación de expresión Regular"></regularexpression>
</validationsettings>
</propertiestextedit>
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFooter="True" ShowGroupPanel="True" 
                                        ShowGroupFooter="VisibleIfExpanded" ShowHorizontalScrollBar="True" 
                                        ShowFilterRow="True"/>

<SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>

<Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" 
                                        ShowHorizontalScrollBar="True"></Settings>

<SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>

<TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="costo_historico" SummaryType="Sum"  DisplayFormat="{0:0,0.00}"
                                                ShowInColumn="Costo Historico" />
                                             <dx:ASPxSummaryItem FieldName="costo_actualizado_inicial" SummaryType="Sum"   DisplayFormat="{0:0,0.0000}"
                                                ShowInColumn="Costo Actualizado Inicial" />
                                              <dx:ASPxSummaryItem FieldName="depreciacion_acumulada_total" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInColumn="Deprec. Acum. Total" />
                                              <dx:ASPxSummaryItem FieldName="valor_neto_inicial" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInColumn="Valor Neto Inicial" />
                                              <dx:ASPxSummaryItem FieldName="actualizacion_gestion" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInColumn="Actualizacion Gestion" />
                                                 <dx:ASPxSummaryItem FieldName="costo_total_actualizado" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInColumn="Costo Total Actualizado" />
                                                 <dx:ASPxSummaryItem FieldName="depreciacion_gestion" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInColumn="Depreciación Gestión" />
                                                 <dx:ASPxSummaryItem FieldName="actualizacion_depreciacion_acumulada" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInColumn="Actualización Dep. Acum." />
                                                 <dx:ASPxSummaryItem FieldName="depreciacion_acumulada" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInColumn="Depreciación Acumulada" />
                                                 <dx:ASPxSummaryItem FieldName="valor_neto" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInColumn="Valor Neto" />
                                        </TotalSummary>
                                       
                                        <GroupSummary>
            <dx:ASPxSummaryItem FieldName="costo_historico" SummaryType="Sum"  DisplayFormat="{0:0,0.00}"
                                                ShowInGroupFooterColumn="Costo Historico" />
                                             <dx:ASPxSummaryItem FieldName="costo_actualizado_inicial" SummaryType="Sum"   DisplayFormat="{0:0,0.0000}"
                                                ShowInGroupFooterColumn="Costo Actualizado Inicial" />
                                              <dx:ASPxSummaryItem FieldName="depreciacion_acumulada_total" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInGroupFooterColumn="Deprec. Acum. Total" />
                                              <dx:ASPxSummaryItem FieldName="valor_neto_inicial" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInGroupFooterColumn="Valor Neto Inicial" />
                                              <dx:ASPxSummaryItem FieldName="actualizacion_gestion" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInGroupFooterColumn="Actualizacion Gestion" />
                                                 <dx:ASPxSummaryItem FieldName="costo_total_actualizado" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInGroupFooterColumn="Costo Total Actualizado" />
                                                 <dx:ASPxSummaryItem FieldName="depreciacion_gestion" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInGroupFooterColumn="Depreciación Gestión" />
                                                 <dx:ASPxSummaryItem FieldName="actualizacion_depreciacion_acumulada" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInGroupFooterColumn="Actualización Dep. Acum." />
                                                 <dx:ASPxSummaryItem FieldName="depreciacion_acumulada" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInGroupFooterColumn="Depreciación Acumulada" />
                                                 <dx:ASPxSummaryItem FieldName="valor_neto" SummaryType="Sum"   DisplayFormat="{0:0,0.00}"
                                                ShowInGroupFooterColumn="Valor Neto" />
        </GroupSummary>
                                </dx:ASPxGridView>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            </form>
        </aside>
    </div>

    <script type = "text/javascript">
        window.onload = function () {
            document.onkeydown = function (e) {
                return (e.which || e.keyCode) != 116;
            };
        }
</script>
     
    
</body>
</html>
