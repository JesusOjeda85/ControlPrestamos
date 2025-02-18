<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_SlideBarV1.aspx.cs" Inherits="ControlDescuentos.Archivos.Menu.Menu_SlideBarV1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta http-equiv="Expires" content="0"/>
<meta http-equiv="Last-Modified" content="0"/>
<meta http-equiv="Cache-Control" content="no-cache, mustrevalidate"/>
<meta http-equiv="Pragma" content="no-cache"/>
     <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

     <meta charset="UTF-8"/>
     <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
     <meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
     <link href="https://cdn.lineicons.com/4.0/lineicons.css" rel="stylesheet" />
     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css"/>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" 
         integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <%-- <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet"
       integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>   --%>
     
    <link href="../../tailwinds/static/dist/tailwind.css" rel="stylesheet" />
    <link href="../../Styles/tema.css" rel="stylesheet" />
    <link href="../../Styles/loader.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="../../jqueryEsy/themes/metro-gray/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../../jqueryEsy/themes/icons.css"/>
 
    <script type="text/javascript" src="../../jqueryEsy/jquery.min.js"></script>
    <script type="text/javascript" src="../../jqueryEsy/jquery.easyui.min.js"></script>
   
    <link href="css/style.css" rel="stylesheet" />      
    <script type="text/javascript">
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () {
            null
        };
    </script>
