using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Oracle.ManagedDataAccess.Client;
using Ent.Oracle.MedisynE.PacientesE;

namespace Dat.Oracle.MedisynAD.PacientesAD
{
    public class TabPacientesAD
    {
        private TabPacienteE LlenarEntidad(IDataReader dr, int pOrden = 1)
        {
            TabPacienteE oTabPacienteE = new TabPacienteE();

            oTabPacienteE.IdAmbulatorio = (string)dr["id_ambulatorio"];
            oTabPacienteE.UserW_IdGrupoFamiliar = (string)dr["id_grupo_familiar"];

            oTabPacienteE.UserW_CodParentesco = dr["parentesco"] + "";
            oTabPacienteE.UserW_CodParentesco = (oTabPacienteE.UserW_CodParentesco == "" ? "T" : oTabPacienteE.UserW_CodParentesco);
            switch (oTabPacienteE.UserW_CodParentesco)
            {
                case "C":
                    {
                        oTabPacienteE.UserW_DscParentesco = "CONYUGE";
                        break;
                    }

                case "H":
                    {
                        oTabPacienteE.UserW_DscParentesco = "HIJO(A)";
                        break;
                    }

                case "O":
                    {
                        oTabPacienteE.UserW_DscParentesco = "OTRO";
                        break;
                    }

                default:
                    {
                        oTabPacienteE.UserW_DscParentesco = "TITULAR";
                        break;
                    }
            }

            return oTabPacienteE;
        }

        public List<TabPacienteE> ObtenerGrupoFamiliarPackAge(string IdPaciente)
        {
            TabPacienteE objAmReservaE = new TabPacienteE();
            List<TabPacienteE> ListReservaE = new List<TabPacienteE>();

            try
            {
                string wSqlQuery = "PKG_CSF_Agendamiento.ObtenerGrupoFamiliar";

                using (OracleConnection cnn = new OracleConnection(VariablesGlobales.CnnMedisyn))
                {
                    using (OracleCommand cmd = new OracleCommand(wSqlQuery, cnn))
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("pin_ID_AMBULATORIO", OracleDbType.Int64).Value = IdPaciente;
                        cmd.Parameters.Add("pout_PCURDATOS", OracleDbType.RefCursor, ParameterDirection.Output);
                        OracleDataReader dr = cmd.ExecuteReader();

                        TabPacienteE objPaciente = new TabPacienteE();
                        while (dr.Read())
                            ListReservaE.Add(LlenarEntidad(dr, 1));

                        cmd.Dispose();
                    }

                    cnn.Dispose();
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ConsultarReservasPacientes: " + ex.Message);
            }

            return ListReservaE;
        }

        public DataSet ObtenerDepatamentos(string CodEmpresa)
        {
            TabPacienteE objAmReservaE = new TabPacienteE();
            List<TabPacienteE> ListReservaE = new List<TabPacienteE>();
            string wSqlQuery = "";
            DataSet ds = new DataSet();

            try
            {
                wSqlQuery = "PKG_AGENDA.ObtieneDepto";

                OracleConnection cnn = new OracleConnection(VariablesGlobales.CnnMedisyn);
                cnn.Open();
                OracleCommand cmd = new OracleCommand();

                // wSqlQuery, cnn
                cmd.CommandText = wSqlQuery;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pin_COD_EMPRESA", OracleDbType.Long, 0, CodEmpresa, ParameterDirection.Input);
                cmd.Parameters.Add("pout_PCURDATOS", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Connection = cnn;
                OracleDataAdapter da = new OracleDataAdapter(cmd);

                da.Fill(ds);

                cmd.Dispose();
                cnn.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("ConsultarReservasPacientes: " + ex.Message);
            }
            return ds;
        }


        public List<TabPacienteE> ObtenerGrupoFamiliar2(string IdAmbulatoria)
        {
            IDataReader dr;
            TabPacienteE objAmReservaE = new TabPacienteE();
            List<TabPacienteE> ListReservaE = new List<TabPacienteE>();
            string wSqlQuery = "";
            // Dim ds As New DataSet

            try
            {
                wSqlQuery = "" + "SELECT " + "p.id_ambulatorio, x.id_grupo_familiar, x.parentesco " + "FROM tab_usuario_rpaciente_web x " + "INNER JOIN tab_paciente p ON p.id_ambulatorio = x.id_paciente " + "WHERE p.id_ambulatorio = " + IdAmbulatoria.Trim() + " AND p.vigencia = 'S' AND x.vigencia = 'S' ";

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
                throw new Exception("ObtenerGrupoFamiliar2: " + ex.Message);
            }
            return ListReservaE;
        }

        /// <summary>
        ///         ''' Devolvera a toda la familia al cual pertecene el paciente
        ///         ''' </summary>
        ///         ''' <param name="IdAmbulatoria"></param>
        ///         ''' <returns></returns>
        public List<TabPacienteE> ObtenerGrupoFamiliarxIdAmbulatorio(string IdAmbulatoria)
        {
            IDataReader dr;
            TabPacienteE objAmReservaE = new TabPacienteE();
            List<TabPacienteE> ListReservaE = new List<TabPacienteE>();
            string wSqlQuery = "";
            // Dim ds As New DataSet

            try
            {
                wSqlQuery = "" + "SELECT p.id_grupo_familiar, p.id_paciente id_ambulatorio, p.parentesco, p.ind_jefe_familia " +
                                 "FROM tab_usuario_rpaciente_web p " +
                                 "WHERE p.vigencia = 'S' AND p.id_grupo_familiar IN (SELECT x.id_grupo_familiar FROM tab_usuario_rpaciente_web x WHERE x.id_paciente = " + IdAmbulatoria.Trim() + " AND x.vigencia = 'S')";

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
                throw new Exception("ObtenerGrupoFamiliar2: " + ex.Message);
            }
            return ListReservaE;
        }
    }
}