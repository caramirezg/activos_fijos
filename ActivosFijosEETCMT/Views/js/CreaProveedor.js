$(document).ready(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });
    $('body').animate({ 'opacity': '1' }, 1000);
    LimpiaControles();
});

//------------------------------------------------------------CARGANDO DATOS

$(function () {

    $('#registerButton').bind('click', function () {


        var nombre = $('#nombre').val();
        var telefono = $('#telefono').val();
        var celular = $('#celular').val();
        var direccion = $('#direccion').val();
        var nit = $('#nit').val();
        var lati = $('#Lat').val();
        var longi = $('#Long').val();

        if (nombre == null || nombre == "" || telefono == null || telefono == "" || celular == null || celular == "" || direccion == null || direccion == "" || nit == null || nit == "" || lati == null || lati == "" || longi == null || longi == "") {
            $('#danger').text('Imposible continuar, por favor revise los campos y seleccione un punto en el mapa').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });


            return false;
        } else {

            var result = EnviaDatos(nombre, telefono, celular, direccion, nit, lati, longi);
            if (result > 0) {
                LimpiaControles();
          
                $('#success').text('Datos guardados correctamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });

                return false;
            } else {
                $('#error').text('Lo sentimos Ha ocurrido un error.').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
                return false;
            }

        }
    });

    $('#navigation em').bind('click', function () {
        $('#confirm').fadeOut(500);
    });
});


//----------------ENVIO DE DATOS PARA LA CREACION DE NUEVO USUARIO--------------------------------
function EnviaDatos(nombre, telefono, celular, direccion, nit, lati, longi) {
    var resultado=0;
    $.ajax({
        url: '../Controllers/ControllerProveedor.asmx/CreaProveedor',
        data: JSON.stringify({ nombre: nombre, telefono: telefono, celular:celular, direccion: direccion, nit: nit, lati:lati, longi:longi }),
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
//    $("#telefono, #celular").Enteros();
    $("#nit").Enteros();
    $(textos).each(function() {
        $(this).val('');
    });
}