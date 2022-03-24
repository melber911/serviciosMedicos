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
    public  class MdsynAutorizacionCuestionariosDetAD
    {
        private MdsynAutorizacionCuestionariosDetE LlenarEntidad(IDataReader dr, MdsynAutorizacionCuestionariosDetE pMdsynAutorizacionCuestionariosDetE)
        {
            MdsynAutorizacionCuestionariosDetE oMdsynAutorizacionCuestionariosDetE = new MdsynAutorizacionCuestionariosDetE();
            switch (pMdsynAutorizacionCuestionariosDetE.Orden)
            {
                case 1:
                    {
                        oMdsynAutorizacionCuestionariosDetE.IdeAutorizacionCab = (int) dr["ide_autorizacion_cab"];
                        oMdsynAutorizacionCuestionariosDetE.DscTextoAutorizacion = (string) dr["dsc_texto_autorizacion"];
                        oMdsynAutorizacionCuestionariosDetE.DscRespuesta = (string) dr["dsc_respuesta"];
                        oMdsynAutorizacionCuestionariosDetE.FecRegistro = (DateTime) dr["fec_registro"];
                        oMdsynAutorizacionCuestionariosDetE.IdeAutorizacionDet = (int) dr["ide_autorizacion_det"];
                        break;
                    }
            }
            return oMdsynAutorizacionCuestionariosDetE;
        }

        public List<MdsynAutorizacionCuestionariosDetE> Sp_MdsynAutorizacionCuestionariosDet_Consulta(MdsynAutorizacionCuestionariosDetE pMdsynAutorizacionCuestionariosDetE)
        {
            IDataReader dr;
            MdsynAutorizacionCuestionariosDetE oMdsynAutorizacionCuestionariosDetE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MdsynAutorizacionCuestionariosDetE> oListar = new List<MdsynAutorizacionCuestionariosDetE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosDet_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_det", pMdsynAutorizacionCuestionariosDetE.IdeAutorizacionDet);
                        cmd.Parameters.AddWithValue("@orden", pMdsynAutorizacionCuestionariosDetE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMdsynAutorizacionCuestionariosDetE = LlenarEntidad(dr, pMdsynAutorizacionCuestionariosDetE);
                            oListar.Add(oMdsynAutorizacionCuestionariosDetE);
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

        public bool Sp_MdsynAutorizacionCuestionariosDet_Insert(MdsynAutorizacionCuestionariosDetE pMdsynAutorizacionCuestionariosDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosDet_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_cab", pMdsynAutorizacionCuestionariosDetE.IdeAutorizacionCab);
                        cmd.Parameters.AddWithValue("@dsc_texto_autorizacion", pMdsynAutorizacionCuestionariosDetE.DscTextoAutorizacion);
                        cmd.Parameters.AddWithValue("@dsc_respuesta", pMdsynAutorizacionCuestionariosDetE.DscRespuesta);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_autorizacion_det", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMdsynAutorizacionCuestionariosDetE.IdeAutorizacionDet.ToString()));
                        cmd.Parameters.AddWithValue("@i", pMdsynAutorizacionCuestionariosDetE.i);
                        cmd.Parameters.AddWithValue("@cod_tipo_cuestionario", pMdsynAutorizacionCuestionariosDetE.CodTipoCuestionario);

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        pMdsynAutorizacionCuestionariosDetE.IdeAutorizacionDet = (int) cmd.Parameters["@ide_autorizacion_det"].Value;

                        if (pMdsynAutorizacionCuestionariosDetE.IdeAutorizacionDet == 0)
                            return false;
                        else
                            return true;
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

        public bool Sp_MdsynAutorizacionCuestionariosDet_Update(MdsynAutorizacionCuestionariosDetE pMdsynAutorizacionCuestionariosDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosDet_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_cab", pMdsynAutorizacionCuestionariosDetE.IdeAutorizacionCab);
                        cmd.Parameters.AddWithValue("@dsc_texto_autorizacion", pMdsynAutorizacionCuestionariosDetE.DscTextoAutorizacion);
                        cmd.Parameters.AddWithValue("@dsc_respuesta", pMdsynAutorizacionCuestionariosDetE.DscRespuesta);
                        cmd.Parameters.AddWithValue("@fec_registro", pMdsynAutorizacionCuestionariosDetE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_autorizacion_det", pMdsynAutorizacionCuestionariosDetE.IdeAutorizacionDet);
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

        public bool Sp_MdsynAutorizacionCuestionariosDet_UpdatexCampo(MdsynAutorizacionCuestionariosDetE pMdsynAutorizacionCuestionariosDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosDet_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_det", pMdsynAutorizacionCuestionariosDetE.IdeAutorizacionDet);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pMdsynAutorizacionCuestionariosDetE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pMdsynAutorizacionCuestionariosDetE.Campo);
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

        public bool Sp_MdsynAutorizacionCuestionariosDet_Delete(MdsynAutorizacionCuestionariosDetE pMdsynAutorizacionCuestionariosDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAutorizacionCuestionariosDet_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_autorizacion_det", pMdsynAutorizacionCuestionariosDetE.IdeAutorizacionDet);
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
