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
    public class MdsynVideoLlamadaAD
    {
        private MdsynVideoLlamadaE LlenarEntidad(IDataReader dr, MdsynVideoLlamadaE pMdsynVideollamadaE)
        {
            MdsynVideoLlamadaE oMdsynVideollamadaE = new MdsynVideoLlamadaE();
            switch (pMdsynVideollamadaE.Orden)
            {
                case 1:
                    {
                        oMdsynVideollamadaE.IdecorrelReserva = (int) dr["IdeCorrelReserva"];
                        oMdsynVideollamadaE.FlgTeleConsulta = (string) dr["flg_teleconsulta"];
                        oMdsynVideollamadaE.DscTeleConsulta = (string) dr["dsc_teleconsulta"];
                        break;
                    }
            }
            return oMdsynVideollamadaE;
        }

        public List<MdsynVideoLlamadaE> Sp_MdsynVideoLlamada_Consulta(MdsynVideoLlamadaE pMdsynVideollamadaE)
        {
            IDataReader dr;
            MdsynVideoLlamadaE oMdsynVideollamadaE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MdsynVideoLlamadaE> oListar = new List<MdsynVideoLlamadaE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynVideoLlamada_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@IdeCorrelReserva", pMdsynVideollamadaE.IdecorrelReserva);
                        cmd.Parameters.AddWithValue("@orden", pMdsynVideollamadaE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMdsynVideollamadaE = LlenarEntidad(dr, pMdsynVideollamadaE);
                            oListar.Add(oMdsynVideollamadaE);
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

        public bool Sp_MdsynVideoLlamada_Insert(MdsynVideoLlamadaE pMdsynVideollamadaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynVideoLlamada_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@IdeCorrelReserva", pMdsynVideollamadaE.IdecorrelReserva);
                        cmd.Parameters.AddWithValue("@flg_teleconsulta", pMdsynVideollamadaE.FlgTeleConsulta);
                        cmd.Parameters.AddWithValue("@dsc_url_videollamada", pMdsynVideollamadaE.DscUrlVideollamada);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_videollamada", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMdsynVideollamadaE.IdeVideoLlamada.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pMdsynVideollamadaE.IdeVideoLlamada = (int)cmd.Parameters["@ide_videollamada"].Value;
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

        public bool Sp_MdsynVideollamada_Update(MdsynVideoLlamadaE pMdsynVideollamadaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynVideollamada_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@IdeCorrelReserva", pMdsynVideollamadaE.IdecorrelReserva);
                        cmd.Parameters.AddWithValue("@flg_teleconsulta", pMdsynVideollamadaE.FlgTeleConsulta);
                        cmd.Parameters.AddWithValue("@dsc_url_videollamada", pMdsynVideollamadaE.DscUrlVideollamada);
                        cmd.Parameters.AddWithValue("@fec_registro", pMdsynVideollamadaE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_videollamada", pMdsynVideollamadaE.IdeVideoLlamada);
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

        public bool Sp_MdsynVideollamada_UpdatexCampo(MdsynVideoLlamadaE pMdsynVideollamadaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynVideollamada_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_videollamada", pMdsynVideollamadaE.IdeVideoLlamada);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pMdsynVideollamadaE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pMdsynVideollamadaE.Campo);
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

        public bool Sp_MdsynVideollamada_Delete(MdsynVideoLlamadaE pMdsynVideollamadaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynVideollamada_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_videollamada", pMdsynVideollamadaE.IdeVideoLlamada);
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
