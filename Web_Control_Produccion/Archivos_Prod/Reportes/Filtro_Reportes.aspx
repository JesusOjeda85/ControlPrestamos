﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Filtro_Reportes.aspx.cs" Inherits="ControlDescuentos.Archivos.Reportes.Filtro_Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <meta http-equiv="Expires" content="0"/>
<meta http-equiv="Last-Modified" content="0"/>
<meta http-equiv="Cache-Control" content="no-cache, mustrevalidate"/>
<meta http-equiv="Pragma" content="no-cache"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
    <script src="Filtro_Reportes.js?v0.5"></script>
</head>
<body>
   <div class="w-screen h-screen" align="Center" style="background-color:#FCFDFF;">
      <div class="easyui-panel" style="padding:3px; width:100%">                             
        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'anterior'" id="btnRegresar">Regresar</a>
           <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a>  
        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-print'" id="btnImprimir">Imprimir</a>
           <label id="lbl" class="text-left font-black text-lg text-blue-900"></label> 
     </div>
      <div class="flex flex-row space-x-2 w-full mt-10 mb-4 justify-center items-center ">           
         <asp:Label ID="Label11"  CssClass="text-blue-900 text-left text-lg" runat="server" Text="Valor a Buscar:"></asp:Label>            
         <div class="w-2/5">
            <input type="text" value="" class="easyui-textbox" id="txtvalor" style="width:100%"/>
        </div>             
        <a id="btnBempleado" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">Buscar</a>            
      </div>   
      <table class="easyui-datagrid" id="dgempleados" style="width:100%; height:75%;"> 
        <thead>
           <tr>   
             <th data-options="field:'chk',checkbox:true"></th>   
             <th data-options="field:'Id',width:50,align:'center',halign:'center',hidden:true">Id</th>
             <th data-options="field:'Empleado',width:100,align:'center',halign:'center'">Empleado</th>
             <th data-options="field:'Nombre',width:300,align:'left',halign:'center'">Nombre</th>                          
             <th data-options="field:'Rfc',width:130,align:'center',halign:'center'">Rfc</th>
             <th data-options="field:'Curp',width:180,align:'center',halign:'center'">Curp</th>                                        
             <th data-options="field:'TipoPuesto',width:100,align:'center',halign:'center',hidden:false">TipoPuesto</th>
             <th data-options="field:'ZonaPago',width:100,align:'center',halign:'center',hidden:false">ZonaPago</th>  
              <th data-options="field:'ImporteCredito',width:100,align:'right',halign:'center',hidden:false">Importe</th>  
           </tr>
       </thead>
    </table>   
   </div> 
   <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
       <div class="center w-screen h-screen items-center"  align="center" >
           <img alt="" src="../../Imagenes/ajax-loader.gif" />
       </div>       
   </div> 
</body>
</html>
