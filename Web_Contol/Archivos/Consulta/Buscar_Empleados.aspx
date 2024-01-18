<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buscar_Empleados.aspx.cs" Inherits="ControlDescuentos.Archivos.Consulta.Buscar_Empleados" %>

<%

    //string pagina = (Request.Form["page"] == null) ? "1" : Request.Form["page"].ToString();
    //string rows = (Request.Form["rows"] == null) ? "20" : Request.Form["rows"].ToString();
    //string fkorganismo = "0";//Request.QueryString["fkorganismo"].ToString();
    string busqueda = Request.QueryString["busqueda"].ToString();

    //int paginasN = Convert.ToInt32(pagina);
    //int rowsN = Convert.ToInt32(rows);

    //ClsEntidades.SesionDto objusuario = (ClsEntidades.SesionDto)HttpContext.Current.Session["Sesion"];
    //if (objusuario != null)
    //{
    ClsEntidades.BuscarEmpleado pag = new ClsEntidades.BuscarEmpleado();
    //pag.Desde = ((paginasN * rowsN) - rowsN + 1);
    //pag.Hasta = (paginasN * rowsN);
    pag.Busqueda = busqueda;
    //pag.IdUsuario = objusuario.Idusuario;
   // pag.FkOrganismo = Convert.ToInt16(fkorganismo);

    string jsonobj = Newtonsoft.Json.JsonConvert.SerializeObject(pag);
    string respuesta = ClsObjetos.Llamar_Api.PostItem("Consulta/Listar_Empleados", jsonobj);
    ClsObjetos.ObjMensaje msg = Newtonsoft.Json.JsonConvert.DeserializeObject<ClsObjetos.ObjMensaje>(respuesta);

    string registros = Newtonsoft.Json.JsonConvert.SerializeObject(msg.Data);
    string total = msg.Datos;

    string resultado = "{\"rows\":" + registros + ",\"total\":\"" + total + "\"}";
    Response.Write(resultado);
    //}

        %>
