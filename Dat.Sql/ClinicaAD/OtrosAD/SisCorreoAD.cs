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
    public class SisCorreoAD
    {
        private SisCorreoE LlenarEntidad(IDataReader dr, SisCorreoE pSisCorreoE)
        {
            SisCorreoE oSisCorreoE = new SisCorreoE();
            switch (pSisCorreoE.Orden)
            {
                case 1:
                    {
                        oSisCorreoE.Fecharegistro = (DateTime) dr["fecharegistro"];
                        oSisCorreoE.EnviarA = (string) dr["enviara"];
                        oSisCorreoE.CopiarA = (string) dr["copiara"];
                        oSisCorreoE.Copiarh = (string) dr["copiarh"];
                        oSisCorreoE.Asunto = (string) dr["asunto"];
                        oSisCorreoE.Cuerpo = (string) dr["cuerpo"];
                        oSisCorreoE.Archivo = (string) dr["archivo"];
                        oSisCorreoE.Hostname = (string) dr["hostname"];
                        oSisCorreoE.Username = (string) dr["username"];
                        oSisCorreoE.Appname = (string) dr["appname"];
                        oSisCorreoE.Mailid = (int) dr["mailid"];
                        oSisCorreoE.Errorreturn = (int) dr["errorreturn"];
                        oSisCorreoE.Idcorreo = (int) dr["idcorreo"];
                        break;
                    }
            }
            return oSisCorreoE;
        }

        public bool Ut_EnviarCorreov3(SisCorreoE pSisCorreoE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Ut_EnviarCorreov3", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@profile_name", pSisCorreoE.PerfilName);
                        cmd.Parameters.AddWithValue("@recipients", pSisCorreoE.EnviarA);
                        cmd.Parameters.AddWithValue("@copy_recipients", pSisCorreoE.CopiarA);
                        cmd.Parameters.AddWithValue("@blind_copy_recipients", pSisCorreoE.Copiarh);
                        cmd.Parameters.AddWithValue("@subject", pSisCorreoE.Asunto);
                        cmd.Parameters.AddWithValue("@body", pSisCorreoE.Cuerpo);
                        cmd.Parameters.AddWithValue("@body_format", pSisCorreoE.FormatoCuerpo);
                        cmd.Parameters.AddWithValue("@importance", "NORMAL");
                        cmd.Parameters.AddWithValue("@sensitivity", "NORMAL");
                        cmd.Parameters.AddWithValue("@file_attachments", pSisCorreoE.Archivo);
                        cmd.Parameters.AddWithValue("@query", null);
                        cmd.Parameters.AddWithValue("@execute_query_database", null);
                        cmd.Parameters.AddWithValue("@attach_query_result_as_file", false);
                        cmd.Parameters.AddWithValue("@query_attachment_filename", null);
                        cmd.Parameters.AddWithValue("@query_result_header", true);
                        cmd.Parameters.AddWithValue("@query_result_width", 256);
                        cmd.Parameters.AddWithValue("@query_result_separator", " ");
                        cmd.Parameters.AddWithValue("@exclude_query_output", 0);
                        cmd.Parameters.AddWithValue("@append_query_error", 0);
                        cmd.Parameters.AddWithValue("@query_no_truncate", 0);
                        cmd.Parameters.AddWithValue("@query_result_no_padding", 0);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@mailitem_id", ParameterDirection.InputOutput, SqlDbType.Int, 8, pSisCorreoE.Mailid.ToString()));
                        cmd.Parameters.AddWithValue("@from_address", null);
                        cmd.Parameters.AddWithValue("@reply_to", null);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        if ((int)cmd.Parameters["@mailitem_id"].Value != 0)
                        {
                            pSisCorreoE.Mailid = (int)cmd.Parameters["@mailitem_id"].Value;
                            return true;
                        }
                        else
                            return false;
                        cnn.Close();
                        cmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SisCorreoAD - Ut_EnviarCorreov3: " + ex.Message);
            }
        }

        public List<SisCorreoE> Sp_SisCorreo_Consulta(SisCorreoE pSisCorreoE)
        {
            IDataReader dr;
            SisCorreoE oSisCorreoE = null/* TODO Change to default(_) if this is not a reference type */;
            List<SisCorreoE> oListar = new List<SisCorreoE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_SisCorreo_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@idcorreo", pSisCorreoE.Idcorreo);
                        cmd.Parameters.AddWithValue("@orden", pSisCorreoE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oSisCorreoE = LlenarEntidad(dr, pSisCorreoE);
                            oListar.Add(oSisCorreoE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
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
