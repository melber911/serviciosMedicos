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
    public class DatosGeneralesAD
    {
        private DatosGeneralesE LlenarEntidad(IDataReader dr, DatosGeneralesE PDatosGenerales)
        {
            DatosGeneralesE oDatosGeneralesE = new DatosGeneralesE();
            // Select Case PDatosGenerales.OR .Orden
            // Case 1

            oDatosGeneralesE.cIafasCode = (string) dr["cIafasCode"];
            oDatosGeneralesE.cAsegCode = (string) dr["cAsegCode"];
            oDatosGeneralesE.cAutoCode = (string) dr["cAutoCode"];
            oDatosGeneralesE.fAutoDate = (string) dr["fAutoDate"];
            oDatosGeneralesE.dAutoTime = (string) dr["dAutoTime"];
            oDatosGeneralesE.cIpressCode = (string) dr["cIpressCode"];
            oDatosGeneralesE.dIpressRuc = (string) dr["dIpressRuc"];
            oDatosGeneralesE.apAsegApat = (string) dr["apAsegApat"];
            oDatosGeneralesE.apAsegAmat = (string) dr["apAsegAmat"];
            oDatosGeneralesE.nAsegName = (string) dr["nAsegName"];
            oDatosGeneralesE.apTituApat = (string) dr["apTituApat"];
            oDatosGeneralesE.apTituAmat = (string) dr["apTituAmat"];
            oDatosGeneralesE.nTituName = (string) dr["nTituName"];
            oDatosGeneralesE.fNacmDate = (string) dr["fNacmDate"];
            oDatosGeneralesE.nEdadNum = (int) dr["nEdadNum"];
            oDatosGeneralesE.cGeCode = (string) dr["cGeCode"];
            oDatosGeneralesE.cTituCode = (string) dr["cTituCode"];
            oDatosGeneralesE.cTipoPlan = (string) dr["cTipoPlan"];
            oDatosGeneralesE.dCntrRuc = (string) dr["dCntrRuc"];
            oDatosGeneralesE.dCntrName = (string) dr["dCntrName"];
            oDatosGeneralesE.fIniVigDate = (string) dr["fIniVigDate"];
            oDatosGeneralesE.fFinVigDate = (string) dr["fFinVigDate"];
            oDatosGeneralesE.fInclDate = (string) dr["fInclDate"];
            oDatosGeneralesE.cFiliaCode = (string) dr["cFiliaCode"];
            oDatosGeneralesE.cDniCode = (string) dr["cDniCode"];
            oDatosGeneralesE.nCntrNumb = (string) dr["nCntrNumb"];
            oDatosGeneralesE.cMoneCode = (string) dr["cMoneCode"];
            oDatosGeneralesE.cEstaCode = (string) dr["cEstaCode"];
            oDatosGeneralesE.cAfiCode = (string) dr["cAfiCode"];
            oDatosGeneralesE.cSedeCode = (string) dr["cSedeCode"];
            oDatosGeneralesE.dCarnNumb = (string) dr["dCarnNumb"];
            oDatosGeneralesE.dObserva = (string) dr["dObserva"];
            oDatosGeneralesE.dFotoRuta = (string) dr["dFotoRuta"];
            oDatosGeneralesE.nAsegPlan = (string) dr["nAsegPlan"];
            oDatosGeneralesE.nDniTitular = (string) dr["nDniTitular"];
            oDatosGeneralesE.cDniTitular = (string) dr["cDniTitular"];
            oDatosGeneralesE.nPoliza = (string) dr["nPoliza"];
            oDatosGeneralesE.cCntrTipoDoc = (string) dr["cCntrTipoDoc"];
            oDatosGeneralesE.nDniName = (string) dr["nDniName"];
            oDatosGeneralesE.dLogSusalud = (string) dr["dLogSusalud"];
            oDatosGeneralesE.cEsCivil = (string) dr["cEsCivil"];
            oDatosGeneralesE.nCertificado = (string) dr["nCertificado"];
            oDatosGeneralesE.nCodSeguridad = (string) dr["nCodSeguridad"];
            oDatosGeneralesE.cIafasCodeCia = (string) dr["cIafasCodeCia"];
            oDatosGeneralesE.dCondEspeciales = (string) dr["dCondEspeciales"];
            oDatosGeneralesE.cRenIpress = (string) dr["cRenIpress"];
            // End Select
            return oDatosGeneralesE;
        }

        public string Sp_DatosGenerales_Insert(ref DatosGeneralesE pDatosGeneralesE)
        {
            bool xResult = false;
            string s_codigo = "";
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_s10_logDatosGenerales_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // 'Parametros del Store
                        cmd.Parameters.AddWithValue("@cIafasCode", pDatosGeneralesE.cIafasCode);
                        cmd.Parameters.AddWithValue("@cAsegCode", pDatosGeneralesE.cAsegCode);
                        cmd.Parameters.AddWithValue("@cAutoCode", pDatosGeneralesE.cAutoCode);
                        cmd.Parameters.AddWithValue("@fAutoDate", pDatosGeneralesE.fAutoDate);
                        cmd.Parameters.AddWithValue("@dAutoTime", pDatosGeneralesE.dAutoTime);
                        cmd.Parameters.AddWithValue("@cIpressCode", pDatosGeneralesE.cIpressCode);
                        cmd.Parameters.AddWithValue("@dIpressRuc", pDatosGeneralesE.dIpressRuc);
                        cmd.Parameters.AddWithValue("@apAsegApat", pDatosGeneralesE.apAsegApat);
                        cmd.Parameters.AddWithValue("@apAsegAmat", pDatosGeneralesE.apAsegAmat);
                        cmd.Parameters.AddWithValue("@nAsegName", pDatosGeneralesE.nAsegName);
                        cmd.Parameters.AddWithValue("@apTituAmat", pDatosGeneralesE.apTituAmat);
                        cmd.Parameters.AddWithValue("@apTituApat", pDatosGeneralesE.apTituAmat);
                        cmd.Parameters.AddWithValue("@nTituName", pDatosGeneralesE.nTituName);
                        cmd.Parameters.AddWithValue("@cFiliaCode", pDatosGeneralesE.cFiliaCode);
                        cmd.Parameters.AddWithValue("@cSedeCode", pDatosGeneralesE.cSedeCode);
                        cmd.Parameters.AddWithValue("@fNacmDate", pDatosGeneralesE.fNacmDate);
                        cmd.Parameters.AddWithValue("@nEdadNum", pDatosGeneralesE.nEdadNum);
                        cmd.Parameters.AddWithValue("@cGeCode", pDatosGeneralesE.cGeCode);
                        cmd.Parameters.AddWithValue("@cTituCode", pDatosGeneralesE.cTituCode);
                        cmd.Parameters.AddWithValue("@cTipoPlan", pDatosGeneralesE.cTipoPlan);
                        cmd.Parameters.AddWithValue("@dCntrRuc", pDatosGeneralesE.dCntrRuc);
                        cmd.Parameters.AddWithValue("@dCntrName", pDatosGeneralesE.dCntrName);
                        cmd.Parameters.AddWithValue("@fIniVigDate", pDatosGeneralesE.fIniVigDate);
                        cmd.Parameters.AddWithValue("@fFinVigDate", pDatosGeneralesE.fFinVigDate);
                        cmd.Parameters.AddWithValue("@fInclDate", pDatosGeneralesE.fInclDate);
                        cmd.Parameters.AddWithValue("@cDniCode", pDatosGeneralesE.cDniCode);
                        cmd.Parameters.AddWithValue("@nCntrNumb", pDatosGeneralesE.nCntrNumb);
                        cmd.Parameters.AddWithValue("@cMoneCode", pDatosGeneralesE.cMoneCode);
                        cmd.Parameters.AddWithValue("@cEstaCode", pDatosGeneralesE.cEstaCode);
                        cmd.Parameters.AddWithValue("@cAfiCode", pDatosGeneralesE.cAfiCode);
                        cmd.Parameters.AddWithValue("@dCarnNumb", pDatosGeneralesE.dCarnNumb);
                        cmd.Parameters.AddWithValue("@dObserva", pDatosGeneralesE.dObserva);
                        cmd.Parameters.AddWithValue("@dFotoRuta", pDatosGeneralesE.dFotoRuta);
                        cmd.Parameters.AddWithValue("@nAsegPlan", pDatosGeneralesE.nAsegPlan);
                        cmd.Parameters.AddWithValue("@nDniTitular", pDatosGeneralesE.nDniTitular);
                        cmd.Parameters.AddWithValue("@cDniTitular", pDatosGeneralesE.cDniTitular);
                        cmd.Parameters.AddWithValue("@nPoliza", pDatosGeneralesE.nPoliza);
                        cmd.Parameters.AddWithValue("@cCntrTipoDoc", pDatosGeneralesE.cCntrTipoDoc);
                        cmd.Parameters.AddWithValue("@nDniName", pDatosGeneralesE.nDniName);
                        cmd.Parameters.AddWithValue("@dLogSusalud", pDatosGeneralesE.dLogSusalud);
                        cmd.Parameters.AddWithValue("@cEsCivil", pDatosGeneralesE.cEsCivil);
                        cmd.Parameters.AddWithValue("@nCertificado", pDatosGeneralesE.nCertificado);
                        cmd.Parameters.AddWithValue("@nCodSeguridad", pDatosGeneralesE.nCodSeguridad);
                        cmd.Parameters.AddWithValue("@cIafasCodeCia", pDatosGeneralesE.cIafasCodeCia);
                        cmd.Parameters.AddWithValue("@dCondEspeciales", pDatosGeneralesE.dCondEspeciales);
                        cmd.Parameters.AddWithValue("@cRenIpress", pDatosGeneralesE.cRenIpress);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codllave", ParameterDirection.Output, SqlDbType.VarChar, 50, pDatosGeneralesE.codllaveDG));
                        cnn.Open();

                        // cIafasCode, cAsegCode, cAutoCode
                        cmd.ExecuteNonQuery();
                        pDatosGeneralesE.codllaveDG = cmd.Parameters["@codllave"].Value + "";
                        s_codigo = pDatosGeneralesE.codllaveDG;
                        xResult = true;

                        cnn.Close();
                        cmd.Dispose();
                    }
                }

                return s_codigo; // xResult
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
