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
    public class RcePahMedicacionItemsMaeAD
    {
        private RcePahMedicacionItemsMaeE LlenarEntidad(IDataReader dr, RcePahMedicacionItemsMaeE pRcePahMedicacionItemsMaeE)
        {
            RcePahMedicacionItemsMaeE oRcePahMedicacionItemsMaeE = new RcePahMedicacionItemsMaeE();
            switch (pRcePahMedicacionItemsMaeE.Orden)
            {
                case 1:
                    {
                        oRcePahMedicacionItemsMaeE.DscItem = (string) dr["dsc_item"];
                        oRcePahMedicacionItemsMaeE.DscSubItem = (string) dr["dsc_sub_item"];
                        oRcePahMedicacionItemsMaeE.FlgEstado = (string) dr["flg_estado"];
                        oRcePahMedicacionItemsMaeE.IdeMedicacionItemsMae = (int) dr["ide_medicacion_items_mae"];
                        break;
                    }
            }
            return oRcePahMedicacionItemsMaeE;
        }

        public List<RcePahMedicacionItemsMaeE> Sp_RcePahMedicacionItemsMae_Consulta(RcePahMedicacionItemsMaeE pRcePahMedicacionItemsMaeE)
        {
            IDataReader dr;
            RcePahMedicacionItemsMaeE oRcePahMedicacionItemsMaeE = null/* TODO Change to default(_) if this is not a reference type */;
            List<RcePahMedicacionItemsMaeE> oListar = new List<RcePahMedicacionItemsMaeE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_RcePahMedicacionItemsMae_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_medicacion_items_mae", pRcePahMedicacionItemsMaeE.IdeMedicacionItemsMae);
                        cmd.Parameters.AddWithValue("@orden", pRcePahMedicacionItemsMaeE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oRcePahMedicacionItemsMaeE = LlenarEntidad(dr, pRcePahMedicacionItemsMaeE);
                            oListar.Add(oRcePahMedicacionItemsMaeE);
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
