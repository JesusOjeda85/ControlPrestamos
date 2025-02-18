
using ClsObjetos;
using System.Data;
using WebApi.BaseDatos;
using WebApi.Dto;


namespace WebApi.Repositorio.Reportes
{
    public class RReportes
    {
        public static ObjMensaje Listar_Pagare(FiltroPagare obj)
        {
            ObjMensaje msg = new();
            List<string> lsttbl = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Reportes_Listar_Pagare "+obj.FkOrganismo+",'"+obj.Condicion+"'");
                if (ds.Tables[0].Rows.Count > 0)
                {                   
                    lsttbl = MetodosBD.ListaTablasJson(ds);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lsttbl;
                }
                else {
                    msg.Error = 1;
                    msg.Mensaje = "No existe información";
                    msg.Data = null;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

        public static ObjMensaje Listar_Saldos(FiltroPagare obj)
        {
            ObjMensaje msg = new();
            List<string> lsttbl = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Reportes_Listar_Saldos '" + obj.FkOrganismo + "','" + obj.Condicion + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lsttbl = MetodosBD.ListaTablasJson(ds);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lsttbl;
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No existe información";
                    msg.Data = null;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

        public static ObjMensaje Salida_Emisiones(FiltroPagare obj)
        {
            ObjMensaje msg = new();
            List<string> lsttbl = new();
            DataSet ds = new DataSet();
            try
            {
                if (obj.Modulo == "P") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Reportes_Listar_SalidasEmisiones '" + obj.FkOrganismo + "','" + obj.Condicion + "','" + obj.ImpresionCH+"'"); }
                if (obj.Modulo == "R") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Reportes_Listar_SalidasEmisiones_Retiros '" + obj.FkOrganismo + "','" + obj.Condicion + "','" + obj.ChequesNulos+"','"+obj.ImpresionCH+"'"); }
                if (obj.Modulo == "S") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Reportes_Listar_SalidasEmisiones_Siniestros '" + obj.FkOrganismo + "','" + obj.Condicion + "','" + obj.ChequesNulos + "','" + obj.ImpresionCH + "'"); }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lsttbl = MetodosBD.ListaTablasJson(ds);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lsttbl;
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No existe información";
                    msg.Data = null;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

        public static ObjMensaje Listar_Empleados(FiltroBuscarEmpleado obj)
        {
            ObjMensaje msg = new();

            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("Spt_Reportes_Listar_Empleados '" + obj.Condicion + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

        public static ObjMensaje Listar_Adeudos(FiltroPagare obj)
        {
            ObjMensaje msg = new();
            List<string> lsttbl = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Reportes_Listar_Adeudos '" + obj.Condicion + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lsttbl = MetodosBD.ListaTablasJson(ds);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lsttbl;
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No existe información";
                    msg.Data = null;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

        public static ObjMensaje Revision_Captura(FiltroPagare obj)
        {
            ObjMensaje msg = new();
            List<string> lsttbl = new();
            DataSet ds = new DataSet();
            try
            {                
                if (obj.Modulo == "R") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Reportes_Listar_RevisionCaptura_Retiros '" + obj.Condicion + "'"); }
                if (obj.Modulo == "S") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Reportes_Listar_RevisionCaptura_Siniestros '" + obj.Condicion + "'"); }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lsttbl = MetodosBD.ListaTablasJson(ds);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lsttbl;
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No existe información";
                    msg.Data = null;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

        public static ObjMensaje Listar_Cancelaciones(FiltroPagare obj)
        {
            ObjMensaje msg = new();
            List<string> lsttbl = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Reportes_Listar_Cancelaciones '" + obj.Modulo + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lsttbl = MetodosBD.ListaTablasJson(ds);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lsttbl;
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No existe información";
                    msg.Data = null;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

    }
}
