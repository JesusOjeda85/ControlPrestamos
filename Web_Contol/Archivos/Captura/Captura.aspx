<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captura.aspx.cs" Inherits="ControlDescuentos.Archivos.Captura.Captura" %>

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
 <script type="text/javascript" src="../../scripts/jquery-1.11.1.min.js"></script>
 <script type="text/javascript" src="../../scripts/demos.js"></script>

<link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/metro-red/easyui.css"/>
<link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/icon.css"/>	

 <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
 <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>
    <script src="../../Scripts/Funsiones.js"></script>
    <script src="Captura.js?v0.1"></script>
</head>
<body>   
     <div class="w-screen h-screen flex flex-col bg-yellow-50 " align="Center">
          <div class="easyui-panel mb-3" style="padding:2px; width:100%">                                                 
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'limpiar',disabled:true" id="btnLimpiar" >Limpiar</a>        
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-add'"  id="btnNuevo">Nuevo</a>
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-save',disabled:true" id="btnGuardar" >Guardar</a>                                                        
         </div>        
          <div class="flex flex-col self-center px-2 sm:px-6 md:px-4 lg:px-2 py-2 rounded-md border-2 border-blue-200 ">                     
                    <div class="flex flex-col mb-1">
                        <label class="text-left text-lg text-red-900">Empleado</label>   
                        <div class="flex flex-row w-full">  
                           <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtempleado"  data-options="required:true"/>                                              
                            <div class="flex flex-row w-full px-4 space-x-2 ">        
                                <a id="btnBuscar" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:false">Buscar</a>            
                            </div> 
                        </div>                        
                    </div>                      
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-red-900">Paterno</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtpaterno"  data-options="readonly:true"/>                   
                        </div>
                        <div class="flex flex-col mb-1 w-1/2">
                            <label class="text-left text-lg text-red-900">Materno</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtmaterno"  data-options="readonly:true"/>                   
                        </div>                   
                    </div>
                    <div class="flex flex-col mb-1 ">
                        <label class="text-left text-lg text-red-900">Nombres</label>                    
                        <input class="easyui-textbox" style="width:100%" id="txtnombres"  data-options="readonly:true"/>                   
                    </div>
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2">
                            <label class="text-left text-lg text-red-900">Rfc</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtrfc"  data-options="readonly:true"/>                   
                        </div>
                        <div class="flex flex-col mb-1 w-1/2">
                            <label class="text-left text-lg text-red-900">Curp</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtcurp"  data-options="readonly:true"/>                   
                        </div>                   
                    </div> 
                    <div class="flex flex-row mb-1 space-x-2">
                      <div class="flex flex-col mb-1 w-1/4 ">
                         <label class="text-left text-lg text-red-900">Categoría</label>   
                         <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtcvecat"  data-options="readonly:true"/>
                      </div>
                      <div class="flex flex-col mb-1 w-3/4 ">
                          <label class="text-left text-lg text-red-900">Descripcion</label>   
                          <input class="easyui-textbox" style="width:100%; text-align:left"  id="txtdescat"  data-options="readonly:true"/>
                      </div>
                    </div>
                     <div class="flex flex-row mb-1 space-x-2">
                          <div class="flex flex-col mb-1 w-1/4 ">
                            <label class="text-left text-lg text-red-900">Adscripción</label>   
                            <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtcveads"  data-options="readonly:true"/>
                         </div>
                        <div class="flex flex-col mb-1 w-3/4 ">
                            <label class="text-left text-lg text-red-900">Descripcion</label>   
                            <input class="easyui-textbox" style="width:100%; text-align:left"  id="txtdesads"  data-options="readonly:true"/>
                        </div>
                    </div>                    
                     <div class="flex flex-row mb-1 space-x-2">
                        <div class="flex flex-col mb-1 w-1/4 ">
                            <label class="text-left text-lg text-red-900">Pagaduría</label>   
                            <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtcvepag"  data-options="readonly:true"/>
                        </div>
                        <div class="flex flex-col mb-1 w-3/4 ">
                            <label class="text-left text-lg text-red-900">Descripcion</label>   
                            <input class="easyui-textbox" style="width:100%; text-align:left"  id="txtdespag"  data-options="readonly:true"/>
                        </div>
                    </div> 
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-red-900">Fecha Solicitud</label>                    
                            <input class="easyui-datebox" style="width:100%; text-align:center" id="txtfechasolicitud"  data-options="required:true,formatter:myformatter,parser:myparser"/>                   
                        </div>
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-red-900">Plazo</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:left"  id="cboplazos" data-options="required:true"/>                   
                        </div>
                    </div>
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-red-900">Tipo Pago</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:center"  id="cbotipopago" precision="2" data-options="required:true"/>                   
                        </div>
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-red-900">Banco</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:center"  id="cbobanco" precision="2" data-options="required:true"/>                   
                        </div>
                    </div>   
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-red-900">Importe Solicidado</label>                    
                            <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtimporte" precision="2" data-options="required:true"/>                   
                        </div>
                         <div class="flex flex-col mb-1 w-1/2 ">
                             <label class="text-left text-lg text-red-900">Cuenta Bancaria</label>                    
                             <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtcuenta" precision="2" data-options="required:true"/>                   
                         </div>
                    </div>                                  
                   
           </div>                 
     </div>
     <div class="easyui-dialog flex flex-col items-center space-y-2" id="win" title="Permisos" closed="true" style="padding:2px;">
         <div class="flex flex-row space-x-2 justify-center items-center">
             <asp:Label ID="Label11"  CssClass="LetraChicaNegrita" runat="server" Text="Valor a Buscar:"></asp:Label>
             <input type="text" value="" class="easyui-textbox" id="txtvalor" style="width:250px"/>
             <a id="btnBempleado" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">Buscar</a>
         </div>          
         <table class="easyui-datagrid " id="dgempleados" style="width:100%; height:100%;"> 
            <thead>
                <tr>                    
                    <th data-options="field:'numemp',width:100,align:'center',halign:'center'">Empleado</th>
                    <th data-options="field:'nomcom',width:300,align:'left',halign:'center'">Nombre</th>                          
                    <th data-options="field:'rfccom',width:130,align:'center',halign:'center'">Rfc</th>
                    <th data-options="field:'curpemp',width:180,align:'center',halign:'center'">Curp</th>                        
                    <th data-options="field:'patemp',width:180,align:'center',halign:'center',hidden:true">patemp</th>
                    <th data-options="field:'matemp',width:180,align:'center',halign:'center',hidden:true">matemp</th>
                    <th data-options="field:'nomemp',width:180,align:'center',halign:'center',hidden:true">nomemp</th>
                    <th data-options="field:'cvepuepl',width:180,align:'center',halign:'center',hidden:true">cvepuepl</th>
                    <th data-options="field:'despue',width:180,align:'center',halign:'center',hidden:true">despue</th>
                     <th data-options="field:'cveadspl',width:180,align:'center',halign:'center',hidden:true">cveadspl</th>
                    <th data-options="field:'descentro',width:180,align:'center',halign:'center',hidden:true">descentro</th>
                      <th data-options="field:'cvepagpl',width:180,align:'center',halign:'center',hidden:true">cvepagpl</th>
                    <th data-options="field:'despag',width:180,align:'center',halign:'center',hidden:true">despag</th>
                </tr>
            </thead>
        </table>   
     </div>
     <div class="modal" style="display: none;" id="loading">
            <div class="w-screen h-screen justify-center items-center">
                <img alt="" src="../../Imagenes/ajax-loader.gif" />
            </div>
     </div>
</body>
</html>
