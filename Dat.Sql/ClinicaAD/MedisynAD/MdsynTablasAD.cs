using Ent.Sql.ClinicaE.MedisynE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.MedisynAD
{
    public class MdsynTablasAD
    {
        private MdsynTablasE LlenarEntidad(IDataReader dr, MdsynTablasE pMdsynTablasE)
        {
            MdsynTablasE oMdsynTablasE = new MdsynTablasE();
            switch (pMdsynTablasE.Orden)
            {
                case 1:
                    {
                        oMdsynTablasE.Codtabla = (string) dr["codtabla"];
                        oMdsynTablasE.Codigo = (string) dr["codigo"];
                        oMdsynTablasE.Nombre = (string) dr["nombre"];
                        oMdsynTablasE.Valor = (double) dr["valor"];
                        oMdsynTablasE.Estado = (string) dr["estado"];
                        break;
                    }
            }
            return oMdsynTablasE;
        }

        public List<MdsynTablasE> Sp_MdsynTablas_Consulta(MdsynTablasE pMdsynTablasE)
        {
            IDataReader dr;
            MdsynTablasE oMdsynTablasE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MdsynTablasE> oListar = new List<MdsynTablasE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynTablas_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codtabla", pMdsynTablasE.Codtabla);
                        cmd.Parameters.AddWithValue("@codigo", pMdsynTablasE.Codigo);
                        cmd.Parameters.AddWithValue("@estado", pMdsynTablasE.Estado);
                        cmd.Parameters.AddWithValue("@nombre", pMdsynTablasE.Nombre);
                        cmd.Parameters.AddWithValue("@orden", pMdsynTablasE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMdsynTablasE = LlenarEntidad(dr, pMdsynTablasE);
                            oListar.Add(oMdsynTablasE);
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

        public bool Sp_MdsynTablas_Insert(MdsynTablasE pMdsynTablasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynTablas_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codtabla", pMdsynTablasE.Codtabla);
                        cmd.Parameters.AddWithValue("@codigo", pMdsynTablasE.Codigo);
                        cmd.Parameters.AddWithValue("@nombre", pMdsynTablasE.Nombre);
                        cmd.Parameters.AddWithValue("@valor", pMdsynTablasE.Valor);
                        cmd.Parameters.AddWithValue("@estado", pMdsynTablasE.Estado);
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

        public bool Sp_MdsynTablas_Update(MdsynTablasE pMdsynTablasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynTablas_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codtabla", pMdsynTablasE.Codtabla);
                        cmd.Parameters.AddWithValue("@codigo", pMdsynTablasE.Codigo);
                        cmd.Parameters.AddWithValue("@nombre", pMdsynTablasE.Nombre);
                        cmd.Parameters.AddWithValue("@valor", pMdsynTablasE.Valor);
                        cmd.Parameters.AddWithValue("@estado", pMdsynTablasE.Estado);
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

        public bool Sp_MdsynTablas_UpdatexCampo(MdsynTablasE pMdsynTablasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynTablas_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@nuevo_valor", pMdsynTablasE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pMdsynTablasE.Campo);
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

        public bool Sp_MdsynTablas_Delete(MdsynTablasE pMdsynTablasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynTablas_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
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
