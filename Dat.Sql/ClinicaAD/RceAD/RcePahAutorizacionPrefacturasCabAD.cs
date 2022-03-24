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
    public class RcePahAutorizacionPrefacturasCabAD
    {
        private RcePahAutorizacionPrefacturasCabE LlenarEntidad(IDataReader dr, RcePahAutorizacionPrefacturasCabE pRcePahAutorizacionPrefacturasCabE)
        {
            RcePahAutorizacionPrefacturasCabE oRcePahAutorizacionPrefacturasCabE = new RcePahAutorizacionPrefacturasCabE();
            switch (pRcePahAutorizacionPrefacturasCabE.Orden)
            {
                case 1:
                    {
                        oRcePahAutorizacionPrefacturasCabE.CodAtencion = (string) dr["cod_atencion"];
                        oRcePahAutorizacionPrefacturasCabE.IdeAutorizacionPrefacturasCab = (int) dr["ide_autorizacion_prefacturas_cab"];
                        oRcePahAutorizacionPrefacturasCabE.oAutorizacionPreDetE.IdeAutorizacionPrefacturasCab = (int) dr["ide_autorizacion_prefacturas_det"];
                        oRcePahAutorizacionPrefacturasCabE.oAutorizacionPreDetE.IdeAutorizacionPrefacturasDet = (int) dr["ide_autorizacion_prefacturas_cab"];
                        oRcePahAutorizacionPrefacturasCabE.oAutorizacionPreDetE.DscApellidos = (string) dr["dsc_apellidos"];
                        oRcePahAutorizacionPrefacturasCabE.oAutorizacionPreDetE.DscNombres = (string) dr["dsc_nombres"];
                        oRcePahAutorizacionPrefacturasCabE.oAutorizacionPreDetE.NroDni = (string) dr["nro_dni"];
                        oRcePahAutorizacionPrefacturasCabE.oAutorizacionPreDetE.DscCorreos = (string) dr["dsc_correos"];
                        oRcePahAutorizacionPrefacturasCabE.oAutorizacionPreDetE.Parentesco = (string) dr["dsc_parentesco"];
                        oRcePahAutorizacionPrefacturasCabE.oAutorizacionPreDetE.Telefono = (string) dr["nro_telefono"];
                        break;
                    }
            }
            return oRcePahAutorizacionPrefacturasCabE;
        }

        public List<RcePahAutorizacionPrefacturasCabE> Sp_RcePahAutorizacionPrefacturasCab_Consulta(RcePahAutorizacionPrefacturasCabE pRcePahAutorizacionPrefacturasCabE)
        {
            IDataReader dr;
            RcePahAutorizacionPrefacturasCabE oRcePahAutorizacionPrefacturasCabE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahAutorizacionPrefacturasCabE> oListar = new List<RcePahAutorizacionPrefacturasCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasCab_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_cab", pRcePahAutorizacionPrefacturasCabE.IdeAutorizacionPrefacturasCab);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahAutorizacionPrefacturasCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@orden", pRcePahAutorizacionPrefacturasCabE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahAutorizacionPrefacturasCabE = LlenarEntidad(dr, pRcePahAutorizacionPrefacturasCabE);
                            oListar.Add(oRcePahAutorizacionPrefacturasCabE);
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

        public bool Sp_RcePahAutorizacionPrefacturasCab_Insert(RcePahAutorizacionPrefacturasCabE pRcePahAutorizacionPrefacturasCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasCab_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahAutorizacionPrefacturasCabE.CodAtencion);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_autorizacion_prefacturas_cab", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahAutorizacionPrefacturasCabE.IdeAutorizacionPrefacturasCab.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRcePahAutorizacionPrefacturasCabE.IdeAutorizacionPrefacturasCab = (int)cmd.Parameters["@ide_autorizacion_prefacturas_cab"].Value;
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

        public bool Sp_RcePahAutorizacionPrefacturasCab_Update(RcePahAutorizacionPrefacturasCabE pRcePahAutorizacionPrefacturasCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasCab_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_paciente", pRcePahAutorizacionPrefacturasCabE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahAutorizacionPrefacturasCabE.CodAtencion);
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_cab", pRcePahAutorizacionPrefacturasCabE.IdeAutorizacionPrefacturasCab);
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

        public bool Sp_RcePahAutorizacionPrefacturasCab_UpdatexCampo(RcePahAutorizacionPrefacturasCabE pRcePahAutorizacionPrefacturasCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasCab_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_prefacturas_cab", pRcePahAutorizacionPrefacturasCabE.IdeAutorizacionPrefacturasCab);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahAutorizacionPrefacturasCabE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahAutorizacionPrefacturasCabE.Campo);
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

        public bool Sp_RcePahAutorizacionPrefacturasCab_Delete(RcePahAutorizacionPrefacturasCabE pRcePahAutorizacionPrefacturasCabE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahAutorizacionPrefacturasCab_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahAutorizacionPrefacturasCabE.CodAtencion);
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
