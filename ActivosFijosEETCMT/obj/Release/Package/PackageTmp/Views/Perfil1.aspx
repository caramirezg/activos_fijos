<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true"
    CodeBehind="Perfil1.aspx.cs" Inherits="ActivosFijosEETC.Views.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/Titulos.css" rel="stylesheet" type="text/css" />
    <link href="css/Perfil.css" rel="stylesheet" type="text/css" />
    <link href="css/TextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/Button.css" rel="stylesheet" type="text/css" />
    <link href="css/Label.css" rel="stylesheet" type="text/css" />
    <link href="css/Formularios.css" rel="stylesheet" type="text/css" />

   
    <script src="js/jquery.min.js" type="text/javascript"></script>
     <script src="js/json2.js"                type="text/javascript"></script>
    <script  type="text/javascript">document.write('<script src="js/Perfil.js" type="text/javascript"><\/script>');   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="framePerfil">
        <h4 class="h4Titulos">
            Configuración del Perfil</h4>
        <hr align="middle" size="1" width="95%" style="color: #BDBDBD; padding-left: 20px;" />
        <h3 class="h3Titulos">Datos del Usuario</h3>
        <div class="datos" style="padding-left:260px;">
            <table border="0" align="middle">
                <tr class="fila">
                    <td align="right">
                        <label for="nombre" class="labelForms">
                            Nombres:</label>
                    </td>
                    <td class="campo">
                        <input id="nombre" type="text" placeholder="Nombres" class="textBoxStyle1" />
                    </td>
                </tr>
                <tr class="fila">
                    <td align="right">
                        <label for="apellido" class="labelForms">
                            Apellidos:</label>
                    </td>
                    <td class="campo">
                        <input id="apellido" type="text" placeholder="Apellidos" class="textBoxStyle1" />
                    </td>
                </tr>
                <tr class="fila">
                    <td align="right">
                        <label for="area" class="labelForms">
                            Área:</label>
                    </td>
                    <td class="campo">
                        <select id="area" class="comboBoxStyle1">
                        </select>
                    </td>
                </tr>
                <tr class="fila">
                    <td align="right">
                        <label for="cargo" class="labelForms">
                            Cargo:</label>
                    </td>
                    <td class="campo">
                        <select id="cargo" name="cargo" class="comboBoxStyle1"> 
                        </select>
                    </td>
                </tr>
                <tr class="fila">
                    <td align="right">
                        <label for="perfil" class="labelForms">
                            Perfil:</label>
                    </td>
                    <td class="campo">
                        <input id="perfil" type="text" placeholder="Perfil" class="textBoxStyle1" disabled ="disabled"/>
                    </td>
                </tr>
                <tr class="fila">
                    <td align="right">
                        <label for="estado" class="labelForms">
                            Estado:</label>
                    </td>
                    <td class="campo">
                        <input id="estado" type="text" placeholder="Estado" class="textBoxStyle1" disabled="disabled" />
                    </td>

                </tr>
                        
            </table>
            <select id="Town">
<option value="">Select...</option>
<option value="4004">Town A</option>
<option value="4005">Town B</option>
<option value="4006">Town C</option>
<option value="4007">Town D</option>
<option value="4008">Town E</option>
<option value="4003">Town F</option>
</select>
        </div>

        <div style="padding-left:280px;">
        <hr align="left" size="1" width="47%" style="color: #BDBDBD; padding-left: 20px;" />
        <button type=button id="guardarDatosUsuario" class="button" style='background: url("img/save_16.png") 10px center no-repeat;
                    padding-left: 30px;'>
                    Guardar cambios</button>
                <em id="Datos"></em>
        </div>
        <hr align="middle" size="1" width="95%" style="color: #BDBDBD; padding-left: 20px;" />
        <h3 class="h3Titulos">Cambio Contraseña</h3>      
         <div class="datos" style="padding-left:200px;">
            <table border="0" align="middle">
                 <tr class="fila">
                    <td align="right">
                        <label for="usuario" class="labelForms">
                            Usuario:</label>
                    </td>
                    <td class="campo">
                        <input id="usuario" type="text" placeholder="Usuario" class="textBoxStyle1" disabled="disabled"/>
                    </td>
                </tr>
                 
                <tr class="fila">
                    <td align="right">
                        <label for="clave" class="labelForms">
                            Contraseña nueva:</label>
                    </td>
                    <td class="campo">
                        <input id="claveNueva" type="password" placeholder="Contraseña nueva" class="textBoxStyle1" />
                    </td>
                </tr>
                <tr class="fila">
                    <td align="right">
                        <label for="clave" class="labelForms">
                            Confirmación contraseña:</label>
                    </td>
                     <td class="campo">
                        <input id="confirm" type="password" placeholder="Confirmar contraseña" class="textBoxStyle1" />
                    </td>
                </tr>
                <tr class="fila">
                    <td align="right">
                        <label for="clave" class="labelForms">
                            Contraseña actual:</label>
                    </td>
                    <td class="campo">
                        <input id="claveActual" type="password" placeholder="Contraseña actual" class="textBoxStyle1" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding-left:280px;">
        <hr align="left" size="1" width="47%" style="color: #BDBDBD; padding-left: 20px;" />
        <button id="GuardarPass" type="button" class="button" style='background: url("img/save_16.png") 10px center no-repeat;
                    padding-left: 30px;'>
                    Guardar cambios</button>
                <em id="paswords"></em>
        </div>

    </div>
</asp:Content>
