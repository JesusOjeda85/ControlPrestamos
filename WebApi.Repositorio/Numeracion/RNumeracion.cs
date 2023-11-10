using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BaseDatos;

namespace WebApi.Repositorio.Numeracion
{
    public class RNumeracion
    {
        public static ObjMensaje Listar_Emisiones()
        {
            ObjMensaje msg = new();

            try
            {
               
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Numeracion_Listar_Emisiones ");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
                    msg.Datos = ds.Tables[1].Rows[0][0].ToString();
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
