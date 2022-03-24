using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using Ent.Sql.ClinicaE.ComprobantesE;
using System.Data;

namespace Dat.Sql.ClinicaAD.ComprobantesAD
{
    public class NotasAD
    {
        public int Sp_NotaCredito_GenerarAuto(ref NotasE pNotasE)
        {
            bool xResult = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_NotaCredito_GenerarAuto", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codcomprobante", pNotasE.CodComprobante);
                        cmd.Parameters.AddWithValue("@serieNC", pNotasE.SerieNC);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codNota", ParameterDirection.InputOutput, SqlDbType.Char, 11, pNotasE.CodNota));
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@msg", ParameterDirection.InputOutput, SqlDbType.VarChar, 500, pNotasE.MsgError));
                        cnn.Open();
                        cmd.ExecuteNonQuery();

                        pNotasE.CodNota = Strings.RTrim(cmd.Parameters["@codNota"].Value + "");
                        pNotasE.MsgError = cmd.Parameters["@msg"].Value + "";
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
