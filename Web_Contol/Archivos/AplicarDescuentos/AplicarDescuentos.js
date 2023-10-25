var checkedRows = [];
$(document).ready(function () {
    CARGAR_DESCUENTOS("");

    var text = $('#txtvalor');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();
            CARGAR_DESCUENTOS(valor);
        }
    });

    $('#btnBuscar').bind('click', function () { CARGAR_DESCUENTOS($('#txtvalor').textbox('getValue')); });

    $('#btnDetalle').bind('click', function () { CARGAR_DETALLE_EMPLEADO('#btnDetalle'); });

    $('#btnEditar').bind('click', function () { EDITAR_DESCUENTO('#btnEditar'); });

    $('#btnLimpiar').bind('click', function () { LIMPIAR_DESCUENTOS(); });

    $('#btnAplicar').bind('click', function () { APLICAR_DESCUENTOS('#btnAplicar'); });

    $('#btnGAplicar').bind('click', function () { GUARDAR_DESCUENTOS('#btnGAplicar'); });

    $('#btnGDetalle').bind('click', function () { GUARDAR_CAMBIOS_DESCUENTOS('#btnGDetalle'); });

    $('#btnLDetalle').bind('click', function () { LIMPIAR_CAPTURA(); });


    $('#WEditar').window({
        onBeforeClose: function () {    
            LIMPIAR_DESCUENTOS();
            return true;
        }
    });

    $('#WAplicacion').window({
        onBeforeClose: function () {
            LIMPIAR_DESCUENTOS();
            return true;
        }
    });
});

