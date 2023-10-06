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
 <script type="text/javascript" src="../../scripts/jquery-1.11.1.min.js"></script>
 <script type="text/javascript" src="../../scripts/demos.js"></script>

<link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/metro-red/easyui.css"/>
<link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/icon.css"/>	

 <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
 <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>
    <script src="../../Scripts/Funsiones.js"></script>
    <script src="Captura.js"></script>
</head>
<body>   
     <div class="w-screen h-screen flex flex-col bg-yellow-50 " align="Center">
          <div class="easyui-panel mb-3" style="padding:2px; width:100%">                                                 
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'limpiar',disabled:true" id="btnLimpiar" >Limpiar</a>        
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-add'"  id="btnNuevo">Nuevo</a>
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-save',disabled:true" id="btnGuardar" >Guardar</a>                                                        
         </div>        
          <div class="flex flex-col self-center px-2 sm:px-6 md:px-4 lg:px-2 py-2 rounded-md w-full max-w-md ">                     
                    <div class="flex flex-col mb-1">
                        <label class="text-left text-lg text-red-900">Empleado</label>   
                        <div class="flex flex-row w-full">  
                           <input class="easyui-numberbox" style="width:100%; text-align:center"  id=""  data-options="required:true"/>                                              
                            <div class="flex flex-row w-full px-4 space-x-2 ">        
                                <a id="btnBuscar" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:false">Buscar</a>            
                            </div> 
                        </div>                        
                    </div>  
                    <div class="flex flex-col mb-1 w-48 ">
                        <label class="text-left text-lg text-red-900">Fecha Solicitud</label>                    
                        <input class="easyui-datebox" style="width:100%; text-align:center" id="txtfechasolicitud"  data-options="required:true,formatter:myformatter,parser:myparser"/>                   
                    </div>
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-64 ">
                            <label class="text-left text-lg text-red-900">Paterno</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtpaterno"  data-options="readonly:true"/>                   
                        </div>
                        <div class="flex flex-col mb-1 w-64">
                            <label class="text-left text-lg text-red-900">Materno</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtmaterno"  data-options="readonly:true"/>                   
                        </div>                   
                    </div>
                    <div class="flex flex-col mb-1">
                        <label class="text-left text-lg text-red-900">Nombres</label>                    
                        <input class="easyui-textbox" style="width:100%" id="txtnombres"  data-options="readonly:true"/>                   
                    </div>
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-64">
                            <label class="text-left text-lg text-red-900">Rfc</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtrfc"  data-options="readonly:true"/>                   
                        </div>
                        <div class="flex flex-col mb-1 w-64">
                            <label class="text-left text-lg text-red-900">Curp</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtcurp"  data-options="readonly:true"/>                   
                        </div>                   
                    </div> 
                    <div class="flex flex-col mb-1">
                         <label class="text-left text-lg text-red-900">Categoría</label>   
                        <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtcategoria"  data-options="readonly:true"/>
                    </div>
                    <div class="flex flex-col mb-1">
                        <label class="text-left text-lg text-red-900">Adscripción</label>                    
                        <input class="easyui-textbox" style="width:100%" id="txtadscripcion"  data-options="readonly:true"/>                   
                    </div>
                     <div class="flex flex-col mb-1">
                        <label class="text-left text-lg text-red-900">Pagaduría</label>                    
                        <input class="easyui-textbox" style="width:100%" id="txtpagaduria"  data-options="readonly:true"/>                   
                    </div>
                    <div class="flex flax-row space-x-2">
                    <div class="flex flex-col mb-1 w-64 ">
                        <label class="text-left text-lg text-red-900">Importe Solicidado</label>                    
                        <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtimporte" precision="2" data-options="required:true"/>                   
                    </div>
                    <div class="flex flex-col mb-1 w-64 ">
                         <label class="text-left text-lg text-red-900">Plazo</label>                    
                        <input class="easyui-combobox" style="width:100%; text-align:center"  id="cboplazos" data-options="required:true"/>                   
                    </div>
                    </div>                                  
                   
     </div>                 
     </div>
     <div class="easyui-dialog flex flex-col items-center" id="win" title="Permisos" closed="true" style="padding:2px;">

     </div>
     <div class="modal" style="display: none;" id="loading">
            <div class="w-screen h-screen justify-center items-center">
                <img alt="" src="../../Imagenes/ajax-loader.gif" />
            </div>
     </div>
</body>
</html>
