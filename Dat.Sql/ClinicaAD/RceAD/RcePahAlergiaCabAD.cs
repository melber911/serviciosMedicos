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
    public class RcePahAlergiaCabAD
    {
        private RcePahAlergiaCabE LlenarEntidad(IDataReader dr, RcePahAlergiaCabE pRcePahAlergiaCabE)
        {
            RcePahAlergiaCabE oRcePahAlergiaCabE = new RcePahAlergiaCabE();
            switch (pRcePahAlergiaCabE.Orden)
            {
                case 1:
                    {
                        // oRcePahAlergiaCabE.CodAtencion = dr("cod_atencion")
                        oRcePahAlergiaCabE.IdeAlergiaCab = (int) dr["ide_alergia_cab"];
                        oRcePahAlergiaCabE.IndAlergia = (string) dr["ind_alergia"] + "";
                        oRcePahAlergiaCabE.DscHospitalizado = (string) dr["dsc_hospitalizado"];
                        oRcePahAlergiaCabE.DscRepresentante = (string) dr["dsc_representante"];
                        oRcePahAlergiaCabE.DscHabitacion = (string) dr["dsc_habitacion"];
                        oRcePahAlergiaCabE.DscAlimentos = (string) dr["dsc_alimentos"];
                        oRcePahAlergiaCabE.DscOtros = (string) dr["dsc_otros"];

                        oRcePahAlergiaCabE.IdePreAdmision = (int) dr["ide_pre_admision"];
                        oRcePahAlergiaCabE.IdeMedicacionCab = (int) dr["ide_medicacion_cab"];
                        break;
                    }
            }
            return oRcePahAlergiaCabE;
        }

        public List<RcePahAlergiaCabE> Sp_RcePahAlergiaCab_Consulta(RcePahAlergiaCabE pRcePahAlergiaCabE)
        {
            IDataReader dr;
            RcePahAlergiaCabE oRcePahAlergiaCabE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahAlergiaCabE> oListar = new List<RcePahAlergiaCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaCab_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_alergia_cab", pRcePahAlergiaCabE.IdeAlergiaCab);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahAlergiaCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@orden", pRcePahAlergiaCabE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahAlergiaCabE = LlenarEntidad(dr, pRcePahAlergiaCabE);
                            oListar.Add(oRcePahAlergiaCabE);
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

        public bool Sp_RcePahAlergiaCab_Insert(RcePahAlergiaCabE pRcePahAlergiaCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaCab_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pre_admision", pRcePahAlergiaCabE.IdePreAdmision);
                        cmd.Parameters.AddWithValue("@ind_alergia", pRcePahAlergiaCabE.IndAlergia);
                        cmd.Parameters.AddWithValue("@dsc_hospitalizado", pRcePahAlergiaCabE.DscHospitalizado);
                        cmd.Parameters.AddWithValue("@dsc_representante", pRcePahAlergiaCabE.DscRepresentante);
                        cmd.Parameters.AddWithValue("@dsc_habitacion", pRcePahAlergiaCabE.DscHabitacion);
                        cmd.Parameters.AddWithValue("@dsc_alimentos", pRcePahAlergiaCabE.DscAlimentos);
                        cmd.Parameters.AddWithValue("@dsc_otros", pRcePahAlergiaCabE.DscOtros);
                        cmd.Parameters.AddWithValue("@dsc_resp_envio", pRcePahAlergiaCabE.DscRespEnvio);
                        cmd.Parameters.AddWithValue("@flg_estado", pRcePahAlergiaCabE.FlgEstado);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_alergia_cab", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahAlergiaCabE.IdeAlergiaCab.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRcePahAlergiaCabE.IdeAlergiaCab = (int)cmd.Parameters["@ide_alergia_cab"].Value;
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

        public bool Sp_RcePahAlergiaCab_Update(RcePahAlergiaCabE pRcePahAlergiaCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaCab_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_paciente", pRcePahAlergiaCabE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahAlergiaCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@ind_alergia", pRcePahAlergiaCabE.IndAlergia);
                        cmd.Parameters.AddWithValue("@dsc_hospital", pRcePahAlergiaCabE.DscHospitalizado);
                        cmd.Parameters.AddWithValue("@dsc_representante", pRcePahAlergiaCabE.DscRepresentante);
                        cmd.Parameters.AddWithValue("@dsc_habitacion", pRcePahAlergiaCabE.DscHabitacion);
                        cmd.Parameters.AddWithValue("@dsc_alimentos", pRcePahAlergiaCabE.DscAlimentos);
                        cmd.Parameters.AddWithValue("@dsc_otros", pRcePahAlergiaCabE.DscOtros);
                        cmd.Parameters.AddWithValue("@dsc_resp_envio", pRcePahAlergiaCabE.DscRespEnvio);
                        cmd.Parameters.AddWithValue("@flg_estado", pRcePahAlergiaCabE.FlgEstado);
                        cmd.Parameters.AddWithValue("@fec_registro", pRcePahAlergiaCabE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_alergia_cab", pRcePahAlergiaCabE.IdeAlergiaCab);
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

        public bool Sp_RcePahAlergiaCab_UpdatexCampo(RcePahAlergiaCabE pRcePahAlergiaCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaCab_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_alergia_cab", pRcePahAlergiaCabE.IdeAlergiaCab);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahAlergiaCabE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahAlergiaCabE.Campo);
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

        public bool Sp_RcePahAlergiaCab_Delete(RcePahAlergiaCabE pRcePahAlergiaCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaCab_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahAlergiaCabE.CodAtencion);
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
