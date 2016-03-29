<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ActivosFijosEETC.Views.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
      
   
</head>
<body class="skin-blue">
    <!-- header logo: style can be found in header.less -->
    <header class="header">
        <a href="index.html" class="logo">
            <!-- Add the class icon to your logo image or logo icon to add the margining -->
            <p>
                <strong>Control de Activos Fijos</strong></p>
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
                           
                            <!-- Menu Body -->
                            <li class="user-body">
                                <div class="col-xs-4 text-center">
                                    <a href="#">Activos</a>
                                </div>
                                <div class="col-xs-4 text-center">
                                    <a href="#">Compras</a>
                                </div>
                                <div class="col-xs-4 text-center">
                                    <a href="#">Usuarios</a>
                                </div>
                            </li>
                            <!-- Menu Footer-->
                            <li class="user-footer">
                                <div class="pull-left">
                                    <a href="Perfil.aspx" class="btn btn-default btn-flat">Perfil</a>
                                </div>
                                <div class="pull-right">
                                    <a href="Login.aspx" class="btn btn-default btn-flat">Sign out</a>
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
                    <img src="img/logoBlue.JPG" class="img-thumbnail" alt="User Image" />
                    <div class="pull-left image">
                    </div>
                    <div class="pull-left info">
                        <p>
                            <asp:Label ID="lblUsuario" Text="text" runat="server" /></p>
                        <a href="#"><i class="fa fa-circle text-success"></i>Online</a>
                    </div>
                </div>
                <!-- /.search form -->
                <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu">
                    <li class="active"><a href="Default.aspx"><i class="fa fa-dashboard"></i><span>Dashboard</span>
                    </a></li>
                     <li class="treeview"><a href="#"><i class="fa fa-edit"></i><span>Parametrización</span> <i
                        class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                        <li><a href="TasasCambio.aspx"><i class="fa fa-angle-double-right"></i>Tasas de Cambio</a></li>
                            <li><a href="GruposContables.aspx"><i class="fa fa-angle-double-right"></i>Grupos Contables</a></li>
                             <li><a href="GruposAuxiliares.aspx"><i class="fa fa-angle-double-right"></i>Auxiliares Contables</a></li>  
                              <li><a href="Marcas.aspx"><i class="fa fa-angle-double-right"></i>Marcas - Modelos</a></li>     
                              <li><a href="Personal.aspx"><i class="fa fa-angle-double-right"></i>Personal</a></li>                                              
                        </ul>
                    </li>
                     <li class="treeview"><a href="#"><i class="fa fa-group"></i><span>Proveedores</span>
                        <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="RegistroProveedor.aspx"><i class="fa fa-angle-double-right"></i>Registrar
                                Proveedor</a></li>
                            <li><a href="EditarProveedor.aspx"><i class="fa fa-angle-double-right"></i>Editar Proveedor</a></li>
                            <li><a href="BuscaProveedor.aspx"><i class="fa fa-angle-double-right"></i>Buscar</a></li>
                            <li><a href="RutasProveedor.aspx"><i class="fa fa-angle-double-right"></i>Rutas</a></li>
                            <li><a href="ListaProveedores.aspx"><i class="fa fa-angle-double-right"></i>Lista Proveedores</a></li>
                        </ul>
                    </li>

                    <li class="treeview"><a href="#"><i class="fa fa-shopping-cart"></i><span>Compras</span>
                        <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="Compras.aspx"><i class="fa fa-angle-double-right"></i>Gestión Compras</a></li>
                        </ul>
                    </li>

                    <li class="treeview"><a href="#"><i class="fa fa-gift"></i><span>Donación</span>
                        <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="Compras.aspx"><i class="fa fa-angle-double-right"></i>Registro Donación</a></li>
                        </ul>
                    </li>

                    <li class="treeview"><a href="#"><i class="fa fa-retweet"></i><span>Transferencias</span>
                        <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="Transferencias.aspx"><i class="fa fa-angle-double-right"></i>Registro Transferencias</a></li>
                        </ul>
                    </li>

                    <li class="treeview"><a href="#"><i class="fa fa-laptop"></i><span>Activos</span>
                        <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="pages/UI/general.html"><i class="fa fa-angle-double-right"></i>Códigos de barra</a></li>
                            <li><a href="RegistroActivosPorCompras.aspx"><i class="fa fa-angle-double-right"></i>Registro de activos</a></li>
                            <li><a href="pages/UI/buttons.html"><i class="fa fa-angle-double-right"></i>Asignaciones</a></li>
                            <li><a href="pages/UI/sliders.html"><i class="fa fa-angle-double-right"></i>Transferencias</a></li>
                            
                        </ul>
                    </li>
                   
                    <li class="treeview"><a href="#"><i class="fa fa-bar-chart-o"></i><span>Reportes</span>
                        <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="pages/charts/morris.html"><i class="fa fa-angle-double-right"></i>Prestamos</a></li>
                            <li><a href="pages/charts/flot.html"><i class="fa fa-angle-double-right"></i>Compras</a></li>
                            <li><a href="pages/charts/inline.html"><i class="fa fa-angle-double-right"></i>Activos sin seguro</a></li>
                            <li><a href="pages/charts/inline.html"><i class="fa fa-angle-double-right"></i>Garantias</a></li>
                            <li><a href="pages/charts/inline.html"><i class="fa fa-angle-double-right"></i>Activos sin seguro</a></li>
                            <li><a href="pages/charts/inline.html"><i class="fa fa-angle-double-right"></i>Asignaciones</a></li>
                            <li><a href="pages/charts/inline.html"><i class="fa fa-angle-double-right"></i>Depreciación</a></li>
                        </ul>
                    </li>
                    
                   
                    
                </ul>
            </section>
            <!-- /.sidebar -->
        </aside>
        <!-- Right side column. Contains the navbar and content of the page -->
        <aside class="right-side">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>
                    Dashboard <small>Panel de control</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li class="active">Dashboard</li>
                </ol>
            </section>
            <!-- Main content -->
            <section class="content">
                <!-- Small boxes (Stat box) -->
                <div class="row">
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-aqua">
                            <div class="inner">
                                <h3>
                                    5.386.248,51 <sup style="font-size: 20px">Bs</sup>
                                </h3>
                                <p>
                                    Compras Activos
                                </p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-bag"></i>
                            </div>
                            <a href="#" class="small-box-footer">Más informacion <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-green">
                            <div class="inner">
                                <h3>
                                    53<sup style="font-size: 20px">%</sup>
                                </h3>
                                <p>
                                    Activos Prestados
                                </p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-stats-bars"></i>
                            </div>
                            <a href="#" class="small-box-footer">Más información <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-yellow">
                            <div class="inner">
                                <h3>
                                    44
                                </h3>
                                <p>
                                    Activos sin seguro
                                </p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-person-add"></i>
                            </div>
                            <a href="#" class="small-box-footer">Más Información <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-red">
                            <div class="inner">
                                <h3>
                                    65
                                </h3>
                                <p>
                                    Alerta de activos depreciados
                                </p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-pie-graph"></i>
                            </div>
                            <a href="#" class="small-box-footer">Más Información <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                </div>
                <!-- /.row -->
                <!-- Main row -->
                <div class="row">
                    <!-- Left col -->
                    <section class="col-lg-7 connectedSortable">
                        <!-- Custom tabs (Charts with tabs)-->
                        <div class="nav-tabs-custom">
                            <!-- Tabs within a box -->
                            <ul class="nav nav-tabs pull-right">
                                <li class="active"><a href="#revenue-chart" data-toggle="tab">Area</a></li>
                                <li><a href="#sales-chart" data-toggle="tab">Donut</a></li>
                                <li class="pull-left header"><i class="fa fa-shopping-cart"></i>Compras de activos</li>
                            </ul>
                            <div class="tab-content no-padding">
                                <!-- Morris chart - Sales -->
                                <div class="chart tab-pane active" id="revenue-chart" style="position: relative;
                                    height: 300px;">
                                </div>
                                <div class="chart tab-pane" id="sales-chart" style="position: relative; height: 300px;">
                                </div>
                            </div>
                        </div>
                        <!-- /.nav-tabs-custom -->
                        <!-- Chat box -->
                        <div class="box box-success">
                            <div class="box-header">
                                <i class="fa fa-comments-o"></i>
                                <h3 class="box-title">
                                    Chat</h3>
                                <div class="box-tools pull-right" data-toggle="tooltip" title="Status">
                                    <div class="btn-group" data-toggle="btn-toggle">
                                        <button type="button" class="btn btn-default btn-sm active">
                                            <i class="fa fa-square text-green"></i>
                                        </button>
                                        <button type="button" class="btn btn-default btn-sm">
                                            <i class="fa fa-square text-red"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div class="box-body chat" id="chat-box">
                                <!-- chat item -->
                                <div class="item">
                                    <img src="img/avatar.png" alt="user image" class="online" />
                                    <p class="message">
                                        <a href="#" class="name"><small class="text-muted pull-right"><i class="fa fa-clock-o">
                                        </i>2:15</small> Mike Doe </a>I would like to meet you to discuss the latest news
                                        about the arrival of the new theme. They say it is going to be one the best themes
                                        on the market
                                    </p>
                                    <div class="attachment">
                                        <h4>
                                            Attachments:</h4>
                                        <p class="filename">
                                            Theme-thumbnail-image.jpg
                                        </p>
                                        <div class="pull-right">
                                            <button class="btn btn-primary btn-sm btn-flat">
                                                Open</button>
                                        </div>
                                    </div>
                                    <!-- /.attachment -->
                                </div>
                                <!-- /.item -->
                                <!-- chat item -->
                                <div class="item">
                                    <img src="img/avatar2.png" alt="user image" class="offline" />
                                    <p class="message">
                                        <a href="#" class="name"><small class="text-muted pull-right"><i class="fa fa-clock-o">
                                        </i>5:15</small> </a>I would like to meet you to discuss the latest news about the
                                        arrival of the new theme. They say it is going to be one the best themes on the
                                        market
                                    </p>
                                </div>
                                <!-- /.item -->
                                <!-- chat item -->
                                <div class="item">
                                    <img src="img/avatar3.png" alt="user image" class="offline" />
                                    <p class="message">
                                        <a href="#" class="name"><small class="text-muted pull-right"><i class="fa fa-clock-o">
                                        </i>5:30</small> Susan Doe </a>I would like to meet you to discuss the latest news
                                        about the arrival of the new theme. They say it is going to be one the best themes
                                        on the market
                                    </p>
                                </div>
                                <!-- /.item -->
                            </div>
                            <!-- /.chat -->
                            <div class="box-footer">
                                <div class="input-group">
                                    <input class="form-control" placeholder="Type message..." />
                                    <div class="input-group-btn">
                                        <button class="btn btn-success">
                                            <i class="fa fa-plus"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.box (chat box) -->
                      
                    </section><!-- /.Left col -->
                    <!-- right col (We are only adding the ID to make the widgets sortable)-->
                    <section class="col-lg-5 connectedSortable">
                        <!-- Map box -->
                      
                       <%-- <div class="box box-solid bg-black-gradient">
                            <div class="box-header">
                                <!-- tools box -->
                                <div class="pull-right box-tools">
                                    
                                    <button class="btn btn-primary btn-sm pull-right bg-black" data-widget='collapse' data-toggle="tooltip"
                                        title="Collapse" style="margin-right: 5px;">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                                <!-- /. tools -->
                                <i class="fa fa-map-marker"></i>
                                <h3 class="box-title">
                                    Proveedores
                                </h3>
                            </div>
                            <div class="box-body">
                                <div id="test" class="gmap3">
                                </div>
                            </div>
                            <!-- /.box-body-->
                            <div class="box-footer no-border">
                                <div class="row">
                                    <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                                        <div id="sparkline-1">
                                        </div>
                                        <div class="knob-label">
                                            Visitors</div>
                                    </div>
                                    <!-- ./col -->
                                    <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                                        <div id="sparkline-2">
                                        </div>
                                        <div class="knob-label">
                                            Online</div>
                                    </div>
                                    <!-- ./col -->
                                    <div class="col-xs-4 text-center">
                                        <div id="sparkline-3">
                                        </div>
                                        <div class="knob-label">
                                            Exists</div>
                                    </div>
                                    <!-- ./col -->
                                </div>
                                <!-- /.row -->
                            </div>
                        </div>--%>
                        <!-- /.box -->
                        <!-- solid sales graph -->
                        <div class="box box-solid bg-teal-gradient">
                            <div class="box-header">
                                <i class="fa fa-th"></i>
                                <h3 class="box-title">
                                    Sales Graph</h3>
                                <div class="box-tools pull-right">
                                    <button class="btn bg-teal btn-sm" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                    <button class="btn bg-teal btn-sm" data-widget="remove">
                                        <i class="fa fa-times"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body border-radius-none">
                                <div class="chart" id="line-chart" style="height: 250px;">
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer no-border">
                                <div class="row">
                                    <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                                        <input type="text" class="knob" data-readonly="true" value="20" data-width="60" data-height="60"
                                            data-fgcolor="#39CCCC" />
                                        <div class="knob-label">
                                            Mail-Orders</div>
                                    </div>
                                    <!-- ./col -->
                                    <div class="col-xs-4 text-center" style="border-right: 1px solid #f4f4f4">
                                        <input type="text" class="knob" data-readonly="true" value="50" data-width="60" data-height="60"
                                            data-fgcolor="#39CCCC" />
                                        <div class="knob-label">
                                            Online</div>
                                    </div>
                                    <!-- ./col -->
                                    <div class="col-xs-4 text-center">
                                        <input type="text" class="knob" data-readonly="true" value="30" data-width="60" data-height="60"
                                            data-fgcolor="#39CCCC" />
                                        <div class="knob-label">
                                            In-Store</div>
                                    </div>
                                    <!-- ./col -->
                                </div>
                                <!-- /.row -->
                            </div>
                            <!-- /.box-footer -->
                        </div>
                        <!-- /.box -->
                        <!-- Calendar -->
                        <div class="box box-solid bg-green-gradient">
                            <div class="box-header">
                                <i class="fa fa-calendar"></i>
                                <h3 class="box-title">
                                    Calendar</h3>
                                <!-- tools box -->
                                <div class="pull-right box-tools">
                                    <!-- button with a dropdown -->
                                    <div class="btn-group">
                                        <button class="btn btn-success btn-sm dropdown-toggle" data-toggle="dropdown">
                                            <i class="fa fa-bars"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right" role="menu">
                                            <li><a href="#">Add new event</a></li>
                                            <li><a href="#">Clear events</a></li>
                                            <li class="divider"></li>
                                            <li><a href="#">View calendar</a></li>
                                        </ul>
                                    </div>
                                    <button class="btn btn-success btn-sm" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                    <button class="btn btn-success btn-sm" data-widget="remove">
                                        <i class="fa fa-times"></i>
                                    </button>
                                </div>
                                <!-- /. tools -->
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <!--The calendar -->
                                <div id="calendar" style="width: 100%">
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer text-black">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <!-- Progress bars -->
                                        <div class="clearfix">
                                            <span class="pull-left">Task #1</span> <small class="pull-right">90%</small>
                                        </div>
                                        <div class="progress xs">
                                            <div class="progress-bar progress-bar-green" style="width: 90%;">
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <span class="pull-left">Task #2</span> <small class="pull-right">70%</small>
                                        </div>
                                        <div class="progress xs">
                                            <div class="progress-bar progress-bar-green" style="width: 70%;">
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-sm-6">
                                        <div class="clearfix">
                                            <span class="pull-left">Task #3</span> <small class="pull-right">60%</small>
                                        </div>
                                        <div class="progress xs">
                                            <div class="progress-bar progress-bar-green" style="width: 60%;">
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <span class="pull-left">Task #4</span> <small class="pull-right">40%</small>
                                        </div>
                                        <div class="progress xs">
                                            <div class="progress-bar progress-bar-green" style="width: 40%;">
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->
                            </div>
                        </div>
                        <!-- /.box -->
                    </section><!-- right col -->
                </div>
                <!-- /.row (main row) -->
            </section>
            <!-- /.content -->
        </aside><!-- /.right-side -->
    </div>
    <!-- ./wrapper -->
    <!-- add new calendar event modal -->

    <!-- jQuery 2.0.2 -->
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>

   

    
   <!-- jQuery UI 1.10.3 -->
    <script src="bootstrap/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
     <!-- Morris.js charts -->
     <script src="//cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
     <script src="js/plugins/morris/morris.min.js" type="text/javascript"></script>
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
    
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="bootstrap/js/AdminLTE/dashboard.js" type="text/javascript"></script>


  
  
   
    
    
    
 

   
       
    
  


</body>
</html>
