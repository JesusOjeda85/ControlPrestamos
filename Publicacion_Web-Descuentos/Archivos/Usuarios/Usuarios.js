var idusuario = 0;
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
    DESHABILITAR();
    LISTAR_USUARIOS();

    var text = $('#txtfiltrar');
    text.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            var valor = text.val();
            if (valor != "") {
                $('#lstusuario').tree('doFilter', valor);
                $('#lstusuario').tree('expandAll');
            }
            else {
                $('#lstusuario').tree('doFilter', '');
            }
        }
    });

    $('#lstusuario').tree({
        onClick: function (node) {
            if (node.IdPadre != 0) {
                idusuario = node.id;
                HABILITAR();                
                SACAR_DATOS_USUARIOS(node.id);
            }
            else {
                LIMPIAR('#btnLimpiar');
                DESHABILITAR();
            }
        }
    });

    $('#btnNuevo').bind('click', function () { NUEVO('#btnNuevo'); });
    $('#btnLimpiar').bind('click', function () { LIMPIAR('#btnLimpiar'); });
    $('#btnGuardar').bind('click', function () { GUARDAR('#btnGuardar'); });

    $('#btnPermisos').bind('click', function () { CARGAR_PERMISOS('#btnPermisos'); });
    $('#btnGpermisos').bind('click', function () { GUARDAR_PERMISOS('#btnGpermisos'); });

    FILTRAR_TREE_TXT('#txtfilperfil', '#lstperfil');
    FILTRAR_TREE_TXT('#txtfilmenu', '#lstmenus');
});

function DESHABILITAR() {
    $('#txtusuario').textbox({ readonly: true });
    $('#txtcontraseña').textbox({ readonly: true });
    $('#txtnombres').textbox({ readonly: true });
    $('#txtappaterno').textbox({ readonly: true });
    $('#txtapmaterno').textbox({ readonly: true });

    $('#chkadmin').checkbox({ readonly: true });
    $('#chkestatus').checkbox({ readonly: true });

    $('#btnPermisos').linkbutton('disable');

    $('#btnGuardar').linkbutton('disable');
    $('#btnLimpiar').linkbutton('disable');
}
function HABILITAR() {
    $('#txtusuario').textbox({ readonly: false });
    $('#txtcontraseña').textbox({ readonly: false });
    $('#txtnombres').textbox({ readonly: false });
    $('#txtappaterno').textbox({ readonly: false });
    $('#txtapmaterno').textbox({ readonly: false });

    $('#chkadmin').checkbox({ readonly: false });
    $('#chkestatus').checkbox({ readonly: false });

    $('#btnPermisos').linkbutton('enable');

    $('#btnLimpiar').linkbutton('enable');
    $('#btnGuardar').linkbutton('enable');
}

function NUEVO(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        HABILITAR();        
        $('#btnPermisos').linkbutton({ disabled: false });
        $('#txtusuario').textbox('clear').textbox('textbox').focus();
        $('#chkestatus').checkbox({ checked: true });
    }
}
function LIMPIAR(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {

        $('#txtfiltrar').textbox('setValue', '');
        $('#txtusuario').textbox('setValue', '');
        $('#txtcontraseña').textbox('setValue', '');
        $('#txtnombres').textbox('setValue', '');
        $('#txtappaterno').textbox('setValue', '');
        $('#txtapmaterno').textbox('setValue', '');
      
        $('#chkadmin').checkbox({ checked: false });
        $('#chkestatus').checkbox({ checked: false });
      
        $('#btnPermisos').linkbutton('disable');
        
        DESHABILITAR();

        LIMPIAR_NODE_TREE('#lstusuario');

        idusuario = "";
    }
}


