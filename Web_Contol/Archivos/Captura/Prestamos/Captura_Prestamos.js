var fkpue = 0;
var fkcon = 0;
var cveperfil = 0;
var NomPerfil = "";
var PlazoQnas = 0;
$(document).ready(function () {   
    //var org = $_GET('fkorg');
    //if (org != undefined) { fkorg = org; }
    //else { fkorg = ''; }
    //var cve = $_GET('cve');
    //if (cve != undefined) { cveperfil = cve; }
    //else { cveperfil = ''; }
    //var Perfil = $_GET('perfil');
    //if (Perfil != undefined) { NomPerfil = Perfil; }
    //else { NomPerfil = ''; }

    //$('#lblconcepto').text('Perfil: ' + NomPerfil);

    var text = $('#txtvalor');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();           
                CARGAR_EMPLEADOS('#btnBuscar',valor,"Si");               
        }
    });

    $('#btnBuscar').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar', "","No"); });

    $('#btnBempleado').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar', $('#txtvalor').textbox('getValue'),"Si"); });

    $('#btnGuardar').bind('click', function () { GUARDAR_CAPTURA('#btnGuardar'); });

    $('#btnRegresar').bind('click', function () { IR_PAGINA('../Listar_Perfiles.aspx', ''); });

    $('#btnLimpiar').bind('click', function () { LIMPIAR_CAPTURA(); });

    $('#btnEliminar').bind('click', function () { ELIMINAR_CAPTURA('#btnGuardar');  });
});

