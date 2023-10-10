using ClsObjetos;
using System.Data;
using System.Data.SqlClient;
using WebApi.BaseDatos;
using WebApi.Dto;
using WebApi.Entidades;

namespace WebApi.Repositorio.Captura
{
    public class RCaptura
    {

        public static ObjMensaje Listar_Plazos(DatosCaptura obj)
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_Plazos " + obj.FkOrganismo);
                if (ds.Tables.Count > 0)
                {
                    Cboobj = new ObjComboBox();
                    Cboobj.valor = "x";
                    Cboobj.descripcion = "Seleccione una Opción";
                    Cboobj.selected = true;
                    lstcat.Add(Cboobj);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Cboobj = new ObjComboBox();
                        Cboobj.valor = ds.Tables[0].Rows[i]["id"].ToString();
                        Cboobj.descripcion = ds.Tables[0].Rows[i]["Descripcion"].ToString();
                        Cboobj.selected = false;
                        lstcat.Add(Cboobj);
                    }
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lstcat;
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
        public static ObjMensaje Listar_Bancos()
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_Bancos ");
                if (ds.Tables.Count > 0)
                {
                    Cboobj = new ObjComboBox();
                    Cboobj.valor = "x";
                    Cboobj.descripcion = "Seleccione una Opción";
                    Cboobj.selected = true;
                    lstcat.Add(Cboobj);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Cboobj = new ObjComboBox();
                        Cboobj.valor = ds.Tables[0].Rows[i][0].ToString();
                        Cboobj.descripcion = ds.Tables[0].Rows[i][1].ToString();
                        Cboobj.selected = false;
                        lstcat.Add(Cboobj);
                    }
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lstcat;
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
        public static ObjMensaje Listar_TipoPago()
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_TipoPago ");
                if (ds.Tables.Count > 0)
                {
                    Cboobj = new ObjComboBox();
                    Cboobj.valor = "x";
                    Cboobj.descripcion = "Seleccione una Opción";
                    Cboobj.selected = true;
                    lstcat.Add(Cboobj);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Cboobj = new ObjComboBox();
                        Cboobj.valor = ds.Tables[0].Rows[i][0].ToString();
                        Cboobj.descripcion = ds.Tables[0].Rows[i][1].ToString();
                        Cboobj.selected = false;
                        lstcat.Add(Cboobj);
                    }
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = lstcat;
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
        public static ObjMensaje Buscar_Empleado(BuscarEmpleado obj)
        {
            ObjMensaje msg = new();
           
            try
            {
                List<SqlParameter> parametro = new List<SqlParameter>
                {
                     new SqlParameter("@Desde", SqlDbType.Int) {Value= obj.Desde },
                      new SqlParameter("@Hasta", SqlDbType.Int) {Value= obj.Hasta },
                     new SqlParameter("@IdUsuario", SqlDbType.Int) {Value= obj.IdUsuario },
                      new SqlParameter("@FkOrganismo", SqlDbType.Int) {Value= obj.FkOrganismo },
                       new SqlParameter("@Busqueda", SqlDbType.VarChar,50) {Value= obj.Busqueda },
                };

                DataSet ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Buscar_Empleado ",parametro);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
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
        public static ObjMensaje Guardar_Captura(DatosCaptura Obj)
        {
            ObjMensaje msg = new();          
            List<SqlParameter> parametro = new List<SqlParameter>
            {
                new SqlParameter("@IdUsuario", SqlDbType.Int) {Value= Obj.IdUsuario },
                new SqlParameter("@FkOrganismo", SqlDbType.Int) { Value = Obj.FkOrganismo },
                new SqlParameter("@Empleado", SqlDbType.Int) { Value = Obj.Empleado },
                new SqlParameter("@FechaSolicitud", SqlDbType.VarChar, 50) { Value = Obj.FechaSolicitud },
                new SqlParameter("@Rfc", SqlDbType.VarChar, 20) { Value = Obj.Rfc },
                new SqlParameter("@Curp", SqlDbType.VarChar, 20) { Value = Obj.Curp },
                new SqlParameter("@ApMaterno", SqlDbType.VarChar, 20) { Value = Obj.ApMaterno },
                new SqlParameter("@ApPaterno", SqlDbType.VarChar, 20) { Value = Obj.ApPaterno },
                new SqlParameter("@Nombres", SqlDbType.VarChar, 20) { Value = Obj.Nombres },
                new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 20) { Value = Obj.NombreCompleto },
                new SqlParameter("@CvePagaduria", SqlDbType.VarChar, 20) { Value = Obj.CvePagaduria },
                new SqlParameter("@DesPagaduria", SqlDbType.VarChar, 300) { Value = Obj.DesPagaduria },
                new SqlParameter("@CveCategoria", SqlDbType.VarChar, 20) { Value = Obj.CveCategoria },
                new SqlParameter("@DesCategoria", SqlDbType.VarChar, 300) { Value = Obj.DesCategoria },
                new SqlParameter("@CveAdscripcion", SqlDbType.VarChar, 20) { Value = Obj.CveAdscripcion },
                new SqlParameter("@DesAdscripcion", SqlDbType.VarChar, 300) { Value = Obj.DesAdscripcion },
                new SqlParameter("@ImporteCredito", SqlDbType.Float) { Value = Obj.ImporteCredito },
                new SqlParameter("@FkPlazo", SqlDbType.Int, 20) { Value = Obj.FkPlazo },
             };


            DataSet ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Guardar ",parametro);
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