/*LISTAR LOS USUARIOS*/
function LISTAR_USUARIOS() {

    $.ajax({
        type: "POST",
        url: 'Fun_Usuarios.aspx/LISTAR_USUARIOS',
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);
            $('#lstusuario').tree({
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
function SACAR_DATOS_USUARIOS(fkusuario) {
    var data = {
        objusuario: {
            Idusuario: fkusuario,
        }
    }
    $.ajax({
        type: "POST",
        url: 'Fun_Usuarios.aspx/LISTAR_DATOS_USUARIO',
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);
            $('#txtusuario').textbox('setValue', obj[0].Usuario);
            $('#txtcontraseña').textbox('setValue', obj[0].Contraseña);
            $('#txtnombres').textbox('setValue', obj[0].Nombres);          
            $('#txtappaterno').textbox('setValue', obj[0].ApPaterno);
            $('#txtapmaterno').textbox('setValue', obj[0].ApMaterno);           
            if (obj[0].Administrador == 1) {              
                $('#chkadmin').checkbox({ checked: true });
            }
            else {                
                $('#chkadmin').checkbox({ checked: false });
            }
            if (obj[0].Estatus == 1) {              
                $('#chkestatus').checkbox({ checked: true });
            }
            else {              
                $('#chkestatus').checkbox({ checked: false });
            }
          
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}

/*GUARDAR DATOS DEL USUARIO */
function GUARDAR(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        if ($('#txtusuario').textbox('getValue') == "") { $.messager.alert('Error', "Falta el usuario", 'error'); }
        else
            if ($('#txtcontraseña').textbox('getValue') == "") { $.messager.alert('Error', "Falta la contraseña", 'error'); }
            else {
                if (idusuario == "") { idusuario = 0; }

                var estatus = $('#chkestatus').checkbox('options');
                var admin = $('#chkadmin').checkbox('options');
                var data = {
                    objusuario: {
                        Idusuario: idusuario,
                        Usuario: $('#txtusuario').textbox('getValue'),
                        Contraseña: $('#txtcontraseña').textbox('getValue'),
                        APPaterno: $('#txtappaterno').textbox('getValue'),
                        APMaterno: $('#txtapmaterno').textbox('getValue'),
                        Nombres: $('#txtnombres').textbox('getValue'),                                               
                        Administrador: admin.checked,
                        Estatus: estatus.checked
                    }
                }

                $.ajax({
                    type: "POST",
                    url: "Fun_Usuarios.aspx/GUARDAR_USUARIO",
                    data: JSON.stringify(data),
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
                        $.messager.alert('Error', er.responseJSON.Message, 'error');
                    },
                    complete: function () {
                        $('#loading').hide(100);
                    }
                });
            }
    }
}


function LISTAR_PERFILES() {
    $.ajax({
        type: "POST",
        url: 'Fun_Usuarios.aspx/LISTAR_PERFILES',
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {            
            var obj = jQuery.parseJSON(data.d[2]);
           
            $('#lstperfil').tree({
                data: obj,
                checkbox: function (node) {
                    if (node.checkbox == true) {
                        return true;
                    }
                }
            });
            CARGAR_PERMISOS_ASIGNADOS('#lstperfil', 'C');
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}
function LISTAR_MENUS() {
    $.ajax({
        type: "POST",
        url: 'Fun_Usuarios.aspx/LISTAR_MENUS',
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);
            $('#lstmenus').tree({
                data: obj
            });
            CARGAR_PERMISOS_ASIGNADOS('#lstmenus', 'M');
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}

/*CARGAR PERMISOS*/
function CARGAR_PERMISOS_ASIGNADOS(objtree,modulo) {
    var data = {
        objusuario: {
            Idusuario: idusuario,
        }
    }
    $.ajax({
        type: "POST",
        url: 'Fun_Usuarios.aspx/CARGAR_PERMISOS',
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
                      
            var tri = $(objtree).tree('getRoots');           
            if (modulo == 'C') {
                var tblconceptos = jQuery.parseJSON(obj[0]);
                if (tblconceptos.length > 0) {
                    for (var h = 0; h < tri.length; h++) {
                        var tree = $(objtree).tree('getChildren', tri[h].target);
                        for (var i = 0; i < tree.length; i++) {
                            for (var j = 0; j < tblconceptos.length; j++) {
                                if (tblconceptos[j].fkConcepto == tree[i].nombre) {
                                    $(objtree).tree('check', tree[i].target)                                    
                                }
                            }
                        }
                    }
                }
            }
            if (modulo == 'M') {
                var tblmenus = jQuery.parseJSON(obj[1]);
                if (tblmenus.length > 0) {
                    for (var h = 0; h < tri.length; h++) {
                        for (var j = 0; j < tblmenus.length; j++) {
                            if (tblmenus[j].fkMenu == tri[h].id) {
                                $(objtree).tree('check', tri[h].target)
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


function CARGAR_PERMISOS(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {

        LISTAR_PERFILES();      
        LISTAR_MENUS();
               
        $('#loading').hide(100);
        //windows_porcentaje("#win", 90, 60, false, false, false, "Permisos");  
        windows("#win","90%","550px",false,"Permisos");
    }
}

function getchkConceptos(objtre) {
    var nodes = $(objtre).tree('getChecked', ['checked', 'indeterminate']);
    var ss = [];
    for (var i = 0; i < nodes.length; i++) {
        ss.push(nodes[i].idPadre + "," + nodes[i].nombre);
    }
    return ss.join('|');
}

function getchkMenus(objtre) {
    var nodes = $(objtre).tree('getChecked', ['checked', 'indeterminate']);
    var ss = [];
    for (var i = 0; i < nodes.length; i++) {
        ss.push(nodes[i].id);
    }
    return ss.join('|');
}

/*GUARDAR PERMISOS*/
function GUARDAR_PERMISOS(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var data = {
            objpermisos: {
                Idusuario: idusuario,
                fkconceptos: getchkConceptos('#lstperfil'),
                fkmenus: getchkMenus('#lstmenus'),              
            }
        }
        $.ajax({
            type: "POST",
            url: "Fun_Usuarios.aspx/GUARDAR_PERMISOS",
            data: JSON.stringify(data),
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
                $.messager.alert('Error', er.statusText, 'error');
            },
            complete: function () {
                $('#loading').hide(100);
            }
        });
    }
}

