using Ent.Sql.ClinicaE.LiquidacionesE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.LiquidacionesAD
{
    public class LiquidacionesAD
    {
        private LiquidacionesE LlenarEntidad(IDataReader dr, LiquidacionesE pLiquidacionesE)
        {
            LiquidacionesE oLiquidacionesE = new LiquidacionesE();

            try
            {
                oLiquidacionesE.CodLiquidacion = (string) dr["codliquidacion"];
                oLiquidacionesE.CodAtencion = (string) dr["codatencion"] + "";
                oLiquidacionesE.Codcomprobante = (string) dr["codcomprobante"] + "";
                oLiquidacionesE.Fechagenerada = (DateTime) dr["fechagenerada"];
                oLiquidacionesE.Estado = (string) dr["estado"] + "";
                oLiquidacionesE.Monto = (double) dr["monto"];
                oLiquidacionesE.Paraquienseliquida = (string) dr["paraquienseliquida"] + "";
                oLiquidacionesE.Fechaprocesada = (DateTime) dr["fechaprocesada"];//Interaction.IIf(Information.IsDBNull(dr["fechaprocesada"]), DateTime.Now.Date, dr["fechaprocesada"]);
                oLiquidacionesE.Fechaanulada = (DateTime)dr["fechaanulada"];//Interaction.IIf(Information.IsDBNull(dr["fechaanulada"]), DateTime.Now.Date, dr["fechaanulada"]);
                oLiquidacionesE.Fechainicio = (DateTime)dr["fechainicio"];//Interaction.IIf(Information.IsDBNull(dr["fechainicio"]), DateTime.Now.Date, dr["fechainicio"]);
                oLiquidacionesE.Fechafin = (DateTime)dr["fechafin"];//Interaction.IIf(Information.IsDBNull(dr["fechafin"]), DateTime.Now.Date, dr["fechafin"]);
                oLiquidacionesE.Deducible = (decimal) dr["deducible"];
                oLiquidacionesE.Coaseguro = (decimal) dr["coaseguro"];
                oLiquidacionesE.Deduciblecarta = (decimal) dr["deduciblecarta"];
                oLiquidacionesE.Difcobertura = (decimal) dr["difcobertura"];
                oLiquidacionesE.Pagadeducible = (string) dr["pagadeducible"];
                oLiquidacionesE.Pagacoaseguro = (string) dr["pagacoaseguro"];
                oLiquidacionesE.Pagagnc = (string) dr["pagagnc"];
                oLiquidacionesE.Anombredequien = (string)(dr["anombredequien"] + "").Trim();
                oLiquidacionesE.Ruc = (string) dr["ruc"] + "";
                oLiquidacionesE.Montoinafecto = (double) dr["montoinafecto"];
                oLiquidacionesE.Codaseguradora = (string) dr["codaseguradora"];
                oLiquidacionesE.Codcia = (string) dr["codcia"] + "";
                oLiquidacionesE.Codpoliza = (string)(dr["codpoliza"] + "").Trim();
                oLiquidacionesE.Planpoliza = (string) dr["planpoliza"];
                oLiquidacionesE.Tipoimpresion = (string) dr["tipoimpresion"] + "";
                oLiquidacionesE.FlgGratuito = (bool) dr["flg_gratuito"];
            }
            catch (Exception ex)
            {
            }

            return oLiquidacionesE;
        }

        public List<LiquidacionesE> Sp_Liquidaciones_Consulta(LiquidacionesE pLiquidacionesE)
        {
            IDataReader dr;
            LiquidacionesE oLiquidacionesE = null/* TODO Change to default(_) if this is not a reference type */;
            List<LiquidacionesE> oListar = new List<LiquidacionesE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Liquidaciones_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codliquidacion", pLiquidacionesE.CodLiquidacion);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oLiquidacionesE = LlenarEntidad(dr, pLiquidacionesE);
                            oListar.Add(oLiquidacionesE);
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

        public bool Sp_Liquidaciones_Insert(LiquidacionesE pLiquidacionesE)
        {
            bool result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Liquidaciones_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pLiquidacionesE.CodAtencion);
                        cmd.Parameters.AddWithValue("@codpresotor", pLiquidacionesE.CodPresotor);
                        cmd.Parameters.AddWithValue("@quien", pLiquidacionesE.QuienCreoRegistro);
                        cmd.Parameters.AddWithValue("@tipo", pLiquidacionesE.Tipo);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codliquidacion", ParameterDirection.InputOutput, SqlDbType.VarChar, 12, pLiquidacionesE.CodLiquidacion));
                        cnn.Open();

                        cmd.ExecuteNonQuery();
                        pLiquidacionesE.CodLiquidacion = (string)cmd.Parameters["@codliquidacion"].Value;
                        if (pLiquidacionesE.CodLiquidacion != "")
                            result = true;

                        cmd.Dispose(); // Se liberan todos los recursos de la 
                        cnn.Close(); // Se cierre la conexión
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_LiquidacionesRecalculo_Update(LiquidacionesE pLiquidacionesE)
        {
            bool Result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_LiquidacionesRecalculo_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codatencion", pLiquidacionesE.CodAtencion);
                        cmd.Parameters.AddWithValue("@quien", pLiquidacionesE.QuienCreoRegistro);
                        cmd.Parameters.AddWithValue("@codliquidacion", pLiquidacionesE.CodLiquidacion);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        Result = true;

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

            return Result;
        }

        public bool Sp_Liquidaciones_Delete(LiquidacionesE pLiquidacionesE)
        {
            int xReturn;
            bool Result = true;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Liquidaciones_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@return", "").Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.AddWithValue("@codliquidacion", pLiquidacionesE.CodLiquidacion);
                        cnn.Open();

                        cmd.ExecuteNonQuery();

                        xReturn = Convert.ToInt32(cmd.Parameters["@return"].Value);
                        if (xReturn == 0)
                            Result = true;

                        cmd.Dispose(); // Se liberan todos los recursos de la 
                        cnn.Close(); // Se cierre la conexión
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Liquidaciones_Update(LiquidacionesE pLiquidacionesE)
        {
            bool Result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Liquidaciones_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@campo", pLiquidacionesE.Campo);
                        cmd.Parameters.AddWithValue("@codigo", pLiquidacionesE.CodLiquidacion);
                        cmd.Parameters.AddWithValue("@nuevovalor", pLiquidacionesE.NuevoValor);
                        cnn.Open();

                        int exito = cmd.ExecuteNonQuery();
                        if (exito >= 1)
                            Result = true;
                        else
                            Result = false;

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

            return Result;
        }
    }
}
