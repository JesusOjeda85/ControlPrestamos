﻿var idusuario = "", fkusuario = "";
var makesArray = [];
var checkedRows = [];
var checkedRowsCon = [];
var checkedRowsPLa = [];
$(document).ready(function () {
    $.extend($.fn.tree.methods, {
        removeAll: function (jq) {
            return jq.each(function () {
                var roots = $(this).tree('getRoots');
                for (var i = roots.length - 1; i >= 0; i--) {
                    $(this).tree('remove', roots[i].target);
                }
            })
        },
        unselect: function (jq, target) {
            return jq.each(function () {
                var opts = $(this).tree('options');
                $(target).removeClass('tree-node-selected');
                if (opts.onUnselect) {
                    opts.onUnselect.call(this, $(this).tree('getNode', target));
                }
            });
        }
    })
    $.extend($.fn.datagrid.methods, {
        getChecked: function (jq) {
            var rr = [];
            var rows = jq.datagrid('getRows');
            jq.datagrid('getPanel').find('div.datagrid-cell-check input:checked').each(function () {
                var index = $(this).parents('tr:first').attr('datagrid-row-index');
                rr.push(rows[index]);
            });
            return rr;
        }
    });

    DESHABILITAR();

    Cargar_ComboBox('grupos', '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_CATALOGO_GRUPOS_USUARIO', '', 'cbotipousuario');

    LISTAR_USUARIOS();

    $('#btnNuevo').bind('click', function () { NUEVO('#btnNuevo'); });
    $('#btnLimpiar').bind('click', function () { LIMPIAR('#btnLimpiar'); });
    $('#btnGuardar').bind('click', function () { GUARDAR('#btnGuardar'); });

    $('#btnBGrupo').bind('click', function () { CARGAR_ROLES('#btnBGrupo'); });
    $('#btnLPermisos').bind('click', function () { LIMPIAR_ROLES('#btnLPermisos'); });


    $('#btnBPermisos').bind('click', function () {
        $('#loading').show();
        CARGAR_LISTA_INDIVIDUALES('#btnBPermisos');
    });


    $('#btnEMenus').bind('click', function () { ELIMINAR_ROLES_USUARIOS('#btnEMenus', 'MENU'); });
    $('#btnEMovimientos').bind('click', function () { ELIMINAR_ROLES_USUARIOS('#btnEMovimientos', 'MOV'); });
    $('#btnETerceros').bind('click', function () { ELIMINAR_ROLES_USUARIOS('#btnETerceros', 'TER'); });
    $('#btnEReportes').bind('click', function () { ELIMINAR_ROLES_USUARIOS('#btnEReportes', 'REP'); });
    $('#btnEFiltros').bind('click', function () { ELIMINAR_ROLES_USUARIOS('#btnEFiltros', 'FIL'); });
    $('#btnEProEsp').bind('click', function () { ELIMINAR_ROLES_USUARIOS('#btnEProEsp', 'PE'); });    

    $('#btnEMenuInd').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnEMenuInd', 'ME'); });
    $('#btnEMovPerInd').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnEMovPerInd', 'MP'); });
    $('#btnEMovConInd').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnEMovConInd', 'MC'); });
    $('#btnEMovDPInd').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnEMovDPInd', 'DP'); });
    $('#btnEMovILInd').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnEMovILInd', 'IL'); });
    $('#btnEMovRFInd').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnEMovRFInd', 'RF'); });
    $('#btnETerInd').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnETerInd', 'TR'); });
    $('#btnERepInd').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnERepInd', 'RP'); });

    $('#btnECat').bind('click', function () { ELIMINAR_CATALOGOS_INDIVIDUALES('#btnECat'); });
    $('#btnECon').bind('click', function () { ELIMINAR_CONSULTAS_INDIVIDUALES('#btnECon'); });
    $('#btnECreacionPLA').bind('click', function () { ELIMINAR_CREACIONPLA_INDIVIDUALES('#btnECreacionPLA'); });

    $('#btnEperxls').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnEperxls', 'XLS'); });
    $('#btnEperpe').bind('click', function () { ELIMINAR_PERMISOS_INDIVIDUALES('#btnEperpe', 'PE'); });


    $('#btnGpermisos').bind('click', function () { GUARDAR_ROLES_USUARIOS('#btnGpermisos'); });

    $('#btnGPerInd').bind('click', function () { GUARDAR_PERMISOS_INDIVIDUALES('#btnGPerInd'); });


    $('#chkadmin').bind('click', function () {
        if ($('#chkadmin').is(":checked") == true) {
            $('#btnBGrupo').linkbutton({ disabled: true });
            $('#btnBPermisos').linkbutton({ disabled: true });
        }
        else {
            $('#btnBGrupo').linkbutton({ disabled: false });
            $('#btnBPermisos').linkbutton({ disabled: false });
        }
    });
    

    $('#lstusurio').tree({
        onClick: function (node) {
            if (node.IdPadre != 0) {                
                idusuario = node.clave;
                HABILITAR();
                SACAR_PERMISOS(node.clave);
            }
            else {
                LIMPIAR('#btnLimpiar');
                DESHABILITAR();
            }
        }
    });

   
    $('#dgcat').datagrid('enableCellEditing').datagrid('gotoCell', {
        index: 0,
        field: 'id',
    });

    $('#dgcat').datagrid({
        pagination: false,
        enableFilter: false,
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: false,
        striped: true,
        pageSize: 20,
        checkOnSelect: false,
        selectOnCheck: false,
        onCheck: onCheck,
        onUncheck: onUncheck,
        onCheckAll: function () {
            var allRows = $(this).datagrid('getRows');
            checkedRows = allRows;
        },
        onUncheckAll: function () {
            checkedRows = [];
        },
        onLoadSuccess: function (data) {
            for (var i = 0; i < data.rows.length; i++) {
                $(this).datagrid('beginEdit', i);
            }
        }
    });


    $('#dgcon').datagrid('enableCellEditing').datagrid('gotoCell', {
        index: 0,
        field: 'id',
    });

    $('#dgcon').datagrid({
        pagination: false,
        enableFilter: false,
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: false,
        striped: true,
        pageSize: 20,
        checkOnSelect: false,
        selectOnCheck: false,
        onCheck: onCheckCon,
        onUncheck: onUncheckCon,
        onCheckAll: function () {
            var allRows = $(this).datagrid('getRows');
            checkedRowsCon = allRows;
        },
        onUncheckAll: function () {
            checkedRowsCon = [];
        },
        onLoadSuccess: function (data) {
            for (var i = 0; i < data.rows.length; i++) {
                $(this).datagrid('beginEdit', i);
            }
            if (data.rows.length > 0) { $('#btnEcon').linkbutton({ disabled: false }); }
            else { $('#btnEcon').linkbutton({ disabled: true }); }
        }
    });

    $('#dgcreacionpla').datagrid('enableCellEditing').datagrid('gotoCell', {
        index: 0,
        field: 'id',
    });

    $('#dgcreacionpla').datagrid({
        pagination: false,
        enableFilter: false,
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: false,
        striped: true,
        pageSize: 20,
        checkOnSelect: false,
        selectOnCheck: false,
        onCheck: onCheckPLa,
        onUncheck: onUncheckPla,
        onCheckAll: function () {
            var allRows = $(this).datagrid('getRows');
            checkedRowsPLa = allRows;
        },
        onUncheckAll: function () {
            checkedRowsPLa = [];
        },
        onLoadSuccess: function (data) {
            for (var i = 0; i < data.rows.length; i++) {
                $(this).datagrid('beginEdit', i);
            }
            if (data.rows.length > 0) { $('#btnECreacionPLA').linkbutton({ disabled: false }); }
            else { $('#btnECreacionPLA').linkbutton({ disabled: true }); }
        }
    });

    var text = $('#txtfiltrar');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();
            if (valor != "") {
                $('#lstusurio').tree('doFilter', valor);
                $('#lstusurio').tree('expandAll');
            }
            else {
                $('#lstusurio').tree('doFilter', '');
                //$('#lstusurio').tree('collapseAll');
            }
        }
    });

    FILTRAR_TREE_TXT('#txtFrolmenu', '#lstRMenus');
    FILTRAR_TREE_TXT('#lstRMov', '#txtFrolmov');
    FILTRAR_TREE_TXT('#txtFrolpe', '#lstRpe');
    FILTRAR_TREE_TXT('#txtFrolter', '#lstRTer');
    FILTRAR_TREE_TXT('#txtFrolrep', '#lstRRep');
    FILTRAR_TREE_TXT('#txtFrolfil', '#lstRFil');
    
    FILTRAR_TREE_TXT('#txtMovPerInd', '#tmovmpind');
    FILTRAR_TREE_TXT('#txtMovConInd', '#tmovmcind');
    FILTRAR_TREE_TXT('#txtMovDPInd', '#tmovdpind');
    FILTRAR_TREE_TXT('#txtmovRFInd', '#tmovrfind');
    FILTRAR_TREE_TXT('#txtMovIncLab', '#tmovilind');
    FILTRAR_TREE_TXT('#txtperxls', '#tperxls');
    FILTRAR_TREE_TXT('#txtperpe', '#tperpe');
    FILTRAR_TREE_TXT('#txtTerInd', '#tterind');
    FILTRAR_TREE_TXT('#txtRepInd', '#trepoind');
});


