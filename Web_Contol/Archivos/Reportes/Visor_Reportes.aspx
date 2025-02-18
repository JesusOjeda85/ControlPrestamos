<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visor_Reportes.aspx.cs" Inherits="ControlDescuentos.Archivos.Reportes.Visor_Reportes" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>  
  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <meta http-equiv="Expires" content="0"/>
<meta http-equiv="Last-Modified" content="0"/>
<meta http-equiv="Cache-Control" content="no-cache, mustrevalidate"/>
<meta http-equiv="Pragma" content="no-cache"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>     
<meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />     
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css"/>    
        <link href="../../tailwinds/static/dist/tailwind.css" rel="stylesheet" />
        <link href="../../Styles/tema.css" rel="stylesheet" />
        <link href="../../Styles/loader.css" rel="stylesheet" />
        <link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/metro-gray/easyui.css"/>
        <link href="../../jqueryEsy/themes/icons.css" rel="stylesheet" />

        <script type="text/javascript" src="../../scripts/jquery-1.11.1.min.js"></script>
        <script type="text/javascript" src="../../scripts/demos.js"></script>

        <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
        <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../jqueryesy/plugins/datagrid-filter.js"></script>
       <script src="../../Scripts/Funsiones.js"></script>
    <script src="Visor_Reportes.js?v0.1"></script>
</head>
<body> 
   <%-- <form runat="server">--%>
      <div class="w-screen h-screen" align="Center" style="background-color:#FCFDFF;">  
           <div class="easyui-panel" style="padding:3px; width:100%">                                         
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon_excel'" id="btnExportar">Exportar</a>          
            </div>
           <div id="rwvista" title="Panel" style="width:100%;height:100%;padding:2px;"></div>
      </div>
    <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
    <div class="center w-screen h-screen items-center"  align="center" >
        <img alt="" src="../../Imagenes/ajax-loader.gif" />
    </div>       
</div> 
     <%--</form>--%>
</body>
</html>
