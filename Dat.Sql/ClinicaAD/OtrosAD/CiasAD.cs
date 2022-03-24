using Ent.Sql.ClinicaE.OtrosE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.OtrosAD
{
    partial class CiasAD
    {
        private CiasE LlenarEntidad(IDataReader dr, CiasE pCiasE)
        {
            CiasE oCiasE = new CiasE();
            switch (pCiasE.Orden)
            {
                case 1:
                    {
                        oCiasE.Codcia = (string) dr["codcia"];
                        oCiasE.Nombre = (string) dr["nombre"];
                        oCiasE.Direccion = (string) dr["direccion"];
                        oCiasE.Telefono = (string) dr["telefono"];
                        oCiasE.Ruc = (string) dr["ruc"];
                        oCiasE.Contacto = (string) dr["contacto"];
                        oCiasE.Estado = (bool) dr["estado"];
                        oCiasE.Login = (string) dr["login"];
                        oCiasE.Password = (string) dr["password"];
                        oCiasE.Activointernet = (int) dr["activointernet"];
                        oCiasE.Fecharegistro = (DateTime) dr["fecharegistro"];
                        oCiasE.Codusercreo = (int) dr["codusercreo"];
                        oCiasE.Fechamodifico = (DateTime) dr["fechamodifico"];
                        oCiasE.Codusermodifico = (int) dr["codusermodifico"];
                        oCiasE.Codciaanterior = (string) dr["codciaanterior"];
                        oCiasE.Fechabaja = (DateTime) dr["fechabaja"];
                        oCiasE.Coduserbaja = (int) dr["coduserbaja"];
                        oCiasE.Correo = (string) dr["correo"];
                        oCiasE.CodTipopersona = (string) dr["cod_tipopersona"];
                        oCiasE.DscAppaterno = (string) dr["dsc_appaterno"];
                        oCiasE.DscApmaterno = (string) dr["dsc_apmaterno"];
                        oCiasE.DscSegundonombre = (string) dr["dsc_segundonombre"];
                        oCiasE.DscPrimernombre = (string) dr["dsc_primernombre"];
                        oCiasE.CodUbigeo = (string) dr["cod_ubigeo"];
                        oCiasE.NumDiaspago = (int) dr["num_diaspago"];
                        oCiasE.Cardcode = (string) dr["cardcode"];
                        oCiasE.FlgEnviosap = (bool) dr["flg_enviosap"];
                        oCiasE.FecEnviosap = (DateTime) dr["fec_enviosap"];
                        oCiasE.IdeDocentrysap = (int) dr["ide_docentrysap"];
                        oCiasE.FecDocentrysap = (DateTime) dr["fec_docentrysap"];
                        oCiasE.FecRecepcionsap = (DateTime) dr["fec_recepcionsap"];
                        oCiasE.FlagServicio = (int) dr["flag_servicio"];
                        break;
                    }
            }
            return oCiasE;
        }

        public List<CiasE> Sp_Cias_Consulta(CiasE pCiasE)
        {
            IDataReader dr;
            CiasE oCiasE = null/* TODO Change to default(_) if this is not a reference type */;
            List<CiasE> oListar = new List<CiasE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Cias_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@orden", pCiasE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oCiasE = LlenarEntidad(dr, pCiasE);
                            oListar.Add(oCiasE);
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

        public bool Sp_Cias_Insert(CiasE pCiasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Cias_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codigo", ParameterDirection.InputOutput, SqlDbType.VarChar, 20, pCiasE.Codcia));

                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pCiasE.Codcia = (string)cmd.Parameters["@codigo"].Value;
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

        public bool Sp_Cias_Update(CiasE pCiasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Cias_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@campo", pCiasE.Campo);
                        cmd.Parameters.AddWithValue("@codigo", pCiasE.Codcia);
                        cmd.Parameters.AddWithValue("@nuevovalor", pCiasE.NuevoValor);

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
