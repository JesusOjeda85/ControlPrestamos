$(document).ready(function () {
    LISTAR_PLAZOS();
});


function LISTAR_PLAZOS() {
    $.ajax({
        type: "POST",
        url: 'Fun_Captura.aspx/LISTAR_PLAZOS',
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);

            $('#cboplazos').combobox({
                data: obj,                
            });
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}