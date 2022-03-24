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
    public class TablasAD
    {
        private TablasE LlenarEntidad(IDataReader dr, TablasE pTablasE)
        {
            TablasE oTablasE = new TablasE();
            switch (pTablasE.Orden)
            {
                case -1:
                case 4:
                    {
                        oTablasE.Codtabla = (string) dr["codtabla"];
                        oTablasE.Codigo = (string) dr["codigo"];
                        oTablasE.Nombre = (string) dr["nombre"];
                        oTablasE.Valor = (double)dr["valor"];//IIf(IsDBNull(dr("valor")), 0, dr("valor"];
                        oTablasE.Estado = (string) dr["estado"];
                        break;
                    }

                case 7:
                    {
                        oTablasE.Codtabla = (string) dr["codtabla"];
                        oTablasE.Codigo = (string) dr["codigo"];
                        oTablasE.Nombre = (string) dr["nombre"];
                        oTablasE.Valor = (double)dr["valor"]; //IIf(IsDBNull(dr("valor")), 0, dr("valor"];
                        oTablasE.Estado = (string) dr["estado"];
                        break;
                    }

                case 8:
                    {
                        oTablasE.Codtabla = (string) dr["codtabla"];
                        oTablasE.Codigo = (string) dr["codigo"];
                        oTablasE.Nombre = (string) dr["nombre"];
                        oTablasE.Valor = (double)dr["valor"]; //IIf(IsDBNull(dr("valor")), 0, dr("valor"];
                        oTablasE.Estado = (string) dr["estado"];
                        break;
                    }

                case 9:
                    {
                        oTablasE.Codigo = (string) dr["codigo"];
                        oTablasE.Nombre = (string) dr["nombre"];
                        break;
                    }

                case 16:
                    {
                        oTablasE.Codigo = (string) dr["codigo"];
                        oTablasE.Nombre = (string) dr["codtabla"];
                        break;
                    }

                case 19:
                    {
                        oTablasE.Codtabla = (string) dr["codtabla"];
                        oTablasE.Codigo = (string) dr["codigo"];
                        oTablasE.Nombre = (string) dr["nombre"];
                        oTablasE.Valor = (double)dr["valor"]; //IIf(IsDBNull(dr("valor")), 0, dr("valor"];
                        oTablasE.Estado = (string) dr["estado"];
                        break;
                    }
            }
            return oTablasE;
        }

        public TablasE Sp_Tablas_ConsultaEntidad(TablasE pTablasE)
        {
            IDataReader dr;
            TablasE oTablasE = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Tablas_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codtabla", pTablasE.Codtabla);
                        cmd.Parameters.AddWithValue("@buscar", pTablasE.Buscar);
                        cmd.Parameters.AddWithValue("@key", pTablasE.Key);
                        cmd.Parameters.AddWithValue("@numerolineas", pTablasE.NumeroLineas);
                        cmd.Parameters.AddWithValue("@orden", pTablasE.Orden);

                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                            oTablasE = LlenarEntidad(dr, pTablasE);

                        dr.Close(); // Se cierre la conexión.
                        dr.Dispose(); // Se liberan todos los recursos del data reader.
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.

                        return oTablasE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Sp_Tablas_Consulta: " + ex.Message);
            }
        }

        public List<TablasE> Sp_Tablas_Consulta(TablasE pTablasE)
        {
            IDataReader dr;
            TablasE oTablasE = null/* TODO Change to default(_) if this is not a reference type */;
            List<TablasE> oListar = new List<TablasE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Tablas_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codtabla", pTablasE.Codtabla);
                        cmd.Parameters.AddWithValue("@buscar", pTablasE.Buscar);
                        cmd.Parameters.AddWithValue("@key", pTablasE.Key);
                        cmd.Parameters.AddWithValue("@numerolineas", pTablasE.NumeroLineas);
                        cmd.Parameters.AddWithValue("@orden", pTablasE.Orden);

                        cnn.Open();
                        dr = cmd.ExecuteReader();

                        if (pTablasE.RegistroBlanco == true)
                            oListar.Add(new TablasE());
                        while (dr.Read())
                        {
                            oTablasE = LlenarEntidad(dr, pTablasE);
                            oListar.Add(oTablasE);
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
                throw new Exception("Clase Sp_Tablas_Consulta: " + ex.Message);
            }
        }

        public bool Sp_Tablas_Update(TablasE pTablasE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Tablas_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codigotabla", pTablasE.Codtabla);
                        cmd.Parameters.AddWithValue("@codigo", pTablasE.Codigo);
                        cmd.Parameters.AddWithValue("@nuevovalor", pTablasE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pTablasE.Campo);

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
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///         ''' Devuelve el estado del RisPacs
        ///         ''' </summary>
        ///         ''' <param name="pTablasE">Enviar en el @buscar el codigo a buscar, también mandamos por defecto el valor -1 al orden.</param>
        ///         ''' <returns></returns>
        public List<TablasE> Sp_Ris_Consulta_RisPacs(TablasE pTablasE)
        {
            IDataReader dr;
            TablasE oTablasE = null/* TODO Change to default(_) if this is not a reference type */;
            List<TablasE> oListar = new List<TablasE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Ris_Consulta_RisPacs", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@buscar", pTablasE.Buscar);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oTablasE = LlenarEntidad(dr, pTablasE);
                            oListar.Add(oTablasE);
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
                throw new Exception("Clase Sp_Ris_Consulta_RisPacs: " + ex.Message);
            }
        }
    }
}
