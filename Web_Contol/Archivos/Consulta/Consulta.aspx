<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="ControlDescuentos.Archivos.Consulta.Consulta" %>

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
 
 <link rel="stylesheet" type="text/css" href="../../jqueryEsy/themes/metro-gray/easyui.css"/>
 <link rel="stylesheet" type="text/css" href="../../jqueryEsy/themes/icons.css"/>
  
 <script type="text/javascript" src="../../jqueryEsy/jquery.min.js"></script>
 <script type="text/javascript" src="../../jqueryEsy/jquery.easyui.min.js"></script>
   
 <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-detailview.js"></script>
       <script src="../../Scripts/Funsiones.js?v0.0"></script>
    <script src="Consulta.js?v0.6"></script>
</head>
<body>
     <div class="w-screen h-screen flex flex-col items-center" align="Center" style="background-color:#FCFDFF;">   
          <div class="easyui-panel" style="padding:2px; width:100%">          
             <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a>               
             <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search',disabled:false" id="btnBuscar" >Buscar</a>        
          </div> 
         <div class=" w-8/12 flex flex-col self-center px-2 py-2 overflow-hidden">
              <div class="flex flax-row space-x-2">
                <div class="flex flex-col mb-1 w-1/2 ">
                    <label class="text-left text-lg text-blue-900">Empleado</label>   
                    <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtempleado"  data-options="readonly:true"/>           
                </div>
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
                          
           </div>
           <div class="flex flax-row space-x-2">
             <div class="flex flex-col mb-1 w-1/3 ">
                <label class="text-left text-lg text-blue-900">Emisión</label>                    
                <input class="easyui-combobox" style="width:100%; text-align:left"  id="cboEmision"/>                   
            </div>  
            <div class="flex flex-col mb-1  w-1/3">
                <label class="text-left text-lg text-blue-900">Concepto</label>                    
                <input class="easyui-textbox" style="width:100%; text-align:left"  id="txtconcepto" data-options="readonly:true"/>                                                                         
            </div>  
            <div class="flex flex-col mb-1  w-1/3">
                <label class="text-left text-lg text-blue-900">Importe</label>                    
                <input class="easyui-textbox" style="width:100%; text-align:right"  id="txtimporte" data-options="readonly:true"/>                                                                         
            </div>  
            <div class="flex flex-col mb-1  w-1/3">
                <label class="text-left text-lg text-blue-900">Plazo</label>                    
                <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtplazo" data-options="readonly:true"/>                                                                         
            </div>  
         </div>
     </div> 
          <table class="easyui-datagrid " id="dgdetalle" style="width:80%; height:65%;" > 
            <thead>
                <tr>                                            
                   <th data-options="field:'Quincena',width:80,align:'center',halign:'center',hidden:false">Quincena</th>
                   <th data-options="field:'Año',width:50,align:'center',halign:'center',hidden:false">Año</th>
                    <th data-options="field:'ImporteCobrar',width:150,align:'right',halign:'center',hidden:false">Importe Cobrar</th>
                     <th data-options="field:'ImporteCobrado',width:150,align:'right',halign:'center',hidden:false">Importe Cobrado</th>
                </tr>
            </thead>
         </table>
     </div>
      <div class="easyui-dialog flex flex-col items-center" id="win" title="Prestamos" closed="true" style="padding:2px;">
      <div class="flex flex-row w-full justify-center items-center ">           
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
