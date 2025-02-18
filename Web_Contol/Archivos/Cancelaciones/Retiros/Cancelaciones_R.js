$(document).ready(function () {
    var text = $('#txtvalor');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();
            CARGAR_EMPLEADOS('#btnBempleado', valor,"Si");
        }
    });

    $('#btnBuscar').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar', "", "No"); });

    $('#btnBempleado').bind('click', function () { CARGAR_EMPLEADOS('#btnBempleado', $('#txtvalor').textbox('getValue'), "Si"); });

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
    $('#txtrfc').textbox('setValue', '');    
    $('#txtNombre').textbox('setValue', '');
    $('#txttipopuesto').textbox('setValue', '');
    $('#txtzonapago').textbox('setValue', '');
    $('#txtimpbruto').numberbox('setValue', '');
    $('#txtimpadeudo').numberbox('setValue', '');
    $('#txtimpneto').numberbox('setValue', '');
    $('#txtmotivo').textbox('setValue', '');
    $('#txtEmision').textbox('setValue', '');
    $('#dbfecCaptura').datebox('setValue', '');          
    $('#txtfecsolicitud').textbox('setValue', '');          
    $('#txtobservaciones').textbox('setValue', '');
    $('#btnGuardar').linkbutton({ disabled: true });
}

function CARGAR_EMPLEADOS(btnobj, filtro, carga) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {        
        $('#dgempleados').datagrid('loadData', { "total": 0, "rows": [] });
        LIMPIAR_OBJ('textbox', '#txtvalor');
        TXTFOCUS('textbox','#txtvalor');

        if (carga == "Si") {            
            $('#dgempleados').datagrid({
                url: "../Buscar_Empleados.aspx?modulo=R&busqueda=" + filtro,
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
                   
                    $('#txtrfc').textbox('setValue', row.Rfc);                    
                    $('#txtNombre').textbox('setValue', row.Nombre);
                    $('#txttipopuesto').textbox('setValue', row.TipoPuesto);
                    $('#txtzonapago').textbox('setValue', row.ZonaPago);
                    $('#txtimpbruto').textbox('setValue', row.ImporteBruto);
                    $('#txtimpadeudo').textbox('setValue', row.ImporteAdeudo);
                    $('#txtimpneto').textbox('setValue', row.ImporteNeto);
                    $('#txtEmision').textbox('setValue', row.Emision);
                    $('#txtmotivo').textbox('setValue', row.MotivoBaja);                    
                    $('#txtfecsolicitud').textbox('setValue', row.FecSolicitud);
                   

                    $('#win').window('close');
                    $("#btnGuardar").linkbutton({ disabled: false });
                    
                }
            });
        }

        $('#loading').hide(100);
        windows_porcentaje("#win", 90, 60, false, false, false, "Empleados");              
    }
}

function GUARDAR_CAPTURA(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if ($('#txtobservaciones').textbox('getValue') == "") { $.messager.alert('Error', "Faltan las observaciones de la cancelación", 'error'); }
        else
            if ($('#dbfecCaptura').datebox('getValue') == "") { $.messager.alert('Error', "Faltan la fecha de la cancelación", 'error'); }
        else            
            var row = $('#dgempleados').datagrid('getSelected');
        var data = {
            Obj: {
                Id: row.Id,
                FecCaptura: $('#dbfecCaptura').datebox('getValue'),
                Observaciones: $('#txtobservaciones').textbox('getValue'),
                Modulo:"R"
            }
        }
                $.ajax({
                                type: "POST",
                                url: "../Fun_Cancelaciones.aspx/GUARDAR_CANCELACIONES",
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
                                        //$('#txtobservaciones').textbox('setValue', "");
                                        //$('#txtfecCaptura').textbox('setValue', "");
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
