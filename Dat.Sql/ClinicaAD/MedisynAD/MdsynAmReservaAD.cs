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
    public class MdsynAmReservaAD
    {
        private MdsynAmReservaE LlenarEntidad(IDataReader dr, MdsynAmReservaE pMdsynAmReservaE)
        {
            MdsynAmReservaE oMdsynAmReservaE = new MdsynAmReservaE();
            switch (pMdsynAmReservaE.Orden)
            {
                case "1":
                    {
                        break;
                    }

                case "2":
                    {
                        oMdsynAmReservaE.IdePagosBot = (int) dr["ide_pagos_bot"];
                        oMdsynAmReservaE.IdeReserva = (long) dr["ide_reserva"];
                        oMdsynAmReservaE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];

                        oMdsynAmReservaE.FecRegistro = (DateTime) dr["fec_registro"];
                        oMdsynAmReservaE.RutPaciente = (string) dr["rut_paciente"];

                        oMdsynAmReservaE.NombresPaciente = (string) dr["paciente"];
                        oMdsynAmReservaE.NombresMedico = (string) dr["medico"];
                        oMdsynAmReservaE.Telefono = (string) dr["telefono"];
                        oMdsynAmReservaE.Telefono2 = (string) dr["telefono2"];
                        oMdsynAmReservaE.DscSede = (string) dr["dsc_sede"];

                        oMdsynAmReservaE.FecCita = (DateTime) dr["fec_cita"];

                        oMdsynAmReservaE.DscEspecialidad = (string) dr["dsc_especialidad"];
                        oMdsynAmReservaE.DscTipoConsultaMedica = (string) dr["dsc_tipo_consulta_medica"];

                        oMdsynAmReservaE.UsrRegistroPlataforma = (string) dr["usr_registro_plataforma"];
                        break;
                    }

                case "3":
                    {
                        oMdsynAmReservaE.IdeReserva = (long) dr["ide_reserva"];
                        oMdsynAmReservaE.CodAtencion = (string) dr["codatencion"];
                        oMdsynAmReservaE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];
                        oMdsynAmReservaE.FecCita = (DateTime) dr["fec_cita"];
                        break;
                    }

                case "4":
                    {
                        // oMdsynAmReservaE.IdePagosBot = dr("ide_pagos_bot")
                        oMdsynAmReservaE.IdeReserva = (long) dr["ide_reserva"];
                        oMdsynAmReservaE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];

                        // oMdsynAmReservaE.FecRegistro = dr("fec_registro")
                        oMdsynAmReservaE.CodPaciente = (string) dr["cod_paciente"];
                        oMdsynAmReservaE.RutPaciente = (string) dr["rut_paciente"];

                        oMdsynAmReservaE.NombresPaciente = (string) dr["paciente"];
                        oMdsynAmReservaE.NombresMedico = (string) dr["dsc_medico"];

                        oMdsynAmReservaE.DscSede = (string) dr["sede"];
                        oMdsynAmReservaE.FecCita = (DateTime) dr["fec_cita"];
                        oMdsynAmReservaE.CodAtencion = (string) dr["cod_atencion"];

                        oMdsynAmReservaE.DscEspecialidad = (string) dr["dsc_especialidad"];
                        oMdsynAmReservaE.DscTipoConsultaMedica = (string) dr["dsc_tipo_consulta_medica"];
                        oMdsynAmReservaE.CodTipoPago = (string) dr["cod_tipo_pago"];
                        break;
                    }

                case "5":
                    {
                        // oMdsynAmReservaE.IdePagosBot = dr("ide_pagos_bot")
                        oMdsynAmReservaE.IdeReserva = (long) dr["ide_reserva"];
                        oMdsynAmReservaE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];

                        // oMdsynAmReservaE.FecRegistro = dr("fec_registro")
                        oMdsynAmReservaE.CodPaciente = (string) dr["cod_paciente"];
                        oMdsynAmReservaE.RutPaciente = (string) dr["rut_paciente"];

                        oMdsynAmReservaE.NombresPaciente = (string) dr["paciente"];
                        oMdsynAmReservaE.NombresMedico = (string) dr["dsc_medico"];

                        oMdsynAmReservaE.DscSede = (string) dr["sede"];

                        oMdsynAmReservaE.FecCita = (DateTime) dr["fec_cita"];

                        // oMdsynAmReservaE.DscEspecialidad = dr("dsc_especialidad")
                        oMdsynAmReservaE.DscTipoConsultaMedica = (string) dr["dsc_tipo_consulta_medica"];
                        break;
                    }

                case "7":
                    {
                        oMdsynAmReservaE.IdeReserva = (int) dr["ide_reserva"];
                        oMdsynAmReservaE.CodAtencion = (string) dr["cod_atencion"];
                        // oMdsynAmReservaE.CodPaciente = dr("cod_paciente")
                        // oMdsynAmReservaE.NombresPaciente = dr("paciente")

                        // oMdsynAmReservaE. = dr("nro_identidad")
                        // oMdsynAmReservaE. = dr("cod_aseguradora")
                        // oMdsynAmReservaE. = dr("dsc_aseguradora")
                        oMdsynAmReservaE.DscSede = (string) dr["dsc_sede"];
                        oMdsynAmReservaE.FecCita = (DateTime) dr["fec_cita"];
                        oMdsynAmReservaE.FecRegistro = (DateTime) dr["fec_registro"];

                        // oMdsynAmReservaE. = dr("fec_reserva")
                        // oMdsynAmReservaE. = dr("num_autorizacionsiteds")
                        // oMdsynAmReservaE.CodMedico = dr("cod_medico")
                        // oMdsynAmReservaE.NombresMedico = dr("dsc_medico")
                        // oMdsynAmReservaE. = dr("flg_recepcion")
                        // oMdsynAmReservaE. = dr("fec_recepcion")

                        // oMdsynAmReservaE.CodEspecialidad = dr("codespecialidad")
                        // oMdsynAmReservaE.DscTipoConsultaMedica = dr("dsc_tipo_consulta_medica")

                        oMdsynAmReservaE.EstConsultaMedica = (string) dr["est_consulta_medica"];
                        oMdsynAmReservaE.CodTipoPago = (string) dr["cod_tipo_pago"];
                        break;
                    }

                case "8":
                    {
                        oMdsynAmReservaE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];
                        oMdsynAmReservaE.FecRegistro = (DateTime) dr["fec_registro"];
                        oMdsynAmReservaE.RutPaciente = (string) dr["rut_paciente"];

                        oMdsynAmReservaE.NombresPaciente = (string) dr["paciente"];
                        oMdsynAmReservaE.NombresMedico = (string) dr["medico"];
                        oMdsynAmReservaE.CodAtencion = (string) dr["cod_atencion"];

                        oMdsynAmReservaE.FecCita = (DateTime) dr["fec_cita"];
                        oMdsynAmReservaE.DscSede = (string) dr["dsc_sede"];
                        oMdsynAmReservaE.DscTipoConsultaMedica = (string) dr["dsc_tipo_consulta_medica"];

                        oMdsynAmReservaE.DscEspecialidad = (string) dr["dsc_especialidad"];

                        oMdsynAmReservaE.CodEspecialidad = (string) dr["cod_especialidad"];
                        oMdsynAmReservaE.CodTipoPago = (string) dr["cod_tipo_pago"];
                        oMdsynAmReservaE.DscTipoPago = (string) dr["dsc_tipo_pago"];
                        oMdsynAmReservaE.UsrRegistroPlataforma = (string) dr["usr_registro_plataforma"];

                        oMdsynAmReservaE.Telefono = (string) dr["telefono"];
                        oMdsynAmReservaE.Email = (string) dr["email"];

                        oMdsynAmReservaE.FecAnulacion = (string) dr["fec_reserva_anulada"];
                        oMdsynAmReservaE.Moneda = (string) dr["moneda"];
                        oMdsynAmReservaE.Monto = (string) dr["cnt_montopago"];
                        oMdsynAmReservaE.NroOperacion = (string) dr["nro_operacion"];
                        break;
                    }

                case "9":
                    {
                        oMdsynAmReservaE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];
                        oMdsynAmReservaE.CodAtencion = (string) dr["cod_atencion"];
                        oMdsynAmReservaE.CodTipoPago = (string) dr["cod_tipo_pago"];
                        oMdsynAmReservaE.FlgReprogramar = (string) dr["flg_reprogramar"];
                        break;
                    }

                case "10":
                    {
                        oMdsynAmReservaE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];
                        oMdsynAmReservaE.EstPago = (string) dr["est_pago"];
                        break;
                    }
            }
            return oMdsynAmReservaE;
        }

        public List<MdsynAmReservaE> Sp_MdsynAmReserva_Consulta(MdsynAmReservaE pMdsynAmReservaE)
        {
            IDataReader dr;
            MdsynAmReservaE oMdsynAmReservaE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MdsynAmReservaE> oListar = new List<MdsynAmReservaE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAmReserva_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_reserva", pMdsynAmReservaE.IdeReserva);
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynAmReservaE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@fec_inicio", pMdsynAmReservaE.FecInicio);
                        cmd.Parameters.AddWithValue("@fec_fin", pMdsynAmReservaE.FecFin);
                        cmd.Parameters.AddWithValue("@cod_sede", pMdsynAmReservaE.CodSede);
                        cmd.Parameters.AddWithValue("@nombrespaciente", pMdsynAmReservaE.NombresPaciente);

                        cmd.Parameters.AddWithValue("@doc_identidad", pMdsynAmReservaE.RutPaciente);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMdsynAmReservaE.CodPaciente);
                        cmd.Parameters.AddWithValue("@orden", pMdsynAmReservaE.Orden);

                        cmd.Parameters.AddWithValue("@cod_tipo_consulta_medica", pMdsynAmReservaE.CodTipoConsultaMedica);
                        cmd.Parameters.AddWithValue("@cod_tipo_pago", pMdsynAmReservaE.CodTipoPago);
                        cmd.Parameters.AddWithValue("@cod_atencion", pMdsynAmReservaE.CodAtencion);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMdsynAmReservaE = LlenarEntidad(dr, pMdsynAmReservaE);
                            oListar.Add(oMdsynAmReservaE);
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

        public DataTable Sp_MdsynAmReserva_Consulta_DataTable(MdsynAmReservaE pMdsynAmReservaE)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAmReserva_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_reserva", pMdsynAmReservaE.IdeReserva);
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynAmReservaE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@fec_inicio", pMdsynAmReservaE.FecInicio);
                        cmd.Parameters.AddWithValue("@fec_fin", pMdsynAmReservaE.FecFin);
                        cmd.Parameters.AddWithValue("@cod_sede", pMdsynAmReservaE.CodSede);
                        cmd.Parameters.AddWithValue("@nombrespaciente", pMdsynAmReservaE.NombresPaciente);
                        cmd.Parameters.AddWithValue("@orden", pMdsynAmReservaE.Orden);
                        cnn.Open();
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(dt);

                        ad.Dispose();
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_MdsynAmReserva_Insert(MdsynAmReservaE pMdsynAmReservaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAmReserva_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynAmReservaE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@cod_sede", pMdsynAmReservaE.CodSede);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMdsynAmReservaE.CodPaciente);
                        cmd.Parameters.AddWithValue("@rut_paciente", pMdsynAmReservaE.RutPaciente);
                        cmd.Parameters.AddWithValue("@cod_medico", pMdsynAmReservaE.CodMedico);
                        cmd.Parameters.AddWithValue("@cod_prof_medico", pMdsynAmReservaE.CodProfMedico);
                        cmd.Parameters.AddWithValue("@cod_especialidad", pMdsynAmReservaE.CodEspecialidad);
                        cmd.Parameters.AddWithValue("@fec_cita", pMdsynAmReservaE.FecCita);
                        cmd.Parameters.AddWithValue("@usr_registro_plataforma", pMdsynAmReservaE.UsrRegistroPlataforma);
                        cmd.Parameters.AddWithValue("@est_consulta_medica", pMdsynAmReservaE.EstConsultaMedica);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_reserva", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMdsynAmReservaE.IdeReserva.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pMdsynAmReservaE.IdeReserva = (long)cmd.Parameters["@ide_reserva"].Value;
                            return true;
                        }
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

        public bool Sp_MdsynAmReserva_Update(MdsynAmReservaE pMdsynAmReservaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAmReserva_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynAmReservaE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@cod_sede", pMdsynAmReservaE.CodSede);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMdsynAmReservaE.CodPaciente);
                        cmd.Parameters.AddWithValue("@rut_paciente", pMdsynAmReservaE.RutPaciente);
                        cmd.Parameters.AddWithValue("@cod_medico", pMdsynAmReservaE.CodMedico);

                        cmd.Parameters.AddWithValue("@cod_prof_medico", pMdsynAmReservaE.CodProfMedico);
                        cmd.Parameters.AddWithValue("@cod_especialidad", pMdsynAmReservaE.CodEspecialidad);
                        cmd.Parameters.AddWithValue("@fec_cita", pMdsynAmReservaE.FecCita);
                        cmd.Parameters.AddWithValue("@usr_registro_plataforma", pMdsynAmReservaE.UsrRegistroPlataforma);

                        cmd.Parameters.AddWithValue("@cnt_montopago", pMdsynAmReservaE.CntMontopago);
                        cmd.Parameters.AddWithValue("@cod_tipo_pago", pMdsynAmReservaE.CodTipoPago);
                        cmd.Parameters.AddWithValue("@ide_reserva", pMdsynAmReservaE.IdeReserva);

                        cmd.Parameters.AddWithValue("@usr_reserva_anulada", pMdsynAmReservaE.UsrReservaAnulada);
                        cmd.Parameters.AddWithValue("@flg_reserva_anulada", pMdsynAmReservaE.FlgReservaAnulada);
                        cmd.Parameters.AddWithValue("@orden", pMdsynAmReservaE.Orden);
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

        public bool Sp_MdsynAmReserva_UpdatexCampo(MdsynAmReservaE pMdsynAmReservaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAmReserva_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_reserva", pMdsynAmReservaE.IdeReserva);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pMdsynAmReservaE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pMdsynAmReservaE.Campo);
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

        public bool Sp_MdsynAmReserva_Delete(MdsynAmReservaE pMdsynAmReservaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynAmReserva_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_reserva", pMdsynAmReservaE.IdeReserva);
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

        public bool Sp_Mdsyn_Cita_Monto_Cero(MdsynAmReservaE pMdsynAmReservaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Mdsyn_Cita_Monto_Cero", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynAmReservaE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@cod_atencion", pMdsynAmReservaE.CodAtencion);
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

        public bool Sp_Mdsyn_Reprogramar_Citas(MdsynAmReservaE pMdsynAmReservaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Mdsyn_Reprogramar_Citas", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_correl_reserva_anterior", pMdsynAmReservaE.IdeCorrelReservaBack);
                        cmd.Parameters.AddWithValue("@ide_correl_reserva_nuevo", pMdsynAmReservaE.IdeCorrelReservaNew);
                        cmd.Parameters.AddWithValue("@usr_reprograma", pMdsynAmReservaE.UsrReprograma);
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

        public bool Sp_PresotorAmbulatorio_Insert(MdsynAmReservaE pMdsynAmReservaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_PresotorAmbulatorio_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pMdsynAmReservaE.CodAtencion);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codpresotor", ParameterDirection.InputOutput, SqlDbType.VarChar, 20, pMdsynAmReservaE.CodPresotor));
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
