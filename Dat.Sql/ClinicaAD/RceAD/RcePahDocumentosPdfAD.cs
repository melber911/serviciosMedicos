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
    public class RcePahDocumentosPdfAD
    {
        private RcePahDocumentosPdfE LlenarEntidad(IDataReader dr, RcePahDocumentosPdfE pRcePahDocumentosPdfE)
        {
            RcePahDocumentosPdfE oRcePahDocumentosPdfE = new RcePahDocumentosPdfE();
            switch (pRcePahDocumentosPdfE.Orden)
            {
                case 1:
                case 2:
                    {
                        oRcePahDocumentosPdfE.IdeDocumentosPdf = (int) dr["ide_documentos_pdf"];
                        oRcePahDocumentosPdfE.CodAtencion = (string) dr["cod_atencion"];
                        oRcePahDocumentosPdfE.IdePreAdmision = (int) dr["ide_pre_admision"];
                        oRcePahDocumentosPdfE.CodTipoDocumento = (string) dr["cod_tipo_documento"];
                        oRcePahDocumentosPdfE.BlbDocumento = (byte[]) dr["blb_documento"];
                        break;
                    }
            }
            return oRcePahDocumentosPdfE;
        }

        public List<RcePahDocumentosPdfE> Sp_RcePahDocumentosPdf_Consulta(RcePahDocumentosPdfE pRcePahDocumentosPdfE)
        {
            IDataReader dr;
            RcePahDocumentosPdfE oRcePahDocumentosPdfE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahDocumentosPdfE> oListar = new List<RcePahDocumentosPdfE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentosPdf_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_documentos_pdf", pRcePahDocumentosPdfE.IdeDocumentosPdf);
                        cmd.Parameters.AddWithValue("@cod_tipo_documento", pRcePahDocumentosPdfE.CodTipoDocumento);
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahDocumentosPdfE.CodAtencion);
                        cmd.Parameters.AddWithValue("@ide_pre_admision", pRcePahDocumentosPdfE.IdePreAdmision);
                        cmd.Parameters.AddWithValue("@orden", pRcePahDocumentosPdfE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahDocumentosPdfE = LlenarEntidad(dr, pRcePahDocumentosPdfE);
                            oListar.Add(oRcePahDocumentosPdfE);
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

        public bool Sp_RcePahDocumentosPdf_Insert(RcePahDocumentosPdfE pRcePahDocumentosPdfE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentosPdf_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahDocumentosPdfE.CodAtencion);
                        cmd.Parameters.AddWithValue("@ide_pre_admision", pRcePahDocumentosPdfE.IdePreAdmision);
                        cmd.Parameters.AddWithValue("@cod_tipo_documento", pRcePahDocumentosPdfE.CodTipoDocumento);
                        cmd.Parameters.AddWithValue("@blb_documento", pRcePahDocumentosPdfE.BlbDocumento);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_documentos_pdf", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahDocumentosPdfE.IdeDocumentosPdf.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRcePahDocumentosPdfE.IdeDocumentosPdf = (int)cmd.Parameters["@ide_documentos_pdf"].Value;
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

        public bool Sp_RcePahDocumentosPdf_Update(RcePahDocumentosPdfE pRcePahDocumentosPdfE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentosPdf_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRcePahDocumentosPdfE.CodAtencion);
                        cmd.Parameters.AddWithValue("@ide_pre_admision", pRcePahDocumentosPdfE.IdePreAdmision);
                        cmd.Parameters.AddWithValue("@cod_tipo_documento", pRcePahDocumentosPdfE.CodTipoDocumento);
                        cmd.Parameters.AddWithValue("@blb_documento", pRcePahDocumentosPdfE.BlbDocumento);
                        cmd.Parameters.AddWithValue("@fec_registro", pRcePahDocumentosPdfE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_documentos_pdf", pRcePahDocumentosPdfE.IdeDocumentosPdf);
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

        public bool Sp_RcePahDocumentosPdf_UpdatexCampo(RcePahDocumentosPdfE pRcePahDocumentosPdfE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentosPdf_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_documentos_pdf", pRcePahDocumentosPdfE.IdeDocumentosPdf);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahDocumentosPdfE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahDocumentosPdfE.Campo);
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

        public bool Sp_RcePahDocumentosPdf_Delete(RcePahDocumentosPdfE pRcePahDocumentosPdfE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahDocumentosPdf_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_documentos_pdf", pRcePahDocumentosPdfE.IdeDocumentosPdf);
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
