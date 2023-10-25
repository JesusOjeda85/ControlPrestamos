using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using WebApi.BaseDatos;
using WebApi.Entidades;

namespace WebApi.Repositorio.Usuarios
{
    public class RUsuarios
    {
        public static ObjMensaje Listar_Usuarios()
        {
            ObjMensaje msg = new();
            ObjTree TreeObj = new();
            List<ObjTree> LstObj = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Sesion_Listar_Usuarios 0");
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TreeObj = new ObjTree();
                        TreeObj.Id = Convert.ToInt16(ds.Tables[0].Rows[i]["Id"].ToString());
                        TreeObj.text = ds.Tables[0].Rows[i]["nombre"].ToString();
                        TreeObj.target = ds.Tables[0].Rows[i]["Usuario"].ToString();                        
                        LstObj.Add(TreeObj);
                    }                   
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = LstObj;
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No Existe Información a Mostrar";
                    msg.Data = null;
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

        public static ObjMensaje Buscar_UsuarioId(DatosUsuario obj)
        {
            ObjMensaje msg = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Sesion_Listar_Usuarios " + obj.Idusuario);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
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

        public static ObjMensaje Guardar_Usuario(DatosUsuario Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Sesion_Guardar_Usuarios " + Obj.Idusuario + ",'" + Obj.Usuario + "','" + Obj.Contraseña + "','" + Obj.APPaterno.ToUpper() + "','" + Obj.APMaterno.ToUpper() + "','" + Obj.Nombres.ToUpper() + "'," + Obj.Administrador + "," + Obj.Estatus);
            if (ds.Tables.Count > 0)
            {
                msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                msg.Data = null;
                msg.Datos = "";
            }
            ds.Dispose();
            return msg;
        }
    }
}
