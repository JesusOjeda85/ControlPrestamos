<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listar_Empleados.aspx.cs" Inherits="ControlDescuentos.Archivos.Captura.Listar_Empleados" %>

<%   
    string fkorganismo=Request.QueryString["fkorganismo"].ToString();
    string fkconcepto=Request.QueryString["fkconcepto"].ToString();
    string busqueda =Request.QueryString["busqueda"].ToString();

    ClsEntidades.SesionDto objusuario = (ClsEntidades.SesionDto)HttpContext.Current.Session["Sesion"];
    if (objusuario != null)
    {
        ClsEntidades.BuscarEmpleado pag = new ClsEntidades.BuscarEmpleado();
        pag.Busqueda = busqueda;
        pag.IdUsuario = objusuario.Idusuario;
        pag.FkOrganismo = Convert.ToInt16(fkorganismo);
        pag.FkConcepto = Convert.ToInt16(fkconcepto);

        string jsonobj = Newtonsoft.Json.JsonConvert.SerializeObject(pag);
        string respuesta = ClsObjetos.Llamar_Api.PostItem("Captura/Buscar_Empleado", jsonobj);
        ClsObjetos.ObjMensaje msg = Newtonsoft.Json.JsonConvert.DeserializeObject<ClsObjetos.ObjMensaje>(respuesta);

        string registros = Newtonsoft.Json.JsonConvert.SerializeObject(msg.Data);
        string total = msg.Datos;

        string resultado = "{\"rows\":" + registros + ",\"total\":\"" + total + "\"}";
        Response.Write(resultado);
    }

        %>
