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
</head>
<body>   
     <div class="w-screen h-screen flex flex-col " >
          <div class="easyui-panel mb-3" style="padding:2px; width:100%">                                                 
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'limpiar',disabled:true" id="btnLimpiar" >Limpiar</a>        
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-add'"  id="btnNuevo">Nuevo</a>
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-save',disabled:true" id="btnGuardar" >Guardar</a>                                                        
         </div>          
                <div class="flex flex-col self-center px-2 sm:px-6 md:px-4 lg:px-2 py-2 rounded-md w-full max-w-md border-2 border-blue-200 ">   
                    <div class="flex flex-col mb-1 w-32 border-2 border-red-200">
                        <label class="text-left text-lg text-red-900">Empleado</label>                    
                        <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtempleado"  data-options="required:true"/>                   
                    </div>
                    <div class="flex flax-row">
                        <div class="flex flex-col mb-1 w-64 border-2 border-red-200">
                            <label class="text-left text-lg text-red-900">Paterno</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtpaterno"  data-options="required:true"/>                   
                        </div>
                        <div class="flex flex-col mb-1 w-64 border-2 border-red-200">
                            <label class="text-left text-lg text-red-900">Materno</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtmaterno"  data-options="required:true"/>                   
                        </div>                   
                    </div>
                    <div class="flex flex-col mb-1  border-2 border-red-200">
                        <label class="text-left text-lg text-red-900">Nombres</label>                    
                        <input class="easyui-textbox" style="width:100%" id="txtnombres"  data-options="required:true"/>                   
                    </div>
                    <div class="flex flax-row">
                        <div class="flex flex-col mb-1 w-64 border-2 border-red-200">
                            <label class="text-left text-lg text-red-900">Rfc</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtrfc"  data-options="required:true"/>                   
                        </div>
                        <div class="flex flex-col mb-1 w-64 border-2 border-red-200">
                            <label class="text-left text-lg text-red-900">Curp</label>                    
                            <input class="easyui-textbox" style="width:100%" id="txtcurp"  data-options="required:true"/>                   
                        </div>                   
                    </div>  
                     <div class="flex flax-row">
                     <div class="flex flex-col mb-1 w-64 border-2 border-red-200">
                            <label class="text-left text-lg text-red-900">Categoría</label> 
                             <input class="easyui-textbox" style="width:100%; text-align:center"  id="txtcvecategoria"  data-options="required:true"/>                              
                        </div>                    
                      <div class="flex flex-row border-2 border-red-200">                                
                            <a id="btnBcategoria" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">Buscar</a>
                            <a id="btnLcategoria" href="#" class="easyui-linkbutton" data-options="iconCls:'limpiar',plain:true">Limpiar</a>
                        </div> 
                     </div>
                </div>       
     </div>
     <div class="modal" style="display: none;" id="loading">
            <div class="w-screen h-screen justify-center items-center">
                <img alt="" src="../../Imagenes/ajax-loader.gif" />
            </div>
     </div>
</body>
</html>
