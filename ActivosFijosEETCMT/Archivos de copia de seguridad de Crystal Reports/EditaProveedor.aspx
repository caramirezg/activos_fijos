<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true"
    CodeBehind="EditaProveedor.aspx.cs" Inherits="ActivosFijosEETC.Views.EditaProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/Titulos.css" rel="stylesheet" type="text/css" />
    <link href="css/Label.css" rel="stylesheet" type="text/css" />
    <link href="css/proveedores.css" rel="stylesheet" type="text/css" />
    <link href="css/TextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/Button.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery.plugins.js" type="text/javascript"></script>
    <script src="js/json2.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script src="js/jquery.plugins.js" type="text/javascript"></script>
    <script src="http://maps.googleapis.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script type="text/javascript">
        document.write('<script src="js/EditaProveedor.js" type="text/javascript"><\/script>');
    </script>
    <script type="text/javascript" src="map/gmap3.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#test").gmap3({
                map: {
                    options: {
                        zoom: 14,
                        center: [-16.4992945, -68.1353024],
                        streetViewControl: false
                    }
                }
            });
        });
    </script>
     <style type="text/css">
        .gmap3
        {
            border: 1px dashed #C0C0C0;
            width: 90%;
            height: 400px;
        }
    </style>
    <form id="formElem">
    <div class="frame1">
      <h4 class="h4Titulos">
                Edición de Datos de Proveedor</h4>
      <hr align="middle" size="1" width="95%" style="color: #BDBDBD; padding-left: 20px;" />
      <br />
        <div class="datos">
          <div>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <label for="proveedor" class="labelForms">
                                Seleccione un proveedor:</label>
                        </td>
                        <td>
                            <select id="ItemOption" name="standard-dropdown" style="width: 100%; color: Black;
                                height: 30px;">
                                <option value="">Seleccione un Proveedor</option>
                            </select>
                        </td>
                    </tr>
                </table>
               
            </div>
        <hr align="left" size="1" width="90%" style="color: #BDBDBD; padding-left: 20px;" />
            <div>
            
        <div id="test" class="gmap3">
        </div>
        <input type="text" style="display: none; top: 10px;" name="zoom" id="Lat" />
        <input type="text" style="display: none; top: 50px;" name="zoom" id="Long" />
        <hr align="left" size="1" width="90%" style="color: #BDBDBD; padding-left: 20px;" />
            
            <br />
            <table style="width: 859px">
                <tr>
                    <td>
                        <label for="nombre" class="labelForms">
                            Nombre:</label>
                    </td>
                    <td>
                        <input id="nombre" type="text" placeholder="Nombre del Proveedor." class="textBoxStyle1" />
                    </td>
                    <td>
                        <label for="telefono" class="labelForms">
                            Teléfono:</label>
                    </td>
                    <td>
                        <input id="telefono" type="text" placeholder="Ingrese el Numero Telefonico de la Empresa"
                            class="textBoxStyle1" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <label for="celular" class="labelForms">
                            Celular:</label>
                    </td>
                    <td class="style2">
                        <input id="celular" type="text" placeholder="Ingrese el número Celular de la Empresa"
                            class="textBoxStyle1" />
                    </td>
                    <td class="style2">
                        <label for="direccion" class="labelForms">Dirección:</label>
                    </td>
                    <td class="style2">
                        <input id="direccion" type="text" placeholder="Ingrese la Avenida, Zona y Número."
                            class="textBoxStyle1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="nit" class="labelForms">
                            Nit:</label>
                    </td>
                    <td>
                        <input id="nit" type="text" placeholder="Ingrese el Número Nit del Proveedor." class="textBoxStyle1" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
             <hr align="left" size="1" width="90%" style="color: #BDBDBD; padding-left: 20px;" />
             <button id="registerButton" type="button" class="button"  style='background: url("img/save_16.png") 10px center no-repeat;
                    padding-left: 30px;'>
                    Guardar</button>
                <em id="confirm"></em>
                </div>
        </div>
    </div>
    <br />

    </form>
</asp:Content>