function onCheck(index, row) {
    for (var i = 0; i < checkedRows.length; i++) {
        if (checkedRows[i].id == row.id) {
            return
        }
    }
    checkedRows.push(row);
}
function onUncheck(index, row) {
    for (var i = 0; i < checkedRows.length; i++) {
        if (checkedRows[i].id == row.id) {
            checkedRows.splice(i, 1);
            return;
        }
    }
}

function onCheckCon(index, row) {
    for (var i = 0; i < checkedRowsCon.length; i++) {
        if (checkedRowsCon[i].id == row.id) {
            return
        }
    }
    checkedRowsCon.push(row);
}
function onUncheckCon(index, row) {
    for (var i = 0; i < checkedRowsCon.length; i++) {
        if (checkedRowsCon[i].id == row.id) {
            checkedRowsCon.splice(i, 1);
            return;
        }
    }
}

function onCheckPLa(index, row) {
    for (var i = 0; i < checkedRowsPLa.length; i++) {
        if (checkedRowsPLa[i].id == row.id) {
            return
        }
    }
    checkedRowsPLa.push(row);
}
function onUncheckPla(index, row) {
    for (var i = 0; i < checkedRowsPLa.length; i++) {
        if (checkedRowsPLa[i].id == row.id) {
            checkedRowsPLa.splice(i, 1);
            return;
        }
    }
}


function getChkPerInd(objtre) {
    var nodes = $(objtre).tree('getChecked', ['checked', 'indeterminate']);
    var ss = [];
    for (var i = 0; i < nodes.length; i++) {
        ss.push(nodes[i].nombre);
    }
    return ss.join(',');
}

function getChkTerInd(objtre) {
    var nodes = $(objtre).tree('getChecked', ['checked', 'indeterminate']);
    var ss = [];
    for (var i = 0; i < nodes.length; i++) {
        ss.push(nodes[i].clave);
    }
    // if (nodes.length > 0) { ss.join(','); }
    return ss.join(',');
}

function getCheckedpe(objtre) {
    var nodes = $(objtre).tree('getChecked', ['checked', 'indeterminate']);
    var ss = [];
    for (var i = 0; i < nodes.length; i++) {
        ss.push(nodes[i].clave);
    }
    return ss.join(',');
}

function getChkRepInd(objtre) {
    var nodes = $(objtre).tree('getChecked', ['checked', 'indeterminate']);
    var ss = [];
    for (var i = 0; i < nodes.length; i++) {
        ss.push(nodes[i].Id);
    }
    return ss.join(',');
}

function getPermisosCatalogos() {
    var percatalogos = "";
    $('#dgcat').datagrid('acceptChanges');
    if (checkedRows.length > 0) {
        for (var i = 0; i < checkedRows.length; i++) {
            var Agregar = 0, Modificar = 0, Eliminar = 0, Exportar = 0, Reportes = 0, Historia = 0;
            if (checkedRows[i].Agregar == "Si") { Agregar = 1; }
            if (checkedRows[i].Modificar == "Si") { Modificar = 1; }
            if (checkedRows[i].Eliminar == "Si") { Eliminar = 1; }
            if (checkedRows[i].Exportar == "Si") { Exportar = 1; }
            if (checkedRows[i].Reportes == "Si") { Reportes = 1; }
            if (checkedRows[i].Historia == "Si") { Historia = 1; }
            percatalogos += "0," + checkedRows[i].id + "," + Agregar + "," + Modificar + "," + Eliminar + "," + Historia + "," + Exportar + "," + Reportes + "|";
        }
        percatalogos = percatalogos.substring(0, percatalogos.length - 1);

    }
    return percatalogos;
}

function getEliminarCatalogos() {
    var percatalogos = "";

    if (checkedRows.length > 0) {
        $('#dgcat').datagrid('acceptChanges');
        for (var i = 0; i < checkedRows.length; i++) {
            percatalogos += checkedRows[i].id + ",";
        }
        percatalogos = percatalogos.substring(0, percatalogos.length - 1);

        return percatalogos;
    }
    else { $.messager.alert('Error', 'Falta Seleccionar el catálogo guardar', 'error'); }
}

function getEliminarConsultas() {
    var perconsultas = "";
    if (checkedRowsCon.length > 0) {
        $('#dgcon').datagrid('acceptChanges');
        for (var i = 0; i < checkedRowsCon.length; i++) {
            perconsultas += idusuario + ";" + checkedRowsCon[i].id + ';histmovper=' + ((checkedRowsCon[i].histmovper == 'Si') ? 1 : 0) + ',histmovcon=' + ((checkedRowsCon[i].histmovcon == 'Si') ? 1 : 0) +
                ',histdatper=' + ((checkedRowsCon[i].histdatper == 'Si') ? 1 : 0) + ',histreffam=' + ((checkedRowsCon[i].histreffam == 'Si') ? 1 : 0) +
                ',histmovesp=' + ((checkedRowsCon[i].histmovesp == 'Si') ? 1 : 0) + ',histinclab=' + ((checkedRowsCon[i].histinclab == 'Si') ? 1 : 0) +
                ',histcapter=' + ((checkedRowsCon[i].histcapter == 'Si') ? 1 : 0) + ',histplazas=' + ((checkedRowsCon[i].histplazas == 'Si') ? 1 : 0) +
                ',histdetnom=' + ((checkedRowsCon[i].histdetnom == 'Si') ? 1 : 0) + ',histimgexp=' + ((checkedRowsCon[i].histimgexp == 'Si') ? 1 : 0) + '|';
        }
        perconsultas = perconsultas.substring(0, perconsultas.length - 1);

        return perconsultas;
    }
    else { $.messager.alert('Error', 'Falta Seleccionar la consulta de historia a guardar', 'error'); }
}

