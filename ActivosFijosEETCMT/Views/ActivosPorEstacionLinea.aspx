<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivosPorEstacionLinea.aspx.cs" Inherits="ActivosFijosEETC.Views.ActivosPorEstacionLinea" %>

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
               <form id="form1" runat="server">
            <section class="content-header">
                <h1>
                    Activos Estaciones y Lineas
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Reportes</a></li>
                    <li class="active">Activos Por Estación - Línea</li>
                </ol>
            </section>
         
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div id="div_gruposcontables" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Estaciones - Lineas</h3>
                            </div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                              
                           <div class="box-header">
                                    <div id="danger" class="alert alert-danger" role="alert" style="display: none">
                                        <strong>Error!</strong>
                                    </div>
                                    <div id="success" class="alert alert-success" role="alert" style="display: none">
                                        <strong>Correcto!</strong>
                                    </div>
                                    <div id="warning" class="alert alert-warning" role="alert" style="display: none">
                                        <strong>Atencion!</strong>
                                    </div>
                                 
                                </div>
                                <asp:UpdatePanel runat="server" ID="updateButtons">
                                    <ContentTemplate>
                            <div class="box-body">
                                <asp:Button ID="btnImprimirReporte" runat="server" 
                                    CssClass="btn btn-primary" Text="Imprimir Reporte" onclick="btnImprimirReporte_Click"
                                    />
                                    
                            </div>
                            </ContentTemplate>
                            <Triggers>        
                                <asp:PostBackTrigger ControlID="btnImprimirReporte" />
                            </Triggers>
                            </asp:UpdatePanel>
                            <!-- /.box-body -->
                          
                                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                             <ContentTemplate>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Tipo de Reporte <font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlTipoReporte" runat="server" CssClass=form-control 
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddlTipoReporte_SelectedIndexChanged" >
                                             <asp:ListItem Text="Seleccione un item" Value="-1" />
                                            <asp:ListItem Text="POR LINEA" Value=1 />
                                            <asp:ListItem Text="POR ESTACION" Value=2  />
                                            <asp:ListItem Text="OFICINAS ADMINISTRATIVAS" Value=3  />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                              
                                           
                                                
                                                <div class=row>
                                                    <div class="col-xs-12" id="linea" runat="server">
                                                        <label for="nombre">
                                                            Línea <font color="red">*</font>
                                                        </label>
                                                        <asp:DropDownList ID="ddlLinea" CssClass="form-control" runat="server" AutoPostBack="True"
                                                            AppendDataBoundItems="true" 
                                                            onselectedindexchanged="ddlLinea_SelectedIndexChanged">
                                                            <asp:ListItem Text="Seleccione un item" Value="-1" />
                                                        </asp:DropDownList>
                                                    </div>
                                                    </div>
                                                    <div class=row>
                                                    <div class="col-xs-12" id="estacion" runat="server" >
                                                        <label for="nombre">
                                                            Estación <font color="red">*</font>
                                                        </label>
                                                        <asp:DropDownList ID="ddlEstacion" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    </div>
                                              
                            </div>
                              </ContentTemplate>
                                            </asp:UpdatePanel>
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

