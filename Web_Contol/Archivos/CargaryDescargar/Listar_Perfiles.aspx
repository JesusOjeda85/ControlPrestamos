<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listar_Perfiles.aspx.cs" Inherits="ControlDescuentos.Archivos.CargaryDescargar.Listar_Perfiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
 <meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />
 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css"/>    
 <link href="../../tailwinds/static/dist/tailwind.css" rel="stylesheet" />
    <link href="../../Styles/tema.css" rel="stylesheet" />
    <link href="../../Styles/loader.css" rel="stylesheet" />

 <script type="text/javascript" src="../../scripts/jquery-1.11.1.min.js"></script>
 <script type="text/javascript" src="../../scripts/demos.js"></script>

<link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/metro-gray/easyui.css"/>
 <link href="../../jqueryEsy/themes/icons.css" rel="stylesheet" />

 <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
 <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>
    <script src="../../Scripts/Funsiones.js"></script>
    <script src="Listar_Perfiles.js?v0.0"></script>
</head>
<body>
     <div class="bg-neutral-100 w-screen h-screen flex flex-col bg-yellow-50 " align="Center" style="background-color:#FCFDFF;">  
         <div class="flex flex-col self-center px-2 py-2 w-8/12  rounded-md ">    
            <div class="flex flex-col space-y-2 items-center overflow-hidden h-full" style="padding:2px;">
                <input class="easyui-textbox" style="width:100%" id="txtfconcepto" data-options="prompt:'Buscar Concepto'"/>
                    <div class="text-left" style="width:100%; padding:2px; overflow:auto;" >
                        <ul class="easyui-tree" id="lstconceptos" style="width:100%; height:100%;" data-options="animate:true,lines:false"></ul>                        
                    </div>
            </div>
        </div>
    </div>
      <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
     <div class="center w-screen h-screen items-center"  align="center" >
        <img alt="" src="../../Imagenes/ajax-loader.gif" />
     </div> 
   </div> 
</body>
</html>
