var objm = "";
var quin = "";
$(document).ready(function () {      
    $('#tt').hide();

    CARGAR_MENU('#menu');

    $('#slideusuario').slideReveal({
        position: "right",
        overlay: true,
        autoEscape: true,
        push: false,
        width: 430,
        speed: 700
    });

    $('#tt').tabs({
        tabPosition: "top",
        plain: true,
        onBeforeClose: function (title, index) {
            var target = this;
            $.messager.confirm('Confirm', 'Seguro de cerrar el módulo ' + title, function (r) {
                if (r) {

                    var count = $('#tt .panel').length;
                    var opts = $(target).tabs('options');
                    var bc = opts.onBeforeClose;
                    opts.onBeforeClose = function () { };
                    $(target).tabs('close', index);
                    opts.onBeforeClose = bc;
                    if (count == 1) {
                        $('#tt').hide();
                        $('#imglogo').show();
                    }

                }
            });

            SACAR_DATOS_QUINCENA();

            return false;
        }
    });

    $('#btnUsuario').bind('click', function () {
        $('#slideusuario').show();
        $('#slideusuario').slideReveal("toggle");
    });

    $('#btnCerrar').bind('click', function () {
        Cerrar();
    });

    $('#btnCambiarPass').bind('click', function () { windows("#wcontraseña", 400, 170, false, 'Modificar Contraseña'); });
    $('#btnCancelarCambioPass').bind('click', function () { $('#wcontraseña').window('close'); });
    $('#btnGuardarCambioPass').bind('click', function () { CAMBIA_PASS(); });
   
});

function CARGAR_MENU(mcontrol) {
    $.ajax({
        type: "POST",
        url: '../funciones/AdministracionDeUsuarios.aspx/MOSTRAR_MENU',
        datatype: 'json',
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            if (data.d[0] != "0") {
                var obj = $.parseJSON(data.d[0]);

                //si el usuario logueado tiene rol de filtro por secretaria, se abre la consuslta de empleados
                if (data.d[1] == "Si") {
                    permisofiltro = data.d[1];
                }
                else { permisofiltro = "No"; }
                menu($(mcontrol), obj);
            }
            else { $.messager.alert('Error', 'No Existe la Configuración del menu', 'error'); }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            $('#loading').hide();
            $.messager.alert('Error', jqXHR, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}

function menu(ul, obj) {
    var nombrerpt = "";
    for (var i = 0; i < obj.length; i++) {
        var nombre = obj[i].Nombre;
        var objlst = obj[i].List;
        var imagen = obj[i].UrlImagen;
       
        var li = $('<li class="nav-list__item"/>')
            .appendTo(ul);

        var a = $('<a class="nav-list__link nav-list__link--primary"/>')
            .text(nombre)
            .attr('href', "javascript:void(0);")
            .appendTo(li);
        var img = $('<img id="imgmenu" class="nav-list__icon" src="../..' + imagen + '" alt=""/>')
            .appendTo(a);

        if (objlst!= null) {
            var sub_ul = $('<ul class="nav-list__sub"/>')
                .appendTo(li);
            submenu(sub_ul, objlst);
        }
    }
}

function submenu(ul, objlst) {
    var nombrerpt = "";
    for (var i = 0; i < objlst.length; i++) {
        var nombre = objlst[i].Nombre;
        var lstsub = objlst[i].List;
        var url = objlst[i].Url;

        var nomtab = objlst[i].NombreTab;
        if (objlst[i].nombrerpt != undefined) { nombrerpt = objlst[i].nombrerpt; }
        else { nombrerpt = ""; }

        if (lstsub.length > 0) {
            var li = $('<li class="nav-list__item"/>')
                .appendTo(ul);
            var a = $('<a class="nav-list__link"/>')
                .text(nombre)
                .attr('href', "javascript:void(0);")
                .appendTo(li);

            var sub_ul = $('<ul class="nav-list__sub"/>')
                .appendTo(li);
            submenu(sub_ul, lstsub);
        }
        else {
            var li = $('<li class="nav-list__item"/>')
                .appendTo(ul);
            var a = $('<a class="nav-list__link" data-menu="' + url + nombrerpt + '"/>')
                .text(nombre)
                .attr('href', ".." + url + nombrerpt)
                .attr('name', nomtab)
                .appendTo(li);

            if ((permisofiltro == "Si") && (nomtab == 'Consulta de Empleados')) {
                AgregarTabPadre('Consulta', nombre, ".." + url);
            }
        }
        ///mov_personal/menucaptura.aspx?tipo='MP',&titulo='MOVIMIENTOS PERSONALES'
    }
}

function CAMBIA_PASS() {
    if ($('#txtPassAnt').textbox('getValue') == "") { $.messager.alert('Error', "Ingrese contraseña actual", 'error'); }
    else
        if ($('#txtPassNuevo').textbox('getValue') == "" || $('#txtPassNuevo_Rep').textbox('getValue') == "") { $.messager.alert('Error', "Ingrese contraseña nueva", 'error'); }
        else
            if ($('#txtPassNuevo').textbox('getValue') != $('#txtPassNuevo_Rep').textbox('getValue')) { $.messager.alert('Error', "Contraseña nueva no coincide en ambos campos", 'error'); }
            else
            {
                var parametros = {};               
                parametros.pass = $('#txtPassAnt').textbox('getValue');
                parametros.passNuevo = $('#txtPassNuevo').textbox('getValue');
                $.ajax({
                    type: "POST",
                    url: "../FUNCIONES/AdministracionDeUsuarios.aspx/CAMBIAR_PASS",
                    data: JSON.stringify(parametros),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    beforeSend: function () {
                        $('#loading').show();
                    },
                    success: function (data) {
                        var obj = $.parseJSON(data.d[0]);
                        if (obj.Error == "0") {
                            $.messager.alert('Información', obj.Mensaje, 'info');
                            LIMPIAR_CAMBIOPASS();
                            $('#wcontraseña').window('close');
                        }
                        else { $.messager.alert('Error', obj.Mensaje, 'error'); }
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

function LIMPIAR_CAMBIOPASS() {
    $('#txtPassAnt').textbox('setValue', '');
    $('#txtPassNuevo_Rep').textbox('setValue', '');
    $('#txtPassNuevo').textbox('setValue', '');
}

function Cerrar() {
    $.messager.confirm('Confirmación', 'Seguro de salir del sistema', function (r) {
        if (r) {                                 
            window.location.href = '../../Login.aspx';
        }
    });
    return false;    
}





