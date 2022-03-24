using Ent.Sql.ClinicaE.DiagnosticoE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.DiaganosticoAD
{
    public class DiagnosticoxHospitalAD
    {
        private DiagnosticoxHospitalE LlenarEntidad(IDataReader dr, DiagnosticoxHospitalE pDiagnosticoxhospitalE)
        {
            DiagnosticoxHospitalE oDiagnosticoxhospitalE = new DiagnosticoxHospitalE();
            switch (pDiagnosticoxhospitalE.Orden)
            {
                case 1:
                    {
                        oDiagnosticoxhospitalE.Codatencion = (string)dr["codatencion"];
                        oDiagnosticoxhospitalE.Tipo = (string)dr["tipo"];
                        oDiagnosticoxhospitalE.Coddiagnostico = (string)dr["coddiagnostico"];
                        oDiagnosticoxhospitalE.Tipodiagnostico = (string)dr["tipodiagnostico"];
                        oDiagnosticoxhospitalE.Clasificaciondiagnostico = (string)dr["clasificaciondiagnostico"];
                        oDiagnosticoxhospitalE.FecRegistro = (DateTime)dr["fec_registro"];
                        break;
                    }
            }
            return oDiagnosticoxhospitalE;
        }

        public bool Sp_Diagxhospital_Insert(DiagnosticoxHospitalE pDiagnosticoxhospitalE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Diagxhospital_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pDiagnosticoxhospitalE.Codatencion);
                        cmd.Parameters.AddWithValue("@tipo", pDiagnosticoxhospitalE.Tipo);
                        cmd.Parameters.AddWithValue("@coddiagnostico", pDiagnosticoxhospitalE.Coddiagnostico);

                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else
                            return false;
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
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
