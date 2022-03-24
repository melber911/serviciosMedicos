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
    public class RcePahDocumentoAdmisionCabAD
    {
        private RcePahDocumentoAdmisionCabE LlenarEntidad(IDataReader dr, RcePahDocumentoAdmisionCabE pRcePahDocumentoAdmisionCabE)
        {
            RcePahDocumentoAdmisionCabE oRcePahDocumentoAdmisionCabE = new RcePahDocumentoAdmisionCabE();
            switch (pRcePahDocumentoAdmisionCabE.Orden)
            {
                case 1:
                    {
                        oRcePahDocumentoAdmisionCabE.IdeDocumentoAdmisionCab = (int) dr["ide_documento_admision_cab"];
                        oRcePahDocumentoAdmisionCabE.DscRpta = (string) dr["dsc_rpta"];
                        break;
                    }
            }
            return oRcePahDocumentoAdmisionCabE;
        }

        public List<RcePahDocumentoAdmisionCabE> Sp_RcePahDocumentoAdmisionCab_Consulta(RcePahDocumentoAdmisionCabE pRcePahDocumentoAdmisionCabE)
        {
            IDataReader dr;
            RcePahDocumentoAdmisionCabE oRcePahDocumentoAdmisionCabE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahDocumentoAdmisionCabE> oListar = new List<RcePahDocumentoAdmisionCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentoAdmisionCab_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_documento_admision_cab", pRcePahDocumentoAdmisionCabE.IdeDocumentoAdmisionCab);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahDocumentoAdmisionCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@orden", pRcePahDocumentoAdmisionCabE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahDocumentoAdmisionCabE = LlenarEntidad(dr, pRcePahDocumentoAdmisionCabE);
                            oListar.Add(oRcePahDocumentoAdmisionCabE);
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

        public bool Sp_RcePahDocumentoAdmisionCab_Insert(RcePahDocumentoAdmisionCabE pRcePahDocumentoAdmisionCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentoAdmisionCab_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahDocumentoAdmisionCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@dsc_texto_documento", pRcePahDocumentoAdmisionCabE.DscTextoDocumento);
                        cmd.Parameters.AddWithValue("@dsc_responsable_envio", pRcePahDocumentoAdmisionCabE.DscRespEnvio);
                        cmd.Parameters.AddWithValue("@dsc_rpta", pRcePahDocumentoAdmisionCabE.DscRpta);
                        cmd.Parameters.AddWithValue("@flg_estado", pRcePahDocumentoAdmisionCabE.FlgEstado);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_documento_admision_cab", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahDocumentoAdmisionCabE.IdeDocumentoAdmisionCab.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRcePahDocumentoAdmisionCabE.IdeDocumentoAdmisionCab = (int)cmd.Parameters["@ide_documento_admision_cab"].Value;
                            return true;
                        }
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

        public bool Sp_RcePahDocumentoAdmisionCab_Update(RcePahDocumentoAdmisionCabE pRcePahDocumentoAdmisionCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentoAdmisionCab_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_paciente", pRcePahDocumentoAdmisionCabE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahDocumentoAdmisionCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@dsc_texto_documento", pRcePahDocumentoAdmisionCabE.DscTextoDocumento);
                        cmd.Parameters.AddWithValue("@dsc_resp_envio", pRcePahDocumentoAdmisionCabE.DscRespEnvio);
                        cmd.Parameters.AddWithValue("@flg_estado", pRcePahDocumentoAdmisionCabE.FlgEstado);
                        cmd.Parameters.AddWithValue("@fec_registro", pRcePahDocumentoAdmisionCabE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_documento_admision_cab", pRcePahDocumentoAdmisionCabE.IdeDocumentoAdmisionCab);
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

        public bool Sp_RcePahDocumentoAdmisionCab_UpdatexCampo(RcePahDocumentoAdmisionCabE pRcePahDocumentoAdmisionCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentoAdmisionCab_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_documento_admision_cab", pRcePahDocumentoAdmisionCabE.IdeDocumentoAdmisionCab);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahDocumentoAdmisionCabE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahDocumentoAdmisionCabE.Campo);
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

        public bool Sp_RcePahDocumentoAdmisionCab_Delete(RcePahDocumentoAdmisionCabE pRcePahDocumentoAdmisionCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentoAdmisionCab_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahDocumentoAdmisionCabE.CodAtencion);
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
