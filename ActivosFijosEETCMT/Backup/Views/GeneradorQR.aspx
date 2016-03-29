<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true"
    CodeBehind="GeneradorQR.aspx.cs" Inherits="ActivosFijosEETC.Views.GeneradorQR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/TextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/Button.css" rel="stylesheet" type="text/css" />
    <link href="css/GeneradorQR.css" rel="stylesheet" type="text/css" />
    <div class="frame">
        <table style="width: 100%;">
            <tr>
                <td align="middle">
                   <h4 style="font-size:30px;">Generador de código QR</h4>
                </br>
                </td>
            </tr>
            <tr>
                <td align="middle">
                    <asp:Image ID="QRImage" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="middle">
                    <asp:TextBox ID="txtURL" CssClass="textBoxStyle1" runat="server" placeholder="Código a generar"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="middle">
                    <asp:Button ID="btnGenerarCodigo" runat="server" Text="Generar QR" CssClass="button" 
                        OnClick="btnGenerarCodigo_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
