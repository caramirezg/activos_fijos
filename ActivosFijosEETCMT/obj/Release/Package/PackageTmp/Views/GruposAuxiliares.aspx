<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GruposAuxiliares.aspx.cs"
    Inherits="ActivosFijosEETC.Views.GruposAuxiliares" %>

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
    <%--   <script src="js/jquery.min.js"           type="text/javascript"></script>--%>
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        document.write('<script src="js/AuxiliaresContables.js" type="text/javascript"><\/script>');   
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
                  <span class='fa fa-cog'></span> Auxiliares Contables <small></small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li><a href="#">Parametricas</a></li>
                    <li class="active">Grupos Auxiliares</li>
                </ol>
            </section>
            <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div id="div_gruposcontables" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Grupos Contables</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <asp:LinkButton ID="btnVerAuxiliares" runat="server" CssClass="btn btn-primary" Text="<span class='fa fa-search'></span> Ver Auxiliares"
                                    OnClick="btnVerAuxiliares_Click"></asp:LinkButton>
                                <%--<asp:Button ID="btnVerAuxiliares" runat="server" CssClass="btn btn-primary" Text="Ver Auxiliares"
                                    OnClick="btnVerAuxiliares_Click" />--%>
                            </div>
                            <!-- /.box-body -->
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <%--    <div id='jqxWidget'>
                                <div id="jqxgrid">
                                </div>
                            </div>--%>
                                    <div>
                                        <dx:ASPxGridView ID="gridGruposContables" runat="server" AutoGenerateColumns="False"
                                            EnableTheming="True" Theme="Aqua" Width="100%" Caption="Grupos Contables" 
                                            oncustomcolumndisplaytext="gridGruposContables_CustomColumnDisplayText">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="2">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Id" FieldName="ID" VisibleIndex="1" 
                                                    Visible="False">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Nombre" FieldName="nombre" VisibleIndex="3">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" 
                                                    VisibleIndex="4">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Sigla" FieldName="sigla" VisibleIndex="5">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Vida Útil" FieldName="vida_util" 
                                                    VisibleIndex="6">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Porcentaje Depreciación" FieldName="porcentaje_depreciacion"
                                                    VisibleIndex="7">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ErrorText="Valor inválido">
                                                            <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsPager PageSize="20">
                                            </SettingsPager>
                                            <Settings ShowFilterRow="True" />
                                            <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                        </dx:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div id="div_auxiliares" class="box box-warning" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    <asp:Label ID="lblAuxiliarContable" Text="text" runat="server" /></h3>
                            </div>

                            <div class="box-body">
                            <div id="danger" class="alert alert-danger" role="alert" style="display: none">
                                                <strong>Error!</strong>
                                                </div>
                                                <div id="success" class="alert alert-success" role="alert" style="display: none">
                            <strong>Correcto!</strong>
                        </div>
                                <button id="btnNuevoAuxiliar" type="button" class="btn btn-primary">
                                  <span class='fa fa-plus'></span> Nuevo Auxiliar</button>
                                <asp:LinkButton ID="btnEditarAuxiliar" runat="server" CssClass="btn btn-warning" Text="<span class='fa fa-pencil'></span> Editar"
                                    OnClick="btnEditarAuxiliar_Click"></asp:LinkButton>
                              <%--  <asp:Button ID="btnEditarAuxiliar" runat="server" CssClass="btn btn-primary" Text="Editar"
                                    OnClick="btnEditarAuxiliar_Click" />--%>
                                <asp:LinkButton ID="btnEliminarCompra" runat="server" 
                                    Text="<span class='fa fa-trash-o'></span> Eliminar Auxiliar" CssClass="btn btn-danger" 
                                     OnClientClick="return ConfirmaElimina();"></asp:LinkButton>
                                    <%-- <asp:Button ID="btnEliminarCompra" runat="server" 
                                    Text="Eliminar Auxiliar" CssClass="btn btn-primary" 
                                     OnClientClick="return ConfirmaElimina();"/>--%>
                                <asp:LinkButton ID="btnVerGruposContables" runat="server" CssClass="btn btn-default"
                                    Text="<span class='fa fa-gears'></span> Grupos Contables" OnClick="btnVerGruposContables_Click"></asp:LinkButton>
                                <%--<asp:Button ID="btnVerGruposContables" runat="server" CssClass="btn btn-primary"
                                    Text="Grupos Contables" OnClick="btnVerGruposContables_Click" />--%>
                            </div>
                            <div class="box">
                                <div class="box-body table-responsive">
                                    <dx:ASPxGridView ID="gridAuxiliaresContables" runat="server" AutoGenerateColumns="False"
                                        Caption="Auxiliares Contables" Theme="Aqua" Width="100%" 
                                        EnableTheming="True" KeyFieldName="ID">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="1">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="id" FieldName="ID" VisibleIndex="0" 
                                                Visible="False">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="nombre" VisibleIndex="2">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" 
                                                VisibleIndex="3">
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
                                            <dx:GridViewDataTextColumn Caption="Grupo Contable" FieldName="grupo_contable" 
                                                VisibleIndex="5">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ErrorText="Valor inválido">
                                                        <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsBehavior AllowFocusedRow="True" />
                                        <SettingsPager PageSize="20">
                                        </SettingsPager>
                                        <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                    </dx:ASPxGridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="modalDatosAuxiliarContable" class="modal fade">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title">
                                    <asp:label ID="lblTitleModal" text="text" runat="server" />
                                       <%-- <label id="lblTitleModal">
                                        </label>--%>
                                    </h4>
                                </div>
                                <div class="modal-body">
                                    <!-- form start -->
                                    <div class="box-body">
                                        <div class="row">
                                            <asp:TextBox ID="id" runat="server" Visible="false" Enabled="false"></asp:TextBox>
                                            <div class="col-xs-12">
                                                <label for="nombre">
                                                    Nombre</label>
                                                <asp:TextBox ID="nombre" CssClass="form-control" placeholder="ejemplo: Escritorios"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <label for="nombre">
                                                    Descripcion</label>
                                                <asp:TextBox ID="descripcion" CssClass="form-control" placeholder="ejemplo: Escritorios de oficina"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <label for="nombre">
                                                    Sigla</label>
                                                <asp:TextBox ID="sigla" CssClass="form-control" placeholder="ejemplo: ES" runat="server" MaxLength="4"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Cerrar</button>
                                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Guardar Cambios" OnClientClick="return Validar();"
                                        ID="btnGuardarAuxiliaresContables" OnClick="btnGuardarAuxiliaresContables_Click" />
                                    <%-- <button id="btnGuardarGrupoContable" type="button" class="btn btn-primary">Save changes</button>--%>
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
                 <div class="modal fade" id="deleteConfirmModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title" id="deleteLabel">Notificacion de eliminacion</h4>
            </div>
            <div class="modal-body">
                <p><strong>Esta seguro que desea eliminar el auxiliar contable?</strong></p>
                <p><small>
                    No se podran eliminar los auxiliares contables que ya tengan asignado un activo</small>
                </p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                 <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" 
                                    Text="Eliminar" onclick="btnEliminar_Click" />
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

            if (document.getElementById('<%=nombre.ClientID %>').value == ''||document.getElementById('<%=descripcion.ClientID %>').value == ''||document.getElementById('<%=sigla.ClientID %>').value == '') {
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
    <script type = "text/javascript">
        window.onload = function () {
            document.onkeydown = function (e) {
                return (e.which || e.keyCode) != 116;
            };
        }
</script>

<script type="text/javascript">
    function ConfirmaElimina() {
        $('#deleteConfirmModal').modal('show');
        return false;
    }

   
    </script>

</body>
</html>
