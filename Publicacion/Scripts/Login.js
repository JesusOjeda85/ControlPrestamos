//var tipo = "M";
$(document).ready(function () {
   
    $.fn.enterKey = function (fnc) {
        return this.each(function () {
            $(this).keypress(function (ev) {
                var keycode = (ev.keyCode ? ev.keyCode : ev.which);
                if (keycode == '13') {
                    fnc.call(this, ev);
                }
            })
        })
    }
    $("#txtusu").focus();
   
    $("#txtusu").keypress(function (event) {
        if (event.which == 13) {           
            $("#txtpas").focus();
        }
    });

    $("#txtpas").keypress(function (event) {
        if (event.which == 13) {
            Entrar();
        }
    });


    $('#btnentrar').bind('click', function () { Entrar(); });

   
});


function Entrar() {
    var parametros = {};
    parametros.strusuario = document.getElementById("txtusu").value;
    parametros.strcontraseña = document.getElementById("txtpas").value;

    $.ajax({
        type: "POST",
        url: 'Login.aspx/Iniciar_Seccion',
        data: JSON.stringify(parametros),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = $.parseJSON(data.d[0]);
            if (obj.Error == "1") {
                $.messager.alert('Error', obj.Mensaje, 'error');
            }
            else {
                IR_PAGINA('Archivos/Menu/menu.aspx', '');
                //window.location = 'file/sistema/menu.aspx';
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            $('#loading').hide();
            $.messager.alert('Information', jqXHR.responseText, 'error');
        },
        complete: function () {
            $('#loading').hide(100);
        }
    });
}

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




