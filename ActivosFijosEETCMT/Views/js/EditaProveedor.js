$(document).ready(function () {

    $(document).bind("contextmenu", function (e) {
        return false;
    });

    $('body').animate({ 'opacity': '1' }, 1000);

    $('#navigation em').bind('click', function () {
        $('#confirm').fadeOut(500);
    });

//    $("#telefono").Enteros();
    $("#nit").Enteros();
});

//-----------------------------------------CARGA LA LISTA DE PROVEEDORES
$(document).ready(function () {

    $('#ItemOption').change(function() {

        var id = $(this).val();
        if (id != "") {
            DatosProveedor(id);
        } else {
            LimpiaControles();
        }
    });

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
            $('#ItemOption').append($("<option></option>").attr("value", this.ID).text(this.nombre));
        });
        $('#ItemOption').selectBox().selectBox('settings', {
            'menuTransition': 'slide',
            'menuSpeed': 0
        });
    }

});

function DatosProveedor(id) {

   
    $.ajax({
        type: "POST",
        url: "../Controllers/ControllerProveedor.asmx/DatosProveedorPorID",
        data: JSON.stringify({ id: id }),
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
        var lati; 
        var longi;
        $.each(result.d, function () {
            $('#nombre').val(this.nombre);
            $('#telefono').val(this.telefono);
            $('#celular').val(this.celular);
            $('#direccion').val(this.direccion);
            $('#nit').val(this.nit);
            $('#Lat').val(this.lati);
            $('#Long').val(this.longi);
            lati = this.lati;
            longi = this.longi;
            });
        loadMap(lati, longi);
    }
}
function loadMap(lati, longi) {
    
$('#test').gmap3({
    clear: "marker"
  });

    $("#test").gmap3({
        marker: {
            latLng: [lati, longi],
            options: {
                        draggable: true
                    },
             events: {
                        dragend: function (marker) {

                            var latLong = String(marker.getPosition());
                            $('#Lat').val(latLong.split(',')[0].substring(1, 12));
                            $('#Long').val(latLong.split(',')[1].substring(1, 12));
                        }
                    }
        }  
    });
}


//------------------------------------------------------------CARGANDO DATOS
$(function () {

    $('#registerButton').bind('click', function () {

        var id = $('#ItemOption').val();

        var nombre = $('#nombre').val();
        var direccion = $('#direccion').val();
        var telefono = $('#telefono').val();
        var celular = $('#celular').val();
        var nit = $('#nit').val();
        var lati = $('#Lat').val();
        var longi = $('#Long').val();
        if (id == "" || id == null || nombre == "" || nombre == null || direccion == "" || direccion == null ||
                    telefono == "" || telefono == null || celular == "" || celular == null || nit == "" || nit == null ||
                    lati == "" || lati == null || longi == "" || longi == null) {
            $('#danger').text('Imposible continuar, por favor seleccione un proveedor para editar y complete los campos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
            return false;
        }
        else {

            var result = EnviaDatos(id, nombre, telefono, celular, direccion, nit, lati, longi);
            if (result == 1) {
                CargarComboBox();
                LimpiaControles();
                $('#success').text('DATOS GUARDADOS CORRECTAMENTE').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
            }
            else {
                $('#error').text('Lo sentimos Ha ocurrido un error.').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
            }
        }
    });

})


//----------------ENVIO DE DATOS PARA LA EDICION DEL ITEM--------------------------------
function EnviaDatos(id, nombre, telefono, celular, direccion, nit, lati, longi) {
    var resultado = 0;
    
    $.ajax({
        url: '../Controllers/ControllerProveedor.asmx/ActualizaProveedor',
        data: JSON.stringify({ id: id, nombre: nombre, telefono: telefono, celular:celular, direccion: direccion, nit: nit, lati:lati, longi:longi }),
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (result) {
            resultado = result.d;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
    return resultado;
}

function LimpiaControles() {

    var textos = $('input[type=text], input[type=password], select');

    $(textos).each(function() {
        $(this).val('');
    });
}

function CargarComboBox() {

    $('#ItemOption').empty();
    $("#ItemOption").append('<option value="">Seleccione un Proveedor</option>');

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
            $('#ItemOption').append($("<option></option>").attr("value", this.ID).text(this.nombre));
        });
        $('#ItemOption').selectBox().selectBox('settings', {
            'menuTransition': 'slide',
            'menuSpeed': 0
        });
    }
}