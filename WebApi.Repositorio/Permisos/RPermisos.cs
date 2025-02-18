
using ClsObjetos;
using System.Data;
using WebApi.BaseDatos;
using WebApi.Dto;
using WebApi.Entidades;



namespace WebApi.Repositorio.Permisos
{
    public class RPermisos
    {
        public static ObjMensaje Listar_Perfiles_Organimos(IdUsuarioDto Obj)
        {
            ObjMensaje msg = new();
            ObjTree TreeObj = new();
            List<ObjTree> LstObj = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Permisos_Listar_Perfiles " + Obj.Idusuario);
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TreeObj = new ObjTree();
                        TreeObj.Id = Convert.ToInt16(ds.Tables[0].Rows[i]["Id"].ToString());
                        TreeObj.text = (ds.Tables[0].Rows[i]["Concepto"].ToString() == "" ? ds.Tables[0].Rows[i]["Descripcion"].ToString() : ds.Tables[0].Rows[i]["Descripcion"].ToString() + "-" + ds.Tables[0].Rows[i]["Concepto"].ToString());
                        TreeObj.strclave = ds.Tables[0].Rows[i]["idreg"].ToString();
                        TreeObj.nombre = ds.Tables[0].Rows[i]["NombreSalida"].ToString();
                        TreeObj.checkbox = Convert.ToBoolean(ds.Tables[0].Rows[i]["Marcar"].ToString());
                        TreeObj.IdPadre = ds.Tables[0].Rows[i]["IdPadre"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["IdPadre"].ToString()) : (int?)null;
                        LstObj.Add(TreeObj);
                    }
                    List<ObjTree> LstTreeObj = Funsiones.GetObjTree(LstObj, 0);

                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = LstTreeObj;
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
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

        public static ObjMensaje Listar_Perfiles(IdUsuarioDto Obj)
        {
            ObjMensaje msg = new();
            ObjTree TreeObj = new();
            List<ObjTree> LstObj = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Permisos_Listar_Perfiles_TipoPuesto " + Obj.Idusuario);
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TreeObj = new ObjTree();
                        TreeObj.Id = Convert.ToInt16(ds.Tables[0].Rows[i]["Id"].ToString());
                        TreeObj.text = (ds.Tables[0].Rows[i]["Concepto"].ToString() == "" ? ds.Tables[0].Rows[i]["Descripcion"].ToString() :ds.Tables[0].Rows[i]["Concepto"].ToString());
                        TreeObj.strclave = ds.Tables[0].Rows[i]["idreg"].ToString();
                        TreeObj.nombre = ds.Tables[0].Rows[i]["NombreSalida"].ToString();
                        TreeObj.checkbox = Convert.ToBoolean(ds.Tables[0].Rows[i]["Marcar"].ToString());
                        TreeObj.IdPadre = ds.Tables[0].Rows[i]["IdPadre"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["IdPadre"].ToString()) : (int?)null;
                        LstObj.Add(TreeObj);
                    }
                    List<ObjTree> LstTreeObj = Funsiones.GetObjTree(LstObj, 0);

                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = LstTreeObj;
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
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

        public static ObjMensaje Listar_Menus()
        {
            ObjMensaje msg = new();
            ObjTree TreeObj = new();
            List<ObjTree> LstObj = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Permisos_Listar_Menus");
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TreeObj = new ObjTree();
                        TreeObj.Id = Convert.ToInt16(ds.Tables[0].Rows[i]["Orden"].ToString());
                        TreeObj.text = ds.Tables[0].Rows[i]["Descripcion"].ToString();
                        TreeObj.nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();
                        TreeObj.checkbox = Convert.ToBoolean(ds.Tables[0].Rows[i]["Marcar"].ToString());
                        TreeObj.visible= Convert.ToBoolean(ds.Tables[0].Rows[i]["Estatus"].ToString());
                        TreeObj.IdPadre = ds.Tables[0].Rows[i]["IdPadre"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["IdPadre"].ToString()) : (int?)null;
                        LstObj.Add(TreeObj);
                    }
                    List<ObjTree> LstTreeObj = Funsiones.GetModuloTree(LstObj, 0);

                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = LstTreeObj;
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

        public static ObjMensaje Listar_Reportes()
        {
            ObjMensaje msg = new();
            ObjTree TreeObj = new();
            List<ObjTree> LstObj = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Permisos_Listar_Reportes");
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TreeObj = new ObjTree();
                        TreeObj.Id = Convert.ToInt16(ds.Tables[0].Rows[i]["Id"].ToString());
                        TreeObj.text = ds.Tables[0].Rows[i]["Descripcion"].ToString();
                        TreeObj.nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();
                        TreeObj.strclave = ds.Tables[0].Rows[i]["Proceso"].ToString()+"@"+ ds.Tables[0].Rows[i]["TablaDS"].ToString() + "@" + ds.Tables[0].Rows[i]["CargaInicial"].ToString();
                        TreeObj.checkbox = Convert.ToBoolean(ds.Tables[0].Rows[i]["Marcar"].ToString());
                        TreeObj.IdPadre = ds.Tables[0].Rows[i]["IdPadre"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[i]["IdPadre"].ToString()) : (int?)null;
                        LstObj.Add(TreeObj);
                    }
                    List<ObjTree> LstTreeObj = Funsiones.GetObjTree(LstObj, 0);

                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = LstTreeObj;
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

        public static ObjMensaje Guardar_Permisos(DatosPermisos Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Permisos_Guardar " + Obj.Idusuario + ",'" + Obj.fkconceptos + "','" + Obj.fkmenus + "'");
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

        public static ObjMensaje Cargar_Permisos(IdUsuarioDto Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Permisos_Listar_Permisos " + Obj.Idusuario);
            if (ds.Tables.Count > 0)
            {
                List<string> tbls = MetodosBD.ListaTablasJson(ds);
                msg.Error = 0;
                msg.Mensaje = "";
                msg.Data = tbls;
                msg.Datos = "";
            }
            ds.Dispose();
            return msg;
        }

    }
}
