using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
using Ent.Oracle.MedisynE.ReservasE;
using System.Data;

namespace Dat.Oracle.MedisynAD.ReservasAD
{
    public class AmReservaAD
    {
        private AmReservaE LlenarEntidad(IDataReader dr, int pOrden = 1)
        {
            AmReservaE oAmReservaE = new AmReservaE();

            switch (pOrden)
            {
                case 1:
                    {
                        oAmReservaE.IdCorrelReserva = (string)dr["correl_reserva"];
                        oAmReservaE.FecIngresoReserva = (DateTime)dr["fecing_reserva"];
                        //oAmReservaE.FecReserva = ($"{dr["fecha_reserva"]} {dr["hora_reserva"]})";
                        oAmReservaE.FecReserva = Convert.ToDateTime((string)dr["fecha_reserva"] + " " + (string)dr["hora_reserva"]);
                        oAmReservaE.IdPaciente = (int)dr["id_paciente"];
                        oAmReservaE.IdPacienteReserva = (int)dr["id_paciente_reserva"];
                        oAmReservaE.CodEspecialidad = (int)dr["cod_especialidad"];
                        oAmReservaE.CodSucursal = (int)dr["cod_sucursal"];
                        oAmReservaE.Medico = (string)dr["medico"];
                        oAmReservaE.EmailPaciente = (string)dr["email_paciente"];
                        break;
                    }

                case 2:
                    {
                        oAmReservaE.BoxReserva = dr["box_reserva"] + "";
                        oAmReservaE.CodUnidad = dr["cod_unidad"] + "";
                        oAmReservaE.DescUnidad = dr["desc_unidad"] + "";
                        break;
                    }

                case 3:
                    {
                        oAmReservaE.CodProf = dr["cod_prof"] + "";
                        oAmReservaE.IdAmbulatorio = dr["id_ambulatorio"] + "";
                        oAmReservaE.IdCorrelReserva = dr["correl_reserva"] + "";
                        oAmReservaE.CodEspecialidad = (int)dr["cod_especialidad"];
                        //oAmReservaE.RutPaciente = Right("00" + dr("rut_paciente").ToString + "", 8);
                        oAmReservaE.RutPaciente = ("00" + (dr["rut_paciente"] + ""));
                        oAmReservaE.RutPaciente = oAmReservaE.RutPaciente.Substring(oAmReservaE.RutPaciente.Length - 8, 8);

                        oAmReservaE.FecReserva = (DateTime)dr["fecha_reserva"];
                        oAmReservaE.HoraReserva = (DateTime)dr["hora_reserva"];
                        oAmReservaE.CodSucursal = (int)dr["cod_sucursal"];
                        oAmReservaE.DscSucursal = (string)dr["DSC_SUCURSAL"];
                        break;
                    }
            }

            return oAmReservaE;
        }

