var Perfil = "";
var NomRep = "";
var Reporte = "";
$(document).ready(function () {
    var org = $_GET('fkorg');
    if (org != undefined) { fkorg = org; }
    else { fkorg = ''; }
    var perfil = $_GET('perfil');
    if (perfil != undefined) { Perfil = perfil; }
    else { Perfil = ''; }
    var nomrep = $_GET('nomrep');
    if (nomrep != undefined) { NomRep = nomrep; }
    else { NomRep = ''; }
    var reporte = $_GET('Reporte');
    if (reporte != undefined) { Reporte = reporte; }
    else { Reporte = ''; }

    $('#lbl').text('Perfil: ' + Perfil + " / Reporte: " + NomRep);

    $('#btnImpresion').bind('click', function () {
        if ($('#btnImpresion').linkbutton('options').disabled) { return false; }
        else {            
            report.print();
        }
    });
    $('#btnBuscar').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar', ""); });

    $('#btnRegresar').bind('click', function () { IR_PAGINA('Listar_Perfiles.aspx', ''); });

   
});
function onBodyLoad() {
    createViewer();  
    setReport();
}

function IR_PAGINA(url, parametros) {
    var strpagina = "";
    if (parametros != "") { strpagina = url + "?" + parametros; } else { strpagina = url; }
    $.ajax({
        url: url + "/GetResponse",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            if (data.d == true) {
                window.location = strpagina;
            }
        },
        error: function (a, b, c) {
            $('#loading').hide(100);
            $.messager.alert('Error', c, 'error');
        }
    });
}

function createViewer() {
    // Specify necessary options for the viewer
    var options = new Stimulsoft.Viewer.StiViewerOptions();
    options.height = "100%";
    options.toolbar._zoom = 150;
    options.appearance.scrollbarsMode = true;
    options.toolbar.showDesignButton = false;
    options.toolbar.showAboutButton = false;
    options.toolbar.showBookmarksButton = false;
    options.toolbar.showDesignButton = false;
    options.toolbar.showFindButton = false;
    options.toolbar.showFullScreenButton = false;
    options.toolbar.showSaveButton = false;
    options.toolbar.showParametersButton = false;
    options.toolbar.showViewModeButton = false;
    options.toolbar.showFirstPageButton = false;
    options.toolbar.showLastPageButton = false;
    options.toolbar.showZoomButton = false;
    options.toolbar.showNextPageButton = false;
    options.toolbar.showPreviousPageButton = false;
    options.toolbar.showCurrentPageControl = false;
    options.toolbar.showPrintButton = false;
    options.toolbar.printDestination = Stimulsoft.Viewer.StiPrintDestination.Direct;
    options.appearance.htmlRenderMode = Stimulsoft.Report.Export.StiHtmlExportMode.Table;
    options.toolbar.visible = false;

    Stimulsoft.Base.Localization.StiLocalization.setLocalizationFile("Localization/es.xml", true);

    // Create an instance of the viewer
    viewer = new Stimulsoft.Viewer.StiViewer(options, "StiViewer", false);

    viewer.renderHtml("viewerContent");

}
function setReport() {
    // Forcibly show process indicator
    viewer.showProcessIndicator();

    // tiempo necesario para mostrar el reporte signado
    setTimeout(function () {
        //crear la instancia del reporte
        report = new Stimulsoft.Report.StiReport();

        //cargar el repote desde una rita del directorio
        report.loadFile(Reporte+".mrt");

        //limpiar las base de datos de directorio de datos
        //report.dictionary.databases.clear();

        //asignar las variables del reporte para pasar los datos
        //var ArrarDatos = valores.split('|');
        //report._dictionary._variables._list[0].val = ArrarDatos[0];
        //report._dictionary._variables._list[1].val = ArrarDatos[1];
        //report._dictionary._variables._list[2].val = ArrarDatos[2];
        //report._dictionary._variables._list[3].val = ArrarDatos[3];

        //asignar el reporte al visor
        viewer.report = report;
    }, 50);
}


function CARGAR_EMPLEADOS(btnobj, filtro) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {

        if (filtro != "") { $('#txtvalor').textbox('setValue', filtro); }
        else { filtro = $('#txtvalor').textbox('getValue'); }

        if (filtro == undefined) { filtro = ""; }

        $('#dgempleados').datagrid({
            url: 'listar_Empleados.aspx?busqueda=' + filtro + "&fkorganismo=" + fkorg,
            pagination: true,
            enableFilter: true,
            rownumbers: true,
            singleSelect: true,
            striped: true,
            scroll: true,
            pageSize: 20,
            showPageList: false,
            onClickRow: function () {
                var row = $('#dgempleados').datagrid('getSelected');               
                $('#win').window('close');
            }
        });

        $('#loading').hide(100);
        windows_porcentaje("#win", 90, 60, false, false, false, "Permisos");
        // windows("#win", "90%", "60%", false, "Empleados");
    }
}