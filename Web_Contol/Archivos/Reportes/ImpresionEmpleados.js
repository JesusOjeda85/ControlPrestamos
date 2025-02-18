var checkedRows = [];
var buscando = false;
$(document).ready(function () {
    CARGAR_PROCESOS("");

    $('#btnPagare').bind('click', function () { IMPRESION_PROCESOS('#btnPagare', 'Pagare','Salida_Emisiones@dtPagare',0); });

    $('#btnCheque').bind('click', function () { IMPRESION_PROCESOS('#btnCheque', 'ChequeStd','Salida_Emisiones@dtPagare',1); });

    $('#btnListado').bind('click', function () { IMPRESION_PROCESOS('#btnListado', 'ListadoFirmas', 'Salida_Emisiones@dtPagare',1); });

    $('#btnSaldos').bind('click', function () { IMPRESION_PROCESOS('#btnSaldos', 'Saldos', 'Listar_Saldos@dtSaldos',0); });

    $('#btnRegresar').bind('click', function () {
        $("#ddatos").show();
        $("#dvista").hide();
        $('#pvista').empty();      
    });

    $('#btnLimpiar').bind('click', function () {
        if (buscando == true) { CARGAR_PROCESOS(""); }
        else { LIMPIAR_SELECCION_GRID('#dgprocesos', true); }        
        $('#txtvalor').textbox('setValue', '');
    });

    var text = $('#txtvalor');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();
            buscando = true;
            CARGAR_PROCESOS(valor);
        }
    });

    $('#btnBuscar').bind('click', function () { buscando = true; CARGAR_PROCESOS($('#txtvalor').textbox('getValue')); });

    TXTFOCUS('#txtvalor');
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
        if (checkedRows[i].Id == row.Id) {
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


function CARGAR_PROCESOS(filtro) {
   
    var data = {
        Obj: {           
            Condicion: (filtro == undefined ? filtro = "" : filtro)
        }
    }
   
    $.ajax({
        type: "POST",
        url: "Fun_Reportes.aspx/Buscar_Empleados",
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

function IMPRESION_PROCESOS(btnobj, reporte, proceso,chequesNulos) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if (checkedRows.length == 0) { $.messager.alert('Error', 'Falta seleccionar por lo menos un empleado', 'error'); return 0; }
        else {
           // $('#dgprocesos').datagrid('acceptChanges');
            var filtro = [];
            for (var s = 0; s < checkedRows.length; s++) {
                filtro += checkedRows[s].Empleado + ",";
            }
            if (filtro.length > 0) { filtro = filtro.substring(0, filtro.length - 1); } else { filtro = 0; }

            var parametros = {};
            parametros.FkOrganismo = "R";
            parametros.Filtros = filtro;
            parametros.Reporte = reporte;
            parametros.Proceso = proceso;
            parametros.Modulo = "P";
            parametros.ChequesNulos = chequesNulos;
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
                        $("#ddatos").hide();                       
                        $("#dvista").show();
                        $('#pvista').empty().html('<embed id="evista" width="100%" height="100%" src="' + "../ArchivosRdlc/" + data.d[2] + '"></embed>')
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
        }
    }
}