function getEliminarCreacionPla() {
    var perplazas = "";
    if (checkedRowsPLa.length > 0) {
        $('#dgcreacionpla').datagrid('acceptChanges');
        for (var i = 0; i < checkedRowsPLa.length; i++) {
            perplazas += idusuario + ";" + checkedRowsPLa[i].id + ';btnnormal=' + ((checkedRowsPLa[i].PlaNormales == 'Si') ? 1 : 0) + ',btninterinos=' + ((checkedRowsPLa[i].PlaInterinos == 'Si') ? 1 : 0) +
                ',btnjubpen=' + ((checkedRowsPLa[i].PlaJubPen == 'Si') ? 1 : 0) + ',btnnoemp=' + ((checkedRowsPLa[i].PlaNoEmp == 'Si') ? 1 : 0)
        }
        // perplazas = perplazas.substring(0, perplazas.length - 1);

        return perplazas;
    }
    else { $.messager.alert('Error', 'Falta Seleccionar el menu a eliminar', 'error'); }
}

function getPermisosConsultas() {
    var perconsultas = "";
    $('#dgcon').datagrid('acceptChanges');
    if (checkedRowsCon.length > 0) {
        for (var i = 0; i < checkedRowsCon.length; i++) {
            var histmovper = 0, histmovcon = 0, histdatper = 0, histreffam = 0, histmovesp = 0, histinclab = 0, histcapter = 0, histplazas = 0, histdetnom = 0, histimgexp = 0;
            if (checkedRowsCon[i].histmovper == "Si") { histmovper = 1; }
            if (checkedRowsCon[i].histmovcon == "Si") { histmovcon = 1; }
            if (checkedRowsCon[i].histdatper == "Si") { histdatper = 1; }
            if (checkedRowsCon[i].histreffam == "Si") { histreffam = 1; }
            if (checkedRowsCon[i].histmovesp == "Si") { histmovesp = 1; }
            if (checkedRowsCon[i].histinclab == "Si") { histinclab = 1; }
            if (checkedRowsCon[i].histcapter == "Si") { histcapter = 1; }
            if (checkedRowsCon[i].histplazas == "Si") { histplazas = 1; }
            if (checkedRowsCon[i].histdetnom == "Si") { histdetnom = 1; }
            if (checkedRowsCon[i].histimgexp == "Si") { histimgexp = 1; }
            perconsultas += 0 + "," + checkedRowsCon[i].id + "," + histmovper + "," + histmovcon + "," + histdatper + "," + histreffam + "," + histmovesp + "," + histinclab + "," + histcapter + "," + histplazas + "," + histdetnom + "," + histimgexp + "|";
        }
        perconsultas = perconsultas.substring(0, perconsultas.length - 1);
    }
    else {
        perconsultas = "";
        //$.messager.alert('Error', 'Falta Seleccionar el catálogo guardar', 'error');
    }
    return perconsultas;
}

function getPermisosPlazas() {
    var perplazas = "";
    $('#dgcreacionpla').datagrid('acceptChanges');
    if (checkedRowsPLa.length > 0) {
        for (var i = 0; i < checkedRowsPLa.length; i++) {
            var PlaNormales = 0, PlaInterinos = 0, PlaJubPen = 0, PlaNoEmp = 0;
            if (checkedRowsPLa[i].PlaNormales == "Si") { PlaNormales = 1; }
            if (checkedRowsPLa[i].PlaInterinos == "Si") { PlaInterinos = 1; }
            if (checkedRowsPLa[i].PlaJubPen == "Si") { PlaJubPen = 1; }
            if (checkedRowsPLa[i].PlaNoEmp == "Si") { PlaNoEmp = 1; }
            perplazas = 0 + "," + checkedRowsPLa[i].id + "," + PlaNormales + "," + PlaInterinos + "," + PlaJubPen + "," + PlaNoEmp;
        }
        //perplazas = perplazas.substring(0, perplazas.length - 1);
    }
    else {
        perplazas = "";
        //$.messager.alert('Error', 'Falta Seleccionar el catálogo guardar', 'error');
    }
    return perplazas;
}


function DESHABILITAR() {
    $('#txtusuario').textbox({ readonly: true });
    $('#txtcontraseña').textbox({ readonly: true });
    $('#txtnombres').textbox({ readonly: true });
    $('#txtappaterno').textbox({ readonly: true });
    $('#txtapmaterno').textbox({ readonly: true });
    $('#dtvigenciaini').datebox({ readonly: true });
    $('#dtvigenciafin').datebox({ readonly: true });
    $('#cbotipousuario').combobox({ readonly: true });
    $('#txtcorreo').textbox({ readonly: true });
    $('#chkestatus').attr("disabled", true);
    $('#chkadmin').attr("disabled", true);
    $('#chkconexterna').attr("disabled", true);

    $('#btnBGrupo').linkbutton('disable');
    $('#btnBPermisos').linkbutton('disable');


    $('#btnGuardar').linkbutton('disable');
    $('#btnLimpiar').linkbutton('disable');
}

function HABILITAR() {
    $('#txtusuario').textbox({ readonly: false });
    $('#txtcontraseña').textbox({ readonly: false });
    $('#txtnombres').textbox({ readonly: false });
    $('#txtappaterno').textbox({ readonly: false });
    $('#txtapmaterno').textbox({ readonly: false });
    $('#dtvigenciaini').datebox({ readonly: false });
    $('#dtvigenciafin').datebox({ readonly: false });
    $('#cbotipousuario').combobox({ readonly: false });
    $('#txtcorreo').textbox({ readonly: false });

    $('#chkestatus').attr("disabled", false);
    $('#chkadmin').attr("disabled", false);
    $('#chkconexterna').attr("disabled", false);

    $('#btnBGrupo').linkbutton('enable');
    $('#btnBPermisos').linkbutton('enable');

    $('#btnLimpiar').linkbutton('enable');
    $('#btnGuardar').linkbutton('enable');
}

function LIMPIAR(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        $('#txtusuario').textbox('setValue', '');
        $('#txtcontraseña').textbox('setValue', '');
        $('#txtnombres').textbox('setValue', '');
        $('#txtappaterno').textbox('setValue', '');
        $('#txtapmaterno').textbox('setValue', '');
        $('#dtvigenciaini').datebox('setValue', '');
        $('#dtvigenciafin').datebox('setValue', '');
        $('#cbotipousuario').combobox('setValue', 'x');
        $('#txtcorreo').textbox('setValue', '');
        document.getElementById('chkadmin').checked = false;
        document.getElementById('chkestatus').checked = false;

        $('#btnBGrupo').linkbutton('disable');
        $('#btnBPermisos').linkbutton('disable');

        DESHABILITAR();

        LIMPIAR_NODE_TREE('#lstusurio');
        idusuario = "";
    }
}

