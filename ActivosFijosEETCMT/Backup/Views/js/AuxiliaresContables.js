$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
  
    });

});


$(function () {
    $('#btnNuevoAuxiliar').bind('click', function () {
        LimpiaControles();
        document.getElementById('lblTitleModal').innerHTML = 'Registrar Auxiliar Contable';
        $('#modalDatosAuxiliarContable').modal('show');
    });
});

function modalEditar() {
    document.getElementById('lblTitleModal').innerHTML = 'Editar Grupo Contable';
    $('#modalDatosAuxiliarContable').modal('show');
    document.getElementById("sigla").readOnly = true;
    document.getElementById("grupoContable").readOnly = true;
    
}

function LimpiaControles() {

    var textos = $('input[type=text], input[type=password], select');

    $(textos).each(function () {
        $(this).val('');
    })
}

