using ClsDatos;
using ClsEntidades.Inicio;
using ClsEntidades.UauriosYPermisos;
using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;

namespace Nomina_PermisosYRoles
{
    public class PermisosDeMenus
    {
        public static List<ObjMenu> Menu_Inicial(int Id)
        {
            ObjMenu TreeObj = new ObjMenu();
            List<ObjMenu> LstObj = new List<ObjMenu>();
            List<ObjMenu> LstTreeObj = new List<ObjMenu>();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Menus_Permisos " + Id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeObj = new ObjMenu();

                    TreeObj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    TreeObj.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    TreeObj.Url = ds.Tables[0].Rows[i]["url"].ToString();
                    TreeObj.UrlImagen = ds.Tables[0].Rows[i]["urlimagen"].ToString();
                    TreeObj.NombreTab = ds.Tables[0].Rows[i]["NombreTab"].ToString();
                    TreeObj.Propietario = ds.Tables[0].Rows[i]["propietario"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["propietario"].ToString()) : (int?)null;
                    TreeObj.Visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["visible"]);
                    LstObj.Add(TreeObj);
                }
                LstTreeObj = Funsiones.GetMenuTree(LstObj, 0);
            }
            ds.Dispose();
            return LstTreeObj;
        }

        public static List<ObjTree> Listar_Menu()
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();
            List<ObjTree> LstTreeObj = new List<ObjTree>();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Menus");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeObj = new ObjTree();
                    TreeObj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    TreeObj.text = ds.Tables[0].Rows[i]["nombre"].ToString();
                    TreeObj.IdPadre = ds.Tables[0].Rows[i]["propietario"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["propietario"]) : (int?)null;
                    TreeObj.visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["visible"].ToString());
                    LstObj.Add(TreeObj);
                }
                LstTreeObj = Funsiones.GetObjTree(LstObj, 0);
            }
            ds.Dispose();
            return LstTreeObj;
        }

        public static List<ObjTree> Listar_Reportes()
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Reportes");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TreeObj = new ObjTree();
                TreeObj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                TreeObj.text = ds.Tables[0].Rows[i]["Descripcion"].ToString();
                TreeObj.IdPadre = ds.Tables[0].Rows[i]["propietario"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["propietario"]) : (int?)null;
                TreeObj.visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["visible"].ToString());
                LstObj.Add(TreeObj);
            }
            List<ObjTree> LstTreeObj = Funsiones.GetObjTree(LstObj, 0);
            ds.Dispose();
            return LstTreeObj;
        }

        public static List<ObjTree> Listar_Terceros()
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Terceros");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TreeObj = new ObjTree();
                TreeObj.clave = Convert.ToInt32(ds.Tables[0].Rows[i]["cveter"].ToString());
                TreeObj.text = ds.Tables[0].Rows[i]["dester"].ToString();
                TreeObj.visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["activo"].ToString());
                LstObj.Add(TreeObj);
            }
            ds.Dispose();
            return LstObj;
        }

        public static List<ObjTree> Listar_Plazas()
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_MenuPlazas");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TreeObj = new ObjTree();
                TreeObj.strclave = ds.Tables[0].Rows[i]["Tipoplaza"].ToString();
                TreeObj.text = ds.Tables[0].Rows[i]["titulocaptura"].ToString();
                TreeObj.visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["visible"].ToString());
                LstObj.Add(TreeObj);
            }
            ds.Dispose();
            return LstObj;
        }

        public static List<ObjTree> Listar_Creacion_Plazas(FiltroIdTipoPermiso Obj)
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Botones_CreacionDePlaza " + Obj.Id + ",'" + Obj.TipoPermiso + "'");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TreeObj = new ObjTree();
                TreeObj.text = ds.Tables[0].Rows[i]["Tipoplaza"].ToString();
                TreeObj.nombre = ds.Tables[0].Rows[i]["titulocaptura"].ToString();
                TreeObj.visible =Convert.ToBoolean(ds.Tables[0].Rows[i]["visible"].ToString());
                LstObj.Add(TreeObj);
            }
            ds.Dispose();
            return LstObj;
        }

        public static List<ObjTree>[] Listar_Procesos_Especiales()
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();
            List<ObjTree>[] ListasObj = new List<ObjTree>[2];

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Procesos_Especiales");
            if (ds.Tables.Count > 0)
            {
                for (int t = 0; t < ds.Tables.Count; t++)
                {
                    LstObj = new List<ObjTree>();
                    for (int i = 0; i < ds.Tables[t].Rows.Count; i++)
                    {
                        TreeObj = new ObjTree();
                        TreeObj.clave = Convert.ToInt32(ds.Tables[t].Rows[i][0].ToString());
                        TreeObj.target = ds.Tables[t].Rows[i][0].ToString();
                        TreeObj.text = ds.Tables[t].Rows[i][1].ToString();
                        TreeObj.visible = Convert.ToBoolean(ds.Tables[t].Rows[i][2].ToString());
                        LstObj.Add(TreeObj);
                    }
                    ListasObj[t] = LstObj;
                }
                ds.Dispose();
            }
            return ListasObj;
        }

        public static List<ObjTree> Listar_Movimientos(FiltroModulo Obj)
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Movimientos '" + Obj.Modulo + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeObj = new ObjTree();
                    TreeObj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    TreeObj.nombre = ds.Tables[0].Rows[i]["Id"].ToString();
                    TreeObj.text = ds.Tables[0].Rows[i]["Nombre"].ToString();
                    TreeObj.IdPadre = ds.Tables[0].Rows[i]["Propietario"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["Propietario"]) : (int?)null;
                    TreeObj.visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["Visible"].ToString());
                    LstObj.Add(TreeObj);
                }
            }
            List<ObjTree> LstTreeObj = Funsiones.GetModuloTree(LstObj, 0);
            ds.Dispose();
            return LstTreeObj;
        }

        public static ObjMensaje Listar_Movimientos_Permisos(FiltroIdModClave Obj)
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();
            ObjMensaje Msg = new ObjMensaje();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_MovimientosPermisos " + Obj.Id + ",'"+Obj.Modulo+"','"+Obj.Filtro+"'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeObj = new ObjTree();
                    TreeObj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    TreeObj.nombre = ds.Tables[0].Rows[i]["Id"].ToString();
                    TreeObj.text = ds.Tables[0].Rows[i]["Id"].ToString() + "-" + ds.Tables[0].Rows[i]["Nombre"].ToString();
                    TreeObj.IdPadre = ds.Tables[0].Rows[i]["Propietario"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["Propietario"]) : (int?)null;
                    TreeObj.visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["Visible"].ToString());
                    LstObj.Add(TreeObj);
                }
                List<ObjTree> LstTreeObj = Funsiones.GetModuloTree(LstObj, 0);
                Msg.Error = 0;
                Msg.Data = LstTreeObj;
                Msg.Mensaje = "";
            }
            else {
                Msg.Error = 1;
                Msg.Mensaje = "";
            }
            
            ds.Dispose();
            return Msg;
        }

        public static List<Dictionary<string, object>> Listar_Catalogos(FiltroIdTipoPermiso Obj)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Catalogos " + Obj.Id + ",'" + Obj.TipoPermiso + "'");
            if (ds.Tables[0].Rows.Count > 0)
            { rows = Metodos.convertirDatatableEnJsonString(ds.Tables[0]); }
            ds.Dispose();
            return rows;
        }

        public static List<Dictionary<string, object>> Listar_ConsultasHist(FiltroIdTipoPermiso Obj)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Consultas " + Obj.Id + ",'" + Obj.TipoPermiso + "'");
            if (ds.Tables[0].Rows.Count > 0)
            { rows = Metodos.convertirDatatableEnJsonString(ds.Tables[0]); }
            ds.Dispose();
            return rows;
        }

        
    }
}