function NUEVO(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        HABILITAR();
        $('#btnBGrupo').linkbutton({ disabled: false });
        $('#btnBPermisos').linkbutton({ disabled: false });
        $('#txtusuario').textbox('clear').textbox('textbox').focus();
        document.getElementById('chkestatus').checked = true;
    }
}


/*SACAR LA LISTA DE USUARIO*/
function LISTAR_USUARIOS() {
    var parametros = {};
    parametros.strfiltro = "";
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_USUARIOS',
        data: JSON.stringify(parametros),
        dataType: "json",
        async: false,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[0]);
            $('#lstusurio').tree({
                data: obj
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}

/*SACAR LOS DATOS DEL USUARIO*/
function SACAR_PERMISOS(fkusuario) {
    var parametros = {};
    parametros.fkusuario = fkusuario;
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_DATOS_USUARIO',
        data: JSON.stringify(parametros),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[0]);                                  
            $('#txtusuario').textbox('setValue', obj.Usuario);
            $('#txtcontraseña').textbox('setValue', obj.Contraseña);
            $('#txtnombres').textbox('setValue', obj.Nombres);
            $('#txtcorreo').textbox('setValue', obj.Correo);
            $('#txtappaterno').textbox('setValue', obj.APPaterno);
            $('#txtapmaterno').textbox('setValue', obj.APMaterno);
            $('#dtvigenciaini').datebox('setValue', obj.VigenciaIni);
            $('#dtvigenciafin').datebox('setValue', obj.VigenciaFin);
            $('#cbotipousuario').combobox('setValue', obj.IdGrupo);
            if (obj.EsAdmin == "True") {
                    document.getElementById('chkadmin').checked = true;                
                }
                else {
                    document.getElementById('chkadmin').checked = false;                    
                }
            if (obj.Estatus == "True") { document.getElementById('chkestatus').checked = true; }
                else { document.getElementById('chkestatus').checked = false; }

            if (obj.ConsultaExterna == "True") { document.getElementById('chkconexterna').checked = true; }
                else { document.getElementById('chkconexterna').checked = false; }

        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}

/*GUARDAR DATOS DEL USUARIO*/
function GUARDAR(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if ($('#txtusuario').textbox('getValue') == "") { $.messager.alert('Error', "Falta el usuario", 'error'); }
        else
            if ($('#txtcontraseña').textbox('getValue') == "") { $.messager.alert('Error', "Falta la contraseña", 'error'); }
            else {
                if (idusuario == "") { idusuario = 0; }

                var parametros = {};
                parametros.id = idusuario;
                parametros.usuario = $('#txtusuario').textbox('getValue');
                parametros.contraseña = $('#txtcontraseña').textbox('getValue');
                parametros.appaterno = $('#txtappaterno').textbox('getValue');
                parametros.apmaterno = $('#txtapmaterno').textbox('getValue');
                parametros.nombres = $('#txtnombres').textbox('getValue');
                parametros.correo = $('#txtcorreo').textbox('getValue');
                parametros.vigenciaini = $('#dtvigenciaini').datebox('getValue');
                parametros.vigenciafin = $('#dtvigenciafin').datebox('getValue');
                parametros.idgrupo = $('#cbotipousuario').combobox('getValue');
                parametros.estatus = $('#chkestatus').is(":checked");
                parametros.esadmin = $('#chkadmin').is(":checked");
                parametros.conexterna = $('#chkconexterna').is(":checked");
                $.ajax({
                    type: "POST",
                    url: "../funciones/Fun_AdministracionDeUsuarios.aspx/Guardar_Usuario",
                    data: JSON.stringify(parametros),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    beforeSend: function () {
                        $('#loading').show();
                    },
                    success: function (data) {
                        if (data.d[0] == "0") {
                            $.messager.alert('Información', data.d[1], 'info');
                            LISTAR_USUARIOS();
                            LIMPIAR('#btnLimpiar');
                        }
                        else { $.messager.alert('Error', data.d[1], 'error'); }
                    },
                    error: function (er) {
                        $('#loading').hide();
                        $.messager.alert('Error', er.statusText, 'error');
                    },
                    complete: function () {
                        $('#loading').hide(100);
                    }
                });
            }
    }
}

/*METODOS DE LA LISTA DE ROLES */
function LIMPIAR_ROLES() {
    LIMPIAR_NODE_TREE('#lstRMenus');
    $('#txtFrolmenu').textbox('setValue', '');
    LIMPIAR_NODE_TREE('#lstRMov');
    $('#txtFrolmov').textbox('setValue', '');
    LIMPIAR_NODE_TREE('#lstRRep');
    $('#txtFrolrep').textbox('setValue', '');
    LIMPIAR_NODE_TREE('#lstRTer');
    $('#txtFrolter').textbox('setValue', '');
    LIMPIAR_NODE_TREE('#lstRpe');
    $('#txtFpe').textbox('setValue', '');
}
function LISTAR_ROLES(tobj, tipo) {
    var parametros = {};
    parametros.idusuario = idusuario;
    parametros.tiporol = tipo;    
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/Lista_de_Roles',
        data: JSON.stringify(parametros),
        dataType: "json",      
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[0]);
            $(tobj).tree({
                data: obj
            });
            if (data.d[1] != 'null')
                {
                var objp = jQuery.parseJSON(data.d[1]);
                if (objp.length == 0) {
                    if (tipo == 'menu') { $('#btnEMenus').linkbutton({ disabled: true }); }
                    if (tipo == 'mov') { $('#btnEMovimientos').linkbutton({ disabled: true }); }
                    if (tipo == 'rep') { $('#btnEReportes').linkbutton({ disabled: true }); }
                    if (tipo == 'ter') { $('#btnETerceros').linkbutton({ disabled: true }); }
                    if (tipo == 'fil') { $('#btnEFiltros').linkbutton({ disabled: true }); }
                    if (tipo == 'pe') { $('#btnEpe').linkbutton({ disabled: true }); }
                }
                else {
                    if (tipo == 'menu') { $('#btnEMenus').linkbutton({ disabled: false }); }
                    if (tipo == 'mov') { $('#btnEMovimientos').linkbutton({ disabled: false }); }
                    if (tipo == 'rep') { $('#btnEReportes').linkbutton({ disabled: false }); }
                    if (tipo == 'ter') { $('#btnETerceros').linkbutton({ disabled: false }); }
                    if (tipo == 'fil') { $('#btnEFiltros').linkbutton({ disabled: false }); }
                    if (tipo == 'pe') { $('#btnEpe').linkbutton({ disabled: false }); }

                    var tri = $(tobj).tree('getRoots');
                    for (var j = 0; j < objp.length; j++) {
                        for (var h = 0; h < tri.length; h++) {
                            if (tipo == 'menu') {
                                if (objp[j].clave == tri[h].clave) {
                                    $(tobj).tree('check', tri[h].target)
                                    break;
                                }
                            }
                            else
                                if (tipo == 'mov') {
                                    if (objp[j].clave == tri[h].clave) {
                                        $(tobj).tree('check', tri[h].target)
                                        break;
                                    }
                                }
                                else
                                    if (tipo == 'rep') {
                                        if (objp[j].clave == tri[h].clave) {
                                            $(tobj).tree('check', tri[h].target)
                                            break;
                                        }
                                    }
                                    else
                                        if (tipo == 'ter') {
                                            if (objp[j].clave == tri[h].clave) {
                                                $(tobj).tree('check', tri[h].target)
                                                break;
                                            }
                                        }
                                        else
                                            if (tipo == 'fil') {
                                                if (objp[j].clave == tri[h].clave) {
                                                    $(tobj).tree('check', tri[h].target)
                                                    break;
                                                }
                                            }
                                            else
                                                if (tipo == 'xls') {
                                                    if (objp[j].clave == tri[h].clave) {
                                                        $(tobj).tree('check', tri[h].target)
                                                        break;
                                                    }
                                                }
                                                else
                                                    if (tipo == 'pe') {
                                                        if (objp[j].clave == tri[h].clave) {
                                                            $(tobj).tree('check', tri[h].target)
                                                            break;
                                                        }
                                                    }
                        }
                    }
                }
            
            }
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}
function CARGAR_ROLES(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        LISTAR_ROLES('#lstRMenus', 'menu');
        LISTAR_ROLES('#lstRMov', 'mov');
        LISTAR_ROLES('#lstRRep', 'rep');
        LISTAR_ROLES('#lstRTer', 'ter');
        LISTAR_ROLES('#lstRpe', 'pe');

        if (document.getElementById('chkconexterna').checked == true) {
            $('#tfiltros').show();
            LISTAR_ROLES('#lstRFil', 'fil');
        }
        else {
            $('#btnEFiltros').linkbutton({ disabled: true });
            $('#tfiltros').hide();
            var p = $('#tproles').tabs('getTab', 5);
            p.panel('options').tab.hide();
        }

        windows("#winroll", 700, 550, "Permisos por Grupos");
    }
}


