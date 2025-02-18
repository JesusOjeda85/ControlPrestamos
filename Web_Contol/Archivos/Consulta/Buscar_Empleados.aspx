<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buscar_Empleados.aspx.cs" Inherits="ControlDescuentos.Archivos.Consulta.Buscar_Empleados" %>

<%

    string modulo = Request.QueryString["modulo"].ToString();
    string busqueda = Request.QueryString["busqueda"].ToString();

    ClsEntidades.BuscarEmpleado pag = new ClsEntidades.BuscarEmpleado();
    pag.Busqueda = busqueda;
    pag.Modulo = modulo;


    string jsonobj = Newtonsoft.Json.JsonConvert.SerializeObject(pag);
    string respuesta = ClsObjetos.Llamar_Api.PostItem("Consulta/Listar_Empleados", jsonobj);
    ClsObjetos.ObjMensaje msg = Newtonsoft.Json.JsonConvert.DeserializeObject<ClsObjetos.ObjMensaje>(respuesta);

    string registros = Newtonsoft.Json.JsonConvert.SerializeObject(msg.Data);
    string total = msg.Datos;

    string resultado = "{\"rows\":" + registros + ",\"total\":\"" + total + "\"}";
    Response.Write(resultado);


        %>
