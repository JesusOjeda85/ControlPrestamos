
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

        public static ObjMensaje Listar_Plazos(IdOrganismoDto obj)
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
                        Cboobj.Qry= ds.Tables[0].Rows[i][2].ToString();

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
        public static ObjMensaje Listar_MotivosBajas()
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_MotivosBajas ");
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
                       // Cboobj.Qry = ds.Tables[0].Rows[i][2].ToString();

                        //if (i == 0) { Cboobj.selected = true; }
                        //else
                        //{ Cboobj.selected = false; }
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
        public static ObjMensaje Listar_CausasMuerte()
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_CausasMuerte");
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
                        // Cboobj.Qry = ds.Tables[0].Rows[i][2].ToString();

                        //if (i == 0) { Cboobj.selected = true; }
                        //else
                        //{ Cboobj.selected = false; }
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
        public static ObjMensaje Listar_ConceptosSiniestros()
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_ConceptosSiniestros");
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
                        // Cboobj.Qry = ds.Tables[0].Rows[i][2].ToString();

                        //if (i == 0) { Cboobj.selected = true; }
                        //else
                        //{ Cboobj.selected = false; }
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
        public static ObjMensaje Listar_ImportesPlazos(IdOrganismoDto obj)
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstimportes = new();
            List<ObjComboBox> lstplazos = new();
            List<object> lista = new(); 
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Catalogos_Listar_ImportesOtorgados " + obj.FkOrganismo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Cboobj = new ObjComboBox();
                    Cboobj.valor = "x";
                    Cboobj.descripcion = "Seleccione una Opción";
                    Cboobj.selected = true;
                    lstimportes.Add(Cboobj);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Cboobj = new ObjComboBox();
                        Cboobj.valor = ds.Tables[0].Rows[i][0].ToString();
                        Cboobj.descripcion = ds.Tables[0].Rows[i][0].ToString();                       
                        lstimportes.Add(Cboobj);
                    }
                    lista.Add(lstimportes);
                }
                if (ds.Tables[1].Rows.Count > 0)
                {                   
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        Cboobj = new ObjComboBox();
                        Cboobj.valor = ds.Tables[1].Rows[i][0].ToString();
                        Cboobj.descripcion = ds.Tables[1].Rows[i][1].ToString();
                        Cboobj.Qry= ds.Tables[1].Rows[i][2].ToString();

                        if (i == 0) { Cboobj.selected = true; }
                        else
                        { Cboobj.selected = false; }
                        lstplazos.Add(Cboobj);
                    }
                    lista.Add(lstplazos);
                }
                msg.Error = 0;
                msg.Mensaje = "";
                msg.Data = lista;
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }
        public static ObjMensaje Listar_ConceptosPorPuesto(IdTipoPuestoDto obj)
        {
            ObjComboBox Cboobj = new();
            ObjMensaje msg = new();
            List<ObjComboBox> lstcat = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Captura_Listar_ConceptosPorPuesto " + obj.FkTipopuesto);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Cboobj = new ObjComboBox();
                    Cboobj.valor = "x";
                    Cboobj.descripcion = "Seleccione una Opción";
                    Cboobj.Qry = "";
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
                }
                
                msg.Error = 0;
                msg.Mensaje = "";
                msg.Data = lstcat;
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
            DataSet ds = new();
            try
            {
                List<SqlParameter> parametro = new()
                {
                     new SqlParameter("@idusuario", SqlDbType.Int) {Value= obj.IdUsuario },
                     new SqlParameter("@fkconcepto", SqlDbType.Int) {Value= obj.FkConcepto },
                     new SqlParameter("@fkorganismo", SqlDbType.Int) {Value= obj.FkOrganismo },
                     new SqlParameter("@Busqueda", SqlDbType.VarChar,50) {Value= obj.Busqueda },
                };
               
                 ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Buscar_Empleado ", parametro); 
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
                    msg.Datos = ds.Tables[0].Rows.Count.ToString();
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
                DataSet ds = new DataSet();
                List <SqlParameter> parametro = new()
                {
                    new SqlParameter("@Id", SqlDbType.Int) {Value= Obj.Id },
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
                    new SqlParameter("@ImporteCredito", SqlDbType.Float) { Value = Obj.ImporteCredito },
                    new SqlParameter("@FkPlazo", SqlDbType.Int) { Value = Obj.FkPlazo },
                    new SqlParameter("@PlazoQnas", SqlDbType.Int) { Value = Obj.PlazoQnas },
                    new SqlParameter("@FkTipoPago", SqlDbType.Int) { Value = Obj.FkTipoPago },
                    new SqlParameter("@FkTipoPuesto", SqlDbType.Int) { Value = Obj.FkTipoPuesto },
                    new SqlParameter("@FkBanco", SqlDbType.Int) { Value = Obj.FkBanco },
                    new SqlParameter("@Cuenta", SqlDbType.Int) { Value = Obj.Cuenta },
                    new SqlParameter("@FkZonaPago", SqlDbType.Int) { Value = Obj.FkZonaPago },
                };

                if (Obj.Id == 0)
                { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Guardar ", parametro); }
                else { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Actualizar ", parametro); } 

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



        public static ObjMensaje Eliminar_Captura(DatosCaptura Obj)
        {
            ObjMensaje msg = new();
            try
            {
                List<SqlParameter> parametro = new()
                {
                    new SqlParameter("@FkUsuarioCaptura", SqlDbType.Int) {Value= Obj.FkUsuarioCaptura },
                    new SqlParameter("@Id", SqlDbType.Int) {Value= Obj.Id },
                    new SqlParameter("@Empleado", SqlDbType.Int) {Value= Obj.Empleado },
                    new SqlParameter("@Rfc", SqlDbType.VarChar, 20) { Value = Obj.Rfc },
                    new SqlParameter("@Modulo", SqlDbType.VarChar) {Value= Obj.Datos },
                };

                DataSet ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Eliminar ", parametro);
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

        
        public static ObjMensaje Guardar_Cancelaciones(DatosCancelaciones Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new();
            try
            {
                List<SqlParameter> parametro = new()
                {
                    new SqlParameter("@Id", SqlDbType.Int) {Value= Obj.Id },      
                    new SqlParameter("@FecCaptura", SqlDbType.VarChar) { Value = Obj.FecCaptura },
                    new SqlParameter("@Observacion", SqlDbType.VarChar) { Value = Obj.Observaciones },                    
                };

                if (Obj.Modulo == "P")
                { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Cancelar ", parametro); }
                if (Obj.Modulo == "R")
                { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Cancelar_R ", parametro); }
                if (Obj.Modulo == "S")
                { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Cancelar_S ", parametro); }

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


        public static ObjMensaje Guardar_PagosExternos(DatosPagosExternos Obj)
        {
            ObjMensaje msg = new();
            try
            {
                List<SqlParameter> parametro = new()
                {
                    new SqlParameter("@Id", SqlDbType.Int) {Value= Obj.Id },
                    new SqlParameter("@Importe", SqlDbType.Float) { Value = Obj.Importe },
                    new SqlParameter("@FecCaptura", SqlDbType.VarChar) { Value = Obj.FecCaptura },
                    new SqlParameter("@Observacion", SqlDbType.VarChar) { Value = Obj.Observaciones },
                };

                DataSet ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_PagosExternos ", parametro);
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


        public static ObjMensaje Buscar_Retiros_Siniestros(BuscarEmpleado obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new();
            try
            {
                List<SqlParameter> parametro = new()
                {
                     new SqlParameter("@IdUsuario", SqlDbType.Int) {Value= obj.IdUsuario },                  
                     new SqlParameter("@Busqueda", SqlDbType.VarChar,50) {Value= obj.Busqueda },
                };
                
                if (obj.Modulo == "R")
                { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Buscar_Retiros ", parametro); }
                if (obj.Modulo == "S")
                { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Buscar_Siniestros ", parametro); }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
                    msg.Datos = ds.Tables[0].Rows.Count.ToString();
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


        public static ObjMensaje Guardar_Captura_Retiros(DatosCapturaRetiros Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> parametro = new()
                {
                     new SqlParameter("@Id", SqlDbType.Int) {Value= Obj.Id },
                    new SqlParameter("@Rfc", SqlDbType.VarChar, 20) { Value = Obj.Rfc },
                     new SqlParameter("@ApPaterno", SqlDbType.VarChar, 100) { Value = Obj.ApPaterno },
                    new SqlParameter("@ApMaterno", SqlDbType.VarChar, 100) { Value = Obj.ApMaterno },
                    new SqlParameter("@Nombres", SqlDbType.VarChar, 100) { Value = Obj.Nombres },
                    new SqlParameter("@FkTipoPuesto", SqlDbType.Int) { Value = Obj.FkTipoPuesto },
                    new SqlParameter("@FkMotivoBaja", SqlDbType.Int) { Value = Obj.FkMotivoBaja },
                     new SqlParameter("@ImporteBruto", SqlDbType.Float) { Value = Obj.ImporteBruto },
                     new SqlParameter("@ImporteAdeudo", SqlDbType.Float) { Value = Obj.ImporteAdeudo },
                     new SqlParameter("@ImporteNeto", SqlDbType.Float) { Value = Obj.ImporteNeto },
                       new SqlParameter("@FkTipoPago", SqlDbType.Int) { Value = Obj.FkTipoPago },
                    new SqlParameter("@FkBanco", SqlDbType.Int) { Value = Obj.FkBanco },
                      new SqlParameter("@Cuenta", SqlDbType.Int) { Value = Obj.Cuenta },
                      new SqlParameter("@FechaSolicitud", SqlDbType.VarChar, 11) { Value = Obj.FechaSolicitud },
                       new SqlParameter("@FkOrganismo", SqlDbType.Int) { Value = Obj.FkOrganismo },
                        new SqlParameter("@FkUsuarioCaptura", SqlDbType.Int) {Value= Obj.FkUsuarioCaptura },
                    new SqlParameter("@FkZonaPago", SqlDbType.Int) { Value = Obj.FkZonaPago },
                    new SqlParameter("@TipoProceso", SqlDbType.VarChar, 1) { Value = Obj.TipoProceso },
                };

                
                 
                if (Obj.Id == 0)
                { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_GuardarRetiros ", parametro); }
                else{ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_ActualizarRetiros ", parametro);
            }
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

        public static ObjMensaje Guardar_Captura_Siniestros(DatosCapturaSiniestros Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new ();
            try
            {
                List<SqlParameter> parametro = new()
                {
                     new SqlParameter("@Id", SqlDbType.Int) {Value= Obj.Id },
                    new SqlParameter("@Rfc", SqlDbType.VarChar, 20) { Value = Obj.Rfc },
                     new SqlParameter("@ApPaterno", SqlDbType.VarChar, 100) { Value = Obj.ApPaterno },
                    new SqlParameter("@ApMaterno", SqlDbType.VarChar, 100) { Value = Obj.ApMaterno },
                    new SqlParameter("@Nombres", SqlDbType.VarChar, 100) { Value = Obj.Nombres },
                    new SqlParameter("@FkTipoPuesto", SqlDbType.Int) { Value = Obj.FkTipoPuesto },
                    new SqlParameter("@Beneficiario", SqlDbType.VarChar, 500) { Value = Obj.Beneficiario },
                    new SqlParameter("@FkCausaMuerte", SqlDbType.Int) { Value = Obj.FkCausaMuerte },
                    new SqlParameter("@FkConceptoSiniestro", SqlDbType.Int) { Value = Obj.FkConceptoSiniestro },
                     new SqlParameter("@ImporteBruto", SqlDbType.Float) { Value = Obj.ImporteBruto },
                     new SqlParameter("@ImporteAdeudo", SqlDbType.Float) { Value = Obj.ImporteAdeudo },
                     new SqlParameter("@ImporteNeto", SqlDbType.Float) { Value = Obj.ImporteNeto },
                       new SqlParameter("@FkTipoPago", SqlDbType.Int) { Value = Obj.FkTipoPago },
                    new SqlParameter("@FkBanco", SqlDbType.Int) { Value = Obj.FkBanco },
                      new SqlParameter("@Cuenta", SqlDbType.Int) { Value = Obj.Cuenta },
                      new SqlParameter("@FechaSolicitud", SqlDbType.VarChar, 11) { Value = Obj.FechaSolicitud },
                       new SqlParameter("@FkOrganismo", SqlDbType.Int) { Value = Obj.FkOrganismo },
                        new SqlParameter("@FkUsuarioCaptura", SqlDbType.Int) {Value= Obj.FkUsuarioCaptura },
                    new SqlParameter("@FkZonaPago", SqlDbType.Int) { Value = Obj.FkZonaPago },
                       new SqlParameter("@TipoProceso", SqlDbType.VarChar, 1) { Value = Obj.TipoProceso },
                };

                if (Obj.Id == 0)
                { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_GuardarSiniestros ", parametro); }
                else { ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_ActualizarSiniestros ", parametro); }

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

        public static ObjMensaje Listar_Revision_Captura(DatosNumeracion Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new DataSet();
            try
            {               
                if (Obj.Modulo == "R") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Captura_Listar_RevisionCaptura_Retiros "); }
                if (Obj.Modulo == "S") { ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Captura_Listar_RevisionCaptura_Siniestros"); }
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
    }
}
