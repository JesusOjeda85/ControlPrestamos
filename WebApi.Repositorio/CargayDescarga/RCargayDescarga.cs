
using ClsObjetos;
using Newtonsoft.Json;
using System.Data;
using WebApi.BaseDatos;
using WebApi.Entidades;

namespace WebApi.Repositorio.CargayDescarga
{
    public class RCargayDescarga
    {

        public static ObjMensaje Subir_Archivo(DatosCargar Obj)
        {
            ObjMensaje msg = new();
            string datos = Obj.Archivo;
            string valores = "";
            try
            {
                var lista = JsonConvert.DeserializeObject<List<ArchivoCarga>>(datos);
                foreach (ArchivoCarga dat in lista)
                {
                    valores += "''" + dat.descrech + "'',''" + dat.desind + "''," + dat.impnom + "," + dat.importe + ",''" + dat.indicador + "'',''" + dat.nomcom + "''," + dat.numemp + "," + dat.periodo + ",''" + dat.rfc + "'',''" + dat.estatus + "'',''" + dat.tipmov + "''," + dat.numprest + "|";
                }
                valores = valores.Substring(0, valores.Length - 1);

                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ControlArchivos_Cargar " + Obj.IdUsuario +","+Obj.FkOrganismo +",'" + Obj.Nombre + "','"+Obj.Quincena+"','" + valores + "'");
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

        public static ObjMensaje Salida_Archivo(ArchivoSalida Obj)
        {
            ObjMensaje msg = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ControlArchivos_Salida " + Obj.IdUsuario + "," + Obj.FkOrganismo );
                if (ds.Tables.Count > 0)
                {
                    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                    msg.Data = MetodosBD.convertirDatatableEnJsonString(ds.Tables[1]);
                    msg.Datos = "";
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
