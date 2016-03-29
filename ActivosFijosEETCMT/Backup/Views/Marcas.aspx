<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="ActivosFijosEETC.Views.Marcas" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
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
    <!-- DATA TABLES -->
    <link href="bootstrap/css/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- jQuery 2.0.2 -->
    <%--   <script src="js/jquery.min.js"           type="text/javascript"></script>--%>
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        document.write('<script src="js/MarcasModelos.js" type="text/javascript"><\/script>');   
    </script>
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

    <script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
<script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
<script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/patterns.js"></script>


    <style type="text/css">
    
    #chartdiv {
	width		: 100%;
	height		: 300px;
	font-size	: 11px;
}			
    </style>

    <script type="text/javascript">

        $(function () {

            AmCharts.loadJSON = function (url) {
                var dataEstadistica = [];
                $.ajax({
                    type: "POST",
                    url: "../Controllers/ControllerActivos.asmx/dataTableActivosPorMarca",
                    data: {},
                    contentType: "application/json; chartset:utf-8",
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        var objdata = $.parseJSON(result.d);
                    
                        //alert($(objdata).length);
                        var cant = 0;
                        $.each(objdata, function (key, val) {
                            $.each(val, function (k, v) {
                                dataEstadistica.push({
                                    nombre: v[0],
                                    cant: v[1]
                                });

                                cant++;
                            });

                        });



                        //                       var obj = JSON.stringify(result.d);

                        /*$(objdata).each(function (i, val) {
                        var cant = $(val).length;
                        $.each(cant, function (k, v) {
                        for (j = 0; i < v.length; i++)
                        {
                        dataEstadistica.push({
                        nombre: v[j][0],
                        cant: v[j][1]
                        }
                        });

                        });
                        });*/

                    }
                });
                return eval(JSON.stringify(dataEstadistica));
            }

            
            var chart = AmCharts.makeChart("chartdiv", {
                "type": "serial",
                "theme": "none",
                "dataProvider": new AmCharts.loadJSON(0),
                "valueAxes": [{
                    "gridColor": "#FFFFFF",
                    "gridAlpha": 0.2,
                    "dashLength": 0
                }],
                "gridAboveGraphs": true,
                "startDuration": 1,
                "graphs": [{
                    "balloonText": "[[category]]: <b>[[value]]</b>",
                    "fillAlphas": 0.8,
                    "lineAlpha": 0.2,
                    "type": "column",
                    "valueField": "cant"
                }],
                "chartCursor": {
                    "categoryBalloonEnabled": false,
                    "cursorAlpha": 0,
                    "zoomable": false
                },
                "categoryField": "nombre",
                "categoryAxis": {
                    "gridPosition": "start",
                    "gridAlpha": 0,
                    "tickPosition": "start",
                    "tickLength": 20,
                    "labelRotation": 90
                },
                "export": {
                    "enabled": true,
                    "libs": {
                        "path": "http://www.amcharts.com/lib/3/plugins/export/libs/"
                    }
                }

            });
        });
    </script>
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
                   <span class='fa fa-mobile-phone'></span> Marcas y Modelos <small>Parametrización marcas y modelos</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Parametricas</a></li>
                    <li class="active">Marcas</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div id="div_marcas" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Marcas</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                            <div id="chartdiv"></div>			
                            </div>

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
                                  </div>
                                <div class="box-body">
                                <button id="btnNuevaMarca" type="button" class="btn btn-primary">
                                 <span class='fa fa-apple'></span> Nueva Marca</button>
                                <asp:LinkButton ID="btnEditaMarca" runat="server" Text="<span class='fa fa-pencil'></span> Editar" CssClass="btn btn-warning"
                                    OnClick="btnEditaMarca_Click"></asp:LinkButton>
                           
                                    <asp:LinkButton ID="btnEliminarMarca" runat="server" 
                                    Text="Eliminar Marca" CssClass="btn btn-danger" 
                                     OnClientClick="return ConfirmaEliminaMarca();"></asp:LinkButton>

                                    <asp:LinkButton ID="btnVerModelos" runat="server" Text="<span class='fa fa-search'></span> Ver Modelos" CssClass="btn btn-default"
                                    OnClick="btnVerModelos_Click"></asp:LinkButton>
                            
                                    </div>
                          
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <div>
                                        <dx:ASPxGridView ID="gridMarcas" runat="server" AutoGenerateColumns="False" EnableTheming="True"
                                            Theme="Aqua" Width="100%" Caption="Marcas">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="Id" FieldName="ID" VisibleIndex="1" Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Nombre" FieldName="nombre" VisibleIndex="2">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle VerticalAlign="Middle">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>
                                            <SettingsPager PageSize="20">
                                            </SettingsPager>
                                            <Settings ShowFilterRow="True" />
                                            <Settings ShowFilterRow="True"></Settings>
                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                        </dx:ASPxGridView>
                                    </div>
                                    <div id="modalDatosMarcas" class="modal fade">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                        &times;</button>
                                                    <h4 class="modal-title">
                                                        <%--<label id="lblTitleModalMarcas">
                                                        </label>--%>
                                                        <asp:label id="lblTitleModalMarcas" text="text" runat="server" />
                                                    </h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- form start -->
                                                    <div class="box-body">
                                                        <div class="row">
                                                            <asp:TextBox CssClass="hidden" ID="id" runat="server"></asp:TextBox>
                                                            <div class="col-xs-12">
                                                                <label for="nombre">
                                                                    Marca</label>
                                                                <asp:TextBox ID="nombreMarca" CssClass="form-control" placeholder="ejemplo: Mitsubishi"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                                        Cerrar</button>
                                                    <asp:Button CssClass="btn btn-primary" ID="btnGuardarMarca" runat="server" Text="Guardar Cambios"
                                                        OnClientClick="return Validar();" OnClick="btnGuardarMarca_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div id="div_modelos" class="box box-warning" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    <asp:Label ID="lblModelo" Text="text" runat="server" /></h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-header">
                                <div id="dangerModelos" class="alert alert-danger" role="alert" style="display: none">
                                    <strong>Error!</strong>
                                </div>
                                 <div id="warningModelos" class="alert alert-warning" role="alert" style="display: none">
                                    <strong>Error!</strong>
                                </div>
                                <div id="successModelos" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Correcto!</strong>
                                </div>

                                <div class="box-body">
                                <button id="btnNuevoModelo" type="button" class="btn btn-primary">
                                    <span class="fa fa-file-text-o"></span> Modelo</button>
                                    <asp:LinkButton ID="btnEditarModelo" runat="server" Text="<span class='fa fa-pencil'></span> Editar" CssClass="btn btn-warning"
                                    OnClick="btnEditarModelo_Click"></asp:LinkButton>
                              <%--  <asp:Button ID="btnEditarModelo" runat="server" Text="Editar" CssClass="btn btn-primary"
                                    OnClick="btnEditarModelo_Click" />--%>
                                    <asp:LinkButton ID="Button1" runat="server" 
                                    Text="<span class='fa fa-trash-o'></span> Eliminar Modelo" CssClass="btn btn-danger" 
                                     OnClientClick="return ConfirmaEliminaModelo();"></asp:LinkButton>
