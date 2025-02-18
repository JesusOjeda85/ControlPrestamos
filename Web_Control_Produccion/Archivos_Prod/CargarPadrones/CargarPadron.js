var NomPerfil = "";
var cvePerfil = 0;
$(document).ready(function () {
    var org = $_GET('fkorg');
    if (org != undefined) { fkorg = org; }
    else { fkorg = ''; }
    var cve = $_GET('cve');
    if (cve != undefined) { cveperfil = cve; }
    else { cveperfil = ''; }
    var Perfil = $_GET('perfil');
    if (Perfil != undefined) { NomPerfil = Perfil; }
    else { NomPerfil = ''; }

    $('#lblperfil').text('Perfil: ' + NomPerfil);

    $('#btnRegresar').bind('click', function () { IR_PAGINA('Listar_Perfiles.aspx', 'mod=P'); });

    $('#xls').filebox({
        buttonText: 'Examinar',
        prompt: 'Selecciona Archivo',
        accept: '*.xlsx,*.xls',
        multiple: false,
        onChange: function (newValue, oldValue) {
            var files = $(this).next().find('input[type=file]')[0].files;
            if (files && files[0]) {
                var reader = new FileReader();
                reader.onload = function (evt) {
                    var data = evt.target.result;

                    var NombreArchivo = files[0].name;
                    //var ss = NombreArchivo.split('.');
                    //var ext = ss.pop();
                    //var quincena = ss[0].slice(ss[0].length - 7)

                    //$('#lblquincena').text('Quincena a Cargar: ' + quincena);

                    var workbook = XLSX.read(data, {
                        type: "binary"
                    });
                    workbook.SheetNames.forEach(sheet => {
                        let rowObject = XLSX.utils.sheet_to_row_object_array(
                            workbook.Sheets[sheet]
                        );
                        if (rowObject.length > 0) {
                            var jsonObject = JSON.stringify(rowObject);
                            sessionStorage.setItem('JsonData', jsonObject);
                        }
                    });
                }
                //reader.readAsDataURL(files[0]);
                reader.readAsBinaryString(files[0]);
            }
        }
    });

    $('#btnGuardar').bind('click', function () { GUARDAR_ARCHIVO('#btnGuardar'); });

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


function GUARDAR_ARCHIVO(btnobj) {
    if ($(btnobj).linkbutton('options').disabled) { return false; }
    else {
        var file = $('#xls').next().find('.textbox-value')[0];
        var nombre = $('#xls').next().find('input[type=file]')[0].files;
        if (file == null) { $.messager.alert('Error', 'Falta Seleccionar el Archivo', 'error'); return; }
        else {
            var fileName = file.value;
            var NombreArchivo = nombre[0].name;
           
            var data = {
                Obj: {
                    CvePerfil: cveperfil,
                    FkOrganismo: fkorg,
                    Nombre: NombreArchivo,                  
                    Archivo: sessionStorage.getItem('JsonData'),
                }
            }
            $.ajax({
                type: "POST",
                url: "Fun_CargarPadrones.aspx/GUARDAR_PADRON",
                data: JSON.stringify(data),
                async: true,
                cache: false,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {
                    $('#loading').show();
                },
                success: function (data) {
                    if (data.d[0] == "0") {
                        $.messager.alert('Información', data.d[2] + ' ' + data.d[1], 'info');
                    }
                    else { $.messager.alert('Error', data.d[1], 'error'); }
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
    }
}

