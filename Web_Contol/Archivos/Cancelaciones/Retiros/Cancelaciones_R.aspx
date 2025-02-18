<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cancelaciones_R.aspx.cs" Inherits="ControlDescuentos.Archivos.Cancelaciones.Prestamos.Cancelaciones_R" %>

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
    <script src="../../../Scripts/Funsiones.js"></script>
    <script src="Cancelaciones_R.js?v0.4"></script>
</head>
<body>
   <div class="w-screen h-screen flex flex-col " align="Center" style="background-color:#FCFDFF;">              
      <div class="easyui-panel mb-3" style="padding:2px; width:100%">         
        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a> 
        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search',disabled:false" id="btnBuscar" >Buscar</a>    
        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save',disabled:true" id="btnGuardar" >Guardar</a>                                                                
     </div>        
            <div class=" w-8/12 flex flex-col self-center px-2 py-2 overflow-hidden">
         <div class="flex flax-row space-x-2">           
           <div class="flex flex-col mb-1 w-1/2">
               <label class="text-left text-lg text-blue-900">Rfc</label>                    
               <input class="easyui-textbox uppercase" style="width:100%;" id="txtrfc"  data-options="readonly:true"/>                   
           </div>               
           <div class="flex flex-col mb-1 w-1/2">
               <label class="text-left text-lg text-blue-900">Nombre</label>                    
               <input class="easyui-textbox uppercase" style="width:100%;" id="txtNombre"  data-options="readonly:true"/>                   
           </div>                              
        </div>            
       <div class="flex flax-row space-x-2">
           <div class="flex flex-col mb-1 w-1/2 ">
               <label class="text-left text-lg text-blue-900">Tipo de Puesto</label>                    
               <input class="easyui-textbox" style="width:100%; text-align:left"  id="txttipopuesto"  data-options="readonly:true"/>                   
         </div>
         <div class="flex flex-col mb-1  w-1/2">
            <label class="text-left text-lg text-blue-900">Zona Pago</label>                    
            <input class="easyui-textbox" style="width:100%; text-align:left"  id="txtzonapago" data-options="readonly:true"/>                                                                         
         </div> 
        <div class="flex flex-col mb-1  w-1/2">
           <label class="text-left text-lg text-blue-900">Motivo de Baja</label>                    
           <input class="easyui-textbox" style="width:100%; text-align:left"  id="txtmotivo" data-options="readonly:true"/>               
       </div>                            
      </div>
      <div class="flex flax-row space-x-2">            
        <div class="flex flex-col mb-1 w-1/2 ">
            <label class="text-left text-lg text-blue-900">Importe Bruto</label>                    
            <input data-tooltip-target="tooltip-bottom" class="easyui-numberbox" style="width:100%; text-align:right"  id="txtimpbruto" data-options="readonly:true,groupSeparator:',',precision:2"/>                                              
        </div>
        <div class="flex flex-col mb-1 w-1/2 ">
            <label class="text-left text-lg text-blue-900">Importe Adeudo</label>                    
            <input class="easyui-numberbox" style="width:100%; text-align:right"  id="txtimpadeudo" data-options="readonly:true,groupSeparator:',',precision:2"/>                   
        </div>      
        <div class="flex flex-col mb-1 w-1/2 ">
            <label class="text-left text-lg text-blue-900">Importe Neto</label>                    
            <input class="easyui-numberbox" style="width:100%; text-align:right"  id="txtimpneto" data-options="readonly:true,groupSeparator:',',precision:2"/>                   
        </div>        
      </div>
     <div class="flex flax-row space-x-2">        
        <div class="flex flex-col mb-1  w-1/3">
            <label class="text-left text-lg text-blue-900">Fecha Cancelación</label>                                
            <input class="easyui-datebox" style="width:100%" id="dbfecCaptura" data-options="formatter:myformatter,parser:myparser,required:true"/>
        </div>  
        <div class="flex flex-col mb-1  w-1/3">
            <label class="text-left text-lg text-blue-900">Fecha Solicitud</label>                    
            <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtfecsolicitud" data-options="readonly:true"/>                                                                         
        </div>  
        <div class="flex flex-col mb-1 w-1/3 ">
            <label class="text-left text-lg text-blue-900">Emisión</label>                    
            <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtEmision" data-options="readonly:true"/>                   
        </div> 
     </div>
     <div class="flex flex-row ">
  <div class="flex flex-col w-full">
   <label class="text-left text-lg text-blue-900">Observaciones</label>                    
   <input class="easyui-textbox uppercase" multiline="true" style="width:100%; height:120px" id="txtobservaciones"  data-options="readonly:false"/>                   
 </div> 
</div>
</div> 
      
    </div>   
   <div class="easyui-dialog flex flex-col items-center" id="win" title="Prestamos" closed="true" style="padding:2px;">
     <div class="flex flex-row w-full pt-1 pb-1 space-x-1 justify-center items-center ">           
       <asp:Label ID="Label11"  CssClass="text-blue-900 text-left text-lg" runat="server" Text="Valor a Buscar:"></asp:Label>            
       <div class="w-2/5">
         <input type="text" value="" class="easyui-textbox" id="txtvalor" style="width:100%"/>
       </div>             
       <a id="btnBempleado" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">Buscar</a>            
   </div>          
     <table class="easyui-datagrid " id="dgempleados" style="width:100%; height:100%;"> 
      <thead>
          <tr>   
              <th data-options="field:'Id',width:50,align:'center',halign:'center',hidden:true">Id</th>
              <th data-options="field:'fkorganismo',width:50,align:'center',halign:'center',hidden:true">fkorganismo</th>              
              <th data-options="field:'Nombre',width:300,align:'left',halign:'center'">Nombre</th>                          
              <th data-options="field:'Rfc',width:130,align:'center',halign:'center'">Rfc</th>              
              <th data-options="field:'TipoPuesto',width:110,align:'center',halign:'center',hidden:false">Tipo Puesto</th>
              <th data-options="field:'ZonaPago',width:110,align:'center',halign:'center',hidden:false">Zona Pago</th>  
               <th data-options="field:'ImporteBruto',width:110,align:'right',halign:'center',hidden:false">Imp. Bruto</th>  
                <th data-options="field:'ImporteAdeudo',width:110,align:'right',halign:'center',hidden:false">Imp. Adeudo</th>  
               <th data-options="field:'ImporteNeto',width:110,align:'right',halign:'center',hidden:false">Imp. Neto</th>               
               <th data-options="field:'Emision',width:90,align:'right',halign:'center',hidden:false">Emision</th>  
               <th data-options="field:'FecSolicitud',width:150,align:'center',halign:'center',hidden:false">Fec. Solñicitud</th>  
               <th data-options="field:'MotivoBaja',width:250,align:'left',halign:'center',hidden:false">Motivo Baja</th>  
          </tr>
        </thead>
      </table>   
   </div>
<div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
       <div class="center w-screen h-screen items-center"  align="center" >
          <img alt="" src="../../../Imagenes/ajax-loader.gif" />
       </div> 
     </div> 
</body>
</html>

 
 