var checkedRows = [];
$(document).ready(function () {    
    CARGAR_EMISIONES_RENUMERACION();

    $('#btnAplicar').bind('click', function () { APLICAR_RENUMERACION('#btnAplicar'); });

    $('#btnLimpiar').bind('click', function () { CARGAR_PROCESOS(); });

    $('#dgdatos').datagrid('enableCellEditing').datagrid('gotoCell', {
        index: 0,
        field: 'Emision',
    });
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

function CARGAR_EMISIONES_RENUMERACION() {
    $('#dgdatos').datagrid('loadData', { "total": 0, "rows": [] });
    $.ajax({
        type: "POST",
        url: "Fun_Numeracion.aspx/Cargar_Emisiones_Renumeracion",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        cache: "false",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            if (data.d[0] == "0") {
                obj = $.parseJSON(data.d[2]);
                $('#dgdatos').datagrid({
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
                    onClickCell: function (index, field, value) {
                        var dg = $(this);
                        if ((field == 'ChequeInicial')|| (field == 'ChequeFinal')||(field == 'ChequeActual')) {
                            dg.datagrid('beginEdit', index);
                            var ed = dg.datagrid('getEditor', { index: index, field: field });
                            $(ed.target).focus();

                            var ed = dg.datagrid('getEditors', index)[0];
                            if (!ed) { return; }
                            var t = $(ed.target);
                            if (t.hasClass('textbox-f')) {
                                t = t.textbox('textbox');
                            }
                            t.bind('keydown', function (e) {
                                if (e.keyCode == 13) {
                                    dg.datagrid('endEdit', index);
                                } else if (e.keyCode == 27) {
                                    dg.datagrid('endEdit', index);
                                }
                            })
                        }
                        else {
                            dg.datagrid('acceptChanges');
                        }
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

function APLICAR_RENUMERACION(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if (checkedRows.length == 0) { $.messager.alert('Error', 'Falta los folios a renumerar', 'error'); return 0; }
        else {
            $('#dgdatos').datagrid('acceptChanges');
            var Procesos = [];
            for (var s = 0; s < checkedRows.length; s++) {
                Procesos += "''" + checkedRows[s].Emision + "'':" + checkedRows[s].fkTipoPuesto + "," + checkedRows[s].ChequeInicial + "," + checkedRows[s].ChequeFinal + "," + checkedRows[s].ChequeActual+ "," + checkedRows[s].NumExt + "|";
            }
            if (Procesos.length > 0) { Procesos = Procesos.substring(0, Procesos.length - 1); } else { Procesos = 0; }

            var data = {
                Obj: {
                    Proceso: Procesos
                }
            }
            $.ajax({
                type: "POST",
                url: "Fun_Numeracion.aspx/APLICAR_RENUMERACION",
                data: JSON.stringify(data),
                async: true,
                cache: false,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {
                    $('#loading').show();
                },
                success: function (data) {
                    if (data.d[0] == "0") {
                        $.messager.alert('Información', data.d[1], 'info');
                        CARGAR_PROCESOS();

                    }
                    else { $.messager.alert('Error', data.d[1], 'error'); }
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