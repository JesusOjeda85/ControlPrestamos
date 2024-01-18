using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    // List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    lsttbl= MetodosBD.ListaTablasJson(ds);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lsttbl;
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

        public static ObjMensaje Listar_Empleados(BuscarEmpleado obj)
        {
            ObjMensaje msg = new();

            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("Spt_Reportes_Listar_Empleados " + obj.FkOrganismo + ",'" + obj.Busqueda + "'");
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
    }
}
