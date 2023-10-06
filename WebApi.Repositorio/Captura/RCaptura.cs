using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BaseDatos;
using WebApi.Dto;
using WebApi.Entidades;

namespace WebApi.Repositorio.Captura
{
    public class RCaptura
    {
        public static ObjMensaje Listar_Plazos(DatosCaptura obj)
        {
            ObjMensaje msg = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_Plazos " + obj.IdUsuario);
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
        public static ObjMensaje Guardar_Captura(DatosCaptura Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Captura_Guardar " + Obj.IdUsuario + "," + Obj.FkOrganismo + "," + Obj.Empleado + ",'" + Obj.FechaSolicitud + "','" + Obj.Rfc.ToUpper() + "','" + Obj.Curp.ToUpper() + "','" + Obj.ApPaterno + "','" + Obj.ApMaterno+"'");
            if (ds.Tables.Count > 0)
            {
                msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                msg.Data = null;
                msg.Datos = "";
            }
            ds.Dispose();
            return msg;
        }
    }
}
