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
    public class HospitalEncuestaAD
    {
        private HospitalEncuestaE LlenarEntidad(IDataReader dr, HospitalEncuestaE pHospitalEncuestaE)
        {
            HospitalEncuestaE oHospitalEncuestaE = new HospitalEncuestaE();
            switch (pHospitalEncuestaE.Orden)
            {
                case 1:
                    {
                        oHospitalEncuestaE.CodRespuesta = (int) dr["cod_respuesta"];
                        oHospitalEncuestaE.Respuesta = (string) dr["respuesta"];
                        oHospitalEncuestaE.Codlocal = (int) dr["codlocal"];
                        oHospitalEncuestaE.NombreLocal = (string) dr["nombre_local"];
                        oHospitalEncuestaE.CodAtencion = (string) dr["cod_atencion"];
                        oHospitalEncuestaE.FechaAtencion = (DateTime) dr["fecha_atencion"];
                        oHospitalEncuestaE.CodUsuario = (int) dr["cod_usuario"];
                        oHospitalEncuestaE.NombreUsuario = (string) dr["nombre_usuario"];
                        oHospitalEncuestaE.CodPaciente = (string) dr["cod_paciente"];
                        oHospitalEncuestaE.NombrePaciente = (string) dr["nombre_paciente"];
                        oHospitalEncuestaE.FechaEnvio = (DateTime) dr["fecha_envio"];
                        oHospitalEncuestaE.FechaEncuesta = (DateTime) dr["fecha_encuesta"];
                        oHospitalEncuestaE.Comentario = (string) dr["comentario"];
                        oHospitalEncuestaE.Estado = (string) dr["estado"];
                        oHospitalEncuestaE.CorreoPaciente = (string) dr["correo_paciente"];
                        oHospitalEncuestaE.CodEncuesta = (int) dr["cod_encuesta"];
                        break;
                    }
            }
            return oHospitalEncuestaE;
        }

        public List<HospitalEncuestaE> Sp_HospitalEncuesta_Consulta(HospitalEncuestaE pHospitalEncuestaE)
        {
            IDataReader dr;
            HospitalEncuestaE oHospitalEncuestaE = null/* TODO Change to default(_) if this is not a reference type */;
            List<HospitalEncuestaE> oListar = new List<HospitalEncuestaE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_HospitalEncuesta_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_encuesta", pHospitalEncuestaE.CodEncuesta);
                        cmd.Parameters.AddWithValue("@orden", pHospitalEncuestaE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oHospitalEncuestaE = LlenarEntidad(dr, pHospitalEncuestaE);
                            oListar.Add(oHospitalEncuestaE);
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

        public bool Sp_HospitalEncuesta_Insert(HospitalEncuestaE pHospitalEncuestaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_HospitalEncuesta_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pHospitalEncuestaE.CodAtencion);
                        cmd.Parameters.AddWithValue("@codpaciente", pHospitalEncuestaE.CodPaciente);
                        cmd.Parameters.AddWithValue("@codusuario", pHospitalEncuestaE.CodUsuario);
                        cmd.Parameters.AddWithValue("@codlocal", pHospitalEncuestaE.Codlocal);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codencuesta", ParameterDirection.InputOutput, SqlDbType.Int, 0, pHospitalEncuestaE.CodEncuesta));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pHospitalEncuestaE.CodEncuesta = (int)cmd.Parameters["@codencuesta"].Value;
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
