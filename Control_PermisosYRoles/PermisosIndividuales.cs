using ClsDatos;
using ClsEntidades.Inicio;
using ClsEntidades.UauriosYPermisos;
using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Nomina_PermisosYRoles
{
    public class PermisosIndividuales
    {
        public static List<Dictionary<string, object>> Listar_Permisos_Individuales(FiltroIdModulo Obj)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosInd_Listar_Permisos " + Obj.Id + ",'" + Obj.Modulo + "'");
            if (ds.Tables[0].Rows.Count > 0)
            { rows = Metodos.convertirDatatableEnJsonString(ds.Tables[0]); }
            ds.Dispose();
            return rows;
        }

        public static ObjMensaje Guardar_Permisos_Individuales(GuardarPermisosIndividuales Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosInd_Guardar_Permisos " + Obj.Id + ",'" + Obj.FkPermisosMenus + "','" + Obj.FkMovPersonales + "','" + Obj.FkMovConceptos + "','" + Obj.FkMovDatPer + "','" + Obj.FkMovIncLab + "','" + Obj.FkMovRefFam + "','" + Obj.FkPermisosRep + "','" + Obj.FkPermisosTer + "','" + Obj.FkPermisosCatalogos + "','" + Obj.FkPermisosXls + "','" + Obj.FkPerisosProEsp + "','" + Obj.FkPermisosConsultas + "','"+Obj.FkPermisosPlazas + "'");
            if (ds.Tables.Count > 0)
            {
                msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    msg.Datos = Metodos.DataTableToJsonObj(ds.Tables[1]);
                }
            }

            ds.Dispose();
            return msg;
        }

        public static ObjMensaje Eliminar_Permisos_Individuales(EliminarPermisosIdModFkPer Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosInd_Eliminar_Permisos " + Obj.Id + ",'" + Obj.Modulo + "','" + Obj.FkPermisos + "'");
            msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            ds.Dispose();
            return msg;
        }

        public static ObjMensaje Eliminar_Permisos_Ind_Consultas(EliminarPermisosIdModFkPer Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Eliminar_Consultas " + Obj.Modulo + ",'" + Obj.Id + "','" + Obj.FkPermisos + "'");
            msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            ds.Dispose();
            return msg;
        }

        public static ObjMensaje Eliminar_Permisos_Ind_CreacionPla(EliminarPermisosIdModFkPer Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Eliminar_CreacionPla " + Obj.Modulo + ",'" + Obj.Id + "','" + Obj.FkPermisos + "'");
            msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            ds.Dispose();
            return msg;
        }

        public static ObjMensaje Eliminar_Permisos_Ind_Catalogos(EliminarPermisosIdModFkPer Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Eliminar_Catalogos " + Obj.Modulo + ",'" + Obj.Id + "','" + Obj.FkPermisos + "'");
            msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            ds.Dispose();
            return msg;
        }



        public static List<ObjTree>[] Listar_Permisos_Roles(FiltroIdModulo Obj)
        {
            List<ObjTree> LstObj = new List<ObjTree>();
            List<ObjTree>[] ListasObj = new List<ObjTree>[2];

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Listar_Roles '" + Obj.Modulo + "'," + Obj.Id);
            if (ds.Tables.Count > 0)
            {
                LstObj = new List<ObjTree>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ObjTree TreeObj = new ObjTree();
                    if (Obj.Modulo == "fil")
                    {
                        TreeObj.nombre = ds.Tables[0].Rows[i]["filtro"].ToString();
                    }
                    TreeObj.clave = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    TreeObj.text = ds.Tables[0].Rows[i]["descripcion"].ToString();
                    TreeObj.visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["estatus"].ToString());
                    LstObj.Add(TreeObj);
                }
                ListasObj[0] = LstObj;
                if (ds.Tables[1].Rows.Count > 0)
                {
                    string colrol = "";
                    if (Obj.Modulo == "menu") { colrol = "fkRolPermiso"; }
                    if (Obj.Modulo == "mov") { colrol = "fkRolMovimiento"; }
                    if (Obj.Modulo == "rep") { colrol = "fkRolReporte"; }
                    if (Obj.Modulo == "ter") { colrol = "fkRolterceros"; }
                    if (Obj.Modulo == "fil") { colrol = "fkRolFiltros"; }
                    if (Obj.Modulo == "pe") { colrol = "fkRolproesp"; }
                    if (Obj.Modulo == "pla") { colrol = "fkRolplazas"; }

                    LstObj = new List<ObjTree>();
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        ObjTree TreeObj = new ObjTree();
                        TreeObj.Id = Convert.ToInt32(ds.Tables[1].Rows[i]["Id"].ToString());
                        TreeObj.clave = Convert.ToInt32(ds.Tables[1].Rows[i][colrol].ToString());
                        LstObj.Add(TreeObj);
                    }
                    ListasObj[1] = LstObj;
                }
            }
            ds.Dispose();
            return ListasObj;
        }

        public static ObjMensaje Guardar_Permsios_Roles(GuardarPermisosIndividuales Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            //DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Guardar_Roles " + Obj.Id + ",'" + Obj.FkPermisosMenus + "','" + Obj.FkMovimiento + "','" + Obj.FkPermisosRep + "','" + Obj.FkPermisosTer + "','" + Obj.FkPermisosFil + "','" + Obj.FkPerisosProEsp + "','"+Obj.FkPermisosPla+"'");
            //if (ds.Tables.Count > 0)
            //{
            //    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
            //    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            //}

            //ds.Dispose();
            return msg;
        }

        public static ObjMensaje Eliminar_Permsios_Roles(EliminarPermisosIdModFkPer Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = new DataSet();
            ds = Metodos.EjecutarConsultaEnDataSet("SPT_PermisosYRoles_Eliminar_Roles_Usuario" + Obj.Id + ", '" + Obj.Modulo + "', '" + Obj.FkPermisos + "'");
            msg.Error = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            ds.Dispose();
            return msg;
        }
    }
}
