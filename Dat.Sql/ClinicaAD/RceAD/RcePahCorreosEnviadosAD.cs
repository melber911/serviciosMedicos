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
    public class RcePahCorreosEnviadosAD
    {
        private RcePahCorreosEnviadosE LlenarEntidad(IDataReader dr, RcePahCorreosEnviadosE pRcePahCorreosEnviadosE)
        {
            RcePahCorreosEnviadosE oRcePahCorreosEnviadosE = new RcePahCorreosEnviadosE();
            switch (pRcePahCorreosEnviadosE.Orden)
            {
                case 1:
                    {
                        oRcePahCorreosEnviadosE.CodAtencion = (string) dr["cod_atencion"];
                        oRcePahCorreosEnviadosE.DscEmail = (string) dr["dsc_email"];
                        oRcePahCorreosEnviadosE.DscTelefono = (string) dr["dsc_telefono"];
                        oRcePahCorreosEnviadosE.UsrEnvio = (int) dr["usr_envio"];
                        oRcePahCorreosEnviadosE.FecEnvio = (DateTime) dr["fec_envio"];
                        oRcePahCorreosEnviadosE.IdeCorreoEnviado = (int) dr["ide_correo_enviado"];
                        break;
                    }
            }
            return oRcePahCorreosEnviadosE;
        }

        public List<RcePahCorreosEnviadosE> Sp_RcePahCorreosEnviados_Consulta(RcePahCorreosEnviadosE pRcePahCorreosEnviadosE)
        {
            IDataReader dr;
            RcePahCorreosEnviadosE oRcePahCorreosEnviadosE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahCorreosEnviadosE> oListar = new List<RcePahCorreosEnviadosE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahCorreosEnviados_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_correo_enviado", pRcePahCorreosEnviadosE.IdeCorreoEnviado);
                        cmd.Parameters.AddWithValue("@orden", pRcePahCorreosEnviadosE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahCorreosEnviadosE = LlenarEntidad(dr, pRcePahCorreosEnviadosE);
                            oListar.Add(oRcePahCorreosEnviadosE);
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

        public bool Sp_RcePahCorreosEnviados_Insert(RcePahCorreosEnviadosE pRcePahCorreosEnviadosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahCorreosEnviados_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahCorreosEnviadosE.CodAtencion);
                        cmd.Parameters.AddWithValue("@usr_envio", pRcePahCorreosEnviadosE.UsrEnvio);
                        cmd.Parameters.AddWithValue("@dsc_mail", pRcePahCorreosEnviadosE.DscEmail);
                        cmd.Parameters.AddWithValue("@dsc_telefono", pRcePahCorreosEnviadosE.DscTelefono);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_correo_enviado", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahCorreosEnviadosE.IdeCorreoEnviado.ToString()));
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@mailitem_id", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahCorreosEnviadosE.MailItemId.ToString()));
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        pRcePahCorreosEnviadosE.IdeCorreoEnviado = (int)cmd.Parameters["@ide_correo_enviado"].Value;
                        pRcePahCorreosEnviadosE.MailItemId = (int)cmd.Parameters["@mailitem_id"].Value;

                        if (pRcePahCorreosEnviadosE.MailItemId >= 1)
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

        public bool Sp_RcePahCorreosEnviados_Update(RcePahCorreosEnviadosE pRcePahCorreosEnviadosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahCorreosEnviados_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahCorreosEnviadosE.CodAtencion);
                        cmd.Parameters.AddWithValue("@dsc_email", pRcePahCorreosEnviadosE.DscEmail);
                        cmd.Parameters.AddWithValue("@dsc_telefono", pRcePahCorreosEnviadosE.DscTelefono);
                        cmd.Parameters.AddWithValue("@usr_envio", pRcePahCorreosEnviadosE.UsrEnvio);
                        cmd.Parameters.AddWithValue("@fec_envio", pRcePahCorreosEnviadosE.FecEnvio);
                        cmd.Parameters.AddWithValue("@ide_correo_enviado", pRcePahCorreosEnviadosE.IdeCorreoEnviado);
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

        public bool Sp_RcePahCorreosEnviados_UpdatexCampo(RcePahCorreosEnviadosE pRcePahCorreosEnviadosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahCorreosEnviados_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_correo_enviado", pRcePahCorreosEnviadosE.IdeCorreoEnviado);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahCorreosEnviadosE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahCorreosEnviadosE.Campo);
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

        public bool Sp_RcePahCorreosEnviados_Delete(RcePahCorreosEnviadosE pRcePahCorreosEnviadosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahCorreosEnviados_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_correo_enviado", pRcePahCorreosEnviadosE.IdeCorreoEnviado);
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

        public bool Sp_RcePahCorreosGenerales(RcePahCorreosEnviadosE pRcePahCorreosEnviadosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahCorreosGenerales", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@orden", pRcePahCorreosEnviadosE.Orden);
                        cmd.Parameters.AddWithValue("@codatencion", pRcePahCorreosEnviadosE.CodAtencion);
                        cmd.Parameters.AddWithValue("@codpaciente", "");
                        cmd.Parameters.AddWithValue("@correo", "");
                        cmd.Parameters.AddWithValue("@ide_primary", pRcePahCorreosEnviadosE.IdePrimary);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@mailitem_id", ParameterDirection.InputOutput, SqlDbType.Int, 0, pRcePahCorreosEnviadosE.MailItemId));
                        cmd.Parameters.AddWithValue("@ruta_archivo_adjunto", pRcePahCorreosEnviadosE.RutaArchivoAdjunto);

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        if ((int)cmd.Parameters["@mailitem_id"].Value != 0)
                        {
                            pRcePahCorreosEnviadosE.MailItemId = (int)cmd.Parameters["@mailitem_id"].Value;
                            return true;
                        }
                        else
                            return false;

                        // If cmd.ExecuteNonQuery() >= 1 Then
                        // pRcePahCorreosEnviadosE.MailItemId = cmd.Parameters("@mailitem_id").Value
                        // Return True
                        // Else
                        // Return False
                        // End If
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
