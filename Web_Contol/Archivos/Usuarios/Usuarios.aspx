<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ControlDescuentos.Archivos.Usuarios.Usuarios" %>

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
    <script src="Usuarios.js?v0.0"></script>
</head>
<body>
  <div class="w-screen h-screen" align="Center">
      <div class="easyui-panel mb-3" style="padding:2px; width:100%">                                                 
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'limpiar',disabled:true" id="btnLimpiar" >Limpiar</a>        
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-add'"  id="btnNuevo">Nuevo</a>
            <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-save',disabled:true" id="btnGuardar" >Guardar</a>                                                        
        </div>  
        <div class="easyui-layout" style="padding:2px; top:15px; width:90%; height:90%;overflow:hidden;">    
            <div id="rmenu"  data-options="region:'west',split:true,hideCollapsedContent:false,collapsed:false" title="<span style='font-size:16px'>Lista de Usuarios</span>" style="width:30%; height:100%; padding:0px; overflow:hidden;" align="center">             
                <div class="flex flex-col items-center overflow-hidden h-full" style="padding:2px;">
                    <input class="easyui-textbox" style="width:100%" id="txtfiltrar" data-options="prompt:'Buscar Usuarios'"/>
                   <div class="text-left" style="width:100%;  height:96%; padding:3px; overflow:auto;" >
                        <ul class="easyui-tree" id="lstusuario" style="width:100%; height:100%;" data-options="animate:true,lines:false"></ul>                        
                    </div>
                </div>
            </div>
            <div data-options="region:'center'" style="width:70%; height:100%; padding:10px;" align="center" class="overflow-hidden" > 
                <div class="flex flex-col px-4 sm:px-6 md:px-4 lg:px-4 py-4 rounded-md w-full max-w-md ">   
                    <div class="flex flex-col mb-3">
                        <label class="text-left text-lg text-red-900">Usuario</label>                    
                        <input class="easyui-textbox" style="width:100%" id="txtusuario"  data-options="required:true"/>                   
                    </div>
                    <div class="flex flex-col mb-3">
                        <label class="text-left text-lg text-red-900">Contraseña</label>                    
                        <input class="easyui-textbox" type="password" style="width:100%" id="txtcontraseña" data-options="required:true,validType: 'length[0,25]'" />                   
                    </div>
                    <div class="flex flex-col mb-3">
                        <label class="text-left text-lg text-red-900">Nombre</label>                    
                        <input class="easyui-textbox" style="width:100%" id="txtnombres" data-options="required:true" />                   
                    </div>
                    <div class="flex flex-col mb-3">
                        <label class="text-left text-lg text-red-900">Apellido Paterno</label>                    
                        <input class="easyui-textbox" style="width:100%" id="txtappaterno" data-options="prompt:''" />                   
                    </div>
                    <div class="flex flex-col mb-3">
                        <label class="text-left text-lg text-red-900">Apellido Materno</label>                    
                        <input class="easyui-textbox" style="width:100%" id="txtapmaterno" data-options="prompt:''" />                   
                    </div>                   
                    <div class="mb-3">
                         <a href="#" class="easyui-linkbutton h-10" data-options="iconCls:'icon-search'" style="width:100%;" id="btnPermisos">Permisos</a>                               
                    </div>                                    
                    <div class="flex flex-rol space-x-4 mb-3  justify-left items-center">
                          <label class="text-left text-lg text-red-900">Administrador:</label>
                          <input id="chkadmin" class="easyui-checkbox" name="Admon" value="0" label=""/>                          
                    </div>                    
                    <div class="flex flex-rol space-x-4 mb-3  justify-left items-center">                          
                          <label class="text-left text-lg text-red-900">Activo:</label>
                          <input  id="chkestatus" class="easyui-checkbox" name="Activo" value="0" label=""/>
                    </div>                  
                </div> 
            </div>
        </div>  
 </div>
  <div class="easyui-dialog flex flex-col items-center" id="win" title="Permisos" closed="true" style="padding:2px;">
      <div class="easyui-panel" style="padding:2px; width:100%;">
          <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar'" id="btnLPermisos" >Limpiar</a>
          <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'" id="btnGpermisos" >Guardar</a>                            
      </div>
     <div id="tt" class="easyui-tabs" style="width:100%; height:94%;overflow:hidden;padding:2px;" data-options="plain:true">
          <div title="Perfiles" align="center" class="flex flex-col items-left" style="overflow:hidden;"> 
               <div class="flex flex-col items-center overflow-hidden h-full" style="padding:2px;">
                    <input class="easyui-textbox" style="width:100%" id="txtfilperfil" data-options="prompt:'Buscar Perfil'"/>
                    <div class="text-left" style="width:100%;  height:96%; padding:2px; overflow:auto;" >
                       <ul class="easyui-tree" id="lstperfil" style="width:100%; height:100%;" data-options="animate:true,lines:false,checkbox:true"></ul>                        
                    </div>
                </div>
          </div>
         <div title="Menus" align="center" class="flex flex-col items-left" style="overflow:hidden;"> 
              <div class="flex flex-col items-center overflow-hidden h-full" style="padding:2px;">
                  <input class="easyui-textbox" style="width:100%" id="txtfilmenu" data-options="prompt:'Buscar Menu'"/>
                  <div class="text-left" style="width:100%;  height:96%; padding:2px; overflow:auto;" >
                        <ul class="easyui-tree" id="lstmenu" style="width:100%; height:100%;" data-options="animate:true,lines:false,checkbox:true"></ul>                        
                  </div>
              </div>
          </div>
     </div>
  </div>
 <div class="modal w-screen h-screen" style="display: none;" id="loading">
        <div class="w-screen h-screen justify-center items-center">
            <img alt="" src="../../Imagenes/ajax-loader.gif" />
        </div>
 </div>
</body>
</html>
