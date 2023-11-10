var Perfil = "";
var NomRep = "";
var Reporte = "";
$(document).ready(function () {   
    var perfil = $_GET('perfil');
    if (perfil != undefined) { Perfil = perfil; }
    else { Perfil = ''; }
    var nomrep = $_GET('nomrep');
    if (nomrep != undefined) { NomRep = nomrep; }
    else { NomRep = ''; }

    $('#lbl').text('Perfil: ' + Perfil + " / Reporte: " + NomRep);



    $('#btnImprimir').bind('click', function () { Print(); });

    $('#btnRegresar').bind('click', function () { IR_PAGINA('Listar_Perfiles.aspx', ''); });
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