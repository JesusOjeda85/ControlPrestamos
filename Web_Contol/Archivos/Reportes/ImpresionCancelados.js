var tipopuesto = "";
$(document).ready(function () {        
    CARGAR_TIPOS('#cbotipopuesto');

    $("#cbotipopuesto").combobox({
        onSelect: function (rec) {           
            tipopuesto = rec.Clave;
            if (rec.Clave != "X") {
                IMPRESION_PROCESOS('ListadoCancelaciones', 'Listar_Cancelaciones@dtCancelados');
            }
        },
    });
    $('#btnLimpiar').bind('click', function () {
        $('#rwvista').empty();
        $("#cbotipopuesto").combobox('setValue','X');
    });
});


function CARGAR_TIPOS(cbobjeto) {
    var columna;
    var Campos = [];
    var obj;
    
    obj = {};    
    obj["Clave"] = "X";
    obj["Descripcion"] = "Seleccione una opción";
    obj["selected"] = true; 
    Campos.push(obj);

    obj = {};    
    obj["Clave"] = "P";
    obj["Descripcion"] = "Prestamos";    
    Campos.push(obj);

    obj = {};
    obj["Clave"] = "S";
    obj["Descripcion"] = "Retiros";
    Campos.push(obj);

    obj = {};
    obj["Clave"] = "S";
    obj["Descripcion"] = "Siniestros";
    Campos.push(obj);
    
    $(cbobjeto).combobox({
        data: Campos,
        valueField: "Clave",
        textField: "Descripcion",
        editable: false
    });
}

function IMPRESION_PROCESOS(reporte, proceso) {

    var parametros = {};
    parametros.FkOrganismo = '';
    parametros.Filtros = "";
    parametros.Reporte = reporte;
    parametros.Proceso = proceso;
    parametros.Modulo = tipopuesto;
    parametros.ChequesNulos = 0;
    parametros.ImpresionCH = 0;

    $.ajax({
        type: "POST",
        url: '../ArchivosRdlc/Fun_Archivos.aspx/Generar_Archivos',
        data: JSON.stringify(parametros),
        async: true,
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            if (data.d[0] == "1") { $.messager.alert('Error', data.d[1], 'error'); }
            else {
                $('#rwvista').empty().html('<embed id="evista" width="100%" height="100%" src="' + "../ArchivosRdlc/" + data.d[2] + '"></embed>')
            }
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