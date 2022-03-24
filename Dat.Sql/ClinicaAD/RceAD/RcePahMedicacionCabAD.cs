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
    public class RcePahMedicacionCabAD
    {
        private RcePahMedicacionCabE LlenarEntidad(IDataReader dr, RcePahMedicacionCabE pRcePahMedicacionCabE)
        {
            RcePahMedicacionCabE oRcePahMedicacionCabE = new RcePahMedicacionCabE();
            switch (pRcePahMedicacionCabE.Orden)
            {
                case 1:
                    {
                        oRcePahMedicacionCabE.CodPaciente = (string) dr["cod_paciente"];
                        oRcePahMedicacionCabE.CodAtencion = (string) dr["cod_atencion"];
                        oRcePahMedicacionCabE.DscRespEnvio = (string) dr["dsc_resp_envio"];
                        oRcePahMedicacionCabE.FlgEstado = (string) dr["flg_estado"];
                        oRcePahMedicacionCabE.FecRegistro = (DateTime) dr["fec_registro"];
                        oRcePahMedicacionCabE.IdeMedicacionCab = (int) dr["ide_medicacion_cab"];
                        break;
                    }
            }
            return oRcePahMedicacionCabE;
        }

        public List<RcePahMedicacionCabE> Sp_RcePahMedicacionCab_Consulta(RcePahMedicacionCabE pRcePahMedicacionCabE)
        {
            IDataReader dr;
            RcePahMedicacionCabE oRcePahMedicacionCabE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahMedicacionCabE> oListar = new List<RcePahMedicacionCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionCab_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_medicacion_cab", pRcePahMedicacionCabE.IdeMedicacionCab);
                        cmd.Parameters.AddWithValue("@orden", pRcePahMedicacionCabE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahMedicacionCabE = LlenarEntidad(dr, pRcePahMedicacionCabE);
                            oListar.Add(oRcePahMedicacionCabE);
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

        public bool Sp_RcePahMedicacionCab_Insert(RcePahMedicacionCabE pRcePahMedicacionCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionCab_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@dsc_resp_envio", pRcePahMedicacionCabE.DscRespEnvio);
                        cmd.Parameters.AddWithValue("@flg_estado", pRcePahMedicacionCabE.FlgEstado);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_medicacion_cab", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahMedicacionCabE.IdeMedicacionCab.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRcePahMedicacionCabE.IdeMedicacionCab = (int)cmd.Parameters["@ide_medicacion_cab"].Value;
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

        public bool Sp_RcePahMedicacionCab_Update(RcePahMedicacionCabE pRcePahMedicacionCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionCab_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_paciente", pRcePahMedicacionCabE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahMedicacionCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@dsc_resp_envio", pRcePahMedicacionCabE.DscRespEnvio);
                        cmd.Parameters.AddWithValue("@flg_estado", pRcePahMedicacionCabE.FlgEstado);
                        cmd.Parameters.AddWithValue("@fec_registro", pRcePahMedicacionCabE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_medicacion_cab", pRcePahMedicacionCabE.IdeMedicacionCab);
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

        public bool Sp_RcePahMedicacionCab_UpdatexCampo(RcePahMedicacionCabE pRcePahMedicacionCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionCab_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_medicacion_cab", pRcePahMedicacionCabE.IdeMedicacionCab);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahMedicacionCabE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahMedicacionCabE.Campo);
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

        public bool Sp_RcePahMedicacionCab_Delete(RcePahMedicacionCabE pRcePahMedicacionCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionCab_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahMedicacionCabE.CodAtencion);
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
