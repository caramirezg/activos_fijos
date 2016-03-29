//-----------------------------Manteniendo Session Activa------------------------------

$(function () {

    $(document).everyTime(500000, function () {

        $.ajax({
            type: "POST",
            url: "../Controllers/ControllerMenu.asmx/SesionActiva",
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: {},
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    });
});

//---------------------------Llamado de datos usuario----------------

$(function () {
    $.ajax({

        type: "POST",
        url: "../Controllers/ControllerMenu.asmx/DatosUsuario",
        data: "{}",
        contentType: "application/json; chartset:utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            var nivel;
            $.each(result.d, function () {
                $('#tip').find('td#Nombre').html("").append(this.nombre + " " + this.apellido);
                $('#tip').find('td#Cargo').html("").append(this.cargo);
                $('#tip').find('td#Area').html("").append(this.area);
                nivel = this.nivel;
            });
            switch (nivel) {
                case 1: $('.tab_item').show();
                    break;
                case 2: $('.tab_item:nth-child(5), .tab_item:nth-child(6)').show();
                    break;
            }
        },

        error: function (XMLHttpRequest, textStatus, errorThrown) {
            window.location = ('login.aspx');
        },
        async: true
    });
});
//-----------------------------Cerrando Session------------------------------------
function CierraSesion(){
    $.ajax({

        type: "POST",
        url: "../Controllers/ControllerMenu.asmx/CierraSesion",
        data: "{}",
        contentType: "application/json; chartset:utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            if (result.d) {
                window.location = 'login.aspx';
            }
        },

        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        },
        async: true
    });
       

}

//----------------------------------Menu iframe----------------------------------------------------
$(document).ready(function () {

    $(document).bind("contextmenu", function (e) {
        return false;
    });

    /*
    * VARIABLES GLOBALES
    */
    //status de panel lateral: 1 ON (default), 0 OFF
    var status = 1;
    //selectores
    var top = $("#top");
    var iframe = $("#iframe");
    var tip = $("#tip");
    var title = $("#content h2");
    var toggler = $("#toggler");
    var lateral = $("#lateral");
    var content = $("#content");
    var lateralWidth = lateral.width() + "px";
    //dimensiones disponibles para elementos del panel
    var windowHeight = 0;
    var renderHeight = 0;
    var togglerHeight = 0;


    /*
    * AL CARGAR EL DOCUMENTO
    */
    calculateDimensions();
    applyDimensions();

    /*
    * AL CAMBIAR DE TAMAÑO LA VENTANA DEL NAVEGADOR
    */
    $(window).resize(function () {
        calculateDimensions();
        applyDimensions();
    });


    /*
    * AL HACER CLICK EN TOGGLER (PANEL LATERAL)
    */
    toggler.click(clickToggler);
    /*
    * AL SELECCIONAR UNO DE LOS ITEMS DEL LISTADO LATERAL
    */
    $("#lateral li").click(loadItem);
    $(".tabslider li").click(loadItem);
    // $("#lateral input").hover(buttoms);
    /*
    * FUNCIONES DE CONTROL DE ELEMENTOS DE INTERFAZ
    */
    // calculo de dimensiones disponibles
    function calculateDimensions() {
        windowHeight = document.documentElement.clientHeight; //alto disponible en ventana del explorador
        renderHeight = (windowHeight - 84 - 26 - 26) + "px";
        togglerHeight = (windowHeight - 84 - 26 - 26) + "px";

    }
    // aplicado de dimensiones disponibles
    function applyDimensions() {
       content.css("height", renderHeight);
        toggler.css("height", togglerHeight);
    }
    // control de elemento lateral (toggler)
    function clickToggler() {
        //ocultamos panel si esta mostrandose
        if (status == 1) {
            lateral.hide(500);
            content.animate({ marginLeft: 0 }, 500, function () { toggler.addClass("off") });   //ò        content.css("margin-left","0px");
            status = 0;
        }
        //mostramos panel si esta oculto
        else {
            lateral.show(500);
            content.animate({ marginLeft: lateralWidth }, 500, function () { toggler.removeClass("off"); });  //ò         content.css("margin-left", lateralWidth);

            status = 1;
        }
    }
    //control de items a cargar en listado lateral
    function loadItem(e) {
        //mostramos iframe y ocultamos consejo (tip)
        if ($(e.currentTarget).attr('id') == 'SALIR') {
            CierraSesion();
           }

        else if ($(e.currentTarget).attr('id') == 'INICIO') {
            location.reload();
        }
        else {

            iframe.css("display", "block");
            tip.css("display", "none");
            iframe.attr("src", $(e.currentTarget).attr('id') + '.aspx');
            title.html("<label width='200px'>" + $(e.currentTarget).text() + "</label>");
            
        }
        return false;
    }
});

/* .-----------------------Seccion Menu de la cabezera--------------------------*/

var TabbedContent = {
    init: function () {
    
        $(".tab_item").click(function() {    //  EFECTO SLIDE DE LOS ICONOS CLICK o MOUSEOVER

            var background = $(this).parent().find(".moving_bg");
            var child = $(this).children('img');


            $(background).stop().animate({
                left: $(this).position()['left']
            }, {
                duration: 300
            });
            TabbedContent.slideContent($(this));

        });
    },

    slideContent: function(obj) {

        var margin = $(obj).parent().parent().find(".slide_content").width();
        margin = margin * ($(obj).prevAll().size() - 1);
        margin = margin * -1;

        $(obj).parent().parent().find(".tabslider").stop().animate({
            marginLeft: margin + "px"
        }, {
            duration: 300
        });
    }
}

function CalculateDimentions() {
    var windowWidth;
    windowWidth = document.documentElement.clientWidth;
    $('.tabslider ul').css("width", (windowWidth) + 'px');
}
$(document).ready(function() {
    TabbedContent.init();
    CalculateDimentions();
    animation();
});
$(window).resize(function() {
    CalculateDimentions();
});





 
    
  