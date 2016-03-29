$(document).ready(function () {
    //    CargarAreas();
    CargarCargos();
    CargarGerencias();
    $(document).bind("contextmenu", function (e) {

        return false;
    });
});

//************************carga combo gerencias**********************************

function CargarGerencias() {

    $.ajax({
        type: "POST",
        url: "../Controllers/ControllerAdministracion.asmx/DatosGerencias",
        data: {},
        contentType: "application/json; chartset:utf-8",
        dataType: "json",
        success: loadItems,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });

    function loadItems(result) {

        $.each(result.d, function () {
            $('#gerencia').append($("<option></option>").attr("value", this.ID).text(this.nombre));
        });

    }
}

//************************carga combo areas**********************************

//function CargarAreas() {

//    $.ajax({
//        type: "POST",
//        url: "../Controllers/ControllerAdministracion.asmx/DatosArea",
//        data: {},
//        contentType: "application/json; chartset:utf-8",
//        dataType: "json",
//        success: loadItems,
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert(textStatus + ": " + XMLHttpRequest.responseText);
//        }
//    });

//    function loadItems(result) {

//        $.each(result.d, function () {
//            $('#area').append($("<option></option>").attr("value", this.ID).text(this.nombre));
//        });
//       
//    }
//}

//************************carga combo cargos**********************************

function CargarCargos() {

    $.ajax({
        type: "POST",
        url: "../Controllers/ControllerCargos.asmx/DatosCargo",
        data: {},
        contentType: "application/json; chartset:utf-8",
        dataType: "json",
        success: loadItems,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });

    function loadItems(result) {

        $.each(result.d, function () {
            $('#cargo').append($("<option></option>").attr("value", this.ID).text(this.nombre));
        });
       
    }
}


//*********************LLENA DATOS DE UN USUARIO**************************
$(function () {
    CargarDatosUsuario();
});


function CargarDatosUsuario() {
    $.ajax({

        type: "POST",
        url: "../Controllers/ControllerAdministracion.asmx/DatosUsuarioPorSession",
        data: "{}",
        contentType: "application/json; chartset:utf-8",
        dataType: "json",
        async: true,
        success: function (result) {
            $.each(result.d, function () {

                var area = this.IDarea;
                var cargo = this.IDcargo;

                $("select#Town").val("4006");

                //                $('#cargo').val(this.IDcargo);
                $('#area').val("").val(this.IDarea);

                $("select#cargo").val(cargo);

                $('input#usuario').val("").val(this.usuario);
                $('input#nombre').val("").val(this.nombre);
                $('input#apellido').val("").val(this.apellido);

                //                $('#area option:[value=' + result.d[0].IDarea + ']').attr("selected", "selected");
                //                $('#cargo option:[value=' + result.d[0].IDcargo + ']').attr("selected", "selected");
                $('input#perfil').val("").val(this.perfil);
                if (this.estado == 1) {
                    $('input#estado').val("").val("Activo");
                } else {
                    $('input#estado').val("").val("No Activo")
                }

            });
        },

        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        },
        async: true
    });
}

//****************Actualiza datos*********************
$(function () {

    $('#guardarDatosUsuario').click(function () {

        var nombre = $('#nombre').val();
        var apellido = $('#apellido').val();
        var IDarea = $('#area').val();
        var IDcargo = $('#cargo').val();

        if (nombre == null || nombre == "" || apellido == null || apellido == "" || IDarea == null || IDarea == "" || IDcargo == null || IDcargo == "") {
            $('#dangerDatos').text('Imposible continuar, por favor revise los campos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
            return false;
        } else {
            $.ajax({

                type: "POST",
                url: "../Controllers/ControllerAdministracion.asmx/ActualizaUsuario",
                data: JSON.stringify({ nombre: nombre, apellido: apellido, IDarea: IDarea, IDcargo: IDcargo }),
                contentType: "application/json; chartset:utf-8",
                dataType: "json",
                success: function resultado(result) {

                    if (result.d == 1) {
//                        CargarDatosUsuario();
                        $('#successDatos').text('Datos guardados correctamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
                    }
                    else {
                        $('#errorDatos').text('Lo sentimos Ha ocurrido un error.').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                }

            });
        }

    });

    //**************Confirmar Password******************

    $('#confirm').focusout(function () {
        if ($(this).val() != $('#claveNueva').val())
            $('em#paswords').text("La confirmación de contraseña no coincide con la nueva contraseña").parpadear();
    });

    //*************Guarda los datos de contraseña**************
    $('#GuardarPass').click(function () {
        var pass = $('#claveNueva').val();
        var passActual = $('#claveActual').val();
        var confirm = $('#confirm').val();

        if (pass == null || pass == "" || passActual == null || passActual == "" || confirm == null || confirm == "") {
            $('#dangerPass').text('Imposible continuar, por favor revise los campos').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
            return false;
        } else {
            if (pass == confirm) {
                $.ajax({

                    type: "POST",
                    url: "../Controllers/ControllerAdministracion.asmx/ActualizaPassword",
                    data: JSON.stringify({ password: pass, passwordActual: passActual }),
                    contentType: "application/json; chartset:utf-8",
                    dataType: "json",
                    success: function resultado(result) {

                        if (result.d == 1) {
                            $('#successPass').text('Datos guardados correctamente').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
                            $('#password, #confirmpass').val("");
                        }
                        else {
                            $('#errorPass').text('Password no Guardado verifique su contraseña actual').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
                           
                        }
                    },

                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                });

            }
            else {
                $('#errorPass').text('Las contraseñas no concuerdan').fadeIn(800).delay(4000).fadeOut(800).css({ display: inline });
            }
        }
    });
});

//-----------------------------PARPADEO------------------------------------
$.fn.parpadear = function () {

    this.each(function parpadear() {

        for (var i = 0; i <= 0; i++) {
            $(this).animate({ opacity: 9 }, 400).delay(4000).animate({ opacity: 0.01 }, 400).css({ color: '#1F5C9E' });
        }
        $(this).animate({ opacity: 0.01 }, 400).css({ color: '#1F5C9E' });

    });
}