        public List<AmReservaE> ConsultarReservasPacientes(ref int CodReservaUltimo)
        {
            IDataReader dr;
            AmReservaE objAmReservaE = new AmReservaE();
            List<AmReservaE> ListReservaE = new List<AmReservaE>();
            string wSqlQuery = "";

            try
            {
                wSqlQuery = "" + "select" + " r.correl_reserva," + " r.fecing_reserva," + " r.fecha_reserva," + " r.hora_reserva," + " p.id_paciente," + " r.id_paciente_reserva," + " p.email_paciente," + " m.cod_especialidad," + " TRIM(m.apepat_prof) || ' ' || TRIM(m.apemat_prof) || ' ' || TRIM(m.nombre1_prof) as medico," + " r.cod_sucursal " + "from medisyn_16.am_reserva r " + "inner join medisyn_16.tab_paciente p on p.id_ambulatorio = r.id_ambulatorio " + "inner join gen_profesional m on m.cod_prof = r.cod_prof " + "where r.correl_reserva > " + CodReservaUltimo.ToString() + " and antr_reserva is null " + "order by r.correl_reserva";

                using (OracleConnection cnn = new OracleConnection(VariablesGlobales.CnnMedisyn))
                {
                    using (OracleCommand cmd = new OracleCommand(wSqlQuery, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                            ListReservaE.Add(LlenarEntidad(dr));
                        cmd.Dispose();
                        cnn.Dispose();
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ConsultarReservasPacientes: " + ex.Message);
            }
            return ListReservaE;
        }

        public List<AmReservaE> ConsultarReservaPacienteId(string CorrelReserva)
        {
            IDataReader dr;
            AmReservaE objAmReservaE = new AmReservaE();
            List<AmReservaE> ListReservaE = new List<AmReservaE>();
            string wSqlQuery = "";

            try
            {
                wSqlQuery = "" + "select NVL(x.box_reserva, 0) box_reserva, x.cod_unidad, gu.desc_unidad " + "from am_reserva x " + "left join am_box ab on ab.cod_box = x.box_reserva " + "left join gen_unidad gu ON gu.cod_unidad = x.cod_unidad " + "WHERE x.correl_reserva = " + CorrelReserva + "";

                using (OracleConnection cnn = new OracleConnection(VariablesGlobales.CnnMedisyn))
                {
                    using (OracleCommand cmd = new OracleCommand(wSqlQuery, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                            ListReservaE.Add(LlenarEntidad(dr, 2));
                        cmd.Dispose();
                        cnn.Dispose();
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ConsultarReservasPacientes: " + ex.Message);
            }
            return ListReservaE;
        }


        public AmReservaE ObtenerInfoReserva(AmReservaE pObjAmReserva)
        {
            IDataReader dr;
            AmReservaE objGenEnvioMailE = new AmReservaE();
            string wSqlQuery = "";

            try
            {
                wSqlQuery = "SELECT " + "x.cod_prof, x.id_ambulatorio, x.correl_reserva, x.cod_especialidad, t.rut_paciente, " + "x.fecha_reserva, x.hora_reserva, x.cod_sucursal, p.desc_item dsc_sucursal  " + "From am_reserva x " + "INNER JOIN tab_paciente t ON t.id_ambulatorio = x.id_ambulatorio " + "INNER JOIN  tab_paramet p ON p.cod_grupo = 6 AND p.cod_item = x.cod_sucursal " + "WHERE x.correl_reserva = '" + pObjAmReserva.IdCorrelReserva + "'";

                using (OracleConnection cnn = new OracleConnection(VariablesGlobales.CnnMedisyn))
                {
                    using (OracleCommand cmd = new OracleCommand(wSqlQuery, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                            objGenEnvioMailE = LlenarEntidad(dr, pObjAmReserva.ORDEN);
                        dr.Dispose();
                        dr.Close();
                        cmd.Dispose();
                        cnn.Dispose();
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("cls: AmReservaAD - mtd: ObtenerInfoReserva: " + ex.Message);
            }

            return objGenEnvioMailE;
        }

        /// <summary>
        ///         ''' Verificamos si este paciente tiene cita ese dia con ese mismo médico.
        ///         ''' </summary>
        ///         ''' <param name="pObjAmReserva"></param>
        ///         ''' <returns></returns>
        public bool VerificarCitaPacienteMedicoDia(AmReservaE pObjAmReserva)
        {
            bool result = false;

            try
            {
                using (OracleConnection cnn = new OracleConnection(VariablesGlobales.CnnMedisyn))
                {
                    using (OracleCommand cmd = new OracleCommand("PKG_CSF_Agendamiento.VerificarCitaPacienteMedicaDia", cnn))
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("pIn_Id_Ambulatorio", OracleDbType.Int64).Value = pObjAmReserva.IdAmbulatorio;
                        cmd.Parameters.Add("pIn_FECHA_RESERVA", OracleDbType.NVarchar2).Value = pObjAmReserva.FecReserva_String;
                        cmd.Parameters.Add("pIn_CORREL_HORARIO", OracleDbType.Int64).Value = pObjAmReserva.CorrelHorario;
                        cmd.Parameters.Add("pOut_PCURDATOS", OracleDbType.RefCursor, ParameterDirection.Output);
                        IDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                            result = true;

                        dr.Dispose();
                        dr.Close();
                        cmd.Dispose();
                    }

                    cnn.Dispose();
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("cls: AmReservaAD - mtd: VerificarCitaPacienteMedicoDia: " + ex.Message);
            }

            return result;
        }

        /// <summary>
        ///         ''' Obtiene la agenda de los médicos por apellido.
        ///         ''' </summary>
        ///         ''' <returns></returns>
        public List<AgendaDatos> ObtieneAgendaXApellido(int Cod_Empresa, int Cod_Sucursal, string ApelPat_prof)
        {
            var oList = new List<AgendaDatos>();

            try
            {
                using (OracleConnection cnn = new OracleConnection(VariablesGlobales.CnnMedisyn))
                {
                    using (OracleCommand cmd = new OracleCommand("PKG_AGENDA.ObtieneAgendaXApellido", cnn))
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("pnumcodempresa", OracleDbType.Int64).Value = Cod_Empresa;
                        cmd.Parameters.Add("pnumcodsucursal", OracleDbType.Int64).Value = Cod_Sucursal;
                        cmd.Parameters.Add("pstrapepatprof", OracleDbType.NVarchar2).Value = ApelPat_prof;
                        cmd.Parameters.Add("rcursor", OracleDbType.RefCursor, ParameterDirection.Output);

                        IDataReader dr = cmd.ExecuteReader();
                        var obj = new AgendaDatos();
                        while (dr.Read())
                        {
                            obj = new AgendaDatos();
                            obj.cOD_SUCURSAL = (byte)dr["Cod_Sucursal"];
                            obj.sUCURSAL = (string)dr["sucursal"];
                            obj.cOD_PROF = (ushort)dr["cod_prof"];
                            obj.rUT_PROF = (uint)dr["rut_prof"];
                            obj.aPEPAT_PROF = (string)dr["apepat_prof"];
                            obj.aPEMAT_PROF = (string)dr["apemat_prof"];
                            obj.nOMBRE1_PROF = (string)dr["nombre1_prof"];
                            obj.cOD_ESPECIALIDAD = (byte)dr["cod_especialidad"];
                            obj.dESC_ITEM = (string)dr["desc_item"];
                            obj.cORRAGENDA = (ushort)dr["corragenda"];
                            obj.fECHAINICPROX_AGENDA = (string)dr["fechainicprox_agenda"];
                            obj.fECHA_SISTEMA = (string)dr["fecha_sistema"];
                            obj.cOD_UNIDAD = (byte)dr["cod_unidad"];
                            obj.dESC_UNIDAD = (string)dr["desc_unidad"];
                            obj.hMUL = (byte)dr["hmul"];
                            obj.vERSTAFF = (string)dr["verstaff"];
                            obj.pROXIMA_HORA_DISPONIBLE = (DateTime)dr["proxima_hora_disponible"];
                            obj.pROXIMA_HORA_DISPONIBLE_CHAR = (string)dr["proxima_hora_disponible_char"];
                            // obj.dSC_ESPECIALIDAD_ALTERNO = (string) dr["")
                            // obj.mONTO_TARIFA_PARTICULAR = (string) dr["")
                            // obj.mONEDA_TARIFA_PARTICULAR = (string) dr["")
                            // obj.tIPO_CONSULTA_MEDICA = (string) dr["")

                            // <Datos>
                            // <COD_SUCURSAL>1</COD_SUCURSAL>
                            // <SUCURSAL>SUC. CAMACHO</SUCURSAL>
                            // <COD_PROF>268</COD_PROF>
                            // <RUT_PROF>6624470</RUT_PROF>
                            // <APEPAT_PROF>SANSONI</APEPAT_PROF>
                            // <APEMAT_PROF>RAINUZZO</APEMAT_PROF>
                            // <NOMBRE1_PROF>ALDO</NOMBRE1_PROF>
                            // <COD_ESPECIALIDAD>10</COD_ESPECIALIDAD>
                            // <DESC_ITEM>DERMATOLOGIA</DESC_ITEM>
                            // <CORRAGENDA>415</CORRAGENDA>
                            // <FECHAINICPROX_AGENDA>02/12/2021</FECHAINICPROX_AGENDA>
                            // <HORARIOPROX_AGENDA>5A10000000000000000005A10000000005A10000005A10000000005A10000003E80000000003D40000003C00000000003C00000003D40000000003C00000003C00000000003C00000003C00000000003C00000003C00000000003C00000003C00000000003C00000003C00000000003C00000003C00000000003C00000003C00000000003C00000003C00000000003C00000003C00000000003C00000003C00000000003C00000003C00000000003C00000003C0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000</HORARIOPROX_AGENDA>
                            // <FECHA_SISTEMA>12/12/2021</FECHA_SISTEMA>
                            // <COD_UNIDAD>2</COD_UNIDAD>
                            // <DESC_UNIDAD>CM CAMACHO</DESC_UNIDAD>
                            // <HMUL>1</HMUL>
                            // <VERSTAFF>MOSTRAR</VERSTAFF>
                            // <PROXIMA_HORA_DISPONIBLE>2021-12-23T16:40:00-05:00</PROXIMA_HORA_DISPONIBLE>
                            // <PROXIMA_HORA_DISPONIBLE_CHAR>23/12/2021 16:40:00</PROXIMA_HORA_DISPONIBLE_CHAR>
                            // </Datos>

                            oList.Add(obj);
                        }

                        dr.Dispose();
                        dr.Close();
                        cmd.Dispose();
                    }

                    cnn.Dispose();
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("cls: AmReservaAD - mtd: ObtieneAgendaXApellido: " + ex.Message);
            }

            return oList;
        }
    }
}
