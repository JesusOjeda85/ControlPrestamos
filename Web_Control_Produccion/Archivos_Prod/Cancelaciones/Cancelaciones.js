$(document).ready(function () {
    var text = $('#txtvalor');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();
            CARGAR_EMPLEADOS('#btnBuscar', valor,"Si");
        }
    });

    $('#btnBuscar').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar', "", "No"); });

    $('#btnBempleado').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar', $('#txtvalor').textbox('getValue'), "Si"); });

    $('#btnGuardar').bind('click', function () { GUARDAR_CAPTURA('#btnGuardar'); });

    $('#btnLimpiar').bind('click', function () { LIMPIAR_DATOS(); });

});


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

function LIMPIAR_DATOS() {
    $('#txtempleado').textbox('setValue', '');
    $('#txtrfc').textbox('setValue', '');
    $('#txtcurp').textbox('setValue', '');
    $('#txtNombre').textbox('setValue', '');
    $('#txttipopuesto').textbox('setValue', '');
    $('#txtzonapago').textbox('setValue', '');
    $('#txtimporte').textbox('setValue', '');
    $('#txtplazo').textbox('setValue', '');
    $('#txtconcepto').textbox('setValue', '');
    $('#txtEmision').textbox('setValue', '');
    $('#txtfecautorizo').textbox('setValue', '');   
    $('#txtobservaciones').textbox('setValue', '');
}

function CARGAR_EMPLEADOS(btnobj, filtro, carga) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if (carga == "Si") {
            $('#dgempleados').datagrid({
                url: "../Consulta/Buscar_Empleados.aspx?busqueda=" + filtro,
                pagination: false,
                enableFilter: false,
                rownumbers: true,
                singleSelect: true,
                striped: true,
                scroll: true,
                pageSize: 20,
                showPageList: false,
                onClickRow: function () {
                    var row = $('#dgempleados').datagrid('getSelected');

                    $('#txtempleado').textbox('setValue', row.Empleado);
                    $('#txtrfc').textbox('setValue', row.Rfc);
                    $('#txtcurp').textbox('setValue', row.Curp);
                    $('#txtNombre').textbox('setValue', row.Nombre);
                    $('#txttipopuesto').textbox('setValue', row.TipoPuesto);
                    $('#txtzonapago').textbox('setValue', row.ZonaPago);
                    $('#txtimporte').textbox('setValue', row.ImporteCredito);
                    $('#txtEmision').textbox('setValue', row.Emision);
                    $('#txtconcepto').textbox('setValue', row.Concepto);
                    $('#txtplazo').textbox('setValue', row.PlazoAños);
                    $('#txtfecautorizo').textbox('setValue', row.FecAutorizado);

                    $('#win').window('close');
                    $("#btnGuardar").linkbutton({ disabled: false });
                    
                }
            });
        }
        $('#loading').hide(100);
        windows_porcentaje("#win", 90, 60, false, false, false, "Empleados");       

        TXTFOCUS('#txtvalor');
    }
}

function GUARDAR_CAPTURA(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if ($('#txtobservaciones').textbox('getValue') == "") { $.messager.alert('Error', "Faltan las observaciones de la cancelación", 'error'); }
        else            
            var row = $('#dgempleados').datagrid('getSelected');
        var data = {
            Obj: {
                Id: row.Id,
                Observaciones: $('#txtobservaciones').textbox('getValue')
            }
        }
                $.ajax({
                                type: "POST",
                                url: "Fun_Cancelaciones.aspx/GUARDAR_CANCELACIONES",
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
                                        $('#txtobservaciones').textbox('setValue', "");
                                        LIMPIAR_DATOS();
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
