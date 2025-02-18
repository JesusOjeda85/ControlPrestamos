
using ClsObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BaseDatos;
using WebApi.Dto;


namespace WebApi.Repositorio.Consulta
{
    public class RConsulta
    {
        public static ObjMensaje Listar_Empleados(BuscarEmpleado obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new();
            try
            {
                if (obj.Modulo == "P")
                { ds = MetodosBD.EjecutarConsultaEnDataSet("Spt_Consulta_Listar_Empleados '" + obj.Busqueda + "'"); }
                if (obj.Modulo == "R")
                { ds = MetodosBD.EjecutarConsultaEnDataSet("Spt_Consulta_Listar_Empleados_Retiros '" + obj.Busqueda + "'"); }
                if (obj.Modulo == "S")
                { ds = MetodosBD.EjecutarConsultaEnDataSet("Spt_Consulta_Listar_Empleados_Siniestros '" + obj.Busqueda + "'"); }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);

                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
                    msg.Datos = ds.Tables[1].Rows[0][0].ToString();
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No Existe Información";
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

        public static ObjMensaje Listar_NumCreditos(FiltroEmpleado obj)
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("Spt_Consulta_Listar_NumCreditos " + obj.Empleado);
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
                        Cboobj.Qry = ds.Tables[0].Rows[i][2].ToString();
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
                    msg.Mensaje = "No Existe Información";
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

        public static ObjMensaje Listar_DetalleCredito(FiltroIdCredito obj)
        {
            ObjMensaje msg = new();

            try
            {               
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("Spt_Consulta_Listar_DetalleCredito " + obj.Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
                    msg.Datos = "";
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No Existe Información";
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
    }
}
