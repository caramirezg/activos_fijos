<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pruebas.aspx.cs" Inherits="ActivosFijosEETC.Views.pruebas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
      <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <link href="bootstrap/datepicker/css/datepicker.css" rel="stylesheet" type="text/css" />
     <script src="bootstrap/js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
     <script src="bootstrap/js/plugins/datepicker/bootstrap-datepicker.js" type="text/javascript"></script>
      <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        document.write('<script src="js/Compras.js" type="text/javascript"><\/script>');   
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <input id="dateFechaRegistro" type="text" name="dateFechaRegistro" value="" class="form-control"
                                            placeholder="ejemplo: 01/01/2014" />
    </div>
    </form>
</body>

</html>
