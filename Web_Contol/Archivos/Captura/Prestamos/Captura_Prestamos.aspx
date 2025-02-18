<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captura_Prestamos.aspx.cs" Inherits="ControlDescuentos.Archivos.Captura.Captura_Prestamos" %>

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
    <script src="Captura_Prestamos.js?v1.0"></script>    
</head>
<body>   
     <div class="w-screen h-screen flex flex-col " align="Center" style="background-color:#FCFDFF;">              
          <div class="easyui-panel mb-3" style="padding:2px; width:100%">  
           <%-- <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'anterior'" id="btnRegresar">Regresar</a> --%>
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a> 
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search',disabled:true" id="btnBuscar" >Buscar</a>
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save',disabled:false" id="btnGuardar" >Guardar</a>
              <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save',disabled:true" id="btnEliminar" >Eliminar</a>
             <label id="lblconcepto" class="text-left font-black text-lg text-blue-900"></label> 
         </div>        
          <div class="flex flex-col self-center px-2 py-2 w-8/12 overflow-auto">   
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Tipo de Puesto</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbotipopuesto"  data-options="required:false"/>                   
                       </div>
                       <div class="flex flex-col mb-1  w-1/2">
                            <label class="text-left text-lg text-blue-900">Concepto</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:left"  id="cboconceptos" data-options="required:true"/>                                                                         
                        </div> 
                       <div class="flex flex-col mb-1  w-1/2">
                           <label class="text-left text-lg text-blue-900">Zona Pago</label>                    
                           <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbozonapago" data-options="required:true"/>                                                                         
                      </div> 
                   </div>
                    <div class="flex flax-row space-x-2">
                         <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Empleado</label>   
                            <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtempleado"  data-options="readonly:true,required:true"/>  
                            <%--   <div class="flex flex-row ">                                                                        
                                <div class="flex flex-row w-full px-4 space-x-2 ">        
                                <a id="btnBuscar" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:false">Buscar</a>            
                                </div>                                 
                                </div>       --%>                 
                         </div>
                        <div class="flex flex-col mb-1 w-1/2">
                            <label class="text-left text-lg text-blue-900">Rfc</label>                    
                            <input class="easyui-textbox uppercase" style="width:100%;" id="txtrfc"  data-options="readonly:true,required:true"/>                   
                        </div>     
                        <div class="flex flex-col mb-1 w-1/2">
                            <label class="text-left text-lg text-blue-900">Curp</label>                    
                            <input class="easyui-textbox uppercase" style="width:100%;" id="txtcurp"  data-options="readonly:true,required:true"/>                   
                        </div>     
                    </div>
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Paterno</label>                    
                            <input class="easyui-textbox uppercase" style="width:100%" id="txtpaterno"  data-options="readonly:true"/>                   
                        </div>                       
                         <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Materno</label>                                                 
                            <input class="easyui-textbox uppercase" style="width:100%; text-align:left"  id="txtmaterno" data-options="readonly:true"/>                                               
                        </div>  
                         <div class="flex flex-col mb-1 w-1/2  ">
                            <label class="text-left text-lg text-blue-900">Nombres</label>                    
                            <input class="easyui-textbox uppercase" style="width:100%" id="txtnombres"  data-options="readonly:true"/>                   
                        </div>
                    </div>                                                                            
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Telefono 1</label>                    
                            <input class="easyui-textbox"  style="width:100%; text-align:center"  id="txttelefono1"  data-options="required:false"/>                   
                        </div>     
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Telefono 2</label>                    
                            <input class="easyui-textbox"  style="width:100%; text-align:center"  id="txttelefono2"  data-options="required:false"/>                   
                        </div>
                    </div>                    
                    <div class="flex flax-row space-x-2">
                         <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Importe Otorgado</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:left"  id="cboimporte" data-options="required:true"/>                   
                          </div>
                         <div class="flex flex-col mb-1 w-1/2 ">
                             <label class="text-left text-lg text-blue-900">Plazo</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:left"  id="cboplazos" data-options="required:true"/>                   
                        </div>                                           
                    </div>   
                    <div class="flex flax-row space-x-2">
                       <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Tipo de Pago</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbotipopago"  data-options="required:true"/>                   
                        </div>     
                         <div class="flex flex-col mb-1 w-1/2 ">
                             <label class="text-left text-lg text-blue-900">Cuenta Bancaria</label>                    
                             <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtcuenta"  data-options="required:false    "/>                   
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
                    <th data-options="field:'id',width:80,align:'center',halign:'center'">Id</th>
                    <th data-options="field:'empleado',width:100,align:'center',halign:'center'">Empleado</th>
                    <th data-options="field:'nomcom',width:300,align:'left',halign:'center'">Nombre</th>                          
                    <th data-options="field:'rfc',width:130,align:'center',halign:'center'">Rfc</th>
                    <th data-options="field:'curp',width:180,align:'center',halign:'center'">Curp</th>                        
                    <th data-options="field:'paterno',width:180,align:'center',halign:'center',hidden:true">Paterno</th>
                    <th data-options="field:'materno',width:180,align:'center',halign:'center',hidden:true">Materno</th>
                    <th data-options="field:'nombre',width:180,align:'center',halign:'center',hidden:true">Nombre</th>  
                    <th data-options="field:'fkTipoPuesto',width:80,align:'center',halign:'center',hidden:true">fkTipoPuesto</th>
                    <th data-options="field:'fkConcepto',width:80,align:'center',halign:'center',hidden:true">fkConcepto</th>
                    <th data-options="field:'fkZonaPago',width:80,align:'center',halign:'center',hidden:true">fkZonaPago</th>
                    <th data-options="field:'ImporteCredito',width:80,align:'center',halign:'center',hidden:true">ImporteCredito</th>
                    <th data-options="field:'PlazoAños',width:80,align:'center',halign:'center',hidden:true">PlazoAños</th>
                    <th data-options="field:'fkTipoPago',width:80,align:'center',halign:'center',hidden:true">fkTipoPago</th>
                    <th data-options="field:'CuentaBancaria',width:80,align:'center',halign:'center',hidden:true">CuentaBancaria</th>
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
