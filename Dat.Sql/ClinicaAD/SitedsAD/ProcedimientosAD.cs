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
    public class ProcedimientosAD
    {
        private ProcedimientosE LlenarEntidad(IDataReader dr, ProcedimientosE PProcedimientos)
        {
            ProcedimientosE oProcedimientossE = new ProcedimientosE();
            // Select Case PDatosGenerales.OR .Orden
            // Case 1

            oProcedimientossE.cIafasCode = (string) dr["cIafasCode"];
            oProcedimientossE.cAsegCode = (string) dr["cAsegCode"];
            oProcedimientossE.cAutoCode = (string) dr["cAutoCode"];
            oProcedimientossE.cCoberCode = (string) dr["cCoberCode"];
            oProcedimientossE.cSubtipoCober = (string) dr["cSubtipoCober"];
            oProcedimientossE.cItem = (string) dr["cItem"];
            oProcedimientossE.cTipoProcInt = (string) dr["cTipoProcInt"];
            oProcedimientossE.nTipoProcName = (string) dr["nTipoProcName"];
            oProcedimientossE.cGeCode = (string) dr["cGeCode"];
            oProcedimientossE.nCopgFijo = (double) dr["nCopgFijo"];
            oProcedimientossE.nCopgVari = (double) dr["nCopgVari"];
            oProcedimientossE.nFrecNumb = (int) dr["nFrecNumb"];
            oProcedimientossE.nDiasCant = (int) dr["nDiasCant"];
            oProcedimientossE.dObserProc = (string) dr["dObserProc"];

            // End Select
            return oProcedimientossE;
        }

        public string Sp_Procedimientos_Insert(ref ProcedimientosE pProcedimientosE)
        {
            bool xResult = false;
            string s_codigo = "";
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_s10_logProcedimientos_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cIafasCode", pProcedimientosE.cIafasCode);
                        cmd.Parameters.AddWithValue("@cAsegCode", pProcedimientosE.cAsegCode);
                        cmd.Parameters.AddWithValue("@cAutoCode", pProcedimientosE.cAutoCode);
                        cmd.Parameters.AddWithValue("@cCoberCode", pProcedimientosE.cCoberCode);
                        cmd.Parameters.AddWithValue("@cSubtipoCober", pProcedimientosE.cSubtipoCober);
                        cmd.Parameters.AddWithValue("@cItem", pProcedimientosE.cItem);
                        cmd.Parameters.AddWithValue("@cTipoProcInt", pProcedimientosE.cTipoProcInt);
                        cmd.Parameters.AddWithValue("@nTipoProcName", pProcedimientosE.nTipoProcName);
                        cmd.Parameters.AddWithValue("@cGeCode", pProcedimientosE.cGeCode);
                        cmd.Parameters.AddWithValue("@nCopgFijo", pProcedimientosE.nCopgFijo);
                        cmd.Parameters.AddWithValue("@nCopgVari", pProcedimientosE.nCopgVari);
                        cmd.Parameters.AddWithValue("@nFrecNumb", pProcedimientosE.nFrecNumb);
                        cmd.Parameters.AddWithValue("@nDiasCant", pProcedimientosE.nDiasCant);
                        cmd.Parameters.AddWithValue("@dObserProc", pProcedimientosE.dObserProc);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codllave", ParameterDirection.Output, SqlDbType.VarChar, 50, pProcedimientosE.codllaveProc));
                        cnn.Open();

                        cmd.ExecuteNonQuery();
                        pProcedimientosE.codllaveProc = cmd.Parameters["@codllave"].Value + "";
                        s_codigo = pProcedimientosE.codllaveProc;
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
