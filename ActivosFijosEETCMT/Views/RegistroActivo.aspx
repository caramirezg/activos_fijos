<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroActivo.aspx.cs" Inherits="ActivosFijosEETC.Views.RegistroActivo" %>

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
                    <!-- Messages: style can be found in dropdown.less-->
                    <li class="dropdown messages-menu"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="fa fa-envelope"></i><span class="label label-success">4</span> </a>
                        <ul class="dropdown-menu">
                            <li class="header">You have 4 messages</li>
                            <li>
                                <!-- inner menu: contains the actual data -->
                                <ul class="menu">
                                    <li>
                                        <!-- start message -->
                                        <a href="#">
                                            <div class="pull-left">
                                                <img src="img/avatar3.png" class="img-circle" alt="User Image" />
                                            </div>
                                            <h4>
                                                Support Team <small><i class="fa fa-clock-o"></i>5 mins</small>
                                            </h4>
                                            <p>
                                                Why not buy a new awesome theme?</p>
                                        </a></li>
                                    <!-- end message -->
                                    <li><a href="#">
                                        <div class="pull-left">
                                            <img src="img/avatar2.png" class="img-circle" alt="user image" />
                                        </div>
                                        <h4>
                                            AdminLTE Design Team <small><i class="fa fa-clock-o"></i>2 hours</small>
                                        </h4>
                                        <p>
                                            Why not buy a new awesome theme?</p>
                                    </a></li>
                                    <li><a href="#">
                                        <div class="pull-left">
                                            <img src="img/avatar.png" class="img-circle" alt="user image" />
                                        </div>
                                        <h4>
                                            Developers <small><i class="fa fa-clock-o"></i>Today</small>
                                        </h4>
                                        <p>
                                            Why not buy a new awesome theme?</p>
                                    </a></li>
                                    <li><a href="#">
                                        <div class="pull-left">
                                            <img src="img/avatar2.png" class="img-circle" alt="user image" />
                                        </div>
                                        <h4>
                                            Sales Department <small><i class="fa fa-clock-o"></i>Yesterday</small>
                                        </h4>
                                        <p>
                                            Why not buy a new awesome theme?</p>
                                    </a></li>
                                    <li><a href="#">
                                        <div class="pull-left">
                                            <img src="img/avatar.png" class="img-circle" alt="user image" />
                                        </div>
                                        <h4>
                                            Reviewers <small><i class="fa fa-clock-o"></i>2 days</small>
                                        </h4>
                                        <p>
                                            Why not buy a new awesome theme?</p>
                                    </a></li>
                                </ul>
                            </li>
                            <li class="footer"><a href="#">See All Messages</a></li>
                        </ul>
                    </li>
                    <!-- Notifications: style can be found in dropdown.less -->
                    <li class="dropdown notifications-menu"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="fa fa-warning"></i><span class="label label-warning">10</span> </a>
                        <ul class="dropdown-menu">
                            <li class="header">You have 10 notifications</li>
                            <li>
                                <!-- inner menu: contains the actual data -->
                                <ul class="menu">
                                    <li><a href="#"><i class="ion ion-ios7-people info"></i>5 new members joined today </a>
                                    </li>
                                    <li><a href="#"><i class="fa fa-warning danger"></i>Very long description here that
                                        may not fit into the page and may cause design problems </a></li>
                                    <li><a href="#"><i class="fa fa-users warning"></i>5 new members joined </a></li>
                                    <li><a href="#"><i class="ion ion-ios7-cart success"></i>25 sales made </a></li>
                                    <li><a href="#"><i class="ion ion-ios7-person danger"></i>You changed your username
                                    </a></li>
                                </ul>
                            </li>
                            <li class="footer"><a href="#">View all</a></li>
                        </ul>
                    </li>
                    <!-- Tasks: style can be found in dropdown.less -->
                    <li class="dropdown tasks-menu"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="fa fa-tasks"></i><span class="label label-danger">9</span> </a>
                        <ul class="dropdown-menu">
                            <li class="header">You have 9 tasks</li>
                            <li>
                                <!-- inner menu: contains the actual data -->
                                <ul class="menu">
                                    <li>
                                        <!-- Task item -->
                                        <a href="#">
                                            <h3>
                                                Design some buttons <small class="pull-right">20%</small>
                                            </h3>
                                            <div class="progress xs">
                                                <div class="progress-bar progress-bar-aqua" style="width: 20%" role="progressbar"
                                                    aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                                                    <span class="sr-only">20% Complete</span>
                                                </div>
                                            </div>
                                        </a></li>
                                    <!-- end task item -->
                                    <li>
                                        <!-- Task item -->
                                        <a href="#">
                                            <h3>
                                                Create a nice theme <small class="pull-right">40%</small>
                                            </h3>
                                            <div class="progress xs">
                                                <div class="progress-bar progress-bar-green" style="width: 40%" role="progressbar"
                                                    aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                                                    <span class="sr-only">40% Complete</span>
                                                </div>
                                            </div>
                                        </a></li>
                                    <!-- end task item -->
                                    <li>
                                        <!-- Task item -->
                                        <a href="#">
                                            <h3>
                                                Some task I need to do <small class="pull-right">60%</small>
                                            </h3>
                                            <div class="progress xs">
                                                <div class="progress-bar progress-bar-red" style="width: 60%" role="progressbar"
                                                    aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                                                    <span class="sr-only">60% Complete</span>
                                                </div>
                                            </div>
                                        </a></li>
                                    <!-- end task item -->
                                    <li>
                                        <!-- Task item -->
                                        <a href="#">
                                            <h3>
                                                Make beautiful transitions <small class="pull-right">80%</small>
                                            </h3>
                                            <div class="progress xs">
                                                <div class="progress-bar progress-bar-yellow" style="width: 80%" role="progressbar"
                                                    aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                                                    <span class="sr-only">80% Complete</span>
                                                </div>
                                            </div>
                                        </a></li>
                                    <!-- end task item -->
                                </ul>
                            </li>
                            <li class="footer"><a href="#">View all tasks</a> </li>
                        </ul>
                    </li>
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
                            <li><a href="pages/forms/general.html"><i class="fa fa-angle-double-right"></i>Grupos contables</a></li>
                          
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
                            <li><a href="RegistroProveedor.aspx"><i class="fa fa-angle-double-right"></i>Control Compras</a></li>
                            <li><a href="EditarProveedor.aspx"><i class="fa fa-angle-double-right"></i>Registro Compras</a></li>
                            <li><a href="BuscaProveedor.aspx"><i class="fa fa-angle-double-right"></i>Registro Individual</a></li>
                        </ul>
                    </li>

                    <li class="treeview"><a href="#"><i class="fa fa-laptop"></i><span>Activos</span>
                        <i class="fa fa-angle-left pull-right"></i></a>
                        <ul class="treeview-menu">
                            <li><a href="pages/UI/general.html"><i class="fa fa-angle-double-right"></i>Códigos de barra</a></li>
                            <li><a href="pages/UI/icons.html"><i class="fa fa-angle-double-right"></i>Registro de activos</a></li>
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
            <section class="content-header">
                <h1>
                    Perfil <small>Configuración de perfil</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Configuración</a></li>
                    <li class="active">Perfil</li>
                </ol>
            </section>
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-success">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Datos del Activo</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                               <div class="form-group">
                                <label for="nombre" >
                                Responsable</label>
                                <input id="nombre" type="text" placeholder="Nombres" class="form-control" />
                                </div>
                        
                               <div class="form-group">
                                 <label for="apellido">Categoría
                                </label>
                                <input id="apellido" type="text" placeholder="Apellidos" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="area" >
                            Sub-Categoria</label>
                                  <select id="area" class="form-control">
                        </select>
                            </div>

                            <div class="form-group">
                               <label for="cargo" >
                            Marcas</label>
                                   <select id="cargo" name="cargo" class="form-control"> 
                        </select>
                      
                            </div>

                             <div class="form-group">
                              <label for="perfil" >
                            Modelos</label>
                                  <input id="perfil" type="text" placeholder="Perfil" class="form-control" disabled ="disabled"/>
                       
                            </div>

                              <div class="form-group">
                                <label for="estado" >
                            Estado:</label>
                                 <input id="estado" type="text" placeholder="Estado" class="form-control" disabled="disabled" />
                       
                            </div>
                      
                             </div>
                            <!-- /.box-body -->
                                <div class="box-footer">
                                <button type=button id="guardarDatosUsuario" class="btn btn-primary">
                    Guardar cambios</button>
                                </div>
                       
                        <!-- /.box -->
                         <div id="dangerDatos" class="alert alert-warning" role="alert" style="display: none">
                            <strong>Error!</strong>
                        </div>
                        <div id="successDatos" class="alert alert-success" role="alert" style="display: none">
                            <strong>Correcto!</strong>
                        </div>
                        <div id="errorDatos" class="alert alert-danger" role="alert" style="display: none">
                            <strong>Correcto!</strong>
                        </div>
                    </div>
                    </div>
                   
                
                <!-- /.box -->
                </div>
            </section>
        </aside>






    </div>
    <!-- ./wrapper -->
    <!-- add new calendar event modal -->

    <!-- jQuery 2.0.2 -->
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="http://maps.googleapis.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script type="text/javascript">
        document.write('<script src="js/BuscarProveedores.js" type="text/javascript"><\/script>');   
    </script>
    
    <script src="map/gmap3.js" type="text/javascript" ></script>  
    

     <style type="text/css">

    .gmap3
        {
            border: 1px dashed #C0C0C0;
            width: 100%;
            height: 400px; 
        }
      .Desc {
          padding: 2px;
      }
      .Desc>h1 {
          font-size: 15px;
          border-bottom: 1px solid #566579;
          color: #2365B0;
      }
      .Desc>h2 {
          font-size: 12px;
          margin-top: 5px;
          padding: 2px 0 2px 25px;
          background: url(img/house.png) no-repeat 0px 0px;
          color: #030405;
          
      }
      .Desc>h3 {
          font-size: 12px;
          padding: 2px 0 2px 25px;
          background: url(img/phone.png) no-repeat 0px 1px;
          color: #030405;
      }
      
      
    
    </style>
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


    <!-- AdminLTE for demo purposes -->
    <script src="bootstrap/js/AdminLTE/demo.js" type="text/javascript"></script>
  
   
    
    
    
 

   
       
    
  


</body>
</html>
