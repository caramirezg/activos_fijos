$(function () {
    $(document).bind("contextmenu", function (e) {

        return false;
    });




});

modalConfirmSave

function modalConfirmSave() {
    $('#modalSaveConfirm').modal('show');

}

function modalHide() {
    $('#modalSaveConfirm').modal('hide');

}

function modalEditaCompra() {
    $('#modalEditaCompra').modal('show');
//    document.getElementById('<%=txtEditaId.ClientID %>').innerHTML = id;
//    document.getElementById('<%=txtEditaCodigo.ClientID %>').value = codigo;
//    document.getElementById('<%=txtEditaDescripcion.ClientID %>').value = descripcion;

    //            document.getElementById("vida_util").readOnly = true;
    //            document.getElementById("sigla").readOnly = true;
    //            document.getElementById("porcentaje").readOnly = true;
}

//Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function fechas() {
//    $('#dateInicioGarantia').datepicker({
//        format: 'dd-mm-yyyy'
//    });

//    $('#dateFinGarantia').datepicker({
//        format: 'dd-mm-yyyy'
//    });
//});



$(document).ready(function () {

    $("#txtValorInicial").numeric();
    $("#txtGastosConCreditoFiscal").numeric();
    $("#txtGastosSinCreditoFiscal").numeric();
    $("#txtVidaUtilEspecifica").numeric(false);

    $("#txtEditaCosto").numeric();
    $("#txtEditaGastosConCreditoFiscal").numeric();
    $("#txtEditaGastosSinCreditoFiscal").numeric();
});


//$(function () {

//    $("#txtValorInicial").Decimales();
//    $("#txtGastosConCreditoFiscal").Decimales();
//    $("#txtGastosSinCreditoFiscal").Decimales();
//    $("#txtVidaUtilEspecifica").Enteros();

//    $("#txtEditaCosto").Decimales();
//    $("#txtEditaGastosConCreditoFiscal").Decimales();
//    $("#txtEditaGastosSinCreditoFiscal").Decimales();

//});

//************Carga combos por selected change***************
//$(document).ready(function () {

//    $('#ddlGrupoContable').change(function () {

//        var id = $(this).val();
//        if (id != "" || $('#ddlGrupoContable').val().trim() != '') {
//            DatosAuxiliaresContables(id);
//        }

//    })

//    $('#ddlMarca').change(function () {

//        var id = $(this).val();
//        if (id != "" || $('#ddlMarca').val().trim() != '') {
//            DatosModelos(id);
//        }

//        })

//    CargarDatosGruposContables();
//    DatosMarcas();
//});

//function CargarDatosGruposContables() {

//    //----------------CARGA COMBO GRUPOS CONTABLES--------------------------------
//    $.ajax({
//        url: '../Controllers/ControllerGruposContables.asmx/DatosGruposContables',
//        data: {},
//        type: 'POST',
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        async: false,
//        success: function (result) {
//            $.each(result.d, function () {
//                $('#ddlGrupoContable').append($('<option></option>').val(this.ID).text(this.nombre));
//            });
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert(textStatus + ": " + XMLHttpRequest.responseText);
//        }
//    });


//}
////---------------CARGA AUXILIARES CONTABLES
//function DatosAuxiliaresContables(id) {
//    $('#ddlAuxiliarContable').empty();

//    $.ajax({
//        type: "POST",
//        url: "../Controllers/ControllerAuxiliaresContables.asmx/DatosAuxiliaresContables",
//        data: JSON.stringify({ id: id }),
//        contentType: "application/json; chartset:utf-8",
//        dataType: "json",
//        async: false,
//        success: function (result) {
//            $("#ddlAuxiliarContable").val("seleccione un item");
//            $.each(result.d, function () {
//                $('#ddlAuxiliarContable').append($('<option></option>').val(this.ID).text(this.nombre));
//            });
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert(textStatus + ": " + XMLHttpRequest.responseText);
//        },
//        async: true
//    });
//}


////---------------CARGA MARCAS
//function DatosMarcas() {

//    $.ajax({
//        type: "POST",
//        url: "../Controllers/ControllerMarcas.asmx/DatosMarcas",
//        data: {},
//        contentType: "application/json; chartset:utf-8",
//        dataType: "json",
//        async: false,
//        success: function (result) {
//            $.each(result.d, function () {
//                $('#ddlMarca').append($('<option></option>').val(this.ID).text(this.nombre));
//            });
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert(textStatus + ": " + XMLHttpRequest.responseText);
//        },
//        async: true
//    });
//}

////---------------CARGA MODELOS
//function DatosModelos(id) {
//    $('#ddlModelo').empty();

//    $.ajax({
//        type: "POST",
//        url: "../Controllers/ControllerModelos.asmx/DatosModelos",
//        data: JSON.stringify({ idMarca: id }),
//        contentType: "application/json; chartset:utf-8",
//        dataType: "json",
//        async: false,
//        success: function (result) {
//            $("#ddlModelo").val("seleccione un item");
//            $.each(result.d, function () {
//                $('#ddlModelo').append($('<option></option>').val(this.ID).text(this.nombre));
//            });
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert(textStatus + ": " + XMLHttpRequest.responseText);
//        },
//        async: true
//    });
//}

////------------------------------------------------------------------------------Agregar Item a la Seleccion-------------------
//$(function () {
//    $('#btnAgregar').bind('click', function () {

//        var CodigoActivo = $('#codigoActivo').val();
//        var GrupoContable = $('#grupoContable').val();
//        var SubGrupoContable = $('#subGrupoContable').val();
//        var Marca = $('#marca').val();
//        var Modelo = $('#modelo').val();
//        var Serie = $('#serie').val();
//        var Descripcion = $('#descripcion').val();
//        var FechaRegistro = $('#fechaRegistro').val();
//        var Estado = $('#estado').val();
//        var Costo = $('#costo').val();
//        var UnidadMedida = $('#unidadMedida').val();

//        if (CodigoActivo == "" || GrupoContable == "" || SubGrupoContable == "" || Marca == "" ||
//        Modelo == "" || Serie == "" || Descripcion == "" || FechaRegistro == "" || Estado == "" ||
//        Costo == "" || UnidadMedida == "") {
//            $('#myModal').modal('show');
//        } else {
//            $('#datosActivos tbody').append($('<tr></tr>').append(
//             $('<td></td>').text(CodigoActivo),
//             $('<td></td>').text(GrupoContable),
//             $('<td></td>').text(SubGrupoContable),
//             $('<td></td>').text(Marca),
//             $('<td></td>').text(Modelo),
//             $('<td></td>').text(Serie),
//             $('<td></td>').text(Descripcion),
//             $('<td></td>').text(FechaRegistro),
//             $('<td></td>').text(Estado),
//             $('<td></td>').text(Costo),
//             $('<td></td>').text(UnidadMedida),
//             $('<td></td>').append($('<input class="btn btn-danger btn-sm" type="button" value="Borrar" />'))
//        ));
//   
//        }
//    });

    //-----------------------------------------------------------------------------Borrar de la seleccion-------------------------------------

//    $(document).on("click", "#datosActivos tr td input", function () {
//        $(this).parent('td').parent('tr').remove();
//    });

//      $('#btnFinalizar').bind('click', function () {
//          $('#myModal2').modal('show');
//      });
//});