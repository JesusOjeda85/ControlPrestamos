<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buscar_Creditos.aspx.cs" Inherits="ControlDescuentos.Archivos.Devoluciones.Buscar_Creditos" %>

<%

 
    string busqueda = Request.QueryString["busqueda"].ToString();

   
    ClsEntidades.BuscarEmpleado pag = new ClsEntidades.BuscarEmpleado();
   
    pag.Busqueda = busqueda;
   

    string jsonobj = Newtonsoft.Json.JsonConvert.SerializeObject(pag);
    string respuesta = ClsObjetos.Llamar_Api.PostItem("Devoluciones/Listar_Adeudos_Creditos", jsonobj);
    ClsObjetos.ObjMensaje msg = Newtonsoft.Json.JsonConvert.DeserializeObject<ClsObjetos.ObjMensaje>(respuesta);

    string registros = Newtonsoft.Json.JsonConvert.SerializeObject(msg.Data);
    string total = msg.Datos;

    string resultado = "{\"rows\":" + registros + ",\"total\":\"" + total + "\"}";
    Response.Write(resultado);
   

        %>
