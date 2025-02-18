var NomPerfil = "";
var cvePerfil = 0;
var archivo = "";
var JsonArchivo = "";


$(document).ready(function () {
    //var org = $_GET('fkorg');
    //if (org != undefined) { fkorg = org; }
    //else { fkorg = ''; }
    //var cve = $_GET('cve');
    //if (cve != undefined) { cveperfil = cve; }
    //else { cveperfil = ''; }
    //var Perfil = $_GET('perfil');
    //if (Perfil != undefined) { NomPerfil = Perfil; }
    //else { NomPerfil = ''; }
    //var NomArc = $_GET('NomArc');
    //if (NomArc != undefined) { archivo = NomArc; }
    //else { archivo = ''; }

    //$('#lblperfil').text('Perfil: ' + NomPerfil);

    
     ($('#chkE').linkbutton('options').selected) ? archivo = "PREVISIONSOCIAL" : archivo = "PREVSOC",    
     $('#txtnombrearchivo').textbox('setValue', archivo);

   /* $('#btnRegresar').bind('click', function () { IR_PAGINA('Listar_Perfiles.aspx', 'mod=S'); });*/

   
    $('#btnDescargar').bind('click', function () {
        CARGAR_INFORMACION_SALIDA();
      
    });

    $('#chkE').linkbutton({
        text: '<span style="font-size:18px">Ejecutivo</span>'
    });
    $('#chkM').linkbutton({
        text: '<span style="font-size:18px">Magisterio</span>'
    });



    $('#chkE').bind('click', function () {
        archivo = "PREVISIONSOCIAL";
        $('#txtnombrearchivo').textbox('setValue', archivo);
       
    });
    $('#chkM').bind('click', function () {
        archivo = "PREVSOC";
        $('#txtnombrearchivo').textbox('setValue', archivo);      
    });

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

function CARGAR_INFORMACION_SALIDA() {
    var data = {
        Obj: {           
            FkOrganismo: ($('#chkE').linkbutton('options').selected) ? 1 : 2
        }
    }
    $.ajax({
        type: "POST",
        url: "Fun_CargaYDescarga.aspx/SALIDA_ARCHIVO",
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
                //document.getElementById("jsonData").innerHTML = data.d[2];              
                //JsonArchivo = data.d[2];

                var JsonDataObject = eval(data.d[2]);
                exportWorksheet(JsonDataObject);

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

function DESCARGAR_ARCHIVO() { 
   // var JsonData = $("#jsonData").val();
    var JsonDataObject = eval(JsonArchivo);
    exportWorksheet(JsonDataObject);
}

function exportWorksheet(jsonObject) {   
    var myWorkSheet = XLSX.utils.json_to_sheet(jsonObject);
    var myWorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(myWorkBook, myWorkSheet, "myWorkSheet");
    XLSX.writeFile(myWorkBook, archivo+".xlsx");
}


