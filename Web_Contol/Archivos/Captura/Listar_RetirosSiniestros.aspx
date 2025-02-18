<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listar_RetirosSiniestros.aspx.cs" Inherits="ControlDescuentos.Archivos.Captura.Listar_RetirosSiniestros" %>

<%       
    string busqueda =Request.QueryString["busqueda"].ToString();
    string modulo =Request.QueryString["modulo"].ToString();

    ClsEntidades.SesionDto objusuario = (ClsEntidades.SesionDto)HttpContext.Current.Session["Sesion"];
    if (objusuario != null)
    {
        ClsEntidades.BuscarEmpleado pag = new ClsEntidades.BuscarEmpleado();
        pag.Busqueda = busqueda;
        pag.IdUsuario = 1;// objusuario.Idusuario;
        pag.Modulo = modulo;

        string jsonobj = Newtonsoft.Json.JsonConvert.SerializeObject(pag);
        string respuesta = ClsObjetos.Llamar_Api.PostItem("Captura/Buscar_Retiros_Siniestros", jsonobj);
        ClsObjetos.ObjMensaje msg = Newtonsoft.Json.JsonConvert.DeserializeObject<ClsObjetos.ObjMensaje>(respuesta);

        string registros = Newtonsoft.Json.JsonConvert.SerializeObject(msg.Data);
        string total = msg.Datos;

        string resultado = "{\"rows\":" + registros + ",\"total\":\"" + total + "\"}";
        Response.Write(resultado);
    }

        %>