</head>
<body>
    <div class="wrapper">
     <aside id="sidebar">
         <div class="d-flex">
             <button class="toggle-btn" type="button">
                 <i class="lni lni-grid-alt"></i>
             </button>
             <div class="sidebar-logo">
                 <a href="#">Prestamos</a>
             </div>
         </div>
         <ul class="sidebar-nav" id="Menu">            
            <%-- <li class="sidebar-item" style="display:none" id="btnCaptura">
                 <a href="#" class="sidebar-link"  >
                     <i class="bi bi-keyboard"></i>                     
                     <span>Captura</span>
                 </a>
             </li>--%>
            <li class="sidebar-item" style="display:none" id="btnCaptura">
                <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                    data-bs-target="#Cap" aria-expanded="false" aria-controls="Capturas">
                    <i class="bi bi-keyboard"></i>
                    <span>Capturas</span>
                </a>
                <ul id="Cap" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar" >
                    <li class="sidebar-item"  id="dmPrestamos">
                        <a href="#" class="sidebar-link" >Préstamos</a>
                    </li>
                    <li class="sidebar-item"  id="dmRetiros">
                        <a href="#" class="sidebar-link" >Retiros</a>
                    <%--</li>--%>
                    <li class="sidebar-item"  id="dmSiniestros">
                        <a href="#" class="sidebar-link" >Siniestros</a>
                    </li>
                </ul>
            </li>
            <li class="sidebar-item" style="display:none" id="btnCancelaciones">
               <a href="#" class="sidebar-link"  >
                    <i class="bi bi-x-circle"></i>
                <span>Cancelación de Préstamos</span>
              </a>
           </li>
           <li class="sidebar-item" style="display:none" id="btnPagosExternos">
                <a href="#" class="sidebar-link"  >
                    <i class="bi bi-paypal"></i>
                <span>Abono a Préstamos</span>
                </a>
            </li>
             <li class="sidebar-item" style="display:none" id="btnAplicacion">
                 <a href="#" class="sidebar-link" >
                     <i class="bi bi-bookmark-check"></i>
                     <span>Autorización de Préstamos</span>
                 </a>
             </li>
             <li class="sidebar-item" style="display:none" id="btnProduccionPrestamos">
                 <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                    data-bs-target="#ProdP" aria-expanded="false" aria-controls="Produccion">
                    <i class="bi bi-currency-dollar"></i>
                    <span>Producción Préstamos</span>
                 </a>
                 <ul id="ProdP" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar" >
                    <li class="sidebar-item"  id="dmNumeracionPrestamos">
                        <a href="#" class="sidebar-link" >Numeración</a>
                    </li>
                    <li class="sidebar-item"  id="dmImpresionEmisionPrestamos">
                        <a href="#" class="sidebar-link" >Impresión</a>
                    </li>
                    <li class="sidebar-item"  id="dmRenumeracionPrestamos">
                        <a href="#" class="sidebar-link" >Renumeración</a>
                    </li>
                </ul>
             </li>
             <li class="sidebar-item" style="display:none" id="btnProduccionRetiros">
                <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                    data-bs-target="#ProdR" aria-expanded="false" aria-controls="Produccion">
                    <i class="bi bi-person-fill-down"></i>
                    <span>Producción Retiros</span>
                </a>
                <ul id="ProdR" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar" >
                    <li class="sidebar-item"  id="dmNumeracionRetiros">
                        <a href="#" class="sidebar-link" >Numeración</a>
                    </li>
                    <li class="sidebar-item"  id="dmImpresionEmisionRetiros">
                        <a href="#" class="sidebar-link" >Impresión</a>
                    </li>
                    <li class="sidebar-item"  id="dmRenumeracionRetiros">
                        <a href="#" class="sidebar-link" >Renumeración</a>
                    </li>
                </ul>
             </li>
             <li class="sidebar-item" style="display:none" id="btnProduccionSiniestros">
                <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                    data-bs-target="#ProdS" aria-expanded="false" aria-controls="Produccion">
                    <i class="bi bi-person-fill-exclamation"></i>
                    <span>Producción Siniestros</span>
                </a>
                <ul id="ProdS" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar" >
                    <li class="sidebar-item"  id="dmNumeracionSiniestros">
                        <a href="#" class="sidebar-link" >Numeración</a>
                    </li>
                    <li class="sidebar-item"  id="dmImpresionEmisionSiniestros">
                        <a href="#" class="sidebar-link" >Impresión</a>
                    </li>
                    <li class="sidebar-item"  id="dmRenumeracionSiniestros">
                        <a href="#" class="sidebar-link" >Renumeración</a>
                    </li>
                </ul>
            </li>
             <li class="sidebar-item" style="display:none" id="btnImportacion">
                 <a href="#" class="sidebar-link" >
                     <i class="lni lni-download"></i>
                     <span>Préstamos Aplicados</span>
                 </a>
             </li>
             <li class="sidebar-item" style="display:none" id="btnExportacion">
                 <a href="#" class="sidebar-link"  >
                     <i class="lni lni-upload"></i>
                     <span>Préstamos a Aplicar</span>
                 </a>
             </li> 
             

              <li class="sidebar-item" style="display:none" id="btnDevoluciones">
                <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                    data-bs-target="#Ded" aria-expanded="false" aria-controls="Produccion">
                        <i class="bi bi-arrow-clockwise"></i>
                            <span>Devoluciones</span>
               </a>
                <ul id="Ded" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar" >
                    <li class="sidebar-item"  id="dmDevoluciones">
                        <a href="#" class="sidebar-link" >Captura</a>
                    </li>
                    <li class="sidebar-item"  id="dmImpDevoluciones">
                        <a href="#" class="sidebar-link" >Impresión</a>
                    </li>
                    <li class="sidebar-item"  id="dmRemDevoluciones">
                        <a href="#" class="sidebar-link" >Modificación</a>
                    </li>
                </ul>
            </li>


             <li class="sidebar-item" style="display:none" id="btnConsulta">
                <a href="#" class="sidebar-link" >
                    <i class="bi bi-search"></i>
                    <span>Consulta</span>
                </a>
            </li>            
            <li class="sidebar-item" style="display:none" id="btnReportes">
               <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                  data-bs-target="#rep" aria-expanded="false" aria-controls="Padrones">
                  <i class="bi bi-printer"></i>
                    <span>Reportes</span>
               </a>
               <ul id="rep" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar" >
                  <li class="sidebar-item"  id="dmImpresionEmp">
                    <a href="#" class="sidebar-link" >Impresión por Empleado</a>
                  </li>
                  <li class="sidebar-item"  id="dmSaldos">
                    <a href="#" class="sidebar-link" >Reporte de Saldos</a>
                  </li>                    
              </ul>
             </li>  
             <li class="sidebar-item" style="display:none" id="btnPadrones">
                 <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                    data-bs-target="#auth" aria-expanded="false" aria-controls="Padrones">
                     <i class="bi bi-journals"></i>
                     <span>Padrones</span>
                 </a>
                 <ul id="auth" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar" >
                     <li class="sidebar-item"  id="dmLiquidez">
                         <a href="#" class="sidebar-link" >Liquidez</a>
                     </li>
                     <li class="sidebar-item"  id="dmPadronEmp">
                        <a href="#" class="sidebar-link" >Padron de Empleados</a>
                     </li>
                 </ul>
             </li>                       
              <li class="sidebar-item" style="display:none" id="btnConfiguracion">
                <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                    data-bs-target="#config" aria-expanded="false" aria-controls="Configuracion">
                    <i class="lni lni-cog"></i>
                    <span>Configuración</span>
                </a>
                <ul id="config" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar" >
                    <li class="sidebar-item"  id="dmUsuarios">
                        <a href="#" class="sidebar-link">Usuarios</a>
                    </li>               
                </ul>
            </li>  
         </ul>
         <div>
             <a href="#" class="sidebar-link" id="btnCerrar">
                 <i class="lni lni-exit"></i>
                 <span>Salida</span>
             </a>           
         </div>
     </aside>
     <div class="main ">
         <div id="tt" class="easyui-tabs" style="width:100%; height:100%; display:none;"></div>  
     </div>
 </div>
     <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
        <div class="center w-screen h-screen items-center"  align="center" >
           <img alt="" src="../../Imagenes/ajax-loader.gif" />
        </div> 
      </div> 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"
      integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe"
      crossorigin="anonymous"></script>
    <script src="script/script.js"></script> 
   <script src="Menu_SlideBar.js?v0.7"></script>
</body>
</html>
