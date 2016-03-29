<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Almacen.Views.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ACTIVOS FIJOS</title>
    <!-- Stylesheets -->
    <link href="css/LogIn.css" rel="stylesheet" type="text/css" />
    <link href="css/queryLoader.css" rel="stylesheet" type="text/css" />
    <link href="css/DropDown.css" rel="stylesheet" type="text/css" />
    <!-- Scripts -->
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/queryLoader.js" type="text/javascript"></script>
    <script src="js/LogIn.js" type="text/javascript"></script>
</head>
<body>
    <div class="BackDotted">
    </div>
    <div id="MainContent" class="MainContent">
        <div class="Content">
            <div class="DivLogins">
                <div class="Back">
                    <div class="Log1 active">
                    </div>
                    <div class="LogDatos active" align="center">
                    <h4>Sistema de Control de Activos Fijos</h4>
                       </br>
                        <input id="user" type="text" style="padding-left: 30px; background-image: url(img/user.png);"
                            placeholder="Usuario" />
                        <span id="UsuError" class="error">
                            <p>
                                *USUARIO INCORRECTO</p>
                        </span>
                      
                        <input id="pass" type="password" style="padding-left: 30px; background-image: url(img/key.png);"
                            placeholder="Password" />
                        <span id="PassError" class="error"><p> *CLAVE INCORRECTA></p></span>
                        <div class="bottom" align="center">
                            <input id="Ingreso" type="button" value="INGRESO"></input>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
