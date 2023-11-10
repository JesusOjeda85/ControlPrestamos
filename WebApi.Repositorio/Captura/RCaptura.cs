using ClsObjetos;
using System;
using System.Collections.Generic;
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
        public static ObjMensaje Listar_ZonaPago()
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_ZonaPago ");
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
        public static ObjMensaje Listar_TipoPuesto()
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_TipoPuesto ");
                if (ds.Tables.Count > 0)
                {
                    //Cboobj = new ObjComboBox();
                    //Cboobj.valor = "x";
                    //Cboobj.descripcion = "Seleccione una Opción";
                    //Cboobj.selected = true;
                    //lstcat.Add(Cboobj);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Cboobj = new ObjComboBox();
                        Cboobj.valor = ds.Tables[0].Rows[i][0].ToString();
                        Cboobj.descripcion = ds.Tables[0].Rows[i][1].ToString();
                        if (i == 0) { Cboobj.selected = true; }
                        else
                        { Cboobj.selected = false; }
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
                List<SqlParameter> parametro = new()
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
            try { 
                List<SqlParameter> parametro = new()
                {
                    new SqlParameter("@FkUsuarioCaptura", SqlDbType.Int) {Value= Obj.FkUsuarioCaptura },
                    new SqlParameter("@FkOrganismo", SqlDbType.Int) { Value = Obj.FkOrganismo },
                    new SqlParameter("@FkConcepto", SqlDbType.Int) { Value = Obj.FkConcepto },
                    new SqlParameter("@Empleado", SqlDbType.Int) { Value = Obj.Empleado },
                    new SqlParameter("@FechaSolicitud", SqlDbType.VarChar, 11) { Value = Obj.FechaSolicitud },
                    new SqlParameter("@FechaIngreso", SqlDbType.VarChar, 11) { Value = Obj.FechaIngreso },
                    new SqlParameter("@Rfc", SqlDbType.VarChar, 20) { Value = Obj.Rfc },
                    new SqlParameter("@Curp", SqlDbType.VarChar, 20) { Value = Obj.Curp },
                    new SqlParameter("@ApPaterno", SqlDbType.VarChar, 100) { Value = Obj.ApPaterno },
                    new SqlParameter("@ApMaterno", SqlDbType.VarChar, 100) { Value = Obj.ApMaterno },
                    new SqlParameter("@Nombres", SqlDbType.VarChar, 100) { Value = Obj.Nombres },
                    new SqlParameter("@Domicilio", SqlDbType.VarChar, 100) { Value = Obj.Domicilio },
                    new SqlParameter("@Telefono1", SqlDbType.VarChar, 100) { Value = Obj.Telefono1 },
                    new SqlParameter("@Telefono2", SqlDbType.VarChar, 100) { Value = Obj.Telefono2 },
                    new SqlParameter("@CvePagaduria", SqlDbType.VarChar, 20) { Value = Obj.CvePagaduria },
                    new SqlParameter("@DesPagaduria", SqlDbType.VarChar, 300) { Value = Obj.DesPagaduria },
                    new SqlParameter("@CveCategoria", SqlDbType.VarChar, 20) { Value = Obj.CveCategoria },
                    new SqlParameter("@DesCategoria", SqlDbType.VarChar, 300) { Value = Obj.DesCategoria },
                    new SqlParameter("@CveAdscripcion", SqlDbType.VarChar, 20) { Value = Obj.CveAdscripcion },
                    new SqlParameter("@DesAdscripcion", SqlDbType.VarChar, 300) { Value = Obj.DesAdscripcion },
                    new SqlParameter("@ImporteCredito", SqlDbType.BigInt) { Value = Obj.ImporteCredito },
                    new SqlParameter("@FkPlazo", SqlDbType.Int) { Value = Obj.FkPlazo },
                    new SqlParameter("@FkTipoPago", SqlDbType.Int) { Value = Obj.FkTipoPago },
                    new SqlParameter("@FkTipoPuesto", SqlDbType.Int) { Value = Obj.FkTipoPuesto },
                    new SqlParameter("@FkBanco", SqlDbType.Int) { Value = Obj.FkBanco },
                    new SqlParameter("@Cuenta", SqlDbType.Int) { Value = Obj.Cuenta },
                    new SqlParameter("@FkZonaPago", SqlDbType.Int) { Value = Obj.FkZonaPago },
                };


                //DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Captura_Guardar "+ Obj.IdUsuario+","+ Obj.FkOrganismo+","+ Obj.Empleado+",'"+ Obj.FechaSolicitud +"','"+ Obj.Rfc + "','" + Obj.Curp + "','" + Obj.ApPaterno + "','" + Obj.ApMaterno + "','" + Obj.Nombres + "','" + Obj.CvePagaduria + "','" + Obj.DesPagaduria + "','" + Obj.CveCategoria + "','" + Obj.DesCategoria + "','" + Obj.CveAdscripcion + "','" + Obj.DesAdscripcion + "'," + Obj.ImporteCredito+","+ Obj.FkPlazo + "," + Obj.FkTipoPago + "," + Obj.FkBanco + "," + Obj.Cuenta);
                DataSet ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Guardar ", parametro);
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
        public static ObjMensaje Modificar_Captura(DatosCaptura Obj)
        {
            ObjMensaje msg = new();
            try
            {
                List<SqlParameter> parametro = new()
                {
                    new SqlParameter("@FkUsuarioCaptura", SqlDbType.Int) {Value= Obj.FkUsuarioCaptura },
                    new SqlParameter("@Id", SqlDbType.Int) {Value= Obj.Id },
                    new SqlParameter("@Empleado", SqlDbType.Int) {Value= Obj.Empleado },
                    new SqlParameter("@ImporteCredito", SqlDbType.BigInt) { Value = Obj.ImporteCredito },
                    new SqlParameter("@FkPlazo", SqlDbType.Int) { Value = Obj.FkPlazo },
                    new SqlParameter("@FkTipoPago", SqlDbType.Int) { Value = Obj.FkTipoPago },
                    new SqlParameter("@FkBanco", SqlDbType.Int) { Value = Obj.FkBanco },
                    new SqlParameter("@Cuenta", SqlDbType.Int) { Value = Obj.Cuenta },
                    new SqlParameter("@Datos", SqlDbType.VarChar) { Value = Obj.Datos },
                };
                
                DataSet ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Modificar ", parametro);
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
