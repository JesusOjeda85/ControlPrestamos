﻿var checkedRows = [];
var NomRep = "";
var boton = "";
$(document).ready(function () {
    CARGAR_PROCESOS();

    $('#btnImpresionRevision').bind('click', function () {
        IMPRESION_PROCESOS('#btnImpresionRevision', 'RevisionCaptura_S');      
    });

    $('#btnLimpiar').bind('click', function () { CARGAR_PROCESOS(); });
});


function onCheck(index, row) {
    for (var i = 0; i < checkedRows.length; i++) {
        if (checkedRows[i].Emision == row.Emision) {
            return
        }
    }
    checkedRows.push(row);
}

function onUncheck(index, row) {
    for (var i = 0; i < checkedRows.length; i++) {
        if (checkedRows[i].Emision == row.Emision) {
            checkedRows.splice(i, 1);
            return;
        }
    }
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

function CARGAR_PROCESOS() {
    var data = {
        Obj: {
            Modulo: "S"
        }
    }
    $.ajax({
        type: "POST",
        url: "../Fun_Captura.aspx/LISTAR_REVISION_CAPTURA",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        cache: "false",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            if (data.d[0] == "0") {
                obj = $.parseJSON(data.d[2]);
                $('#dgprocesos').datagrid({
                    data: obj,
                    pagination: false,
                    rownumbers: false,
                    scroll: true,
                    pageSize: 20,
                    onCheck: onCheck,
                    onUncheck: onUncheck,
                    onCheckAll: function () {
                        var allRows = $(this).datagrid('getRows');
                        checkedRows = allRows;
                    },
                    onUncheckAll: function () {
                        checkedRows = [];
                    },
                    onBeforeEdit: function (index, row) {
                        var dg = $(this);
                        dg.datagrid('checkRow', index);
                    },
                    error: function (err) {
                        $('#loading').hide(100);
                        $.messager.alert('Error', err.statusText, 'error');
                    },
                    complete: function () {
                        $('#loading').hide(100);
                    },
                });
            }
            else { $.messager.alert('Error', "No existen datos a mostrar", 'error'); }
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', err.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.status === 0) {

            alert('Not connect: Verify Network.');

        } else if (jqXHR.status == 404) {

            alert('Requested page not found [404]');

        } else if (jqXHR.status == 500) {

            alert('Internal Server Error [500].');

        } else if (textStatus === 'parsererror') {

            alert('Requested JSON parse failed.');

        } else if (textStatus === 'timeout') {

            alert('Time out error.');

        } else if (textStatus === 'abort') {

            alert('Ajax request aborted.');

        } else {

            alert('Uncaught Error: ' + jqXHR.responseText);

        }
    });

}

function IMPRESION_PROCESOS(btnobj, reporte) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if (checkedRows.length == 0) { $.messager.alert('Error', 'Falta seleccionar por lo menos un proceso', 'error'); return 0; }
        else {           
                    $('#dgprocesos').datagrid('acceptChanges');
                    var filtro = [];
                    for (var s = 0; s < checkedRows.length; s++) {
                        filtro += "''" + checkedRows[s].Emision + "'',";
                    }
                    if (filtro.length > 0) { filtro = filtro.substring(0, filtro.length - 1); } else { filtro = 0; }
                   
                    var parametros = {};   
                    parametros.FkOrganismo = "";
                    parametros.Filtros = filtro;
                    parametros.Reporte = reporte;
                    parametros.Proceso = "Revision_Captura@dtSiniestros";
                    parametros.Modulo = "S";
                    parametros.ChequesNulos = 0;
                    parametros.ImpresionCH = 0;
                    
                    $.ajax({
                        type: "POST",
                        url: '../../ArchivosRdlc/Fun_Archivos.aspx/Generar_Archivos',
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
                                NomRep = data.d[2];
                                IR_PAGINA("../Captura_Vista_Previa.aspx", "Mod=S&Pag=Impresion_Revision_S&NomRep=" + NomRep);
                            }
                        },
                        error: function (er) {
                            $('#loading').hide();
                            $.messager.alert('Error', er.responseJSON.Message, 'error');
                        },
                        complete: function () {
                            $('#loading').hide();
                        }
                    });
                }
        }
    }

