using Ent.Sql.ClinicaE.HospitalE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.HospitalAD
{
    public class HospitalvalidarAD
    {
        private HospitalValidarE LlenarEntidad(IDataReader dr, HospitalValidarE pHospitalvalidarE)
        {
            HospitalValidarE oHospitalvalidarE = new HospitalValidarE();
            switch (pHospitalvalidarE.Orden)
            {
                case 1:
                    {
                        oHospitalvalidarE.Descripcion = (string) dr["descripcion"];
                        oHospitalvalidarE.Script = (string) dr["script"];
                        oHospitalvalidarE.Idvalidarpadre = (int) dr["idvalidarpadre"];
                        oHospitalvalidarE.Idvalidar = (int) dr["idvalidar"];
                        break;
                    }
            }
            return oHospitalvalidarE;
        }

        public int Sp_HospitalValidarCobertura_Consulta(HospitalValidarE pHospitalvalidarE)
        {
            int xReturn;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_HospitalValidarCobertura_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        // cmd.Parameters.Add("@return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
                        cmd.Parameters.AddWithValue("@return", "").Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.AddWithValue("@tipoatencion", pHospitalvalidarE.TipoAtencion);
                        cmd.Parameters.AddWithValue("@codaseguradora", pHospitalvalidarE.CodAseguradora);
                        cmd.Parameters.AddWithValue("@codcobertura", pHospitalvalidarE.CodCobertura);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        xReturn = System.Convert.ToInt32(cmd.Parameters["@return"].Value);

                        cnn.Close();

                        return xReturn;
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
