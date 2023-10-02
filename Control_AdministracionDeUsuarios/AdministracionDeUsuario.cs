using ClsDatos;
using ClsEntidades.Inicio;
using ClsEntidades.UauriosYPermisos;
using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;

namespace Nomina_AdministracionDeUsuarios
{
    public class AdministracionDeUsuario
    {
        public static List<ObjComboBox> Listar_Grupos()
        {
            ObjComboBox Cboobj = new ObjComboBox();
            List<ObjComboBox> lstcat = new List<ObjComboBox>();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Usuarios_Listar_Grupos");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Cboobj = new ObjComboBox();
                        Cboobj.valor = ds.Tables[0].Rows[i][0].ToString();
                        Cboobj.descripcion = ds.Tables[0].Rows[i][1].ToString();
                        Cboobj.selected = false;
                        lstcat.Add(Cboobj);
                    }
                }
            }
            ds.Dispose();
            return lstcat;
        }

        public static List<ObjTree> Listar_Usuarios()
        {
            ObjTree TreeObj = new ObjTree();
            List<ObjTree> LstObj = new List<ObjTree>();

            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Usuarios_Listar_Usuarios ''");
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeObj = new ObjTree();
                    TreeObj.Id = Convert.ToInt16(ds.Tables[0].Rows[i]["Id"].ToString());
                    TreeObj.text = ds.Tables[0].Rows[i]["Descripcion"].ToString();
                    TreeObj.target = ds.Tables[0].Rows[i]["Usuario"].ToString();
                    TreeObj.clave = Convert.ToInt32(ds.Tables[0].Rows[i]["clave"].ToString());
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["estado"].ToString()) == 1)
                    { TreeObj.state = "opened"; }
                    TreeObj.IdPadre = ds.Tables[0].Rows[i]["IdPadre"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["IdPadre"].ToString()) : (int?)null;
                    LstObj.Add(TreeObj);
                }
            }
            List<ObjTree> LstTreeObj = Funsiones.GetObjTree(LstObj, 0);
            ds.Dispose();
            return LstTreeObj;
        }

        public static ObjMensaje Buscar_UsuarioId(FiltroIdUsuario obj)
        {
            ObjMensaje msg = new ObjMensaje();
            try
            {
                DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Usuarios_Listar_Usuarios " + obj.Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Tbljson = Metodos.DataTableToJsonObj(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Datos = Tbljson;
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

        public static ObjMensaje Guardar_Usuario(EDatosUsuario Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Usuarios_Guardar_Usuarios " + Obj.Id + ",'" + Obj.Usuario + "','" + Obj.Contraseña + "','" + Obj.APPaterno.ToUpper() + "','" + Obj.APMaterno.ToUpper() + "','" + Obj.Nombres.ToUpper() + "','" + Obj.Correo + "','" + Obj.VigenciaIni + "','" + Obj.VigenciaFin + "'," + Obj.Estatus + "," + Obj.IdGrupo + "," + Obj.EsAdmin + "," + Obj.ConsultaExterna);
            if (ds.Tables.Count > 0)
            {
                msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            }
            ds.Dispose();
            return msg;
        }
    }
}
