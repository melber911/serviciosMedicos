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
    public class HospitalAdmisionAD
    {
        private HospitalAdmisionE LlenarEntidad(IDataReader dr, HospitalAdmisionE pHospitaladmisionE)
        {
            HospitalAdmisionE oHospitaladmisionE = new HospitalAdmisionE();
            switch (pHospitaladmisionE.Orden)
            {
                case 1:
                    {
                        oHospitaladmisionE.Codatencion = (string) dr["codatencion"];
                        oHospitaladmisionE.Codtipo = (string) dr["codtipo"];
                        oHospitaladmisionE.Nombre = (string) dr["nombre"];
                        oHospitaladmisionE.Tipdocidentidad = (string) dr["tipdocidentidad"];
                        oHospitaladmisionE.Docidentidad = (string) dr["docidentidad"];
                        oHospitaladmisionE.Telefono = (string) dr["telefono"];
                        oHospitaladmisionE.ApellidoPat = (string) dr["apellido_pat"];
                        oHospitaladmisionE.ApellidoMat = (string) dr["apellido_mat"];
                        oHospitaladmisionE.Correo = (string) dr["correo"];
                        oHospitaladmisionE.Flagcorreo = (string) dr["flagcorreo"];
                        oHospitaladmisionE.Fecharegistro = (DateTime) dr["fecharegistro"];
                        oHospitaladmisionE.Fechamodificacion = (DateTime) dr["fechamodificacion"];
                        oHospitaladmisionE.Fecharespuestavalidacion = (DateTime) dr["fecharespuestavalidacion"];
                        oHospitaladmisionE.Nombres = (string) dr["nombres"];
                        break;
                    }
            }
            return oHospitaladmisionE;
        }

        public List<HospitalAdmisionE> Sp_Hospitaladmision_Consulta(HospitalAdmisionE pHospitaladmisionE)
        {
            IDataReader dr;
            HospitalAdmisionE oHospitaladmisionE = null/* TODO Change to default(_) if this is not a reference type */;
            List<HospitalAdmisionE> oListar = new List<HospitalAdmisionE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Hospitaladmision_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@orden", pHospitaladmisionE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oHospitaladmisionE = LlenarEntidad(dr, pHospitaladmisionE);
                            oListar.Add(oHospitaladmisionE);
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

        public bool Sp_HospitalAdmision_UpdatexCampo(HospitalAdmisionE pHospitaladmisionE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_HospitalAdmision_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@nuevo_valor", pHospitaladmisionE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pHospitaladmisionE.Campo);
                        cmd.Parameters.AddWithValue("@codatencion", pHospitaladmisionE.Codatencion);
                        cmd.Parameters.AddWithValue("@codtipo", pHospitaladmisionE.Codtipo);

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
