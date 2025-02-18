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
   
    const dmCapturaPrestamos = document.getElementById("dmCapturaPrestamos");
    dmCapturaPrestamos.addEventListener("click", function () {
        AgregarTabPadre('Captura de Prestamos', '../Captura/Prestamos/Captura_Prestamos.aspx'); 
    });

    const dmAutorizacion = document.getElementById("dmAutorizacion");
    dmAutorizacion.addEventListener("click", function () {
        AgregarTabPadre('Autorización de Créditos', '../AplicarDescuentos/Autorizacion.aspx');
    });

    const dmCapturaDevoluciones = document.getElementById("dmCapturaDevoluciones");
    dmCapturaDevoluciones.addEventListener("click", function () {
        AgregarTabPadre('Captura de Reembolsos', '../Devoluciones/Captura_Devolucion.aspx');
    });

    const dmImpDevoluciones = document.getElementById("dmImpDevoluciones");
    dmImpDevoluciones.addEventListener("click", function () {
        AgregarTabPadre('Impresión de Reembolsos', '../Devoluciones/Impresion_Devolucion.aspx');
    });

    const dmRemDevoluciones = document.getElementById("dmRemDevoluciones");
    dmRemDevoluciones.addEventListener("click", function () {
        AgregarTabPadre('Modificación de Reembolsos', '../Devoluciones/Modificacion_Devolucion.aspx');
    });

    const dmCancelacionP = document.getElementById("dmCancelacionP");
    dmCancelacionP.addEventListener("click", function () {
        AgregarTabPadre('Cancelaciones Prestamos', '../Cancelaciones/Prestamos/Cancelaciones_P.aspx');
    });

    const dmPagosExternos = document.getElementById("dmPagosExternos");
    dmPagosExternos.addEventListener("click", function () {
        AgregarTabPadre('Abono a Deuda', '../PagosExternos/PagosExternos.aspx');
    });

    const dmNumeracionPrestamos = document.getElementById("dmNumeracionPrestamos");
    dmNumeracionPrestamos.addEventListener("click", function () {
        AgregarTabPadre('Numeración De Prestamos', '../Numeracion/Prestamos/Numeracion_P.aspx');
    });

    const dmImpresionEmisionPrestamos = document.getElementById("dmImpresionEmisionPrestamos");
    dmImpresionEmisionPrestamos.addEventListener("click", function () {
        AgregarTabPadre('Impresión de Prestamos', '../Numeracion/Prestamos/Impresion_Emision_P.aspx');
    });

    const dmRenumeracionPrestamos = document.getElementById("dmRenumeracionPrestamos");
    dmRenumeracionPrestamos.addEventListener("click", function () {
        AgregarTabPadre('Renumeración de Prestamos', '../Numeracion/Prestamos/Renumeracion_Cheques_P.aspx');
    });

    const MImportacion = document.getElementById("MImportacion");
    MImportacion.addEventListener("click", function () {
        AgregarTabPadre('Actualización de Saldos', '../CargarYDescargar/CargarArchivos.aspx');
    });

    const MExportacion = document.getElementById("MExportacion");
    MExportacion.addEventListener("click", function () {
        AgregarTabPadre('Préstamos a Aplicar', '../CargarYDescargar/SalidaArchivos.aspx');
    });

    const dmLiquidez = document.getElementById("dmLiquidez");
    dmLiquidez.addEventListener("click", function () {
        AgregarTabPadre('Liquidez', '../CargarPadrones/CargarLiquidez.aspx');
    });

    const dmPadronEmp = document.getElementById("dmPadronEmp");
    dmPadronEmp.addEventListener("click", function () {
        AgregarTabPadre('Padron de Empleados', '../CargarPadrones/CargarPadron.aspx');
    });



    const dmCapturaRetiros = document.getElementById("dmCapturaRetiros");
    dmCapturaRetiros.addEventListener("click", function () {
        AgregarTabPadre('Captura de Retiros', '../Captura/Retiros/Captura_Retiros.aspx');
    });

    const dmRevisionRetiros = document.getElementById("dmRevisionRetiros");
    dmRevisionRetiros.addEventListener("click", function () {
        AgregarTabPadre('Revisión de Captura Retiros', '../Captura/Retiros/Impresion_Revision_R.aspx');
    });

    const dmCancelacionR = document.getElementById("dmCancelacionR");
    dmCancelacionR.addEventListener("click", function () {
        AgregarTabPadre('Cancelaciones Retiros', '../Cancelaciones/Retiros/Cancelaciones_R.aspx');
    });

    const dmNumeracionRetiros = document.getElementById("dmNumeracionRetiros");
    dmNumeracionRetiros.addEventListener("click", function () {
        AgregarTabPadre('Captura De Retiros', '../Numeracion/Retiros/Numeracion_R.aspx');
    });

    const dmImpresionEmisionRetiros = document.getElementById("dmImpresionEmisionRetiros");
    dmImpresionEmisionRetiros.addEventListener("click", function () {
        AgregarTabPadre('Impresión de Retiros', '../Numeracion/Retiros/Impresion_Emision_R.aspx');
    });

    const dmRenumeracionRetiros = document.getElementById("dmRenumeracionRetiros");
    dmRenumeracionRetiros.addEventListener("click", function () {
        AgregarTabPadre('Renumeración de Retiros', '../Numeracion/Retiros/Renumeracion_Cheques_R.aspx');
    });



    const dmCapturaSiniestros = document.getElementById("dmCapturaSiniestros");
    dmCapturaSiniestros.addEventListener("click", function () {
        AgregarTabPadre('Captura de Siniestros', '../Captura/Siniestros/Captura_Siniestros.aspx');
    });

    const dmRevisionSiniestros = document.getElementById("dmRevisionSiniestros");
    dmRevisionSiniestros.addEventListener("click", function () {
        AgregarTabPadre('Revisión de Captura Siniestros', '../Captura/Siniestros/Impresion_Revision_S.aspx');
    });


    const dmCancelacionS = document.getElementById("dmCancelacionS");
    dmCancelacionS.addEventListener("click", function () {
        AgregarTabPadre('Cancelaciones Siniestros', '../Cancelaciones/Siniestros/Cancelaciones_S.aspx');
    });

    const dmNumeracionSiniestros = document.getElementById("dmNumeracionSiniestros");
    dmNumeracionSiniestros.addEventListener("click", function () {
        AgregarTabPadre('Numeración De Siniestros', '../Numeracion/Siniestros/Numeracion_S.aspx');
    });

    const dmImpresionEmisionSiniestros = document.getElementById("dmImpresionEmisionSiniestros");
    dmImpresionEmisionSiniestros.addEventListener("click", function () {
        AgregarTabPadre('Impresión de Siniestros', '../Numeracion/Siniestros/Impresion_Emision_S.aspx');
    });

    const dmRenumeracionSiniestros = document.getElementById("dmRenumeracionSiniestros");
    dmRenumeracionSiniestros.addEventListener("click", function () {
        AgregarTabPadre('Renumeración de Siniestros', '../Numeracion/Siniestros/Renumeracion_Cheques_S.aspx');
    });



    const MConsulta = document.getElementById("MConsulta");
    MConsulta.addEventListener("click", function () {
        AgregarTabPadre('Consulta', '../Consulta/Consulta.aspx');
    });


    const dmSaldos = document.getElementById("dmSaldos");
    dmSaldos.addEventListener("click", function () {
        AgregarTabPadre('Reporte de Saldos', '../Reportes/Visor_Reportes.aspx?nomrep=Saldos');
    });


    const dmCancelados = document.getElementById("dmCancelados");
    dmCancelados.addEventListener("click", function () {
        AgregarTabPadre('Reporte de Cancelados', '../Reportes/ImpresionCancelados.aspx');
    });

    const dmUsuarios = document.getElementById("dmUsuarios");
    dmUsuarios.addEventListener("click", function () {
        AgregarTabPadre('Usuarios', '../Usuarios/Usuarios.aspx');
    });

    const btnCerrar = document.getElementById("btnCerrar");
    btnCerrar.addEventListener("click", function () {
        Cerrar();
    }); 

   



   
});
$(window).load(function () {
   CARGAR_PERMISOS();     
  // CARGAR_MENUS();
});

