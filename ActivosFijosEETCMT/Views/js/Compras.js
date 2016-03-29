$(document).ready(function () {

    $(document).bind("contextmenu", function (e) {
        return false;
    });

//    $('#dateFechaRegistro').datepicker({
//        format: 'dd-mm-yyyy'
//    });

    $('#dateFechaRegistro').datepicker({
        format: 'dd-mm-yyyy',
        clearBtn: true,
        language: "es",
        calendarWeeks: true,
        autoclose: true,
        todayHighlight: true
    });
   
});

$(function () {

    $("#txtNroFactura").Enteros();
    $("#txtTasaUFV").Decimales();
    $("#txtTasaDolar").Decimales();

});

$(document).ready(function () {
    //***************Obtiene las tasas de cambio ufv y dolar de la fecha*****************
    $(function () {

        $('#dateFechaRegistro').datepicker()
          .on('changeDate', function (ev) {
       
              $('#txtTasaUFV').val("");
              $('#txtTasaDolar').val("");

              $(this).datepicker('hide');
              var fecha = $('#dateFechaRegistro').val();
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


//-----------------------------------------CARGA LA LISTA DE PROVEEDORES
//$(document).ready(function () {

//    $('#ItemOption').change(function () {

//        var id = $(this).val();
//        if (id != "") {
//            DatosProveedor(id);
//        } else {
//            LimpiaControles();
//        }
//    });
//    //----------CARGA COMBO PROVEEDORES
//    $.ajax({
//        type: "POST",
//        url: "../Controllers/ControllerProveedor.asmx/DatosProveedores",
//        data: {},
//        contentType: "application/json; chartset:utf-8",
//        dataType: "json",
//        async: false,
//        success: loadItems,
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert(textStatus + ": " + XMLHttpRequest.responseText);
//        },
//        async: true
//    });
//    function loadItems(result) {


//        $.each(result.d, function () {
//            $('#ddlProveedor').append($("<option></option>").attr("value", this.ID).text(this.nombre));
//        });
//    }
    //---------CARGA COMBO GERENCIAS
//    $.ajax({
//        type: "POST",
//        url: "../Controllers/ControllerAdministracion.asmx/DatosGerencias",
//        data: {},
//        contentType: "application/json; chartset:utf-8",
//        dataType: "json",
//        async: false,
//        success: loadItemsGerencias,
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert(textStatus + ": " + XMLHttpRequest.responseText);
//        },
//        async: true
//    });
//    function loadItemsGerencias(result) {
//        $.each(result.d, function () {
//            $('#ddlSolicitante').append($("<option></option>").attr("value", this.id).text(this.nombre));
//        });
//    }
//});