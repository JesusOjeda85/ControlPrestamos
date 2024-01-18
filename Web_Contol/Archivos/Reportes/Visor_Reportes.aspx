<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visor_Reportes.aspx.cs" Inherits="ControlDescuentos.Archivos.Reportes.Visor_Reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>     
<meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />     
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css"/>    
        <link href="../../tailwinds/static/dist/tailwind.css" rel="stylesheet" />
        <link href="../../Styles/tema.css" rel="stylesheet" />
        <link href="../../Styles/loader.css" rel="stylesheet" />
        <link rel="stylesheet" type="text/css" href="../../jqueryesy/themes/metro-gray/easyui.css"/>
        <link href="../../jqueryEsy/themes/icons.css" rel="stylesheet" />

        <script type="text/javascript" src="../../scripts/jquery-1.11.1.min.js"></script>
        <script type="text/javascript" src="../../scripts/demos.js"></script>

        <script type="text/javascript" src="../../jqueryesy/jquery.min.js"></script>
        <script type="text/javascript" src="../../jqueryesy/jquery.easyui.min.js"></script>
        <script src="../../Scripts/Funsiones.js"></script>
        <script src="Visor_Reportes.js"></script>
        <script type="text/javascript">       
            function Print() {
         //var report = document.getElementById("<%=rvVista.ClientID %>");
         var div = report.getElementsByTagName("DIV");
         var reportContents;
         for (var i = 0; i < div.length; i++) {
             if (div[i].id.indexOf("VisibleReportContent") != -1) {
                 reportContents = div[i].innerHTML;
                 break;
             }
         }

         var frame1 = document.createElement('iframe');
         frame1.name = "frame1";
         frame1.style.position = "absolute";
         frame1.style.top = "-1000000px";
         document.body.appendChild(frame1);
         var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
         frameDoc.document.open();
         frameDoc.document.write('<html><head><title>RDL Report</title>');
         frameDoc.document.write('</head><body style = "font-family:arial;font-size:10pt;">');
         frameDoc.document.write(reportContents);
         frameDoc.document.write('</body></html>');
         frameDoc.document.close();

         setTimeout(function () {
             window.frames["frame1"].focus();
             window.frames["frame1"].print();
             document.body.removeChild(frame1);
         }, 500);
     }
        </script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="w-screen h-screen" align="Center" style="background-color:#FCFDFF;">
             <div class="easyui-panel mb-0" style="padding:2px; width:100%; ">   
                <a id="btnRegresar" href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'anterior'" >Regresar</a> 
                <a id="btnBuscar" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search',plain:false">Buscar</a>
                <a id="btnImpresion" href="#" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-impbarras16',disabled:true" >Imprimir</a>   
                <label id="lbl" class="text-left font-black text-lg text-blue-900"></label> 
            </div>           
           <%--<rsweb:ReportViewer ID="rvVista" Width="100%" Height="95%" runat="server"></rsweb:ReportViewer>--%>
           <embed src="files/Brochure.pdf#toolbar=0&navpanes=0&scrollbar=0" type="application/pdf" width="100%" height="95%" />
        </div>
         <div class="modal w-screen h-screen items-center" style="display: none;" id="loading" align="center">
            <div class="center w-screen h-screen items-center"  align="center" >
                <img alt="" src="../../Imagenes/ajax-loader.gif" />
            </div>       
        </div> 
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
