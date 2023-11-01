using ClsObjetos;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using WebApi.BaseDatos;
using WebApi.Dto;
using WebApi.Entidades;

namespace WebApi.Repositorio.CargayDescarga
{
    public class RCargayDescarga
    {

        public static ObjMensaje Subir_Archivo_014a(DatosCargar Obj)
        {
            ObjMensaje msg = new();
            string datos = Obj.Archivo;
            string valores = "";
            try
            {
                var lista = JsonConvert.DeserializeObject<List<Archivo_014a>>(datos);
                foreach (Archivo_014a dat in lista)
                {
                    valores += "''" + dat.descrech + "'',''" + dat.desind + "''," + dat.impnom + "," + dat.importe + ",''" + dat.indicador + "'',''" + dat.nomcom + "''," + dat.numemp + "," + dat.periodo + ",''" + dat.rfc + "'',''" + dat.estatus + "'',''" + dat.tipmov + "''," + dat.numprest + "|";
                }
                valores = valores.Substring(0, valores.Length - 1);

                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_ControlArchivos_Cargar " + Obj.IdUsuario + "," + Obj.CvePerfil +","+Obj.FkOrganismo +",'" + Obj.Nombre + "','"+Obj.Quincena+"','" + valores + "'");
                if (ds.Tables.Count > 0)
                {
                    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                    msg.Data = null;
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
