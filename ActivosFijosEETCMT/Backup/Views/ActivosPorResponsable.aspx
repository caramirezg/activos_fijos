<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivosPorResponsable.aspx.cs" Inherits="ActivosFijosEETC.Views.ActivosPorResponsable" %>

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
                    Activos Por Responsable <small></small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Reportes</a></li>
                    <li class="active">Activos Por Responsable</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div id="div_gruposcontables" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Personal</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <asp:Button ID="btnImprimirActivosPorResponsable" runat="server" 
                                    CssClass="btn btn-primary" Text="Imprimir Reporte" onclick="btnImprimirActivosPorResponsable_Click"
                                    />
                            </div>

                            <div class="alert alert-info alert-dismissable">
                                        <i class="fa fa-info"></i>
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                        <b>Información!</b> Busqué la persona por los campos de la grilla
                                    </div>

                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                 
                                    <dx:ASPxGridView ID="gridPersonal" runat="server" Theme="Aqua" Width="100%" 
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Documento" FieldName="documento" 
                                                VisibleIndex="1">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Nombres" FieldName="nombres" 
                                                VisibleIndex="2">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Apellidos" FieldName="apellidos" 
                                                VisibleIndex="3">
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
                                            <dx:GridViewDataTextColumn Caption="Area" FieldName="area" VisibleIndex="5">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Estado" FieldName="estado" Visible="False" 
                                                VisibleIndex="6">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsBehavior AllowFocusedRow="True" />
                                        <Settings ShowFilterRow="True" ShowHeaderFilterButton="True" />
<SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                    </dx:ASPxGridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </section>
            </form>
        </aside>
    </div>
    <!-- ./wrapper -->

    <script type = "text/javascript">
        window.onload = function () {
            document.onkeydown = function (e) {
                return (e.which || e.keyCode) != 116;
            };
        }
</script>

</body>
</html>
