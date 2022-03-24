using Ent.Sql.ClinicaE.HospitalE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.HospitalAD
{
    public class HospitalAD
    {
        private HospitalE LlenarEntidad(IDataReader dr, HospitalE pHospitalE)
        {
            HospitalE oHospitalE = new HospitalE();
            switch (pHospitalE.Orden)
            {
                case 1:
                    {
                        oHospitalE.CodAtencion = (string) dr["codatencion"];
                        oHospitalE.CodPaciente = (string) dr["codpaciente"];
                        oHospitalE.Tipoingreso = (string) dr["tipoingreso"];
                        oHospitalE.Tipoegreso = (string) dr["tipoegreso"];
                        oHospitalE.Activo = (string) dr["activo"];
                        oHospitalE.CodDiagnostico = (string) dr["coddiagnostico"];
                        oHospitalE.Fechainicio = (DateTime) dr["fechainicio"];
                        oHospitalE.Fechafin = (DateTime) dr["fechafin"];
                        oHospitalE.Codmedico = (string) dr["codmedico"];
                        oHospitalE.Tipomedico = (string) dr["tipomedico"];
                        oHospitalE.Cama = (string) dr["cama"];
                        oHospitalE.Codpoliza = (string) dr["codpoliza"];
                        oHospitalE.Planpoliza = (string) dr["planpoliza"];
                        oHospitalE.Codaseguradora = (string) dr["codaseguradora"];
                        oHospitalE.Titular = (string) dr["titular"];
                        oHospitalE.Quirofano = (bool) dr["quirofano"];
                        oHospitalE.Codcia = (string) dr["codcia"];
                        oHospitalE.Quiencreoregistro = (string) dr["quiencreoregistro"];
                        oHospitalE.Quienmodificoregistro = (string) dr["quienmodificoregistro"];
                        oHospitalE.Estado = (string) dr["estado"];
                        oHospitalE.Familiar = (string) dr["familiar"];
                        oHospitalE.Gestante = (string) dr["gestante"];
                        oHospitalE.Fur = (DateTime) dr["fur"];
                        oHospitalE.Fechaaltamedica = (DateTime) dr["fechaaltamedica"];
                        oHospitalE.Vaseguradora = (double) dr["vaseguradora"];
                        oHospitalE.Vpaciente = (double) dr["vpaciente"];
                        oHospitalE.Vcontratante = (double) dr["vcontratante"];
                        oHospitalE.Quieneliminoregistro = (string) dr["quieneliminoregistro"];
                        oHospitalE.UsrAltamedica = (int) dr["usr_altamedica"];
                        oHospitalE.UsrAltaadministrativa = (int) dr["usr_altaadministrativa"];
                        oHospitalE.FecAltaadministrativa = (DateTime) dr["fec_altaadministrativa"];
                        break;
                    }

                case 14:
                    {
                        oHospitalE.CodPaciente = (string) dr["codpaciente"];
                        oHospitalE.TipoAtencion = (string) dr["tipo"];
                        oHospitalE.FlagCorreo = (string) dr["flagcorreo"];
                        oHospitalE.Nombres = (string) dr["nombres"];
                        oHospitalE.ApellidoPat = (string) dr["apellido_pat"];
                        oHospitalE.CodTipo = (string) dr["codtipo"];
                        oHospitalE.Correo = (string) dr["correo"];
                        oHospitalE.NombresPaciente = (string) dr["nombres_paciente"];
                        break;
                    }

                case 15:
                    {
                        oHospitalE.CodAtencion = (string) dr["codatencion"] + "";
                        oHospitalE.CodPaciente = (string) dr["codpaciente"] + "";
                        oHospitalE.NombresPaciente = (string) dr["nombres"] + "";
                        oHospitalE.Correo = (string) dr["email"] + "";
                        oHospitalE.Telefono = (string) dr["telefono"] + "";
                        oHospitalE.Telefono1 = (string) dr["telefono1"] + "";
                        break;
                    }
            }
            return oHospitalE;
        }

        public List<HospitalE> Sp_Hospital_Consulta(HospitalE pHospitalE)
        {
            IDataReader dr;
            List<HospitalE> oListar = new List<HospitalE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Hospital_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@buscar", pHospitalE.Buscar);
                        cmd.Parameters.AddWithValue("@key", pHospitalE.Key);
                        cmd.Parameters.AddWithValue("@numerolineas", pHospitalE.NumeroLineas);
                        cmd.Parameters.AddWithValue("@orden", pHospitalE.Orden);
                        cmd.Parameters.AddWithValue("@tipoatencion", pHospitalE.TipoAtencion);
                        cmd.Parameters.AddWithValue("@activo", pHospitalE.Activo);
                        cmd.Parameters.AddWithValue("@filtrolocal", pHospitalE.FiltroLocal);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            HospitalE oHospitalE = LlenarEntidad(dr, pHospitalE);
                            oListar.Add(oHospitalE);
                        }

                        dr.Close(); // Se cierre la conexión.
                        dr.Dispose(); // Se liberan todos los recursos del data reader.
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Hospital_Insert(HospitalE pHospitalE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Hospital_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pHospitalE.CodAtencion);
                        cmd.Parameters.AddWithValue("@codpaciente", pHospitalE.CodPaciente);
                        cmd.Parameters.AddWithValue("@tipoingreso", pHospitalE.Tipoingreso);
                        cmd.Parameters.AddWithValue("@tipoegreso", pHospitalE.Tipoegreso);
                        cmd.Parameters.AddWithValue("@activo", pHospitalE.Activo);
                        cmd.Parameters.AddWithValue("@coddiagnostico", pHospitalE.CodDiagnostico);
                        cmd.Parameters.AddWithValue("@fechainicio", pHospitalE.Fechainicio);
                        cmd.Parameters.AddWithValue("@fechafin", pHospitalE.Fechafin);
                        cmd.Parameters.AddWithValue("@codmedico", pHospitalE.Codmedico);
                        cmd.Parameters.AddWithValue("@tipomedico", pHospitalE.Tipomedico);
                        cmd.Parameters.AddWithValue("@cama", pHospitalE.Cama);
                        cmd.Parameters.AddWithValue("@codpoliza", pHospitalE.Codpoliza);
                        cmd.Parameters.AddWithValue("@planpoliza", pHospitalE.Planpoliza);
                        cmd.Parameters.AddWithValue("@codaseguradora", pHospitalE.Codaseguradora);
                        cmd.Parameters.AddWithValue("@titular", pHospitalE.Titular);
                        cmd.Parameters.AddWithValue("@quirofano", pHospitalE.Quirofano);
                        cmd.Parameters.AddWithValue("@codcia", pHospitalE.Codcia);
                        cmd.Parameters.AddWithValue("@quiencreoregistro", pHospitalE.Quiencreoregistro);
                        cmd.Parameters.AddWithValue("@quienmodificoregistro", pHospitalE.Quienmodificoregistro);
                        cmd.Parameters.AddWithValue("@estado", pHospitalE.Estado);
                        cmd.Parameters.AddWithValue("@familiar", pHospitalE.Familiar);
                        cmd.Parameters.AddWithValue("@gestante", pHospitalE.Gestante);
                        cmd.Parameters.AddWithValue("@fur", pHospitalE.Fur);
                        cmd.Parameters.AddWithValue("@fechaaltamedica", pHospitalE.Fechaaltamedica);
                        cmd.Parameters.AddWithValue("@vaseguradora", pHospitalE.Vaseguradora);
                        cmd.Parameters.AddWithValue("@vpaciente", pHospitalE.Vpaciente);
                        cmd.Parameters.AddWithValue("@vcontratante", pHospitalE.Vcontratante);
                        cmd.Parameters.AddWithValue("@quieneliminoregistro", pHospitalE.Quieneliminoregistro);
                        cmd.Parameters.AddWithValue("@usr_altamedica", pHospitalE.UsrAltamedica);
                        cmd.Parameters.AddWithValue("@usr_altaadministrativa", pHospitalE.UsrAltaadministrativa);
                        cmd.Parameters.AddWithValue("@fec_altaadministrativa", pHospitalE.FecAltaadministrativa);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else
                            return false;
                        cnn.Close();
                        cmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Hospital_Insert1(HospitalE pHospitalE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Hospital_Insert1", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codpaciente", pHospitalE.CodPaciente);
                        cmd.Parameters.AddWithValue("@tipoatencion", pHospitalE.TipoAtencion);
                        cmd.Parameters.AddWithValue("@codusuario", pHospitalE.CodUser);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codigo", ParameterDirection.Output, SqlDbType.VarChar, 8, pHospitalE.CodAtencion));

                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pHospitalE.CodAtencion = (string)cmd.Parameters["@codigo"].Value;
                            return true;
                        }
                        else
                            return false;

                        cmd.Dispose(); // Se liberan todos los recursos de la 
                        cnn.Close(); // Se cierre la conexión
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Hospital_Insert_App(HospitalE pHospitalE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Hospital_Insert_App", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codpaciente", pHospitalE.CodPaciente);
                        cmd.Parameters.AddWithValue("@tipoatencion", pHospitalE.TipoAtencion);
                        cmd.Parameters.AddWithValue("@codusuario", pHospitalE.CodUser);
                        cmd.Parameters.AddWithValue("@codsedelocal", pHospitalE.CodSede);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codigo", ParameterDirection.Output, SqlDbType.VarChar, 8, pHospitalE.CodAtencion));

                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pHospitalE.CodAtencion = (string)cmd.Parameters["@codigo"].Value;
                            return true;
                        }
                        else
                            return false;

                        cmd.Dispose(); // Se liberan todos los recursos de la 
                        cnn.Close(); // Se cierre la conexión
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Hospital_Update(HospitalE pHospitalE)
        {
            bool xResult = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Hospital_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codigo", pHospitalE.CodAtencion);
                        cmd.Parameters.AddWithValue("@campo", pHospitalE.Campo);
                        cmd.Parameters.AddWithValue("@nuevovalor", pHospitalE.NuevoValor);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        xResult = true;

                        cnn.Close();
                        cmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return xResult;
        }

        public bool Sp_Hospital_Delete(HospitalE pHospitalE)
        {
            bool xResult = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Hospital_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@return", "").Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.AddWithValue("@codatencion", pHospitalE.CodAtencion);
                        cmd.Parameters.AddWithValue("@accion", pHospitalE.Orden);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        xResult = true;
                        cnn.Close();
                        cmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return xResult;
        }

        // 
        public DataSet Sp_ConsultarDatosHospitalarios(HospitalE pHospitalE)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_ConsultarDatosHospitalarios", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_paciente", pHospitalE.CodPaciente);
                        cnn.Open();

                        SqlDataAdapter oda = new SqlDataAdapter(cmd);
                        oda.Fill(ds);

                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.

                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
