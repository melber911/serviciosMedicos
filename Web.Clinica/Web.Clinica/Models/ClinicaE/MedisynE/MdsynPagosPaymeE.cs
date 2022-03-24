using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedisynE
{
    public class MdsynPagosPaymeE
    {
        public int IdeDagosPayme { get; set; } = 0;
        public long Idecorrelreserva { get; set; } = 0;
        public string Authorizationcode { get; set; } = "";
        public string Bin { get; set; } = "";
        public string Shippingcountry { get; set; } = "";
        public string Reserved1 { get; set; } = "";
        public string Reserved2 { get; set; } = "";
        public string Shippinglastname { get; set; } = "";
        public string Errorcode { get; set; } = "";
        public string Idcommerce { get; set; } = "";
        public string Shippingcity { get; set; } = "";
        public string Txdatetime { get; set; } = "";
        public string Purchasecurrencycode { get; set; } = "";
        public string Commerceassociated { get; set; } = "";
        public string Shippingfirstname { get; set; } = "";
        public string Purchaseoperationnumber { get; set; } = "";
        public string Shippingphone { get; set; } = "";
        public string Shippingaddress { get; set; } = "";
        public string Reserved22 { get; set; } = "";
        public string Answermessage { get; set; } = "";
        public string Cuota { get; set; } = "";
        public string Paymentreferencecode { get; set; } = "";
        public string Shippingstate { get; set; } = "";
        public string Brand { get; set; } = "";
        public string Mcc { get; set; } = "";
        public string Shippingemail { get; set; } = "";
        public string Shippingzip { get; set; } = "";
        public string Acquirerid { get; set; } = "";
        public string Purchaseamount { get; set; } = "";
        public string Purchaseverification { get; set; } = "";
        public string Idtransaction { get; set; } = "";
        public string Answercode { get; set; } = "";
        public string Errormessage { get; set; } = "";
        public string Authorizationresult { get; set; } = "";
        public string Reserved23 { get; set; } = "";
        public DateTime FecRegistro { get; set; } = DateTime.Now;
        public int UsrRegistro { get; set; } = 0;
        // ---     EXTENSIONES    ---
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;


        public MdsynPagosPaymeE()
        {
        }

        public MdsynPagosPaymeE(int pIdeDagospayme)
        {
            IdeDagosPayme = pIdeDagospayme;
        }

        public MdsynPagosPaymeE(int pIdeDagospayme, string pNuevoValor, string pCampo)
        {
            IdeDagosPayme = pIdeDagospayme;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public MdsynPagosPaymeE(int pIdeDagospayme, long pIdeCorrelReserva, string pauthorizationCode, string pbin, string pshippingCountry, string preserved1, string preserved2, string pshippingLastName, string perrorCode, string pidCommerce, string pshippingCity, string ptxDateTime, string ppurchaseCurrencyCode, string pcommerceAssociated, string pshippingFirstName, string ppurchaseOperationNumber, string pshippingPhone, string pshippingAddress, string preserved22, string panswerMessage, string pcuota, string ppaymentReferenceCode, string pshippingState, string pbrand, string pmcc, string pshippingEmail, string pshippingZIP, string pacquirerId, string ppurchaseAmount, string ppurchaseVerification, string pIDTransaction, string panswerCode, string perrorMessage, string pauthorizationResult, string preserved23)
        {
            IdeDagosPayme = pIdeDagospayme;
            Idecorrelreserva = pIdeCorrelReserva;
            Authorizationcode = pauthorizationCode;
            Bin = pbin;
            Shippingcountry = pshippingCountry;
            Reserved1 = preserved1;
            Reserved2 = preserved2;
            Shippinglastname = pshippingLastName;
            Errorcode = perrorCode;
            Idcommerce = pidCommerce;
            Shippingcity = pshippingCity;
            Txdatetime = ptxDateTime;
            Purchasecurrencycode = ppurchaseCurrencyCode;
            Commerceassociated = pcommerceAssociated;
            Shippingfirstname = pshippingFirstName;
            Purchaseoperationnumber = ppurchaseOperationNumber;
            Shippingphone = pshippingPhone;
            Shippingaddress = pshippingAddress;
            Reserved22 = preserved22;
            Answermessage = panswerMessage;
            Cuota = pcuota;
            Paymentreferencecode = ppaymentReferenceCode;
            Shippingstate = pshippingState;
            Brand = pbrand;
            Mcc = pmcc;
            Shippingemail = pshippingEmail;
            Shippingzip = Shippingzip;
            Acquirerid = pacquirerId;
            Purchaseamount = ppurchaseAmount;
            Purchaseverification = ppurchaseAmount;
            Idtransaction = pIDTransaction;
            Answercode = panswerCode;
            Errormessage = perrorMessage;
            Authorizationresult = pauthorizationResult;
            Reserved23 = preserved23;
        }
    }
}
