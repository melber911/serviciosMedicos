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
    public class RcePahAlergiaMedicamentosDetAD
    {
        private RcePahAlergiaMedicamentosDetE LlenarEntidad(IDataReader dr, RcePahAlergiaMedicamentosDetE pRcePahAlergiaMedicamentosDetE)
        {
            RcePahAlergiaMedicamentosDetE oRcePahAlergiaMedicamentosDetE = new RcePahAlergiaMedicamentosDetE();
            switch (pRcePahAlergiaMedicamentosDetE.Orden)
            {
                case 1:
                    {
                        oRcePahAlergiaMedicamentosDetE.IdeAlergiaMedicamentosDet = (int) dr["ide_alergia_medicamentos_det"];
                        oRcePahAlergiaMedicamentosDetE.IdeAlergiaCab = (int) dr["ide_alergia_cab"];
                        oRcePahAlergiaMedicamentosDetE.CodGenerico = (string) dr["cod_generico"];
                        oRcePahAlergiaMedicamentosDetE.DscMedicamento = (string) dr["dsc_medicamento"];
                        break;
                    }
            }
            return oRcePahAlergiaMedicamentosDetE;
        }

        public List<RcePahAlergiaMedicamentosDetE> Sp_RcePahAlergiaMedicamentosDet_Consulta(RcePahAlergiaMedicamentosDetE pRcePahAlergiaMedicamentosDetE)
        {
            IDataReader dr;
            RcePahAlergiaMedicamentosDetE oRcePahAlergiaMedicamentosDetE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahAlergiaMedicamentosDetE> oListar = new List<RcePahAlergiaMedicamentosDetE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaMedicamentosDet_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_alergia_medicamentos_det", pRcePahAlergiaMedicamentosDetE.IdeAlergiaMedicamentosDet);
                        cmd.Parameters.AddWithValue("@ide_alergia_cab", pRcePahAlergiaMedicamentosDetE.IdeAlergiaCab);
                        cmd.Parameters.AddWithValue("@orden", pRcePahAlergiaMedicamentosDetE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahAlergiaMedicamentosDetE = LlenarEntidad(dr, pRcePahAlergiaMedicamentosDetE);
                            oListar.Add(oRcePahAlergiaMedicamentosDetE);
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

        public bool Sp_RcePahAlergiaMedicamentosDet_Insert(RcePahAlergiaMedicamentosDetE pRcePahAlergiaMedicamentosDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaMedicamentosDet_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_alergia_cab", pRcePahAlergiaMedicamentosDetE.IdeAlergiaCab);
                        cmd.Parameters.AddWithValue("@cod_generico", pRcePahAlergiaMedicamentosDetE.CodGenerico);
                        cmd.Parameters.AddWithValue("@dsc_medicamento", pRcePahAlergiaMedicamentosDetE.DscMedicamento);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_alergia_medicamentos_det", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahAlergiaMedicamentosDetE.IdeAlergiaMedicamentosDet.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRcePahAlergiaMedicamentosDetE.IdeAlergiaMedicamentosDet = (int)cmd.Parameters["@ide_alergia_medicamentos_det"].Value;
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

        public bool Sp_RcePahAlergiaMedicamentosDet_Update(RcePahAlergiaMedicamentosDetE pRcePahAlergiaMedicamentosDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaMedicamentosDet_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_alergia_cab", pRcePahAlergiaMedicamentosDetE.IdeAlergiaCab);
                        cmd.Parameters.AddWithValue("@dsc_medicamento", pRcePahAlergiaMedicamentosDetE.DscMedicamento);
                        cmd.Parameters.AddWithValue("@fec_registro", pRcePahAlergiaMedicamentosDetE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_alergia_medicamentos_det", pRcePahAlergiaMedicamentosDetE.IdeAlergiaMedicamentosDet);
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

        public bool Sp_RcePahAlergiaMedicamentosDet_UpdatexCampo(RcePahAlergiaMedicamentosDetE pRcePahAlergiaMedicamentosDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaMedicamentosDet_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_alergia_medicamentos_det", pRcePahAlergiaMedicamentosDetE.IdeAlergiaMedicamentosDet);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahAlergiaMedicamentosDetE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahAlergiaMedicamentosDetE.Campo);
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

        public bool Sp_RcePahAlergiaMedicamentosDet_Delete(RcePahAlergiaMedicamentosDetE pRcePahAlergiaMedicamentosDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAlergiaMedicamentosDet_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_alergia_medicamentos_det", pRcePahAlergiaMedicamentosDetE.IdeAlergiaMedicamentosDet);
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
