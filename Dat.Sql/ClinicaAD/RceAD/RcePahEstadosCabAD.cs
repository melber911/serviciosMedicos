using Ent.Sql.ClinicaE.RceE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.RceAD
{
    public class RcePahEstadosCabAD
    {
        private RcePahEstadosCabE LlenarEntidad(IDataReader dr, RcePahEstadosCabE pRcePahEstadosCabE)
        {
            RcePahEstadosCabE oRcePahEstadosCabE = new RcePahEstadosCabE();
            switch (pRcePahEstadosCabE.Orden)
            {
                case 1:
                    {
                        // oRcePahEstadosCabE.CodPaciente = dr("cod_paciente") 
                        oRcePahEstadosCabE.CodAtencion = (string) dr["cod_atencion"];
                        oRcePahEstadosCabE.FecEnvio = (string) dr["fec_envio"];
                        oRcePahEstadosCabE.UsrEnvio = (string) dr["usr_envio"];

                        oRcePahEstadosCabE.IdePreAdmision = (int) dr["ide_pre_admision"];
                        oRcePahEstadosCabE.IdeAlergiaCab = (int) dr["ide_alergia_cab"];
                        oRcePahEstadosCabE.IdeMedicacionCab = (int) dr["ide_medicacion_cab"];
                        oRcePahEstadosCabE.IdeDocumentoAdmisionCab = (int) dr["ide_documento_admision_cab"];
                        oRcePahEstadosCabE.IdeAutorizacionPrefacturasCab = (int) dr["ide_autorizacion_prefacturas_cab"];

                        oRcePahEstadosCabE.DscPacientes = (string) dr["dsc_paciente"];
                        oRcePahEstadosCabE.IdePreAdmision = (int) dr["ide_pre_admision"];

                        oRcePahEstadosCabE.DscSecuencia = (string) dr["dsc_secuencia"];
                        oRcePahEstadosCabE.IdeCorreoEnviado = (int) dr["ide_correo_enviado"];

                        oRcePahEstadosCabE.FechaCirugia = (string) dr["fec_cirugia"];

                        oRcePahEstadosCabE.CodAtencionNueva = (string) dr["cod_atencion_nueva"];
                        break;
                    }

                case 3:
                    {
                        oRcePahEstadosCabE.CodAtencion = (string) dr["cod_atencion"];
                        oRcePahEstadosCabE.CodEnvioCorreo = (string) dr["cod_envio_correo"];
                        break;
                    }
            }
            return oRcePahEstadosCabE;
        }

        public List<RcePahEstadosCabE> Sp_RcePahEstadosCab_Consulta(RcePahEstadosCabE pRcePahEstadosCabE)
        {
            IDataReader dr;
            RcePahEstadosCabE oRcePahEstadosCabE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahEstadosCabE> oListar = new List<RcePahEstadosCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahEstadosCab_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pre_admision", pRcePahEstadosCabE.IdePreAdmision);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahEstadosCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@doc_identidad", pRcePahEstadosCabE.DocIdentidad);
                        cmd.Parameters.AddWithValue("@dsc_pacientes", pRcePahEstadosCabE.DscPacientes);
                        cmd.Parameters.AddWithValue("@fec_inicio", pRcePahEstadosCabE.FecInicio);
                        cmd.Parameters.AddWithValue("@fec_fin", pRcePahEstadosCabE.FecFin);
                        cmd.Parameters.AddWithValue("@orden", pRcePahEstadosCabE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahEstadosCabE = LlenarEntidad(dr, pRcePahEstadosCabE);
                            oListar.Add(oRcePahEstadosCabE);
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

        public bool Sp_RcePahEstadosCab_Insert(RcePahEstadosCabE pRcePahEstadosCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahEstadosCab_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_paciente", pRcePahEstadosCabE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahEstadosCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@accion", pRcePahEstadosCabE.Accion);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_pre_admision", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahEstadosCabE.IdePreAdmision.ToString()));
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        pRcePahEstadosCabE.IdePreAdmision = (int)cmd.Parameters["@ide_pre_admision"].Value;

                        if (pRcePahEstadosCabE.IdePreAdmision >= 1)
                            return true;
                        else
                            return false;
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_RcePahEstadosCab_Update(RcePahEstadosCabE pRcePahEstadosCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahEstadosCab_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_paciente", pRcePahEstadosCabE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahEstadosCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@num_secuencia", pRcePahEstadosCabE.NumSecuencia);
                        cmd.Parameters.AddWithValue("@est_secuencia", pRcePahEstadosCabE.EstSecuencia);
                        cmd.Parameters.AddWithValue("@ide_alergia_cab", pRcePahEstadosCabE.IdeAlergiaCab);
                        cmd.Parameters.AddWithValue("@ide_medicacion_cab", pRcePahEstadosCabE.IdeMedicacionCab);
                        cmd.Parameters.AddWithValue("@fec_alergia_medicacion", pRcePahEstadosCabE.FecAlergiaMedicacion);
                        cmd.Parameters.AddWithValue("@ide_documento_admision_cab", pRcePahEstadosCabE.IdeDocumentoAdmisionCab);
                        cmd.Parameters.AddWithValue("@fec_documento_admision", pRcePahEstadosCabE.FecDocumentoAdmision);
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_cab", pRcePahEstadosCabE.IdeAutorizacionPrefacturasCab);
                        cmd.Parameters.AddWithValue("@fec_autorizacion_prefacturas", pRcePahEstadosCabE.FecAutorizacionPrefacturas);
                        cmd.Parameters.AddWithValue("@flg_estado", pRcePahEstadosCabE.FlgEstado);
                        cmd.Parameters.AddWithValue("@fec_registro", pRcePahEstadosCabE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_pre_admision", pRcePahEstadosCabE.IdePreAdmision);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else
                            return false;
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_RcePahEstadosCab_UpdatexCampo(RcePahEstadosCabE pRcePahEstadosCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahEstadosCab_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pre_admision", pRcePahEstadosCabE.IdePreAdmision);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahEstadosCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahEstadosCabE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahEstadosCabE.Campo);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else
                            return false;
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_RcePahEstadosCab_Delete(RcePahEstadosCabE pRcePahEstadosCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahEstadosCab_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pre_admision", pRcePahEstadosCabE.IdePreAdmision);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else
                            return false;
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
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
