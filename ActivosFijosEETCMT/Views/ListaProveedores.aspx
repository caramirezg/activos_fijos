<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaProveedores.aspx.cs" Inherits="ActivosFijosEETC.Views.ListaProveedores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="jqwidget/jqwidgets/styles/jqx.base.css" type="text/css" />
      <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
  <%--    <script type="text/javascript" src="jqwidget/scripts/jquery-1.10.2.min.js"></script>--%>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxmenu.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxgrid.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxgrid.filter.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxgrid.sort.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxgrid.selection.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxpanel.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxcalendar.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxdatetimeinput.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/jqxcheckbox.js"></script>
    <script type="text/javascript" src="jqwidget/jqwidgets/globalization/globalize.js"></script>
    <script type="text/javascript" src="jqwidget/scripts/demos.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "../Controllers/ControllerProveedor.asmx/DatosProveedores",
                data: {},
                contentType: "application/json; chartset:utf-8",
                dataType: "json",
                async: false,
                success: loadItems,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                },
                async: true
            });

            function loadItems(result) {

                var source =
            {
                datatype: "json",
                datafields: [
                    { name: 'ID', type: 'string' },
                    { name: 'nombre', type: 'string' }
                 
                ],
                localdata: result.d
            };
            var dataAdapter = new $.jqx.dataAdapter(source);

            $("#jqxgrid").jqxGrid(
            {
                width: 850,
                source: dataAdapter,
                showfilterrow: true,
                filterable: true,
                selectionmode: 'multiplecellsextended',
                columns: [
                    { text: 'id', columntype: 'textbox', filtertype: 'textbox', datafield: 'ID', width: 250 },
                    { text: 'nombre', columntype: 'textbox', filtertype: 'textbox', datafield: 'nombre', width: 150 }
                   
                ]
            });

            }
           
            
        });
    </script>
</head>
<body class='default'>
   <div id='jqxWidget'>
        <div id="jqxgrid"></div>
    </div>
</body>
</html>
