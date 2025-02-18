var Org = "";
var NomRep = "";
var Reporte = "";
var Proceso = "";
var checkedRows = [];

$(document).ready(function () {
    //var org = $_GET('fkorg');
    //if (org != undefined) { Org = org; }
    //else { Org = ''; }
    //var perfil = $_GET('perfil');
    //if (perfil != undefined) { Perfil = perfil; }
    //else { Perfil = ''; }
    var nomrep = $_GET('nomrep');
    if (nomrep != undefined) { NomRep = nomrep; }
    else { NomRep = ''; }
    //var reporte = $_GET('Reporte');
    //if (reporte != undefined) { Reporte = reporte; }
    //else { Reporte = ''; }
    //var proceso = $_GET('Proceso');
    //if (proceso != undefined) { Proceso = proceso; }
    //else { Proceso = ''; }

  
    if (NomRep == 'Saldos') {
        $('#loading').show();
        IMPRESION_PROCESOS('Saldos', 'Listar_Saldos@dtSaldos');
    }
    $('#btnExportar').click(function (e) {
        window.open('Descargar_Excel.aspx?Fileid=' + nomrep.replace(".pdf", ""));
    });
});

function IMPRESION_PROCESOS( reporte, proceso) {
    
        //if (checkedRows.length == 0) { $.messager.alert('Error', 'Falta seleccionar por lo menos un empleado', 'error'); return 0; }
        //else {
        //    // $('#dgprocesos').datagrid('acceptChanges');
        //    var filtro = [];
        //    for (var s = 0; s < checkedRows.length; s++) {
        //        filtro += checkedRows[s].Empleado + ",";
        //    }
        //    if (filtro.length > 0) { filtro = filtro.substring(0, filtro.length - 1); } else { filtro = 0; }

            var parametros = {};
            parametros.FkOrganismo = '';
            parametros.Filtros = '';
            parametros.Reporte = reporte;
            parametros.Proceso = proceso;
            parametros.Modulo = "";
            parametros.ChequesNulos = 0;
            parametros.ImpresionCH = 0;

            $.ajax({
                type: "POST",
                url: '../ArchivosRdlc/Fun_Archivos.aspx/Generar_Archivos',
                data: JSON.stringify(parametros),
                async: true,
                cache: false,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {
                    $('#loading').show();
                },
                success: function (data) {
                    if (data.d[0] == "1") { $.messager.alert('Error', data.d[1], 'error'); }
                    else {                     
                        $('#rwvista').empty().html('<embed id="evista" width="100%" height="100%" src="' + "../ArchivosRdlc/" + data.d[2] + '"></embed>')
                    }
                },
                error: function (er) {
                    $('#loading').hide();
                    $.messager.alert('Error', er.responseJSON.Message, 'error');
                },
                complete: function () {
                    $('#loading').hide(100);
                }
            });
       
    //}
}