using Ent.Sql.ClinicaE.MedicosE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.MedicosAD
{
    public class MedicoDatosMedisynAD
    {
        private MedicoDatosMedisynE LlenarEntidad(IDataReader dr, MedicoDatosMedisynE pMedicoDatosMedisynE)
        {
            MedicoDatosMedisynE oMedicoDatosMedisynE = new MedicoDatosMedisynE();
            switch (pMedicoDatosMedisynE.Orden)
            {
                case 1:
                    {
                        oMedicoDatosMedisynE.COD_PROF = (string) dr["COD_PROF"];
                        break;
                    }
            }

            return oMedicoDatosMedisynE;
        }

        public List<MedicoDatosMedisynE> Sp_MedicoDatosMedisyn_Consulta(string pNombresMedico)
        {
            IDataReader dr;
            MedicoDatosMedisynE oMedicoDatosMedisynE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MedicoDatosMedisynE> oListar = new List<MedicoDatosMedisynE>();

            MedicoDatosMedisynE pMedicoDatosMedisynE = new MedicoDatosMedisynE();
            pMedicoDatosMedisynE.Orden = 1;

            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MedicoDatosMedisyn_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@nombres", pNombresMedico);
                        cmd.Parameters.AddWithValue("@codprofesional", 0);
                        cmd.Parameters.AddWithValue("@codmedico", 0);
                        cmd.Parameters.AddWithValue("@orden", 1);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMedicoDatosMedisynE = LlenarEntidad(dr, pMedicoDatosMedisynE);
                            oListar.Add(oMedicoDatosMedisynE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
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
