<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ControlDescuentos.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Expires" content="0"/>
  <meta http-equiv="Last-Modified" content="0"/>
  <meta http-equiv="Cache-Control" content="no-cache, mustrevalidate"/>
  <meta http-equiv="Pragma" content="no-cache"/>

    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css"/>    
    <link href="tailwinds/static/dist/tailwind.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.11.1.min.js"></script>
    <script src="Scripts/demos.js"></script>

    <link href="jqueryEsy/themes/metro-gray/easyui.css" rel="stylesheet" />  
     <link href="jqueryEsy/themes/icon.css" rel="stylesheet" />        
    <link href="Styles/loader.css" rel="stylesheet" />

     <script type="text/javascript" src="jqueryesy/jquery.min.js"></script>
	<script type="text/javascript" src="jqueryesy/jquery.easyui.min.js"></script>      
    <script src="Scripts/Login.js?0.2"></script>
   <script type="text/javascript">
       function preventBack() {
           window.history.forward();
       }
       setTimeout("preventBack()", 0);
       window.onunload = function () {
           null
       };
   </script>
</head>
 <body>
        <div class="w-screen h-screen  lg:flex" style="overflow:hidden; background-color:#FFFFFF;">
            <div class="lg:w-1/2 xl:max-w-screen-sm" style="overflow:hidden">
              <%--  <div class="py-12 bg-red-100 lg:bg-white flex justify-center lg:justify-start lg:px-12">                   
                    <div class="cursor-pointer flex items-center">
                        <div>
                            <svg class="w-10 text-indigo-500" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" id="Layer_1" x="0px" y="0px" viewBox="0 0 225 225" style="enable-background:new 0 0 225 225;" xml:space="preserve">
                                <style type="text/css">
                                    .st0{fill:none;stroke:currentColor;stroke-width:20;stroke-linecap:round;stroke-miterlimit:3;}
                                </style>
                                <g transform="matrix( 1, 0, 0, 1, 0,0) ">
                                <g>
                                <path id="Layer0_0_1_STROKES" class="st0" d="M173.8,151.5l13.6-13.6 M35.4,89.9l29.1-29 M89.4,34.9v1 M137.4,187.9l-0.6-0.4     M36.6,138.7l0.2-0.2 M56.1,169.1l27.7-27.6 M63.8,111.5l74.3-74.4 M87.1,188.1L187.6,87.6 M110.8,114.5l57.8-57.8"/>
                                </g>
                                </g>
                            </svg>
                        </div>
                        <div class="text-2xl text-indigo-800 tracking-wide ml-2 font-semibold">blockify</div>
                    </div>
                </div>--%>
                <div class="py-24 mt-10 px-12 sm:px-24 md:px-48 lg:px-12 lg:mt-16 xl:px-24 xl:max-w-2xl">
                    <h2 class="text-center text-3xl text-blue-900 font-black lg:text-left xl:text-3xl
                    xl:text-bold">Control de Prestamos</h2>
                    <div class="mt-12">                      
                            <div>
                                <div class="text-2xl font-black text-blue-900 ">Usuario</div>
                                <input id="txtusu" class="uppercase w-full text-1xl font-black py-2 border-b border-blue-800 focus:outline-none focus:border-blue-500" type="text" value="Admin" placeholder="Usuario"/>
                            </div>
                            <div class="mt-8">
                                <div class="flex justify-between items-center">
                                    <div class="text-2xl font-black text-blue-900 ">Contraseña</div>                                
                                </div>
                                <input id="txtpas" class="uppercase w-full text-1xl font-black py-2 border-b border-blue-800 focus:outline-none focus:border-blue-500" type="password" value="@dM1n" placeholder="Contraseña"/>
                            </div>
                            <div class="mt-10">
                                <button id='btnentrar' class="bg-gray-300 text-2xl text-blue-900 p-4 w-full rounded-full tracking-wide
                                font-black  focus:outline-none focus:shadow-outline hover:bg-gray-200 
                                shadow-lg">
                                    Entrar
                                </button>
                            </div>
                             
                    </div>
                </div>
            </div>
            <div class="hidden lg:flex items-center justify-center bg-red-100 flex-1 h-screen" style="overflow:hidden">
                <img src="Imagenes/prestamos2.jpg" class="w-full h-full"/>              
            </div>
        </div>
     <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
           <div class="center w-screen h-screen items-center"  align="center" >
              <img alt="" src="Imagenes/ajax-loader.gif" />
           </div> 
         </div> 
    </body>
</html>