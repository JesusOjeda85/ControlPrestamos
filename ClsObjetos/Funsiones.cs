using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsObjetos
{
   public class Funsiones
    {
        public static List<ObjTree> GetObjTree(List<ObjTree> list, int? IdPadre)
        {
            return list.Where(x => x.IdPadre == IdPadre).Select(x => new ObjTree()
            {
                Id = x.Id,
                text = x.text,
                target = x.target,
                clave = x.clave,
                IdPadre = x.IdPadre,
                state = x.state,
                children = GetObjTree(list, x.Id)
            }).ToList();
        }

        public static List<ObjMenu> GetMenuTree(List<ObjMenu> list, int? propietario)
        {
            return list.Where(x => x.Propietario == propietario).Select(x => new ObjMenu()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Url = x.Url,
                UrlImagen = x.UrlImagen,
                NombreTab = x.NombreTab,
                Propietario = x.Propietario,
                Visible = x.Visible,
                List = GetMenuTree(list, x.Id)
            }).ToList();
        }
        public static List<ObjTree> GetModuloTree(List<ObjTree> list, int? IdPadre)
        {
            return list.Where(x => x.IdPadre == IdPadre).Select(x => new ObjTree()
            {
                Id = x.Id,
                text = x.text,
                nombre = x.nombre,
                IdPadre = x.IdPadre,
                visible = x.visible,
                children = GetModuloTree(list, x.Id)
            }).ToList();
        }
    }
}
