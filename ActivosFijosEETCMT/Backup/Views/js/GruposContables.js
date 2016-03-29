$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });

});

$(function () {
    $('#btnNuevo').bind('click', function () {
        LimpiaControles();
        document.getElementById("txtCodigoGrupo").readOnly = false;
        document.getElementById("porcentaje").readOnly = true;
        document.getElementById("vida_util").readOnly = false;
        document.getElementById("sigla").readOnly = false;
        document.getElementById('lblTitleModal').innerHTML = 'Registrar Grupo Contable';
        $('#modalDatosGrupoContable').modal('show');
    });
});



function modalEditar() {
    document.getElementById("txtCodigoGrupo").readOnly = true;
    document.getElementById('lblTitleModal').innerHTML = 'Editar Grupo Contable';
    $('#modalDatosGrupoContable').modal('show');
    document.getElementById("vida_util").readOnly = true;
    document.getElementById("sigla").readOnly = true;
    document.getElementById("porcentaje").readOnly = true;
 }



 $(function () {
     $("#vida_util").Enteros();
     $("#porcentaje").Decimales();

 });

 function modalHide() {
     $('#modalDatosGrupoContable').modal('hide');
     $('body').removeClass('modal-open');
     $('.modal-backdrop').remove();
     return false;
 }


//$(function () {

//    $.ajax({
//        type: 'POST',
//        url: '../Controllers/ControllerGruposContables.asmx/DatosGruposContables',
//        data: {},
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',

//        success: loadItems,
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert(textStatus + ": " + XMLHttpRequest.responseText);
//        }

//    });

//    function loadItems(result) {

//        var source =
//            {
//                datatype: "json",
//                datafields: [
//                    { name: 'ID', type: 'string' },
//                    { name: 'nombre', type: 'string' },
//                    { name: 'descripcion', type: 'string' },
//                    { name: 'vida_util', type: 'string' },
//                    { name: 'porcentaje_depreciacion', type: 'string' },
//                    { name: 'sigla', type: 'string' }
//                ],
//                localdata: result.d
//            };

//            var dataAdapter = new $.jqx.dataAdapter(source);

//            $("#jqxgrid").jqxGrid(
//            {
//                width: 850,
//              
//                source: dataAdapter,
//                showfilterrow: true,
//                altRows:true,
//                filterable: true,
//                selectionmode: 'multiplecellsextended',
//                columns: [
//                    { text: 'id', columntype: 'textbox', filtertype: 'textbox', datafield: 'ID', width: 250 },
//                    { text: 'nombre', columntype: 'textbox', filtertype: 'textbox', datafield: 'nombre', width: 150 },
//                    { text: 'descripcion', columntype: 'textbox', filtertype: 'textbox', datafield: 'descripcion', width: 150 },
//                    { text: 'vida_util', columntype: 'textbox', filtertype: 'textbox', datafield: 'vida_util', width: 150 },
//                    { text: 'porcentaje_depreciacion', columntype: 'textbox', filtertype: 'textbox', datafield: 'porcentaje_depreciacion', width: 150 },
//                    { text: 'sigla', columntype: 'textbox', filtertype: 'textbox', datafield: 'sigla', width: 150 }

//                ]
//            });
//    }
//});
$(function () {

//    $('#btnGuardarGrupoContable').bind('click', function () {

//        var nombre = $('#nombre').val();
//        var descripcion = $('#descripcion').val();
//        var vida_util = $('#vida_util').val();
//        var sigla = $('#sigla').val();
//        var porcentaje = $('#porcentaje').val();


//        if (nombre == "" || descripcion == "" || vida_util == "" || sigla == "" || porcentaje == "") {
//            $('#confirm').text('IMPOSIBLE CONTINUAR, POR FAVOR REVISE LOS CAMPOS').fadeIn(800).delay(2000).fadeOut(800).css({ color: '#f00' });
//            return false;
//        } else {
//            var result = EnviaDatosGrupoContable(nombre, descripcion, vida_util, sigla, porcentaje);

//            if (result > 0) {
//                //CargarDatos();
//                $('#confirm').text('ITEM: ' + result + ' CREADO CORRETAMENTE').fadeIn(500).css({ color: '#2A91FF' });
//                CargarGrid();
////                LimpiaControles();

//                //var EmptyInputs = $("input[type=text]:[value='']").length; -> Encontrar por valor
//            }
//            else {
//                $('#confirm').text('Lo sentimos Ha ocurrido un error.').fadeIn(500);
//            }
//        }


//    });
});

function EnviaDatosGrupoContable(nombre, descripcion, vida_util, sigla, porcentaje) {
    var resultado = 0;
    $.ajax({
        url: '../Controllers/ControllerGruposContables.asmx/CreaGrupoContable',
        data: JSON.stringify({ nombre: nombre, descripcion: descripcion, vida_util: vida_util, sigla: sigla, porcentaje: porcentaje }),
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (result) {
            resultado = result.d;
          
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
    return resultado;
}

function LimpiaControles() {

    var textos = $('input[type=text], input[type=password], select');

    $(textos).each(function () {
        $(this).val('');
    })
}

function CargarGrid() { 
    $.ajax({
                    type: "POST",
                    url: "GruposContables.aspx/cargaGrilla",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: {},
                    success: function () {
                       
                    },
                    error: function () {
                       
                    }
                });
}

