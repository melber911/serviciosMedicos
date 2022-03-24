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
    public class ExcepCarenciaAD
    {
        private ExcepCarenciaE LlenarEntidad(IDataReader dr, ExcepCarenciaE PExcepCarenciaE)
        {
            ExcepCarenciaE oExcepCarenciaE = new ExcepCarenciaE();
            // Select Case PDatosGenerales.OR .Orden
            // Case 1
            oExcepCarenciaE.cIafasCode = (string) dr["cIafasCode"];
            oExcepCarenciaE.cAsegCode = (string) dr["cAsegCode"];
            oExcepCarenciaE.cAutoCode = (string) dr["cAutoCode"];
            oExcepCarenciaE.cCoberCode = (string) dr["cCoberCode"];
            oExcepCarenciaE.cSubtipoCober = (string) dr["cSubtipoCober"];
            oExcepCarenciaE.cItem = (string) dr["cItem"];
            oExcepCarenciaE.cDxExcepCaren = (string) dr["cDxExcepCaren"];
            oExcepCarenciaE.nDxExcepCaren = (string) dr["nDxExcepCaren"];
            oExcepCarenciaE.dObsExcepCaren = (string) dr["dObsExcepCaren"];

            // End Select
            return oExcepCarenciaE;
        }

        public string Sp_ExcepCarencia_Insert(ref ExcepCarenciaE pExcepCarenciaE)
        {
            bool xResult = false;
            string s_codigo = "";
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_s10_logExcepCarencia_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cIafasCode", pExcepCarenciaE.cIafasCode);
                        cmd.Parameters.AddWithValue("@cAsegCode", pExcepCarenciaE.cAsegCode);
                        cmd.Parameters.AddWithValue("@cAutoCode", pExcepCarenciaE.cAutoCode);
                        cmd.Parameters.AddWithValue("@cCoberCode", pExcepCarenciaE.cCoberCode);
                        cmd.Parameters.AddWithValue("@cSubtipoCober", pExcepCarenciaE.cSubtipoCober);
                        cmd.Parameters.AddWithValue("@cItem", pExcepCarenciaE.cItem);
                        cmd.Parameters.AddWithValue("@cDxExcepCaren", pExcepCarenciaE.cDxExcepCaren);
                        cmd.Parameters.AddWithValue("@nDxExcepCaren", pExcepCarenciaE.nDxExcepCaren);
                        cmd.Parameters.AddWithValue("@dObsExcepCaren", pExcepCarenciaE.dObsExcepCaren);

                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codllave", ParameterDirection.Output, SqlDbType.VarChar, 50, pExcepCarenciaE.codllaveExpCar));
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        pExcepCarenciaE.codllaveExpCar = cmd.Parameters["@codllave"].Value + "";
                        s_codigo = pExcepCarenciaE.codllaveExpCar;
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
