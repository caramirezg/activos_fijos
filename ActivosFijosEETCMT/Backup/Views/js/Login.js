$(function () {
    $(document).bind("contextmenu", function (e) {
        

        return false;
    });
});
//-------------------------------------------------------------------------------
$(document).ready(function() {

    NuevaDimension();

    $(window).resize(function() { //Cada que cambie de tama�o la ventana
        NuevaDimension();
    });

});
function NuevaDimension() {
    var WindowHeight = $(window).height();
    var WindowsWidth = $(window).width();
    $("img.BackGround").css({ "width": WindowsWidth, "height": WindowHeight });
}

//---------------------------------------Intercalar Formularios de Registro y Logueo---------
$(function () {
    var $Back = $('.Back');
    var $ActualLog = $('.active');
    var $link = $ActualLog.find('.linkForm');
    var width, height, target;


    $Back.children('div').each(function (i) {
        var $theForm = $(this);

        if (!$theForm.hasClass('active'))
            $theForm.hide();
        $theForm.data({
            width: $theForm.width(),
            height: $theForm.height()
        });
    });

    resize();

    $link.bind('click', function (e) {

        target = $link.attr('rel');
        $ActualLog = $('div.Log1');
        $ActualLog.fadeOut(400, function () {

            $ActualLog.removeClass('active');
            $ActualLog = $ActualLog.parent('.Back').children('div.' + target);

            $Back.stop().animate({
                width: $ActualLog.data('width') + 'px',
                height: $ActualLog.data('height') + 'px'


            }, 500, function () {

                $ActualLog.addClass('active');
                $ActualLog.fadeIn(400);
            });
        });
        e.preventDefault();
    });

    $('.linkForm2').click(function () {

        $ActualLog = $('.Log2');
        $ActualLog.fadeOut(400, function () {
            $ActualLog = $ActualLog.parent('.Back').children('div.Log1');

            $Back.stop().animate({
                width: $ActualLog.data('width') + 'px',
                height: $ActualLog.data('height') + 'px'
            }, 500, function () {
                $ActualLog.fadeIn(400);
            });
        });
    });


    function resize() {

        height = $ActualLog.height();
        width = $ActualLog.width();
        $Back.css({ "width": width, "height": height });
    }
});

//-------------------CLIC INGRESAR AL SISTEMA---------
$(function () {
    $('#Ingreso').click(function () {
        loguin();
    });
    $(document).keypress(function (e) {
        if (e.keyCode == 13) {
            loguin();
        }
    });

    function loguin() {

        var UserDatos = new Object();
        UserDatos.User = $('#user').val();
        UserDatos.Pass = $('#pass').val();
        UserDatos = JSON.stringify(UserDatos);

        $.ajax({
            type: "POST",
            url: "../Controllers/ControllerLogin.asmx/Autentificacion",
            data: UserDatos,
            contentType: "application/json; chartset:utf-8",
            dataType: "json",
            async: false,
            success: logueo,

            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            },
            async: true
        });
    }

    function logueo(result) {

        if (result.d == "0x0") {
        document.getElementById('PassError').style.display = 'block';
        }
        else
            window.location = result.d;
    }

    $.fn.parpadear = function () {
        this.each(function parpadear() {

            for (var i = 0; i <= 2; i++) {
                $(this).animate({ opacity: 9 }, 600).delay(400).animate({ opacity: 0.01 }, 600);
            }
            $(this).animate({ opacity: 0.01 }, 600);
        });
    };
});

