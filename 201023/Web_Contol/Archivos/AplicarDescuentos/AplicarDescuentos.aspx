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

<link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/metro-red/easyui.css"/>
<link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/icon.css"/>	

 <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
 <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>
    <script src="../../Scripts/Funsiones.js"></script>
    <script src="AplicarDescuentos.js?v0.0"></script>
</head>
<body>
     <div class="bg-neutral-100 w-screen h-screen flex flex-col bg-yellow-50 " align="Center">   
          <div class="easyui-panel mb-3" style="padding:2px; width:100%">                 
                <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a>                  
                <a href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-save',disabled:false" id="btnAplicar" >Aplicar</a>                                                                     
           </div>  
         <div class="flex flex-col space-y-2 w-full h-full">
           <div class="flex flex-row space-x-2 w-full justify-center items-center ">           
                <asp:Label ID="Label11"  CssClass="LetraChicaNegrita" runat="server" Text="Valor a Buscar:"></asp:Label>            
                <div class="w-2/5">
                    <input type="text" value="" class="easyui-textbox" id="txtvalor" style="width:100%"/>
                </div>             
                <a id="btnBuscar" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:false">Buscar</a>            
            </div>         
            <table class="easyui-datagrid " id="dgdatos" style="width:100%; height:90%;"> 
                <thead>
                    <tr> 
                         <th data-options="field:'chk',checkbox:true"></th>    
                         <th data-options="field:'id',width:90,align:'center',halign:'center',hidden:true">id</th>
                        <th data-options="field:'Empleado',width:90,align:'center',halign:'center'">Empleado</th>
                        <th data-options="field:'Rfc',width:150,align:'center',halign:'center'">Rfc</th>                                                  
                        <th data-options="field:'Nombre',width:300,align:'left',halign:'center'">Nombre</th>                        
                        <th data-options="field:'ImporteCredito',width:100,align:'right',halign:'center',hidden:false">Credido</th>
                        <th data-options="field:'fkPlazo',width:180,align:'center',halign:'center',hidden:true">fkPlazo</th>
                        <th data-options="field:'Plazo',width:100,align:'center',halign:'center',hidden:false">Plazo</th>
                        <th data-options="field:'fkTipoPago',width:180,align:'center',halign:'center',hidden:true">fkTipoPago</th>
                        <th data-options="field:'TipoPago',width:100,align:'center',halign:'center',hidden:false">TipoPago</th>                       
                        <th data-options="field:'fkBanco',width:180,align:'center',halign:'center',hidden:true">fkBanco</th>
                        <th data-options="field:'Banco',width:100,align:'center',halign:'center',hidden:false">Banco</th>
                        <th data-options="field:'CuentaBancaria',width:180,align:'center',halign:'center',hidden:false">Cuenta</th>
                        <th data-options="field:'Categoria',width:180,align:'center',halign:'center',hidden:true">CveCategoria</th>
                        <th data-options="field:'DescCategoria',width:200,align:'left',halign:'center',hidden:true">Categoria</th>
                        <th data-options="field:'Adscripcion',width:180,align:'center',halign:'center',hidden:true">cveAdscripcion</th>
                        <th data-options="field:'DescAdscripcion',width:200,align:'left',halign:'center',hidden:true">Adscripcion</th>
                        <th data-options="field:'Pagaduria',width:180,align:'center',halign:'center',hidden:true">cvePagaduria</th>
                        <th data-options="field:'DescPagaduria',width:200,align:'left',halign:'center',hidden:true">Pagaduria</th>
                    </tr>
                </thead>
            </table>   
         </div>
     </div>  
      <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
         <div class="center w-screen h-screen items-center"  align="center" >
            <img alt="" src="../../Imagenes/ajax-loader.gif" />
         </div> 
       </div> 
</body>
</html>
