using ClsDatos;
using ClsEntidades.UauriosYPermisos;
using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;

namespace Nomina_PermisosYRoles
{
    public class PermisosBotones
    {
        public static ObjMensaje Botones_CreacionPlazas(FiltroIdUsuario obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = new DataSet();
            try
            {
                ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Listar_Permisos_CreacionPlaza " + obj.Id + ",'I'");
                List<string> Tbljson = Metodos.ListaTablasJson(ds);

                msg.Error = 0;
                msg.Mensaje = "";
                msg.Data = Tbljson;
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            ds.Dispose();
            return msg;
        }
        public static ObjMensaje Botones_ConsultasHistoria(FiltroPermisosConsultas obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = new DataSet();
            try
            {
                ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Listar_Permisos_ConsultasHiist " + obj.Id + "," + obj.Consulta);
                List<string> Tbljson = Metodos.ListaTablasJson(ds);

                msg.Error = 0;
                msg.Mensaje = "";
                msg.Data = Tbljson;
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            ds.Dispose();
            return msg;
        }
    }
}
