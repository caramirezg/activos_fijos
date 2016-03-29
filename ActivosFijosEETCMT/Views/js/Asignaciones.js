$(document).ready(function () {

    $(document).bind("contextmenu", function (e) {
        return false;
    });

//    initialDisplay();


//    $('#dateFechaAsignacion').datepicker({
//        format: 'dd-mm-yyyy'
//    });

    $('#dateFechaAsignacion').datepicker({
        format: 'dd-mm-yyyy',
        clearBtn: true,
        language: "es",
        calendarWeeks: true,
        autoclose: true,
        todayHighlight: true
    });

});

//function initialDisplay() {
//    document.getElementById('linea').style.display = 'none';
//    document.getElementById('estacion').style.display = 'none';
//}