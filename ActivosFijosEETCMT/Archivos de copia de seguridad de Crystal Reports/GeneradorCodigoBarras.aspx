<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="GeneradorCodigoBarras.aspx.cs" Inherits="ActivosFijosEETC.Views.GeneradorCodigoBarras" %>
<%@ Register assembly="BusinessRefinery.Barcode.Web" namespace="BusinessRefinery.Barcode.Web" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <link href="css/TextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/Button.css" rel="stylesheet" type="text/css" />
     <link href="css/GeneradorQR.css" rel="stylesheet" type="text/css" />
    <div class="frame">   
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <td align="middle">
                    <h4 style="font-size:30px;">Generador de código de barra</h4>
                    </br>
                </td>
            </tr>
            <tr>
                <td align="middle">
                     <asp:Image ID="Image2" runat="server" Height="200px" Width="500px" />
                </td>
            </tr>
            <tr>
                <td align="middle">
                <asp:TextBox ID="txtURL" runat="server" CssClass="textBoxStyle1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="middle">
            <asp:Button ID="btnGenerarCodigoBarras" runat="server" 
            onclick="btnGenerarCodigoBarras_Click" Text="Button" CssClass="button" />
                </td>
            </tr>
        </table>
        
        
       
    </div> 
</asp:Content>
