using Ent.Sql.ClinicaE.OtrosE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.OtrosAD
{
    public class ConsultaPolizasAD
    {
        private ConsultaPolizasE LlenarEntidad(IDataReader dr, ConsultaPolizasE pConsultapolizasE)
        {
            ConsultaPolizasE oConsultapolizasE = new ConsultaPolizasE();
            switch (pConsultapolizasE.Orden)
            {
                case 1:
                    {
                        oConsultapolizasE.Codatencion = (string) dr["codatencion"];
                        oConsultapolizasE.Linea = (string) dr["linea"];
                        oConsultapolizasE.Idconsulta = (int) dr["idconsulta"];
                        break;
                    }
            }
            return oConsultapolizasE;
        }

        public List<ConsultaPolizasE> Sp_Consultapolizas_Consulta(ConsultaPolizasE pConsultapolizasE)
        {
            IDataReader dr;
            ConsultaPolizasE oConsultapolizasE = null/* TODO Change to default(_) if this is not a reference type */;
            List<ConsultaPolizasE> oListar = new List<ConsultaPolizasE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Consultapolizas_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@idconsulta", pConsultapolizasE.Idconsulta);
                        cmd.Parameters.AddWithValue("@orden", pConsultapolizasE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oConsultapolizasE = LlenarEntidad(dr, pConsultapolizasE);
                            oListar.Add(oConsultapolizasE);
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

        public bool Sp_ConsultaPolizas_InsertV2(ref ConsultaPolizasE pConsultapolizasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_ConsultaPolizas_InsertV2", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pConsultapolizasE.Codatencion);
                        cmd.Parameters.AddWithValue("@linea", pConsultapolizasE.Linea);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@idconsulta", ParameterDirection.InputOutput, SqlDbType.Int, 8, pConsultapolizasE.Idconsulta.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pConsultapolizasE.Idconsulta = (int)cmd.Parameters["@idconsulta"].Value;
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

        public bool Sp_Consultapolizas_Update(ConsultaPolizasE pConsultapolizasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Consultapolizas_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pConsultapolizasE.Codatencion);
                        cmd.Parameters.AddWithValue("@linea", pConsultapolizasE.Linea);
                        cmd.Parameters.AddWithValue("@idconsulta", pConsultapolizasE.Idconsulta);
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

        public bool Sp_Consultapolizas_UpdatexCampo(ConsultaPolizasE pConsultapolizasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Consultapolizas_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@idconsulta", pConsultapolizasE.Idconsulta);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pConsultapolizasE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pConsultapolizasE.Campo);
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

        public bool Sp_Consultapolizas_Delete(ConsultaPolizasE pConsultapolizasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Consultapolizas_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@idconsulta", pConsultapolizasE.Idconsulta);
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
