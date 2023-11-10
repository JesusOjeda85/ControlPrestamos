$(document).ready(function () {   
    $('#tt').tabs({
        tabPosition: "top",
        plain: true,
        onBeforeClose: function (title, index) {
            var count = $('#tt .panel').length;
            var target = this;
            if (title == 'Inicio') {
                $.messager.confirm('Confirmación', 'Seguro de salir del sistema?', function (r) {
                    if (r) {

                        var opts = $(target).tabs('options');
                        var bc = opts.onBeforeClose;
                        opts.onBeforeClose = function () { };
                        $(target).tabs('close', index);
                        opts.onBeforeClose = bc;
                        if (count == 1) { $('#tt').hide(); }

                    }
                });
                return false;
            }          
            if (count == 1) { $('#tt').hide(); }
        }
    })

    $('#btnInicio').bind('click', function () { Cerrar(); });

    $('#btnCaptura').bind('click', function () { AgregarTabPadre('#tpcaptura', 'Captura', '../Captura/Listar_Perfiles.aspx'); });
    $('#btnAplicacion').bind('click', function () { AgregarTabPadre('#tpaplicacion', 'Aplicar Descuentos', '../AplicarDescuentos/Listar_Perfiles.aspx'); });
    $('#btnNumeracion').bind('click', function () { AgregarTabPadre('#tpnumeracion', 'Numeración Cheques', '../Numeracion/Listar_Perfiles.aspx'); });
    $('#btnReportes').bind('click', function () { AgregarTabPadre('#tpreportes', 'Reportes', '../Reportes/Listar_Perfiles.aspx'); });
    $('#btnUsuarios').bind('click', function () { AgregarTabPadre('#tpusuarios', 'Usuarios', '../Usuarios/Usuarios.aspx'); });
    $('#btnImportacion').bind('click', function () { AgregarTabPadre('#tpcargar', 'Cargar Archivos', '../CargarYDescargar/Listar_Perfiles.aspx?mod=C'); });
    $('#btnExportacion').bind('click', function () { AgregarTabPadre('#tpsalida', 'Salida De Archivos', '../CargarYDescargar/Listar_Perfiles.aspx?mod=S'); });

    $('#dmLiquidez').bind('click', function () { AgregarTabPadre('#tpsalida', 'Liquidez', '../CargarPadrones/Listar_Perfiles.aspx?mod=L'); });
    $('#dmFondoA').bind('click', function () { AgregarTabPadre('#tpsalida', 'Fondo de Ahorrro', '../CargarPadrones/Listar_Perfiles.aspx?mod=F'); });

    //$('#dmpagare').bind('click', function () { AgregarTabPadre('#tpsalida', 'Pagaré', '../Reportes/Pagare.aspx'); });
    

});
$(window).load(function () {
    CARGAR_PERMISOS();
});
function CARGAR_PERMISOS() {
    $.ajax({
        type: "POST",
        url: 'Fun_Menus.aspx/CARGAR_PERMISOS',
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);   
            //var tblperfiles = jQuery.parseJSON(obj[0]);  
            var tblpermisosmenu = jQuery.parseJSON(obj[1]);
            var tblmenu = jQuery.parseJSON(obj[2]);

            if (data.d[4] == "False") {
                for (var m = 0; m < tblmenu.length; m++) {
                    $('#' + tblmenu[m].Nombre).hide();
                }

                if (tblpermisosmenu.length > 0) {
                    for (var p = 0; p < tblpermisosmenu.length; p++) {
                        for (var m = 0; m < tblmenu.length; m++) {
                            if (tblmenu[m].Id == tblpermisosmenu[p].fkMenu) { $('#' + tblpermisosmenu[p].Nombre).show(); break; }
                        }
                    }
                }
            }
            document.getElementById('lblusuario').innerHTML = data.d[3];
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}

function Cerrar() {
    $.messager.confirm('Confirmación', 'Seguro de salir del sistema', function (r) {
        if (r) {           
            window.location.href = '../../Login.aspx';
        }
    });
    return false;
}

function AgregarTabPadre(objtap, titulo, href) {    
    $('#tt').show();
    $("#tt").tabs({
        heightStyle: "fill",
        onSelect: function (title) {
           
        }
    });

    if ($('#tt').tabs('exists', titulo)) {
        $('#tt').tabs('select', titulo);
    }
    else {
        var contenido = '<iframe src="' + href + '" frameborder="0" scrolling="no"  style="width:100%; height:99.6%;" ></iframe> ';
        $('#tt').tabs('add', {
            title: titulo,
            content: contenido,         
            closable: true,
            bodyCls: 'noscroll'
        });
    }
}
