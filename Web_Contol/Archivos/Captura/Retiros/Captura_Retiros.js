var fkpue = 0;
var fkcon = 0;
var cveperfil = 0;
var NomPerfil = "";
var PlazoQnas = 0;
$(document).ready(function () {
    
    var text = $('#txtvalor');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();
            CARGAR_EMPLEADOS('#btnBuscar', valor, "Si");
        }
    });

    $('#btnBuscar').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar', "", "No"); });

    $('#btnBempleado').bind('click', function () { CARGAR_EMPLEADOS('#btnBempleado', $('#txtvalor').textbox('getValue'), "Si"); });

    $('#btnGuardar').bind('click', function () { GUARDAR_CAPTURA_RETIROS('#btnGuardar'); });

  
    $('#btnLimpiar').bind('click', function () { LIMPIAR_CAPTURA(); });

    $('#chkord').linkbutton({
        text: '<span style="font-size:18px">Ordinaria</span>'
    });
    $('#chkext').linkbutton({
        text: '<span style="font-size:18px">Extraordinaria</span>'
    });

    var txtimpbruto = $('#txtimpbruto');
    txtimpbruto.numberbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = txtimpbruto.val();
            $('#txtimpneto').numberbox('setValue', valor);
            TXTFOCUS('numberbox','#txtimpadeudo');
        }
    });
    var txtimpadeudo = $('#txtimpadeudo');
    txtimpadeudo.numberbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var neto = $('#txtimpbruto').numberbox('getValue') - $('#txtimpadeudo').numberbox('getValue');
            $('#txtimpneto').numberbox('setValue', neto);
        }
    });

    $('#btnEliminar').bind('click', function () { ELIMINAR_CAPTURA('#btnGuardar'); });
});

