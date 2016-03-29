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
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/none.js"></script>
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
            <section class="content" id="_contenido" runat="server">
                <!-- Small boxes (Stat box) -->
                <div class="row">
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <a href="compras.aspx">
                            <div class="small-box bg-aqua-gradient">
                                <div class="inner">
                                    <h3>
                                        <asp:Label ID="lblCompras" runat="server" Text="Label"></asp:Label>
                                    </h3>
                                    <p>
                                        Compras<sup style="font-size: 5px"></sup>
                                    </p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-bag"></i>
                                </div>
                            </div>
                        </a>
                    </div>
                    <!-- ./col -->
                    <a href="transferencias.aspx">
                        <div class="col-lg-3 col-xs-6">
                            <!-- small box -->
                            <div class="small-box bg-green-gradient">
                                <div class="inner">
                                    <h3>
                                        <asp:Label ID="lblTransferencias" runat="server" Text="Label"></asp:Label>
                                    </h3>
                                    <p>
                                        Transferencias Externas<sup style="font-size: 10px"></sup>
                                    </p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-android-arrow-up-right"></i>
                                </div>
                            </div>
                        </div>
                    </a>
                    
                     <a href="transferenciasInternas.aspx">
                        <div class="col-lg-3 col-xs-6">
                            <!-- small box -->
                            <div class="small-box bg-teal-gradient">
                                <div class="inner">
                                    <h3>
                                        <asp:Label ID="lblTransferenciasInternas" runat="server" Text="Label"></asp:Label>
                                    </h3>
                                    <p>
                                        Transferencias Internas<sup style="font-size: 10px"></sup>
                                    </p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-android-arrow-down-left"></i>
                                </div>
                            </div>
                        </div>
                    </a>
                    
                    <a href="asignaciones.aspx">
                        <!-- ./col -->
                        <div class="col-lg-3 col-xs-6">
                            <!-- small box -->
                            <div class="small-box bg-yellow-gradient">
                                <div class="inner">
                                    <h3>
                                        <asp:Label ID="lblAsignaciones" runat="server" Text="Label"></asp:Label>
                                    </h3>
                                    <p>
                                        Asignaciones
                                    </p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-person-add"></i>
                                </div>
                            </div>
                        </div>
                    </a>
                    <!-- ./col -->
                    <a href="Depreciaciones.aspx">
                        <div class="col-lg-3 col-xs-6">
                            <!-- small box -->
                            <div class="small-box bg-red-gradient">
                                <div class="inner">
                                    <h3>
                                       
                                        <asp:Label ID="lblUltimaDepreciacion" runat="server" Text="Sin datos"></asp:Label>
                                    </h3>
                                    <p>
                                        Depreciaciones 
                                    </p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-flash"></i>
                                </div>
                            </div>
                        </div>
                    </a>
                    <!-- ./col -->


                    <a href="Bajas.aspx">
                        <!-- ./col -->
                        <div class="col-lg-3 col-xs-6">
                            <!-- small box -->
                            <div class="small-box bg-black-gradient">
                                <div class="inner">
                                    <h3>
                                        <asp:Label ID="lblBajas" runat="server" Text="Label"></asp:Label>
                                    </h3>
                                    <p>
                                        Bajas
                                    </p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-trash-a"></i>
                                </div>
                            </div>
                        </div>
                    </a>

                     <a href="RevaluoTecnico.aspx">
                        <!-- ./col -->
                        <div class="col-lg-3 col-xs-6">
                            <!-- small box -->
                            <div class="small-box bg-maroon-gradient">
                                <div class="inner">
                                    <h3>
                                        <asp:Label ID="lblRevaluo" runat="server" Text="Label"></asp:Label>
                                    </h3>
                                    <p>
                                        Revalúo Tecnico
                                    </p>
                                </div>
                                <div class="icon">
                                    <i class="ion ion-calculator"></i>
                                </div>
                            </div>
                        </div>
                    </a>

                </div>
                <div id="chartdiv">
                </div>
                <div class="container-fluid">
                    <div class="row text-center" style="overflow: hidden;">
                        <div class="col-sm-3" style="float: none !important; display: inline-block;">
                            <label class="text-left">
                                Angle:</label>
                            <input class="chart-input" data-property="angle" type="range" min="0" max="89" value="30"
                                step="1" />
                        </div>
                        <div class="col-sm-3" style="float: none !important; display: inline-block;">
                            <label class="text-left">
                                Depth:</label>
                            <input class="chart-input" data-property="depth3D" type="range" min="1" max="120"
                                value="20" step="1" />
                        </div>
                    </div>
                </div>
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
    <%--     <script src="js/plugins/morris/morris.min.js" type="text/javascript"></script>--%>
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
    <%--    <script src="bootstrap/js/AdminLTE/dashboard.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        $(function () {


            AmCharts.loadJSON = function (url) {
                var dataEstadistica = [];
                var colors = ['#FF0F00', '#FF6600', '#FF9E01', '#FCD202', '#F8FF01', '#B0DE09', '#04D215', '#0D8ECF', '#0D52D1', '#2A0CD0', '#8A0CCF', '#CD0D74', '#754DEB', '#DDDDDD', '#999999', '#333333', '#000000'];
                $.ajax({
                    type: "POST",
                    url: "../Controllers/ControllerAdministracion.asmx/DatosCountActivosPorGrupo",
                    data: {},
                    contentType: "application/json; chartset:utf-8",
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        var obj = JSON.stringify(result.d);


                        for (var i = 0; i < (result.d.length); i++) {
                            dataEstadistica.push({
                                grupo_contable: result.d[i].grupo_contable,
                                count: result.d[i].count,
                                color: colors[i]
                            });
                        }
                    }
                });
                return eval(JSON.stringify(dataEstadistica));
            }
            var chart = AmCharts.makeChart("chartdiv", {
                "theme": "none",
                "type": "serial",
                "startDuration": 2,
                "dataProvider": new AmCharts.loadJSON(0),
                "graphs": [{
                    "balloonText": "[[category]]: <b>[[value]]</b>",
                    "colorField": "color",
                    "fillAlphas": 1,
                    "lineAlpha": 0.1,
                    "type": "column",
                    "valueField": "count"
                }],
                "depth3D": 20,
                "angle": 30,
                "chartCursor": {
                    "categoryBalloonEnabled": false,
                    "cursorAlpha": 0,
                    "zoomable": false
                },
                "categoryField": "grupo_contable",
                "categoryAxis": {
                    "gridPosition": "start",
                    "labelRotation": 90
                },
                "exportConfig": {
                    "menuTop": "20px",
                    "menuRight": "20px",
                    "menuItems": [{
                        "icon": '/lib/3/images/export.png',
                        "format": 'png'
                    }]
                }
            });
            // alert(dataEstadistica);

            jQuery('.chart-input').off().on('input change', function () {
                var property = jQuery(this).data('property');
                var target = chart;
                chart.startDuration = 0;

                if (property == 'topRadius') {
                    target = chart.graphs[0];
                    if (this.value == 0) {
                        this.value = undefined;
                    }
                }

                target[property] = this.value;
                chart.validateNow();
            }); /*
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                },
                async: true
            });*/
        });

       
    </script>
    <style type="text/css">
        #chartdiv
        {
            width: 100%;
            height: 435px;
            font-size: 11px;
        }
    </style>
</body>
</html>
