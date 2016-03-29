$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });

    var padd = 0;
    var max = 0;
    $("div.master span").each(function () {
        if ($(this).width() > max) {
            max = $(this).width();
        }
    });
    $("div.master span").each(function () {
        $(this).css("padding-left", (max - $(this).width() + 5))
    });

    var a;
    $(a).LimpiaControles();
});
//------------------------------------------------------------------Ultimo Ingreso Realizado-----
$(function () {
    $.ajax({
        type: "POST",
        url: "../Controllers/Service_Ingreso.asmx/UltimoIngreso",
        data: {},
        contentType: "application/json; chartset:utf-8",
        dataType: "json",
        async: false,
        success: loadOptions,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        },
        async: true
    });
    function loadOptions(result) {
        $('#Num').html("");
        $('#Num').text(result.d);
    }
});
//------------------------------------------------------------------CargandoPlugins para los Textos------
$(function () {
    $("#Cantidad").Enteros();
    $("#Factura").Enteros();
    $("#Importe").Decimales();
    $("#Fecha").mask("99/99/9999");
    $('#Fecha').datepicker({
        changeMonth: true,
        changeYear: true
        
    }).datepicker( "option", "showAnim", "drop" );
});
//-------------------------------------------------------------------Autocomplete Item-------------------

$(function () 
{

    $.ui.autocomplete.prototype._renderItem = function (ul, item) {  //para el highlight del texto 
        var term = this.term.split(' ').join('|');
        var re = new RegExp("(" + term + ")", "gi");
        var t = item.label.replace(re, "<strong>$1</strong>");
        return $("<li></li>")
     .data("item.autocomplete", item)
     .append("<a>" + t + "</a>")
     .appendTo(ul);
    };



    var IDItem = 0;
    var Unidad = '';
    var Desc = '';
    $("#Item").autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "../Controllers/Service_Ingreso.asmx/DatosItemAutocomplete",
                data: JSON.stringify({ prefix: request.term }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            label: item.desc,
                            numero: item.numero,
                            unidad: item.unidad
                        }
                    }))
                },
                error: function(response) {
                    alert(response.responseText);
                },
                failure: function(response) {
                    alert(response.responseText);
                }
            });
        },

        select: function(e, i) {
            IDItem = i.item.numero;
            Unidad = i.item.unidad;
            Desc = i.item.label;

        },
        minLength: 1


    });
       
    //------------------------------------------------------------------------------Agregar Item a la Seleccion-------------------
    $("#Agregar").click(function () {
        var existe = 0;
        var Cantidad = $('#Cantidad').val();
        var Importe = $('#Importe').val();
        var id = $('#tbody tr td:first').text();

        if (Cantidad == "" || Importe == "" || IDItem == 0) {
            alert('Datos Faltantes');
        }
        else {

            $('#tbody tr').each(function () {
                var idCampo = $(this).children('td:first').text();
                if (idCampo == IDItem) {
                    var sumCanti = parseInt($(this).children('td:nth-child(4)').text()) + parseInt(Cantidad)
                    var sumImporte = parseFloat($(this).children('td:nth-child(6)').text()) + parseFloat(Importe)
                    $(this).children('td:nth-child(4)').text(sumCanti);
                    $(this).children('td:nth-child(6)').text(Math.round((sumImporte) * Math.pow(10, 2)) / Math.pow(10, 2));
                    $(this).children('td:nth-child(5)').text(Math.round((sumImporte / sumCanti) * Math.pow(10, 2)) / Math.pow(10, 2));
                    $(this).highlight();
                    CalculaTotales();
                    existe = 1;
                }
            });

            if (existe == 0) {
                $("#tbody").append($('<tr></tr>').append(
                    $('<td></td>').text(IDItem),
                    $('<td></td>').text(Desc),
                    $('<td></td>').text(Unidad),
                    $('<td></td>').text(Cantidad),
                    $('<td></td>').text(Math.round((Importe / Cantidad) * Math.pow(10, 2)) / Math.pow(10, 2)),
                    $('<td></td>').text(Importe),
                    $('<td></td>').append($('<input type="button" value="Borrar" />'))
                ));
                $('#tbody tr:last').highlight();
            }
            CalculaTotales();
            $('#Cantidad').val('');
            $('#Importe').val('');
            $('#Item').val('');
        }
    });
    //-----------------------------------------------------------------------------Borrar de la seleccion-------------------------------------
    $("#tbody tr td input").live("click", function () {

        $(this).parent('td').parent('tr').remove();
        CalculaTotales();
    });


    function CalculaTotales() {

        var TtlRegistros = 0;
        var TtlCantidad = 0;
        var TtlImporte = 0;

        $("#tbody tr").each(function () {
            TtlCantidad = TtlCantidad + parseInt($(this).children('td:nth-child(4)').text());
            TtlImporte = TtlImporte + parseFloat($(this).children('td:nth-child(6)').text());
        });
        TtlImporte = Math.round((TtlImporte) * Math.pow(10, 2)) / Math.pow(10, 2);

        $('em#TtlCantidad').text(TtlCantidad);
        $('em#TtlImporte').text(TtlImporte);
        $('em#TtlRegistros').text(($("#tbody tr").length));
    }


});

  //------------------------Autocomoplete Proveedor-----------------------------------------------