$(window).load(function () {   
    $('#loading').show();
    LISTAR_TIPOPUESTO();
    LISTAR_TIPOPAGO();
    LISTAR_ZONAPAGO();
    LISTAR_MOTIVOSBJAS();
    $('#loading').hide(100);
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

//function LISTAR_PLAZOS() {
//    var data = {
//        objorganismo: {
//            FkOrganismo: fkorg,
//        }
//    }
//    $.ajax({
//        type: "POST",
//        url: 'Fun_Captura.aspx/LISTAR_PLAZOS',
//        data: JSON.stringify(data),
//        dataType: "json",
//        async: true,
//        cache: false,
//        contentType: "application/json; charset=utf-8",
//        beforeSend: function () {
//          //  $('#loading').show();
//        },
//        success: function (data) {
//            var obj = jQuery.parseJSON(data.d[2]);

//            $('#cboplazos').combobox({
//                data: obj,
//                valueField: 'valor',
//                textField: 'descripcion',
//                editable: false,
//                onSelect: function (rec) {
//                    PlazoQnas = rec.qry;
//                }
//            });
//        },
//        error: function (err) {
//            $('#loading').hide(100);
//            $.messager.alert('Error', er.statusText, 'error');
//        },
//        complete: function () {
//            //$('#loading').hide(100);
//        }
//    });
//}
//function LISTAR_BANCOS() {
//    //var data = {
//    //    objorganismo: {
//    //        FkOrganismo: 1,
//    //    }
//    //}
//    $.ajax({
//        type: "POST",
//        url: 'Fun_Captura.aspx/LISTAR_BANCOS',
//        //data: JSON.stringify(data),
//        dataType: "json",
//        async: true,
//        cache: false,
//        contentType: "application/json; charset=utf-8",
//        beforeSend: function () {
//            $('#loading').show();
//        },
//        success: function (data) {
//            var obj = jQuery.parseJSON(data.d[2]);

//            $('#cbobanco').combobox({
//                data: obj,
//                valueField: 'valor',
//                textField: 'descripcion',
//                editable: false
//            });
//        },
//        error: function (err) {
//            $('#loading').hide(100);
//            $.messager.alert('Error', er.statusText, 'error');
//        },
//        complete: function () { $('#loading').hide(100); }
//    });
//}
function LISTAR_TIPOPAGO() {
    //var data = {
    //    objorganismo: {
    //        FkOrganismo: 1,
    //    }
    //}
    $.ajax({
        type: "POST",
        url: '../Fun_Captura.aspx/LISTAR_TIPOPAGO',
        // data: JSON.stringify(data),
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
           // $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#cbotipopago').combobox({
                data: obj,
                valueField: 'valor',
                textField: 'descripcion',
                editable: false
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () {            
            //$('#loading').hide(100);
        }
    });
}
function LISTAR_ZONAPAGO() {
    //var data = {
    //    objorganismo: {
    //        FkOrganismo: 1,
    //    }
    //}
    $.ajax({
        type: "POST",
        url: '../Fun_Captura.aspx/LISTAR_ZONAPAGO',
        // data: JSON.stringify(data),
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
           // $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#cbozonapago').combobox({
                data: obj,
                valueField: 'valor',
                textField: 'descripcion',
                editable: false
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () {
            //$('#loading').hide(100);
        }
    });
}
function LISTAR_TIPOPUESTO() {
    //var data = {
    //    objorganismo: {
    //        FkOrganismo: 1,
    //    }
    //}
    $.ajax({
        type: "POST",
        url: '../Fun_Captura.aspx/LISTAR_TIPOPUESTO',
        // data: JSON.stringify(data),
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            //$('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#cbotipopuesto').combobox({
                data: obj,
                valueField: 'valor',
                textField: 'descripcion',
                editable: false,
                onSelect: function (rec) {
                    if (rec.valor != "x") {
                        fkpue = rec.valor
                        //LISTAR_CONCEPTOSPORPUESTO(rec.valor);
                    }
                }
            });
            // LISTAR_CONCEPTOSPORPUESTO($('#cbotipopuesto').combobox('getValue'));
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () {
            //$('#loading').hide(100);
        }
    });
}
function LISTAR_MOTIVOSBJAS() {
    //var data = {
    //    objorganismo: {
    //        FkOrganismo: 1,
    //    }
    //}
    $.ajax({
        type: "POST",
        url: '../Fun_Captura.aspx/LISTAR_MOTIVOSBAJAS',
        // data: JSON.stringify(data),
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
           // $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#cbomotivo').combobox({
                data: obj,
                valueField: 'valor',
                textField: 'descripcion',
                editable: false,
                //onSelect: function (rec) {
                //    if (rec.valor != "x") {
                //        //fkpue = rec.valor
                //        LISTAR_CONCEPTOSPORPUESTO(rec.valor);
                //    }
                //}
            });          
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () {
            //$('#loading').hide(100);
        }
    });
}
function LISTAR_CONCEPTOSPORPUESTO(fktipopuesto) {
    var data = {
        obj: {
            FkTipopuesto: fktipopuesto,
        }
    }
    $.ajax({
        type: "POST",
        url: '../Fun_Captura.aspx/LISTAR_CONCEPTOSPORPUESTO',
        data: JSON.stringify(data),
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
           // $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#cboconceptos').combobox({
                data: obj,
                valueField: 'valor',
                textField: 'descripcion',
                editable: false,
                onSelect: function (rec) {
                    if (rec.valor != "x") {
                        fkcon = rec.valor;
                        fkpue = rec.qry;
                        $('#btnBuscar').linkbutton({ disabled: false });
                        LISTAR_IMPORTES_PLAZOS(rec.qry);
                    }
                }
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () {
            //$('#loading').hide(100);
        }
    });
}
//function LISTAR_IMPORTES_PLAZOS(fkorg) {
//    var data = {
//        objorganismo: {
//            FkOrganismo: fkorg,
//        }
//    }
//    $.ajax({
//        type: "POST",
//        url: '../Fun_Captura.aspx/LISTAR_IMPORTES_PLAZOS',
//        data: JSON.stringify(data),
//        dataType: "json",
//        async: true,
//        cache: false,
//        contentType: "application/json; charset=utf-8",
//        beforeSend: function () {
//        //    $('#loading').show();
//        },
//        success: function (data) {
//            var obj = jQuery.parseJSON(data.d[2]);

