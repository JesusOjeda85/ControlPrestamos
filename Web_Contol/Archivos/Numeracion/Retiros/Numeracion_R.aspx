<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Numeracion_R.aspx.cs" Inherits="ControlDescuentos.Archivos.Numeracion.Prestamos.Numeracion_R" %>

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
    <script src="Numeracion_R.js?v0.4"></script>    
</head>
<body>
    <div class="w-screen h-screen flex flex-col " align="Center" style="background-color:#FCFDFF;">   
         <div class="easyui-panel mb-3" style="padding:2px; width:100%">          
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a>                  
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-ok',disabled:false" id="btnProcesar" >Procesar</a>                                                                   
        </div>        
         <div class=" w-full h-full  items-center">      
         <table class="easyui-datagrid " id="dgdatos" style="width:100%; height:100%;" > 
            <thead>
                <tr>                        
                    <th data-options="field:'chk',checkbox:true"></th>                                             
                    <th data-options="field:'Organismo',width:100,align:'center',halign:'center',hidden:false">Organismo</th>      
                     <th data-options="field:'fkTipoPuesto',width:100,align:'center',halign:'center',hidden:true">Tipo de Puesto</th> 
                    <th data-options="field:'TipoPuesto',width:110,align:'center',halign:'center',hidden:false">Tipo de Puesto</th> 
                    <th data-options="field:'Emision',width:130,align:'center',halign:'center',hidden:false">Emision</th>                                           
                    <th data-options="field:'NumExt',width:130,align:'center',halign:'center',hidden:false">Proceso</th>
                    <th data-options="field:'Contador',width:90,align:'center',halign:'center',hidden:false">Empleados</th> 
                    <th data-options="field:'CuentaMaestra',width:100,align:'center',halign:'center',hidden:false">Cuenta</th> 
                    <th data-options="field:'Cheque',width:90,align:'right',halign:'center',hidden:false,editor:{type:'numberbox',options:{precision:0}}">Cheque</th>           
                </tr>
            </thead>
        </table> 
         </div>
       </div> 
     <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
        <div class="center w-screen h-screen items-center"  align="center" >
           <img alt="" src="../../../Imagenes/ajax-loader.gif" />
        </div> 
      </div> 
</body>
</html>
