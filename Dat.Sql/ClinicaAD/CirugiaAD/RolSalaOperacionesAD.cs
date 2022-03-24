using System.Data;
using System.Data.SqlClient;
using Ent.Sql.ClinicaE.CirugiaE;

namespace Dat.Sql.ClinicaAD.CirugiaAD
{
    public class RolSalaOperacionesAD
    {
        private RolSalaOperacionesE LlenarEntidad3(IDataReader dr, RolSalaOperacionesE pRolsalaoperacionesE)
        {
            RolSalaOperacionesE oRolsalaoperacionesE = new RolSalaOperacionesE();

            oRolsalaoperacionesE.Codrolsala = (decimal)dr["codrolsala"];
            oRolsalaoperacionesE.Codatencion = (string)dr["codatencion"];
            return oRolsalaoperacionesE;
        }

        private RolSalaOperacionesE LlenarEntidad(IDataReader dr, RolSalaOperacionesE pRolsalaoperacionesE)
        {
            RolSalaOperacionesE oRolsalaoperacionesE = new RolSalaOperacionesE();

            oRolsalaoperacionesE.Codrolsala = (decimal)dr["codrolsala"];
            oRolsalaoperacionesE.Codatencion = (string)dr["codatencion"];
            return oRolsalaoperacionesE;
        }

        public List<RolSalaOperacionesE> Sp_RolSalaOperaciones3_Consulta(RolSalaOperacionesE pRolsalaoperacionesE)
        {
            IDataReader dr;
            RolSalaOperacionesE oRolsalaoperacionesE;
            List<RolSalaOperacionesE> oListar = new List<RolSalaOperacionesE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RolSalaOperaciones3_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pRolsalaoperacionesE.Codatencion);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRolsalaoperacionesE = LlenarEntidad3(dr, pRolsalaoperacionesE);
                            oListar.Add(oRolsalaoperacionesE);
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

