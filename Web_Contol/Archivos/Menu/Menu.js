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

    $('#btnCaptura').bind('click', function () { AgregarTabPadre('#tpcaptura', 'Captura', '../Captura/captura.aspx'); });
    $('#btnConsultas').bind('click', function () { AgregarTabPadre('#tpconsulta', 'Consultas', '../Consulta/Consulta.aspx'); });
    $('#btnReportes').bind('click', function () { AgregarTabPadre('#tpreportes', 'Reportes', '../Reportes/Reportes.aspx'); });
    $('#btnUsuarios').bind('click', function () { AgregarTabPadre('#tpusuarios', 'Usuarios', '../Usuarios/Usuario.aspx'); });


});

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
        var contenido = '<iframe src="' + href + '" frameborder="0" scrolling="no" style="width:100%; height:99.6%;" ></iframe> ';
        $('#tt').tabs('add', {
            title: titulo,
            content: contenido,         
            closable: true,
            bodyCls: 'noscroll'
        });
    }
}
