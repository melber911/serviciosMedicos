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
    public class EspecialidadxMedicoAD
    {
        private EspecialidadxMedicoE LlenarEntidad(IDataReader dr, EspecialidadxMedicoE pEspecialidadxmedicoE)
        {
            EspecialidadxMedicoE oEspecialidadxmedicoE = new EspecialidadxMedicoE();
            switch (pEspecialidadxmedicoE.Orden)
            {
                case 2:
                    {
                        oEspecialidadxmedicoE.CodEspecialidad = dr["codespecialidad"] + "";
                        oEspecialidadxmedicoE.Especialidad = dr["especialidad"] + "";
                        break;
                    }
            }
            return oEspecialidadxmedicoE;
        }

        public List<EspecialidadxMedicoE> Sp_EspecialidadxMed_Consulta(EspecialidadxMedicoE pEspecialidadxmedicoE)
        {
            IDataReader dr;
            EspecialidadxMedicoE oEspecialidadxmedicoE = null/* TODO Change to default(_) if this is not a reference type */;
            List<EspecialidadxMedicoE> oListar = new List<EspecialidadxMedicoE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_EspecialidadxMed_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@buscar", pEspecialidadxmedicoE.Buscar);
                        cmd.Parameters.AddWithValue("@key", pEspecialidadxmedicoE.Key);
                        cmd.Parameters.AddWithValue("@numerolineas", pEspecialidadxmedicoE.NumeroLineas);
                        cmd.Parameters.AddWithValue("@orden", pEspecialidadxmedicoE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oEspecialidadxmedicoE = LlenarEntidad(dr, pEspecialidadxmedicoE);
                            oListar.Add(oEspecialidadxmedicoE);
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
