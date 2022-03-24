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
    public class Coberturas_AcredAD
    {
        private Coberturas_AcredE LlenarEntidad(IDataReader dr, Coberturas_AcredE PCoberturas_Acred)
        {
            Coberturas_AcredE oCoberturas_AcredE = new Coberturas_AcredE();
            // Select Case PDatosGenerales.OR .Orden
            // Case 1

            oCoberturas_AcredE.cIafasCode = (string) dr["cIafasCode"];
            oCoberturas_AcredE.cAsegCode = (string) dr["cAsegCode"];
            oCoberturas_AcredE.cAutoCode = (string) dr["cAutoCode"];
            oCoberturas_AcredE.cCoberCode = (string) dr["cCoberCode"];
            oCoberturas_AcredE.cSubTipoCober = (string) dr["cSubTipoCober"];
            oCoberturas_AcredE.nSubTipoCober = (string) dr["nSubTipoCober"];
            oCoberturas_AcredE.cIndiProCode = (string) dr["cIndiProCode"];
            oCoberturas_AcredE.nCopgFijo = (double) dr["nCopgFijo"];
            oCoberturas_AcredE.cMoneCode = (string) dr["cMoneCode"];
            oCoberturas_AcredE.cCalifServCode = (string) dr["cCalifServCode"];
            oCoberturas_AcredE.nCopgVari = (double) dr["nCopgVari"];
            oCoberturas_AcredE.dBeneficioMax = (string) dr["dBeneficioMax"];
            oCoberturas_AcredE.fFeCarDate = (string) dr["fFeCarDate"];
            oCoberturas_AcredE.fEsperDate = (string) dr["fEsperDate"];
            oCoberturas_AcredE.cFlagCarta = (string) dr["cFlagCarta"];
            oCoberturas_AcredE.cProdCode = (string) dr["cProdCode"];
            oCoberturas_AcredE.cEspeCode = (string) dr["cEspeCode"];
            oCoberturas_AcredE.dIpssHost = (string) dr["dIpssHost"];
            oCoberturas_AcredE.cOrigenAte = (string) dr["cOrigenAte"];
            oCoberturas_AcredE.cAccidentes = (string) dr["cAccidentes"];
            oCoberturas_AcredE.cTiDeclaracion = (string) dr["cTiDeclaracion"];
            oCoberturas_AcredE.dObserva = (string) dr["dObserva"];
            oCoberturas_AcredE.dComercName = (string) dr["dComercName"];
            oCoberturas_AcredE.fAccidentes = (string) dr["fAccidentes"];
            oCoberturas_AcredE.fOrigenAten = (string) dr["fOrigenAten"];
            oCoberturas_AcredE.cUserCode = (string) dr["cUserCode"];
            oCoberturas_AcredE.nUserName = (string) dr["nUserName"];
            oCoberturas_AcredE.cFlagCGCode = (string) dr["cFlagCGCode"];
            oCoberturas_AcredE.dFlagCGName = (string) dr["dFlagCGName"];
            oCoberturas_AcredE.cIndiRestriCode = (string) dr["cIndiRestriCode"];
            oCoberturas_AcredE.dObsCarencia = (string) dr["dObsCarencia"];

            // End Select
            return oCoberturas_AcredE;
        }

        public string Sp_Coberturas_Acred_Insert(ref Coberturas_AcredE pCoberturas_AcredE)
        {
            bool xResult = false;
            string s_codigo = "";
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_s10_logCoberturas_Acred_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cIafasCode", pCoberturas_AcredE.cIafasCode);
                        cmd.Parameters.AddWithValue("@cAsegCode", pCoberturas_AcredE.cAsegCode);
                        cmd.Parameters.AddWithValue("@cAutoCode", pCoberturas_AcredE.cAutoCode);
                        cmd.Parameters.AddWithValue("@cCoberCode", pCoberturas_AcredE.cCoberCode);
                        cmd.Parameters.AddWithValue("@cSubTipoCober", pCoberturas_AcredE.cSubTipoCober);
                        cmd.Parameters.AddWithValue("@nSubTipoCober", pCoberturas_AcredE.nSubTipoCober);
                        cmd.Parameters.AddWithValue("@cIndiProCode", pCoberturas_AcredE.cIndiProCode);
                        cmd.Parameters.AddWithValue("@nCopgFijo", pCoberturas_AcredE.nCopgFijo);
                        cmd.Parameters.AddWithValue("@cMoneCode", pCoberturas_AcredE.cMoneCode);
                        cmd.Parameters.AddWithValue("@cCalifServCode", pCoberturas_AcredE.cCalifServCode);
                        cmd.Parameters.AddWithValue("@nCopgVari", pCoberturas_AcredE.nCopgVari);
                        cmd.Parameters.AddWithValue("@dBeneficioMax", pCoberturas_AcredE.dBeneficioMax);
                        cmd.Parameters.AddWithValue("@fFeCarDate", pCoberturas_AcredE.fFeCarDate);
                        cmd.Parameters.AddWithValue("@fEsperDate", pCoberturas_AcredE.fEsperDate);

                        cmd.Parameters.AddWithValue("@cFlagCarta", pCoberturas_AcredE.cFlagCarta);
                        cmd.Parameters.AddWithValue("@cProdCode", pCoberturas_AcredE.cProdCode);
                        cmd.Parameters.AddWithValue("@cEspeCode", pCoberturas_AcredE.cEspeCode);
                        cmd.Parameters.AddWithValue("@dIpssHost", pCoberturas_AcredE.dIpssHost);
                        cmd.Parameters.AddWithValue("@cOrigenAte", pCoberturas_AcredE.cOrigenAte);

                        cmd.Parameters.AddWithValue("@cAccidentes", pCoberturas_AcredE.cAccidentes);
                        cmd.Parameters.AddWithValue("@cTiDeclaracion", pCoberturas_AcredE.cTiDeclaracion);
                        cmd.Parameters.AddWithValue("@dObserva", pCoberturas_AcredE.dObserva);
                        cmd.Parameters.AddWithValue("@dComercName", pCoberturas_AcredE.dComercName);

                        cmd.Parameters.AddWithValue("@fAccidentes", pCoberturas_AcredE.fAccidentes);
                        cmd.Parameters.AddWithValue("@fOrigenAten", pCoberturas_AcredE.fOrigenAten);
                        cmd.Parameters.AddWithValue("@cUserCode", pCoberturas_AcredE.cUserCode);
                        cmd.Parameters.AddWithValue("@nUserName", pCoberturas_AcredE.nUserName);

                        cmd.Parameters.AddWithValue("@cFlagCGCode", pCoberturas_AcredE.cFlagCGCode);
                        cmd.Parameters.AddWithValue("@dFlagCGName", pCoberturas_AcredE.dFlagCGName);
                        cmd.Parameters.AddWithValue("@cIndiRestriCode", pCoberturas_AcredE.cIndiRestriCode);
                        cmd.Parameters.AddWithValue("@dObsCarencia", pCoberturas_AcredE.dObsCarencia);

                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codllave", ParameterDirection.Output, SqlDbType.VarChar, 50, pCoberturas_AcredE.codllaveCA));
                        cnn.Open();
                        // cIafasCode, cAsegCode, cAutoCode
                        cmd.ExecuteNonQuery();
                        pCoberturas_AcredE.codllaveCA = cmd.Parameters["@codllave"].Value + "";
                        s_codigo = pCoberturas_AcredE.codllaveCA;

                        xResult = true;

                        cnn.Close();
                        cmd.Dispose();
                    }
                }

                return s_codigo;  // xResult
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
