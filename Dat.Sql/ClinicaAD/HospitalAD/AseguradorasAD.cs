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
    public class AseguradorasAD
    {
        private AseguradorasE LlenarEntidad(IDataReader dr, AseguradorasE pAseguradorasE)
        {
            AseguradorasE oAseguradorasE = new AseguradorasE();
            switch (pAseguradorasE.Orden)
            {
                case 1:
                    {
                        oAseguradorasE.Codaseguradora = (string) (string) dr["codaseguradora"];
                        oAseguradorasE.Nombre = (string) dr["nombre"];
                        oAseguradorasE.Direccion = (string) dr["direccion"];
                        oAseguradorasE.Telefono = (string) dr["telefono"];
                        oAseguradorasE.Ruc = (string) dr["ruc"];
                        oAseguradorasE.Contacto = (string) dr["contacto"];
                        oAseguradorasE.Estado = (bool) dr["estado"];
                        oAseguradorasE.Tipoaseguradora = (string) dr["tipoaseguradora"];
                        oAseguradorasE.Tarifaambulatorio = (string) dr["tarifaambulatorio"];
                        oAseguradorasE.Tarifaemergencia = (string) dr["tarifaemergencia"];
                        oAseguradorasE.Tarifahospital = (string) dr["tarifahospital"];
                        oAseguradorasE.Tarifaspectmedic = (string) dr["tarifaspectmedic"];
                        oAseguradorasE.Diaspago = (int) dr["diaspago"];
                        oAseguradorasE.Correo = (string) dr["correo"];
                        oAseguradorasE.CodEpss = (string) dr["cod_epss"];
                        oAseguradorasE.CodUbigeo = (string) dr["cod_ubigeo"];
                        oAseguradorasE.Cardcode = (string) dr["cardcode"];
                        oAseguradorasE.FlgEnviosap = (bool) dr["flg_enviosap"];
                        oAseguradorasE.FecEnviosap = (DateTime) dr["fec_enviosap"];
                        oAseguradorasE.IdeDocentrysap = (int) dr["ide_docentrysap"];
                        oAseguradorasE.FecDocentrysap = (DateTime) dr["fec_docentrysap"];
                        oAseguradorasE.FecRecepcionsap = (DateTime) dr["fec_recepcionsap"];
                        break;
                    }

                case 8:
                    {
                        oAseguradorasE.Codaseguradora = ((string) dr["codaseguradora"] + "").Trim();
                        oAseguradorasE.Nombre = ((string) dr["nombre"] + "").Trim();
                        oAseguradorasE.CodEpss = ((string) dr["cod_epss"] + "").Trim();
                        break;
                    }
            }
            return oAseguradorasE;
        }

        public List<AseguradorasE> Sp_Aseguradoras_Consulta(AseguradorasE pAseguradorasE)
        {
            IDataReader dr;
            AseguradorasE oAseguradorasE = null/* TODO Change to default(_) if this is not a reference type */;
            List<AseguradorasE> oListar = new List<AseguradorasE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Aseguradoras_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@buscar", pAseguradorasE.Buscar);
                        cmd.Parameters.AddWithValue("@key", pAseguradorasE.Key);
                        cmd.Parameters.AddWithValue("@numerolineas", pAseguradorasE.NumeroLineas);
                        cmd.Parameters.AddWithValue("@orden", pAseguradorasE.Orden);

                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oAseguradorasE = LlenarEntidad(dr, pAseguradorasE);
                            oListar.Add(oAseguradorasE);
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

        public bool Sp_Aseguradoras_Insert(AseguradorasE pAseguradorasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Aseguradoras_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        // @codigo lc_codatencion output
                        cmd.Parameters.AddWithValue("@codigo", pAseguradorasE.CodAtencion);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            // pAseguradorasE.CodAtencion = cmd.Parameters("codigo").Value
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

        public bool Sp_Aseguradoras_Update(AseguradorasE pAseguradorasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Aseguradoras_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@campo", pAseguradorasE.Campo);
                        cmd.Parameters.AddWithValue("@codigo", pAseguradorasE.CodAtencion);
                        cmd.Parameters.AddWithValue("@nuevovalor", pAseguradorasE.NuevoValor);
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
