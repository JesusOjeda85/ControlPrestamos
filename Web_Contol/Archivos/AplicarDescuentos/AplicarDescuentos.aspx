<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AplicarDescuentos.aspx.cs" Inherits="ControlDescuentos.Archivos.AplicarDescuentos.AplicarDescuentos" %>

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
 <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-cellediting.js"></script>
 <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-scrollview.js"></script>
 <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-filter.js"></script>
 <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-export.js"></script>
 <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-detailview.js"></script>
    <script src="../../Scripts/Funsiones.js?v0.0"></script>
    <script src="AplicarDescuentos.js?v0.0"></script>
</head>
<body>
     <div class="bg-neutral-100 w-screen h-screen flex flex-col bg-yellow-50 " align="Center" style="background-color:#FCFDFF;">   
          <div class="easyui-panel mb-3" style="padding:2px; width:100%">    
               <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'anterior'" id="btnRegresar">Regresar</a> 
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a>  
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add',disabled:false" id="btnEditar">Editar</a>
                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-ok',disabled:false" id="btnAplicar" >Aplicar</a>  
               <label id="lblconcepto" class="text-left font-black text-lg text-blue-900"></label> 
           </div>  
         <div class="flex flex-col space-y-2 w-full h-full">
           <div class="flex flex-row space-x-2 w-full justify-center items-center ">           
                <asp:Label ID="Label11"  CssClass="text-blue-900" runat="server" Text="Valor a Buscar:"></asp:Label>            
                <div class="w-2/5">
                    <input type="text" value="" class="easyui-textbox" id="txtvalor" style="width:100%"/>
                </div>             
                <a id="btnBuscar" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">Buscar</a>            
            </div>         
            <table class="easyui-datagrid " id="dgdatos" style="width:100%; height:75%;" > 
                <thead>
                    <tr>                        
                        <th data-options="field:'chk',checkbox:true"></th>                         
                        <th data-options="field:'id',width:90,align:'center',halign:'center',hidden:true">id</th>
                        <th data-options="field:'fkorganismo',width:90,align:'center',halign:'center',hidden:true">fkorganismo</th>
                        <th data-options="field:'Organismo',width:70,align:'center',halign:'center',hidden:false">Organismo</th>
                        <th data-options="field:'fkconcepto',width:90,align:'center',halign:'center',hidden:true">fkconcepto</th>
                        <th data-options="field:'Concepto',width:250,align:'left',halign:'center',hidden:false">Concepto</th>
                        <th data-options="field:'Empleado',width:70,align:'center',halign:'center'">Empleado</th>
                        <th data-options="field:'Rfc',width:120,align:'center',halign:'center'">Rfc</th>                                                  
                        <th data-options="field:'Nombre',width:300,align:'left',halign:'center'">Nombre</th>                        
                        <th data-options="field:'ImporteCredito',width:90,align:'right',halign:'center',hidden:false">Credito</th>
                        <th data-options="field:'fkPlazo',width:180,align:'center',halign:'center',hidden:true">fkPlazo</th>
                        <th data-options="field:'Plazo',width:90,align:'center',halign:'center',hidden:false">Plazo</th>
                        <th data-options="field:'fkTipoPago',width:180,align:'center',halign:'center',hidden:true">fkTipoPago</th>
                        <th data-options="field:'TipoPago',width:150,align:'center',halign:'center',hidden:false">Tipo de Pago</th>                       
                        <th data-options="field:'fkBanco',width:180,align:'center',halign:'center',hidden:true">fkBanco</th>
                        <th data-options="field:'Banco',width:90,align:'center',halign:'center',hidden:false">Banco</th>
                        <th data-options="field:'CuentaBancaria',width:150,align:'center',halign:'center',hidden:false">Cuenta Bancaria</th>                    
                    </tr>
                </thead>
            </table> 
              <div id="tb" style="height:auto">                
               
              <%--  <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:false,disabled:false" id="btnDetalle">Detalle</a>--%>
            </div>
         </div>
     </div>  
     <div class="easyui-dialog flex flex-col items-center space-y-2" id="WDetalle" title="Detalle del Empleado" closed="true" style="padding:2px;background-color:#FCFDFF;overflow:hidden;">
    
        <div class="flex flex-col self-center px-2 py-2 w-full overflow-auto">
             <div class="flex flex-row space-x-1"  >
                <div class="flex flex-col mb-1 w-1/4 ">
                    <label class="text-left text-lg text-blue-900">Categoría</label>   
                    <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtcvecat"  data-options="readonly:true"/>
                </div>
                <div class="flex flex-col mb-1 w-3/4">
                    <label class="text-left text-lg text-blue-900">Descripcion</label>   
                    <input class="easyui-textbox" style="width:100%; text-align:left"  id="txtdescat"  data-options="readonly:true"/>
                </div>
            </div>
            <div class="flex flex-row  space-x-1">
                <div class="flex flex-col mb-1 w-1/4 ">
                    <label class="text-left text-lg text-blue-900">Adscripción</label>   
                    <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtcveads"  data-options="readonly:true"/>
                </div>
                <div class="flex flex-col mb-1 w-3/4 ">
                    <label class="text-left text-lg text-blue-900">Descripcion</label>   
                    <input class="easyui-textbox" style="width:100%; text-align:left"  id="txtdesads"  data-options="readonly:true"/>
                </div>
           </div>                    
            <div class="flex flex-row  space-x-1">
                <div class="flex flex-col mb-1 w-1/4 ">
                    <label class="text-left text-lg text-blue-900">Pagaduría</label>   
                    <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtcvepag"  data-options="readonly:true"/>
                </div>
                <div class="flex flex-col mb-1 w-3/4 ">
                    <label class="text-left text-lg text-blue-900">Descripcion</label>   
                    <input class="easyui-textbox" style="width:100%; text-align:left"  id="txtdespag"  data-options="readonly:true"/>
                </div>
            </div> 
        </div>
      </div>
     <div class="easyui-dialog flex flex-col items-center space-y-2" id="WEditar" title="Detalle del Empleado" closed="true" style="padding:2px;background-color:#FCFDFF;overflow:hidden;">
        <div class="easyui-panel mb-3" style="padding:2px; width:100%">                 
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLDetalle" >Limpiar</a>
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save',disabled:false" id="btnGDetalle" >Guardar</a>
        </div> 
         <div class="flex flex-col self-center px-2 py-2 w-full overflow-auto">
             <div class="flex flex-col  w-full ">
                <label class="text-left text-lg text-blue-900">Plazo</label>                    
                <input class="easyui-combobox" style="width:100%; text-align:left"  id="cboplazos" data-options="required:true"/>                   
             </div>
             <div class="flex flax-row space-x-1">
                <div class="flex flex-col w-1/2 ">
                    <label class="text-left text-lg text-blue-900">Tipo Pago</label>                    
                    <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbotipopago"  data-options="required:true"/>                   
                </div>
                <div class="flex flex-col w-1/2 ">
                    <label class="text-left text-lg text-blue-900">Banco</label>                    
                    <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbobanco" data-options="required:true"/>                   
                </div>
            </div>   
            <div class="flex flax-row space-x-1">
                <div class="flex flex-col w-1/2 ">
                    <label class="text-left text-lg text-blue-900">Importe Solicitado</label>                    
                    <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtimporte" precision="0" data-options="required:true,precision:2,groupSeparator:',',decimalSeparator:'.'"/>                   
                </div>
                <div class="flex flex-col  w-1/2 ">
                    <label class="text-left text-lg text-blue-900">Cuenta Bancaria</label>                    
                    <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtcuenta"  data-options="required:true"/>                   
                </div>
            </div>      
         </div>
     </div>
     <div class="easyui-dialog flex flex-col items-center space-y-2" id="WAplicacion"  closed="true" style="padding:2px;background-color:#FCFDFF; overflow:hidden;">
         <div class="easyui-panel mb-3" style="padding:2px; width:100%">                              
             <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-ok',disabled:false" id="btnGAplicar" >Autorizar</a>
         </div> 
         <div class="flex flex-col self-center px-2 py-2 w-full overflow-auto">
              <div class="flex flax-row space-x-1 overflow-hidden">
                <div class="flex flex-col mb-1 w-1/2 ">
                    <label class="text-left text-lg text-blue-900">Quincena</label>                    
                    <input class="easyui-numberspinner" style="width:100%; text-align:center" id="numquincena"  data-options="readonly:false, spinAlign:'horizontal',min:1,max:24,editable:true"/>                   
                </div>
                <div class="flex flex-col mb-1 w-1/2 ">
                    <label class="text-left text-lg text-blue-900">Año</label>                    
                    <input class="easyui-numberspinner" style="width:100%; text-align:center"  id="numaño" data-options="readonly:false,spinAlign:'horizontal',editable:false"/>                   
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
