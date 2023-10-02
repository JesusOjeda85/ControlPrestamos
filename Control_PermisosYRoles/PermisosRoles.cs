using ClsDatos;
using ClsEntidades.Inicio;
using ClsEntidades.UauriosYPermisos;
using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;

namespace Nomina_PermisosYRoles
{
    public class PermisosRoles
    {
        public static List<ObjTree> Listar_Roles(FiltroModulo Obj)
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstTreeObj = new List<ObjTree>();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Listar_Roles '" + Obj.Modulo + "'");
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeObj = new ObjTree();
                    if (Obj.Modulo == "fil")
                    {
                        TreeObj.nombre = ds.Tables[0].Rows[i]["filtro"].ToString();
                    }
                    TreeObj.clave = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    TreeObj.text = ds.Tables[0].Rows[i]["descripcion"].ToString();
                    TreeObj.visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["estatus"].ToString());
                    LstTreeObj.Add(TreeObj);
                }
            }
            ds.Dispose();
            return LstTreeObj;
        }

        public static ObjMensaje Listar_Permisos(FiltroIdTipoPermiso Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = new DataSet();
           
            try
            {
                ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Listar_Permisos_Roles " + Obj.Id + ",'" + Obj.TipoPermiso + "','"+Obj.Modulo+"'");
                if (ds.Tables[0].Rows.Count > 0)
                {                                         
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Datos= Metodos.DataTableToJsonObj(ds.Tables[0]);
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No Existe Información";
                }
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            ds.Dispose();
            return msg;
        }

        public static ObjMensaje Listar_Permisos_PE(FiltroIdTipoPermiso Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = new DataSet();
           
            try
            {
                ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Listar_Permisos_Roles " + Obj.Id + ",'" + Obj.TipoPermiso + "',''");
                if ((ds.Tables[0].Rows.Count > 0) || (ds.Tables[1].Rows.Count > 0))
                {
                    msg.Error = 0;
                    msg.Mensaje = "";
                    List<string> lsttbl = Metodos.ListaTablasJson(ds);
                    msg.Data = lsttbl;
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No Existe Información";
                }
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            ds.Dispose();
            return msg;
        }

        public static List<Dictionary<string, object>> Listar_Usuarios(FiltroIdModulo Obj)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Listar_DatosUsuarios_Roles " + Obj.Id + ",'" + Obj.Modulo + "'");
            if (ds.Tables[0].Rows.Count > 0)
            { rows = Metodos.convertirDatatableEnJsonString(ds.Tables[0]); }
            ds.Dispose();
            return rows;
        }

        public static List<ObjTree> Listar_Movimientos_Asignados(FiltroIdUsuario Obj)
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Listar_Roles_Movimientos " + Obj.Id + ",''");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TreeObj = new ObjTree();
                TreeObj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                TreeObj.target = ds.Tables[0].Rows[i]["Id"].ToString();
                TreeObj.text = ds.Tables[0].Rows[i]["Nombre"].ToString();
                TreeObj.IdPadre = ds.Tables[0].Rows[i]["Propietario"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["Propietario"]) : (int?)null;
                TreeObj.visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["Visible"].ToString());
                LstObj.Add(TreeObj);
            }
            List<ObjTree> LstTreeObj = Funsiones.GetObjTree(LstObj, 0);
            ds.Dispose();
            return LstTreeObj;
        }

        public static List<ObjTree> Listar_Indicadores_Asignados()
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sistema_Listar_Indicadores_Deducciones");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TreeObj = new ObjTree();
                TreeObj.strclave = ds.Tables[0].Rows[i][0].ToString();
                TreeObj.text = ds.Tables[0].Rows[i][1].ToString();
                LstObj.Add(TreeObj);
            }
            ds.Dispose();
            return LstObj;
        }



        public static ObjMensaje Guardar_Roles_Menus(GuardarPermisosIndividuales Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            //DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Guardar_Roles_Menus " + Obj.Id + ", '" + Obj.Descripcion.ToUpper() + "', " + Obj.Activo + ", '" + Obj.FkPermisosMenus + "', '" + Obj.FkPermisosCatalogos + "', '" + Obj.FkPermisosConsultas + "'");
            //if (ds.Tables.Count > 0)
            //{
            //    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
            //    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            //}
            //ds.Dispose();
            return msg;
        }

        public static ObjMensaje Guardar_Roles_Movimientos(GuardarPermisosIndividuales Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            //DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Guardar_Roles_Movimientos " + Obj.Id + ", '" + Obj.Descripcion.ToUpper() + "', " + Obj.Activo + ", '" + Obj.FkMovimiento + "', '" + Obj.FkMovPersonales + "', '" + Obj.FkMovConceptos + "', '" + Obj.FkMovDatPer + "', '" + Obj.FkMovRefFam + "', '" + Obj.FkMovIncLab + "', '" + Obj.Indicadores + "'");
            //if (ds.Tables.Count > 0)
            //{
            //    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
            //    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            //}
            //ds.Dispose();
            return msg;
        }

        public static ObjMensaje Guardar_Roles_Plazas(GuardarPermisosIndividuales Obj)
        {
           ObjMensaje msg = new ObjMensaje();
            //DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Guardar_Roles_Plazas " + Obj.Id + ", '" + Obj.Descripcion.ToUpper() + "', " + Obj.Activo + ", '" + Obj.FkPermisosPla + "'");
            //if (ds.Tables.Count > 0)
            //{
            //    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
            //    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            //}
            //ds.Dispose();
            return msg;
        }

        public static ObjMensaje Guardar_Roles_ProcesoEsp(GuardarPermisosIndividuales Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            //DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Guardar_Roles_ProcesosEspeciales " + Obj.Id + ", '" + Obj.Descripcion.ToUpper() + "', " + Obj.Activo + ", '" + Obj.FkPermisosXls + "', '" + Obj.FkPerisosProEsp + "'");
            //if (ds.Tables.Count > 0)
            //{
            //    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
            //    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            //}
            //ds.Dispose();
            return msg;
        }

        public static ObjMensaje Guardar_Roles_Reportes(GuardarPermisosIndividuales Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            //DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Guardar_Roles_Reportes " + Obj.Id + ", '" + Obj.Descripcion.ToUpper() + "', " + Obj.Activo + ", '" + Obj.FkPermisosRep + "'");
            //if (ds.Tables.Count > 0)
            //{
            //    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
            //    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            //}
            //ds.Dispose();
            return msg;
        }

        public static ObjMensaje Guardar_Roles_Terceros(GuardarPermisosIndividuales Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            //DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Guardar_Roles_Terceros " + Obj.Id + ", '" + Obj.Descripcion.ToUpper() + "', " + Obj.Activo + ", '" + Obj.FkPermisosTer + "'");
            //if (ds.Tables.Count > 0)
            //{
            //    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
            //    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            //}
            //ds.Dispose();
            return msg;
        }
       
        public static ObjMensaje Guardar_Roles_Filtros(GuardarPermisosIndividuales Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            //DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Guardar_Roles_Filtros " + Obj.Id + ", '" + Obj.Descripcion.ToUpper() + "', " + Obj.Activo + ", '" + Obj.FkPermisosFil + "'");
            //if (ds.Tables.Count > 0)
            //{
            //    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
            //    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            //}
            //ds.Dispose();
            return msg;
        }



        public static ObjMensaje Eliminar_Roles(FiltroIdTipoPermiso Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = new DataSet();
            ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Eliminar_Rol_Modulo '" + Obj.TipoPermiso + "', " + Obj.Id);
            msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            ds.Dispose();
            return msg;
        }

        public static ObjMensaje Eliminar_Permisos_Roles(FiltroPermisosRoles Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Eliminar_Permisos_Rol '" + Obj.Modulo + "','" + Obj.TipoPermiso + "'," + Obj.Id + ",'" + Obj.FkPermisos + "'");
            msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            ds.Dispose();
            return msg;
        }

        public static ObjMensaje Eliminar_Roles_Catalogos(FiltroIdUsuPermisos Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Eliminar_Permisos_Catalogo_Rol '" + Obj.TipoPermiso + "'," + Obj.Id + ",'" + Obj.FkPermisos + "'");
            msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            ds.Dispose();
            return msg;
        }

        public static ObjMensaje Eliminar_Roles_Consultas(FiltroIdUsuPermisos Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Eliminar_Permisos_Consulta_Rol '" + Obj.TipoPermiso + "',"+0+",'" + Obj.FkPermisos + "'");
            msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            ds.Dispose();
            return msg;
        }

        //public static ObjMensaje Eliminar_Permisos_MenuPlazas(FiltroIdUsuPermisos Obj)
        //{
        //    ObjMensaje msg = new ObjMensaje();
        //    DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Eliminar_Permisos_CreacionPla_Rol '" + Obj.TipoPermiso + "'," + Obj.Id + ",'" + Obj.FkPermisos + "'");
        //    msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        //    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
        //    ds.Dispose();
        //    return msg;
        //}
    }
}