/*METODOS DE LA LISTA DE PERMISOS INDIVIDUALES*/
function CARGAR_MENUS_TREE(tobj) {
    $.ajax({
        type: "POST",
        url: "../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_MENU",
        dataType: "json",
        contentType: "application/json; charset=utf-8",       
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[0]);
            $(tobj).tree({
                data: obj
            });
           // $(tobj).tree('collapseAll');
            LISTAR_PERMISOS_INDIVIDUALES(tobj, 'ME');
        },
        error: function (er) {
            $('#loading').hide();
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () {
          //  $('#loading').hide(100);
        }
    });
}
function LISTAR_PERMISOS_INDIVIDUALES(tobj, tipo) {
    var parametros = {};
    parametros.tiporol = tipo;
    parametros.idusuario = idusuario;
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_PERMISOS_INDIVIDUALES',
        data: JSON.stringify(parametros),
        dataType: "json",       
        contentType: "application/json; charset=utf-8",       
        success: function (data) {
            var objp = jQuery.parseJSON(data.d[0]);
            if (objp.length == 0) {
                if (tipo == 'ME') { $('#btnEMenuInd').linkbutton({ disabled: true }); }
                if (tipo == 'MP') { $('#btnEMovPerInd').linkbutton({ disabled: true }); }
                if (tipo == 'MC') { $('#btnEMovConInd').linkbutton({ disabled: true }); }
                if (tipo == 'IL') { $('#btnEMovILInd').linkbutton({ disabled: true }); }
                if (tipo == 'DP') { $('#btnEMovDPInd').linkbutton({ disabled: true }); }
                if (tipo == 'RF') { $('#btnEMovRFInd').linkbutton({ disabled: true }); }
                if (tipo == 'RP') { $('#btnERepInd').linkbutton({ disabled: true }); }
                if (tipo == 'TR') { $('#btnETerInd').linkbutton({ disabled: true }); }
                if (tipo == 'XLS') { $('#btnEperxls').linkbutton({ disabled: true }); }
                if (tipo == 'PE') { $('#btnEperpe').linkbutton({ disabled: true }); }
            }
            else {
                if (tipo == 'ME') { $('#btnEMenuInd').linkbutton({ disabled: false }); }
                if (tipo == 'MP') { $('#btnEMovPerInd').linkbutton({ disabled: false }); }
                if (tipo == 'MC') { $('#btnEMovConInd').linkbutton({ disabled: false }); }
                if (tipo == 'DP') { $('#btnEMovDPInd').linkbutton({ disabled: false }); }
                if (tipo == 'RF') { $('#btnEMovRFInd').linkbutton({ disabled: false }); }
                if (tipo == 'IL') { $('#btnEMovILInd').linkbutton({ disabled: false }); }
                if (tipo == 'RP') { $('#btnERepInd').linkbutton({ disabled: false }); }
                if (tipo == 'TR') { $('#btnETerInd').linkbutton({ disabled: false }); }
                if (tipo == 'IL') { $('#btnEIncLab').linkbutton({ disabled: false }); }
                if (tipo == 'PE') { $('#btnEperpe').linkbutton({ disabled: false }); }
                if (tipo == 'XLS') { $('#btnEperxls').linkbutton({ disabled: false }); }

                if (objp.length > 0) {
                    var tri = $(tobj).tree('getRoots');
                    for (var h = 0; h < tri.length; h++) {
                        if ((tipo != 'TR') && (tipo != 'XLS') && (tipo != 'PE')) {
                            var tree = $(tobj).tree('getChildren', tri[h].target);
                            if (tree.length == 0) {
                                for (var j = 0; j < objp.length; j++) {
                                    if (objp[j].fkPermisoInd == tri[h].Id) {
                                        $(tobj).tree('check', tri[h].target);
                                    }
                                }
                            }
                            else {
                                for (var i = 0; i < tree.length; i++) {
                                    for (var j = 0; j < objp.length; j++) {
                                        if (objp[j].fkPermisoInd == tree[i].Id) {
                                            $(tobj).tree('check', tree[i].target)
                                        }

                                        if (objp[j].fkPermisoInd == tri[h].Id) {
                                            $(tobj).tree('check', tri[h].target);
                                        }
                                    }
                                }
                            }
                        }
                        else {
                            for (var j = 0; j < objp.length; j++) {
                                if (objp[j].fkPermisoInd == tri[h].clave) {
                                    $(tobj).tree('check', tri[h].target)
                                    break;
                                }
                            }
                        }
                    }
                }
            }
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
function CARGAR_MOVIMIENTOS_TREE(tobj, tipo, abierto) {
    var parametros = {};
    parametros.strtipo = tipo;   
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_MOVIMIENTOS',
        data: JSON.stringify(parametros),
        dataType: "json",        
        contentType: "application/json; charset=utf-8",       
        success: function (data) {
            var obj = $.parseJSON(data.d[0]);
            $(tobj).tree({
                data: obj
                //onLoadSuccess: function (node, data) {
                //    if (abierto == "Si") { expandTree(tobj); }
                //    else { $(tobj).tree('collapseAll'); }
                //},
                //formatter: function (node) {
                //    return '<span title=\'' + node.nombre + "-" + node.text + '\' class=\'easyui-tooltip\'>' + node.text + '</span>';
                //},
            });
            LISTAR_PERMISOS_INDIVIDUALES(tobj, tipo);
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', err.statusText, 'error');
        },
        complete: function () {//$('#loading').hide(100);
        }
    });
}
function LISTAR_CATALOGOS(dgcontrol, fkroll) {
    var parametros = {};
    parametros.idusuario = fkroll;
    parametros.tipo = "I";
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_MENU_CATALOGOS',
        data: JSON.stringify(parametros),
        dataType: "json",       
        contentType: "application/json; charset=utf-8",        
        success: function (data) {
            var obj = $.parseJSON(data.d[0]);
            if (obj.length>0) { $('#btnECat').linkbutton({ disabled: true }); } else { $('#btnECat').linkbutton({ disabled: false }); }

            $(dgcontrol).datagrid({
                data: obj,
                enableFilter: false,
                rownumbers: true,
                singleSelect: true,
                striped: true,
                pageSize: 20
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', err.statusText, 'error');
        },
        complete: function () {
            //$('#loading').hide(100);
        }
    });
}
function LISTAR_CONSULTAS(dgcontrol, fkroll) {
    var parametros = {};
    parametros.idusuario = fkroll;
    parametros.tipo = "I";
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_MENU_CONSULTASHISTORIA',
        data: JSON.stringify(parametros),
        dataType: "json",      
        contentType: "application/json; charset=utf-8",       
        success: function (data) {
            var obj = $.parseJSON(data.d[0]);
            if (obj.length>0) { $('#btnECon').linkbutton({ disabled: true }); } else { $('#btnECon').linkbutton({ disabled: false }); }

            $(dgcontrol).datagrid({
                data: obj,
                enableFilter: false,
                rownumbers: true,
                singleSelect: true,
                striped: true,
                pageSize: 20
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', err.statusText, 'error');
        },
        complete: function () {
            //$('#loading').hide(100);
        }
    });
}
function LISTAR_CREACIONPLAZAS(dgcontrol, fkroll) {
    var parametros = {};
    parametros.idusuario = fkroll;
    parametros.tipo = "I";
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_MENU_CREACIONPLAZAS',
        data: JSON.stringify(parametros),
        dataType: "json",       
        contentType: "application/json; charset=utf-8",       
        success: function (data) {
            var obj = $.parseJSON(data.d[0]);
            if (obj.length>0) { $('#btnECreacionPLA').linkbutton({ disabled: true }); } else { $('#btnECreacionPLA').linkbutton({ disabled: false }); }

            $(dgcontrol).datagrid({
                data: obj,
                enableFilter: false,
                rownumbers: true,
                singleSelect: true,
                striped: true,
                pageSize: 20
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', err.statusText, 'error');
        },
        complete: function () {
            //$('#loading').hide(100);
        }
    });
}
function LISTAR_FORMATOS(tobjeto) {
    var parametros = {};
    parametros.idformatos = '';
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_REPORTES',
        data: JSON.stringify(parametros),
        dataType: "json",        
        contentType: "application/json; charset=utf-8",       
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[0]);
            //objformatos = jQuery.parseJSON(data.d[1]);

            $(tobjeto).tree({
                data: obj
            });
           // $(tobjeto).tree('collapseAll');
            LISTAR_PERMISOS_INDIVIDUALES('#trepoind', 'RP');
        },
        error: function (er) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () {
            //$('#loading').hide(100);
        }
    });
}
function LISTAR_TERCEROS(tobj) {
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_TERCEROS',
        dataType: "json",      
        contentType: "application/json; charset=utf-8",        
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[0]);

            $(tobj).tree({
                data: obj
            });
            LISTAR_PERMISOS_INDIVIDUALES('#tterind', 'TR');
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
function CARGAR_PROCESOS_ESPECIALES() {
    $.ajax({
        type: "POST",
        url: '../funciones/Fun_AdministracionDeUsuarios.aspx/LISTAR_PROCESOSESPECIALES',
        dataType: "json",       
        contentType: "application/json; charset=utf-8",      
        success: function (data) {
            var objxls = $.parseJSON(data.d[0]);
            var objpe = $.parseJSON(data.d[1]);

            $('#tperxls').tree({
                data: objxls               
            });

            $('#tperpe').tree({
                data: objpe                
            });
            LISTAR_PERMISOS_INDIVIDUALES('#tperxls', 'XLS');
            LISTAR_PERMISOS_INDIVIDUALES('#tperpe', 'PE');

        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', err.statusText, 'error');
        },
        complete: function () {
            //$('#loading').hide(100);
        }
    });
}

