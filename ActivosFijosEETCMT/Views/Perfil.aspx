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
                    Perfil <small>Configuración de perfil</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Configuración</a></li>
                    <li class="active">Perfil</li>
                </ol>
            </section>
            <section class="content">
                <div class="row" ">
                    <div class="col-md-6" style="display:none;>
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
                                Gerencia</label>
                                  <select id="gerencia" class="form-control">
                            </select>
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
