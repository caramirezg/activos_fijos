$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });

    $('#txtMaestroFecha').datepicker({
        format: 'dd-mm-yyyy'
    });

    $('#txtMaestroFecha').on('change', function () {
        $('.datepicker').hide();
    });


    $('#txtFechaConclusion').datepicker({
        format: 'dd-mm-yyyy'
    });

    $('#txtFechaConclusion').on('change', function () {
        $('.datepicker').hide();
    });
    

});



function LimpiaControles() {

    var textos = $('input[type=text], input[type=password], select');

    $(textos).each(function () {
        $(this).val('');
    })
}