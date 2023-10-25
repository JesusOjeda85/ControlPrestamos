var modulo = "";
$(document).ready(function () {
    var mod = $_GET('mod');
    if (mod != undefined) { modulo = mod; }
    else { modulo = "C"; }

   
});
$(window).load(function () {
    LISTAR_PERFILES();
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


function LISTAR_PERFILES() {
    $.ajax({
        type: "POST",
        url: '../usuarios/Fun_Usuarios.aspx/LISTAR_PERFILES',
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#lstconceptos').tree({
                data: obj,
                onClick: function (node) {
                    if (node.children.length <= 0) {
                        //fkorganismo = node.idPadre;   
                        if (modulo == "C") { IR_PAGINA('CargarArchivos.aspx', 'perfil='+node.nombre+"&nombre=" + node.text); }
                        else { IR_PAGINA('DesCargarArchivos.aspx', 'perfil=' + node.nombre + "&nombre=" + node.text); }
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
