<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ControlDescuentos.Archivos.Reportes.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css"/>    
    <link href="../../tailwinds/static/dist/tailwind.css" rel="stylesheet" />
    <link href="../../Styles/tema.css" rel="stylesheet" />
    <link href="../../Styles/loader.css" rel="stylesheet" />

<!-- Report Viewer Office2013 style -->
<link href="../../Styles/stimulsoft.viewer.office2013.whiteblue.css" rel="stylesheet"/>	
<!-- Report Designer Office2013 style -->
<link href="../../Styles/stimulsoft.designer.office2013.whiteblue.css" rel="stylesheet"/>

<!-- Stimusloft Reports.JS -->
<script src="../../Scripts/stimulsoft.reports.js" type="text/javascript"></script>
<script src="../../Scripts/stimulsoft.viewer.js" type="text/javascript"></script>
<script src="../../Scripts/stimulsoft.designer.js" type="text/javascript"></script>

 <link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/metro-gray/easyui.css"/>
 <link href="../../jqueryEsy/themes/icons.css" rel="stylesheet" />

     <script type="text/javascript" src="../../scripts/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="../../scripts/demos.js"></script>
 
    <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
    <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>
     <script src="../../Scripts/Funsiones.js"></script>
    <script src="Reportes.js?v0.0"></script>
</head>
<body onload="onBodyLoad();">
   <div class="w-screen h-screen" align="Center">
      <div class="easyui-panel mb-3" style="padding:2px; width:100%; background-color:#FCFDFF;">   
         <a id="btnRegresar" href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'anterior'" >Regresar</a> 
         <a id="btnBuscar" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:false">Buscar</a>
         <a id="btnImpresion" href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-impbarras16',disabled:true" >Imprimir</a>   
           <label id="lbl" class="text-left font-black text-lg text-blue-900"></label> 
      </div> 
      <table class="Main" cellpadding="0" cellspacing="4" >
        <tr>               
          <td id="viewerContent" style="width: 100%; height: 100%"></td>
        </tr>
      </table> 
    </div>
    <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
       <div class="center w-screen h-screen items-center"  align="center" >
          <img alt="" src="../../Imagenes/ajax-loader.gif" />
       </div>       
   </div> 
</body>
</html>
