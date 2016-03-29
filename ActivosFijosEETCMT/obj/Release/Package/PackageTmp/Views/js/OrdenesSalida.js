$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });

});

  

function modalAdicionar() {
    $('#modalAdicionar').modal('show');
    return false;
}

function modalHide() {
    $('#modalAdicionar').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
    return false;
}

function modalEditar() {
    $('#modalEditar').modal('show');

    return false;
}