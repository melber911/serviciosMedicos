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
    public class MdsynReservalogErrorAD
    {
        public bool Sp_MdsynReservalogError_Insert(MdsynReservalogErrorE pMdsynReservalogerrorE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynReservalogerror_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@dsc_mensaje", pMdsynReservalogerrorE.DscMensaje);
                        cmd.Parameters.AddWithValue("@dsc_pc", pMdsynReservalogerrorE.DscPC);
                        cmd.Parameters.AddWithValue("@dsc_ip", pMdsynReservalogerrorE.DscIP);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_reservalogerror", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMdsynReservalogerrorE.IdeReservalogerror.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pMdsynReservalogerrorE.IdeReservalogerror = (int)cmd.Parameters["@ide_reservalogerror"].Value;
                            return true;
                        }
                        else
                            return false;
                        cnn.Close();
                        cmd.Dispose();
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
