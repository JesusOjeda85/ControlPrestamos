var Org = "";
var NomRep = "";
var Reporte = "";
var Proceso = "";
var CargaInicial = "";
var checkedRows = [];
$(document).ready(function () {
    var org = $_GET('fkorg');
    if (org != undefined) { Org = org; }
    else { Org = ''; }
    var perfil = $_GET('perfil');
    if (perfil != undefined) { Perfil = perfil; }
    else { Perfil = ''; }
    var nomrep = $_GET('nomrep');
    if (nomrep != undefined) { NomRep = nomrep; }
    else { NomRep = ''; }
    var reporte = $_GET('Reporte');
    if (reporte != undefined) { Reporte = reporte; }
    else { Reporte = ''; }
    var proceso = $_GET('Proceso');
    if (proceso != undefined) { Proceso = proceso; }
    else { Proceso = ''; }
    var cargainicial = $_GET('CargaInicial');
    if (cargainicial != undefined) { CargaInicial = cargainicial; }
    else { CargaInicial = ''; }

    $('#lbl').text('Perfil: ' + Perfil + " / Reporte: " + NomRep);

    $('#btnBuscar').bind('click', function () { CARGAR_EMPLEADOS(""); });

    $('#btnBempleado').bind('click', function () { CARGAR_EMPLEADOS($('#txtvalor').textbox('getValue')); });

    var text = $('#txtvalor');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();
            CARGAR_EMPLEADOS(valor);
        }
    });

    $('#btnLimpiar').bind('click', function () {
        $('#pvista').empty();
    });

    $('#btnImpGeneral').bind('click', function () { IMPRESION_GENERAL('#btnImpGeneral'); });

    $('#btnImprimir').bind('click', function () { IMPRESION_GENERAL('#btnImprimir'); });

    $('#btnRegresar').bind('click', function () { $('#pvista').empty(); IR_PAGINA('Listar_Perfiles.aspx', ''); });

    if (CargaInicial == 'True') { IMPRESION_GENERAL('#btnImprimir'); }
});


function onCheck(index, row) {
    for (var i = 0; i < checkedRows.length; i++) {
        if (checkedRows[i].id == row.id) {
            return
        }
    }
    checkedRows.push(row);
}
function onUncheck(index, row) {
    for (var i = 0; i < checkedRows.length; i++) {
        if (checkedRows[i].id == row.id) {
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

function CARGAR_EMPLEADOS(filtro) {
    //if ($(btnobj).linkbutton('options').disabled) { return false; }
    //else {      
        var data = {
            Obj: {
                FkOrganismo: 1,
                Busqueda: (filtro == undefined ? filtro = "" : filtro)
            }
        }
        $.ajax({
            type: "POST",
            url: "Fun_Reportes.aspx/Buscar_Empleados",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            cache: "false",
            beforeSend: function () {
                $('#loading').show();
            },
            success: function (data) {
                if (data.d[0] == "0") {
                    obj = $.parseJSON(data.d[2]);
                    $('#dgempleados').datagrid({
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

    $('#loading').hide(100);    
    windows_porcentaje("#win", 90, 60, false, false, false, "Empleados");
    //}
}


function IMPRESION_GENERAL(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var Filtroa = "";

        if (checkedRows.length > 0) {
            for (var f = 0; f < checkedRows.length; f++) {
                Filtroa += checkedRows[f].id + ",";
            }
            Filtroa = Filtroa.substring(0, Filtroa.length - 1);
        }

        var parametros = {};
        parametros.FkOrganismo = Org;
        parametros.Filtros = Filtroa;
        parametros.Reporte = Reporte;
        parametros.Proceso = Proceso;

        $.ajax({
            type: "POST",
            url: '../ArchivosRdlc/Fun_Archivos.aspx/Generar_Archivos',
            data: JSON.stringify(parametros),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                $('#loading').show();
            },
            success: function (data) {
                if (data.d[0] == "1") { $.messager.alert('Error', data.d, 'error'); }
                else {  
                    $("#win").window('close');
                    $('#pvista').empty();
                    $('#pvista').empty().html('<embed id="evista" width="100%" height="100%" src="' + "../ArchivosRdlc/" + data.d[2] + '"></embed>')
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $('#loading').hide(100);
                $.messager.alert('Error', jqXHR.responseText, 'error');
            },
            complete: function () {
                $('#loading').hide(100);
            }
        });

    }
}