<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarraMenu.aspx.cs" Inherits="ControlDescuentos.Archivos.Menu.BarraMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
      <meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />
  <script src="https://cdn.tailwindcss.com"></script>
 <!-- <script src="./tailwind3.js"></script> -->
 <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;800&display=swap" 
   rel="stylesheet"/>
 <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css"/>   
    
 <link href="../../jqueryEsy/themes/metro-gray/easyui.css" rel="stylesheet" />
 <link href="../../jqueryEsy/themes/icons.css" rel="stylesheet" />

  <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
  <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>

    <script src="BarraMenu.js?v0.0"></script>
</head>

<body class="bg-white-300  font-[Poppins]">
     <div class="w-full item-center" style="top:0px; height:100%; overflow:hidden; position:absolute">
       <div id="tt" class="easyui-tabs" style="width:100%;  height:100%; display:none;"></div> 
     </div>
  <span class="absolute text-white text-4xl top-5 left-4 cursor-pointer" onclick="Openbar()">
    <i class="bi bi-filter-left px-2 bg-gray-900 rounded-md"></i>
  </span>
  <div class="sidebar fixed top-0 bottom-0 lg:left-0 left-[-300px] duration-1000
    p-2 w-[300px] overflow-y-auto text-center  shadow h-screen" style="background-color:#2D3E50;">
    <div class="text-blue-100 text-xl">
      <div class="p-2.5 mt-1 flex items-center rounded-md ">
       <%-- <i class="bi bi-app-indicator px-2 py-1 bg-blue-900 rounded-md"></i>--%>
        <h1 class="text-[15px]  ml-3 text-xl text-gray-200 font-bold">Prestamos</h1>
        <i class="bi bi-x ml-20 cursor-pointer lg:hidden" onclick="Openbar()"></i>
      </div>
      <hr class="my-2 text-gray-600">
      <div>     
        <div class="p-2.5 mt-2 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
          <%--<i class="bi bi-house-door-fill"></i>--%>
          <img class="imagen" width="25" heigth="25" src="../../Imagenes/botones/captura.png"/>
          <span class="text-[15px] ml-4 text-gray-200" onclick="AgregarTabPadre('#tpcaptura', 'Captura', '../Captura/Listar_Perfiles.aspx')">Captura</span>         
        </div>
         <hr class="my-4 text-gray-600">
        <div id="daplicacionl" class="p-2.5 mt-2 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
         <%-- <i class="bi bi-bookmark-fill"></i>--%>
             <img class="imagen" width="25" heigth="25" src="../../Imagenes/botones/aplicacion.png"/>
          <span class="text-[15px] ml-4 text-gray-200">Aplicación</span>
        </div>
        <hr id="lnumeracion" class="my-4 text-gray-600">
        <div id="dnumeracion" class="p-2.5 mt-2 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
        <%--  <i class="bi bi-envelope-fill"></i>--%>
             <img class="imagen" width="25" heigth="25" src="../../Imagenes/botones/numeracion.png"/>
          <span class="text-[15px] ml-4 text-gray-200">Numeración</span>
        </div>
        <hr id="limportacion" class="my-4 text-gray-600">
        <div id="dimportacion" class="p-2.5 mt-2 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
            <%--<i class="bi bi-envelope-fill"></i>--%>
             <img class="imagen" width="25" heigth="25" src="../../Imagenes/botones/importacion.png"/>
            <span class="text-[15px] ml-4 text-gray-200">Importación</span>
        </div>
         <hr id="lexportacion" class="my-4 text-gray-600">
        <div id="dexportacion" class="p-2.5 mt-2 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
           <%-- <i class="bi bi-envelope-fill"></i>--%>
             <img class="imagen" width="25" heigth="25" src="../../Imagenes/botones/exportacion.png"/>
            <span class="text-[15px] ml-4 text-gray-200">Exportación</span>
        </div>
        <hr id="lpadrones" class="my-4 text-gray-600">
        <div id="dpadrones" class="p-2.5 mt-2 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
         <%-- <i class="bi bi-chat-left-text-fill"></i>--%>
             <img class="imagen" width="25" heigth="25" src="../../Imagenes/botones/padrones.png"/>
          <div class="flex justify-between w-full items-center" onclick="dropDown()">
            <span class="text-[15px] ml-4 text-gray-200">Padrones</span>
            <span class="text-sm rotate-180" id="arrow">
              <i class="bi bi-chevron-down"></i>
            </span>
          </div>
        </div>
        <div class=" leading-7 text-left text-sm font-thin mt-2 w-4/5 mx-auto" id="submenu">
          <h1 class="cursor-pointer p-2 hover:bg-blue-300 rounded-md mt-1">Liquidez</h1>          
        </div>
         <hr  id="lreportes" class="my-4 text-gray-600">
        <div id="dreportes" class="p-2.5 mt-2 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
           <%-- <i class="bi bi-envelope-fill"></i>--%>
             <img class="imagen" width="25" heigth="25" src="../../Imagenes/botones/reportes.png"/>
            <span class="text-[15px] ml-4 text-gray-200">Reportes</span>
        </div>
        <hr id="lcatalogos" class="my-4 text-gray-600">
        <div id="dcatalogos" class="p-2.5 mt-2 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
           <%-- <i class="bi bi-envelope-fill"></i>--%>
             <img class="imagen" width="25" heigth="25" src="../../Imagenes/botones/catalogos.png"/>
            <span class="text-[15px] ml-4 text-gray-200">Catálogos</span>
        </div>
          <hr id="lusuarios" class="my-4 text-gray-600">
         <div id="dusuarios" class="p-2.5 mt-2 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
             <%-- <i class="bi bi-envelope-fill"></i>--%>
            <img class="imagen" width="25" heigth="25" src="../../Imagenes/botones/usuarios.png"/>
            <span class="text-[15px] ml-4 text-gray-200">Usuarios</span>
        </div>
        <hr id="lsalir" class="my-4 text-gray-600">
        <div class="p-2.5 mt-3 flex items-center rounded-md px-4 duration-300 cursor-pointer  hover:bg-blue-400">
          <i class="bi bi-box-arrow-in-right"></i>
          <span class="text-[15px] ml-4 text-gray-200 font-bold">Salir</span>
        </div>
        <div class="p-2.5 mt-1 flex items-center rounded-md ">            
            <asp:Label id="lblusuario" class="text-[15px]  ml-3 text-xl text-gray-200 font-bold"  runat="server" Text="Usuario"></asp:Label> 
        </div>
      </div>
    </div>
  </div>
  <script>
    function dropDown() {
      document.querySelector('#submenu').classList.toggle('hidden')
      document.querySelector('#arrow').classList.toggle('rotate-0')
    }
    dropDown()

    function Openbar() {
      document.querySelector('.sidebar').classList.toggle('left-[-300px]')
    }
  </script>
 
</body>
</html>
