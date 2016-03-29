<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kardex.aspx.cs" Inherits="ActivosFijosEETC.Views.Kardex" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
    <script type="text/javascript">
        document.write('<script src="js/GruposContables.js" type="text/javascript"><\/script>');   
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
                <ul class="sidebar-menu" id="_menu" runat="server">
                    <li class="active"><a href="Default.aspx"><i class="fa fa-dashboard"></i><span>Dashboard</span>
                    </a></li>
                        <%--  <li class="active" runat="server" id="_solicitudesSalidas"><a href="OrdenesSalidaIngresos.aspx">
                        <i class="fa  fa-sign-out"></i><span>Solicitud salida de activos</span> </a>
                    </li>--%>
                    <li class="treeview" runat="server" id="_parametrizacion"><a href="#"><i class="fa fa-edit">
                    </i><span>Parametrización</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="TasasCambio.aspx"><i class="fa fa-angle-double-right"></i>Tasas de Cambio</a></li>
                            <li><a href="GruposContables.aspx"><i class="fa fa-angle-double-right"></i>Grupos Contables</a></li>
                            <li><a href="GruposAuxiliares.aspx"><i class="fa fa-angle-double-right"></i>Auxiliares
                                Contables</a></li>
                            <li><a href="Marcas.aspx"><i class="fa fa-angle-double-right"></i>Marcas - Modelos</a></li>
                            <li><a href="Personal.aspx"><i class="fa fa-angle-double-right"></i>Personal</a></li>
                        </ul>
                    </li>
                    <li class="treeview" runat="server" id="_proveedores"><a href="#"><i class="fa fa-group">
                    </i><span>Proveedores</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="RegistroProveedor.aspx"><i class="fa fa-angle-double-right"></i>Registrar
                                Proveedor</a></li>
                            <li><a href="EditarProveedor.aspx"><i class="fa fa-angle-double-right"></i>Editar Proveedor</a></li>
                            <li><a href="BuscaProveedor.aspx"><i class="fa fa-angle-double-right"></i>Buscar</a></li>
                            <li><a href="RutasProveedor.aspx"><i class="fa fa-angle-double-right"></i>Rutas</a></li>
                        </ul>
                    </li>
                    <li class="treeview" runat="server" id="_altas"><a href="#"><i class="fa fa-shopping-cart">
                    </i><span>Altas de Activos</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="Compras.aspx"><i class="fa fa-angle-double-right"></i>Compras</a></li>
                            <li><a href="Transferencias.aspx"><i class="fa fa-angle-double-right"></i>Transferencias</a></li>
                        </ul>
                    </li>
                    <li class="treeview" runat="server" id="_transferencias"><a href="#"><i class="fa fa-retweet">
                    </i><span>Transferencias</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="TransferenciasInternas.aspx"><i class="fa fa-angle-double-right"></i>Gestión
                                Transferencias</a></li>
                        </ul>
                    </li>
                    <li class="treeview" runat="server" id="_asignaciones"><a href="#"><i class="fa fa-tag">
                    </i><span>Asignaciones</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="Asignaciones.aspx"><i class="fa fa-angle-double-right"></i>Asignaciones</a></li>
                        </ul>
                    </li>
                    <li class="treeview" runat="server" id="_depreciaciones"><a href="#"><i class="fa fa-bolt">
                    </i><span>Depreciaciones</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="Depreciaciones.aspx"><i class="fa fa-angle-double-right"></i>Depreciaciones</a></li>
                        </ul>
                    </li>
                    <li class="treeview" runat="server" id="_control_activos"><a href="#"><i class="fa fa-barcode">
                    </i><span>Control de Activos</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="Inventario.aspx"><i class="fa fa-angle-double-right"></i>Inventario</a></li>
                            <li><a href="OrdenesSalidaIngresos.aspx"><i class="fa fa-angle-double-right"></i>Salidas
                                de activos</a></li>
                            <li><a href="IngresosActivos.aspx"><i class="fa fa-angle-double-right"></i>Ingresos
                                Activos Fijos</a></li>
                        </ul>
                    </li>
                    <li class="treeview" runat="server" id="_bajas"><a href="#"><i class="fa fa-trash-o"></i>
                        <span>Bajas</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="Bajas.aspx"><i class="fa fa-angle-double-right"></i>Registro de bajas</a></li>
                             <li><a href="DetalleBajas.aspx"><i class="fa fa-angle-double-right"></i>Detalle de bajas</a></li>
                        </ul>
                    </li>
                     <li class="treeview" runat="server" id="Li1"><a href="#"><i class="fa fa-dollar">
                    </i><span>Revaluo Técnico</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="RevaluoTecnico.aspx"><i class="fa fa-angle-double-right"></i>Registro Revalúo</a></li>
                        </ul>
                    </li>

                    <li class="treeview" runat="server" id="_cierre"><a href="#"><i class="fa fa-lock"></i>
                        <span>Cierre</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="cierre.aspx"><i class="fa fa-angle-double-right"></i>Cierre de gestión</a></li>
                        </ul>
                    </li>
                    <li class="treeview" runat="server" id="_apertura"><a href="#"><i class="fa fa-unlock">
                    </i><span>Apertura</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="apertura.aspx"><i class="fa fa-angle-double-right"></i>Apertura de gestión</a></li>
                        </ul>
                    </li>
                    <li class="treeview" runat="server" id="_reportes"><a href="#"><i class="fa fa-bar-chart-o">
                    </i><span>Reportes</span> <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li id="rep_tasa_cambio" runat="server"><a href="TasasCambioPorFecha.aspx"><i class="fa fa-angle-double-right">
                            </i>Tasas Cambio</a></li>
                            <li id="rep_activos_con_custodio" runat="server"><a href="reportes/ReporteActivosConCustodio.aspx">
                                <i class="fa fa-angle-double-right"></i>Activos Con Custodio</a></li>
                            <li id="rep_activos_por_responsable" runat="server"><a href="ActivosPorResponsable.aspx">
                                <i class="fa fa-angle-double-right"></i>Activos Por Responsable</a></li>
                            <li id="rep_agrupado" runat="server"><a href="ReporteAgrupado.aspx"><i class="fa fa-angle-double-right">
                            </i>Reportes por agrupaciones</a></li>
                            <li id="rep_activos_por_estacion_linea" runat="server"><a href="ActivosPorEstacionLinea.aspx">
                                <i class="fa fa-angle-double-right"></i>Estación - Línea - Oficinas</a></li>
                            <li id="rep_resumen_activos_por_grupo" runat="server"><a href="reportes/ReporteResumenActivosFijosPorGrupo.aspx"
                                target="_blank"><i class="fa fa-angle-double-right"></i>Resumen Activos Por Grupo</a></li>
                            <li id="rep_detalle_activos_por_grupo" runat="server"><a href="reportes/ReporteDetalleActivosFijosPorGrupo.aspx"
                                target="_blank"><i class="fa fa-angle-double-right"></i>Detalle Activos Por Grupo</a></li>
                            <li id="rep_existencias_por_fecha" runat="server"><a href="ExistenciasActivosPorFechas.aspx"
                                target="_blank"><i class="fa fa-angle-double-right"></i>Existencias por fecha</a></li>
                            <li id="rep_auxiliares_por_area" runat="server"><a href="reportes/ReporteAuxiliaresPorArea.aspx"
                                target="_blank"><i class="fa fa-angle-double-right"></i>Auxiliares por area</a></li>
                            <li id="rep_auxiliares_general" runat="server"><a href="reportes/ReporteAuxiliaresGeneral.aspx"
                                target="_blank"><i class="fa fa-angle-double-right"></i>Auxiliares General</a></li>
                            <li id="rep_kardex" runat="server"><a href="Kardex.aspx"><i class="fa fa-angle-double-right">
                            </i>Kardex</a></li>
                        </ul>
                    </li>
                </ul>
            </section>
            <!-- /.sidebar -->
        </aside>
        <!-- Right side column. Contains the navbar and content of the page -->
        <aside class="right-side">
            <section class="content-header">
                <h1>
                    Kardex <small>Kardex por activo</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Reportes</a></li>
                    <li class="active">Kardex</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Generación de reportes</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-header">
                            

                        <div class="box-body">
                            <asp:LinkButton ID="btnGenerarReporte" runat="server" CssClass="btn btn-warning" 
                                Text="<span class='fa fa-print'></span>Generar Kardex" 
                                onclick="btnGenerarReporte_Click" ></asp:LinkButton>
                           
                            <%--<asp:Button ID="btnGenerarReporte" runat="server" CssClass="btn btn-warning" 
                                Text="Generar Reporte" onclick="btnGenerarReporte_Click" />--%>
                                    </div>
                                    <div class=box-body>
                                      
                                            <dx:ASPxGridView ID="gridActivos" runat="server" AutoGenerateColumns="False"
                                            Caption="Activos Fijos" Width="100%" EnableTheming="True" Theme="Aqua">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0">
                                                    <ClearFilterButton Visible="True">
                                                    </ClearFilterButton>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="id" VisibleIndex="1" FieldName="id" 
                                                    Visible="False">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Registro" FieldName="f_registro" 
                                                    VisibleIndex="2">
<PropertiesTextEdit DisplayFormatString="{0:dd/MM/yyyy}">
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" 
                                                    VisibleIndex="3">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" 
                                                    VisibleIndex="4">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" VisibleIndex="5">
                                                    <propertiestextedit>
<validationsettings errortext="Valor inválido">
<regularexpression errortext="Falló la validación de expresión Regular"></regularexpression>
</validationsettings>
</propertiestextedit>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <Settings ShowFilterRow="True" />

<SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>

<Settings ShowFilterRow="True"></Settings>

<SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                        </dx:ASPxGridView>

                                    </div>
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

</body>
</html>
