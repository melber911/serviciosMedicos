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
    public class SubtipoCoberturaAD
    {
        private SubTipoCoberturaE LlenarEntidad(IDataReader dr, SubTipoCoberturaE PSubtipoCobertura)
        {
            SubTipoCoberturaE oSubtipoCoberturasE = new SubTipoCoberturaE();
            // Select Case PDatosGenerales.OR .Orden
            // Case 1

            oSubtipoCoberturasE.cCoberCode = (string) dr["cCoberCode"];
            oSubtipoCoberturasE.cSubTipoCober = (string) dr["cSubTipoCober"];
            oSubtipoCoberturasE.nSubTipoCoberName = (string) dr["nSubTipoCoberName"];
            oSubtipoCoberturasE.cSitedsCode = (string) dr["cSitedsCode"];
            oSubtipoCoberturasE.cSitedsCode2 = (string) dr["cSitedsCode2"];
            oSubtipoCoberturasE.dEstado = (string) dr["dEstado"];

            // End Select
            return oSubtipoCoberturasE;
        }

        public int Sp_SubtipoCobertura_Insert(ref SubTipoCoberturaE PSubtipoCoberturaE)
        {
            bool xResult = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_SubtipoCobertura_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@pcCoberCode", PSubtipoCoberturaE.cCoberCode);
                        cmd.Parameters.AddWithValue("@pcSubTipoCober", PSubtipoCoberturaE.cSubTipoCober);
                        cmd.Parameters.AddWithValue("@pnSubTipoCoberName", PSubtipoCoberturaE.nSubTipoCoberName);
                        cmd.Parameters.AddWithValue("@pcSitedsCode", PSubtipoCoberturaE.cSitedsCode);
                        cmd.Parameters.AddWithValue("@pcSitedsCode2", PSubtipoCoberturaE.cSitedsCode2);
                        cmd.Parameters.AddWithValue("@pdEstado", PSubtipoCoberturaE.dEstado);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@pcodllaveSubTipCober", ParameterDirection.Output, SqlDbType.VarChar, 20, PSubtipoCoberturaE.codllaveSubTipCober));
                        cnn.Open();

                        cmd.ExecuteNonQuery();
                        PSubtipoCoberturaE.codllaveSubTipCober = cmd.Parameters["@pcodllaveSubTipCober"].Value + "";
                        xResult = true;

                        cnn.Close();
                        cmd.Dispose();
                    }
                }

                return Convert.ToInt32(xResult);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
