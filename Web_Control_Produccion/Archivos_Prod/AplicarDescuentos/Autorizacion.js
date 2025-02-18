var checkedRows = [];
var fkpue = 0;
var clavepuesto = "";
$(document).ready(function () {
    LISTAR_TIPOPUESTO();

    $('#btnLimpiar').bind('click', function () {
        LIMPIAR_DESCUENTOS();
    });

    $('#btnAplicar').bind('click', function () { APLICAR_DESCUENTOS('#btnAplicar'); });

    $('#btnAutorizar').bind('click', function () { AUTORIZAR_DESCUENTOS('#btnAutorizar'); });

    var ano = obtenerAno();
    localStorage.setItem('año', ano);
   
    var date = new Date();
    var y = date.getFullYear();
    var m = date.getMonth() + 3;
    var d = date.getDate();
    var fecha = (d < 10 ? ('0' + d) : d) + '/' + (m < 10 ? ('0' + m) : m) + '/' + y
    $('#dtfechaaplicacion').datebox('setValue', fecha);
});

function obtenerAno() {
    var d = new Date();
    var n = d.getFullYear();
    return n;
}

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

function LISTAR_TIPOPUESTO() {   
    $.ajax({
        type: "POST",
        url: '../Captura/Fun_Captura.aspx/LISTAR_TIPOPUESTO',      
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
                        fkpue = rec.valor;
                        clavepuesto = rec.qry;
                        CARGAR_PRESTAMOS("", rec.valor);
                        //TXTFOCUS('#txtvalor');
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

function CARGAR_PRESTAMOS(filtro,tipopuesto) {      
    var data = {
        Obj: {
            FkTipoPuesto: tipopuesto,
            Busqueda: (filtro == "") ? "" : filtro
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

                $('#dgdatos').datagrid('loadData', { "total": 0, "rows": [] });  
                
                obj = $.parseJSON(data.d[2]);
                $('#dgdatos').datagrid({
                    data: obj,
                    pagination: false,
                    enableFilter: true,
                    rownumbers: true,
                    singleSelect: false,
                    striped: true,
                    scroll: true,
                    pageSize: 20,
                    showPageList: false,
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

function LIMPIAR_DESCUENTOS() {  
    //$('#txtvalor').textbox('setValue', "");
    CARGAR_PRESTAMOS("", fkpue);
}

function APLICAR_DESCUENTOS() {
    if (checkedRows.length > 0) {       
        windows_porcentaje("#WAplicacion",25, 35, false, false, false, "Autorización de Prestamos");
       // windows("WAplicacion", '300px', '400px', false, 'Autorización de Prestamos');
       
        $('#txtnumaño').textbox('setValue', localStorage.getItem('año'));
        
        //TXTFOCUS('#txtemision');
        //$('#txtemision').textbox('setValue', "P" + localStorage.getItem('año') + clavepuesto);
    }
    else { $.messager.alert('Error', 'Falta seleccionar los empleados', 'error'); return 0; }
}

function AUTORIZAR_DESCUENTOS(objbtn) {
    if ($(objbtn).linkbutton('options').disabled) { return false; }
    else {
        var año = localStorage.getItem('año');
       /* var quin = localStorage.getItem('quin');*/
        if ($('#txtnumaño').numberspinner('getValue') < año) { $.messager.alert('Error', 'El Año Seleccionado no puede ser menor al año actual', 'error'); return 0; }
        else           
            //if ($('#txtemision').textbox('getValue') == "") { $.messager.alert('Error', 'Falta el folio de la emisión', 'error'); return 0; }
            //else {     
                if ($('#dtfechaaplicacion').datebox('getValue') == '') { $.messager.alert('Error', 'Falta seleccionar la fecha de aplicación', 'error'); return 0; }
                else 
                        var Aplicados = [], Rechazados = [];                       
                        var dg = $('#dgdatos');

                for (var s = 0; s < checkedRows.length; s++) {
                    Aplicados += checkedRows[s].Id + ","; 
                }
                var encontrado = false;
                var rows = dg.datagrid('getRows');                        
                for (var r = 0; r < rows.length; r++) {
                   for (var s = 0; s < checkedRows.length; s++) {
                       if (rows[r].Id == checkedRows[s].Id) { encontrado = true; break; } else { encontrado = false; }                   
                    } 
                    if (encontrado == false) {
                        Rechazados += rows[r].Id + ",";                       
                    }
                }
                        if (Aplicados.length > 0) { Aplicados = Aplicados.substring(0, Aplicados.length - 1); } else { Aplicados = 0; }
                        if (Rechazados.length > 0) { Rechazados = Rechazados.substring(0, Rechazados.length - 1); } else { Rechazados = 0; }

                        $("#WAplicacion").window('close');

                        var data = {
                            Obj: {                                   
                                Año: $('#txtnumaño').numberspinner('getValue'),
                                Aplicados: Aplicados,
                                Rechazados: Rechazados,                               
                                Proceso: ($('#btnOrd').linkbutton('options').selected) ? "O" : "E",
                                Quincena: $('#dtfechaaplicacion').datebox('getValue'),
                                TipoPuesto: clavepuesto
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

                                    CARGAR_PRESTAMOS("", fkpue);
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
