using Ent.Sql.ClinicaE.RceE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.RceAD
{
    public class RcePahMedicacionDetAD
    {
        private RcePahMedicacionDetE LlenarEntidad(IDataReader dr, RcePahMedicacionDetE pRcePahMedicacionDetE)
        {
            RcePahMedicacionDetE oRcePahMedicacionDetE = new RcePahMedicacionDetE();
            switch (pRcePahMedicacionDetE.Orden)
            {
                case 1:
                    {
                        oRcePahMedicacionDetE.IdeMedicacionCab = (int) dr["ide_medicacion_cab"];
                        oRcePahMedicacionDetE.IdeMedicacionDet = (int) dr["ide_medicacion_det"];
                        oRcePahMedicacionDetE.IdeMedicacionItemsMae = (int) dr["ide_medicacion_items_mae"];
                        oRcePahMedicacionDetE.DscItem = (string) dr["dsc_item"];
                        oRcePahMedicacionDetE.DscSubItem = (string) dr["dsc_sub_item"];
                        oRcePahMedicacionDetE.FlgRespuesta = (string) dr["flg_respuesta"];
                        break;
                    }
            }
            return oRcePahMedicacionDetE;
        }

        public List<RcePahMedicacionDetE> Sp_RcePahMedicacionDet_Consulta(RcePahMedicacionDetE pRcePahMedicacionDetE)
        {
            IDataReader dr;
            RcePahMedicacionDetE oRcePahMedicacionDetE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahMedicacionDetE> oListar = new List<RcePahMedicacionDetE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionDet_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_medicacion_det", pRcePahMedicacionDetE.IdeMedicacionDet);
                        cmd.Parameters.AddWithValue("@ide_medicacion_cab", pRcePahMedicacionDetE.IdeMedicacionCab);
                        cmd.Parameters.AddWithValue("@orden", pRcePahMedicacionDetE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahMedicacionDetE = LlenarEntidad(dr, pRcePahMedicacionDetE);
                            oListar.Add(oRcePahMedicacionDetE);
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

        public bool Sp_RcePahMedicacionDet_Insert(RcePahMedicacionDetE pRcePahMedicacionDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionDet_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_medicacion_cab", pRcePahMedicacionDetE.IdeMedicacionCab);
                        cmd.Parameters.AddWithValue("@ide_medicacion_items_mae", pRcePahMedicacionDetE.IdeMedicacionItemsMae);
                        cmd.Parameters.AddWithValue("@flg_respuesta", pRcePahMedicacionDetE.FlgRespuesta);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_medicacion_det", ParameterDirection.InputOutput, SqlDbType.Int, 8, pRcePahMedicacionDetE.IdeMedicacionDet.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pRcePahMedicacionDetE.IdeMedicacionDet = (int)cmd.Parameters["@ide_medicacion_det"].Value;
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

        public bool Sp_RcePahMedicacionDet_Update(RcePahMedicacionDetE pRcePahMedicacionDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionDet_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_medicacion_cab", pRcePahMedicacionDetE.IdeMedicacionCab);
                        cmd.Parameters.AddWithValue("@ide_medicacion_items_mae", pRcePahMedicacionDetE.IdeMedicacionItemsMae);
                        cmd.Parameters.AddWithValue("@flg_respuesta", pRcePahMedicacionDetE.FlgRespuesta);
                        cmd.Parameters.AddWithValue("@fec_registro", pRcePahMedicacionDetE.FecRegistro);
                        cmd.Parameters.AddWithValue("@ide_medicacion_det", pRcePahMedicacionDetE.IdeMedicacionDet);
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

        public bool Sp_RcePahMedicacionDet_UpdatexCampo(RcePahMedicacionDetE pRcePahMedicacionDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionDet_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_medicacion_det", pRcePahMedicacionDetE.IdeMedicacionDet);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pRcePahMedicacionDetE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pRcePahMedicacionDetE.Campo);
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

        public bool Sp_RcePahMedicacionDet_Delete(RcePahMedicacionDetE pRcePahMedicacionDetE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionDet_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_medicacion_det", pRcePahMedicacionDetE.IdeMedicacionDet);
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
