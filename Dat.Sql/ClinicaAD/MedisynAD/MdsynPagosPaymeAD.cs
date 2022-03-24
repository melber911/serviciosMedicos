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
    public class MdsynPagosPaymeAD
    {
        private MdsynPagosPaymeE LlenarEntidad(IDataReader dr, MdsynPagosPaymeE pMdsynPagospaymeE)
        {
            MdsynPagosPaymeE oMdsynPagospaymeE = new MdsynPagosPaymeE();
            switch (pMdsynPagospaymeE.Orden)
            {
                case 1:
                    {
                        oMdsynPagospaymeE.Idecorrelreserva = (long) dr["IdeCorrelReserva"];
                        oMdsynPagospaymeE.Authorizationcode = (string) dr["authorizationCode"];
                        oMdsynPagospaymeE.Bin = (string) dr["bin"];
                        oMdsynPagospaymeE.Shippingcountry = (string) dr["shippingCountry"];
                        oMdsynPagospaymeE.Reserved1 = (string) dr["reserved1"];
                        oMdsynPagospaymeE.Reserved2 = (string) dr["reserved2"];
                        oMdsynPagospaymeE.Shippinglastname = (string) dr["shippingLastName"];
                        oMdsynPagospaymeE.Errorcode = (string) dr["errorCode"];
                        oMdsynPagospaymeE.Idcommerce = (string) dr["idCommerce"];
                        oMdsynPagospaymeE.Shippingcity = (string) dr["shippingCity"];
                        oMdsynPagospaymeE.Txdatetime = (string) dr["txDateTime"];
                        oMdsynPagospaymeE.Purchasecurrencycode = (string) dr["purchaseCurrencyCode"];
                        oMdsynPagospaymeE.Commerceassociated = (string) dr["commerceAssociated"];
                        oMdsynPagospaymeE.Shippingfirstname = (string) dr["shippingFirstName"];
                        oMdsynPagospaymeE.Purchaseoperationnumber = (string) dr["purchaseOperationNumber"];
                        oMdsynPagospaymeE.Shippingphone = (string) dr["shippingPhone"];
                        oMdsynPagospaymeE.Shippingaddress = (string) dr["shippingAddress"];
                        oMdsynPagospaymeE.Reserved22 = (string) dr["reserved22"];
                        oMdsynPagospaymeE.Answermessage = (string) dr["answerMessage"];
                        oMdsynPagospaymeE.Cuota = (string) dr["cuota"];
                        oMdsynPagospaymeE.Paymentreferencecode = (string) dr["paymentReferenceCode"];
                        oMdsynPagospaymeE.Shippingstate = (string) dr["shippingState"];
                        oMdsynPagospaymeE.Brand = (string) dr["brand"];
                        oMdsynPagospaymeE.Mcc = (string) dr["mcc"];
                        oMdsynPagospaymeE.Shippingemail = (string) dr["shippingEmail"];
                        oMdsynPagospaymeE.Shippingzip = (string) dr["shippingZIP"];
                        oMdsynPagospaymeE.Acquirerid = (string) dr["acquirerId"];
                        oMdsynPagospaymeE.Purchaseamount = (string) dr["purchaseAmount"];
                        oMdsynPagospaymeE.Purchaseverification = (string) dr["purchaseVerification"];
                        oMdsynPagospaymeE.Idtransaction = (string) dr["IDTransaction"];
                        oMdsynPagospaymeE.Answercode = (string) dr["answerCode"];
                        oMdsynPagospaymeE.Errormessage = (string) dr["errorMessage"];
                        oMdsynPagospaymeE.Authorizationresult = (string) dr["authorizationResult"];
                        oMdsynPagospaymeE.Reserved23 = (string) dr["reserved23"];
                        oMdsynPagospaymeE.FecRegistro = (DateTime) dr["fec_registro"];
                        oMdsynPagospaymeE.UsrRegistro = (int) dr["usr_registro"];
                        oMdsynPagospaymeE.IdeDagosPayme = (int) dr["ide_dagospayme"];
                        break;
                    }
            }
            return oMdsynPagospaymeE;
        }

        public List<MdsynPagosPaymeE> Sp_MdsynPagospayme_Consulta(MdsynPagosPaymeE pMdsynPagospaymeE)
        {
            IDataReader dr;
            MdsynPagosPaymeE oMdsynPagospaymeE = null/* TODO Change to default(_) if this is not a reference type */;
            List<MdsynPagosPaymeE> oListar = new List<MdsynPagosPaymeE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynPagospayme_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_dagospayme", pMdsynPagospaymeE.IdeDagosPayme);
                        cmd.Parameters.AddWithValue("@orden", pMdsynPagospaymeE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oMdsynPagospaymeE = LlenarEntidad(dr, pMdsynPagospaymeE);
                            oListar.Add(oMdsynPagospaymeE);
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

        public bool Sp_MdsynPagosPayme_Insert(MdsynPagosPaymeE pMdsynPagospaymeE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_MdsynPagosPayme_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@IdeCorrelReserva", pMdsynPagospaymeE.Idecorrelreserva);
                        cmd.Parameters.AddWithValue("@authorizationCode", pMdsynPagospaymeE.Authorizationcode);
                        cmd.Parameters.AddWithValue("@bin", pMdsynPagospaymeE.Bin);
                        cmd.Parameters.AddWithValue("@shippingCountry", pMdsynPagospaymeE.Shippingcountry);
                        cmd.Parameters.AddWithValue("@reserved1", pMdsynPagospaymeE.Reserved1);
                        cmd.Parameters.AddWithValue("@reserved2", pMdsynPagospaymeE.Reserved2);
                        cmd.Parameters.AddWithValue("@shippingLastName", pMdsynPagospaymeE.Shippinglastname);
                        cmd.Parameters.AddWithValue("@errorCode", pMdsynPagospaymeE.Errorcode);
                        cmd.Parameters.AddWithValue("@idCommerce", pMdsynPagospaymeE.Idcommerce);
                        cmd.Parameters.AddWithValue("@shippingCity", pMdsynPagospaymeE.Shippingcity);
                        cmd.Parameters.AddWithValue("@txDateTime", pMdsynPagospaymeE.Txdatetime);
                        cmd.Parameters.AddWithValue("@purchaseCurrencyCode", pMdsynPagospaymeE.Purchasecurrencycode);
                        cmd.Parameters.AddWithValue("@commerceAssociated", pMdsynPagospaymeE.Commerceassociated);
                        cmd.Parameters.AddWithValue("@shippingFirstName", pMdsynPagospaymeE.Shippingfirstname);
                        cmd.Parameters.AddWithValue("@purchaseOperationNumber", pMdsynPagospaymeE.Purchaseoperationnumber);
                        cmd.Parameters.AddWithValue("@shippingPhone", pMdsynPagospaymeE.Shippingphone);
                        cmd.Parameters.AddWithValue("@shippingAddress", pMdsynPagospaymeE.Shippingaddress);
                        cmd.Parameters.AddWithValue("@reserved22", pMdsynPagospaymeE.Reserved22);
                        cmd.Parameters.AddWithValue("@answerMessage", pMdsynPagospaymeE.Answermessage);
                        cmd.Parameters.AddWithValue("@cuota", pMdsynPagospaymeE.Cuota);
                        cmd.Parameters.AddWithValue("@paymentReferenceCode", pMdsynPagospaymeE.Paymentreferencecode);
                        cmd.Parameters.AddWithValue("@shippingState", pMdsynPagospaymeE.Shippingstate);
                        cmd.Parameters.AddWithValue("@brand", pMdsynPagospaymeE.Brand);
                        cmd.Parameters.AddWithValue("@mcc", pMdsynPagospaymeE.Mcc);
                        cmd.Parameters.AddWithValue("@shippingEmail", pMdsynPagospaymeE.Shippingemail);
                        cmd.Parameters.AddWithValue("@shippingZIP", pMdsynPagospaymeE.Shippingzip);
                        cmd.Parameters.AddWithValue("@acquirerId", pMdsynPagospaymeE.Acquirerid);
                        cmd.Parameters.AddWithValue("@purchaseAmount", pMdsynPagospaymeE.Purchaseamount);
                        cmd.Parameters.AddWithValue("@purchaseVerification", pMdsynPagospaymeE.Purchaseverification);
                        cmd.Parameters.AddWithValue("@IDTransaction", pMdsynPagospaymeE.Idtransaction);
                        cmd.Parameters.AddWithValue("@answerCode", pMdsynPagospaymeE.Answercode);
                        cmd.Parameters.AddWithValue("@errorMessage", pMdsynPagospaymeE.Errormessage);
                        cmd.Parameters.AddWithValue("@authorizationResult", pMdsynPagospaymeE.Authorizationresult);
                        cmd.Parameters.AddWithValue("@reserved23", pMdsynPagospaymeE.Reserved23);
                        cmd.Parameters.AddWithValue("@usr_registro", pMdsynPagospaymeE.UsrRegistro);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@ide_dagospayme", ParameterDirection.InputOutput, SqlDbType.Int, 8, pMdsynPagospaymeE.IdeDagosPayme.ToString()));
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pMdsynPagospaymeE.IdeDagosPayme = (int)cmd.Parameters["@ide_dagospayme"].Value;
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
    }
}
