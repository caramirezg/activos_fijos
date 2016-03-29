<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="BuscarProveedor.aspx.cs" Inherits="ActivosFijosEETC.Views.BuscarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/proveedores.css" rel="stylesheet" type="text/css" />
    <link href="css/Titulos.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="map/jquery-1.4.4.min.js"></script>        
    <script src="http://maps.googleapis.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script type="text/javascript" src="map/gmap3.js"></script> 
    <script src="js/BuscarProveedores.js" type="text/javascript"></script>
<style type="text/css">

    
    .gmap3
        {
            border: 1px dashed #C0C0C0;
            width: 90%;
            height: 600px; 
        }
      .Desc {
          padding: 2px;
      }
      .Desc>h1 {
          font-size: 15px;
          border-bottom: 1px solid #566579;
          color: #2365B0;
      }
      .Desc>h2 {
          font-size: 12px;
          margin-top: 5px;
          padding: 2px 0 2px 25px;
          background: url(img/house.png) no-repeat 0px 0px;
          color: #030405;
          
      }
      .Desc>h3 {
          font-size: 12px;
          padding: 2px 0 2px 25px;
          background: url(img/phone.png) no-repeat 0px 1px;
          color: #030405;
      }
      
      .MarkersContainer {
          border-left: 1px solid #000;
          width: 250px;
          height: 735px;
          background: url(img/transparent.png) repeat;
          z-index: 200;
          left:70%;
          top:8%;
          position:absolute;
    
          
      }
      .MarkersContainer>h1 
      {
          color:#38A7F2;
          font-size: 20px;
          text-align: center;
          
      }
      #markers {
          width: 100%;
          top: 40px;
          overflow: auto;
          position: absolute;
          bottom: 0px;
      }
      #markers>h2 {
          font-size: 13px;
          color:#fff;
          text-decoration: underline;
          font-weight: normal;
          padding-left: 5px;
          cursor: pointer;
          margin: 0px;
         padding: 0px;
         font-family:Century Gothic,arial,sans-serif;
      }
       #markers>h2:hover {
         
          text-decoration: none;
          color:#38A7F2;   
      }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="frame1">
        <h4 class="h4Titulos">
            Buscar Proveedor</h4>
        <hr align="middle" size="1" width="95%" style="color: #BDBDBD; padding-left:20%;" />
        <br />
        <div class="datos">
        
        <div id="test" class="gmap3">
            </div>
            <div class="MarkersContainer">
                <h1>
                    Proveedores
                </h1>
                <div id="markers">
                </div>
            </div>
         </div>   
    
    </div>
</asp:Content>
