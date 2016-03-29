<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TasasCambio.aspx.cs" Inherits="ActivosFijosEETC.Views.TasasCambio" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="bootstrap/datepicker/css/datepicker.css" rel="stylesheet" type="text/css" />
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
    
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/light.js"></script>
    
    <!-- jQuery 2.0.2 -->
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="js/jquery.plugins.js" type="text/javascript"></script>
    <script type="text/javascript">
        document.write('<script src="js/TasaCambio.js" type="text/javascript"><\/script>');   
    </script>
    <!-- jQuery UI 1.10.3 -->
    <script src="bootstrap/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <!-- Sparkline -->
    <script src="bootstrap/js/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- daterangepicker -->
    <script src="bootstrap/js/plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <!-- datepicker -->
    <script src="bootstrap/js/plugins/datepicker/bootstrap-datepicker.js" type="text/javascript"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="bootstrap/js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"
        type="text/javascript"></script>
    <!-- AdminLTE App -->
    <script src="bootstrap/js/AdminLTE/app.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/datatables/jquery.dataTables.js" type="text/javascript"></script>
    <script src="bootstrap/js/plugins/datatables/dataTables.bootstrap.js" type="text/javascript"></script>


    

    <style type="text/css">
    #chartdiv {
	width	: 100%;
	height	: 300px;
}		
    </style>
    <script type="text/javascript">
        function cargarGrafico() {
            AmCharts.loadJSON = function (url) {
                var dataEstadistica = [];
                $.ajax({
                    type: "POST",
                    url: "../Controllers/ControllerTasasCambio.asmx/DatosTasaUfvPorFechas",
                    data: {},
                    contentType: "application/json; chartset:utf-8",
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        var obj = JSON.stringify(result.d);

                        for (var i = 0; i < (result.d.length); i++) {
                            dataEstadistica.push({
                                date: result.d[i].f_tasa,
                                value: result.d[i].tasa_ufv

                            });
                        }
                    }
                });
                return eval(JSON.stringify(dataEstadistica));
            }


            var chart = AmCharts.makeChart("chartdiv", {
                "type": "serial",
                "theme": "light",
                "marginRight": 80,
                "autoMarginOffset": 20,
                "pathToImages": "http://www.amcharts.com/lib/3/images/",
                "dataDateFormat": "YYYY-MM-DD",
                "valueAxes": [{
                    "id": "v1",
                    "axisAlpha": 0,
                    "position": "left"
                }],
                "balloon": {
                    "borderThickness": 1,
                    "shadowAlpha": 0
                },
                "graphs": [{
                    "id": "g1",
                    "bullet": "round",
                    "bulletBorderAlpha": 1,
                    "bulletColor": "#FFFFFF",
                    "bulletSize": 5,
                    "hideBulletsCount": 50,
                    "lineThickness": 2,
                    "title": "red line",
                    "useLineColorForBulletBorder": true,
                    "valueField": "value",
                    "balloonText": "<div style='margin:5px; font-size:19px;'><span style='font-size:13px;'>[[category]]</span><br>[[value]]</div>"
                }],
                "chartScrollbar": {
                    "graph": "g1",
                    "scrollbarHeight": 80,
                    "backgroundAlpha": 0,
                    "selectedBackgroundAlpha": 0.1,
                    "selectedBackgroundColor": "#888888",
                    "graphFillAlpha": 0,
                    "graphLineAlpha": 0.5,
                    "selectedGraphFillAlpha": 0,
                    "selectedGraphLineAlpha": 1,
                    "autoGridCount": true,
                    "color": "#AAAAAA"
                },
                "chartCursor": {
                    "pan": true,
                    "valueLineEnabled": true,
                    "valueLineBalloonEnabled": true,
                    "cursorAlpha": 0,
                    "valueLineAlpha": 0.2
                },
                "categoryField": "date",
                "categoryAxis": {
                    "parseDates": true,
                    "dashLength": 1,
                    "minorGridEnabled": true,
                    "position": "top"
                },
                "export": {
                    "enabled": true,
                    "libs": {
                        "path": "http://www.amcharts.com/lib/3/plugins/export/libs/"
                    }
                },
                "dataProvider": new AmCharts.loadJSON(0)
            });

            chart.addListener("rendered", zoomChart);

            zoomChart();

            function zoomChart() {
                chart.zoomToIndexes(chart.dataProvider.length - 40, chart.dataProvider.length - 1);
            }
        }

        $(function () {
            cargarGrafico();
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
                     <span class='fa fa-money'></span> Tipos de Cambio <small>Parametrizacion cambio</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Parametricas</a></li>
                    <li class="active">Tipos de cambio</li>
                </ol>
            </section>
            <form id="form1" runat="server">
              <asp:ScriptManager ID="smgr" runat="server" EnablePartialRendering="true" />

            <section class="content">

            <div class="row">
                <div class="col-md-12">
                <div class="box-primary">
                    
                </div>   
                </div>
            </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Tipos de cambio
                                </h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-header">
                            <asp:updatepanel runat="server">
    <contenttemplate>
                                <div id="danger" class="alert alert-danger" role="alert" style="display: none">
                                    <strong>Error!</strong>
                                </div>
                                <div id="warning" class="alert alert-warning" role="alert" style="display: none">
                                    <strong>Atencion!</strong>
                                </div>
                                <div id="success" class="alert alert-success" role="alert" style="display: none">
                                    <strong>Correcto!</strong>
                                </div>
                                </contenttemplate>
</asp:updatepanel>
                                <div class="box-body">
                                    <button id="btnNuevo" type="button" class="btn btn-warning">
                                        <span class='fa fa-money'></span>
                                    Nuevo tipo de cambio</input>
                                </div>
                            </div>
                            <!-- /.box-body -->

                            <div id="chartdiv"></div>
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <div>
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                        <dx:ASPxGridView ID="gridTasasCambio" runat="server" AutoGenerateColumns="False"
                                            Caption="Tasas de Cambio" Width="100%" EnableTheming="True" Theme="Aqua" 
                                            onhtmlrowprepared="gridTasasCambio_HtmlRowPrepared">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="id" VisibleIndex="0" FieldName="id" 
                                                    Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha Tasa Cambio" FieldName="f_tasa" 
                                                    VisibleIndex="1">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Tasa UFV" FieldName="tasa_ufv" 
                                                    VisibleIndex="2">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Tasa SUS" FieldName="tasa_sus" 
                                                    VisibleIndex="3">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                            <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                            </RegularExpression>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Estado" FieldName="estado" VisibleIndex="5">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn VisibleIndex="5" Caption=" " FieldName="editar">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Valor inv&#225;lido">
<RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                                                <DataItemTemplate>
                                                     <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-primary"
                                                    CommandArgument="<%# Container.VisibleIndex %>"
                                                      Text="Editar" onclick="btnEditar_Click" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>

                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <Settings ShowFilterRow="True" />
                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                        </dx:ASPxGridView>
                                       </ContentTemplate>
                                       </asp:UpdatePanel>
                                    </div>
                                    <div id="modalDatosTasaCambio" class="modal fade">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                        &times;</button>
                                                    <h4 class="modal-title">
                                                        <asp:Label ID="lblTitleModal" Text="text" runat="server" />
                                                    </h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- form start -->
                                                    <div class="box-body">
                                                     
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <label for="nombre">
                                                                    Fecha Tasa de Cambio</label>
                                                                <input id="dateFechaTasaCambio" type="text" name="dateFechaTasaCambio" value="" class="form-control"
                                                                    readonly="readonly" placeholder="ejemplo: 01/01/2014" />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <label for="nombre">
                                                                    Tasa UFV</label>
                                                                <asp:TextBox ID="txtTasaUfv" CssClass="form-control" placeholder="ejemplo: 1,99584 UFV"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <label for="nombre">
                                                                    Tasa SUS</label>
                                                                <asp:TextBox ID="txtTasaSus" CssClass="form-control" placeholder="6.96 Sus" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                                        Cerrar</button>
                                                    <asp:Button CssClass="btn btn-primary" ID="btnGuardarGrupoContable" runat="server"
                                                        Text="Guardar Cambios" OnClientClick="return Validar();" OnClick="btnGuardarTasaCambio_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                      <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                    <ContentTemplate>
                                      <div id="modalEditaDatosTasaCambio" class="modal fade">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                        &times;</button>
                                                    <h4 class="modal-title">
                                                        <span class="fa fa-pencil"></span> <asp:Label ID="Label1" Text="Edita tasas de cambio" runat="server" />
                                                    </h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- form start -->
                                                    <div class="box-body">
                                                        <asp:TextBox ID="txtEditaId" runat="server" Enabled=false Visible=false></asp:TextBox>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <label for="nombre">
                                                                    Fecha Tasa de Cambio</label>
                                                               <asp:TextBox ID="txtEditaFecha" CssClass="form-control" Enabled=false
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <label for="nombre">
                                                                    Tasa UFV</label>
                                                                <asp:TextBox ID="txtEditaTasaUfv" CssClass="form-control" placeholder="ejemplo: 1,99584 UFV"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <label for="nombre">
                                                                    Tasa SUS</label>
                                                                <asp:TextBox ID="txtEditaTasaSus" CssClass="form-control" placeholder="6.96 Sus" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                                        Cerrar</button>
                                                    <asp:Button CssClass="btn btn-primary" ID="btnGuardarEditar" runat="server"
                                                        Text="Guardar Cambios" 
                                        onclick="btnGuardarEditar_Click"   />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                     </ContentTemplate>
                        </asp:UpdatePanel>
                        
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal HTML -->
                <div id="myModal" class="modal fade">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4 class="modal-title">
                                    Información</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Por favor revise los datos faltantes</p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">
                                    Cerrar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal HTML -->
                <div class="modal fade" id="deleteConfirmModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="deleteLabel">
                                    Notificacion de eliminacion</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <strong>Esta seguro que desea eliminar el tipo de cambio?</strong></p>
                                <p>
                                    <small>Los tipos de cambio deben estar parametrizados para obtener las tasas en registros
                                        del sistema</small>
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cancelar</button>
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"
                                    OnClick="btnEliminar_Click" />
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

            if (document.getElementById('dateFechaTasaCambio').value == '' || document.getElementById('<%=txtTasaUfv.ClientID %>').value == '' || document.getElementById('<%=txtTasaSus.ClientID %>').value == '') {
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
        function ConfirmaElimina() {
            $('#deleteConfirmModal').modal('show');
            return false;
        }

        $('#dateFechaTasaCambio').datepicker({
            format: 'dd-mm-yyyy',
            clearBtn: true,
            language: "es",
            calendarWeeks: true,
            autoclose: true,
            todayHighlight: true
        });

    </script>
</body>
</html>
