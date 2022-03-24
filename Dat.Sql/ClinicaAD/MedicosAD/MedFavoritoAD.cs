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
    public class MedFavoritoAD
    {
        private MedFavoritoE LlenarEntidad(IDataReader dr, MedFavoritoE pMedFavoritoE)
        {
            MedFavoritoE oMedFavoritoE = new MedFavoritoE();
            switch (pMedFavoritoE.Orden)
            {
                case 1:
                    {
                        oMedFavoritoE.CodMedico = (string) dr["cod_medico"];
                        oMedFavoritoE.DniMedico = (string) dr["dni_medico"];
                        oMedFavoritoE.CodPaciente = (string) dr["cod_paciente"];
                        break;
                    }
            }

            return oMedFavoritoE;
        }

        public List<MedFavoritoE> Sp_MedFavorito_Consulta(MedFavoritoE pMedFavoritoE)
        {
            IDataReader dr;
            MedFavoritoE oMedFavoritoE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MedFavoritoE> oListar = new List<MedFavoritoE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MedFavorito_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_favorito", pMedFavoritoE.IdeFavorito);
                        cmd.Parameters.AddWithValue("@dni_medico", pMedFavoritoE.DniMedico);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMedFavoritoE.CodPaciente);
                        cmd.Parameters.AddWithValue("@orden", pMedFavoritoE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMedFavoritoE = LlenarEntidad(dr, pMedFavoritoE);
                            oListar.Add(oMedFavoritoE);
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

        public bool Sp_MedFavorito_Insert(MedFavoritoE pMedFavoritoE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MedFavorito_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@dni_medico", pMedFavoritoE.DniMedico);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMedFavoritoE.CodPaciente);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_favorito", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMedFavoritoE.IdeFavorito));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pMedFavoritoE.IdeFavorito = (int)cmd.Parameters["@ide_favorito"].Value;
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

        public bool Sp_MedFavorito_UpdatexCampo(MedFavoritoE pMedFavoritoE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MedFavorito_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_favorito", pMedFavoritoE.IdeFavorito);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pMedFavoritoE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pMedFavoritoE.Campo);
                        cmd.Parameters.AddWithValue("@dni_medico", pMedFavoritoE.DniMedico);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMedFavoritoE.CodPaciente);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
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
