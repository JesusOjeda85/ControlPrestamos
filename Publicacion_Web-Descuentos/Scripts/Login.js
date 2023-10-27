
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

function Entrar() {
    var data = {
        obj: {
            Usuario: document.getElementById("txtusu").value,
            Contraseña: document.getElementById("txtpas").value,
        }
    }
    
    $.ajax({
        type: "POST",
        url: 'Login.aspx/Iniciar_Sesion',
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {            
            if (data.d[0] == "1") {
                $.messager.alert('Error', data.d[1], 'error');
            }
            else {
                IR_PAGINA('Archivos/Menu/Menu.aspx', '');               
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




