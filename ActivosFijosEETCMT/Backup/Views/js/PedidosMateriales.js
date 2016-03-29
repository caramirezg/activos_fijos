$(function () {

    $(document).bind("contextmenu", function (e) {
        return false;
    });

    $('#ItemOption').change(function () {
        var tipoEstadistico = $("#ItemOption option:selected").text();
        if (tipoEstadistico != 'Seleccione una Categoria...') {
            window.location = 'Reports/ReportePedidosMateriales.aspx?tipo=' + tipoEstadistico + '';
        }
    });

});