        public List<RolSalaOperacionesE> Sp_RolSalaAdmisionHospitalaria_Consulta(RolSalaOperacionesE pRolsalaoperacionesE)
        {
            IDataReader dr;
            RolSalaOperacionesE oRolsalaoperacionesE;
            List<RolSalaOperacionesE> oListar = new List<RolSalaOperacionesE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RolSalaAdmisionHospitalaria_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_atencion", pRolsalaoperacionesE.Codatencion);
                        cmd.Parameters.AddWithValue("@ide_primary", pRolsalaoperacionesE.IdePrimary);
                        cmd.Parameters.AddWithValue("@orden", pRolsalaoperacionesE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRolsalaoperacionesE = LlenarEntidad(dr, pRolsalaoperacionesE);
                            oListar.Add(oRolsalaoperacionesE);
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

        public bool Sp_Rolsalaoperaciones_Insert(RolSalaOperacionesE pRolsalaoperacionesE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Rolsalaoperaciones_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@sala", pRolsalaoperacionesE.Sala);
                        cmd.Parameters.AddWithValue("@fechaoperacion", pRolsalaoperacionesE.Fechaoperacion);
                        cmd.Parameters.AddWithValue("@horainicio", pRolsalaoperacionesE.Horainicio);
                        cmd.Parameters.AddWithValue("@horafin", pRolsalaoperacionesE.Horafin);
                        cmd.Parameters.AddWithValue("@codatencion", pRolsalaoperacionesE.Codatencion);
                        cmd.Parameters.AddWithValue("@estado", pRolsalaoperacionesE.Estado);
                        cmd.Parameters.AddWithValue("@operacion", pRolsalaoperacionesE.Operacion);
                        cmd.Parameters.AddWithValue("@codprestacion", pRolsalaoperacionesE.Codprestacion);
                        cmd.Parameters.AddWithValue("@anestesia", pRolsalaoperacionesE.Anestesia);
                        cmd.Parameters.AddWithValue("@emergencia", pRolsalaoperacionesE.Emergencia);
                        cmd.Parameters.AddWithValue("@nombrepaciente", pRolsalaoperacionesE.Nombrepaciente);
                        cmd.Parameters.AddWithValue("@edad", pRolsalaoperacionesE.Edad);
                        cmd.Parameters.AddWithValue("@cuarto", pRolsalaoperacionesE.Cuarto);
                        cmd.Parameters.AddWithValue("@observaciones", pRolsalaoperacionesE.Observaciones);
                        cmd.Parameters.AddWithValue("@horainicioreal", pRolsalaoperacionesE.Horainicioreal);
                        cmd.Parameters.AddWithValue("@horafinreal", pRolsalaoperacionesE.Horafinreal);
                        cmd.Parameters.AddWithValue("@muertexanestesia", pRolsalaoperacionesE.Muertexanestesia);
                        cmd.Parameters.AddWithValue("@tiempooperatorio", pRolsalaoperacionesE.Tiempooperatorio);
                        cmd.Parameters.AddWithValue("@tipoanestesia", pRolsalaoperacionesE.Tipoanestesia);
                        cmd.Parameters.AddWithValue("@laparoscopia", pRolsalaoperacionesE.Laparoscopia);
                        cmd.Parameters.AddWithValue("@electrocauterio", pRolsalaoperacionesE.Electrocauterio);
                        cmd.Parameters.AddWithValue("@oxigeno", pRolsalaoperacionesE.Oxigeno);
                        cmd.Parameters.AddWithValue("@tiempooxigeno", pRolsalaoperacionesE.Tiempooxigeno);
                        cmd.Parameters.AddWithValue("@codpresotor", pRolsalaoperacionesE.Codpresotor);
                        cmd.Parameters.AddWithValue("@complicacionesintraoperatorias", pRolsalaoperacionesE.Complicacionesintraoperatorias);
                        cmd.Parameters.AddWithValue("@intquirurgicainnecesaria", pRolsalaoperacionesE.Intquirurgicainnecesaria);
                        cmd.Parameters.AddWithValue("@clasificacion_cirugia", pRolsalaoperacionesE.ClasificacionCirugia);
                        cmd.Parameters.AddWithValue("@reprogramado", pRolsalaoperacionesE.Reprogramado);
                        cmd.Parameters.AddWithValue("@flag_sinfecha", pRolsalaoperacionesE.FlagSinfecha);
                        cmd.Parameters.AddWithValue("@rolsala_origen", pRolsalaoperacionesE.RolsalaOrigen);
                        cmd.Parameters.AddWithValue("@derivacion", pRolsalaoperacionesE.Derivacion);
                        cmd.Parameters.AddWithValue("@anulado", pRolsalaoperacionesE.Anulado);
                        cmd.Parameters.AddWithValue("@externo", pRolsalaoperacionesE.Externo);
                        cmd.Parameters.AddWithValue("@usu_crea", pRolsalaoperacionesE.UsuCrea);
                        cmd.Parameters.AddWithValue("@usu_modifica", pRolsalaoperacionesE.UsuModifica);
                        cmd.Parameters.AddWithValue("@usu_reprograma", pRolsalaoperacionesE.UsuReprograma);
                        cmd.Parameters.AddWithValue("@usu_realiza", pRolsalaoperacionesE.UsuRealiza);
                        cmd.Parameters.AddWithValue("@usu_anula", pRolsalaoperacionesE.UsuAnula);
                        cmd.Parameters.AddWithValue("@fec_crea", pRolsalaoperacionesE.FecCrea);
                        cmd.Parameters.AddWithValue("@fec_reprograma", pRolsalaoperacionesE.FecReprograma);
                        cmd.Parameters.AddWithValue("@fec_realiza", pRolsalaoperacionesE.FecRealiza);
                        cmd.Parameters.AddWithValue("@fec_anula", pRolsalaoperacionesE.FecAnula);
                        cmd.Parameters.AddWithValue("@fec_modifica", pRolsalaoperacionesE.FecModifica);
                        cmd.Parameters.AddWithValue("@flag_recuperacion", pRolsalaoperacionesE.FlagRecuperacion);
                        cmd.Parameters.AddWithValue("@noprogramado", pRolsalaoperacionesE.Noprogramado);
                        cmd.Parameters.AddWithValue("@parto", pRolsalaoperacionesE.Parto);
                        cmd.Parameters.AddWithValue("@tipoparto", pRolsalaoperacionesE.Tipoparto);
                        cmd.Parameters.AddWithValue("@cesarea", pRolsalaoperacionesE.Cesarea);
                        cmd.Parameters.AddWithValue("@turno_nocturno", pRolsalaoperacionesE.TurnoNocturno);
                        cmd.Parameters.AddWithValue("@videolaringoscopio", pRolsalaoperacionesE.Videolaringoscopio);
                        cmd.Parameters.AddWithValue("@codpresupuesto", pRolsalaoperacionesE.Codpresupuesto);
                        cmd.Parameters.AddWithValue("@correo", pRolsalaoperacionesE.Correo);
                        cmd.Parameters.AddWithValue("@horainiactoquirurgico", pRolsalaoperacionesE.Horainiactoquirurgico);
                        cmd.Parameters.AddWithValue("@horafinactoquirugico", pRolsalaoperacionesE.Horafinactoquirugico);
                        cmd.Parameters.AddWithValue("@tipo_sala", pRolsalaoperacionesE.TipoSala);
                        cmd.Parameters.AddWithValue("@flag_complejidad", pRolsalaoperacionesE.FlagComplejidad);
                        cmd.Parameters.AddWithValue("@tipo_operacion", pRolsalaoperacionesE.TipoOperacion);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codrolsala", ParameterDirection.InputOutput, SqlDbType.BigInt, 8, pRolsalaoperacionesE.Codrolsala.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRolsalaoperacionesE.Codrolsala = (decimal)cmd.Parameters["@codrolsala"].Value;

                            cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                            cnn.Close(); // Se cierre la conexión.
                            cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                            return true;
                        }
                        else
                        {
                            cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                            cnn.Close(); // Se cierre la conexión.
                            cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                            return false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Rolsalaoperaciones_Update(RolSalaOperacionesE pRolsalaoperacionesE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Rolsalaoperaciones_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@sala", pRolsalaoperacionesE.Sala);
                        cmd.Parameters.AddWithValue("@fechaoperacion", pRolsalaoperacionesE.Fechaoperacion);
                        cmd.Parameters.AddWithValue("@horainicio", pRolsalaoperacionesE.Horainicio);
                        cmd.Parameters.AddWithValue("@horafin", pRolsalaoperacionesE.Horafin);
                        cmd.Parameters.AddWithValue("@codatencion", pRolsalaoperacionesE.Codatencion);
                        cmd.Parameters.AddWithValue("@estado", pRolsalaoperacionesE.Estado);
                        cmd.Parameters.AddWithValue("@operacion", pRolsalaoperacionesE.Operacion);
                        cmd.Parameters.AddWithValue("@codprestacion", pRolsalaoperacionesE.Codprestacion);
                        cmd.Parameters.AddWithValue("@anestesia", pRolsalaoperacionesE.Anestesia);
                        cmd.Parameters.AddWithValue("@emergencia", pRolsalaoperacionesE.Emergencia);
                        cmd.Parameters.AddWithValue("@nombrepaciente", pRolsalaoperacionesE.Nombrepaciente);
                        cmd.Parameters.AddWithValue("@edad", pRolsalaoperacionesE.Edad);
                        cmd.Parameters.AddWithValue("@cuarto", pRolsalaoperacionesE.Cuarto);
                        cmd.Parameters.AddWithValue("@observaciones", pRolsalaoperacionesE.Observaciones);
                        cmd.Parameters.AddWithValue("@horainicioreal", pRolsalaoperacionesE.Horainicioreal);
                        cmd.Parameters.AddWithValue("@horafinreal", pRolsalaoperacionesE.Horafinreal);
                        cmd.Parameters.AddWithValue("@muertexanestesia", pRolsalaoperacionesE.Muertexanestesia);
                        cmd.Parameters.AddWithValue("@tiempooperatorio", pRolsalaoperacionesE.Tiempooperatorio);
                        cmd.Parameters.AddWithValue("@tipoanestesia", pRolsalaoperacionesE.Tipoanestesia);
                        cmd.Parameters.AddWithValue("@laparoscopia", pRolsalaoperacionesE.Laparoscopia);
                        cmd.Parameters.AddWithValue("@electrocauterio", pRolsalaoperacionesE.Electrocauterio);
                        cmd.Parameters.AddWithValue("@oxigeno", pRolsalaoperacionesE.Oxigeno);
                        cmd.Parameters.AddWithValue("@tiempooxigeno", pRolsalaoperacionesE.Tiempooxigeno);
                        cmd.Parameters.AddWithValue("@codpresotor", pRolsalaoperacionesE.Codpresotor);
                        cmd.Parameters.AddWithValue("@complicacionesintraoperatorias", pRolsalaoperacionesE.Complicacionesintraoperatorias);
                        cmd.Parameters.AddWithValue("@intquirurgicainnecesaria", pRolsalaoperacionesE.Intquirurgicainnecesaria);
                        cmd.Parameters.AddWithValue("@clasificacion_cirugia", pRolsalaoperacionesE.ClasificacionCirugia);
                        cmd.Parameters.AddWithValue("@reprogramado", pRolsalaoperacionesE.Reprogramado);
                        cmd.Parameters.AddWithValue("@flag_sinfecha", pRolsalaoperacionesE.FlagSinfecha);
                        cmd.Parameters.AddWithValue("@rolsala_origen", pRolsalaoperacionesE.RolsalaOrigen);
                        cmd.Parameters.AddWithValue("@derivacion", pRolsalaoperacionesE.Derivacion);
                        cmd.Parameters.AddWithValue("@anulado", pRolsalaoperacionesE.Anulado);
                        cmd.Parameters.AddWithValue("@externo", pRolsalaoperacionesE.Externo);
                        cmd.Parameters.AddWithValue("@usu_crea", pRolsalaoperacionesE.UsuCrea);
                        cmd.Parameters.AddWithValue("@usu_modifica", pRolsalaoperacionesE.UsuModifica);
                        cmd.Parameters.AddWithValue("@usu_reprograma", pRolsalaoperacionesE.UsuReprograma);
                        cmd.Parameters.AddWithValue("@usu_realiza", pRolsalaoperacionesE.UsuRealiza);
                        cmd.Parameters.AddWithValue("@usu_anula", pRolsalaoperacionesE.UsuAnula);
                        cmd.Parameters.AddWithValue("@fec_crea", pRolsalaoperacionesE.FecCrea);
                        cmd.Parameters.AddWithValue("@fec_reprograma", pRolsalaoperacionesE.FecReprograma);
                        cmd.Parameters.AddWithValue("@fec_realiza", pRolsalaoperacionesE.FecRealiza);
                        cmd.Parameters.AddWithValue("@fec_anula", pRolsalaoperacionesE.FecAnula);
                        cmd.Parameters.AddWithValue("@fec_modifica", pRolsalaoperacionesE.FecModifica);
                        cmd.Parameters.AddWithValue("@flag_recuperacion", pRolsalaoperacionesE.FlagRecuperacion);
                        cmd.Parameters.AddWithValue("@noprogramado", pRolsalaoperacionesE.Noprogramado);
                        cmd.Parameters.AddWithValue("@parto", pRolsalaoperacionesE.Parto);
                        cmd.Parameters.AddWithValue("@tipoparto", pRolsalaoperacionesE.Tipoparto);
                        cmd.Parameters.AddWithValue("@cesarea", pRolsalaoperacionesE.Cesarea);
                        cmd.Parameters.AddWithValue("@turno_nocturno", pRolsalaoperacionesE.TurnoNocturno);
                        cmd.Parameters.AddWithValue("@videolaringoscopio", pRolsalaoperacionesE.Videolaringoscopio);
                        cmd.Parameters.AddWithValue("@codpresupuesto", pRolsalaoperacionesE.Codpresupuesto);
                        cmd.Parameters.AddWithValue("@correo", pRolsalaoperacionesE.Correo);
                        cmd.Parameters.AddWithValue("@horainiactoquirurgico", pRolsalaoperacionesE.Horainiactoquirurgico);
                        cmd.Parameters.AddWithValue("@horafinactoquirugico", pRolsalaoperacionesE.Horafinactoquirugico);
                        cmd.Parameters.AddWithValue("@tipo_sala", pRolsalaoperacionesE.TipoSala);
                        cmd.Parameters.AddWithValue("@flag_complejidad", pRolsalaoperacionesE.FlagComplejidad);
                        cmd.Parameters.AddWithValue("@tipo_operacion", pRolsalaoperacionesE.TipoOperacion);
                        cmd.Parameters.AddWithValue("@codrolsala", pRolsalaoperacionesE.Codrolsala);
                        cnn.Open();

                        int rowResult = cmd.ExecuteNonQuery();
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.

                        if (rowResult >= 1)
                            return true;
                        else
                            return false;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Rolsalaoperaciones_UpdatexCampo(RolSalaOperacionesE pRolsalaoperacionesE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Rolsalaoperaciones_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codrolsala", pRolsalaoperacionesE.Codrolsala);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRolsalaoperacionesE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRolsalaoperacionesE.Campo);
                        cnn.Open();

                        int rowResult = cmd.ExecuteNonQuery();
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.

                        if (rowResult >= 1)
                            return true;
                        else
                            return false;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Rolsalaoperaciones_Delete(RolSalaOperacionesE pRolsalaoperacionesE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Rolsalaoperaciones_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codrolsala", pRolsalaoperacionesE.Codrolsala);
                        cnn.Open();

                        int rowResult = cmd.ExecuteNonQuery();
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.

                        if (rowResult >= 1)
                            return true;
                        else
                            return false;

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