function onCheck(index, row) {
    for (var i = 0; i < checkedRows.length; i++) {
        if (checkedRows[i].Id == row.Id) {
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

function LISTAR_PLAZOS(plazo,org) {
    var data = {
        objorganismo: {
            FkOrganismo: org,
        }
    }
    $.ajax({
        type: "POST",
        url: '../Captura/Fun_Captura.aspx/LISTAR_PLAZOS',
        data: JSON.stringify(data),
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#cboplazos').combobox({
                data: obj,
                valueField: 'valor',
                textField: 'descripcion',
                editable: false
            });
            $('#cboplazos').combobox('setValue', plazo);
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}
function LISTAR_BANCOS(banco) {
    //var data = {
    //    objorganismo: {
    //        FkOrganismo: 1,
    //    }
    //}
    $.ajax({
        type: "POST",
        url: '../Captura/Fun_Captura.aspx/LISTAR_BANCOS',
        //data: JSON.stringify(data),
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#cbobanco').combobox({
                data: obj,
                valueField: 'valor',
                textField: 'descripcion',
                editable: false
            });
            $('#cbobanco').combobox('setValue', banco);
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}
function LISTAR_TIPOPAGO(tipopago) {
    //var data = {
    //    objorganismo: {
    //        FkOrganismo: 1,
    //    }
    //}
    $.ajax({
        type: "POST",
        url: '../Captura/Fun_Captura.aspx/LISTAR_TIPOPAGO',
        // data: JSON.stringify(data),
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#cbotipopago').combobox({
                data: obj,
                valueField: 'valor',
                textField: 'descripcion',
                editable: false
            });
            $('#cbotipopago').combobox('setValue', tipopago);
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}


function CARGAR_DESCUENTOS(filtro) {
    if (filtro != "") { $('#txtvalor').textbox('setValue', filtro); }
    else { filtro = $('#txtvalor').textbox('getValue'); }

   
    var data = {
        Obj: {
            Desde: 1,
            Hasta: 20,
            Busqueda: (filtro == undefined ? filtro = "" : filtro)
        }
    }

    $.ajax({
        type: "POST",
        url: "Fun_AplicarDescuentos.aspx/Cargar_Descuentos",
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
                $('#dgdatos').datagrid({
                    data: obj,
                    pagination: true,
                    enableFilter: true,
                    rownumbers: true,
                    fitColumns: true,
                    autoRowHeight: false,
                    singleSelect: true,
                    striped: true,
                    scroll: true,
                    pageSize: 20,                    
                    showPageList: false,
                    checkOnSelect: false,
                    selectOnCheck: false,
                    onCheckAll: function () {
                        var allRows = $(this).datagrid('getRows');
                        checkedRows = allRows;
                    },
                    onUncheckAll: function () {
                        checkedRows = [];
                    },
                    onCheck: onCheck,
                    onUncheck: onUncheck,
                    view: detailview,
                    detailFormatter: function (index, row) {
                        return '<div style="padding:2px;position:relative;"><table class="ddv"></table></div><div style="padding:2px;position:relative;"><table class="ddv2"></table></div>';
                    },
                    onExpandRow: function (index, row) {
                        var ddv = $(this).datagrid('getRowDetail', index).find('table.ddv');
                        var valor = row["Id"];
                        var filobj = jQuery.grep(obj, function (Detalle, i) {
                            return Detalle.Id == valor;
                        });
                        ddv.datagrid({
                            data: filobj,
                            fitColumns: true,
                            singleSelect: true,
                            rownumbers: true,
                            striped: true,
                            loadMsg: '',
                            height: 'auto',
                            columns: [[
                                { field: 'Categoria', title: 'Categoria', align: 'center' },
                                { field: 'DescCategoria', title: 'DescCategoria', align: 'left' },
                                { field: 'Adscripcion', title: 'Adscripcion', align: 'center' },
                                { field: 'DescAdscripcion', title: 'DescAdscripcion', align: 'left' },
                                { field: 'Pagaduria', title: 'Pagaduria', align: 'center' },
                                { field: 'DescPagaduria', title: 'DescPagaduria', align: 'left' },
                            ]],
                            onResize: function () {
                                $('#dgdatos').datagrid('fixDetailRowHeight', index);
                            },
                            onLoadSuccess: function () {
                                setTimeout(function () {
                                    $('#dgdatos').datagrid('fixDetailRowHeight', index);
                                }, 0);
                            }
                        });
                        $('#dgdatos').datagrid('fixDetailRowHeight', index);
                    },
                    onClickRow: function () {
                        var row = $('#dgempleados').datagrid('getSelected');
                    },
                    error: function (err) {
                        $('#loading').hide(100);
                        $.messager.alert('Error', err.statusText, 'error');
                    },
                    complete: function () { $('#loading').hide(100); },

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

function EDITAR_DESCUENTO(objbtn) {
    if ($(objbtn).linkbutton('options').disabled) { return false; }
    else {
        var row = $('#dgdatos').datagrid('getSelected');
        if (row == null) {
            $.messager.alert('Error', 'Falta seleccionar el empleado', 'error'); return 0;
        }
        else {
            LISTAR_PLAZOS(row.fkPlazo, row.fkorganismo);
            LISTAR_BANCOS(row.fkBanco);
            LISTAR_TIPOPAGO(row.fkTipoPago);
        
            $('#txtimporte').numberbox('setValue', row.ImporteCredito);   
            $('#txtcuenta').numberbox('setValue', row.CuentaBancaria);          

            $('#loading').hide(100);
            windows_porcentaje("#WEditar", 60, 40, false, false, false, "Detalle del Empleado");  
        }
    }
}

function LIMPIAR_DESCUENTOS() {
    var row = $('#dgdatos').datagrid('getSelected');
    if (row == null) {
        CARGAR_DESCUENTOS();
    }
    else
    {       
        LIMPIAR_SELECCION_GRID("#dgdatos",true);               
    }
}

function APLICAR_DESCUENTOS() {
    if (checkedRows.length > 0) {
        $('#loading').hide(100);
        windows_porcentaje("#WAplicacion", 40, 35, false, false, false, "Aplicación de Descuentos");  
    }
    else { $.messager.alert('Error', 'Falta seleccionar los empleados a aplicar', 'error'); return 0; }
}

function GUARDAR_DESCUENTOS(objbtn) {
    if ($(objbtn).linkbutton('options').disabled) { return false; }
    else {
        var valores = "";
        if (checkedRows.length > 0) {
            for (var f = 0; f < checkedRows.length; f++) {
                valores += checkedRows[f].Id + ",";
            }
            valores = valores.substring(0, valores.length - 1);

            var data = {
                Obj: {
                    valores: valores,                            
                }
            }
            $.ajax({
                type: "POST",
                url: "Fun_AplicarDescuentos.aspx/APLICAR_DESCUENTOS",
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

function GUARDAR_CAMBIOS_DESCUENTOS(objbtn) {
    if ($(objbtn).linkbutton('options').disabled) { return false; }
    else {
        var row = $('#dgdatos').datagrid('getSelected');
        var data = {
            Obj: {
                Id: row.Id,
                Empleado:row.Empleado,
                FkPlazo: ($('#cboplazos').combobox('getValue') != "x" ? $('#cboplazos').combobox('getValue') : $.messager.alert('Error', 'Falta seleccionar el plazo', 'error')),
                FkBanco: ($('#cbobanco').combobox('getValue') != "x" ? $('#cbobanco').combobox('getValue') : $.messager.alert('Error', 'Falta seleccionar el banco', 'error')),
                FkTipoPago: ($('#cbotipopago').combobox('getValue') != "x" ? $('#cbotipopago').combobox('getValue') : $.messager.alert('Error', 'Falta seleccionar el tipo de pago', 'error')),
                Cuenta: ($('#txtcuenta').numberbox('getValue') != "" ? $('#txtcuenta').numberbox('getValue') : $.messager.alert('Error', 'Falta el número de cuenta', 'error')),
                ImporteCredito: ($('#txtimporte').numberbox('getValue') != "" ? $('#txtimporte').numberbox('getValue') : $.messager.alert('Error', 'Falta el número de importe', 'error')),
            }
        }
        $.ajax({
            type: "POST",
            url: "Fun_AplicarDescuentos.aspx/MODIFICAR_CAPTURA",
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

function LIMPIAR_CAPTURA() {
    var row = $('#dgdatos').datagrid('getSelected');
    if (row != null) {
        $('#cboplazos').combobox('setValue', row.fkPlazo);
        $('#cbobanco').combobox('setValue', row.fkBanco);
        $('#cbotipopago').combobox('setValue', row.fkTipoPago);
        $('#txtcuenta').numberbox('setValue', row.CuentaBancaria);
        $('#txtimporte').numberbox('setValue', row.ImporteCredito);
    }
}

