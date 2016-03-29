$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });

 
});
//------------------------------------------------------------------Cargando Tabla--------------------------
$(function () {

    CargarDataTables();

    $('li#print').click(function () { //Imprimir Todos los Ingresos Seleccionados.
        window.location = 'Reports/ReporteProveedor.aspx';
    });

});

//----------------------------------------------------------------Funcion Explicta Cargar Ingresos por Fecha--

function CargarDataTables() {
       $.ajax({
            type: "POST",
            url: "../Controllers/Service_Administracion.asmx/DatosProveedores",
            data: {},
            contentType: "application/json; chartset:utf-8",
            dataType: "json",
            async: false,
            success: function (result) 
            {
                renderTable(result.d);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            },
            async: true
        });

        function renderTable(result) {
        var dtData = [];
        var num = 1;
        var lengthVar;

             $.each(result, function () {
            dtData.push({
                "0": num++,
                "1": this.nombre,
                "2": this.direccion,
                "3": this.telefono,
                "4": this.celular,
                "5": this.nit,
                "6": '',
                "DT_RowClass": "gradeX"
            });
        });


        $('#Answers').dataTable({
            "aaData": dtData,
            "sScrollY": ($(window).height() - 134),
            "bJQueryUI": true,
            "sPaginationType": "full_numbers",
            "iDisplayLength": 50
        });
    }
}



