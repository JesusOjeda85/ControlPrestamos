<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captura_Retiros.aspx.cs" Inherits="ControlDescuentos.Archivos.Captura.Retiros.Captura_Retiros" %>

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
    <script src="../../../Scripts/Funsiones.js?v0.1"></script>
    <script src="Captura_Retiros.js?v1.1"></script>     
</head>
<body>   
     <div class="w-screen h-screen flex flex-col " align="Center" style="background-color:#FCFDFF;">              
          <div class="easyui-panel mb-3" style="padding:2px; width:100%">    
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'limpiar',disabled:false" id="btnLimpiar" >Limpiar</a> 
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search',disabled:false" id="btnBuscar" >Buscar</a>  
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save',disabled:false" id="btnGuardar" >Guardar</a>     
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save',disabled:true" id="btnEliminar" >Eliminar</a>
             <label id="lblconcepto" class="text-left font-black text-lg text-blue-900"></label> 
         </div>        
          <div class="flex flex-col self-center px-2 py-2 w-8/12 overflow-auto">   
                     <div class="flex flax-row space-x-2 justify-center items-center mb-4">              
                        <div class="easy-panel flex flex-col mb-1 w-1/2 ">
                            <div class="mb-2 justify-center items-center">
                               <label class="text-left text-lg text-blue-900">Seleccione el Tipo de Emisión</label>      
                            </div>
                            <a href="#" id="chkord" class="easyui-linkbutton mb-2" data-options="plain:true,toggle:true,group:'gf',selected:true"></a>
                            <a href="#" id="chkext" class="easyui-linkbutton mb-2" data-options="plain:true,toggle:true,group:'gf'"></a>                  
                        </div>
                    </div>
                  <hr size="8px" class="bg-blue-800 border-blue-800 mb-4" />
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Tipo de Puesto</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbotipopuesto"  data-options="required:false"/>                   
                       </div>
                       <div class="flex flex-col mb-1  w-1/2">
                            <label class="text-left text-lg text-blue-900">Motivo de Baja</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbomotivo" data-options="required:true"/>                                                                         
                        </div> 
                       <div class="flex flex-col mb-1  w-1/2">
                           <label class="text-left text-lg text-blue-900">Zona Pago</label>                    
                           <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbozonapago" data-options="required:true"/>                                                                         
                      </div> 
                   </div>
                    <div class="flex flax-row space-x-2">
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Paterno</label>                    
                            <input class="easyui-textbox uppercase" style="width:100%" id="txtpaterno"  data-options="readonly:false"/>                   
                        </div>                       
                        <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Materno</label>                                                 
                            <input class="easyui-textbox uppercase" style="width:100%; text-align:left"  id="txtmaterno" data-options="readonly:false"/>                                               
                        </div>                              
                    </div>
                    <div class="flex flax-row space-x-2">                          
                         <div class="flex flex-col mb-1 w-1/2  ">
                            <label class="text-left text-lg text-blue-900">Nombres</label>                    
                            <input class="easyui-textbox uppercase" style="width:100%" id="txtnombres"  data-options="readonly:false,required:true"/>                   
                        </div>
                        <div class="flex flex-col mb-1 w-1/2">
                            <label class="text-left text-lg text-blue-900">Rfc</label>                    
                            <input class="easyui-textbox uppercase" style="width:100%;" id="txtrfc"  data-options="readonly:false,required:true"/>                   
                        </div>
                    </div>                                                                                                    
                    <div class="flex flax-row space-x-2">
                         <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Importe Bruto</label>                    
                            <input data-tooltip-target="tooltip-bottom" class="easyui-numberbox" style="width:100%; text-align:right"  id="txtimpbruto" data-options="required:true,groupSeparator:',',precision:2"/>                                              
                          </div>
                         <div class="flex flex-col mb-1 w-1/2 ">
                             <label class="text-left text-lg text-blue-900">Importe Adeudo</label>                    
                            <input class="easyui-numberbox" style="width:100%; text-align:right"  id="txtimpadeudo" data-options="required:false,groupSeparator:',',precision:2"/>                   
                        </div>   
                         <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Importe Neto</label>                    
                            <input class="easyui-numberbox" style="width:100%; text-align:right"  id="txtimpneto" data-options="disabled:true,groupSeparator:',',precision:2"/>                   
                         </div>   
                    </div>   
                    <div class="flex flax-row space-x-2">
                       <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Tipo de Pago</label>                    
                            <input class="easyui-combobox" style="width:100%; text-align:left"  id="cbotipopago" data-options="required:true" />                   
                        </div>     
                         <div class="flex flex-col mb-1 w-1/2 ">
                             <label class="text-left text-lg text-blue-900">Cuenta Bancaria</label>                    
                             <input class="easyui-numberbox" style="width:100%; text-align:center"  id="txtcuenta" />                   
                         </div>
                          <div class="flex flex-col mb-1 w-1/2 ">
                            <label class="text-left text-lg text-blue-900">Fecha Solicitud</label>                    
                            <input class="easyui-datebox" style="width:100%" id="dbfecSolicitud" data-options="formatter:myformatter,parser:myparser,required:true"/>                
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
         <table class="easyui-datagrid " id="dgdatos" style="width:100%; height:100%;"> 
            <thead>
                <tr>                    
                    <th data-options="field:'Id',width:100,align:'center',halign:'center',hidden:true">Id</th>
                    <th data-options="field:'Nomcom',width:300,align:'left',halign:'center'">Nombre</th>                          
                    <th data-options="field:'Rfc',width:130,align:'center',halign:'center'">Rfc</th>                    
                    <th data-options="field:'Paterno',width:180,align:'center',halign:'center',hidden:true">Paterno</th>
                    <th data-options="field:'Materno',width:180,align:'center',halign:'center',hidden:true">Materno</th>
                    <th data-options="field:'Nombre',width:180,align:'center',halign:'center',hidden:true">Nombre</th> 
                    <th data-options="field:'fkTipoPuesto',width:80,align:'center',halign:'center',hidden:true">fkTipoPuesto</th>
                    <th data-options="field:'fkMotivoBaja',width:80,align:'center',halign:'center',hidden:true">fkMotivoBaja</th>
                    <th data-options="field:'fkZonaPago',width:80,align:'center',halign:'center',hidden:true">fkZonaPago</th>                    
                    <th data-options="field:'fkTipoPago',width:80,align:'center',halign:'center',hidden:true">fkTipoPago</th>
                    <th data-options="field:'FecSolicitud',width:80,align:'center',halign:'center',hidden:true">FecSolicitud</th>
                    <th data-options="field:'CuentaBancaria',width:80,align:'center',halign:'center',hidden:true">CuentaBancaria</th>
                    <th data-options="field:'ImporteBruto',width:80,align:'center',halign:'center',hidden:false">Importe</th>                    
                    <th data-options="field:'ImporteAdeudo',width:80,align:'center',halign:'center',hidden:false">Adeudo</th>                    
                    <th data-options="field:'ImporteNeto',width:80,align:'center',halign:'center',hidden:false">Neto</th>                    
                    <th data-options="field:'NumExt',width:80,align:'center',halign:'center',hidden:true">TipoNomina</th>                    
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