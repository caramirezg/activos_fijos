<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RutasProveedor.aspx.cs" Inherits="ActivosFijosEETC.Views.RutasProveedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="css/proveedores.css" rel="stylesheet" type="text/css" />
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


     <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>

    <!-- jQuery UI 1.10.3 -->
    <script src="bootstrap/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
      
    <!-- AdminLTE for demo purposes -->
    <script src="bootstrap/js/AdminLTE/demo.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    
    <!-- Sparkline -->
    <script src="bootstrap/js/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- jvectormap -->
    <script src="bootstrap/js/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"
        type="text/javascript"></script>
   
    
         
    <!-- iCheck -->
    <script src="bootstrap/js/plugins/iCheck/icheck.min.js" type="text/javascript"></script>
    <!-- AdminLTE App -->
    <script src="bootstrap/js/AdminLTE/app.js" type="text/javascript"></script>
    
      
     <script src="http://maps.googleapis.com/maps/api/js?sensor=false" type="text/javascript"></script>
     <script src="js/jquery.plugins.js" type="text/javascript"></script>
     <script src="map/gmap3.js" type="text/javascript" ></script>     
     <style type="text/css">
        .gmap3
        {
            border: 1px dashed #C0C0C0;
            width: 90%;
            height: 400px;
        }
        .Desc
        {
            padding: 1px;
            font-family: Arial,Helvetica,sans-serif;
        }
        .Desc > h1
        {
            font-size: 15px;
            border-bottom: 1px solid #566579;
            color: #2365B0;
        }
        .Desc > h2
        {
            font-size: 12px;
            margin-top: 5px;
            padding: 2px 0 2px 25px;
            background: url(img/house.png) no-repeat 0px 0px;
            color: #030405;
        }
        .Desc > h3
        {
            font-size: 12px;
            padding: 2px 0 2px 25px;
            background: url(img/phone.png) no-repeat 0px 1px;
            color: #030405;
        }
    </style>

     <script type="text/javascript">
         $.ajax({
             type: "POST",
             url: "../Controllers/ControllerProveedor.asmx/DatosProveedores",
             data: {},
             contentType: "application/json; chartset:utf-8",
             dataType: "json",
             async: false,
             success: loadItems,
             error: function (XMLHttpRequest, textStatus, errorThrown) {
                 alert(textStatus + ": " + XMLHttpRequest.responseText);
             },
             async: true
         });
         function loadItems(result) {


             $.each(result.d, function () {
                 $('#Proveedor1, #Proveedor2').append($("<option></option>").attr("value", (this.lati.trim() + '|' + this.longi.trim())).text(this.nombre));
             });
             $('#Proveedor1, #Proveedor2').selectBox().selectBox('settings', {
                 'menuTransition': 'slide',
                 'menuSpeed': 0
             });
         }

         $(function () {

             RenderMap();

             $('#Generar').click(function () {
                 var origen = $('#Proveedor1').val();
                 var destino = $('#Proveedor2').val();
                 if (origen != "" && destino != "")
                     updateDirections(origen, destino);
             });
         });

         function RenderMap() {

             $("#test").gmap3({
                 map: {
                     options: {
                         center: [-16.500287, -68.122473],
                         zoom: 14
                     }
                 },
                 marker: {
                     values: [{ latLng: [-16.499217, -68.13515]}],
                     options: {

                         icon: new google.maps.MarkerImage("http://maps.gstatic.com/mapfiles/icon_greenA.png")
                     },
                     tag: 'HOLA'
                 },
                 directionsrenderer: {

                     /*container: $(document.createElement("div")).addClass("googlemap").insertAfter($("#test")),*/
                     options: {
                         draggable: true,
                         preserveViewport: false,
                         markerOptions: {
                             visible: false
                         }
                     }
                 }
             });

         }

         function updateDirections(origen, destino) {


             $('#test').gmap3({ clear: "marker" });

             $("#test").gmap3({
                 getroute: {
                     options: {
                         origin: { latLng: [origen.split('|')[0], origen.split('|')[1]] },
                         destination: { latLng: [destino.split('|')[0], destino.split('|')[1]] },
                         travelMode: google.maps.DirectionsTravelMode.DRIVING
                     },
                     callback: function (results) {
                         if (!results) return;

                         $("#test").gmap3({ get: "directionrenderer" }).setDirections(results);
                     }
                 }
             });
         }
    </script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="bootstrap/js/AdminLTE/dashboard.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>



</head>
<body class="skin-blue">
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
                   <span class="fa fa-road"></span> Proveedores <small>Rutas Proveedores</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Proveedores</a></li>
                    <li class="active">Rutas proveedor</li>
                </ol>
            </section>
            <section class="content">
                <div class="row">
                    <div class="col-md-6">
                        <div class="box box-warning">
                            <div class="box-header">
                                <h3 class="box-title">
                                   Mapa de rutas entre proveedores</h3>
                            </div>
                            <!-- /.box-header -->
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
                                    Parámetros de ruta</h3>
                            </div>
                            <div class="box-body">
                            <!-- /.box-header -->
                            <!-- form start -->
                          <div class="form-group">
                            <label for="desde">Desde</label>
                              <select id="Proveedor1" name="standard-dropdown" style="width: 100%; color: Black;
                                height: 30px;">
                                <option value="">Seleccione un Proveedor</option>
                            </select>
                          </div>
                          <div class="form-group">
                            <label for="hasta">Hasta</label>
                            <select id="Proveedor2" name="standard-dropdown" style="width: 100%; color: Black;
                                height: 30px;">
                                <option value="">Seleccione un Proveedor</option>
                            </select>
                          </div>
                          </div>

                            <div class="box-footer">
                              <button id="Generar" type="button" class="btn btn-primary">
                                    Generar ruta</button>
                            </div>

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
