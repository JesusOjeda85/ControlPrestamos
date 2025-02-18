<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reposiciones.aspx.cs" Inherits="ControlDescuentos.Archivos.Reportes.Reposiciones" %>

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

      <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-detailview.js"></script>
   <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-cellediting.js"></script>
  
    <script src="../../Scripts/Funsiones.js"></script>
    <script src="Reposiciones.js?v0.1"></script>
</head>
<body>
   <div class="w-screen h-screen flex flex-col " align="Center" style="background-color:#FCFDFF;">          
       <div id="ddatos" class="w-screen h-screen">
            <div class="easyui-panel mb-3" style="padding:2px; width:100%">    
                 <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a>   
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon_documento',disabled:false" id="btnPagare" >Pagaré</a>                  
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-print',disabled:false" id="btnCheque" >Cheque</a>
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-BDoc',disabled:false" id="btnListado" >Listado</a>
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-costo20',disabled:false" id="btnSaldos" >Saldo</a>
            </div>            
            <div class="flex flex-row w-full space-x-1 mb-3 justify-center items-center ">           
                    <asp:Label ID="Label11"  CssClass="text-blue-900 text-left text-lg" runat="server" Text="Valor a Buscar:"></asp:Label>            
                    <div class="w-2/5">
                       <input type="text" value="" class="easyui-textbox" id="txtvalor" style="width:100%"/>
                   </div>             
                   <a id="btnBempleado" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">Buscar</a>            
            </div>    
            <table class="easyui-datagrid " id="dgprocesos" style="width:100%; height:89.8%;" > 
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
    <div id="dvista"  class="w-screen h-screen" style="display:none">
          <div class="easyui-panel" style="padding:3px; width:100%">                             
             <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'anterior'" id="btnRegresar">Regresar</a>          
         </div>
         <div id="pvista" title="Panel" style="width:100%;height:95%;padding:2px;"></div>
    </div>
 </div>  
   <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
        <div class="center w-screen h-screen items-center"  align="center" >
           <img alt="" src="../../Imagenes/ajax-loader.gif" />
        </div> 
   </div> 
</body>
</html>