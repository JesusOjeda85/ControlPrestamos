<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Autorizacion.aspx.cs" Inherits="ControlDescuentos.Archivos.AplicarDescuentos.Autorizacion" %>

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
 
    <link rel="stylesheet" type="text/css" href="../../jqueryEsy/themes/metro-gray/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../../jqueryEsy/themes/icons.css"/>
  
    <script type="text/javascript" src="../../jqueryEsy/jquery.min.js"></script>
    <script type="text/javascript" src="../../jqueryEsy/jquery.easyui.min.js"></script>
      
    <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-detailview.js"></script>
     <script type="text/javascript" src="../../jqueryEsy/plugins/datagrid-cellediting.js"></script>
    <style type="text/css">
	   .textbox .textbox-text{
		   text-transform: uppercase;
	    }
</style>
    <script src="../../Scripts/Funsiones.js?v0.1"></script></head>
     <script src="Autorizacion.js?v0.4"></script>
<body>
    <div class="w-screen h-screen flex flex-col items-center" align="Center" style="background-color:#FCFDFF;">  
       <div class="easyui-panel mb-3" style="padding:2px; width:100%">              
          <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a>                    
          <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-ok',disabled:false" id="btnAplicar" >Aplicar</a>           
       </div>          
       <div class="flex flex-row space-x-2 w-1/2 mb-3 justify-center items-center ">           
             <asp:Label ID="Label2"  CssClass="text-blue-900" runat="server" Text="Tipo Puesto:"></asp:Label>    
             <div class="w-2/5">                   
                <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbotipopuesto" /> 
             </div>                 
       </div>    
         <%--  <div class="flex flex-row space-x-2 w-full justify-center items-center ">           
              <asp:Label ID="Label11"  CssClass="text-blue-900" runat="server" Text="Valor a Buscar:"></asp:Label>            
              <div class="w-2/5">
                <input type="text" value="" class="easyui-textbox" id="txtvalor" style="width:100%"/>
              </div>             
             <a id="btnBuscar" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:true">Buscar</a>            
         </div>    --%>
        <table class="easyui-datagrid " id="dgdatos" style="width:100%; height:90%;" > 
          <thead>
            <tr>                        
             <th data-options="field:'chk',checkbox:true"></th>   
             <th data-options="field:'RowNumber',width:50,align:'center',halign:'center',hidden:false">#</th>  
             <th data-options="field:'Id',width:90,align:'center',halign:'center',hidden:true">id</th>
             <th data-options="field:'Empleado',width:100,align:'center',halign:'center'">Empleado</th>
             <th data-options="field:'Rfc',width:130,align:'center',halign:'center'">Rfc</th>                                                  
             <th data-options="field:'Nombre',width:300,align:'left',halign:'center'">Nombre</th>
             <th data-options="field:'Plazo',width:100,align:'center',halign:'center'">Plazo</th>
             <th data-options="field:'ImporteCredito',width:100,align:'right',halign:'center',hidden:false">Credito</th>             
             <th data-options="field:'Liquidez',width:100,align:'right',halign:'center',hidden:false">Liquidez</th>
             <th data-options="field:'CreditoVigente',width:120,align:'right',halign:'center',hidden:false">Credito Vigente</th>
             <th data-options="field:'FondoAhorro',width:120,align:'right',halign:'center',hidden:false">Fondo de Ahorro</th>
           </tr>
        </thead>
     </table>             
  </div>            
     <div class="easyui-dialog flex flex-col items-center space-y-2" id="WAplicacion"  closed="true" style="padding:2px;background-color:#FCFDFF; overflow-y:hidden; overflow-x:auto ">
     <div class="easyui-panel mb-3" style="padding:2px; width:100%">                              
         <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-ok',disabled:false" id="btnAutorizar" >Autorizar</a>
     </div> 
     <div class="flex flex-col self-center px-1 py-1 w-full overflow-hidden">
        <div class="flex flex-col mb-1 ">
           <label class="text-left text-lg text-blue-900">Año</label>                    
           <input class="easyui-numberspinner" style="width:100%; text-align:center"  id="txtnumaño" data-options="readonly:false,spinAlign:'horizontal',editable:false"/>                   
        </div>
       <%-- <div class="flex flex-col mb-1 ">
                <label class="text-left text-lg text-blue-900">Emisión</label>                    
                <input class="easyui-numberbox" style="width:100%; text-align:center" " id="txtemision"   data-options="readonly:false"/>                   
        </div>  --%>
        <div class="flex flex-col mb-1 ">
                <label class="text-left text-lg text-blue-900">Fecha de Aplicación</label>                    
                <input class="easyui-datebox" style="width:100%; text-align:center" " id="dtfechaaplicacion"    data-options="formatter:myformatter,parser:myparser"/>                   
        </div>  
        <div class="flex flex-row py-2 justify-center items-center">
            <a href="#" id="btnOrd" class="easyui-linkbutton" data-options="plain:true,toggle:true,group:'gf',selected:true">Ordinaria</a>
            <a href="#" id="btnExt" class="easyui-linkbutton" data-options="plain:true,toggle:true,group:'gf'">ExtraOrdinaria</a>    
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