<%--                               <asp:Button ID="Button1" runat="server" 
                                    Text="Eliminar Modelo" CssClass="btn btn-primary" 
                                     OnClientClick="return ConfirmaEliminaModelo();"/>--%>
                                    <asp:LinkButton ID="btnVerMarcas" runat="server" Text="<span class='fa fa-apple'></span> Ver Marcas" 
                                    CssClass="btn btn-default" onclick="btnVerMarcas_Click"></asp:LinkButton>
                               <%-- <asp:Button ID="btnVerMarcas" runat="server" Text="Ver Marcas" 
                                    CssClass="btn btn-primary" onclick="btnVerMarcas_Click" />--%>
                                    </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <div>
                                        <dx:ASPxGridView ID="gridModelos" runat="server" AutoGenerateColumns="False" EnableTheming="True"
                                            Theme="Aqua" Width="100%" Caption="Modelos">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="Id" FieldName="ID" VisibleIndex="1" Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Nombre" FieldName="nombre" VisibleIndex="2">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle VerticalAlign="Middle">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>
                                            <SettingsPager PageSize="20">
                                            </SettingsPager>
                                            <Settings ShowFilterRow="True" />
                                            <Settings ShowFilterRow="True"></Settings>
                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                        </dx:ASPxGridView>
                                    </div>
                                    <div id="modalDatosModelos" class="modal fade">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                        &times;</button>
                                                    <h4 class="modal-title">
                                                    <asp:label ID="lblTitleModalModelos" text="text" runat="server" />
                                                        <%--<label id="lblTitleModalModelos">
                                                        </label>--%>
                                                    </h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- form start -->
                                                    
                                                    <div class="box-body">
                                                        <div class="row">
                                                      <div class="col-xs-12">
                                                       <label>Marca</label>
                                                          <asp:TextBox ID="txtMarcaPopUp" runat="server"  CssClass="form-control" ReadOnly=true></asp:TextBox>

                                                      </div>
                                                     
                                                      
                                                            <asp:TextBox CssClass="hidden" ID="txtIdModelo" runat="server"></asp:TextBox>
                                                            <div class="col-xs-12">
                                                                <label for="nombre">
                                                                    Modelo</label>
                                                                <asp:TextBox ID="txtNombreModelo" CssClass="form-control" placeholder="ejemplo: Montero Sport 2000"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                                        Cerrar</button>
                                                    <asp:Button CssClass="btn btn-primary" ID="btnGuardarModelo" runat="server" Text="Guardar Cambios"
                                                        OnClientClick="return ValidarModelos();" OnClick="btnGuardarModelo_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal HTML -->
                <div class="modal fade" id="deleteConfirmModalMarca" tabindex="-1" role="dialog"
                    aria-labelledby="deleteLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="deleteLabel">
                                    Notificacion de eliminacion</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <strong>Esta seguro que desea eliminar la marca?</strong></p>
                                <p>
                                    <small>No se podran eliminar las marcas que ya tengan asignado un activo</small>
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                               <asp:Button ID="btnEliminaMarca" runat="server" Text="Eliminar" CssClass="btn btn-danger"
                                   OnClick="btnEliminaMarca_Click" />
                            </div>
                        </div>
                    </div>
                </div>


                <div class="modal fade" id="deleteConfirmModalModelo" tabindex="-1" role="dialog"
                    aria-labelledby="deleteLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="H1">
                                    Notificacion de eliminacion</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <strong>Esta seguro que desea eliminar el modelo?</strong></p>
                                <p>
                                    <small>No se podran eliminar los modelos que ya tengan asignado un activo</small>
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                               <asp:Button ID="btnEliminarModelo" runat="server" Text="Eliminar" CssClass="btn btn-danger"
                                   
                                    onclick="btnEliminarModelo_Click" />


                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.box -->
            </section>
            </form>
        </aside>
    </div>
    <!-- ./wrapper -->
    <script type="text/javascript">

        function Validar() {
            var error = 0;

            if (document.getElementById('<%=nombreMarca.ClientID %>').value == '') {
                error = 1;
            }

            if (error == 0) {
                return true;
            }
            else {
                alert('Valide los datos antes de grabar');
                return false;
            }
        }

        function ValidarModelos() {
            var error = 0;

            if (document.getElementById('<%=txtNombreModelo.ClientID %>').value == '') {
                error = 1;
            }

            if (error == 0) {
                return true;
            }
            else {
                alert('Valide los datos antes de grabar');
                return false;
            }
        } 
    </script>
    <script type="text/javascript">
        function ConfirmaEliminaMarca() {
            $('#deleteConfirmModalMarca').modal('show');
            return false;
        }

        function ConfirmaEliminaModelo() {
            $('#deleteConfirmModalModelo').modal('show');
            return false;
        }
    </script>
</body>
</html>
