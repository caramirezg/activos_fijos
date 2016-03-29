$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;

    });

});
//------------------------------MARCAS-------------------------------
//$(function () {
//    $('#btnNuevaMarca').bind('click', function () {
//        LimpiaControles();
//        document.getElementById('lblTitleModalMarcas').innerHTML = 'Registrar Marcas';
//        $('#modalDatosMarcas').modal('show');
//    });
//});

function modalNuevaMarcas() {
    document.getElementById('lblTitleModalMarcas').innerHTML = 'Registrar Marcas';
    $('#modalDatosMarcas').modal('show');
}

function modalEditarMarcas() {
    document.getElementById('lblTitleModalMarcas').innerHTML = 'Editar Marcas';
    $('#modalDatosMarcas').modal('show');
}




//--------------------------MODELOS--------------------------

//$(function () {
//    $('#btnNuevoModelo').bind('click', function () {
//        LimpiaControles();
//        var variable = document.getElementById("lblModelo").innerHTML;
       
//        document.getElementById('txtMarcaPopUp').value = variable;
//        document.getElementById('lblTitleModalModelos').innerHTML = 'Registrar Modelos';
//        $('#modalDatosModelos').modal('show');
//    });
//});

function modalNuevoModelo() {
    var variable = document.getElementById("lblModelo").innerHTML;
    document.getElementById('txtMarcaPopUp').value = variable;
    document.getElementById('lblTitleModalModelos').innerHTML = 'Registrar Modelos';
    $('#modalDatosModelos').modal('show');
}

function modalEditarModelo() {
    document.getElementById('lblTitleModalModelos').innerHTML = 'Editar Modelos';
    $('#modalDatosModelos').modal('show');
}

function LimpiaControles() {

    var textos = $('input[type=text], input[type=password], select');
    $(textos).each(function () {
       
        $(this).val('');
    })
}