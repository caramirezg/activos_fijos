<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroActivosRevaluados.aspx.cs" Inherits="ActivosFijosEETC.Views.RegistroActivosRevaluados" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

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
        <script src="js/revaluo.js" type="text/javascript"></script>
   
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
    <script src="js/jquery.plugins.js" type="text/javascript"></script>
    <script src="js/plugins/jquery.price_format.2.0.min.js" type="text/javascript"></script>
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
                    <span class='fa fa-dollar'></span> Revalúo Técnico <small></small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                   
                    <li class="active">Revalúo Técnicos</li>
                </ol>
            </section>
            <form id="Form1" runat="server">

         


            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    REVALUO TECNICO</h3>
                            </div>
                            <!-- /.box-header -->
                            <!-- form start -->
                             <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            
                            <div class="box-body">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        
                                    <asp:LinkButton ID="btnVerRevaluos" runat="server" 
                                            Text="<span class='fa fa-dollar'></span> Ver Revaluos" 
                                            CssClass="btn btn-primary" onclick="btnVerRevaluos_Click"
                                    ></asp:LinkButton>
                                    <asp:LinkButton ID="btnImprimir" runat="server" 
                                            Text="<span class='fa fa-print'></span> Imprimir Informe" 
                                            CssClass="btn btn-warning" onclick="btnImprimir_Click"
                                   ></asp:LinkButton>
                          
                                       </ContentTemplate>
                                       <Triggers>
                                       <asp:PostBackTrigger ControlID="btnImprimir" />
                                       </Triggers>
                                </asp:UpdatePanel>    
                            </div>
                           
                            <div class="box-body">
                                <asp:TextBox CssClass="hidden" ID="txtCodigoMaestroRevaluo" runat="server"></asp:TextBox>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label for="nombre">
                                            Motivo Revaluo</label>
                                        <asp:TextBox ID="txtMotivoRevaluo" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3">
                                        <label for="nombre">
                                            Fecha de Revalúo</label>
                                        <asp:TextBox ID="txtFechaRevaluo" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-9">
                                        &nbsp;<label for="nombre">Disposicion de respaldo</label><asp:TextBox ID="txtDisposicionRespaldo" CssClass="form-control"
                                            ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="box-body">
                                    <div id="danger" class="alert alert-danger" role="alert" style="display: none">
                                        <strong>Error!</strong>
                                    </div>
                                    <div id="success" class="alert alert-success" role="alert" style="display: none">
                                        <strong>Correcto!</strong>
                                    </div>
                                    <div id="warning" class="alert alert-success" role="alert" style="display: none">
                                        <strong>Atencion!</strong>
                                    </div>
                                </div>

                        <!-- /.box-body -->
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">
                                    DATOS DEL REVALUO</h3>
                            </div>
                            <div class="box-body">
                                <!-- /.box-header -->
                                <!-- form start -->
                        
                               
                                       
                                
                              
                                        
                                </div>

                                <div class="row">
                                <div class="col-md-5"  id="_activos_existentes" runat="server">
                                      <div class="box">
                                <dx:ASPxGridView ID="gridActivos" runat="server" AutoGenerateColumns="False" 
                                    Caption="Activos" EnableTheming="True" Theme="Aqua" Width="100%">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="0" Visible="False">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="fk_activo" VisibleIndex="1" 
                                            Visible="False">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcion" VisibleIndex="3" 
                                            Caption="Descripción">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="serie" VisibleIndex="4" Caption="Serie">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigo" VisibleIndex="2" Caption="Código">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="valor_neto" VisibleIndex="9" 
                                            Caption="Valor Neto">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Costo Actualizado Inicial" 
                                            FieldName="costo_actualizado_inicial" VisibleIndex="7">
                                            <PropertiesTextEdit>
                                                <ValidationSettings ErrorText="Valor inválido">
                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
<SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                </dx:ASPxGridView>
                            </div>
                                </div>
                                  <div class="col-md-1" id="actionActivos" runat="server">

                                  
                            <div class="box-body center-block">
                                <table class="table table-bordered text-center">
                                    <tr>
                                        <td>
                                             <asp:LinkButton ID="btnRegistrarRevaluo" CssClass="btn btn-primary" 
                                                runat="server" Text="<span class='fa fa-save'></span> Revaluar"
                                                onclick="btnRegistrarRevaluo_Click1"></asp:LinkButton>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btnEliminarRevaluo" CssClass="btn btn-danger" 
                                                runat="server" Text="<span class='fa fa-trash-o'></span>  Eliminar"
                                                OnClientClick="return ConfirmaElimina();" 
                                                onclick="btnEliminarRevaluo_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>


                             
                                </div>


                                <div class="col-md-6" id="_activos_revaluados" runat="server">
                                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <div class="box" >
                                            <div class="box-body table-responsive">
                                                <dx:ASPxGridView ID="gridDetalleRevaluo" runat="server" AutoGenerateColumns="False"
                                                    EnableTheming="True" Theme="Aqua" Width="100%" KeyFieldName="id" 
                                                    Caption="Activos Revaluados" 
                                                    >
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn VisibleIndex="0" FieldName="id" Visible="False">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="fk_activo" 
                                                            Visible="False">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="8" FieldName="nuevo_costo" 
                                                            Caption="Nuevo Costo" Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                                    <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                                    </RegularExpression>
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="9" FieldName="nueva_vida_util" 
                                                            Caption="Nueva Vida Util" Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="11" FieldName="fkc_estado_revaluo" 
                                                            Visible="False">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                                    <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                                    </RegularExpression>
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="10" FieldName="observaciones" 
                                                            Caption="Observaciones" Width="250px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>

                                                        
                                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="codigo" Caption="Código" 
                                                            Width="150px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inv&#225;lido">
                                                                    <RegularExpression ErrorText="Fall&#243; la validaci&#243;n de expresi&#243;n Regular">
                                                                    </RegularExpression>
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" 
                                                            VisibleIndex="3" Width="400px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Serie" FieldName="serie" VisibleIndex="4" 
                                                            Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Estado Revalúo" FieldName="estado_revaluo" 
                                                            VisibleIndex="13" Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>

                                                        
                                                        <dx:GridViewDataTextColumn Caption="Costo Antiguo (Valor Neto Anterior)" 
                                                            FieldName="costo_antiguo" VisibleIndex="6" Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Costo Revalúo" FieldName="costo_revaluo" 
                                                            VisibleIndex="7" Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Costo Actualizado Inicial Anterior" 
                                                            FieldName="costo_actualizado_inicial_anterior" VisibleIndex="5" Width="200px">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings ErrorText="Valor inválido">
                                                                    <RegularExpression ErrorText="Falló la validación de expresión Regular" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>

                                                        
                                                    </Columns>
                                                    <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
                                                    <Settings ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True" ShowFooter="True"
                                                        ShowGroupPanel="True" />
                                                    <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" /><Settings ShowHorizontalScrollBar="True" ShowVerticalScrollBar="True" ShowFooter="True"
                                                        ShowGroupPanel="True" /><SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                                                  
                                                </dx:ASPxGridView>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                </div>

                                </div>

                      

                              
                                       
                              

                               
                            </div>
                        </div>
               
                        <!-- /.box -->   
                  
                      

                        <div class="modal fade" id="RevaluoModal" tabindex="-1" role="dialog" aria-labelledby="deleteLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="H2">
                        Revalúo Técnico</h4>
                </div>
                <div class="modal-body">
                
                  <div class="row">
                  <div class="col-md-6">
                                                <label for="nombre">
                                                    Costo Antiguo <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtCostoAntiguo" runat="server" CssClass="form-control" Enabled=false></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <label for="nombre">
                                                    Costo de revaluo <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtCostoRevaluo" onkeyup="CalculaNuevoCosto();" runat="server" CssClass="form-control" placeholder="ejemplo:300"></asp:TextBox>
                                            </div>
                  </div>
                       <div class="row">
                                            <div class="col-md-6">
                                                <label for="nombre">
                                                    Nuevo Costo <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtNuevoCosto" runat="server" CssClass="form-control" placeholder="ejemplo: 500.30" Enabled=false></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <label for="nombre">
                                                    Nueva Vida Util (años) <font color="red">*</font>
                                                </label>
                                                <asp:TextBox ID="txtNuevaVidaUtil" runat="server" CssClass="form-control" placeholder="ejemplo:3"></asp:TextBox>
                                            </div>
                                        </div>
                                   
                            
                                <div class="row">
                                    
                                            <div class="col-md-12">
                                                <label for="nombre">
                                                    Observaciones
                                                </label>
                                                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" placeholder="ejemplo: XYD001EF501"></asp:TextBox>
                                            </div>
                                          
                                      
                                    
                                </div>
                  
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Cancelar</button>
                    <asp:Button ID="btnRevaluar" runat="server" Text="Revaluar" CssClass="btn btn-danger"
                         onclick="btnRegistrarRevaluo_Click" OnClientClick="return Validar();" />
                </div>
            </div>
        </div>
    </div>   

     
            </section>
            </form>
        </aside>
    </div>
    <!-- ./wrapper -->

    <script type="text/javascript">
        function CalculaNuevoCosto() {
            //Your Code



            var costo_antiguo = document.getElementById("<%=txtCostoAntiguo.ClientID %>").value.toString().replace(/\,/g, '.');
            var costo_revaluado = document.getElementById("<%=txtCostoRevaluo.ClientID %>").value.toString().replace(/\,/g, '.');
            var nuevo_costo = parseFloat(costo_antiguo) + parseFloat(costo_revaluado);
            $('#txtNuevoCosto').val(nuevo_costo);

        }
    </script>
    <script type="text/javascript">



        $("#txtCostoRevaluo").Decimales();
        $("#txtNuevaVidaUtil").Enteros();

        function Validar() {
            var error = 0;

            if (document.getElementById('<%=txtCostoAntiguo.ClientID %>').value == '' || document.getElementById('<%=txtCostoRevaluo.ClientID %>').value == '' || document.getElementById('<%=txtNuevaVidaUtil.ClientID %>').value == '') {
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
            if (confirm("¿Está seguro de que quiere eliminar el registro?"))
                return true;
            else return false;
        }

     

    </script>

</body>
</html>
