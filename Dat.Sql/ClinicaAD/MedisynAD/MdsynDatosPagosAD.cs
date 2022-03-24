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
    public class MdsynDatosPagosAD
    {
        private MdsynDatosPagosE LlenarEntidad(IDataReader dr, MdsynDatosPagosE pMdsynDatospagosE)
        {
            MdsynDatosPagosE oMdsynDatospagosE = new MdsynDatosPagosE();
            {
                var withBlock = oMdsynDatospagosE;
                switch (pMdsynDatospagosE.Orden)
                {
                    case 1:
                        {
                            withBlock.IdeCorrelreserva = (int) dr["ide_correlreserva"];
                            break;
                        }

                    case 2:
                    case 100:
                        {
                            withBlock.IdeDatospagos = (int) dr["ide_datospagos"];
                            withBlock.CodAsegurado = (string) dr["cod_asegurado"];
                            withBlock.TipDocumento = (string) dr["tip_documento"];
                            withBlock.NumDocumento = (string) dr["num_documento"];
                            withBlock.TipPrt = (string) dr["tip_prt"];
                            withBlock.TipParentesco = (string) dr["tip_parentesco"];
                            withBlock.NroPlan = (string) dr["nro_plan"];
                            withBlock.TipDocempresa = (string) dr["tip_docempresa"];
                            withBlock.NumDocempresa = (string) dr["num_docempresa"];
                            withBlock.FecNacimiento = (string) dr["fec_nacimiento"];
                            withBlock.FecIniciovigencia = (string) dr["fec_iniciovigencia"];
                            withBlock.FecAfilicacion = (string) dr["fec_afilicacion"];
                            withBlock.CodCobertura = (string) dr["cod_cobertura"];
                            withBlock.CoPagofijo = (decimal) dr["co_pagofijo"];
                            withBlock.CoPagovariable = (decimal) dr["co_pagovariable"];
                            withBlock.TipMoneda = (string) dr["tip_moneda"];
                            withBlock.IdeCorrelreserva = (int) dr["ide_correlreserva"];
                            withBlock.CodPaciente = (string) dr["cod_paciente"];
                            withBlock.CodPacienteTitular = (string) dr["cod_paciente_titular"];
                            withBlock.TipAtencion = (string) dr["tip_atencion"];
                            withBlock.CodAseguradora = (string) dr["cod_aseguradora"];
                            withBlock.NombresPacientes = (string) dr["paciente"] + "";
                            withBlock.NombresPacienteTitular = (string) dr["paciente_titular"] + "";
                            withBlock.DscAseguradora = (string) dr["dsc_aseguradora"] + "";
                            withBlock.Sexo = (string) dr["sexo"] + "";
                            withBlock.CardCode = (string) dr["cardcode"] + "";
                            withBlock.DscCorreo = (string) dr["email"] + "";
                            withBlock.CodCia = (string) dr["cod_cia"] + "";
                            withBlock.CodSede = (string) dr["cod_sede"] + "";
                            withBlock.CodSunasa = (string) dr["cod_sede_sunasa"] + "";
                            withBlock.CodIAFAS = (string) dr["cod_iafas"] + "";
                            withBlock.DscObservaciones = (string) dr["dsc_observaciones"] + "";

                            withBlock.CodProfMedico = (string) dr["cod_profmedico"] + "";
                            withBlock.CodMedico = (string) dr["cod_medico"] + "";
                            // .DscObservaciones = dr("dsc_observaciones") + ""
                            withBlock.Direccion = (string) dr["direccion"] + "";
                            withBlock.NroOperacion = (string) dr["nro_operacion"] + "";
                            withBlock.CodEntidad = (string) dr["cod_entidad"] + "";
                            withBlock.FecCita = (string) dr["fec_cita"];
                            withBlock.CodEspecialidad = (string) dr["cod_especialidad"] + "";
                            withBlock.EstProcesoAtencion = (int) dr["est_proceso_atencion"];
                            withBlock.CodAtencion = (string) dr["cod_atencion"];
                            withBlock.CodLiquidacion = (string) dr["cod_liquidacion"];
                            withBlock.CodComprobante = (string) dr["cod_comprobante"];
                            withBlock.EstConsultaMedica = (string) dr["est_consulta_medica"];

                            withBlock.ApPaternoPaciente = (string) dr["appaterno"];
                            withBlock.ApMaternoPaciente = (string) dr["apmaterno"];
                            withBlock.NombrePaciente = (string) dr["nombre"];

                            withBlock.Comp_TipoComprobante = (string) dr["cod_tipo_comprobante"];
                            withBlock.Comp_TipDocIdentidad = (string) dr["tip_doc_identidad"];
                            withBlock.Comp_RutDocIdentidad = (string) dr["doc_identidad"];
                            withBlock.Comp_DscTabla = (string) dr["dsc_tabla"];
                            withBlock.Comp_Correo = (string) dr["dsc_correo_comprobante"];
                            withBlock.NombresComprobante = (string) dr["nombres_comprobante"];
                            withBlock.CodTipoConsultaMedica = (string) dr["cod_tipo_consulta_medica"];
                            break;
                        }

                    case 3:
                        {
                            withBlock.CodAtencion = (string)(dr["cod_atencion"] + "").Trim();
                            withBlock.NombresPacientes = (string)(dr["paciente"] + "").Trim();
                            withBlock.CodComprobante = (string)(dr["codcomprobante"] + "").Trim();
                            withBlock.FechaQR = (string) dr["fechaqr"];
                            break;
                        }

                    case 6:
                        {
                            withBlock.IdeDatospagos = (int) dr["ide_datospagos"];
                            withBlock.IdeCorrelreserva = (int) dr["ide_correlreserva"];
                            withBlock.CodComprobante = (string)(dr["cod_comprobante"] + "").Trim();
                            withBlock.CodAtencion = (string)(dr["cod_atencion"] + "").Trim();
                            withBlock.CodLiquidacion = (string)(dr["cod_liquidacion"] + "").Trim();
                            withBlock.CoPagofijo = (decimal) dr["co_pagofijo"];
                            break;
                        }

                    case 7:
                        {
                            withBlock.IdeDatospagos = (int) dr["ide_datospagos"];
                            withBlock.IdeCorrelreserva = (int) dr["ide_correlreserva"];
                            withBlock.FlgRecepcion = (string) dr["flg_recepcion"];
                            break;
                        }

                    case 8:
                        {
                            // .NumDocumento = dr("num_documento")
                            // .CodProfMedico = dr("cod_profmedico")
                            withBlock.CodMedico = (string) dr["codmedico"];
                            withBlock.EstPagoExitoso = (string) dr["est_pagoexitoso"];
                            // .IdeCorrelreserva = dr("ide_correlreserva")
                            withBlock.CodTipoConsultaMedica = (string) dr["cod_tipo_consulta_medico"];
                            withBlock.PuedePagarCita = (string) dr["puede_pagar_cita"];

                            withBlock.SedeFisica = (string) dr["cod_sede_fisica"];
                            withBlock.TipoAtencion = (string) dr["tipo_atencion"];
                            withBlock.DscSede = (string) dr["dsc_sede"];
                            withBlock.Reprogramar = (string) dr["flg_reprogramar"];
                            break;
                        }

                    case 9:
                        {
                            withBlock.IdeDatospagos = (int) dr["ide_datospagos"];
                            withBlock.CodAsegurado = (string) dr["cod_asegurado"];
                            withBlock.TipDocumento = (string) dr["tip_documento"];
                            withBlock.NumDocumento = (string) dr["num_documento"];
                            withBlock.TipPrt = (string) dr["tip_prt"];
                            withBlock.TipParentesco = (string) dr["tip_parentesco"];
                            withBlock.NroPlan = (string) dr["nro_plan"];
                            withBlock.TipDocempresa = (string) dr["tip_docempresa"];
                            withBlock.NumDocempresa = (string) dr["num_docempresa"];
                            withBlock.FecNacimiento = (string) dr["fec_nacimiento"];
                            withBlock.FecIniciovigencia = (string) dr["fec_iniciovigencia"];
                            withBlock.FecAfilicacion = (string) dr["fec_afilicacion"];
                            withBlock.CodCobertura = (string) dr["cod_cobertura"];
                            withBlock.CoPagofijo = (decimal) dr["co_pagofijo"];
                            withBlock.CoPagovariable = (decimal) dr["co_pagovariable"];
                            withBlock.TipMoneda = (string) dr["tip_moneda"];
                            withBlock.IdeCorrelreserva = (int) dr["ide_correlreserva"];
                            withBlock.CodPaciente = (string) dr["cod_paciente"];
                            withBlock.CodPacienteTitular = (string) dr["cod_paciente_titular"];
                            withBlock.TipAtencion = (string) dr["tip_atencion"];
                            withBlock.CodAseguradora = (string) dr["cod_aseguradora"];
                            withBlock.NombresPacientes = (string) dr["paciente"] + "";
                            withBlock.NombresPacienteTitular = (string) dr["paciente_titular"] + "";
                            withBlock.DscAseguradora = (string) dr["dsc_aseguradora"] + "";
                            withBlock.Sexo = (string) dr["sexo"] + "";
                            withBlock.CardCode = (string) dr["cardcode"] + "";
                            withBlock.DscCorreo = (string) dr["email"] + "";
                            withBlock.CodCia = (string) dr["cod_cia"] + "";
                            withBlock.CodSede = (string) dr["cod_sede"] + "";
                            withBlock.CodSunasa = (string) dr["cod_sede_sunasa"] + "";
                            withBlock.CodIAFAS = (string) dr["cod_iafas"] + "";
                            withBlock.DscObservaciones = (string) dr["dsc_observaciones"] + "";

                            withBlock.CodProfMedico = (string) dr["cod_profmedico"] + "";
                            withBlock.CodMedico = (string) dr["cod_medico"] + "";
                            // .DscObservaciones = dr("dsc_observaciones") + ""
                            withBlock.Direccion = (string) dr["direccion"] + "";
                            withBlock.NroOperacion = (string) dr["nro_operacion"] + "";
                            withBlock.CodEntidad = (string) dr["cod_entidad"] + "";
                            withBlock.FecCita = (string) dr["fec_cita"];
                            withBlock.CodEspecialidad = (string) dr["cod_especialidad"] + "";
                            withBlock.EstProcesoAtencion = (int) dr["est_proceso_atencion"];
                            withBlock.CodAtencion = (string) dr["cod_atencion"];
                            withBlock.CodLiquidacion = (string) dr["cod_liquidacion"];
                            withBlock.CodComprobante = (string) dr["cod_comprobante"];
                            withBlock.EstConsultaMedica = (string) dr["est_consulta_medica"];

                            withBlock.NumAutorizacionSiteds = (string) dr["num_autorizacionsiteds"];
                            withBlock.fAutoDate = (string) dr["fAutoDate"];
                            withBlock.dAutotime = (string) dr["dAutoTime"];
                            break;
                        }

                    case 10 // MOBILE
             :
                        {
                            withBlock.NroOperacion = (string) dr["nro_operacion"];
                            withBlock.IdeDatospagos = (int) dr["ide_datospagos"];
                            withBlock.TipoEnvio = (string) dr["tipo_envio"];
                            break;
                        }

                    case 11 // WEB
             :
                        {
                            withBlock.NroOperacion = (string) dr["nro_operacion"];
                            withBlock.IdeDatospagos = (int) dr["ide_datospagos"];
                            withBlock.TipoEnvio = (string) dr["tipo_envio"];
                            break;
                        }

                    case 102:
                        {
                            withBlock.IdeDatospagos = (int) dr["ide_datospagos"];
                            withBlock.CodAtencion = (string) dr["cod_atencion"];
                            withBlock.TipDocumento = (string) dr["tip_documento"];
                            withBlock.NumDocumento = (string) dr["num_documento"];
                            withBlock.ApPaternoPaciente = (string) dr["appaterno"];
                            withBlock.ApMaternoPaciente = (string) dr["apmaterno"];
                            withBlock.NombrePaciente = (string) dr["nombre"];
                            withBlock.TipPrt = (string) dr["tip_prt"];
                            withBlock.CodIAFAS = (string) dr["cod_iafas"];

                            withBlock.CodSunasa = (string) dr["cod_sede_sunasa"];
                            withBlock.CodIAFAS = (string) dr["cod_iafas"];

                            withBlock.CodAsegurado = (string) dr["cod_asegurado"]; // oList(i).CodAsegurado
                            withBlock.NumDocempresa = (string) dr["num_docempresa"]; // oList(i).NumDocempresa

                            withBlock.CodAseguradora = (string) dr["cod_aseguradora"];
                            break;
                        }
                }
            }

            return oMdsynDatospagosE;
        }

        public List<MdsynDatosPagosE> Sp_MdsynDatosPagos_Consulta(MdsynDatosPagosE pMdsynDatosPagosE)
        {
            IDataReader dr;
            MdsynDatosPagosE oMdsynDatospagosE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MdsynDatosPagosE> oListar = new List<MdsynDatosPagosE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynDatosPagos_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_asegurado", pMdsynDatosPagosE.CodAsegurado);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMdsynDatosPagosE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_pacientetitular", pMdsynDatosPagosE.CodPacienteTitular);
                        cmd.Parameters.AddWithValue("@ide_correlreserva", pMdsynDatosPagosE.IdeCorrelreserva);
                        cmd.Parameters.AddWithValue("@orden", pMdsynDatosPagosE.Orden);
                        cmd.Parameters.AddWithValue("@cod_sede", pMdsynDatosPagosE.CodSede);
                        cmd.Parameters.AddWithValue("@dsc_nombrepaciente", pMdsynDatosPagosE.NombresPacientes);
                        cmd.Parameters.AddWithValue("@fec_inicio", "");
                        cmd.Parameters.AddWithValue("@fec_fin", "");
                        cmd.Parameters.AddWithValue("@cod_prof_medisyn", pMdsynDatosPagosE.CodProfMedico);

                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMdsynDatospagosE = LlenarEntidad(dr, pMdsynDatosPagosE);
                            oListar.Add(oMdsynDatospagosE);
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

        public bool Sp_MdsynDatosPagos_Insert(MdsynDatosPagosE pMdsynDatospagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynDatosPagos_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_asegurado", pMdsynDatospagosE.CodAsegurado);
                        cmd.Parameters.AddWithValue("@tip_documento", pMdsynDatospagosE.TipDocumento);
                        cmd.Parameters.AddWithValue("@num_documento", pMdsynDatospagosE.NumDocumento);
                        cmd.Parameters.AddWithValue("@tip_prt", pMdsynDatospagosE.TipPrt);
                        cmd.Parameters.AddWithValue("@tip_parentesco", pMdsynDatospagosE.TipParentesco);
                        cmd.Parameters.AddWithValue("@nro_plan", pMdsynDatospagosE.NroPlan);
                        cmd.Parameters.AddWithValue("@tip_docempresa", pMdsynDatospagosE.TipDocempresa);
                        cmd.Parameters.AddWithValue("@num_docempresa", pMdsynDatospagosE.NumDocempresa);
                        cmd.Parameters.AddWithValue("@fec_nacimiento", pMdsynDatospagosE.FecNacimiento);
                        cmd.Parameters.AddWithValue("@fec_iniciovigencia", pMdsynDatospagosE.FecIniciovigencia);
                        cmd.Parameters.AddWithValue("@fec_afilicacion", pMdsynDatospagosE.FecAfilicacion);
                        cmd.Parameters.AddWithValue("@cod_cobertura", pMdsynDatospagosE.CodCobertura);
                        cmd.Parameters.AddWithValue("@co_pagofijo", pMdsynDatospagosE.CoPagofijo);
                        cmd.Parameters.AddWithValue("@co_pagovariable", pMdsynDatospagosE.CoPagovariable);
                        cmd.Parameters.AddWithValue("@tip_moneda", pMdsynDatospagosE.TipMoneda);

                        cmd.Parameters.AddWithValue("@ide_correlreserva", pMdsynDatospagosE.IdeCorrelreserva);
                        cmd.Parameters.AddWithValue("@tip_atencion", pMdsynDatospagosE.TipAtencion);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMdsynDatospagosE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_pacientetitular", pMdsynDatospagosE.CodPacienteTitular);
                        cmd.Parameters.AddWithValue("@cod_iafas", pMdsynDatospagosE.CodIAFAS);
                        cmd.Parameters.AddWithValue("@cod_sede", pMdsynDatospagosE.CodSede);
                        cmd.Parameters.AddWithValue("@nro_operacion", pMdsynDatospagosE.NroOperacion);
                        cmd.Parameters.AddWithValue("@dsc_mensajerespuesta", pMdsynDatospagosE.DscMensajeRespuesta);
                        cmd.Parameters.AddWithValue("@est_pagoexitoso", pMdsynDatospagosE.EstPagoExitoso);
                        cmd.Parameters.AddWithValue("@cod_profmedico", pMdsynDatospagosE.CodProfMedico);
                        cmd.Parameters.AddWithValue("@cod_esp_medisyn", pMdsynDatospagosE.CodEspecialidadMedisyn);

                        cmd.Parameters.AddWithValue("@fec_cita", pMdsynDatospagosE.FecCita);
                        cmd.Parameters.AddWithValue("@tip_tarjeta", pMdsynDatospagosE.TipTarjeta);
                        cmd.Parameters.AddWithValue("@num_tarjeta", pMdsynDatospagosE.NumTarjeta);

                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_datospagos", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMdsynDatospagosE.IdeDatospagos));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pMdsynDatospagosE.IdeDatospagos = (int)cmd.Parameters["@ide_datospagos"].Value;
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

        public bool Sp_MdsynDatosPagos_Insert_V2(MdsynDatosPagosE pMdsynDatospagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynDatosPagos_Insert_V2", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_asegurado", pMdsynDatospagosE.CodAsegurado);
                        cmd.Parameters.AddWithValue("@tip_documento", pMdsynDatospagosE.TipDocumento);
                        cmd.Parameters.AddWithValue("@num_documento", pMdsynDatospagosE.NumDocumento);
                        cmd.Parameters.AddWithValue("@tip_prt", pMdsynDatospagosE.TipPrt);
                        cmd.Parameters.AddWithValue("@tip_parentesco", pMdsynDatospagosE.TipParentesco);
                        cmd.Parameters.AddWithValue("@nro_plan", pMdsynDatospagosE.NroPlan);
                        cmd.Parameters.AddWithValue("@tip_docempresa", pMdsynDatospagosE.TipDocempresa);
                        cmd.Parameters.AddWithValue("@num_docempresa", pMdsynDatospagosE.NumDocempresa);
                        cmd.Parameters.AddWithValue("@fec_nacimiento", pMdsynDatospagosE.FecNacimiento);
                        cmd.Parameters.AddWithValue("@fec_iniciovigencia", pMdsynDatospagosE.FecIniciovigencia);
                        cmd.Parameters.AddWithValue("@fec_afilicacion", pMdsynDatospagosE.FecAfilicacion);
                        cmd.Parameters.AddWithValue("@cod_cobertura", pMdsynDatospagosE.CodCobertura);
                        cmd.Parameters.AddWithValue("@co_pagofijo", pMdsynDatospagosE.CoPagofijo);
                        cmd.Parameters.AddWithValue("@co_pagovariable", pMdsynDatospagosE.CoPagovariable);
                        cmd.Parameters.AddWithValue("@tip_moneda", pMdsynDatospagosE.TipMoneda);

                        cmd.Parameters.AddWithValue("@ide_correlreserva", pMdsynDatospagosE.IdeCorrelreserva);
                        cmd.Parameters.AddWithValue("@tip_atencion", pMdsynDatospagosE.TipAtencion);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMdsynDatospagosE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_pacientetitular", pMdsynDatospagosE.CodPacienteTitular);
                        cmd.Parameters.AddWithValue("@cod_iafas", pMdsynDatospagosE.CodIAFAS);
                        cmd.Parameters.AddWithValue("@cod_sede", pMdsynDatospagosE.CodSede);
                        cmd.Parameters.AddWithValue("@nro_operacion", pMdsynDatospagosE.NroOperacion);
                        cmd.Parameters.AddWithValue("@dsc_mensajerespuesta", pMdsynDatospagosE.DscMensajeRespuesta);
                        cmd.Parameters.AddWithValue("@est_pagoexitoso", pMdsynDatospagosE.EstPagoExitoso);
                        cmd.Parameters.AddWithValue("@cod_profmedico", pMdsynDatospagosE.CodProfMedico);
                        cmd.Parameters.AddWithValue("@cod_esp_medisyn", pMdsynDatospagosE.CodEspecialidadMedisyn);

                        cmd.Parameters.AddWithValue("@fec_cita", pMdsynDatospagosE.FecCita);
                        cmd.Parameters.AddWithValue("@tip_tarjeta", pMdsynDatospagosE.TipTarjeta);
                        cmd.Parameters.AddWithValue("@num_tarjeta", pMdsynDatospagosE.NumTarjeta);

                        cmd.Parameters.AddWithValue("@comp_cod_tipocomprobante", pMdsynDatospagosE.Comp_TipoComprobante);
                        cmd.Parameters.AddWithValue("@comp_tip_doc_identidad", pMdsynDatospagosE.Comp_TipDocIdentidad);
                        cmd.Parameters.AddWithValue("@comp_doc_identidad", pMdsynDatospagosE.Comp_RutDocIdentidad);
                        cmd.Parameters.AddWithValue("@comp_dsc_tabla", pMdsynDatospagosE.Comp_DscTabla);
                        cmd.Parameters.AddWithValue("@dsc_correo_comprobante", pMdsynDatospagosE.Comp_Correo);

                        cmd.Parameters.AddWithValue("@tipo_envio", pMdsynDatospagosE.TipoEnvio);
                        cmd.Parameters.AddWithValue("@responsable_envio", pMdsynDatospagosE.ResponsableEnvio);

                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_datospagos", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMdsynDatospagosE.IdeDatospagos));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pMdsynDatospagosE.IdeDatospagos = (int) cmd.Parameters["@ide_datospagos"].Value;
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

        public bool Sp_MdsynDatosPagos_Insert_V3(MdsynDatosPagosE pMdsynDatospagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynDatosPagos_Insert_V3", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_asegurado", pMdsynDatospagosE.CodAsegurado);
                        cmd.Parameters.AddWithValue("@tip_documento", pMdsynDatospagosE.TipDocumento);
                        cmd.Parameters.AddWithValue("@num_documento", pMdsynDatospagosE.NumDocumento);
                        cmd.Parameters.AddWithValue("@tip_prt", pMdsynDatospagosE.TipPrt);
                        cmd.Parameters.AddWithValue("@tip_parentesco", pMdsynDatospagosE.TipParentesco);
                        cmd.Parameters.AddWithValue("@nro_plan", pMdsynDatospagosE.NroPlan);
                        cmd.Parameters.AddWithValue("@tip_docempresa", pMdsynDatospagosE.TipDocempresa);
                        cmd.Parameters.AddWithValue("@num_docempresa", pMdsynDatospagosE.NumDocempresa);
                        cmd.Parameters.AddWithValue("@fec_nacimiento", pMdsynDatospagosE.FecNacimiento);
                        cmd.Parameters.AddWithValue("@fec_iniciovigencia", pMdsynDatospagosE.FecIniciovigencia);
                        cmd.Parameters.AddWithValue("@fec_afilicacion", pMdsynDatospagosE.FecAfilicacion);
                        cmd.Parameters.AddWithValue("@cod_cobertura", pMdsynDatospagosE.CodCobertura);
                        cmd.Parameters.AddWithValue("@co_pagofijo", pMdsynDatospagosE.CoPagofijo);
                        cmd.Parameters.AddWithValue("@co_pagovariable", pMdsynDatospagosE.CoPagovariable);
                        cmd.Parameters.AddWithValue("@tip_moneda", pMdsynDatospagosE.TipMoneda);

                        cmd.Parameters.AddWithValue("@ide_correlreserva", pMdsynDatospagosE.IdeCorrelreserva);
                        cmd.Parameters.AddWithValue("@tip_atencion", pMdsynDatospagosE.TipAtencion);
                        cmd.Parameters.AddWithValue("@cod_paciente", pMdsynDatospagosE.CodPaciente);
                        cmd.Parameters.AddWithValue("@cod_pacientetitular", pMdsynDatospagosE.CodPacienteTitular);
                        cmd.Parameters.AddWithValue("@cod_iafas", pMdsynDatospagosE.CodIAFAS);
                        cmd.Parameters.AddWithValue("@cod_sede", pMdsynDatospagosE.CodSede);
                        cmd.Parameters.AddWithValue("@nro_operacion", pMdsynDatospagosE.NroOperacion);
                        cmd.Parameters.AddWithValue("@dsc_mensajerespuesta", pMdsynDatospagosE.DscMensajeRespuesta);
                        cmd.Parameters.AddWithValue("@est_pagoexitoso", pMdsynDatospagosE.EstPagoExitoso);
                        cmd.Parameters.AddWithValue("@cod_profmedico", pMdsynDatospagosE.CodProfMedico);
                        cmd.Parameters.AddWithValue("@cod_esp_medisyn", pMdsynDatospagosE.CodEspecialidadMedisyn);

                        cmd.Parameters.AddWithValue("@fec_cita", pMdsynDatospagosE.FecCita);
                        cmd.Parameters.AddWithValue("@tip_tarjeta", pMdsynDatospagosE.TipTarjeta);
                        cmd.Parameters.AddWithValue("@num_tarjeta", pMdsynDatospagosE.NumTarjeta);

                        cmd.Parameters.AddWithValue("@comp_cod_tipocomprobante", pMdsynDatospagosE.Comp_TipoComprobante);
                        cmd.Parameters.AddWithValue("@comp_tip_doc_identidad", pMdsynDatospagosE.Comp_TipDocIdentidad);
                        cmd.Parameters.AddWithValue("@comp_doc_identidad", pMdsynDatospagosE.Comp_RutDocIdentidad);
                        cmd.Parameters.AddWithValue("@comp_dsc_tabla", pMdsynDatospagosE.Comp_DscTabla);
                        cmd.Parameters.AddWithValue("@dsc_correo_comprobante", pMdsynDatospagosE.Comp_Correo);

                        cmd.Parameters.AddWithValue("@tipo_envio", pMdsynDatospagosE.TipoEnvio);
                        cmd.Parameters.AddWithValue("@responsable_envio", pMdsynDatospagosE.ResponsableEnvio);
                        cmd.Parameters.AddWithValue("@tipo_consulta_medica", pMdsynDatospagosE.CodTipoConsultaMedica);
                        cmd.Parameters.AddWithValue("@transaccion_id", pMdsynDatospagosE.TransaccionIdNiubiz);

                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_datospagos", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMdsynDatospagosE.IdeDatospagos));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pMdsynDatospagosE.IdeDatospagos = (int)cmd.Parameters["@ide_datospagos"].Value;
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

        public bool Sp_MdsynDatosPagos_Update(MdsynDatosPagosE pMdsynDatospagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynDatosPagos_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_datospagos", pMdsynDatospagosE.IdeDatospagos);
                        cmd.Parameters.AddWithValue("@cod_atencion", pMdsynDatospagosE.CodAtencion);
                        cmd.Parameters.AddWithValue("@cod_comprobante", pMdsynDatospagosE.CodComprobante);
                        cmd.Parameters.AddWithValue("@cod_liquidacion", pMdsynDatospagosE.CodLiquidacion);
                        cmd.Parameters.AddWithValue("@num_autorizacionsiteds", pMdsynDatospagosE.CodigoAutorizacion);
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

        public bool Sp_MdsynDatosPagos_Update_V2(MdsynDatosPagosE pMdsynDatospagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynDatosPagos_Update_V2", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_datospagos", pMdsynDatospagosE.IdeDatospagos);
                        cmd.Parameters.AddWithValue("@cod_atencion", pMdsynDatospagosE.CodAtencion);
                        cmd.Parameters.AddWithValue("@cod_comprobante", pMdsynDatospagosE.CodComprobante);
                        cmd.Parameters.AddWithValue("@cod_liquidacion", pMdsynDatospagosE.CodLiquidacion);
                        cmd.Parameters.AddWithValue("@num_autorizacionsiteds", pMdsynDatospagosE.CodigoAutorizacion);

                        cmd.Parameters.AddWithValue("@orden", pMdsynDatospagosE.Orden);
                        cmd.Parameters.AddWithValue("@dsc_mensajerespuesta", pMdsynDatospagosE.DscMensajeRespuesta);
                        cmd.Parameters.AddWithValue("@est_pagoexitoso", pMdsynDatospagosE.EstPagoExitoso);
                        cmd.Parameters.AddWithValue("@tip_tarjeta", pMdsynDatospagosE.TipTarjeta);
                        cmd.Parameters.AddWithValue("@num_tarjeta", pMdsynDatospagosE.NumTarjeta);

                        cmd.Parameters.AddWithValue("@nro_operacion", pMdsynDatospagosE.NroOperacion);
                        cmd.Parameters.AddWithValue("@json_rpta_visa", pMdsynDatospagosE.JsonRptaVisa);

                        // @ide_datospagos			INT,
                        // @cod_atencion			CHAR(8),
                        // @cod_comprobante		CHAR(11),
                        // @cod_liquidacion		lc_liquidacion,
                        // @num_autorizacionsiteds VARCHAR(40),

                        // @orden					INT = 0,
                        // @dsc_mensajerespuesta	VARCHAR(MAX) = '',
                        // @est_pagoexitoso		VARCHAR(1) = '',
                        // @tip_tarjeta			VARCHAR(20) = '',
                        // @num_tarjeta			VARCHAR(20) = ''

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

        public bool Sp_MdsynDatosPagos_UpdatexCampo(MdsynDatosPagosE pMdsynDatospagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynDatosPagos_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_datospagos", pMdsynDatospagosE.IdeDatospagos);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pMdsynDatospagosE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pMdsynDatospagosE.Campo);
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

        public bool Sp_MdsynDatosPagos_Delete(MdsynDatosPagosE pMdsynDatospagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynDatosPagos_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_datospagos", pMdsynDatospagosE.IdeDatospagos);
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
