<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarProveedor.aspx.cs" Inherits="ActivosFijosEETC.Views.EditarProveedor" %>

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
      <script src="http://maps.googleapis.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script src="js/json2.js" type="text/javascript"></script>
    <script src="js/jquery.plugins.js" type="text/javascript"></script>
     <script type="text/javascript">
         document.write('<script src="js/EditaProveedor.js" type="text/javascript"><\/script>');
    </script>
    <script type="text/javascript" src="map/gmap3.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#test").gmap3({
                map: {
                    options: {
                        zoom: 14,
                        center: [-16.4992945, -68.1353024],
                        streetViewControl: false
                    }
                }
            });
        });
    </script>
     <style type="text/css">
        .gmap3
        {
            border: 1px dashed #C0C0C0;
            width: 90%;
            height: 400px;
        }
    </style>

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
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="bootstrap/js/AdminLTE/dashboard.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
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
                   <span class="fa fa-pencil"></span> Proveedores <small>Editar de Proveedor</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Proveedores</a></li>
                    <li class="active">Editar de Proveedor</li>
                </ol>
            </section>
            <section class="content">
                <div class="row">
                    <div class="col-md-6">
                        <div class="box box-warning">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Ubicación Geográfica</h3>
                            </div>
                            <!-- /.box-header -->
                             <div class="alert alert-info alert-dismissable">
                                        <i class="fa fa-info"></i>
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                        <b>Ubicación Geográfica!</b> Seleccione un punto en el mapa
                                    </div>
                            <div class="box-body">
                                <!--mapa-->
                                <div id="test" class="gmap3">
                                </div>
                                <input type="text" style="display: none; top: 10px;" name="zoom" id="Lat" />
                                <input type="text" style="display: none; top: 50px;" name="zoom" id="Long" />
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                    </div>
                    <div class="col-md-6">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Datos del Proveedor</h3>
                            </div>
                            <!-- /.box-header -->
                            <!-- form start -->
                            <div class="box-body">
                            <div class="form-group">
                             <label for="nombre">
                                        Proveedores</label>
                              <select id="ItemOption" name="standard-dropdown" style="width: 100%; color: Black;
                                height: 30px;">
                                <option value="">Seleccione un Proveedor</option>
                            </select>
                            </div>
                             <div class="alert alert-info alert-dismissable">
                                        <i class="fa fa-info"></i>
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                        <b>Información!</b> Debe seleccionar un proveedor para cargar los datos.
                                    </div>
                            
                                <div class="form-group">
                                    <label for="nombre">
                                        Nombre</label>
                                    <input id="nombre" type="text" class="form-control" placeholder="Nombre del Proveedor">
                                </div>
                                <div class="form-group">
                                    <label for="telefono">
                                        Teléfono</label>
                                    <input id="telefono" type="text" class="form-control" placeholder="Ingrese el Numero Telefónico de la Empresa">
                                </div>
                                <div class="form-group">
                                    <label for="celular">
                                        Celular</label>
                                    <input id="celular" type="text" class="form-control" placeholder="Ingrese el número Celular de la Empresa">
                                </div>
                                <div class="form-group">
                                    <label for="nit">
                                        Nit</label>
                                    <input id="nit" type="text" class="form-control" placeholder="Ingrese el Número Nit del Proveedor">
                                </div>
                                <div class="form-group">
                                    <label for="direccion">
                                        Dirección</label>
                                    <input id="direccion" type="text" class="form-control" placeholder="Ingrese la Avenida, Zona y Número">
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer">
                                <button id="registerButton" type="button" class="btn btn-primary">
                                    Save changes</button>
                            </div>
                        </div>
                        <div id="danger" class="alert alert-warning" role="alert" style="display: none">
                            <strong>Error!</strong>
                        </div>
                        <div id="success" class="alert alert-success" role="alert" style="display: none">
                            <strong>Correcto!</strong>
                        </div>
                        <div id="error" class="alert alert-danger" role="alert" style="display: none">
                            <strong>Correcto!</strong>
                        </div>
                    </div>
                </div>
                <!-- /.box -->
            </section>
        </aside>
    </div>
    <!-- ./wrapper -->
</body>
</html>