/*CARGAR LOS PERMISOS INDIVIDUALES*/
function CARGAR_LISTA_INDIVIDUALES(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
   
        CARGAR_MENUS_TREE('#tmenusind');
        CARGAR_MOVIMIENTOS_TREE('#tmovmpind', 'MP', 'No');
        CARGAR_MOVIMIENTOS_TREE('#tmovmcind', 'MC', 'No');
        CARGAR_MOVIMIENTOS_TREE('#tmovdpind', 'DP', 'Si');
        CARGAR_MOVIMIENTOS_TREE('#tmovrfind', 'RF', 'Si');
        CARGAR_MOVIMIENTOS_TREE('#tmovilind', 'IL', 'No');

        LISTAR_CATALOGOS('#dgcat', idusuario);
        LISTAR_CONSULTAS('#dgcon', idusuario);
        checkedRowsPLa = [];
        LISTAR_CREACIONPLAZAS('#dgcreacionpla', idusuario);

        LISTAR_FORMATOS('#trepoind');
        LISTAR_TERCEROS('#tterind');

        CARGAR_PROCESOS_ESPECIALES();

        $('#loading').hide(100);
        windows("#wrolindividual", 800, 600, "Permisos Individuales");
    }
}


/*GUARDAR ROLES DE USUARIOS*/
function GUARDAR_ROLES_USUARIOS(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var parametros = {};
        parametros.idusuario = idusuario;
        parametros.fkrolmenu = getCheckedMov('#lstRMenus');
        parametros.fkrolmov = getCheckedMov('#lstRMov');
        parametros.fkrolrep = getCheckedMov('#lstRRep');
        parametros.fkrolter = getCheckedMov('#lstRTer');
        parametros.fkrolfil = getCheckedMov('#lstRFil');
        parametros.fkrolpe = getCheckedpe('#lstRpe');
        $.ajax({
            type: "POST",
            url: "../funciones/Fun_AdministracionDeUsuarios.aspx/GUARDAR_ROLES_USUARIOS",
            data: JSON.stringify(parametros),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                $('#loading').show();
            },
            success: function (data) {
                var objmsg = $.parseJSON(data.d[0]);
                if (objmsg[0].Error == 0) {
                    $.messager.alert('Información', objmsg[0].Mensaje, 'info');

                    LISTAR_CATALOGOS('#dgcat', idusuario);

                }
                else { $.messager.alert('Error', objmsg[0].Mensaje, 'error'); }
            },
            error: function (er) {
                $('#loading').hide();
                $.messager.alert('Error', er.statusText, 'error');
            },
            complete: function () {
                $('#loading').hide(100);
            }
        });
    }
}

