using Dat.Sql.ClinicaAD.UsuarioAD;
using Ent.Sql.ClinicaE.Mantenimiento;
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
    public class MedicosAD
    {

        private string ConStr;
        public MedicosAD(string ConStr)
        {
            this.ConStr = ConStr;
        }

        public void Disponse()
        {
            GC.SuppressFinalize(this);
        }


        private MedicosE LlenarEntidad(IDataReader dr, int pOrden)
        {
            MedicosE oMedicosE = new MedicosE();

            switch (pOrden)
            {
                case -1:
                    {
                        oMedicosE.CodMedico = (string) dr["codmedico"] + "";
                        oMedicosE.NombresMedico = (string)(dr["nombres"] + "").Trim();

                        oMedicosE.FlgTeleConsulta = (string) dr["flg_teleconsulta"] + "";
                        oMedicosE.FlgTeleConsulta = (string)(oMedicosE.FlgTeleConsulta == "" ? "false": "true");
                        oMedicosE.FlgPresencialJM = (string) dr["flg_presencial_jm"] + "";
                        oMedicosE.FlgPresencialJM = (string) (oMedicosE.FlgPresencialJM == ""? "false": "true");
                        oMedicosE.FlgPresencialCM = (string) dr["flg_presencial_cm"] + "";
                        oMedicosE.FlgPresencialCM = (string)(oMedicosE.FlgPresencialCM == ""? "false": "true");

                        oMedicosE.CodTipoConsulta = (string) dr["cod_tipo_consulta"] + "";

                        oMedicosE.CodProfMedisyn = (string) dr["cod_prof_medisyn"] + "";
                        oMedicosE.ColMedico = (string) dr["colmedico"] + "";
                        break;
                    }

                case 0:
                    {
                        oMedicosE.CodMedico = (string) dr["codmedico"] + "";
                        oMedicosE.NombresMedico = (string) (dr["nombres"] + "").Trim();

                        oMedicosE.FlgTeleConsulta = (string) dr["flg_teleconsulta"] + "";
                        oMedicosE.FlgTeleConsulta = (string)(oMedicosE.FlgTeleConsulta == ""? "false": "true");

                        oMedicosE.FlgPresencialJM = (string) dr["flg_presencial_jm"] + "";
                        oMedicosE.FlgPresencialJM = (string) (oMedicosE.FlgPresencialJM == ""? "false": "true");

                        oMedicosE.FlgPresencialCM = (string) dr["flg_presencial_cm"] + "";
                        oMedicosE.FlgPresencialCM = (string)(oMedicosE.FlgPresencialCM == ""? "false": "true");

                        oMedicosE.CodTipoConsulta = (string) dr["cod_tipo_consulta"] + "";

                        oMedicosE.CodProfMedisyn = (string) dr["cod_prof_medisyn"] + "";
                        oMedicosE.ColMedico = (string) dr["colmedico"] + "";

                        oMedicosE.MntTarifaParticular = (string)dr["mnt_tarifa_particular"]; //Interaction.IIf(Information.IsDBNull(dr["mnt_tarifa_particular"]) == true, 0, dr["mnt_tarifa_particular"]);
                        oMedicosE.DscObservacionSubEspecialidad = (string) dr["dsc_observacion_sub_especialidad"] + "";
                        oMedicosE.DscEmail = (string)(dr["email"] + "").Trim();
                        break;
                    }

                case 2:
                    {
                        oMedicosE.CodMedico = (string) dr["codmedico"] + "";
                        oMedicosE.NombresMedico = (string)(dr["nombres"] + "").Trim();
                        // oMedicosE.DocIdentidad = ""

                        // oMedicosE.ColMedico = dr("colmedico")
                        oMedicosE.FlgTeleConsulta = (string) dr["flg_teleconsulta"] + "";
                        oMedicosE.FlgTeleConsulta = (string)(oMedicosE.FlgTeleConsulta == ""? "false": "true");

                        oMedicosE.FlgPresencialJM = (string) dr["flg_presencial_jm"] + "";
                        oMedicosE.FlgPresencialJM = (string)(oMedicosE.FlgPresencialJM == ""? "false": "true");

                        oMedicosE.FlgPresencialCM = (string) dr["flg_presencial_cm"] + "";
                        oMedicosE.FlgPresencialCM = (string) (oMedicosE.FlgPresencialCM == ""? "false": "true");

                        oMedicosE.CodTipoConsulta = (string) dr["cod_tipo_consulta"] + "";

                        oMedicosE.CodProfMedisyn = (string) dr["cod_prof_medisyn"] + "";
                        break;
                    }

                case 11:
                    {
                        oMedicosE.CodMedico = (string) dr["codmedico"] + "";
                        oMedicosE.CodProfMedisyn = (string) dr["cod_prof_medisyn"] + "";
                        oMedicosE.CodTipoConsulta = (string) dr["cod_tipo_consulta"] + "";
                        oMedicosE.DscObservacionSubEspecialidad = (string) dr["dsc_observacion_sub_especialidad"] + "";
                        oMedicosE.DscTituloTarifa = (string) dr["dsc_titulo_tarifa"] + "";
                        oMedicosE.MntTarifaParticular = (string) dr["mnt_tarifa_particular"];
                        oMedicosE.TipMoneda = (string) dr["tip_moneda"] + "";
                        oMedicosE.TipoConsultaMedica = (string) dr["cod_tipo_consulta"] + "";
                        break;
                    }

                case 12:
                    {
                        oMedicosE.CodMedico = (string) dr["codmedico"] + "";
                        oMedicosE.CodProfMedisyn = (string) dr["cod_prof_medisyn"] + "";
                        break;
                    }

                case 14:
                    {
                        oMedicosE.CodMedico = (string) dr["codmedico"] + "";
                        oMedicosE.CodProfMedisyn = (string) dr["cod_prof_medisyn"] + "";
                        break;
                    }

                case 15:
                    {
                        oMedicosE.CodMedico = (string) dr["codmedico"] + "";
                        oMedicosE.CodProfMedisyn = (string) dr["cod_prof_medisyn"] + "";
                        break;
                    }

                case 17:
                    {
                        oMedicosE.CodMedico = (string) dr["codmedico"] + "";
                        oMedicosE.NombresMedico = (string)(dr["nombres"] + "").Trim();
                        oMedicosE.DocIdentidad = (string)(dr["docidentidad"] + "").Trim();
                        break;
                    }

                case 18:
                    {
                        oMedicosE.CodMedico = (string) dr["codmedico"] + "";
                        break;
                    }
            }

            return oMedicosE;
        }

        public List<MedicosE> Sp_Medicos_Consulta(MedicosE pMedicosE)
        {
            IDataReader dr;
            MedicosE oMedicosE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MedicosE> oListar = new List<MedicosE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Medicos_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@buscar", pMedicosE.Buscar);
                        cmd.Parameters.AddWithValue("@key", pMedicosE.Key);
                        cmd.Parameters.AddWithValue("@numerolineas", pMedicosE.NumeroLineas);
                        cmd.Parameters.AddWithValue("@orden", pMedicosE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMedicosE = LlenarEntidad(dr, pMedicosE.Orden);
                            oListar.Add(oMedicosE);
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

        public bool Sp_Medicos_Update(MedicosE objMedicosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Medicos_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@campo", objMedicosE.Campo);
                        cmd.Parameters.AddWithValue("@codigo", objMedicosE.CodMedico);
                        cmd.Parameters.AddWithValue("@nuevovalor", objMedicosE.NuevoValor);
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

        public bool Sp_Medicos_Update_Agendamiento(MedicosE pMedicosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Medicos_Update_Agendamiento", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codmedico", pMedicosE.CodMedico);

                        cmd.Parameters.AddWithValue("@cod_prof_medisyn", pMedicosE.CodProfMedisyn);
                        cmd.Parameters.AddWithValue("@cod_tipo_consulta", pMedicosE.CodTipoConsulta);
                        cmd.Parameters.AddWithValue("@flg_teleconsulta", pMedicosE.FlgTeleConsulta);
                        cmd.Parameters.AddWithValue("@flg_presencial_jm", pMedicosE.FlgPresencialJM);
                        cmd.Parameters.AddWithValue("@flg_presencial_cm", pMedicosE.FlgPresencialCM);
                        cmd.Parameters.AddWithValue("@mnt_tarifa_particular", pMedicosE.MntTarifaParticular);
                        cmd.Parameters.AddWithValue("@dsc_observacion_sub_especialidad", pMedicosE.DscObservacionSubEspecialidad);
                        cmd.Parameters.AddWithValue("@email", pMedicosE.DscEmail);
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

        public bool GuardarMedicosMantenimiento(MedicoContratoRequestE pMedicosE)
        {
           
        

                using (var Ado = new SQLServer(ConStr))
                    try
                    {
                        Ado.BeginTransaction();
                        var Parameters = new SqlParameter[]
                        {
                         new SqlParameter{ParameterName="@cod_medico",SqlDbType=SqlDbType.VarChar,Size=100,SqlValue=pMedicosE.cod_medico},
                         new SqlParameter{ParameterName="@cod_sede",SqlDbType=SqlDbType.VarChar,Size=100,SqlValue=pMedicosE.cod_sede},
                         new SqlParameter{ParameterName="@flg_forma_pago",SqlDbType=SqlDbType.VarChar,Size=100,SqlValue=pMedicosE.flg_forma_pago},
                         new SqlParameter{ParameterName="@mnt_mensual",SqlDbType=SqlDbType.Float,SqlValue=pMedicosE.mnt_mensual},
                         new SqlParameter{ParameterName="@fec_inicio",SqlDbType=SqlDbType.DateTime,SqlValue=pMedicosE.fec_inicio},
                         new SqlParameter{ParameterName="@fec_fin",SqlDbType=SqlDbType.DateTime,SqlValue=pMedicosE.fec_fin},
                         new SqlParameter{ParameterName="@usr_registro",SqlDbType=SqlDbType.VarChar,Size=100,SqlValue=pMedicosE.usr_registro},
                         new SqlParameter{ParameterName="@flg_estado",SqlDbType=SqlDbType.VarChar,Size=100,SqlValue=pMedicosE.flg_estado},


                        };
                        Ado.ExecNonQueryProcTransaction("sp_med_contrato_alquiler_Insert", Parameters);
                        Ado.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Ado.Rollback();
                        throw ex;
                    }

            
          
        }
    }
}
