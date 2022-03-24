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
    public class RcePahAutorizacionPrefacturasDetAD
    {
        private RcePahAutorizacionPrefacturasDetE LlenarEntidad(IDataReader dr, RcePahAutorizacionPrefacturasDetE pRcePahAutorizacionPrefacturasDetE)
        {
            RcePahAutorizacionPrefacturasDetE oRcePahAutorizacionPrefacturasDetE = new RcePahAutorizacionPrefacturasDetE();
            switch (pRcePahAutorizacionPrefacturasDetE.Orden)
            {
                case 1:
                    {
                        oRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasCab = (int) dr["ide_autorizacion_prefacturas_cab"];
                        oRcePahAutorizacionPrefacturasDetE.DscApellidos = (string) dr["dsc_apellidos"];
                        oRcePahAutorizacionPrefacturasDetE.DscNombres = (string) dr["dsc_nombres"];
                        oRcePahAutorizacionPrefacturasDetE.NroDni = (string) dr["nro_dni"];
                        oRcePahAutorizacionPrefacturasDetE.DscCorreos = (string) dr["dsc_correos"];
                        oRcePahAutorizacionPrefacturasDetE.DscRespEnvio = (string) dr["dsc_resp_envio"];
                        oRcePahAutorizacionPrefacturasDetE.FlgEstado = (string) dr["flg_estado"];
                        oRcePahAutorizacionPrefacturasDetE.FecRegistro = (DateTime) dr["fec_registro"];
                        oRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasDet = (int) dr["ide_autorizacion_prefacturas_det"];
                        break;
                    }
            }
            return oRcePahAutorizacionPrefacturasDetE;
        }

        public List<RcePahAutorizacionPrefacturasDetE> Sp_RcePahAutorizacionPrefacturasDet_Consulta(RcePahAutorizacionPrefacturasDetE pRcePahAutorizacionPrefacturasDetE)
        {
            IDataReader dr;
            RcePahAutorizacionPrefacturasDetE oRcePahAutorizacionPrefacturasDetE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahAutorizacionPrefacturasDetE> oListar = new List<RcePahAutorizacionPrefacturasDetE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasDet_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_det", pRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasDet);
                        cmd.Parameters.AddWithValue("@orden", pRcePahAutorizacionPrefacturasDetE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahAutorizacionPrefacturasDetE = LlenarEntidad(dr, pRcePahAutorizacionPrefacturasDetE);
                            oListar.Add(oRcePahAutorizacionPrefacturasDetE);
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

        public bool Sp_RcePahAutorizacionPrefacturasDet_Insert(RcePahAutorizacionPrefacturasDetE pRcePahAutorizacionPrefacturasDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasDet_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_cab", pRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasCab);
                        cmd.Parameters.AddWithValue("@dsc_apellidos", pRcePahAutorizacionPrefacturasDetE.DscApellidos);
                        cmd.Parameters.AddWithValue("@dsc_nombres", pRcePahAutorizacionPrefacturasDetE.DscNombres);
                        cmd.Parameters.AddWithValue("@nro_dni", pRcePahAutorizacionPrefacturasDetE.NroDni);
                        cmd.Parameters.AddWithValue("@dsc_correos", pRcePahAutorizacionPrefacturasDetE.DscCorreos);
                        cmd.Parameters.AddWithValue("@dsc_resp_envio", pRcePahAutorizacionPrefacturasDetE.DscRespEnvio);
                        cmd.Parameters.AddWithValue("@flg_estado", pRcePahAutorizacionPrefacturasDetE.FlgEstado);
                        cmd.Parameters.AddWithValue("@dsc_parentesco", pRcePahAutorizacionPrefacturasDetE.Parentesco);
                        cmd.Parameters.AddWithValue("@nro_telefono", pRcePahAutorizacionPrefacturasDetE.Telefono);

                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_autorizacion_prefacturas_det", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasDet.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasDet = (int)cmd.Parameters["@ide_autorizacion_prefacturas_det"].Value;
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

        public bool Sp_RcePahAutorizacionPrefacturasDet_Update(RcePahAutorizacionPrefacturasDetE pRcePahAutorizacionPrefacturasDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasDet_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_cab", pRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasCab);
                        cmd.Parameters.AddWithValue("@dsc_apellidos", pRcePahAutorizacionPrefacturasDetE.DscApellidos);
                        cmd.Parameters.AddWithValue("@dsc_nombres", pRcePahAutorizacionPrefacturasDetE.DscNombres);
                        cmd.Parameters.AddWithValue("@nro_dni", pRcePahAutorizacionPrefacturasDetE.NroDni);
                        cmd.Parameters.AddWithValue("@dsc_correos", pRcePahAutorizacionPrefacturasDetE.DscCorreos);
                        cmd.Parameters.AddWithValue("@dsc_resp_envio", pRcePahAutorizacionPrefacturasDetE.DscRespEnvio);
                        cmd.Parameters.AddWithValue("@flg_estado", pRcePahAutorizacionPrefacturasDetE.FlgEstado);
                        cmd.Parameters.AddWithValue("@fec_registro", pRcePahAutorizacionPrefacturasDetE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_det", pRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasDet);
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

        public bool Sp_RcePahAutorizacionPrefacturasDet_UpdatexCampo(RcePahAutorizacionPrefacturasDetE pRcePahAutorizacionPrefacturasDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasDet_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_det", pRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasDet);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahAutorizacionPrefacturasDetE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahAutorizacionPrefacturasDetE.Campo);
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

        public bool Sp_RcePahAutorizacionPrefacturasDet_Delete(RcePahAutorizacionPrefacturasDetE pRcePahAutorizacionPrefacturasDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasDet_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_det", pRcePahAutorizacionPrefacturasDetE.IdeAutorizacionPrefacturasDet);
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
