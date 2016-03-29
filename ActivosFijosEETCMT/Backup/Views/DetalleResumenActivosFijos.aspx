﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleResumenActivosFijos.aspx.cs"
    Inherits="ActivosFijosEETC.Views.DetalleResumenActivosFijos" %>

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
                   Detalle - Resumen de activos fijos
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li class="active">Detalle - Resumen activos fijos</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Generación de reporte</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-header">
                                <div id="danger" class="alert alert-danger" role="alert" style="display: none">
                                    <strong>Error!</strong>
                                </div>
                                <div id="warning" class="alert alert-warning" role="alert" style="display: none">
                                    <strong>Advertencia!</strong>
                                </div>
                                <div id="success" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Correcto!</strong>
                                </div>
                            </div>
                            <div class="box-body">
                                <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" 
                                    CssClass="btn btn-primary" onclick="btnGenerarReporte_Click" OnClientClick="return Validar();" />
                             
                            </div>
                            <!-- /.box-body -->
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Tipo de Reporte</label>
                                        <asp:DropDownList ID="ddlTipoReporte" CssClass="form-control" runat="server" 
                                            AppendDataBoundItems="True">
                                        <asp:ListItem Text="seleccione una tipo de reporte" Value="-1" />
                                            <asp:ListItem Text="RESUMEN" Value="resumen" />
                                            <asp:ListItem Text="DETALLE" Value="detalle" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                  <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Tipo de Clasificación</label>
                                        <asp:DropDownList ID="ddlClasificacion" CssClass="form-control" runat="server" 
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddlClasificacion_SelectedIndexChanged" 
                                            AppendDataBoundItems="True">
                                        <asp:ListItem Text="seleccione un item" Value="-1" />
                                            <asp:ListItem Text="GENERICO" Value="generico" />
                                            <asp:ListItem Text="UBICACION" Value="ubicacion" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                 <div class="row" runat=server id="_ubicacion">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Ubicacion</label>
                                        <asp:DropDownList ID="ddlUbicacion" CssClass="form-control" runat="server" 
                                            AutoPostBack="True" AppendDataBoundItems="True" onselectedindexchanged="ddlUbicacion_SelectedIndexChanged" 
                                            >
                                        <asp:ListItem Text="seleccione un item" Value="-1" />
                                            <asp:ListItem Text="SIN ASIGNAR" Value="0" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row" runat="server" id="_linea">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Línea</label>
                                        <asp:DropDownList ID="ddlLinea" CssClass="form-control" runat="server" 
                                            AutoPostBack="True" onselectedindexchanged="ddlLinea_SelectedIndexChanged" 
                                            AppendDataBoundItems="True">
                                            <asp:ListItem Text="seleccione una linea" Value="-1" />
                                            <asp:ListItem Text="TODAS" Value="0" />
                                          
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row" runat="server" id="_estacion">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Estación</label>
                                        <asp:DropDownList ID="ddlEstacion" CssClass="form-control" runat="server" 
                                            AppendDataBoundItems="True">
                                            <asp:ListItem Text="seleccione una estación" Value="-1" />
                                        </asp:DropDownList>
                                    </div>
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

    <script type="text/javascript">

        function Validar() {
            var error = 0;

            if (document.getElementById('<%=ddlTipoReporte.ClientID %>').value == '-1' || document.getElementById('<%=ddlClasificacion.ClientID %>').value == '-1') {
                error = 1;
            } else {
                if (document.getElementById('<%=ddlUbicacion.ClientID %>').value == '0' || document.getElementById('<%=ddlUbicacion.ClientID %>').value == '11') {
                    error = 0;
                } else if (document.getElementById('<%=ddlUbicacion.ClientID %>').value == '-1') {
                    error = 1;
                } else if (document.getElementById('<%=ddlLinea.ClientID %>').value == '-1') {
                    error = 1;
                }

            }
            if (error == 0) {
                return true;
            }
            else if (error == 1) {
                $('#warning').text('Valide los campos').fadeIn(800).delay(4000).fadeOut(800);
                //                alert('Valide los datos antes de grabar');
                return false;
            } 
        }
    </script>
</body>
</html>