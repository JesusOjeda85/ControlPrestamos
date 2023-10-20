using ClsObjetos;
using WebApi.Entidades;
using Newtonsoft.Json;
using System.Dynamic;

namespace WebApi.Repositorio.CargayDescarga
{
    public class RCargayDescarga
    {

        public static ObjMensaje Subir_Archivo_014a(DatosCargar Obj)
        {
            ObjMensaje msg = new();
            string datos = Obj.Archivo;
            string valores = "";
            var lista = JsonConvert.DeserializeObject<List<Archivo_014a>>(datos);
            foreach (Archivo_014a dat in lista)
            {
                valores += "''" + dat.descrech + "'',''" + dat.desind + "''," + dat.impnom + "," + dat.importe + ",''" + dat.indicador + "'',''" + dat.nomcom + "''," + dat.numemp + "," + dat.periodo + ",''" + dat.rfc + "'',''" + dat.estatus + "'',''" + dat.tipmov + "''," + dat.numprest + "|";
            }
            valores=valores.Substring(0, valores.Length - 1);
             
            return msg;
        }
    }
}