$(window).load(function () {  
    //LISTAR_PLAZOS();
    //LISTAR_BANCOS();
    LISTAR_TIPOPUESTO();
    LISTAR_TIPOPAGO();   
    LISTAR_ZONAPAGO();      
  
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

function LISTAR_PLAZOS() {
    var data = {
        objorganismo: {
            FkOrganismo: fkorg,
        }
    }
    $.ajax({
        type: "POST",
        url: '../Fun_Captura.aspx/LISTAR_PLAZOS',
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
                editable: false,
                onSelect: function (rec) {
                    PlazoQnas = rec.qry;                  
                }
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}
function LISTAR_BANCOS() {
    //var data = {
    //    objorganismo: {
    //        FkOrganismo: 1,
    //    }
    //}
    $.ajax({
        type: "POST",
        url: '../Fun_Captura.aspx/LISTAR_BANCOS',
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
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}
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
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
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
            $('#loading').show();
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
        complete: function () { $('#loading').hide(100); }
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
            $('#loading').show();
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
                        //fkpue = rec.valor
                        LISTAR_CONCEPTOSPORPUESTO(rec.valor);
                    }
                }
            });
           // LISTAR_CONCEPTOSPORPUESTO($('#cbotipopuesto').combobox('getValue'));
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}
function LISTAR_IMPORTES_PLAZOS(fkorg) {
    var data = {
        objorganismo: {
            FkOrganismo: fkorg,
        }
    }
    $.ajax({
        type: "POST",
        url: '../Fun_Captura.aspx/LISTAR_IMPORTES_PLAZOS',
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

            $('#cboimporte').combobox({
                data: obj[0],
                valueField: 'valor',
                textField: 'descripcion',
                editable: false
            });

            $('#cboplazos').combobox({
                data: obj[1],
                valueField: 'valor',
                textField: 'descripcion',
                editable: false,
                onSelect: function (rec) {
                    PlazoQnas = rec.qry;
                }
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
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
            $('#loading').show();
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
        complete: function () { $('#loading').hide(100); }
    });
}


function LIMPIAR_CAPTURA() {
    $('#txtempleado').textbox('setValue', '');    
    $('#txtrfc').textbox('setValue', '');
    $('#txtcurp').textbox('setValue', '');
    $('#txtpaterno').textbox('setValue', '');
    $('#txtmaterno').textbox('setValue', '');
    $('#txtnombres').textbox('setValue', '');    
    $('#txttelefono1').textbox('setValue', '');  
    $('#txttelefono2').textbox('setValue', '');    
    $('#cboimporte').combobox('setValue', 'x');   
    $('#cboplazos').combobox('select', $('#cboplazos').combobox('getData')[0].valor);
    $('#cbotipopago').combobox('setValue', 'x');
    $('#cbozonapago').combobox('setValue', 'x');
    //var row = $('#dgempleados').datagrid('getSelected');
    //if (row.id != 0) {
    //    $('#cbotipopuesto').combobox('setValue', '1');
    //    $('#cboconceptos').combobox('setValue', 'x');
    //    $('#cbotipopago').combobox('setValue', 'x');
    //    $('#cbozonapago').combobox('setValue', 'x');
        
    //    $('#cbobanco').combobox('setValue', 'x');
    //}
    $('#txtcuenta').numberbox('setValue', '');
    $('#btnEliminar').linkbutton({ disabled: true });

   
}

function CARGAR_EMPLEADOS(btnobj,filtro,cargar) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if (cargar == "Si") {
            if (filtro != "") { $('#txtvalor').textbox('setValue', filtro); }
            else { filtro = $('#txtvalor').textbox('getValue'); }

            if (filtro == undefined) { filtro = ""; }

            $('#dgempleados').datagrid({
                url: '../listar_Empleados.aspx?busqueda=' + filtro + "&fkorganismo=" + fkpue + "&fkconcepto=" + fkcon,
                pagination: false,
                enableFilter: true,
                rownumbers: true,
                singleSelect: true,
                striped: true,
                scroll: true,
                pageSize: 20,
                showPageList: false,
                onClickRow: function () {
                    var row = $('#dgempleados').datagrid('getSelected');
                    $('#txtempleado').textbox('setValue', row.empleado);
                    $('#txtrfc').textbox('setValue', row.rfc);
                    $('#txtcurp').textbox('setValue', row.curp);
                    $('#txtpaterno').textbox('setValue', row.paterno);
                    $('#txtmaterno').textbox('setValue', row.materno);
                    $('#txtnombres').textbox('setValue', row.nombre);

                    if (row.id != 0) { 
                        //$('#cbotipopuesto').combobox('setValue', row.fkTipoPuesto);   
                       // $('#cboconceptos').combobox('setValue', row.fkConcepto);   
                        $('#cbozonapago').combobox('setValue', row.fkZonaPago);   
                        $('#cboimporte').combobox('setValue', row.ImporteCredito);
                        $('#cboplazos').combobox('setValue', row.PlazoAños);
                        $('#cbotipopago').combobox('setValue', row.fkTipoPago);                        
                        $('#txtcuenta').textbox('setValue', row.CuentaBancaria);

                        $('#btnEliminar').linkbutton({ disabled: false });
                    }
                    $('#win').window('close');
                }
            });
        }
        $('#loading').hide(100);
        windows_porcentaje("#win", 90, 60, false, false, false, "Permisos");  

        TXTFOCUS('#txtvalor');
        $('#dgempleados').datagrid('loadData', { "total": 0, "rows": [] });   
       
    }
}

function GUARDAR_CAPTURA(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {  
        if ($('#cboconceptos').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar el Concepto", 'error'); }
        else
        if ($('#cboplazos').combobox('getValue') == "") { $.messager.alert('Error', "Falta Seleccionar el Plazo", 'error'); }
        else
            if ($('#cbotipopago').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar el Tipo de Pago", 'error'); }
            else
                if (($('#txtcuenta').numberbox('getValue') == "") && (parseInt($('#cbotipopago').combobox('getValue'))==2)) { $.messager.alert('Error', "Falta la Cuenta Bancaria", 'error'); }
                else
                    if ($('#cbozonapago').combobox('getValue') == "x") { $.messager.alert('Error', "Falta Seleccionar la Zona de Pago", 'error'); }
                    else {
                        var row = $('#dgempleados').datagrid('getSelected');
                    var data = {
                        Obj: {    
                            Id:(row == null ? 0 : row.id),
                            FkOrganismo: fkpue,
                            FkConcepto: $('#cboconceptos').combobox('getValue'),
                            Empleado: $('#txtempleado').textbox('getValue'),
                            FechaSolicitud: '',
                            FechaIngreso:'',
                            Rfc: $('#txtrfc').textbox('getValue'),
                            Curp: $('#txtcurp').textbox('getValue'),
                            ApPaterno: $('#txtpaterno').textbox('getValue'),
                            ApMaterno: $('#txtmaterno').textbox('getValue'),
                            Nombres: $('#txtnombres').textbox('getValue'),
                            Domicilio:'',
                            Telefono1: $('#txttelefono1').textbox('getValue'),
                            Telefono2: $('#txttelefono2').textbox('getValue'),
                            CvePagaduria:'',
                            DesPagaduria: '',
                            CveCategoria: '',
                            DesCategoria: '',
                            CveAdscripcion: '',
                            DesAdscripcion: '',
                            ImporteCredito: parseFloat($('#cboimporte').combobox('getValue')),
                            FkPlazo: parseInt($('#cboplazos').combobox('getValue')),
                            PlazoQnas:PlazoQnas,
                            FkTipoPago: parseInt($('#cbotipopago').combobox('getValue')),
                            FkTipoPuesto: parseInt($('#cbotipopuesto').combobox('getValue')),  
                            FkBanco:0,
                            Cuenta: ($('#txtcuenta').numberbox('getValue') == '') ? 0 : $('#txtcuenta').numberbox('getValue'),
                            FkZonaPago: $('#cbozonapago').combobox('getValue')
                        }
                    }
                    $.ajax({
                        type: "POST",
                        url: "../Fun_Captura.aspx/GUARDAR_CAPTURA",
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
                                    ID: row.id,                                                                        
                                    Empleado: $('#txtempleado').textbox('getValue'),
                                    Rfc: $('#txtrfc').textbox('getValue'),
                                    Datos:'P'
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