//            $('#cboimporte').combobox({
//                data: obj[0],
//                valueField: 'valor',
//                textField: 'descripcion',
//                editable: false
//            });

//            $('#cboplazos').combobox({
//                data: obj[1],
//                valueField: 'valor',
//                textField: 'descripcion',
//                editable: false,
//                onSelect: function (rec) {
//                    PlazoQnas = rec.qry;
//                }
//            });
//        },
//        error: function (err) {
//            $('#loading').hide(100);
//            $.messager.alert('Error', er.statusText, 'error');
//        },
//        complete: function () {
//            //$('#loading').hide(100);
//        }
//    });
//}



function LIMPIAR_CAPTURA() {
    $('#txtrfc').textbox('setValue', '');
    $('#txtpaterno').textbox('setValue', '');
    $('#txtmaterno').textbox('setValue', '');
    $('#txtnombres').textbox('setValue', '');
    $('#cbotipopuesto').combobox('setValue', 1);
    $('#cbomotivo').combobox('setValue', 'x');
    $('#txtimpbruto').textbox('setValue', '');
    $('#txtimpadeudo').textbox('setValue', '');
    $('#txtimpneto').textbox('setValue', '');
    $('#cbotipopago').combobox('setValue', 'x');
    $('#txtcuenta').numberbox('setValue', '');
    $('#cbozonapago').combobox('setValue', 'x');
    $('#dbfecSolicitud').datebox('setValue', '');

    $('#chkord').linkbutton({ selected: true });
    $('#btnEliminar').linkbutton({ disabled: true });
}

function CARGAR_EMPLEADOS(btnobj, filtro, cargar) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        $('#dgdatos').datagrid('loadData', { "total": 0, "rows": [] });
        
        if (cargar == "Si") {
           
            if (filtro != "") { $('#txtvalor').textbox('setValue', filtro); }
            else { filtro = $('#txtvalor').textbox('getValue'); }

            if (filtro == undefined) { filtro = ""; }

            $('#dgdatos').datagrid({
                url: '../listar_RetirosSiniestros.aspx?busqueda=' + filtro+"&modulo=R",
                pagination: false,
                enableFilter: true,
                rownumbers: true,
                singleSelect: true,
                striped: true,
                scroll: true,
                pageSize: 20,
                showPageList: false,
                onClickRow: function () {
                    var row = $('#dgdatos').datagrid('getSelected');                    
                    $('#txtrfc').textbox('setValue', row.Rfc);                    
                    $('#txtpaterno').textbox('setValue', row.Paterno);
                    $('#txtmaterno').textbox('setValue', row.Materno);
                    $('#txtnombres').textbox('setValue', row.Nombre);

                    if (row.id != 0) {                      
                        $('#cbozonapago').combobox('setValue', row.fkZonaPago);
                        $('#cbotipopuesto').combobox('setValue', row.fkTipoPuesto);
                        $('#cbotipopago').combobox('setValue', row.fkTipoPago);
                        $('#cbomotivo').combobox('setValue', row.fkMotivoBaja);
                        $('#txtcuenta').textbox('setValue', row.CuentaBancaria);

                        $('#txtimpbruto').numberbox('setValue', row.ImporteBruto);
                        $('#txtimpadeudo').numberbox('setValue', row.ImporteAdeudo); 
                        $('#txtimpneto').numberbox('setValue', row.ImporteNeto);        

                        $('#dbfecSolicitud').datebox('setValue', row.FecSolicitud);        

                        (row.NumExt == 1 ? $('#chkext').linkbutton({ selected: true }) : $('#chkord').linkbutton({ selected: true }));
                        

                        $('#btnEliminar').linkbutton({ disabled: false });
                    }

                    $('#win').window('close');
                }
            });
        }
        $('#loading').hide(100);
        windows_porcentaje("#win", 90, 60, false, false, false, "Retiros");

        TXTFOCUS('#txtvalor');      
    }
}

