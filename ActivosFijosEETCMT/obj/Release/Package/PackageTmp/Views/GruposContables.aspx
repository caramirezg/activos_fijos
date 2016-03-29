<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GruposContables.aspx.cs"
    Inherits="ActivosFijosEETC.Views.GruposContables" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
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
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        document.write('<script src="js/GruposContables.js" type="text/javascript"><\/script>');   
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
    <script src="js/jquery.plugins.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/dark.js"></script>
    <style type="text/css">
        #chartdiv
        {
            width: auto;
            height: 300px;
            font-size: 11px;
        }
    </style>
    <script type="text/javascript">
       $(function () {

           AmCharts.loadJSON = function (url) {
               var dataEstadistica = [];
               $.ajax({
                   type: "POST",
                   url: "../Controllers/ControllerGruposContables.asmx/DatosGruposContables",
                   data: {},
                   contentType: "application/json; chartset:utf-8",
                   dataType: "json",
                   async: false,
                   success: function (result) {
                       var obj = JSON.stringify(result.d);

                       for (var i = 0; i < (result.d.length); i++) {
                           dataEstadistica.push({
                               grupo_contable: result.d[i].codigo,
                               vida_util: result.d[i].vida_util
                              
                           });
                       }
                   }
               });
               return eval(JSON.stringify(dataEstadistica));
           }

        var chart = AmCharts.makeChart("chartdiv", {
            "type": "serial",
            "theme": "light",
            "dataProvider": new AmCharts.loadJSON(0),
            "gridAboveGraphs": true,
            "startDuration": 1,
            "graphs": [{
                "balloonText": "[[category]]: <b>[[value]]</b>",
                "fillAlphas": 0.8,
                "lineAlpha": 0.2,
                "type": "column",
                "valueField": "vida_util"
            }],
            "chartCursor": {
                "categoryBalloonEnabled": false,
                "cursorAlpha": 0,
                "zoomable": false
            },
            "categoryField": "grupo_contable",
            "categoryAxis": {
                "gridPosition": "start",
                "gridAlpha": 0,
                "tickPosition": "start",
                "tickLength": 20,
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
                    <span class='fa fa-gears'></span>Grupos Contables <small>Gestión de grupos</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Parametricas</a></li>
                    <li class="active">Grupos Contables</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Grupos Contables</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <button id="btnNuevo" type="button" class="btn btn-primary">
                                    <span class='fa fa-gears'></span>Nuevo Grupo contable</button>
                            </div>
                            <div id="chartdiv">
                            </div>
                            <asp:ScriptManager ID="smgr" runat="server" EnablePartialRendering="true" />
                          
                                    <div class="box-header">
                                        <div id="danger" class="alert alert-danger" role="alert" style="display: none">
                                            <strong>Error!</strong>
                                        </div>
                                        <div id="success" class="alert alert-success" role="alert" style="display: none">
                                            <strong>Correcto!</strong>
                                        </div>
                                    </div>
                               
                            <div class="box-body">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnEditar" runat="server" Text="<span class='fa fa-pencil'></span> Editar"
                                            CssClass="btn btn-warning" OnClick="btnEditar_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="btnEliminarCompra" runat="server" Text="<span class='fa fa-trash-o'></span> Eliminar Grupo"
                                            CssClass="btn btn-danger" OnClientClick="return ConfirmaElimina();"></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <dx:ASPxGridView ID="gridGruposContables" runat="server" AutoGenerateColumns="False"
                                                    EnableTheming="True" Theme="Aqua" Width="100%" Caption="Grupos Contables" OnCustomColumnDisplayText="gridGruposContables_CustomColumnDisplayText"
                                                    OnHtmlDataCellPrepared="gridGruposContables_HtmlDataCellPrepared">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Id" FieldName="ID" VisibleIndex="0" Visible="False">
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
                                                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="3">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sigla" FieldName="sigla" VisibleIndex="4">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Vida Útil" FieldName="vida_util" VisibleIndex="5">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Porcentaje Depreciación" FieldName="porcentaje_depreciacion"
                                                            VisibleIndex="6">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="1">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Depreciable" FieldName="depreciable" VisibleIndex="7">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Actualizable" FieldName="actualizable" VisibleIndex="9">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div id="modalDatosGrupoContable" class="modal fade">
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
                                                                    <div class="col-xs-12">
                                                                        <label for="nombre">
                                                                            Código</label>
                                                                        <asp:TextBox ID="txtCodigoGrupo" CssClass="form-control" placeholder="ejemplo: 01"
                                                                            runat="server" MaxLength="2"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <asp:TextBox ID="id" runat="server" Visible="false" Enabled="false"></asp:TextBox>
                                                                    <div class="col-xs-12">
                                                                        <label for="nombre">
                                                                            Nombre</label>
                                                                        <asp:TextBox ID="nombre" CssClass="form-control" placeholder="ejemplo: Muebles y Enseres"
                                                                            runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-xs-12">
                                                                        <label for="nombre">
                                                                            Descripcion</label>
                                                                        <asp:TextBox ID="descripcion" CssClass="form-control" placeholder="ejemplo: Grupo de muebles y enseres"
                                                                            runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-xs-4">
                                                                        <label for="nombre">
                                                                            Vida Util (años)</label>
                                                                        <asp:TextBox ID="vida_util" CssClass="form-control" placeholder="ejemplo: 4 años"
                                                                            onkeyup="getPorcentaje();" runat="server" MaxLength="5"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-xs-4">
                                                                        <label for="nombre">
                                                                            Porcentaje</label>
                                                                        <asp:TextBox ID="porcentaje" CssClass="form-control" placeholder="ejemplo: 25%" runat="server"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-xs-4">
                                                                        <label for="nombre">
                                                                            Sigla</label>
                                                                        <asp:TextBox ID="sigla" CssClass="form-control" placeholder="ejemplo: PZ" runat="server"
                                                                            MaxLength="4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-xs-4">
                                                                        <label for="nombre">
                                                                            Depreciable</label>
                                                                        <asp:DropDownList ID="ddlDepreciable" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                                            <asp:ListItem Text="SI" Value="1" Selected="True" />
                                                                            <asp:ListItem Text="NO" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-xs-4">
                                                                        <label for="nombre">
                                                                            Actualizable</label>
                                                                        <asp:DropDownList ID="ddlActualizable" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                                            <asp:ListItem Text="SI" Value="1" Selected="True" />
                                                                            <asp:ListItem Text="NO" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                                                Cerrar</button>
                                                            <asp:Button CssClass="btn btn-primary" ID="btnGuardarGrupoContable" runat="server"
                                                                Text="Guardar Cambios" OnClick="btnGuardarGrupoContable_Click" OnClientClick="return Validar();" />
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
                <div id="myModal2" class="modal fade">
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
                                    Está seguro que desea guardar los datos de la compra de activos?</p>
                                <p class="text-warning">
                                    <small>Si no guarda, los cambios se perderán.</small></p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Cerrar</button>
                                <button type="button" class="btn btn-primary">
                                    Guardar</button>
                            </div>
                        </div>
                    </div>
                </div>
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
                                    <strong>Esta seguro que desea eliminar el grupo contable?</strong></p>
                                <p>
                                    <small>No se podran eliminar los grupos contables que ya tengan asignado un activo</small>
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

            if (document.getElementById('<%=txtCodigoGrupo.ClientID %>').value == '' || document.getElementById('<%=nombre.ClientID %>').value == '' || document.getElementById('<%=descripcion.ClientID %>').value == '' ||
                document.getElementById('<%=sigla.ClientID %>').value == '' || document.getElementById('<%=ddlDepreciable.ClientID %>').value == '' || document.getElementById('<%=ddlActualizable.ClientID %>').value == '') {
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

        function getPorcentaje() {

            if ($("#vida_util").val() != "") {

                parseFloat("123.456").toFixed(2);
                var vida_util = $("#vida_util").val();
                var porcentaje = 100;
                var result = parseFloat(porcentaje / vida_util).toFixed(2);
                document.getElementById('<%=porcentaje.ClientID%>').value = result;
            } else {
                document.getElementById('<%=porcentaje.ClientID%>').value = 0;
            }

        }
    </script>
    <script type="text/javascript">
        window.onload = function () {
            document.onkeydown = function (e) {
                return (e.which || e.keyCode) != 116;
            };
        }
    </script>
</body>
</html>
