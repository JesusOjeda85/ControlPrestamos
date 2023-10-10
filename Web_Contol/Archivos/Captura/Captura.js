$(document).ready(function () {   
    LISTAR_PLAZOS();   
    LISTAR_BANCOS();
    LISTAR_TIPOPAGO();
    $('#btnBuscar').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar',""); });
});


function LISTAR_PLAZOS() {
    var data = {
        objorganismo: {
            FkOrganismo: 1,
        }
    }
    $.ajax({
        type: "POST",
        url: 'Fun_Captura.aspx/LISTAR_PLAZOS',
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
        url: 'Fun_Captura.aspx/LISTAR_BANCOS',
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
        url: 'Fun_Captura.aspx/LISTAR_TIPOPAGO',
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


function CARGAR_EMPLEADOS(btnobj,filtro) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {

        if (filtro != "") { $('#txtvalor').textbox('setValue', filtro); }
        else { filtro = $('#txtvalor').textbox('getValue'); }

        if (filtro == undefined) { filtro = ""; }

        $('#dgempleados').datagrid({
            url: 'listar_Empleados.aspx?busqueda=' + filtro,
            pagination: true,
            enableFilter: true,
            rownumbers: true,
            singleSelect: true,
            striped: true,
            scroll: true,
            pageSize: 20,
            showPageList: false,
            onClickRow: function () {
                var row = $('#dgempleados').datagrid('getSelected');
                $('#txtempleado').textbox('setValue', row.numemp);              
                $('#txtrfc').textbox('setValue', row.rfccom);
                $('#txtcurp').textbox('setValue', row.curpemp);
                $('#txtpaterno').textbox('setValue', row.patemp);
                $('#txtmaterno').textbox('setValue', row.matemp);
                $('#txtnombres').textbox('setValue', row.nomemp);
                $('#txtcvecat').textbox('setValue', row.cvepuepl);
                $('#txtdescat').textbox('setValue', row.despue);
                $('#txtcveads').textbox('setValue', row.cveadspl);
                $('#txtdesads').textbox('setValue', row.descentro);
                $('#txtcvepag').textbox('setValue', row.cvepagpl);
                $('#txtdespag').textbox('setValue', row.despag);
                $('#win').window('close');
            }
        });

        $('#loading').hide(100);
        //windows_porcentaje("#win", 90, 60, false, false, false, "Permisos");  
        windows("#win", "90%", "550px", false, "Empleados");
    }
}
