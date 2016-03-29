$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });

});

$(function () {
    $('#btnNuevo').bind('click', function () {
        LimpiaControles();
       
        document.getElementById('lblTitleModal').innerHTML = 'Registro Tasas de Cambio';
        $('#modalDatosTasaCambio').modal('show');
    });
});

$(function () {
    $("#txtTasaUfv").Decimales();
    $("#txtTasaSus").Decimales();

    $("#txtEditaTasaUfv").Decimales();
    $("#txtEditaTasaSus").Decimales();

});

function LimpiaControles() {

    var textos = $('input[type=text], input[type=password], select');

    $(textos).each(function () {
        $(this).val('');
    })
}

function modalEditar() {
    $('#modalEditaDatosTasaCambio').modal('show');
    return false;
}

function modalHide() {
    $('#modalEditaDatosTasaCambio').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
    return false;
}