var Modulo = "";
var Carpeta = "";
var Pagina = "";
var Reporte = "";
$(document).ready(function () {
    $('#loading').show();

    var NomRep = $_GET('NomRep');
    if (NomRep != undefined) { Reporte = NomRep; }
    else { Reporte = ''; }

   
    $('#btnRegresar').bind('click', function () {
        $('#rwvista').empty().html('<embed id="evista" width="100%" height="100%" src=""></embed>');
        IR_PAGINA("Impresion_Devolucion.aspx", "");
    });


    $('#rwvista').empty().html('<embed id="evista" width="100%" height="100%" src=""></embed>');
    $('#rwvista').empty().html('<embed id="evista" width="100%" height="100%" src="' + "../ArchivosRdlc/" + Reporte + '"></embed>');
    $('#loading').hide();
});
$(window).load(function () {



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
