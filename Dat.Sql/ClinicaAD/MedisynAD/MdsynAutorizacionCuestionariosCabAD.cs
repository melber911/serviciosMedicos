using Ent.Sql.ClinicaE.MedisynE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.MedisynAD
{
    public class MdsynAutorizacionCuestionariosCabAD
    {
        private MdsynAutorizacionCuestionariosCabE LlenarEntidad(IDataReader dr, MdsynAutorizacionCuestionariosCabE pMdsynAutorizacionCuestionariosCabE)
        {
            MdsynAutorizacionCuestionariosCabE oMdsynAutorizacionCuestionariosCabE = new MdsynAutorizacionCuestionariosCabE();
            switch (pMdsynAutorizacionCuestionariosCabE.Orden)
            {
                case 1:
                    {
                        oMdsynAutorizacionCuestionariosCabE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];
                        oMdsynAutorizacionCuestionariosCabE.CodTipoCuestionario = (string) dr["cod_tipo_cuestionario"];
                        oMdsynAutorizacionCuestionariosCabE.CodPaciente = (string) dr["cod_paciente"];
                        oMdsynAutorizacionCuestionariosCabE.CodPacienteTitular = (string) dr["cod_paciente_titular"];
                        oMdsynAutorizacionCuestionariosCabE.DscIpCliente = (string) dr["dsc_ip_cliente"];
                        oMdsynAutorizacionCuestionariosCabE.FecRegistro = (DateTime) dr["fec_registro"];
                        oMdsynAutorizacionCuestionariosCabE.IdeAutorizacionCab = (int) dr["ide_autorizacion_cab"];
                        break;
                    }
            }
            return oMdsynAutorizacionCuestionariosCabE;
        }

        public List<MdsynAutorizacionCuestionariosCabE> Sp_MdsynAutorizacionCuestionariosCab_Consulta(MdsynAutorizacionCuestionariosCabE pMdsynAutorizacionCuestionariosCabE)
        {
            IDataReader dr;
            MdsynAutorizacionCuestionariosCabE oMdsynAutorizacionCuestionariosCabE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MdsynAutorizacionCuestionariosCabE> oListar = new List<MdsynAutorizacionCuestionariosCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosCab_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_cab", pMdsynAutorizacionCuestionariosCabE.IdeAutorizacionCab);
                        cmd.Parameters.AddWithValue("@orden", pMdsynAutorizacionCuestionariosCabE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMdsynAutorizacionCuestionariosCabE = LlenarEntidad(dr, pMdsynAutorizacionCuestionariosCabE);
                            oListar.Add(oMdsynAutorizacionCuestionariosCabE);
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

        public bool Sp_MdsynAutorizacionCuestionariosCab_Insert(MdsynAutorizacionCuestionariosCabE pMdsynAutorizacionCuestionariosCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosCab_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynAutorizacionCuestionariosCabE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@cod_tipo_cuestionario", pMdsynAutorizacionCuestionariosCabE.CodTipoCuestionario);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMdsynAutorizacionCuestionariosCabE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_paciente_titular", pMdsynAutorizacionCuestionariosCabE.CodPacienteTitular);
                        cmd.Parameters.AddWithValue("@dsc_ip_cliente", pMdsynAutorizacionCuestionariosCabE.DscIpCliente);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_autorizacion_cab", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMdsynAutorizacionCuestionariosCabE.IdeAutorizacionCab.ToString()));

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        pMdsynAutorizacionCuestionariosCabE.IdeAutorizacionCab = (int)cmd.Parameters["@ide_autorizacion_cab"].Value;

                        if (pMdsynAutorizacionCuestionariosCabE.IdeAutorizacionCab != 0)
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

        public bool Sp_MdsynAutorizacionCuestionariosCab_Update(MdsynAutorizacionCuestionariosCabE pMdsynAutorizacionCuestionariosCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosCab_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynAutorizacionCuestionariosCabE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@cod_tipo_cuestionario", pMdsynAutorizacionCuestionariosCabE.CodTipoCuestionario);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMdsynAutorizacionCuestionariosCabE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_paciente_titular", pMdsynAutorizacionCuestionariosCabE.CodPacienteTitular);
                        cmd.Parameters.AddWithValue("@dsc_ip_cliente", pMdsynAutorizacionCuestionariosCabE.DscIpCliente);
                        cmd.Parameters.AddWithValue("@fec_registro", pMdsynAutorizacionCuestionariosCabE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_autorizacion_cab", pMdsynAutorizacionCuestionariosCabE.IdeAutorizacionCab);
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

        public bool Sp_MdsynAutorizacionCuestionariosCab_UpdatexCampo(MdsynAutorizacionCuestionariosCabE pMdsynAutorizacionCuestionariosCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosCab_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_cab", pMdsynAutorizacionCuestionariosCabE.IdeAutorizacionCab);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pMdsynAutorizacionCuestionariosCabE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pMdsynAutorizacionCuestionariosCabE.Campo);
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

        public bool Sp_MdsynAutorizacionCuestionariosCab_Delete(MdsynAutorizacionCuestionariosCabE pMdsynAutorizacionCuestionariosCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosCab_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_cab", pMdsynAutorizacionCuestionariosCabE.IdeAutorizacionCab);
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
