<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ActivosFijosEETC.Views.login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html  class=" sidebar-large js no-touch" xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ACTIVOS FIJOS</title>
    <!-- Stylesheets -->
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
  
    <!-- bootstrap wysihtml5 - text editor -->
    <link href="bootstrap/css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet"
        type="text/css" />
    <!-- Theme style -->
    <link href="bootstrap/css/AdminLTE.css" rel="stylesheet" type="text/css" />
    <!-- DATA TABLES -->
    <link href="bootstrap/css/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />


    <link href="bootstrap/css/style.min.css" rel="stylesheet" type="text/css" />
    <link href="css/plugins.min.css" rel="stylesheet" type="text/css" />


    <link href="css/LogIn.css" rel="stylesheet" type="text/css" />

    <!-- Scripts -->
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/queryLoader.js" type="text/javascript"></script>
    <script src="js/LogIn.js" type="text/javascript"></script>
</head>
<body class="login- fade-in" data-page="login">
<form runat="server">
<div class="BackDotted">
    <div id="login_block" class="container">
        <div class=row>
           <div class="col-sm-6 col-md-4 col-sm-offset-3 col-md-offset-4">
                <div class="login-box clearfix animated flipInY">
                  <div class="login-logo">
              
                    <img alt="Mi Teleferico" src="img/logo.png">
    
                    <h4 class="label-primary" style="color:White; font-weight:bold">ACTIVOS FIJOS</h4>
                    </div>
                    <hr>
                    <div class="login-form">
                    <div id="PassError" class="alert alert-block alert-danger alert-block fade in" style="display:none">
                    <b>Acceso denegado!</b>
                   
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                         <asp:TextBox ID="user" runat="server" class="input-field form-control" style="padding-left: 30px;" placeholder=" Usuario"></asp:TextBox>

                         <%-- <input id="user" type="text" style="padding-left: 30px;" class="form-control"
                            placeholder="Usuario" />--%>
                  
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                        <%-- <input id="pass" type="password" style="padding-left: 30px;" class="form-control"
                            placeholder="Password" />--%>
                          <asp:TextBox ID="pass" style="padding-left: 30px;" TextMode="Password" runat="server" class="form-control"
                                    placeholder=" Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                      <asp:Button ID="txtIngreso" runat="server" Text="Ingresar" class="btn btn-login" 
                            onclick="txtIngreso_Click"  />
                       <%-- <input id="Ingreso" class="btn btn-login" type="button" value="Ingresar"></input>--%>
                    </div>
                    </div>
                </div>
                  <div class="social-login row">
                  <p class="text-center">
                    <small>Copyright (c) 2014 - Sistemas</small>
                    <a id="link-login" href="javascript:void(0)"></a></p>
                                        </div>
            </div>
        </div>
    </div>

    </div>
    </form>
</body>
</html>