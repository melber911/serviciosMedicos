using Ent.Sql.ClinicaE.SitedsE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.SitedsAD
{
    public class s10_LogDocumentoAutorizacionAD
    {
        private s10_LogDocumentoAutorizacionE LlenarEntidad(IDataReader dr, s10_LogDocumentoAutorizacionE pS10LogdocumentoautorizacionE)
        {
            s10_LogDocumentoAutorizacionE oS10LogdocumentoautorizacionE = new s10_LogDocumentoAutorizacionE();
            switch (pS10LogdocumentoautorizacionE.Orden)
            {
                case 1:
                    {
                        oS10LogdocumentoautorizacionE.IdeDatosPagos = (int) dr["ide_datospagos"];
                        oS10LogdocumentoautorizacionE.NumAutorizacionSiteds = (string) dr["num_autorizacionsiteds"];
                        oS10LogdocumentoautorizacionE.BlbDocumento = (byte[]) dr["blb_documento"];
                        oS10LogdocumentoautorizacionE.FecRegistro = (DateTime) dr["fec_registro"];
                        oS10LogdocumentoautorizacionE.IdeDocAutorizacion = (int) dr["ide_doc_autorizacion"];
                        break;
                    }
            }
            return oS10LogdocumentoautorizacionE;
        }

        public List<s10_LogDocumentoAutorizacionE> Sp_S10Logdocumentoautorizacion_Consulta(s10_LogDocumentoAutorizacionE pS10LogdocumentoautorizacionE)
        {
            IDataReader dr;
            s10_LogDocumentoAutorizacionE oS10LogdocumentoautorizacionE = null/* TODO Change to default(_) if this is not a reference type */;
            List<s10_LogDocumentoAutorizacionE> oListar = new List<s10_LogDocumentoAutorizacionE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_S10Logdocumentoautorizacion_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_doc_autorizacion", pS10LogdocumentoautorizacionE.IdeDocAutorizacion);
                        cmd.Parameters.AddWithValue("@orden", pS10LogdocumentoautorizacionE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oS10LogdocumentoautorizacionE = LlenarEntidad(dr, pS10LogdocumentoautorizacionE);
                            oListar.Add(oS10LogdocumentoautorizacionE);
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

        public bool Sp_S10LogDocumentoAutorizacion_Insert(s10_LogDocumentoAutorizacionE pS10LogdocumentoautorizacionE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_S10LogDocumentoAutorizacion_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_datospagos", pS10LogdocumentoautorizacionE.IdeDatosPagos);
                        cmd.Parameters.AddWithValue("@num_autorizacionsiteds", pS10LogdocumentoautorizacionE.NumAutorizacionSiteds);
                        cmd.Parameters.AddWithValue("@blb_documento", pS10LogdocumentoautorizacionE.BlbDocumento);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_doc_autorizacion", ParameterDirection.InputOutput, SqlDbType.Int, 8, pS10LogdocumentoautorizacionE.IdeDocAutorizacion.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pS10LogdocumentoautorizacionE.IdeDocAutorizacion = (int)cmd.Parameters["@ide_doc_autorizacion"].Value;
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
    }
}