function GUARDAR_CAPTURA_RETIROS(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if ($('#cbotipopuesto').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar el Tipo de Puesto", 'error'); }
        else
        if ($('#cbomotivo').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar el Motivo de la Baja", 'error'); }
        else
            if ($('#cbozonapago').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar la Zona de Pago", 'error'); }
            else
               if ($('#cbotipopago').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar el Tipo de Pago", 'error'); }
                else
                   if ($('#txtnombres').textbox('getValue') == "x") { $.messager.alert('Error', "Falta el Nombre", 'error'); }
                   else
                       if ($('#txtimpbruto').numberbox('getValue') == "") { $.messager.alert('Error', "Falta el Importe Bruto", 'error'); }
                       else              
                           if ($('#txtimpneto').numberbox('getValue') == "") { $.messager.alert('Error', "Falta el Importe Neto", 'error'); }
                           else     
                            if (($('#txtcuenta').numberbox('getValue') == "") && (parseInt($('#cbotipopago').combobox('getValue')) == 2)) { $.messager.alert('Error', "Falta la Cuenta Bancaria", 'error'); }                
                            else {
                                var row = $('#dgdatos').datagrid('getSelected');
                                var data = {
                                    Obj: {
                                        ID: (row == null ? 0 : row.Id),
                                        RFC: $('#txtrfc').textbox('getValue'),
                                        ApPaterno: $('#txtpaterno').textbox('getValue'),
                                        ApMaterno: $('#txtmaterno').textbox('getValue'),
                                        Nombres: $('#txtnombres').textbox('getValue'),  
                                        FkTipoPuesto: parseInt($('#cbotipopuesto').combobox('getValue')),
                                        FkMotivoBaja: parseInt($('#cbomotivo').combobox('getValue')),      
                                        ImporteBruto: $('#txtimpbruto').numberbox('getValue'),
                                        ImporteAdeudo: ($('#txtimpadeudo').numberbox('getValue') == "" ? 0 : $('#txtimpadeudo').numberbox('getValue')),
                                        ImporteNeto: ($('#txtimpneto').numberbox('getValue') == "" ? 0 : $('#txtimpneto').numberbox('getValue')),
                                        FkTipoPago: parseInt($('#cbotipopago').combobox('getValue')),                                    
                                        FkBanco: 0,
                                        Cuenta: ($('#txtcuenta').numberbox('getValue') == "" ? 0 : $('#txtcuenta').numberbox('getValue')),     
                                        FechaSolicitud: $('#dbfecSolicitud').datebox('getValue'),
                                        FkOrganismo: fkpue,                                                                        
                                        FkZonaPago: $('#cbozonapago').combobox('getValue'),
                                        TipoProceso: ($('#chkord').linkbutton('options').selected ? "O" : "E")
                                    }
                                }
                                $.ajax({
                                    type: "POST",
                                    url: "../Fun_Captura.aspx/GUARDAR_CAPTURA_RETIROS",
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
                                        LIMPIAR_CAPTURA();
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

function ELIMINAR_CAPTURA(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if ($('#cboconceptos').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar el Concepto", 'error'); }
        else
            if ($('#cboplazos').combobox('getValue') == "") { $.messager.alert('Error', "Falta Seleccionar el Plazo", 'error'); }
            else
                if ($('#cbotipopago').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar el Tipo de Pago", 'error'); }
                else
                    if (($('#txtcuenta').numberbox('getValue') == "") && (parseInt($('#cbotipopago').combobox('getValue')) == 2)) { $.messager.alert('Error', "Falta la Cuenta Bancaria", 'error'); }
                    else
                        if ($('#cbozonapago').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar la Zona de Pago", 'error'); }
                        else {
                            var row = $('#dgempleados').datagrid('getSelected');
                            var data = {
                                Obj: {
                                    ID: row.Id,
                                    Empleado: $('#txtempleado').textbox('getValue'),
                                    Rfc: $('#txtrfc').textbox('getValue'),
                                    Datos: 'R'
                                }
                            }
                            $.ajax({
                                type: "POST",
                                url: "../Fun_Captura.aspx/ELIMINAR_CAPTURA",
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
                                        LIMPIAR_CAPTURA();
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
