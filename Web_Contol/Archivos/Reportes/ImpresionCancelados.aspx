<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImpresionCancelados.aspx.cs" Inherits="ControlDescuentos.Archivos.Reportes.ImpresionCancelados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <meta http-equiv="Expires" content="0"/>
<meta http-equiv="Last-Modified" content="0"/>
<meta http-equiv="Cache-Control" content="no-cache, mustrevalidate"/>
<meta http-equiv="Pragma" content="no-cache"/>
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
    <script src="../../jqueryEsy/plugins/jquery.filebox.js"></script>
 
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.15.3/xlsx.full.min.js"></script>

    <script src="../../Scripts/Funsiones.js"></script>
    <script src="ImpresionCancelados.js?v0.2"></script>
</head>
    <body>
      <div class="bg-neutral-100 w-screen h-screen flex flex-col bg-yellow-50 " align="Center" style="background-color:#FCFDFF;">  
         <div class="easyui-panel mb-3" style="padding:2px; width:100%">    
              <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a>   
             <label class="text-left text-lg text-blue-900">Tipo de Cancelación:</label>
             <input class="easyui-combobox" style="width:250px; text-align:left"  id="cbotipopuesto"  data-options="required:false"/>    
        </div>  
           <div id="rwvista" title="Panel" style="width:100%;height:100%;padding:2px;"></div>
       </div>
     <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
        <div class="center w-screen h-screen items-center"  align="center" >
           <img alt="" src="../../Imagenes/ajax-loader.gif" />
        </div> 
      </div> 
</body>
</html>
