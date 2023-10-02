<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministracionDeUsuarios.aspx.cs" Inherits="Nomina.Archivos.UsuariosyPermisos.AdministracionDeUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>      
      <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
      <meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />	
        
    <link href="../../Styles/pagina.css" rel="stylesheet" />
      <link href="../../Styles/EstiloFuente.css" rel="stylesheet" />    
    <link href="../../Styles/loader.css" rel="stylesheet" />
      <link href="../../tailwinds/static/dist/tailwind.css" rel="stylesheet" />
    
   <link href="../../jqueryEsy/themes/pepper-grinder/easyui.css" rel="stylesheet" />	
    <link href="../../jqueryEsy/themes/icon.css" rel="stylesheet" />   
    
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/demos.js"></script>

    <script src="../../jqueryEsy/jquery.easyui.min.js"></script>

    <script src="../../jqueryEsy/plugins/datagrid-cellediting.js"></script>
    <script src="../../jqueryEsy/plugins/datagrid-scrollview.js"></script>
    <script src="../../jqueryEsy/plugins/datagrid-filter.js"></script>
        
    <script src="../../Scripts/Funsiones.js?v0.0"></script>
    
    <script src="../Script_Paginas/AdministracionDeUsuarios.js?0.0"></script>
    <style>
        .espacio{
					height:10px;
				}
    </style>
