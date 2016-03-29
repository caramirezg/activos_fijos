$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });
});
//------------------------------------------------------------------Cargando Tabla--------------------------
$(function () {

    CargarDataTables();

    $("#markers>h2").on('click', function(){
        var ID = $(this).attr('id');
        var marker = $("#test").gmap3({ get: { id: ID } });
        google.maps.event.trigger(marker, 'click');
    });

});

//----------------------------------------------------------------Funcion Explicta Cargar Ingresos por Fecha--
function CargarDataTables() {
    $.ajax({
        type: "POST",
        url: "../Controllers/ControllerProveedor.asmx/DatosProveedores",
        data: {},
        contentType: "application/json; chartset:utf-8",
        dataType: "json",
        async: false,
        success: loadMap,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
}

function loadMap(result) {

    var values = [];
    $.each(result.d, function () {
        values.push({ latLng: [this.lati, this.longi], data: '<div class="Desc"><h1>"' + this.nombre + '"</h1><h2>' + this.direccion + '</h2><h3>' + this.telefono + ' - ' + this.celular + '</h3></div>', id: this.ID });
        $('#markers').append('<h2 id='+ this.ID +'>'+this.nombre+'</h2>');
    });

    $("#test").gmap3({
        map: {
            options: {
                zoom: 14,
                center: [-16.4992945, -68.1353024],
                streetViewControl: false,
                mapTypeControl: false,
            }
        },
        marker: {
            values: values,
            options: {
                draggable: false
            },
            events: {
                click: function (marker, event, context) {
                    var map = $(this).gmap3("get"),
                    infowindow = $(this).gmap3({ get: { name: "infowindow"} });
                    if (infowindow) {
                        infowindow.open(map, marker);
                        infowindow.setContent(context.data);
                    } else {
                        $(this).gmap3({
                            infowindow: {
                                anchor: marker,
                                options: { content: context.data }
                            }
                        });
                    }
                },

            }
        }
    });
}

