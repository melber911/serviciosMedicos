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
    partial class CoberturaPolizaAD
    {
        private CoberturaPolizaE LlenarEntidad(IDataReader dr, CoberturaPolizaE pCoberturapolizaE, int pOrden = 1)
        {
            CoberturaPolizaE oCoberturapolizaE = new CoberturaPolizaE();

            switch (pOrden)
            {
                case 1:
                    {
                        oCoberturapolizaE.CodAtencion = (string) dr["codatencion"];
                        oCoberturapolizaE.TipoCobertura = (string) dr["tipocobertura"];
                        oCoberturapolizaE.Nombre = (string) dr["nombre"];
                        oCoberturapolizaE.Tipomonto = (string) dr["tipomonto"];
                        oCoberturapolizaE.Monto = (double) dr["monto"];
                        oCoberturapolizaE.Moneda = (string) dr["moneda"];
                        oCoberturapolizaE.Igv = (string) dr["igv"];
                        oCoberturapolizaE.Observaciones = (string) dr["observaciones"];
                        oCoberturapolizaE.Estado = (string) dr["estado"];
                        oCoberturapolizaE.CodCobertura = (string) dr["codcobertura"];
                        oCoberturapolizaE.Codbeneficio = (string) dr["codbeneficio"];
                        oCoberturapolizaE.Csubtipocobertura = (string) dr["cSubTipoCobertura"];
                        oCoberturapolizaE.Csitedsvs = (string) dr["cSitedsVs"];
                        oCoberturapolizaE.Idcobertura = (int) dr["idcobertura"];
                        break;
                    }

                case 2:
                    {
                        oCoberturapolizaE.TipoCobertura = (string) dr["tipocobertura"];
                        oCoberturapolizaE.Nombre = (string) dr["nombre"];
                        oCoberturapolizaE.Tipomonto = (string) dr["tipomonto"];
                        oCoberturapolizaE.Monto = (double) dr["monto"];
                        oCoberturapolizaE.Moneda = (string) dr["moneda"];
                        oCoberturapolizaE.Igv = (string) dr["igv"];
                        oCoberturapolizaE.Observaciones = (string) dr["observaciones"];
                        oCoberturapolizaE.Estado = (string) dr["estado"];
                        oCoberturapolizaE.CodCobertura = (string) dr["codcobertura"];
                        oCoberturapolizaE.Codbeneficio = (string) dr["codbeneficio"];
                        break;
                    }
            }


            return oCoberturapolizaE;
        }

        public List<CoberturaPolizaE> Sp_CoberturaPoliza_Consulta(CoberturaPolizaE pCoberturapolizaE)
        {
            IDataReader dr;
            CoberturaPolizaE oCoberturapolizaE = null/* TODO Change to default(_) if this is not a reference type */;
            List<CoberturaPolizaE> oListar = new List<CoberturaPolizaE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_CoberturaPoliza_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pCoberturapolizaE.CodAtencion);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oCoberturapolizaE = LlenarEntidad(dr, pCoberturapolizaE);
                            oListar.Add(oCoberturapolizaE);
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

        public bool Sp_CoberturaPoliza_Insert(CoberturaPolizaE pCoberturapolizaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_CoberturaPoliza_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@tipocobertura", pCoberturapolizaE.TipoCobertura);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codigo", ParameterDirection.InputOutput, SqlDbType.VarChar, 8, pCoberturapolizaE.CodAtencion));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pCoberturapolizaE.CodAtencion = (string)cmd.Parameters["@codigo"].Value;
                            return true;
                        }
                        else
                            return false;
                        cmd.Dispose(); // Se liberan todos los recursos de la 
                        cnn.Close(); // Se cierre la conexión
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_CoberturaPoliza_Update(CoberturaPolizaE pCoberturapolizaE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_CoberturaPoliza_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@campo", pCoberturapolizaE.Campo);
                        cmd.Parameters.AddWithValue("@codigo", pCoberturapolizaE.CodAtencion);
                        cmd.Parameters.AddWithValue("@tipocobertura", pCoberturapolizaE.TipoCobertura);
                        cmd.Parameters.AddWithValue("@nuevovalor", pCoberturapolizaE.NuevoValor);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else
                            return false;
                        cmd.Dispose(); // Se liberan todos los recursos de la 
                        cnn.Close(); // Se cierre la conexión
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "<br/>@campo: " + pCoberturapolizaE.Campo + "<br/>@codigo: " + pCoberturapolizaE.CodAtencion + "@tipocobertura: " + pCoberturapolizaE.TipoCobertura + "<br/>@nuevovalor: " + pCoberturapolizaE.NuevoValor);
            }
        }

        public List<CoberturaPolizaE> Sp_CoberturaPolizaColsanitas_Consulta(CoberturaPolizaE pCoberturapolizaE)
        {
            IDataReader dr;
            CoberturaPolizaE oCoberturapolizaE = null/* TODO Change to default(_) if this is not a reference type */;
            List<CoberturaPolizaE> oListar = new List<CoberturaPolizaE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_CoberturaPolizaColsanitas_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pCoberturapolizaE.CodAtencion);
                        cmd.Parameters.AddWithValue("@codcobertura", pCoberturapolizaE.TipoCobertura);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oCoberturapolizaE = LlenarEntidad(dr, pCoberturapolizaE, 2);
                            oListar.Add(oCoberturapolizaE);
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
    }
}
