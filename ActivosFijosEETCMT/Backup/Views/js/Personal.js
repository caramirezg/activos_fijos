$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });

});

$(function () {
    $('#btnNuevoPersona').bind('click', function () {
        LimpiaControles();
       document.getElementById("txtDocumento").readOnly = false;
        document.getElementById('lblTitleModal').innerHTML = 'Registrar Persona';
        $('#modalDatosPersonas').modal('show');
    });
});

function LimpiaControles() {

    var textos = $('input[type=text], input[type=password], select');

    $(textos).each(function () {
        $(this).val('');
    })
}

function modalEditar() {
    document.getElementById('lblTitleModal').innerHTML = 'Editar Persona';
    $('#modalDatosPersonas').modal('show');
}