</head>
<body>      
     <div id="dmenu" class="w-screen h-screen items-center" align="Center">  
         <div class="easyui-panel" style="padding:3px; width:100%">                                    
                 <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'" id="btnNuevo">Nuevo</a>        
                 <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar' ,disabled:true" id="btnLimpiar" >Limpiar</a>        
                 <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save',disabled:true" id="btnGuardar" >Guardar</a>                                                        
            </div>                                  
        <div class="easyui-layout" style="width:100%;height:95%;overflow:hidden;">    
            <div id="rmenu" data-options="region:'west',split:true,hideCollapsedContent:false,collapsed:false" title="Lista de Usuarios" style="width:30%; height:100%; padding:0px; overflow:auto;" align="center">             
                <div class="easyui-layout" style="width:100%;height:100%; overflow:hidden;">
                    <div data-options="region:'north'" style="width:100%; height:5%; padding:3px; overflow:hidden;" align="center">                        
                        <input class="easyui-textbox" style="width:100%" id="txtfiltrar">
                    </div>
                    <div data-options="region:'south'" style="width:100%; height:95%; padding:3px; overflow:auto;" >                        
                        <ul class="easyui-tree" id="lstusurio" data-options="animate:true,lines:false"></ul>                        
                    </div>
                </div>        
            </div>
             <div data-options="region:'center'" style="width:70%; height:100%; padding:30px; overflow-x: hidden;overflow-y: hidden;" align="center" > 
                    <table>
                     <tr>
                         <td align="Left" class="auto-style2"><asp:Label ID="Label1" CssClass="LetraChicaNegrita"  runat="server" Text="Usuario:"></asp:Label></td>
                        <td align="Left" class="auto-style3"><input class="easyui-textbox" style="width:250px" id="txtusuario" value=""></td>
                     </tr>
                    <tr class="espacio"></tr>
                    <tr>
                        <td align="Left" class="auto-style2"><asp:Label ID="Label2" CssClass="LetraChicaNegrita"  runat="server" Text="Contraseña:"></asp:Label></td>
                       <td align="Left"><input class="easyui-textbox" type="password" style="width:250px" id="txtcontraseña" value="" data-options="validType: 'length[0,25]'"></td>
                    </tr>
                    <tr class="espacio"></tr>
                    <tr>
                       <td align="Left" class="auto-style2"><asp:Label ID="Label6" CssClass="LetraChicaNegrita"  runat="server" Text="Nombre(s):"></asp:Label></td>
                       <td align="Left"><input class="easyui-textbox" style="width:250px" id="txtnombres" value=""></td>
                     </tr>
                     <tr class="espacio"></tr>
                     <tr>
                        <td align="Left" class="auto-style2"><asp:Label ID="Label7" CssClass="LetraChicaNegrita"  runat="server" Text="Apellido Paterno:"></asp:Label></td>
                       <td align="Left"><input class="easyui-textbox" style="width:250px" id="txtappaterno" value=""></td>
                    </tr>
                        <tr class="espacio"></tr>
                    <tr>
                        <td align="Left" class="auto-style2"><asp:Label ID="Label8" CssClass="LetraChicaNegrita"  runat="server" Text="Apellido Materno:"></asp:Label></td>
                        <td align="Left"><input class="easyui-textbox" style="width:250px" id="txtapmaterno" value=""></td>
                    </tr>
                        <tr class="espacio"></tr>
                    <tr>
                        <td align="Left" class="auto-style2"><asp:Label ID="Label19" CssClass="LetraChicaNegrita" runat="server" Text="Correo:"></asp:Label></td>
                        <td align="Left"><input class="easyui-textbox" style="width: 300px; height: 45px" id="txtcorreo" data-options="multiline:true"></td>
                    </tr>
                        <tr class="espacio"></tr>
                    <tr>                       
                      <td align="Left" class="auto-style2"><asp:Label ID="Label9" CssClass="LetraChicaNegrita"  runat="server" Text="Vigenia Inicial:"></asp:Label></td>
                      <td align="Left"><input class="easyui-datebox" style="width:100px" id="dtvigenciaini" value="" data-options="formatter:myformatter,parser:myparser"></td>
                    </tr>
                        <tr class="espacio"></tr>
                    <tr>                       
                      <td align="Left" class="auto-style2"><asp:Label ID="Label10" CssClass="LetraChicaNegrita"  runat="server" Text="Vigencia Final:"></asp:Label></td>
                      <td align="Left"><input class="easyui-datebox" style="width:100px" id="dtvigenciafin" data-options="formatter:myformatter,parser:myparser"></td>                        
                    </tr>
                        <tr class="espacio"></tr>
                    <tr>
                       <td align="Left" class="auto-style2"><asp:Label ID="Label11" CssClass="LetraChicaNegrita"  runat="server" Text="Grupo de Usuarios:"></asp:Label></td>
                       <td align="Left"><input class="easyui-combobox" style="width:300px" data-options="editable:false" id="cbotipousuario"></td>
                     </tr>
                        <tr class="espacio"></tr>
                    <tr>
                        <td align="Left" class="auto-style2"><asp:Label ID="Label4" CssClass="LetraChicaNegrita"  runat="server" Text="Permisos por Grupos:"></asp:Label></td>
                        <td align="Left"><a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search'" id="btnBGrupo">Buscar</a></td>
                    </tr>
                        <tr class="espacio"></tr>
                    <tr>
                        <td align="Left" class="auto-style2"><asp:Label ID="Label5" CssClass="LetraChicaNegrita"  runat="server" Text="Permisos Individuales:"></asp:Label></td>
                        <td align="Left"><a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search'" id="btnBPermisos">Buscar</a></td>
                    </tr>
                    <tr class="espacio"></tr>
                    <tr>
                         <td align="Left" class="auto-style2"><asp:Label ID="Label20" CssClass="LetraChicaNegrita"  runat="server" Text="Consulta Externa:"></asp:Label></td>
                         <td align="Left"><input type="checkbox" id="chkconexterna"></td>
                     </tr>
                        <tr class="espacio"></tr>
                    <tr>
                         <td align="Left" class="auto-style2"><asp:Label ID="Label12" CssClass="LetraChicaNegrita"  runat="server" Text="Administrador:"></asp:Label></td>
                         <td align="Left"><input type="checkbox" id="chkadmin"></td>
                     </tr>
                        <tr class="espacio"></tr>
                    <tr>
                         <td align="Left" class="auto-style2"><asp:Label ID="Label3" CssClass="LetraChicaNegrita"  runat="server" Text="Activo:"></asp:Label></td>
                         <td align="Left"><input type="checkbox" id="chkestatus"></td>
                    </tr>
                </table>
             </div>
        </div> 
          <div class="easyui-dialog" style="background-image: url('../../Imagenes/FONDO1.jpg'); overflow:hidden;" id="winroll" title="Permisos por Roles" closed="true">
            <div class="easyui-panel" style="padding:3px; width:100%">                                    
                 <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar'" id="btnLPermisos" >Limpiar</a>
                 <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'" id="btnGpermisos" >Guardar</a>                            
            </div>
            <div id="tproles" class="easyui-tabs" style="padding: 3px; width: 100%; height:93.9%; overflow:hidden;">
                 <div title="Menus" align="center" style="overflow:hidden;">
                      <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove',disabled:false" id="btnEMenus" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtFrolmenu"> 
                     <div class="easyui-panel" style=" width:100%;height:87%" >
                        <ul class="easyui-tree" id="lstRMenus" data-options="animate:true,lines:false,checkbox:true"></ul>
                     </div>                      
                 </div>               
                 <div title="Movimientos" align="center" style="overflow:hidden;">
                      <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEMovimientos" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtFrolmov"> 
                     <div class="easyui-panel" style="width:100%;height:87%" >
                        <ul class="easyui-tree" id="lstRMov" data-options="animate:true,lines:false,checkbox:true"></ul>
                     </div>                      
                 </div>
                  <div title="Procesos Especiales" align="center" style="overflow:hidden;">
                      <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEProEsp" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtFrolpe"> 
                     <div class="easyui-panel" style="width:100%;height:87%" >
                        <ul class="easyui-tree" id="lstRpe" data-options="animate:true,lines:false,checkbox:true"></ul>
                     </div>                      
                 </div>                   
                <div title="Terceros" align="center" style="overflow:hidden;">
                      <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnETerceros" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtFrolter"> 
                     <div class="easyui-panel" style="width:100%;height:87%" >
                        <ul class="easyui-tree" id="lstRTer" data-options="animate:true,lines:false,checkbox:true"></ul>
                     </div>                      
                 </div>
                 <div title="Reportes" align="center" style="overflow:hidden;">
                       <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEReportes" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtFrolrep"> 
                     <div class="easyui-panel" style="width:100%;height:87%" >
                        <ul class="easyui-tree" id="lstRRep" data-options="animate:true,lines:false,checkbox:true"></ul>
                     </div>                      
                 </div>
                <div title="Filtros" align="center" style="overflow:hidden;">
                       <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEFiltros" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtFrolfil"> 
                     <div class="easyui-panel" style="width:100%;height:87%" >
                        <ul class="easyui-tree" id="lstRFil" data-options="animate:true,lines:false,checkbox:true"></ul>
                     </div>                      
                 </div>
            </div>                                      
        </div>        
         <div class="easyui-dialog" style="background-image: url('../../Imagenes/FONDO1.jpg'); overflow:hidden" id="wrolindividual" title="Permisos Individuales" closed="true">
            <div class="easyui-panel" style="padding:3px; width:100%">                                    
                 <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar'" id="btnLPerInd" >Limpiar</a>
                 <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'" id="btnGPerInd" >Guardar</a>                 
            </div>
             <div id="tprorind" class="easyui-tabs" style="padding: 3px; width: 100%; height:93.9%">
                 <div title="Menus" align="left" style="overflow:hidden"">
                     <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                         <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEMenuInd" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtMenuInd"> 
                     <div class="easyui-panel" style=" width:100%;height:425px; overflow:auto" >
                        <ul class="easyui-tree" id="tmenusind" data-options="animate:true,lines:false,checkbox:true,cascadeCheck:false"></ul>
                     </div>             
                 </div>
                 <div title="Permisos Por Botones" align="center">
                     <div class="easyui-accordion" style="width:100%;height:100%; overflow:hidden">     
                        <div title="Creación de Plazas" align="center" style="overflow:hidden">
                            <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove',disabled:true" id="btnECreacionPLA" >Eliminar</a>
                           </div>
                            <table id="dgcreacionpla" class="easyui-datagrid" style="width:100%; height:500%;">     
                                <thead>
                                    <tr>
                                        <th data-options="field:'chk',checkbox:true"></th>
                                        <th data-options="field:'id',width:50,align:'left',halign:'center',hidden:true">id</th>
                                        <th data-options="field:'NombreTab',width:300,align:'left',halign:'center'">Menu</th>
                                        <th data-options="field:'PlaNormales',width:80,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Normal</th>
                                        <th data-options="field:'PlaInterinos',width:80,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Interinos</th>
                                        <th data-options="field:'PlaJubPen',width:110,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Jub/Pensionados</th>
                                        <th data-options="field:'PlaNoEmp',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">No Empleados</th>
                                    </tr>
                                </thead>
                           </table>
                       </div>
                       <div title="Por Catálogos" align="center" style="overflow:hidden">
                             <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove',disabled:true" id="btnECat" >Eliminar</a>
                            </div>
                            <table id="dgcat" class="easyui-datagrid" style="width:100%; height:500px;">     
                                <thead>
                                    <tr>
                                        <th data-options="field:'chk',checkbox:true"></th>
                                        <th data-options="field:'id',width:50,align:'left',halign:'center',hidden:true">id</th>
                                        <th data-options="field:'NombreTab',width:300,align:'left',halign:'center'">Catálogo</th>
                                        <th data-options="field:'Agregar',width:80,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Agregar</th>
                                        <th data-options="field:'Modificar',width:80,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Modificar</th>
                                        <th data-options="field:'Eliminar',width:80,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Eliminar</th>
                                        <th data-options="field:'Historia',width:80,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Historia</th>
                                        <th data-options="field:'Exportar',width:80,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Exportar</th>
                                        <th data-options="field:'Reportes',width:80,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Reportes</th>                                                                                
                                    </tr>
                                </thead>                                      
                            </table>              
                        </div>
                        <div title="Consultas de Historia" align="center" style="overflow:hidden">
                            <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                                <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnECon" >Eliminar</a>
                            </div>
                            <table id="dgcon" class="easyui-datagrid" style="width:100%; height:500px;">     
                                <thead>
                                    <tr>
                                        <th data-options="field:'chk',checkbox:true"></th>
                                        <th data-options="field:'id',width:50,align:'left',halign:'center',hidden:true">Id</th>
                                        <th data-options="field:'NombreTab',width:300,align:'left',halign:'center'">Consultas</th>
                                        <th data-options="field:'histmovper',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Mov. Personal </th>
                                        <th data-options="field:'histmovcon',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Mov. Conceptos</th>
                                        <th data-options="field:'histdatper',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Dat. Personales</th>
                                        <th data-options="field:'histreffam',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Ref. Familiares</th>
                                        <th data-options="field:'histmovesp',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Mov. Especiales</th>
                                        <th data-options="field:'histinclab',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Inc. Laborales</th>
                                        <th data-options="field:'histcapter',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Cap. Terceros</th>
                                        <th data-options="field:'histplazas',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Hist. Plazas</th>
                                        <th data-options="field:'histdetnom',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Det. Nomina</th>                                                                                
                                        <th data-options="field:'histimgexp',width:100,align:'center',halign:'center', editor:{type:'checkbox',options:{on:'Si',off:''}}">Img. Expediente</th>                                                                                
                                    </tr>
                                 </thead>                                      
                            </table>    
                        </div>
                      </div>
                 </div>
                 <div title="Movimientos" align="center">
                       <div class="easyui-accordion" style="width:100%;height:100%; overflow:hidden"> 
                            <div title="Movimientos de Personal" style="overflow:hidden;  padding:0px;" align="center">
                                <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                                    <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEMovPerInd" >Eliminar</a>
                                 </div>
                                <input class="easyui-textbox" style="width:100%" id="txtMovPerInd"> 
                                <div class="easyui-panel" style="width:100%;height:285px; overflow:auto" >
                                    <ul class="easyui-tree" id="tmovmpind" data-options="animate:true,lines:false,checkbox:true,cascadeCheck:false"></ul>
                                </div>       
                            </div> 
                <div title="Movimientos de Conceptos" style="overflow:hidden;  padding:0px;" align="center">
                     <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEMovConInd" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtMovConInd"> 
                     <div class="easyui-panel" style="width:100%;height:285px; overflow:auto" >
                        <ul class="easyui-tree" id="tmovmcind" data-options="animate:true,lines:false,checkbox:true,cascadeCheck:false"></ul>
                     </div>              
                </div> 
                <div title="Datos Personales" style="overflow:hidden;  padding:0px;" align="center">
                     <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEMovDPInd" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtMovDPInd"> 
                     <div class="easyui-panel" style="width:100%;height:285px; overflow:auto" >
                        <ul class="easyui-tree" id="tmovdpind" data-options="animate:true,lines:false,checkbox:true,cascadeCheck:false,expanded:true"></ul>
                     </div>                      
                </div> 
                <div title="Referencias Familiares" style="overflow:hidden;  padding:0px;" align="center">
                       <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEMovRFInd" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtmovRFInd"> 
                     <div class="easyui-panel" style="width:100%;height:285px; overflow:auto" >
                        <ul class="easyui-tree" id="tmovrfind" data-options="animate:true,lines:false,checkbox:true"></ul>
                     </div>           
                </div> 
                <div title="Incidencias Laborales" style="overflow:hidden;  padding:0px;" align="center">
                      <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEMovILInd" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtMovIncLab"> 
                     <div class="easyui-panel" style="width:100%;height:285px; overflow:auto" >
                        <ul class="easyui-tree" id="tmovilind" data-options="animate:true,lines:false,checkbox:true,cascadeCheck:false"></ul>
                     </div>        
                </div> 
                       </div>
                 </div>
                 <div title="Procesos Especiales" align="center">
                      <div class="easyui-accordion" style="width:100%;height:100%; overflow:hidden">    
                           <div title="Por Carga" style="overflow:hidden;  padding:0px;" align="center">
                                <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                                    <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEperxls" >Eliminar</a>
                                </div>
                                <input class="easyui-textbox" style="width:100%" id="txtperxls"> 
                                <div class="easyui-panel" style="width:100%;height:485px; overflow:auto" >
                                    <ul class="easyui-tree" id="tperxls" data-options="animate:true,lines:false,checkbox:true"></ul>
                                </div>                   
                          </div> 
                          <div title="Procesos Especiales" style="overflow:hidden;  padding:0px;" align="center">
                                <div class="easyui-panel" style="padding:3px; width:100%">                                                    
                                    <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnEperpe" >Eliminar</a>
                                </div>
                                <input class="easyui-textbox" style="width:100%" id="txtperpe"> 
                                <div class="easyui-panel" style="width:100%;height:485px; overflow:auto" >
                                    <ul class="easyui-tree" id="tperpe" data-options="animate:true,lines:false,checkbox:true"></ul>
                               </div>                   
                        </div> 
                   </div>
                 </div>
                  <div title="Terceros" align="center" style="overflow:hidden">
                       <div class="easyui-panel" style="padding:0px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnETerInd" >Eliminar</a>
                      </div>
                      <input class="easyui-textbox" style="width:100%" id="txtTerInd"> 
                      <div class="easyui-panel" style="width:100%;height:490px; overflow:auto" >
                        <ul class="easyui-tree" id="tterind" data-options="animate:true,lines:false,checkbox:true"></ul>
                     </div>    
                 </div>
                  <div title="Reportes" align="center" style="overflow:hidden">
                       <div class="easyui-panel" style="padding:0px; width:100%">                                                    
                        <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" id="btnERepInd" >Eliminar</a>
                      </div>
                     <input class="easyui-textbox" style="width:100%" id="txtRepInd"> 
                     <div class="easyui-panel" style="width:100%;height:430px; overflow:auto" >
                        <ul class="easyui-tree" id="trepoind" data-options="animate:true,lines:false,checkbox:true,cascadeCheck:false"></ul>
                     </div>           
                  </div>
             </div>                                                
        </div>       
        <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
           <div class="center w-screen h-screen items-center"  align="center" >
              <img alt="" src="../../Imagenes/ajax-loader.gif" />
           </div> 
        </div> 
      </div>   
</body>
</html>
