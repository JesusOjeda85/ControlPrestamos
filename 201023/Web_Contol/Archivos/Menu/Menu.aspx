﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ControlDescuentos.Archivos.Menu.Menu" %>

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
    <link href="../../Styles/Login.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/metro-red/easyui.css"/>	
    <link href="../../jqueryEsy/themes/icons.css" rel="stylesheet" />

     <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
     <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>
    <script src="Menu.js?v0.0"></script>
</head>
<body>    
     <div class="bg-neutral-100 w-screen h-screen flex flex-col" style="overflow:hidden">
         <div class="h-12 border-2 bg-red-800 flex flex-row">
             <div class="w-1/2"  style="padding:4px;">               
                 <asp:Label id="Label1" class="text-2xl font-black text-white"  runat="server" Text="Control de Prestamos"></asp:Label>  
             </div>
             <div class="w-1/2 justify-center item-center" align="right" style="padding:4px;">                 
                <asp:Label id="lblusuario" class="text-1xl font-black text-white item-center"  runat="server" Text=""></asp:Label>                
             </div>
         </div>
         <div class="easyui-panel" style="width:100%;">            
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Sal32'" style="width:80px;"  id="btnInicio">Cerrar</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Cap32'" style="width:80px;"  id="btnCaptura">Captura</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Con32'" style="width:80px;"  id="btnAplicacion">Aplicación</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Rep32'" style="width:80px;"  id="btnReportes">Reportes</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'carga32'" style="width:80px;"  id="btnImportacion">Importación</a>
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'descarga32'" style="width:80px;"  id="btnExportacion">Exportación</a>
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Cat32'" style="width:80px;"  id="btnCatalogos">Catálogos</a>    
             <a href="#" class="easyui-linkbutton" data-options="plain:true,size:'large',iconAlign:'top',iconCls:'Usu32'" style="width:80px;"  id="btnUsuarios">Usuarios</a>    
         </div>
         <div class="w-full item-center" style="top:113px; height:88.5%; overflow:hidden; position:absolute">
              <div id="tt" class="easyui-tabs" style="width:100%;  height:100%; display:none;"></div>  
         </div>            
     </div>   
    <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
           <div class="center w-screen h-screen items-center"  align="center" >
              <img alt="" src="../../Imagenes/ajax-loader.gif" />
           </div> 
         </div> 
</body>
</html>
