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
    public class MdsynPagosAD
    {
        private MdsynPagosE LlenarEntidad(IDataReader dr, MdsynPagosE pMdsynPagosE)
        {
            MdsynPagosE oMdsynPagosE = new MdsynPagosE();
            switch (pMdsynPagosE.Orden)
            {
                case "1":
                    {
                        oMdsynPagosE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];

                        oMdsynPagosE.objSynapsisOrderApiBot.number = (string) dr["number"];
                        oMdsynPagosE.objSynapsisOrderApiBot.amount = (string) dr["amount"]; // CDec(dr("amount")).ToString("####0.00")

                        oMdsynPagosE.objSynapsisOrderApiBot.cust_name = (string) dr["cust_name"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_lastname = (string) dr["cust_lastname"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_phone = (string) dr["cust_phone"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_email = (string) dr["cust_email"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_doc_type = (string) dr["cust_doc_type"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_doc_number = (string) dr["cust_doc_number"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_adress_country = (string) dr["cust_adress_country"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_adress_levels = (string) dr["cust_adress_levels"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_adress_line1 = (string) dr["cust_adress_line1"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_adress_zip = (string) dr["cust_adress_zip"];
                        oMdsynPagosE.objSynapsisOrderApiBot.currency_code = (string) dr["currency_code"];
                        oMdsynPagosE.objSynapsisOrderApiBot.country_code = (string) dr["country_code"];

                        oMdsynPagosE.objSynapsisOrderApiBot.products_name = (string) dr["products_name"];
                        oMdsynPagosE.objSynapsisOrderApiBot.products_quantity = (string) dr["products_quantity"];
                        oMdsynPagosE.objSynapsisOrderApiBot.products_unitAmount = (string) dr["products_unitAmount"];
                        oMdsynPagosE.objSynapsisOrderApiBot.products_amount = (string) dr["products_amount"];

                        oMdsynPagosE.objSynapsisOrderApiBot.ordTyp_code = (string) dr["ordTyp_code"];
                        oMdsynPagosE.objSynapsisOrderApiBot.targTyp_code = (string) dr["targTyp_code"];

                        oMdsynPagosE.objSynapsisOrderApiBot.setting_expiration_date = (DateTime) dr["setting_expiration_date"];

                        oMdsynPagosE.objSynapsisOrderApiBot.header_ApiKey = (string) dr["header_ApiKey"];
                        oMdsynPagosE.objSynapsisOrderApiBot.header_SecretKey = (string) dr["header_SecretKey"];
                        break;
                    }

                case "2":
                    {
                        oMdsynPagosE.objSynapsisOrderApiBot.number = (string) dr["number"];
                        oMdsynPagosE.objSynapsisOrderApiBot.amount = (string) dr["amount"]; // CDec(dr("amount")).ToString("####0.00")

                        oMdsynPagosE.objSynapsisOrderApiBot.cust_name = (string) dr["cust_name"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_lastname = (string) dr["cust_lastname"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_phone = (string) dr["cust_phone"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_email = (string) dr["cust_email"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_doc_type = (string) dr["cust_doc_type"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_doc_number = (string) dr["cust_doc_number"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_adress_country = (string) dr["cust_adress_country"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_adress_levels = (string) dr["cust_adress_levels"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_adress_line1 = (string) dr["cust_adress_line1"];
                        oMdsynPagosE.objSynapsisOrderApiBot.cust_adress_zip = (string) dr["cust_adress_zip"];
                        oMdsynPagosE.objSynapsisOrderApiBot.currency_code = (string) dr["currency_code"];
                        oMdsynPagosE.objSynapsisOrderApiBot.country_code = (string) dr["country_code"];

                        oMdsynPagosE.objSynapsisOrderApiBot.products_name = (string) dr["products_name"];
                        oMdsynPagosE.objSynapsisOrderApiBot.products_quantity = (string) dr["products_quantity"];
                        oMdsynPagosE.objSynapsisOrderApiBot.products_unitAmount = (string) dr["products_unitAmount"];
                        oMdsynPagosE.objSynapsisOrderApiBot.products_amount = (string) dr["products_amount"];

                        oMdsynPagosE.objSynapsisOrderApiBot.ordTyp_code = (string) dr["ordTyp_code"];
                        oMdsynPagosE.objSynapsisOrderApiBot.targTyp_code = (string) dr["targTyp_code"];

                        oMdsynPagosE.objSynapsisOrderApiBot.setting_expiration_date = (DateTime) dr["setting_expiration_date"];
                        break;
                    }

                default:
                    {
                        oMdsynPagosE.CodTipo = (string) dr["cod_tipo"];
                        oMdsynPagosE.IdeCorrelReserva = (int) dr["ide_correl_reserva"];
                        oMdsynPagosE.CodVenta = (string) dr["cod_venta"];
                        oMdsynPagosE.CntMontoPago = (decimal) dr["cnt_monto_pago"];
                        oMdsynPagosE.IdeUniqueIdentifier = (string) dr["ide_unique_identifier"];
                        oMdsynPagosE.CodRptaSynapsis = (string) dr["cod_rpta_synapsis"];
                        oMdsynPagosE.UsrRegOrdenSynapsis = (int) dr["usr_reg_orden_synapsis"];
                        oMdsynPagosE.FecRegOrdenSynapsis = (DateTime) dr["fec_reg_orden_synapsis"];
                        oMdsynPagosE.TxtJsonOrden = (string) dr["txt_json_orden"];
                        oMdsynPagosE.EstPagado = (string) dr["est_pagado"];
                        oMdsynPagosE.NroOperacion = (string) dr["nro_operacion"];
                        oMdsynPagosE.TipTarjeta = (string) dr["tip_tarjeta"];
                        oMdsynPagosE.NumTarjeta = (string) dr["num_tarjeta"];
                        oMdsynPagosE.TxtJsonRpta = (string) dr["txt_json_rpta"];
                        oMdsynPagosE.FecRecepcionPago = (DateTime) dr["fec_recepcion_pago"];
                        oMdsynPagosE.IdePagosBot = (int) dr["ide_pagos_bot"];
                        break;
                    }
            }
            return oMdsynPagosE;
        }

        public List<MdsynPagosE> Sp_MdsynPagos_Consulta(MdsynPagosE pMdsynPagosE)
        {
            IDataReader dr;
            MdsynPagosE oMdsynPagosE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MdsynPagosE> oListar = new List<MdsynPagosE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynPagos_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pagos_bot", pMdsynPagosE.IdePagosBot);
                        cmd.Parameters.AddWithValue("@ide_mdsyn_reserva", pMdsynPagosE.IdeMdsynReserva);
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynPagosE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@cod_liquidacion", pMdsynPagosE.CodLiquidacion);
                        cmd.Parameters.AddWithValue("@cod_venta", pMdsynPagosE.CodVenta);
                        cmd.Parameters.AddWithValue("@orden", pMdsynPagosE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMdsynPagosE = LlenarEntidad(dr, pMdsynPagosE);
                            oListar.Add(oMdsynPagosE);
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

        public bool Sp_MdsynPagos_Insert(MdsynPagosE pMdsynPagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynPagos_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_tipo", pMdsynPagosE.CodTipo);
                        cmd.Parameters.AddWithValue("@ide_mdsyn_reserva", pMdsynPagosE.IdeMdsynReserva);
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynPagosE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@cod_liquidacion", pMdsynPagosE.CodLiquidacion);
                        cmd.Parameters.AddWithValue("@cod_venta", pMdsynPagosE.CodVenta);
                        cmd.Parameters.AddWithValue("@cnt_monto_pago", pMdsynPagosE.CntMontoPago);
                        // cmd.Parameters.AddWithValue("@ide_unique_identifier", pMdsynPagosE.IdeUniqueIdentifier)
                        // cmd.Parameters.AddWithValue("@cod_rpta_synapsis", pMdsynPagosE.CodRptaSynapsis)
                        // cmd.Parameters.AddWithValue("@usr_reg_orden_synapsis", pMdsynPagosE.UsrRegOrdenSynapsis)
                        // cmd.Parameters.AddWithValue("@txt_json_orden", pMdsynPagosE.TxtJsonOrden)
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_pagos_bot", ParameterDirection.InputOutput, SqlDbType.BigInt, 8, pMdsynPagosE.IdePagosBot.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pMdsynPagosE.IdePagosBot = (long)cmd.Parameters["@ide_pagos_bot"].Value;
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

        public bool Sp_MdsynPagos_Update(MdsynPagosE pMdsynPagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynPagos_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_tipo", pMdsynPagosE.CodTipo);
                        cmd.Parameters.AddWithValue("@ide_mdsyn_reserva", pMdsynPagosE.IdeMdsynReserva);
                        cmd.Parameters.AddWithValue("@ide_correl_reserva", pMdsynPagosE.IdeCorrelReserva);
                        cmd.Parameters.AddWithValue("@cod_liquidacion", pMdsynPagosE.CodLiquidacion);
                        cmd.Parameters.AddWithValue("@cod_venta", pMdsynPagosE.CodVenta);

                        cmd.Parameters.AddWithValue("@cnt_monto_pago", pMdsynPagosE.CntMontoPago);
                        cmd.Parameters.AddWithValue("@ide_unique_identifier", pMdsynPagosE.IdeUniqueIdentifier);
                        cmd.Parameters.AddWithValue("@cod_rpta_synapsis", pMdsynPagosE.CodRptaSynapsis);
                        cmd.Parameters.AddWithValue("@usr_reg_orden_synapsis", pMdsynPagosE.UsrRegOrdenSynapsis);
                        cmd.Parameters.AddWithValue("@txt_json_orden", pMdsynPagosE.TxtJsonOrden);

                        cmd.Parameters.AddWithValue("@est_pagado", pMdsynPagosE.EstPagado);
                        cmd.Parameters.AddWithValue("@nro_operacion", pMdsynPagosE.NroOperacion);
                        cmd.Parameters.AddWithValue("@tip_tarjeta", pMdsynPagosE.TipTarjeta);
                        cmd.Parameters.AddWithValue("@num_tarjeta", pMdsynPagosE.NumTarjeta);
                        cmd.Parameters.AddWithValue("@txt_json_rpta", pMdsynPagosE.TxtJsonRpta);

                        cmd.Parameters.AddWithValue("@ide_pagos_bot", pMdsynPagosE.IdePagosBot);
                        cmd.Parameters.AddWithValue("@orden", pMdsynPagosE.Orden);
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

        public bool Sp_MdsynPagos_UpdatexCampo(MdsynPagosE pMdsynPagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynPagos_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pagos_bot", pMdsynPagosE.IdePagosBot);
                        cmd.Parameters.AddWithValue("@nuevo_valor", pMdsynPagosE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pMdsynPagosE.Campo);
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

        public bool Sp_MdsynPagos_Delete(MdsynPagosE pMdsynPagosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynPagos_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pagos_bot", pMdsynPagosE.IdePagosBot);
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