/*GUARDAR PERMISOS INDIVIDUALES*/
function GUARDAR_PERMISOS_INDIVIDUALES(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var parametros = {};
        parametros.idusuario = idusuario;
        parametros.fkmenu = getChecked('#tmenusind');
        parametros.fkmovmp = getChkPerInd('#tmovmpind');
        parametros.fkmovmc = getChkPerInd('#tmovmcind');
        parametros.fkmovdp = getChkPerInd('#tmovdpind');
        parametros.fkmovil = getChkPerInd('#tmovilind');
        parametros.fkmovrf = getChkPerInd('#tmovrfind');
        parametros.fkrep = getChkRepInd('#trepoind');
        parametros.fkter = getChkTerInd('#tterind');
        parametros.fkpermisoscatalogos = getPermisosCatalogos();
        parametros.fkpermisosxls = getChkTerInd('#tperxls');
        parametros.fkpermisospe = getChkTerInd('#tperpe');
        parametros.fkpermisosconsultas = getPermisosConsultas();
        parametros.fkpermisosplazas = getPermisosPlazas();
        $.ajax({
            type: "POST",
            url: "../funciones/Fun_AdministracionDeUsuarios.aspx/GUARDAR_PERMISOSOS_INDIVIDUALES",
            data: JSON.stringify(parametros),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                $('#loading').show();
            },
            success: function (data) {
                var objmsg = $.parseJSON(data.d[0]);
               
                if (objmsg[0].Error == 0) {
                    $.messager.alert('Información', objmsg[0].Mensaje, 'info');

                    LISTAR_CATALOGOS('#dgcat', idusuario);
                    LISTAR_CONSULTAS('#dgcon', idusuario);
                    LISTAR_CREACIONPLAZAS('#dgcreacionpla', idusuario);

                    var objcont = $.parseJSON(data.d[1]);

                    for (var h = 0; h < objcont.length; h++) {
                        if (objcont[h].modulo == 'ME') {
                            if (objcont[h].contador > 0) { $('#btnEMenuInd').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'MP') {
                            if (objcont[h].contador > 0) { $('#btnEMovPerInd').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'MC') {
                            if (objcont[h].contador > 0) { $('#btnEMovConInd').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'IL') {
                            if (objcont[h].contador > 0) { $('#btnEMovILInd').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'DP') {
                            if (objcont[h].contador > 0) { $('#btnEMovDPInd').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'RF') {
                            if (objcont[h].contador > 0) { $('#btnEMovRFInd').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'RP') {
                            if (objcont[h].contador > 0) { $('#btnERepInd').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'TR') {
                            if (objcont[h].contador > 0) { $('#btnETerInd').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'XLS') {
                            if (objcont[h].contador > 0) { $('#btnEperxls').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'PE') {
                            if (objcont[h].contador > 0) { $('#btnEperpe').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'CAT') {
                            if (objcont[h].contador > 0) { $('#btnECat').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'CON') {
                            if (objcont[h].contador > 0) { $('#btnECon').linkbutton({ disabled: false }); continue; }
                        }
                        if (objcont[h].modulo == 'PLA') {
                            if (objcont[h].contador > 0) { $('#btnECreacionPLA').linkbutton({ disabled: false }); continue; }
                        }
                    }
                }
                else { $.messager.alert('Error', objmsg[0].Mensaje, 'error'); }
            },
            error: function (er) {
                $('#loading').hide();
                $.messager.alert('Error', er.statusText, 'error');
            },
            complete: function () {
                $('#loading').hide(100);
            }
        });
    }
}



/*ELIMINAR ROLES DE USUARIOS*/
function ELIMINAR_ROLES_USUARIOS(btnobj, tipopermiso) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var Permisos = [];
        if (tipopermiso == "MENU") { Permisos = getCheckedMov('#lstRMenus'); }
        if (tipopermiso == "MOV") { Permisos = getCheckedMov('#lstRMov'); }
        if (tipopermiso == "REP") { Permisos = getCheckedMov('#lstRRep'); }
        if (tipopermiso == "TER") { Permisos = getCheckedMov('#lstRTer'); }
        if (tipopermiso == "FIL") { Permisos = getCheckedMov('#lstRFil'); }
        if (tipopermiso == "PE") { Permisos = getCheckedpe('#lstRpe'); }

        var parametros = {};
        parametros.idusuario = idusuario;
        parametros.tipopermiso = tipopermiso;
        parametros.fkroles = Permisos;
        $.ajax({
            type: "POST",
            url: "../funciones/Fun_AdministracionDeUsuarios.aspx/ELIMINAR_ROLES_USUARIOS",
            data: JSON.stringify(parametros),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                $('#loading').show();
            },
            success: function (data) {
                if (data.d[0] == "0") {
                    $.messager.alert('Información', data.d[1], 'info');

                    if (tipopermiso == "MENU") {
                        LIMPIAR_NODE_TREE('#lstRMenus');
                        $('#txtFrolmenu').textbox('setValue', '');
                        $('#btnEMenus').linkbutton({ enabled: false });
                    }
                    if (tipopermiso == "MOV") {
                        LIMPIAR_NODE_TREE('#lstRMov');
                        $('#txtFrolmov').textbox('setValue', '');
                        $('#btnEMovimientos').linkbutton({ enabled: false });
                    }
                    if (tipopermiso == "REP") {
                        LIMPIAR_NODE_TREE('#lstRRep');
                        $('#txtFrolrep').textbox('setValue', '');
                        $('#btnEReportes').linkbutton({ enabled: false });
                    }
                    if (tipopermiso == "TER") {
                        LIMPIAR_NODE_TREE('#lstRTer');
                        $('#txtFrolter').textbox('setValue', '');
                        $('#btnETerceros').linkbutton({ enabled: false });
                    }
                    if (tipopermiso == "PE") {
                        LIMPIAR_NODE_TREE('#lstRpe');
                        $('#txtFrolpe').textbox('setValue', '');
                        $('#btnEproesp').linkbutton({ enabled: false });
                    }
                }
                else { $.messager.alert('Error', data.d[1], 'error'); }
            },
            error: function (er) {
                $('#loading').hide();
                $.messager.alert('Error', er.statusText, 'error');
            },
            complete: function () {
                $('#loading').hide(100);
            }
        });
    }
}

/*ELIMINAR PERMISOS INDIVIDUALES*/
function ELIMINAR_PERMISOS_INDIVIDUALES(btnobj, tipopermiso) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var Permisos = [];
        if (tipopermiso == "ME") { Permisos = getChecked('#tmenusind'); }
        if (tipopermiso == "MP") { Permisos = getChkPerInd('#tmovmpind'); }
        if (tipopermiso == "MC") { Permisos = getChkPerInd('#tmovmcind'); }
        if (tipopermiso == "DP") { Permisos = getChkPerInd('#tmovdpind'); }
        if (tipopermiso == "IL") { Permisos = getChkPerInd('#tmovilind'); }
        if (tipopermiso == "RF") { Permisos = getChkPerInd('#tmovrfind'); }
        if (tipopermiso == "TR") { Permisos = getChkTerInd('#tterind'); }
        if (tipopermiso == "RP") { Permisos = getChkPerInd('#trepoind'); }
        if (tipopermiso == "XLS") { Permisos = getChkTerInd('#tperxls'); }
        if (tipopermiso == "PE") { Permisos = getChkTerInd('#tperpe'); }

        if (Permisos != "") {
            var parametros = {};
            parametros.idusuario = idusuario;
            parametros.tipopermiso = tipopermiso;
            parametros.fkpermisos = Permisos;
            $.ajax({
                type: "POST",
                url: "../funciones/Fun_AdministracionDeUsuarios.aspx/ELIMINAR_PERMISOS_INDIVIDUALES",
                data: JSON.stringify(parametros),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {
                    $('#loading').show();
                },
                success: function (data) {
                    if (data.d[0] == "0") {
                        $.messager.alert('Información', data.d[1], 'info');

                        if (tipopermiso == "ME") {
                            LIMPIAR_NODE_TREE('#tmenusind');
                            $('#txtMenuInd').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnEMenuInd').linkbutton({ disabled: true }); } else { $('#btnEMenuInd').linkbutton({ disabled: true }); }
                        }
                        if (tipopermiso == "MP") {
                            LIMPIAR_NODE_TREE('#tmovmpind');
                            $('#txtMovPerInd').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnEMovPerInd').linkbutton({ disabled: true }); } else { $('#btnEMovPerInd').linkbutton({ disabled: true }); }
                        }
                        if (tipopermiso == "MC") {
                            LIMPIAR_NODE_TREE('#tmovmcind');
                            $('#txtMovConInd').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnEMovConInd').linkbutton({ disabled: true }); } else { $('#btnEMovConInd').linkbutton({ disabled: true }); }
                        }
                        if (tipopermiso == "DP") {
                            LIMPIAR_NODE_TREE('#tmovdpind');
                            $('#txtMovDPInd').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnEMovDPInd').linkbutton({ disabled: true }); } else { $('#btnEMovDPInd').linkbutton({ disabled: true }); }
                        }
                        if (tipopermiso == "IL") {
                            LIMPIAR_NODE_TREE('#tmovilind');
                            $('#txtMovILInd').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnEMovILInd').linkbutton({ disabled: true }); } else { $('#btnEMovILInd').linkbutton({ disabled: true }); }
                        }
                        if (tipopermiso == "RF") {
                            LIMPIAR_NODE_TREE('#tmovrfind');
                            $('#txtMovRFInd').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnEMovRFInd').linkbutton({ disabled: true }); } else { $('#btnEMovRFInd').linkbutton({ disabled: true }); }
                        }
                        if (tipopermiso == "RP") {
                            LIMPIAR_NODE_TREE('#trepoind');
                            $('#txtRepInd').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnERepInd').linkbutton({ disabled: true }); } else { $('#btnERepInd').linkbutton({ disabled: true }); }
                        }
                        if (tipopermiso == "TR") {
                            LIMPIAR_NODE_TREE('#tterind');
                            $('#txtTerInd').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnETerInd').linkbutton({ disabled: true }); } else { $('#btnETerInd').linkbutton({ disabled: true }); }
                        }
                        if (tipopermiso == "XLS") {
                            LIMPIAR_NODE_TREE('#tperxls');
                            $('#txtperxls').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnEperxls').linkbutton({ disabled: true }); } else { $('#btnEperxls').linkbutton({ disabled: true }); }
                        }
                        if (tipopermiso == "PE") {
                            LIMPIAR_NODE_TREE('#tperpe');
                            $('#txtperpe').textbox('setValue', '');
                            if (data.d[2] == "0") { $('#btnEperpe').linkbutton({ disabled: true }); } else { $('#btnEperpe').linkbutton({ disabled: true }); }
                        }
                    }
                    else { $.messager.alert('Error', data.d[1], 'error'); }
                },
                error: function (er) {
                    $('#loading').hide();
                    $.messager.alert('Error', er.statusText, 'error');
                },
                complete: function () {
                    $('#loading').hide(100);
                }
            });
        }
        else { $.messager.alert('Error', "Falta seleccionar el permiso a eluminar", 'error'); }
    }
}

/*ELIMINAR PERMISOS DE BOTONES DE LOS CATALOGOS*/
function ELIMINAR_CATALOGOS_INDIVIDUALES(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var valores = getEliminarCatalosos();
        if (valores != undefined) {
            var parametros = {};
            parametros.tipo = "I";
            parametros.idusuario = idusuario;
            parametros.fkpermisoscatalogos = getEliminarCatalogos();
            $.ajax({
                type: "POST",
                url: "../funciones/Fun_AdministracionDeUsuarios.aspx/ELIMINAR_CATALOGOS_INDIVIDUALES",
                data: JSON.stringify(parametros),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {
                    $('#loading').show();
                },
                success: function (data) {
                    if (data.d[0] == "0") {
                        $.messager.alert('Información', data.d[1], 'info');
                        LISTAR_CATALOGOS('#dgcat', idusuario);

                        if (data.d[2] == "0") { $('#btnECat').linkbutton({ disabled: true }); }
                    }
                    else { $.messager.alert('Error', data.d[1], 'error'); }
                },
                error: function (er) {
                    $('#loading').hide();
                    $.messager.alert('Error', er.statusText, 'error');
                },
                complete: function () {
                    $('#loading').hide(100);
                }
            });
        }
    }
}

/*ELIMINAR PERMISOS DE LAS CONSULTAS DE HISTORIA  INDIVIDUALES*/
function ELIMINAR_CONSULTAS_INDIVIDUALES(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var valores = getEliminarConsultas();
        if (valores != undefined) {
            var parametros = {};
            parametros.tipo = "I";
            parametros.idusuario = idusuario;
            parametros.fkpermisosconsultas = getEliminarConsultas();
            $.ajax({
                type: "POST",
                url: "../funciones/Fun_AdministracionDeUsuarios.aspx/ELIMINAR_CONSULTAS_INDIVIDUALES",
                data: JSON.stringify(parametros),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {
                    $('#loading').show();
                },
                success: function (data) {
                    if (data.d[0] == "0") {
                        $.messager.alert('Información', data.d[1], 'info');
                        LISTAR_CONSULTAS('#dgcon', idusuario);

                        if (data.d[2] == "0") { $('#btnECon').linkbutton({ disabled: true }); }
                    }
                    else { $.messager.alert('Error', data.d[1], 'error'); }
                },
                error: function (er) {
                    $('#loading').hide();
                    $.messager.alert('Error', er.statusText, 'error');
                },
                complete: function () {
                    $('#loading').hide(100);
                }
            });
        }
    }
}

/*ELIMINAR LOS PORMISOS DE LOS BOTONES DE LA CREACION DE PLAZAS*/
function ELIMINAR_CREACIONPLA_INDIVIDUALES(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var valores = getEliminarCreacionPla();
        if (valores != undefined) {
            var parametros = {};
            parametros.tipo = "I";
            parametros.idusuario = idusuario;
            parametros.fkpermisoscreacionpla = getEliminarCreacionPla();
            $.ajax({
                type: "POST",
                url: "../funciones/Fun_AdministracionDeUsuarios.aspx/ELIMINAR_CREACIONPLA_INDIVIDUALES",
                data: JSON.stringify(parametros),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {
                    $('#loading').show();
                },
                success: function (data) {
                    if (data.d[0] == "0") {
                        $.messager.alert('Información', data.d[1], 'info');
                        LISTAR_CREACIONPLAZAS('#dgcreacionpla', idusuario);

                        if (data.d[2] == "0") { $('#btnECreacionPLA').linkbutton({ disabled: true }); }
                    }
                    else { $.messager.alert('Error', data.d[1], 'error'); }
                },
                error: function (er) {
                    $('#loading').hide();
                    $.messager.alert('Error', er.statusText, 'error');
                },
                complete: function () {
                    $('#loading').hide(100);
                }
            });
        }
    }
}