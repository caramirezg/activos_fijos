<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroBajasActivos.aspx.cs"
    Inherits="ActivosFijosEETC.Views.RegistroBajasActivos" %>

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
    <!-- jQuery UI 1.10.3 -->
    <script src="bootstrap/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="bootstrap/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <!-- Sparkline -->
    <script src="bootstrap/js/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
   
   
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
                    <i class="fa fa-trash-o"></i> Bajas activos fijos&nbsp;<small> </small>
                </h1>

                

                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                    <li class="active">Bajas activos</li>
                </ol>
            </section>
            <form id="Form1" runat="server">

             <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
            <section class="content">
                <div class="row" id="div3" runat="server">
                    <div class="col-md-12">
                        <div id="div4" class="box box-primary" runat="server">
                            <div class="box-header">
                                <h3 class="box-title">
                                    BAJAS</h3>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-body">
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                <asp:LinkButton ID="btnVerBajas" runat="server" Text="&lt;span class='fa fa-file-o'&gt;&lt;/span&gt; Ver bajas"
                                    CssClass="btn btn-primary" onclick="btnVerBajas_Click"></asp:LinkButton>
                                <asp:LinkButton ID="btnImprimirBajas" runat="server" Text="<span class='fa fa-print'></span> Imprimir baja"
                                    CssClass="btn btn-warning" onclick="btnImprimirBajas_Click"></asp:LinkButton>
                             </ContentTemplate>
                                       <Triggers>
                                       <asp:PostBackTrigger ControlID="btnImprimirBajas" />
                                       </Triggers>
                                </asp:UpdatePanel>    
                            
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label for="nombre">
                                            Fecha de baja 
                                        </label>
                                        <asp:TextBox ID="txtIdMaestro" class="form-control" ReadOnly="true" Visible="false"
                                            runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtFechaBaja" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6" id="Div5" runat="server">
                                        <label for="nombre">
                                            Motivo Baja 
                                        </label>
                                        <asp:TextBox ID="txtMotivoBaja" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                 <div class="col-md-12" id="Div1" runat="server">
                                        <label for="nombre">
                                            Documento Respaldo 
                                        </label>
                                        <asp:TextBox ID="txtDocumentoRespaldo" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-body" id="_info_1" runat="server">
               
                    <div class="alert alert-info alert-dismissable">
                        <i class="fa fa-info"></i>
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                            &times;</button>
                        <b>Información!</b> Los activos que serán dados de baja deberán ser actualizados
                        a la fecha en la que se dará de baja
                  
                </div>
                </div>

                 

                <div class="box-body">

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

                

                <div class="box-footer">
                    <div class="row">
                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>

                        <div class="col-lg-5" id="_activos_existentes" runat="server">
                            <div class="box">
                                <dx:ASPxGridView ID="gridActivos" runat="server" Width="100%" Caption="Activos" Theme="Aqua"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <dx:GridViewCommandColumn Visible="False" VisibleIndex="0">
                                            <ClearFilterButton Visible="True">
                                            </ClearFilterButton>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="id" FieldName="id" VisibleIndex="1" Visible="False">
                                            <PropertiesTextEdit>
                                             
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="3" Width="100px">
                                            <PropertiesTextEdit>
                                               
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="4"
                                            Width="400px">
                                            <PropertiesTextEdit>
                                                
                                            </PropertiesTextEdit>
                                            <CellStyle HorizontalAlign="Justify">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" VisibleIndex="5" Width="200px">
                                            <PropertiesTextEdit>
                                              
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="fk_activo" FieldName="fk_activo" VisibleIndex="2"
                                            Visible="False">
                                            <PropertiesTextEdit>
                                             
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Ultima corrida de depreciación" 
                                            FieldName="f_ult_act_dep" VisibleIndex="6" Width="250px">
                                            <PropertiesTextEdit DisplayFormatString="{0:dd/MM/yyyy}">
                                               
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                    <Settings ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True" VerticalScrollableHeight="400" />
                                    <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control"></SettingsBehavior>
                                    <Settings ShowVerticalScrollBar="True" ShowHorizontalScrollBar="True" VerticalScrollableHeight="400"
                                        ShowFilterRow="True"></Settings>
                                    <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                </dx:ASPxGridView>
                            </div>
                        </div>
                         </ContentTemplate>
                                </asp:UpdatePanel>

                        <div class="col-lg-1" id="_action" runat="server">


                            <div class="box-body center-block">
                                <table class="table table-bordered text-center">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btnBaja" runat="server" Text="&lt;span class='fa fa-trash-o'&gt;&lt;/span&gt; Dar baja"
                                                CssClass="btn btn-danger  btn-block" OnClientClick="return BajaModal(); "></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btnRevertirBaja" runat="server" Text="&lt;span class='fa fa-reply'&gt;&lt;/span&gt; Revertir"
                                                CssClass="btn btn-primary  btn-block" OnClick="btnquitar_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            

                        </div>
                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>

                        <div class="col-lg-6" id="_activos_baja" runat="server">
                            <div class="box">
                                <dx:ASPxGridView ID="gridActivosBajas" runat="server" Width="100%" Caption="Activos Dados de Baja"
                                    Theme="Aqua" AutoGenerateColumns="False" KeyFieldName="id">
                                    <Columns>
                                        <dx:GridViewCommandColumn Visible="False" VisibleIndex="0">
                                            <ClearFilterButton Visible="True">
                                            </ClearFilterButton>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="id" FieldName="id" VisibleIndex="1" 
                                            Visible="False">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="fk_activo" FieldName="fk_activo" VisibleIndex="2"
                                            Visible="False">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Código" FieldName="codigo" VisibleIndex="3" 
                                            Width="20%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="4"
                                            Width="30%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                            <CellStyle HorizontalAlign="Justify">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" VisibleIndex="5" 
                                            Width="20%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Estado Proceso" FieldName="estado_proceso" VisibleIndex="7"
                                            Width="20%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Observaciones" FieldName="observaciones" 
                                            ShowInCustomizationForm="True" VisibleIndex="6" Width="10%">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFooter="True" ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True"
                                        VerticalScrollableHeight="400" ShowFilterRow="True" />
                                    <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                </dx:ASPxGridView>
                            </div>
                        </div>

                         </ContentTemplate>
                                </asp:UpdatePanel>
                    </div>
                </div>
            </section>

              <div class="modal fade" id="BajaModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="H2">
                        Registro Baja de Activo</h4>
                </div>
                <div class="modal-body">
                
                  
                        <div class="row">
                            <div class="col-md-12">
                                <label for="nombre">
                                    Observaciones <font color="red">*</font>
                                </label>
                                <asp:TextBox ID="txtObservaciones" class="form-control" placeholder="ejemplo: activo en buenas condiciones"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                  
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Cancelar</button>
                    <asp:Button ID="btnDarBaja" runat="server" Text="Baja" CssClass="btn btn-danger"
                        OnClick="btnAdicionar_Click" OnClientClick="return Valida();" />
                </div>
            </div>
        </div>
    </div>

            </form>
        </aside>
    </div>
    <!-- ./wrapper -->
  
</body>
</html>
<script type="text/javascript">
    function ConfirmaElimina() {
        if (confirm("¿Está seguro de que quiere eliminar el registro?"))
            return true;
        else return false;
    }

    function BajaModal() {
        $('#BajaModal').modal('show');
        return false;
    }

    function Valida() {
        var error = 0;

        if (document.getElementById('<%=txtObservaciones.ClientID %>').value == '') {
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
