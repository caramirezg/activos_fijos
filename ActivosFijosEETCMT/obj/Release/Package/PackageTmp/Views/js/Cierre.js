$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });
});
//---------------------------Cargado de tabla central----------------


$(function () {
    function renderTable(result) {
        var dtData = [];
        var num = 1;

        $.each(result, function () {
             dtData.push({
                    "0": this.lineaDescripcion,
                    "1": this.item,
                    "2": this.unidad,
                    "3": this.itemDescripcion,
                    "4": this.cantidad,
                    "5": this.unitario,
                    "6": this.precio,
                    "7": this.ingreso,
                    "8": this.ingreso

                })         
        });

        $('#Answers').dataTable({
            "aaData": dtData,
            "sScrollY": ($(window).height() - 93),
            "bJQueryUI": true,
            "sPaginationType": "full_numbers",
            "iDisplayLength": 50,
            "fnInitComplete": function () {
              
            }
        });
    }
    $.ajax({
        url: '../Controllers/Service_Ingreso.asmx/DatosExistenciaCierre',
     
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            renderTable(result.d);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown);
        }
    });
});


//---------------Se realiza el proceso de cierre-----------------
$(function () {
    $('#cerrar').click(function () {

        $.ajax({
            type: "POST",
            url: "../Controllers/Service_Ingreso.asmx/EjecutarCierre",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: cierreResult,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    });
});


function cierreResult(result) {
    if (result.d == 0) {
        jQuery().popup({
            IsSuccess: false,
            WarningMessage: "Error de Cierre",
            WarningDesc: "Ha ocurrido un error al realizar el cierre de gestión. Intente nuevamente",
            addTo: "div.contenedor"
        });
    }
    else {
        jQuery().popup({
            IsSuccess: true,
            WarningMessage: "Registro",
            WarningDesc: "Cierre de Gestión Realizada Correctamente",
            addTo: "div.contenedor",
            WarningRegister: result.d

        });
    }

   
    
}