using Ent.Sql.ClinicaE.PacientesE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.PacientesAD
{
    public class PacientesAD
    {
        private PacientesE LlenarEntidad(IDataReader dr, PacientesE pPacientesE)
        {
            PacientesE oPacientesE = new PacientesE();
            switch (pPacientesE.Orden)
            {
                case -1:
                    {
                        // codpaciente nombres		direccion	coddistrito	codprovincia	telefono	codcivil	
                        // ruc	observaciones	quiencreoregistro	quienmodificoregistro	
                        // estado  vip	coddireccion	lugarnacimiento	restringido	cod_ubigeo	flg_enviosap	fec_enviosap	
                        // ide_docentrysap fec_docentrysap		fec_recepcionsap	nombresexo	nombrecivil	nombretipdocidentidad	
                        // nombreprovincia nombredistrito	nombreestado	nombreestadoHC	nombrevip	nombrerestringido	correo	telefono2	
                        // appaterno   apmaterno	nombre	codcarga	coddepartamento	flagvalidado	fechacrea	fec_modifica
                        oPacientesE.Nombres = (string)(dr["nombres"] + "").Trim();
                        oPacientesE.Tipdocidentidad = (string)(dr["tipdocidentidad"] + "").Trim();
                        oPacientesE.Docidentidad = (string)(dr["docidentidad"] + "").Trim();
                        oPacientesE.Correo = (string)(dr["correo"] + "").Trim();
                        oPacientesE.Sexo = (string)(dr["sexo"] + "").Trim();
                        oPacientesE.Fechanacimiento = (DateTime) dr["fechanacimiento"];
                        oPacientesE.Cardcode = (string) dr["cardcode"] + "";
                        break;
                    }

                case 1 // No se si se está utilizando
         :
                    {
                        oPacientesE.CodPaciente = (string) dr["codpaciente"];
                        oPacientesE.Nombres = (string) dr["nombres"];
                        oPacientesE.Docidentidad = (string) dr["docidentidad"];
                        oPacientesE.Direccion = (string) dr["direccion"];
                        oPacientesE.Coddistrito = (string) dr["coddistrito"];
                        oPacientesE.Codprovincia = (string) dr["codprovincia"];
                        oPacientesE.Telefono = (string) dr["telefono"];
                        oPacientesE.Codcivil = (string) dr["codcivil"];
                        oPacientesE.Fechanacimiento = (DateTime) dr["fechanacimiento"];
                        oPacientesE.Sexo = (string) dr["sexo"];
                        oPacientesE.Tipdocidentidad = (string) dr["tipdocidentidad"];
                        oPacientesE.Ruc = (string) dr["ruc"];
                        oPacientesE.Observaciones = (string) dr["observaciones"];
                        oPacientesE.Quiencreoregistro = (string) dr["quiencreoregistro"];
                        oPacientesE.Quienmodificoregistro = (string) dr["quienmodificoregistro"];
                        oPacientesE.Estado = (string) dr["estado"];
                        oPacientesE.Vip = (string) dr["vip"];
                        oPacientesE.Coddireccion = (string) dr["coddireccion"];
                        oPacientesE.Lugarnacimiento = (string) dr["lugarnacimiento"];
                        oPacientesE.Restringido = (string) dr["restringido"];
                        oPacientesE.CodUbigeo = (string) dr["cod_ubigeo"];
                        oPacientesE.FlgEnviosap = (bool) dr["flg_enviosap"];
                        oPacientesE.FecEnviosap = (DateTime) dr["fec_enviosap"];
                        oPacientesE.IdeDocentrysap = (int) dr["ide_docentrysap"];
                        oPacientesE.FecDocentrysap = (DateTime) dr["fec_docentrysap"];
                        oPacientesE.Cardcode = (string) dr["cardcode"];
                        oPacientesE.FecRecepcionsap = (DateTime) dr["fec_recepcionsap"];
                        break;
                    }

                case 15:
                    {
                        oPacientesE.CodPaciente = (string) dr["codpaciente"];
                        break;
                    }

                case 16:
                    {
                        oPacientesE.FechaRegistro = (DateTime) dr["fechacrea"];
                        break;
                    }
            }
            return oPacientesE;
        }

        private PacientesE LlenarEntidadPacientesTerceros(IDataReader dr, PacientesE pPacientesE)
        {
            PacientesE oPacientesE = new PacientesE();
            switch (pPacientesE.Orden)
            {
                case 1:
                    {
                        oPacientesE.Codigo = (string) dr["codigo"];
                        oPacientesE.Nombres = (string) dr["nombres"];
                        oPacientesE.Docidentidad = (string) dr["docidentidad"];
                        oPacientesE.Direccion = (string) dr["direccion"];
                        oPacientesE.Tabla = (string) dr["tabla"];

                        oPacientesE.Nombre = (string) dr["nombre"] + "";
                        oPacientesE.ApPaterno = (string) dr["appaterno"] + "";
                        oPacientesE.ApMaterno = (string) dr["apmaterno"] + "";
                        oPacientesE.Parentesco = (string) dr["parentesco"] + "";
                        oPacientesE.Correo = (string) dr["correo"] + "";
                        oPacientesE.Celular = (string) dr["celular"] + "";
                        break;
                    }
            }
            return oPacientesE;
        }

        // Sp_BuscarPacienteTercero_Consulta
        public List<PacientesE> Sp_BuscarPacienteTercero_Consulta(PacientesE pPacientesE)
        {
            IDataReader dr;
            PacientesE oPacientesE = null/* TODO Change to default(_) if this is not a reference type */;
            List<PacientesE> oListar = new List<PacientesE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_BuscarPacienteTercero_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@nombres", pPacientesE.Nombres);
                        cmd.Parameters.AddWithValue("@docidentidad", pPacientesE.Docidentidad);
                        cmd.Parameters.AddWithValue("@tipdocidentidad", pPacientesE.Tipdocidentidad);
                        cmd.Parameters.AddWithValue("@orden", pPacientesE.Orden);
                        cmd.Parameters.AddWithValue("@cod_paciente_auditor", pPacientesE.CodPacienteAuditor);
                        // 

                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oPacientesE = LlenarEntidadPacientesTerceros(dr, pPacientesE);
                            oListar.Add(oPacientesE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PacientesE> Sp_Pacientes_Consulta(PacientesE pPacientesE)
        {
            IDataReader dr;
            PacientesE oPacientesE = null/* TODO Change to default(_) if this is not a reference type */;
            List<PacientesE> oListar = new List<PacientesE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Pacientes_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@buscar", pPacientesE.Buscar);
                        cmd.Parameters.AddWithValue("@key", pPacientesE.Key);
                        cmd.Parameters.AddWithValue("@numerolineas", pPacientesE.NumeroLineas);
                        cmd.Parameters.AddWithValue("@orden", pPacientesE.Orden);
                        cmd.Parameters.AddWithValue("@pdocidentidad", pPacientesE.Docidentidad);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oPacientesE = LlenarEntidad(dr, pPacientesE);
                            oListar.Add(oPacientesE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Pacientes_Update(PacientesE pPacientesE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Pacientes_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@campo", pPacientesE.Campo);
                        cmd.Parameters.AddWithValue("@codigo", pPacientesE.CodPaciente);
                        cmd.Parameters.AddWithValue("@nuevovalor", pPacientesE.NuevoValor);

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
    }
}