$(function () {

//    var IDProveedor = 0;
//    $("#Proveedor").autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                url: "../Controllers/Service_Ingreso.asmx/DatosProveedorAutocomplete",
//                data: JSON.stringify({ prefix: request.term }),
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                success: function (data) {
//                    response($.map(data.d, function (item) {
//                        return {
//                            label: item.nombre,
//                            Id: item.ID
//                        }
//                    }))
//                },
//                error: function (response) {
//                    alert(response.responseText);
//                },
//                failure: function (response) {
//                    alert(response.responseText);
//                }
//            });
//        },
//        select: function (e, i) {
//            IDProveedor = i.item.Id;
//        },
//        minLength: 2
//    });

    //----------------------------------------------------------Registrar Ingreso--------------------------------
    $('#Finalizar').click(function () {
        //        var proveedor = IDProveedor;
        var proveedor = $('#Proveedor').val();
        var factura = $('#Factura').val();
        var fecha = $('#Fecha').val();

        if (proveedor == "" || factura == "" || $('table#tbody tr').length == 0)
            alert("Datos Faltantes");
        else
            RegistroIngreso(proveedor, factura, fecha)
    });
    function RegistroIngreso(proveedor, factura, fecha) {
        var data = new Array();
        var n = 0;

        $('table#tbody tr').each(function () { //-------------cargando array para enviar al webmethod

            data[n] = new Object();
            data[n].item = $(this).children('td:nth-child(1)').text();
            data[n].cantidad = $(this).children('td:nth-child(4)').text();
            data[n].importe = $(this).children('td:nth-child(6)').text();
            n++;
        });

        $.ajax({
            type: "POST",
            url: "../Controllers/Service_Ingreso.asmx/CreaIngreso",
            //            data: "{'Datos':" + JSON.stringify(data) + ", 'IDProveedor':" + JSON.stringify(proveedor) + ", 'Factura':" + JSON.stringify(factura) + ", 'Fecha':" + JSON.stringify(fecha) + "}",
            data: "{'Datos':" + JSON.stringify(data) + ", 'IDProveedor':" + JSON.stringify(proveedor) + ", 'Factura':" + JSON.stringify(factura) + ", 'Fecha':" + JSON.stringify(fecha) + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: cargado,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
    function cargado(result) {
        if (result.d == 0) {
            jQuery().popup({
                IsSuccess: false,
                WarningMessage: "Error de Registro",
                WarningDesc: "Ha ocurrido un error. Intente nuevamente",
                addTo: "body"
            });

            //$('#sucess').sucess("error");  TERMINAR ALERTA DE DATOS ENVIADOS CORRECTAMENTE-----------------
        }
        else {
            jQuery().popup({
                IsSuccess: true,
                WarningMessage: "Ingreso",
                WarningDesc: "Ingreso Registrado Correctamente",
                addTo: "body",
                WarningRegister: result.d
            });

            var aux;
            $(aux).LimpiaControles();
            $('#Num').html("");
            $('#Num').text(result.d + 1);
        }
    }


});

$.fn.LimpiaControles = function () {

    $('table#tbody').html("");
    $('#Factura').val("");
    $('#Fecha').val("");
    $('#Proveedor').val("");
    $('em#TtlCantidad').text("");
    $('em#TtlImporte').text("");
    $('em#TtlRegistros').text(($("#tbody tr").length));   
}


$.fn.highlight = function () {

    this.each(function highlight() {

        $(this).css({ backgroundColor: "#FFFED6" }).stop().animate({ backgroundColor: "#EEEEEE" }, 1700, function () {
            $(this).animate({ backgroundColor: "#EEEEEE" }, 1);
        });
    });
}




//codigo nuevo

$(function CargarDatos() {

    //----------------CARGANDO CATEGORIAS--------------------------------
    $.ajax({
        url: '../Controllers/Service_Administracion.asmx/DatosProveedores',
        data: {},
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (result) {
            $.each(result.d, function () {
                $('#Proveedor').append($('<option></option>').val(this.ID).text(this.nombre));
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
///

})