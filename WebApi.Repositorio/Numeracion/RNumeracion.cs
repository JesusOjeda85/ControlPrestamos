
using ClsObjetos;
using System.Data;
using WebApi.BaseDatos;
using WebApi.Entidades;

namespace WebApi.Repositorio.Numeracion
{
    public class RNumeracion
    {
        public static ObjMensaje Listar_Emisiones(DatosNumeracion Obj)
        {
            ObjMensaje msg = new();
            DataSet ds= new DataSet();
            try
            { 
                if (Obj.Modulo == "P") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Listar_Emisiones "); }
                if (Obj.Modulo == "R") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Listar_Emisiones_Retiros "); }
                if (Obj.Modulo == "S") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Listar_Emisiones_Siniestros"); }
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

        public static ObjMensaje Aplicar_Numeracion(DatosNumeracion Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new DataSet();
            try
            {
                if (Obj.Modulo == "P") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Generar_Produccion " + Obj.fkusuario + ",'" + Obj.Proceso + "'"); }
                if (Obj.Modulo == "R") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Generar_Produccion_Retiros " + Obj.fkusuario + ",'" + Obj.Proceso + "'"); }
                if (Obj.Modulo == "S") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Generar_Produccion_Siniestros " + Obj.fkusuario + ",'" + Obj.Proceso + "'"); }
                if (ds.Tables.Count > 0)
                {
                    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                    msg.Data = null;
                    msg.Datos = "";
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
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

        public static ObjMensaje Listar_SalidasEmisiones(DatosNumeracion Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new DataSet();
            try
            {
                if (Obj.Modulo == "P") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Listar_SalidasEmisiones "); }
                if (Obj.Modulo == "R") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Listar_SalidasEmisiones_Retiros "); }
                if (Obj.Modulo == "S") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Listar_SalidasEmisiones_Siniestros "); }
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


        public static ObjMensaje Listar_Emisiones_Renumeracion(DatosNumeracion Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new DataSet();
            try
            {

                if (Obj.Modulo == "P") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ReNumeracion_Listar_Emisiones "); }
                if (Obj.Modulo == "R") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ReNumeracion_Listar_Emisiones_Retiros "); }
                if (Obj.Modulo == "S") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ReNumeracion_Listar_Emisiones_Siniestros "); }

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

        public static ObjMensaje Aplicar_Renumeracion(DatosNumeracion Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new DataSet();
            try
            {
                if (Obj.Modulo == "P") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ReNumeracion_Aplicar " + Obj.fkusuario + ",'" + Obj.Proceso + "'"); }
                if (Obj.Modulo == "R") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ReNumeracion_Aplicar_Retiros " + Obj.fkusuario + ",'" + Obj.Proceso + "'"); }
                if (Obj.Modulo == "S") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ReNumeracion_Aplicar_Siniestros " + Obj.fkusuario + ",'" + Obj.Proceso + "'"); }

                if (ds.Tables.Count > 0)
                {
                    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                    msg.Data = null;
                    msg.Datos = "";
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
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
