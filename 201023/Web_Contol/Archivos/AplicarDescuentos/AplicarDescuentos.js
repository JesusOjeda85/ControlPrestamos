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
});

function onCheck(index, row) {
    for (var i = 0; i < checkedRows.length; i++) {
        if (checkedRows[i].Id == row.Id) {
            return
        }
    }
    checkedRowsVista.push(row);
}
function onUncheck(index, row) {
    for (var i = 0; i < checkedRows.length; i++) {
        if (checkedRows[i].Id == row.Id) {
            checkedRows.splice(i, 1);
            return;
        }
    }
}

function CARGAR_DESCUENTOS(filtro) {
    if (filtro != "") { $('#txtvalor').textbox('setValue', filtro); }
    else { filtro = $('#txtvalor').textbox('getValue'); }

    if (filtro == undefined) { filtro = ""; }

    $('#dgdatos').datagrid({
        url: 'Listar_Descuentos.aspx?busqueda=' + filtro,
        pagination: true,
        enableFilter: true,
        rownumbers: true,
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
        onClickRow: function () {
            var row = $('#dgempleados').datagrid('getSelected');
            //$('#txtempleado').textbox('setValue', row.numemp);
            //$('#txtrfc').textbox('setValue', row.rfccom);
            //$('#txtcurp').textbox('setValue', row.curpemp);
            //$('#txtpaterno').textbox('setValue', row.patemp);
            //$('#txtmaterno').textbox('setValue', row.matemp);
            //$('#txtnombres').textbox('setValue', row.nomemp);
            //$('#txtcvecat').textbox('setValue', row.cvepuepl);
            //$('#txtdescat').textbox('setValue', row.despue);
            //$('#txtcveads').textbox('setValue', row.cveadspl);
            //$('#txtdesads').textbox('setValue', row.descentro);
            //$('#txtcvepag').textbox('setValue', row.cvepagpl);
            //$('#txtdespag').textbox('setValue', row.despag);
            //$('#win').window('close');
        }
    });
}
