using ClsObjetos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BaseDatos;
using WebApi.Entidades;

namespace WebApi.Repositorio.CargarPadrones
{
    public class RCargarPadrones
    {
        public static ObjMensaje Padron_Liquidez(DatosCargar Obj)
        {
            ObjMensaje msg = new();
            string datos = Obj.Archivo;
            string valores = "";
            try
            {
                var lista = JsonConvert.DeserializeObject<List<ArchivoLiquidez>>(datos);
                foreach (ArchivoLiquidez dat in lista)
                {
                    valores += "''" + dat.Rfc + "'',''" + dat.Nombre + "''," + dat.Empleado + "," + dat.Percepciones + "," + dat.DeduccionesLey + "," + dat.DeduccionesSindicales + "," + dat.PensionAlimenticia + "," + dat.Terceros + "," + dat.Liquidez + "|";
                }
                valores = valores.Substring(0, valores.Length - 1);

                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ControlArchivos_Cargar_Liquidez " + Obj.IdUsuario + "," + Obj.CvePerfil + "," + Obj.FkOrganismo + ",'" + Obj.Nombre + "','" + Obj.Quincena + "','" + valores + "'");
                if (ds.Tables.Count > 0)
                {
                    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                    msg.Data = null;
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