function AgregarTabPadre(titulo, href) {
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
        var contenido = '<iframe src="' + href + '" frameborder="0" scrolling="no"  style="width:100%; height:99.6%;" ></iframe> ';
        $('#tt').tabs('add', {
            title: titulo,
            content: contenido,
            closable: true,
            bodyCls: 'noscroll'
        });
    }
}

function Cerrar() {
    $.messager.confirm('Confirmación', 'Seguro de salir del sistema', function (r) {
        if (r) {
            window.location.href = '../../Login.aspx';
        }
    });
    return false;
}

function CARGAR_PERMISOS() {
    $.ajax({
        type: "POST",
        url: 'Fun_Menus.aspx/CARGAR_PERMISOS',
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);      
            //permisos de menus
            var tblpermisosmenu = jQuery.parseJSON(obj[1]);
            

            var myList = $("#sidebar ul").children('li');

            if (data.d[0] == 0) {
                if (tblpermisosmenu!=null) {                   
                    for (var m = 0; m < myList.length; m++) {
                        //ocultar elemento por el indice de la lista                     
                        $('#sidebar ul li:eq(' + m + ')').siblings().css({ 'display': 'none' });
                    }
                    if (tblpermisosmenu.length > 0) {                        
                        for (var m = 0; m < myList.length; m++) {                            
                            //if (myList[m].id == 'dmLiquidez') {
                            //    var stop = "";
                            //}
                            var MenuEncontrado = jQuery.grep(tblpermisosmenu, function (Menus, i) {
                                return myList[m].id == Menus.Nombre;
                            });    
                            if (MenuEncontrado.length > 0) { 
                                $('#' + myList[m].id).css({ 'display': 'block' });
                                //if (myList[m].id == 'dmLiquidez') {
                                //    $('#auth').css({ 'display': 'block' });                                    
                                //}
                                //if (myList[m].id == 'dmPadronEmp') {
                                //    $('#auth').css({ 'display': 'block' });
                                //}
                                //if (myList[m].id == 'dmUsuarios') {
                                //    $('#config').css({ 'display': 'block' });
                                //}
                                //if (myList[m].id == 'dmNumeracion') {
                                //    $('#Prod').css({ 'display': 'block' });
                                //}
                                //if (myList[m].id == 'dmImpresion') {
                                //    $('#Prod').css({ 'display': 'block' });
                                //}
                                //if (myList[m].id == 'dmReposicion') {
                                //    $('#rep').css({ 'display': 'block' });
                                //}
                                //if (myList[m].id == 'dmSaldos') {
                                //    $('#rep').css({ 'display': 'block' });
                                //}
                               
                            }
                        }     
                       
                    }
                }
                else {                  
                   for (var m = 0; m < myList.length; m++) {
                      //mostrar elemento por el indice de la lista
                      $('#sidebar ul li:eq(' + m + ')').css({ 'display': 'block' });
                   }                   
                }
            }
            else {
                for (var m = 0; m < myList.length; m++) {                    
                    //ocultar elemento por el indice de la lista
                    $('#sidebar ul li:eq(' + m + ')').siblings().css({ 'display': 'none' });
                }
            }           
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}



function CARGAR_MENUS() {
    $.ajax({
        type: "POST",
        url: 'Fun_Menus.aspx/CARGAR_PERMISOS',
        dataType: "json",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $('#loading').show();
        },
        success: function (data) {
            var obj = jQuery.parseJSON(data.d[2]);
            var Menu = jQuery.parseJSON(obj);  
            if (data.d[0] == 0) {   
                CREAR_MENU(Menu);
            }
            else {  
                $.messager.alert('Error','No se Tienen Permisos', 'error');
            }
        },
        error: function (err) {
            $('#loading').hide(100);
            $.messager.alert('Error', er.statusText, 'error');
        },
        complete: function () { $('#loading').hide(100); }
    });
}

