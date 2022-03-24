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
    public class RcePahRequestJsonAD
    {
        private RcePahRequestJsonE LlenarEntidad(IDataReader dr, RcePahRequestJsonE pRcePahRequestJsonE)
        {
            RcePahRequestJsonE oRcePahRequestJsonE = new RcePahRequestJsonE();
            switch (pRcePahRequestJsonE.Orden)
            {
                case 1:
                    {
                        oRcePahRequestJsonE.IdePahEstadosCab = (int) dr["ide_pah_estados_cab"];
                        oRcePahRequestJsonE.DscPlataforma = (string) dr["dsc_plataforma"];
                        oRcePahRequestJsonE.DscJson = (string) dr["dsc_json"];
                        oRcePahRequestJsonE.FecJson = (DateTime) dr["fec_json"];
                        oRcePahRequestJsonE.IdePahRequestJson = (int) dr["ide_pah_request_json"];
                        break;
                    }
            }
            return oRcePahRequestJsonE;
        }

        public List<RcePahRequestJsonE> Sp_RcePahRequestJson_Consulta(RcePahRequestJsonE pRcePahRequestJsonE)
        {
            IDataReader dr;
            RcePahRequestJsonE oRcePahRequestJsonE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahRequestJsonE> oListar = new List<RcePahRequestJsonE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahRequestJson_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pah_request_json", pRcePahRequestJsonE.IdePahRequestJson);
                        cmd.Parameters.AddWithValue("@orden", pRcePahRequestJsonE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahRequestJsonE = LlenarEntidad(dr, pRcePahRequestJsonE);
                            oListar.Add(oRcePahRequestJsonE);
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

        public bool Sp_RcePahRequestJson_Insert(RcePahRequestJsonE pRcePahRequestJsonE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahRequestJson_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pah_estados_cab", pRcePahRequestJsonE.IdePahEstadosCab);
                        cmd.Parameters.AddWithValue("@cod_metodo", pRcePahRequestJsonE.CodMetodo);
                        cmd.Parameters.AddWithValue("@dsc_plataforma", pRcePahRequestJsonE.DscPlataforma);
                        cmd.Parameters.AddWithValue("@dsc_json", pRcePahRequestJsonE.DscJson);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_pah_request_json", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahRequestJsonE.IdePahRequestJson.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRcePahRequestJsonE.IdePahRequestJson = (int)cmd.Parameters["@ide_pah_request_json"].Value;
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

        public bool Sp_RcePahRequestJson_Update(RcePahRequestJsonE pRcePahRequestJsonE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahRequestJson_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pah_estados_cab", pRcePahRequestJsonE.IdePahEstadosCab);
                        cmd.Parameters.AddWithValue("@dsc_plataforma", pRcePahRequestJsonE.DscPlataforma);
                        cmd.Parameters.AddWithValue("@dsc_json", pRcePahRequestJsonE.DscJson);
                        cmd.Parameters.AddWithValue("@fec_json", pRcePahRequestJsonE.FecJson);
                        cmd.Parameters.AddWithValue("@ide_pah_request_json", pRcePahRequestJsonE.IdePahRequestJson);
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

        public bool Sp_RcePahRequestJson_UpdatexCampo(RcePahRequestJsonE pRcePahRequestJsonE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahRequestJson_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pah_request_json", pRcePahRequestJsonE.IdePahRequestJson);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahRequestJsonE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahRequestJsonE.Campo);
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

        public bool Sp_RcePahRequestJson_Delete(RcePahRequestJsonE pRcePahRequestJsonE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahRequestJson_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pah_request_json", pRcePahRequestJsonE.IdePahRequestJson);
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
