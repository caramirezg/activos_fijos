$(document).ready(function () {

    $(document).bind("contextmenu", function (e) {
        return false;
    });

    $('#dateFechaTransferencia').datepicker({
        format: 'dd-mm-yyyy',
        clearBtn: true,
        language: "es",
        calendarWeeks: true,
        autoclose: true,
        todayHighlight: true
    });

});

$(document).ready(function () {
    //***************Obtiene las tasas de cambio ufv y dolar de la fecha*****************
    $(function () {

        $('#dateFechaTransferencia').datepicker()
          .on('changeDate', function (ev) {
              $('#txtTasaUFV').val("");
              $('#txtTasaDolar').val("");
              $(this).datepicker('hide');
              var fecha = $('#dateFechaTransferencia').val();
              DatosTasasDeCambio(fecha);
          });
    });



    function DatosTasasDeCambio(fecha) {
        //*******tasa de dolar y ufv********
        $.ajax({
            type: "POST",
            url: "../Controllers/ControllerAdministracion.asmx/obtieneTasaDolarUfv",
            data: JSON.stringify({ fecha: fecha }),
            contentType: "application/json; chartset:utf-8",
            dataType: "json",
            async: false,
            success: loadTasaDolarUfv,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            },
            async: true
        });
    }

    function loadTasaDolarUfv(result) {
        $.each(result.d, function () {
            $('#txtTasaUFV').val(this.tasa_ufv.toFixed(5));

            $('#txtTasaUFV').priceFormat({
                prefix: '',
                thousandsSeparator: '.',
                centsSeparator: ',',
                centsLimit: 5
            });

            $('#txtTasaDolar').val(this.tasa_sus);

            $('#txtTasaDolar').priceFormat({
                prefix: '',
                thousandsSeparator: '.',
                centsSeparator: ',',
                centsLimit: 2
            });
        });
    }

});