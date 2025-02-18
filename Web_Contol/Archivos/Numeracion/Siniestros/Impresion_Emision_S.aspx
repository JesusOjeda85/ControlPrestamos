<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Impresion_Emision_S.aspx.cs" Inherits="ControlDescuentos.Archivos.Numeracion.Prestamos.Impresion_Emision_S" %>

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
 <link href="../../../tailwinds/static/dist/tailwind.css" rel="stylesheet" />
    <link href="../../../Styles/tema.css" rel="stylesheet" />
    <link href="../../../Styles/loader.css" rel="stylesheet" />

 <script type="text/javascript" src="../../../scripts/jquery-1.11.1.min.js"></script>
 <script type="text/javascript" src="../../../scripts/demos.js"></script>

<link rel="stylesheet" type="text/css" href="../../../jqueryesy/themes/metro-gray/easyui.css"/>
 <link href="../../../jqueryEsy/themes/icons.css" rel="stylesheet" />

 <script type="text/javascript" src="../../../jqueryesy/jquery.min.js"></script>
 <script type="text/javascript" src="../../../jqueryesy/jquery.easyui.min.js"></script>  

      <script type="text/javascript" src="../../../jqueryEsy/plugins/datagrid-detailview.js"></script>
   <script type="text/javascript" src="../../../jqueryEsy/plugins/datagrid-cellediting.js"></script>
  
    <script src="../../../Scripts/Funsiones.js"></script>
    <script src="Impresion_Emision_S.js?v0.2"></script>
</head>
<body>
   <div class="w-screen h-screen flex flex-col " align="Center" style="background-color:#FCFDFF;">          
       <div id="ddatos" class="w-screen h-screen">
            <div class="easyui-panel mb-3" style="padding:2px; width:100%">    
                 <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a>   
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon_documento',disabled:false" id="btnPagare" >Finiquitos</a>                  
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-print',disabled:false" id="btnCheque" >Cheques</a>
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-BDoc',disabled:false" id="btnListadoFirmas" >Listado de Firmas</a>
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-BDoc',disabled:false" id="btnListadoEmitidos" >Listado de Emitidos</a>
            </div>  
        <div class=" w-full h-full items-center">  
        <table class="easyui-datagrid " id="dgprocesos" style="width:100%; height:94.5%;" > 
          <thead>
            <tr>                        
                <th data-options="field:'chk',checkbox:true"></th>                   
                <th data-options="field:'Id',width:80,align:'center',halign:'center',hidden:true">Id</th>      
                <th data-options="field:'Organismo',width:110,align:'center',halign:'center',hidden:false">Organismo</th>                 
                <th data-options="field:'TipoPuesto',width:120,align:'center',halign:'center',hidden:false">Tipo Puesto</th> 
                <th data-options="field:'Emision',width:100,align:'center',halign:'center',hidden:false">Emision</th> 
                <th data-options="field:'NumExt',width:130,align:'center',halign:'center',hidden:false">Proceso</th>
               <%-- <th data-options="field:'Contador',width:90,align:'center',halign:'center',hidden:false">Empleados</th>                 --%>
                <th data-options="field:'FechaProceso',width:200,align:'center',halign:'center',hidden:false">Fecha Proceso</th>
            </tr>
          </thead>
       </table> 
       </div>
       </div>
        <div id="dvista"  class="w-screen h-screen" style="display:none">
          <div class="easyui-panel" style="padding:3px; width:100%">                             
             <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'anterior'" id="btnRegresar">Regresar</a>          
         </div>
         <div id="pvista" title="Panel" style="width:100%;height:95%;padding:2px;"></div>
       </div>
   </div>  
   <div class="easyui-dialog flex flex-col items-center space-y-2" id="win"  closed="true" style="padding:2px;background-color:#FCFDFF; overflow:hidden;">
        <div class="easyui-panel mb-3" style="padding:2px; width:100%">                              
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-print',disabled:false" id="btnImprimir" >Imprimir</a>
        </div> 
        <div class="flex flex-col self-center px-1 py-1 w-full overflow-hidden">
            <div class="flex flex-row py-2 justify-center items-center">
                <a href="#" id="btnTodos" class="easyui-linkbutton" data-options="plain:true,toggle:true,group:'gf',selected:true">Todos los Cheques</a>
                <a href="#" id="btnRangos" class="easyui-linkbutton" data-options="plain:true,toggle:true,group:'gf'">Rango de Cheques</a>    
            </div>
            <div class="flex flex-col mb-1 ">
                <label class="text-left text-lg text-blue-900">Cheque Inicial</label>                    
                <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtinicial" data-options="readonly:true"/>                   
            </div>   
            <div class="flex flex-col mb-1 ">
                <label class="text-left text-lg text-blue-900">Cheque Final</label>                    
                <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtfinal" data-options="readonly:true"/>                   
            </div>         
        </div>
   </div>
   <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
        <div class="center w-screen h-screen items-center"  align="center" >
           <img alt="" src="../../../Imagenes/ajax-loader.gif" />
        </div> 
   </div> 
</body>
</html>
