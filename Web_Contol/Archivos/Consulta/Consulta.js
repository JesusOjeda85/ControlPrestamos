$(document).ready(function () {
    $('#btnBuscar').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar', ""); });

    $('#btnBempleado').bind('click', function () { CARGAR_EMPLEADOS('#btnBuscar', $('#txtvalor').textbox('getValue')); });

    var text = $('#txtvalor');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();
            CARGAR_EMPLEADOS('#btnBuscar', valor);
        }
    });

    $('#btnLimpiar').bind('click', function () { LIMPIAR_DATOS(); });
});
function LIMPIAR_DATOS() {
    $('#txtempleado').textbox('setValue','');
    $('#txtrfc').textbox('setValue', '');
    $('#txtcurp').textbox('setValue', '');
    $('#txtNombre').textbox('setValue', '');
    $('#txttipopuesto').textbox('setValue', '');
    $('#txtzonapago').textbox('setValue', '');
    $('#txtimporte').textbox('setValue', '');
    $('#txtplazo').textbox('setValue', '');
    $('#txtconcepto').textbox('setValue', '');
    $('#cboEmision').combobox('setValue', '');

    $('#dgdetalle').datagrid('loadData', { "total": 0, "rows": [] });   
}

function CARGAR_EMPLEADOS(btnobj, filtro) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {

        //if (filtro != "") { $('#txtvalor').textbox('setValue', filtro); }
        //else { filtro = $('#txtvalor').textbox('getValue'); }

        //if (filtro == undefined) { filtro = ""; }

        $('#dgempleados').datagrid({
            url: "Buscar_Empleados.aspx?busqueda="+ filtro,
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
               // $('#txtimporte').textbox('setValue', row.ImporteCredito);    
                CARGAR_PRESTAMOS(row.Empleado);
                $('#win').window('close');
            }
        });

        $('#loading').hide(100);
        windows_porcentaje("#win", 90, 60, false, false, false, "Empleados");
        // windows("#win", "90%", "60%", false, "Empleados");
    }
}

function CARGAR_PRESTAMOS(filtro) {   
    var data = {
        Obj: {           
            Empleado: (filtro == undefined ? filtro = "" : filtro)
        }
    }

    $.ajax({
        type: "POST",
        url: "Fun_Consulta.aspx/Listar_NumCreditos",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        cache: "false",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            if (data.d[0] == "0") {
                tbl = $.parseJSON(data.d[2]);

                $('#dgdetalle').datagrid('loadData', { "total": 0, "rows": [] }); 

                $('#cboEmision').combobox({
                    data: tbl,
                    valueField: 'valor',
                    textField: 'descripcion',
                    editable: false,
                    onSelect: function (rec) {                       
                        if ((rec.qry != "x") && (rec.qry != null)) {                           
                            var valores = rec.qry.split('|');
                            $('#txtimporte').textbox('setValue', valores[2]);  
                            $('#txtplazo').textbox('setValue', valores[1]); 
                            $('#txtconcepto').textbox('setValue', valores[0]); 
                            LISTAR_DETALLE_CREDITO(rec.valor);
                        }
                    },
                    onLoadSuccess: function (item) {
                        if (item.length == 2) {
                            var opts = $(this).combobox('options');
                            $(this).combobox('select', item[1][opts.valueField]);
                        }
                    }                    
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

function LISTAR_DETALLE_CREDITO(idcredito) {
    var data = {
        Obj: {
            Id: idcredito,
        }
    }
    $.ajax({
        type: "POST",
        url: 'Fun_Consulta.aspx/Listar_DetalleCredito',
        data: JSON.stringify(data),
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var tbldetalle = jQuery.parseJSON(data.d[2]);

            $('#dgdetalle').datagrid({
                data: tbldetalle,
                pagination: false,
                rownumbers: false,
                scroll: true,
                pageSize: 20,
                error: function (err) {
                    $('#loading').hide(100);
                    $.messager.alert('Error', err.statusText, 'error');
                },
                complete: function () {
                    $('#loading').hide(100);
                },
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}