function CREAR_MENU(Menu) {
    var nombrerpt = "";
   
    for (var i = 0; i < Menu.length; i++) {
        var nombre = Menu[i].Nombre;
        var objlst = Menu[i].Url;
        var imagen = Menu[i].Icon;
        var Descripcion = Menu[i].Descripcion;

        var li = $('<li class="sidebar-item id="'+nombre+'"/>')
            .appendTo(ul);

        var a = $('<a class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse" data-bs-target="#auth" aria-expanded="false" aria-controls="Padrones"/>')
            .text(Descripcion)
            .attr('href', "javascript:void(0);")
            .appendTo(li);
         var i = $('class="'+imagen+'"/>')
            .appendTo(a);

        //if (objlst != null) {
        //    var sub_ul = $('<ul class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar"/>')
        //        .appendTo(li);
        //    submenu(sub_ul, objlst);
        //}
    }
}

function submenu(ul, objlst) {
    var nombrerpt = "";
    for (var i = 0; i < objlst.length; i++) {
        var nombre = objlst[i].Nombre;
        var objlst = objlst[i].Url;
        var imagen = objlst[i].Icon;
        var Descripcion = objlst[i].Descripcion;

        var nomtab = objlst[i].NombreTab;
        if (objlst[i].nombrerpt != undefined) { nombrerpt = objlst[i].nombrerpt; }
        else { nombrerpt = ""; }

        if (lstsub.length > 0) {
            var li = $('<li class="sidebar-item id="' + nombre +'"/>')
                .appendTo(ul);
            var a = $('<a class="sidebar-link"/>')
                .text(nombre)
                .attr('href', "javascript:void(0);")
                .appendTo(li);

            var sub_ul = $('<ul class="nav-list__sub"/>')
                .appendTo(li);
            submenu(sub_ul, lstsub);
        }
        else {
            var li = $('<li class="sidebar-item id="' + nombre + '"/>')
                .appendTo(ul);
            var a = $('<a class="sidebar-link" data-menu="' + url + '"/>')
                .text(nombre)
                .attr('href', ".." + url)
                .attr('name', nomtab)
                .appendTo(li);

            if ((permisofiltro == "Si") && (nomtab == 'Consulta de Empleados')) { AgregarTabPadre('Consulta', nombre, ".." + url); }
        }
    }
}

