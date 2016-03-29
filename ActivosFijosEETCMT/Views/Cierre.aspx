<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cierre.aspx.cs" Inherits="ActivosFijosEETC.Views.Cierre" %>

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
                    Cierre de Gestión 
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                   
                    <li class="active">Cierre</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Cierre</h3>
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

                        <div class="box-body">

                           
                                <asp:Button ID="btnCerrar" runat="server" 
                                    Text="Cerrar Gestión" CssClass="btn btn-danger" 
                                     OnClientClick="return ConfirmaCierre();" />
                             
                               <asp:Button ID="btnVerCierrePdf" runat="server" 
                                    Text="Historico Resumen Cierre Pfd" CssClass="btn btn-default" OnClick="btnVerCierrePdf_Click" 
                                     />
                                <asp:Button ID="btnVerCierre" runat="server" 
                                    Text="Historico Resumen Cierre Excel" CssClass="btn btn-success" onclick="btnVerCierre_Click" 
                                     />
                                     <asp:Button ID="btnVerDetalleCierre" runat="server" 
                                    Text="Historico Detalle Cierre" CssClass="btn btn-default" onclick="btnVerDetalleCierre_Click"
                                     />
                                    </div>
                            </div>
                            
                            <!-- /.box-body -->
                            <div class="box-body">

                            
                            <div class="row">
                             <div class="col-xs-12">
                             <label for="nombre">
                                                                    Periodos Cerrados</label>
                                <asp:DropDownList ID="ddlPeriodosCerrados" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                </div>
                                </div>
                              
                            </div>
                        </div>
                    </div>
                </div>
             
             <div id="CierreConfirmModal" class="modal fade">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4 class="modal-title">
                                    Confirmación</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Está seguro que desea Cerrar la gestión?</p>
                                <p class="text-warning">
                                    <small>Una vez cerrada la gestion no podrá realizar cambios en la gestión</small></p>
                                    <div class="box-body">
                                    <div class="row">
                                            <div class="col-xs-12">
                                                <label for="nombre">
                                                    Fecha de cierre <font color="red">*</font></label>
                                                <input id="dateFechaCierre" type="text" name="dateFechaCierre" readonly=readonly value="" class="form-control"
                                                    placeholder="ejemplo: 31/12/2014" />
                                       
                                            </div>
                                    </div>
                                    </div>
                            
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                                   <asp:Button ID="btnCerrarGestion" runat="server" Text=" Cerrar Gestión" 
                                    CssClass="btn btn-danger" onclick="btnCerrarGestion_Click" OnClientClick="return validar();"
                                     />
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
       function ConfirmaCierre() {
           $('#CierreConfirmModal').modal('show');
           return false;
       }

       
    </script>
    <script type = "text/javascript">
        window.onload = function () {
            document.onkeydown = function (e) {
                return (e.which || e.keyCode) != 116;
            };
        }
</script>

 <script type="text/javascript">

     $(document).ready(function () {

         $(document).bind("contextmenu", function (e) {
             return false;
         });

         $('#dateFechaCierre').datepicker({
             format: 'dd-mm-yyyy',
             clearBtn: true,
             language: "es",
             calendarWeeks: true,
             autoclose: true,
             todayHighlight: true
         });

     });

     function validar() {
         var error = 0;

         if (document.getElementById('dateFechaCierre').value == '') {
             error = 1;
         }

         if (error == 0) {
             return true;
         }
         else {
             alert('La fecha de cierre es campo obligatorio');
             return false;
         }
     } 
    </script>
     
    
</body>
</html>

