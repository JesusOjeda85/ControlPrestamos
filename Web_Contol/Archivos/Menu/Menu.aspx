<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ControlDescuentos.Archivos.Menu.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
     <meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css"/>    
     <link href="../../tailwinds/static/dist/tailwind.css" rel="stylesheet" />
     <script type="text/javascript" src="../../scripts/jquery-1.11.1.min.js"></script>
     <script type="text/javascript" src="../../scripts/demos.js"></script>
    
    <link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/metro-red/easyui.css"/>	
    <link href="../../jqueryEsy/themes/icons.css" rel="stylesheet" />

     <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
     <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>
    <script src="Menu.js"></script>
</head>
<body>    
     <div class="w-screen h-screen flex flex-col">
         <div class="h-12 border-2 bg-red-800 rounded flex flex-row">
             <div class="w-1/2">
                  <asp:Image ID="Image2" runat="server" Height="100%" ImageUrl="~/IMAGENES/LETRAGRAMA.png" Width="300px" />
             </div>
             <div class="w-1/2" align="right" style="padding:4px;">                 
                <asp:Label id="lblusuario" class="text-lg font-semibold text-white"  runat="server" Text=""></asp:Label>                
             </div>
         </div>
         <div class="easyui-panel rounded" style="width:100%;  padding:2px;">            
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Sal32'" style="width:80px;"  id="btnInicio">Cerrar</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Cap32'" style="width:80px;"  id="btnCaptura">Captura</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Con32'" style="width:80px;"  id="btnConsultas">Consultas</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Rep32'" style="width:80px;"  id="btnReportes">Reportes</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Cat32'" style="width:80px;"  id="btnCatalogos">Catálogos</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Usu32'" style="width:80px;"  id="btnUsuarios">Usuarios</a>    
         </div>
         <div class="h-full border-2 border-red-200 bg-orange-50 rounded">
              <div id="tt" class="easyui-tabs" style="width: 100%;  height:100%; display:none;"></div>  
         </div>            
     </div>    
</body>
</html>
