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
    public class AseguradosAD
    {
        private AseguradosE LlenarEntidad(IDataReader dr, AseguradosE pAseguradosE)
        {
            AseguradosE oAseguradosE = new AseguradosE();

            oAseguradosE.CodAtencion = (string) dr["codatencion"];
            oAseguradosE.Poliza = (string) dr["poliza"];
            oAseguradosE.Planpoliza = (string) dr["planpoliza"];
            oAseguradosE.Codparentesco = (string) dr["codparentesco"];
            oAseguradosE.Codtarifa = (string) dr["codtarifa"];
            oAseguradosE.Fechainiciovigencia = (DateTime) dr["fechainiciovigencia"];
            oAseguradosE.Fechafinvigencia = (DateTime) dr["fechafinvigencia"];
            oAseguradosE.Numerodiasatencion = (int) dr["numerodiasatencion"];
            oAseguradosE.Nombres = (string) dr["nombres"];
            oAseguradosE.Sexo = (string) dr["sexo"];
            oAseguradosE.Fechanacimiento = (DateTime) dr["fechanacimiento"];
            oAseguradosE.Observaciones = (string) dr["observaciones"];
            oAseguradosE.Estado = (string) dr["estado"];
            oAseguradosE.Codigoaseguradoexterno = (string) dr["codigoaseguradoexterno"];
            oAseguradosE.Tiposeguroexterno = (string) dr["tiposeguroexterno"];
            oAseguradosE.Codproducto = (string) dr["codproducto"];

            return oAseguradosE;
        }

        public List<AseguradosE> Sp_Asegurados_Consulta(AseguradosE pAseguradosE)
        {
            IDataReader dr;
            AseguradosE oAseguradosE = null/* TODO Change to default(_) if this is not a reference type */;
            List<AseguradosE> oListar = new List<AseguradosE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Asegurados_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pAseguradosE.CodAtencion);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oAseguradosE = LlenarEntidad(dr, pAseguradosE);
                            oListar.Add(oAseguradosE);
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

        public bool Sp_Asegurados_Insert(AseguradosE pAseguradosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Asegurados_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codigo", ParameterDirection.InputOutput, SqlDbType.VarChar, 8, pAseguradosE.CodAtencion));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pAseguradosE.CodAtencion = (string)cmd.Parameters["@codigo"].Value;
                            return true;
                        }
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

        public bool Sp_Asegurados_Update(AseguradosE pAseguradosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Asegurados_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codigo", pAseguradosE.CodAtencion);
                        cmd.Parameters.AddWithValue("@campo", pAseguradosE.Campo);
                        cmd.Parameters.AddWithValue("@nuevovalor", pAseguradosE.NuevoValor);
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

        public bool Sp_Asegurados_Delete(AseguradosE pAseguradosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Asegurados_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codatencion", pAseguradosE.CodAtencion);
                        // Parametros del Store
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
