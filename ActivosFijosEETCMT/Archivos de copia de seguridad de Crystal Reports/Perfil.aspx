<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ActivosFijosEETC.Views.Perfil1" %>

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

       <!-- jQuery 2.0.2 -->
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    
    
   <!-- jQuery UI 1.10.3 -->
    <script src="bootstrap/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

      <!-- Sparkline -->
    <script src="bootstrap/js/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- jvectormap -->
    <script src="bootstrap/js/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"
        type="text/javascript"></script>

     <!-- Bootstrap WYSIHTML5 -->
    <script src="bootstrap/js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"
        type="text/javascript"></script>
    
    <!-- AdminLTE App -->
    <script src="bootstrap/js/AdminLTE/app.js" type="text/javascript"></script>
   


    <!-- AdminLTE for demo purposes -->
    <script src="bootstrap/js/AdminLTE/demo.js" type="text/javascript"></script>
  
   
     <script src="js/json2.js"                type="text/javascript"></script>
    <script  type="text/javascript">        document.write('<script src="js/Perfil.js" type="text/javascript"><\/script>');   
    </script>
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
                    <div class="col-md-6">
                        <div class="box box-warning">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Datos del Usuario</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                               <div class="form-group">
                                <label for="nombre" >
                                Nombres</label>
                                <input id="nombre" type="text" placeholder="Nombres" class="form-control" />
                            </div>
                        
                               <div class="form-group">
                                 <label for="apellido">
                                Apellidos</label>
                                <input id="apellido" type="text" placeholder="Apellidos" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="area" >
                            Área</label>
                                  <select id="area" class="form-control">
                        </select>
                            </div>

                            <div class="form-group">
                               <label for="cargo" >
                            Cargo</label>
                                   <select id="cargo" name="cargo" class="form-control"> 
                        </select>
                      
                            </div>

                             <div class="form-group">
                              <label for="perfil" >
                            Perfil:</label>
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
                    <div class="col-md-6">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Cambio Contraseña</h3>
                            </div>
                            <!-- /.box-header -->
                            <!-- form start -->
                            <div class="box-body">
                                <div class="form-group">
                                     <label for="usuario" class="labelForms">
                            Usuario</label>
                                     <input id="usuario" type="text" placeholder="Usuario" class="form-control" disabled="disabled"/>
                                </div>
                                <div class="form-group">
                                    <label for="clave" class="labelForms">
                            Contraseña nueva:</label>
                                   <input id="claveNueva" type="password" placeholder="Contraseña nueva" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label for="clave" class="labelForms">
                            Confirmación contraseña:</label>
                                    <input id="confirm" type="password" placeholder="Confirmar contraseña" class="form-control" />
                                </div>
                                <div class="form-group">
                                   <label for="clave" class="labelForms">
                            Contraseña actual:</label>
                                    <input id="claveActual" type="password" placeholder="Contraseña actual" class="form-control" />
                                </div>
                               
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer">
                                <button id="GuardarPass" type="button" class="btn btn-primary">
                                    Guardar cambios</button>
                            </div>
                        </div>
                        <div id="dangerPass" class="alert alert-warning" role="alert" style="display: none">
                            <strong>Error!</strong>
                        </div>
                        <div id="successPass" class="alert alert-success" role="alert" style="display: none">
                            <strong>Correcto!</strong>
                        </div>
                        <div id="errorPass" class="alert alert-danger" role="alert" style="display: none">
                            <strong>Correcto!</strong>
                        </div>
                    </div>
                
                <!-- /.box -->
                </div>
            </section>
        </aside>


    </div>
    <!-- ./wrapper -->


 
</body>
</html>
