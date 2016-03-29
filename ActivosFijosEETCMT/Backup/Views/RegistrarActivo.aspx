<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarActivo.aspx.cs" Inherits="ActivosFijosEETC.Views.RegistrarActivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="frame">   
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            CODIGO DE ACTIVO:
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
