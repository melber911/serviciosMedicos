using Ent.Sql.ClinicaE.EspecialidadesE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.EspecialidadesAD
{
    public class EspecialidadesAD
    {
        private EspecialidadesE LlenarEntidad(IDataReader dr, EspecialidadesE pEspecialidadesE)
        {
            EspecialidadesE oEspecialidadesE = new EspecialidadesE();
            switch (pEspecialidadesE.Orden)
            {
                case 4:
                    {
                        oEspecialidadesE.Codespecialidad = (string) dr["codespecialidad"];
                        oEspecialidadesE.CodEspMedisyn = (string) dr["cod_esp_medisyn"];
                        break;
                    }

                case 5:
                    {
                        oEspecialidadesE.Codespecialidad = (string)dr["codespecialidad"];
                        oEspecialidadesE.CodEspMedisyn = (string)dr["cod_esp_medisyn"];
                        break;
                    }

                case 6:
                    {
                        oEspecialidadesE.Codespecialidad = (string)dr["codespecialidad"];
                        oEspecialidadesE.CodEspMedisyn = (string) dr["cod_esp_medisyn"];
                        break;
                    }
            }
            return oEspecialidadesE;
        }

        public List<EspecialidadesE> Sp_Especialidades_Consulta(EspecialidadesE pEspecialidadesE)
        {
            IDataReader dr;
            EspecialidadesE oEspecialidadesE = null/* TODO Change to default(_) if this is not a reference type */;
            List<EspecialidadesE> oListar = new List<EspecialidadesE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Especialidades_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@buscar", pEspecialidadesE.Orden);
                        cmd.Parameters.AddWithValue("@key", pEspecialidadesE.Key);
                        cmd.Parameters.AddWithValue("@numerolineas", pEspecialidadesE.NumeroLineas);
                        cmd.Parameters.AddWithValue("@orden", pEspecialidadesE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oEspecialidadesE = LlenarEntidad(dr, pEspecialidadesE);
                            oListar.Add(oEspecialidadesE);
                        }
                        dr.Close(); // Se cierre la conexión.
                        dr.Dispose(); // Se liberan todos los recursos del data reader.
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.

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
