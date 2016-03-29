<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true"
    CodeBehind="RutaProveedor.aspx.cs" Inherits="ActivosFijosEETC.Views.RutaProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/proveedores.css" rel="stylesheet" type="text/css" />
    <link href="css/Titulos.css" rel="stylesheet" type="text/css" />
    <link href="css/Label.css" rel="stylesheet" type="text/css" />
    <link href="css/Button.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="map/jquery-1.4.4.min.js"></script>
    <script src="http://maps.googleapis.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script type="text/javascript" src="map/gmap3.js"></script>
    <style type="text/css">
        .gmap3
        {
            border: 1px dashed #C0C0C0;
            width: 90%;
            height: 400px;
        }
        .Desc
        {
            padding: 1px;
            font-family: Arial,Helvetica,sans-serif;
        }
        .Desc > h1
        {
            font-size: 15px;
            border-bottom: 1px solid #566579;
            color: #2365B0;
        }
        .Desc > h2
        {
            font-size: 12px;
            margin-top: 5px;
            padding: 2px 0 2px 25px;
            background: url(img/house.png) no-repeat 0px 0px;
            color: #030405;
        }
        .Desc > h3
        {
            font-size: 12px;
            padding: 2px 0 2px 25px;
            background: url(img/phone.png) no-repeat 0px 1px;
            color: #030405;
        }
        
   
    </style>
    <script type="text/javascript">
        $.ajax({
            type: "POST",
            url: "../Controllers/ControllerProveedor.asmx/DatosProveedores",
            data: {},
            contentType: "application/json; chartset:utf-8",
            dataType: "json",
            async: false,
            success: loadItems,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            },
            async: true
        });
        function loadItems(result) {


            $.each(result.d, function () {
                $('#Proveedor1, #Proveedor2').append($("<option></option>").attr("value", (this.lati.trim() + '|' + this.longi.trim())).text(this.nombre));
            });
            $('#Proveedor1, #Proveedor2').selectBox().selectBox('settings', {
                'menuTransition': 'slide',
                'menuSpeed': 0
            });
        }

        $(function () {

            RenderMap();

            $('#Generar').click(function () {
                var origen = $('#Proveedor1').val();
                var destino = $('#Proveedor2').val();
                if (origen != "" && destino != "")
                    updateDirections(origen, destino);
            });
        });

        function RenderMap() {

            $("#test").gmap3({
                map: {
                    options: {
                        center: [-16.500287, -68.122473],
                        zoom: 14
                    }
                },
                marker: {
                    values: [{ latLng: [-16.499217, -68.13515]}],
                    options: {

                        icon: new google.maps.MarkerImage("http://maps.gstatic.com/mapfiles/icon_greenA.png")
                    },
                    tag: 'HOLA'
                },
                directionsrenderer: {

                    /*container: $(document.createElement("div")).addClass("googlemap").insertAfter($("#test")),*/
                    options: {
                        draggable: true,
                        preserveViewport: false,
                        markerOptions: {
                            visible: false
                        }
                    }
                }
            });

        }

        function updateDirections(origen, destino) {


            $('#test').gmap3({ clear: "marker" });

            $("#test").gmap3({
                getroute: {
                    options: {
                        origin: { latLng: [origen.split('|')[0], origen.split('|')[1]] },
                        destination: { latLng: [destino.split('|')[0], destino.split('|')[1]] },
                        travelMode: google.maps.DirectionsTravelMode.DRIVING
                    },
                    callback: function (results) {
                        if (!results) return;

                        $("#test").gmap3({ get: "directionrenderer" }).setDirections(results);
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="frame1">
        <h4 class="h4Titulos">
            Registro de Proveedor</h4>
        <hr align="middle" size="1" width="95%" style="color: #BDBDBD; padding-left: 20px;" />
        <br />
        <div class="divRuta">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 450px;">
                        <span class="labelForms" style="padding: 3px 2px 2px 2px">DESDE</span>
                        <select id="Proveedor1" name="standard-dropdown" style="width: 300px; color: Black;
                            height: 30px;">
                            <option value="-16.499217|-68.13515">CENTRO DE COMUNICACIONES LA PAZ</option>
                        </select>
                    </td>
                    <td>
                        <span class="labelForms" style="padding: 3px 2px 2px 2px">HACIA</span>
                        <select id="Proveedor2" name="standard-dropdown" style="width: 300px; color: Black;
                            height: 30px;">
                            <option value="">Seleccione un Destino</option>
                        </select>
                    </td>
                </tr>
            </table>
            <div id="MapContenedor">
                <div id="test" class="gmap3">
                </div>
            </div>
            <hr align="left" size="1" width="90%" style="color: #BDBDBD; padding-left: 20px;" />
            <button id="Generar" type="button" value="RUTA" class="button">
                Generar ruta</button>
        </div>
    </div>
</asp:Content>
