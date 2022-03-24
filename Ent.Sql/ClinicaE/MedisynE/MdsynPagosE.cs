using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedisynE
{
    public class MdsynPagosE
    {
        public long IdePagosBot { get; set; } = 0;
        public string CodTipo { get; set; } = "";
        public int IdeMdsynReserva { get; set; } = 0;
        public int IdeCorrelReserva { get; set; } = 0;
        public string CodLiquidacion { get; set; } = "";
        public string CodVenta { get; set; } = "";
        public decimal CntMontoPago { get; set; } = 0;
        public string IdeUniqueIdentifier { get; set; } = "";
        public string CodRptaSynapsis { get; set; } = "";
        public int UsrRegOrdenSynapsis { get; set; } = 0;
        public DateTime FecRegOrdenSynapsis { get; set; } = DateTime.Now;
        public string TxtJsonOrden { get; set; } = "";
        public string EstPagado { get; set; } = "";
        public string NroOperacion { get; set; } = "";
        public string TipTarjeta { get; set; } = "";
        public string NumTarjeta { get; set; } = "";
        public string TxtJsonRpta { get; set; } = "";
        public DateTime FecRecepcionPago { get; set; } = DateTime.Now;
        // ---     EXTENSIONES    ---
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public string Orden { get; set; } = "";

        public SynapsisOrderApiBot objSynapsisOrderApiBot { get; set; } = new SynapsisOrderApiBot();

        public class SynapsisOrderApiBot
        {
            public string number { get; set; } = "";
            public string amount { get; set; } = "";

            public string cust_name { get; set; } = "";
            public string cust_lastname { get; set; } = "";
            public string cust_phone { get; set; } = "";
            public string cust_email { get; set; } = "";
            public string cust_doc_type { get; set; } = "";
            public string cust_doc_number { get; set; } = "";
            public string cust_adress_country { get; set; } = "";
            public string cust_adress_levels { get; set; } = "";
            public string cust_adress_line1 { get; set; } = "";
            public string cust_adress_zip { get; set; } = "";

            public string currency_code { get; set; } = "";

            public string country_code { get; set; } = "";

            public string products_name { get; set; } = "";
            public string products_quantity { get; set; } = "";
            public string products_unitAmount { get; set; } = "";
            public string products_amount { get; set; } = "";

            public string ordTyp_code { get; set; } = "";

            public string targTyp_code { get; set; } = "";

            public string header_ApiKey { get; set; } = "";
            public string header_SecretKey { get; set; } = "";

            public DateTime setting_expiration_date { get; set; }
        }


        public MdsynPagosE()
        {
        }

        public MdsynPagosE(long pIdePagosBot)
        {
            IdePagosBot = pIdePagosBot;
        }

        public MdsynPagosE(long pIdePagosBot, string pOrden)
        {
            IdePagosBot = pIdePagosBot;
            Orden = pOrden;
        }

        public MdsynPagosE(long pIdePagosBot, string pNuevoValor, string pCampo)
        {
            IdePagosBot = pIdePagosBot;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        /// <summary>
        ///         ''' Este constructor puede servir para el método "Sp_MdsynPagos_Insert"
        ///         ''' </summary>
        ///         ''' <param name="pIdePagosBot"></param>
        ///         ''' <param name="pCodTipo"></param>
        ///         ''' <param name="pIdeMdsynReserva"></param>
        ///         ''' <param name="pIdeCorrelReserva"></param>
        ///         ''' <param name="pCodLiquidacion"></param>
        ///         ''' <param name="pCodVenta"></param>
        ///         ''' <param name="pCntMontoPago"></param>
        public MdsynPagosE(long pIdePagosBot, string pCodTipo, int pIdeMdsynReserva, int pIdeCorrelReserva, string pCodLiquidacion, string pCodVenta, decimal pCntMontoPago)
        {
            IdePagosBot = pIdePagosBot;
            CodTipo = pCodTipo;
            IdeMdsynReserva = pIdeMdsynReserva;
            IdeCorrelReserva = pIdeCorrelReserva;
            CodLiquidacion = pCodLiquidacion;
            CodVenta = pCodVenta;
            CntMontoPago = pCntMontoPago;
        }

        /// <summary>
        ///         ''' Este constructor puede servir para el método "Sp_MdsynPagos_Consulta"
        ///         ''' </summary>
        ///         ''' <param name="pIdePagosBot"></param>
        ///         ''' <param name="pCodTipo"></param>
        ///         ''' <param name="pIdeMdsynReserva"></param>
        ///         ''' <param name="pIdeCorrelReserva"></param>
        ///         ''' <param name="pCodLiquidacion"></param>
        ///         ''' <param name="pCodVenta"></param>
        ///         ''' <param name="pCntMontoPago"></param>
        ///         ''' <param name="pOrden"></param>
        public MdsynPagosE(long pIdePagosBot, string pCodTipo, int pIdeMdsynReserva, int pIdeCorrelReserva, string pCodLiquidacion, string pCodVenta, decimal pCntMontoPago, string pOrden)
        {
            IdePagosBot = pIdePagosBot;
            CodTipo = pCodTipo;
            IdeMdsynReserva = pIdeMdsynReserva;
            IdeCorrelReserva = pIdeCorrelReserva;
            CodLiquidacion = pCodLiquidacion;
            CodVenta = pCodVenta;
            CntMontoPago = pCntMontoPago;
            Orden = pOrden;
        }

        public MdsynPagosE(long pIdePagosBot, string pCodTipo, int pIdeCorrelReserva, string pCodVenta, decimal pCntMontoPago, string pIdeUniqueIdentifier, string pCodRptaSynapsis, int pUsrRegOrdenSynapsis, string pTxtJsonOrden)
        {
            IdePagosBot = pIdePagosBot;
            CodTipo = pCodTipo;
            IdeCorrelReserva = pIdeCorrelReserva;
            CodVenta = pCodVenta;
            CntMontoPago = pCntMontoPago;
            IdeUniqueIdentifier = pIdeUniqueIdentifier;
            CodRptaSynapsis = pCodRptaSynapsis;
            UsrRegOrdenSynapsis = pUsrRegOrdenSynapsis;
            // FecRegOrdenSynapsis = pFecRegOrdenSynapsis
            TxtJsonOrden = pTxtJsonOrden;
        }


        /// <summary>
        ///         ''' Este constructor sirve para utilizar el store: [Sp_MdsynPagos_Update]
        ///         ''' </summary>
        ///         ''' <param name="pIdePagosBot"></param>
        ///         ''' <param name="pCodTipo"></param>
        ///         ''' <param name="pIdeMdsynReserva"></param>
        ///         ''' <param name="pIdeCorrelReserva"></param>
        ///         ''' <param name="pCodLiquidacion"></param>
        ///         ''' <param name="pCodVenta"></param>
        ///         ''' <param name="pCntMontoPago"></param>
        ///         ''' <param name="pIdeUniqueIdentifier"></param>
        ///         ''' <param name="pCodRptaSynapsis"></param>
        ///         ''' <param name="pUsrRegOrdenSynapsis"></param>
        ///         ''' <param name="pTxtJsonOrden"></param>
        ///         ''' <param name="pEstPagado"></param>
        ///         ''' <param name="pNroOperacion"></param>
        ///         ''' <param name="pTipTarjeta"></param>
        ///         ''' <param name="pNumTarjeta"></param>
        ///         ''' <param name="pTxtJsonRpta"></param>
        ///         ''' <param name="pOrden"></param>
        public MdsynPagosE(long pIdePagosBot, string pCodTipo, int pIdeMdsynReserva, int pIdeCorrelReserva, string pCodLiquidacion, string pCodVenta, decimal pCntMontoPago, string pIdeUniqueIdentifier, string pCodRptaSynapsis, int pUsrRegOrdenSynapsis, string pTxtJsonOrden, string pEstPagado, string pNroOperacion, string pTipTarjeta, string pNumTarjeta, string pTxtJsonRpta, string pOrden)
        {
            IdePagosBot = pIdePagosBot;
            IdeMdsynReserva = pIdeMdsynReserva;
            CodTipo = pCodTipo;
            IdeCorrelReserva = pIdeCorrelReserva;
            CodLiquidacion = pCodLiquidacion;
            CodVenta = pCodVenta;
            CntMontoPago = pCntMontoPago;
            IdeUniqueIdentifier = pIdeUniqueIdentifier;
            CodRptaSynapsis = pCodRptaSynapsis;
            UsrRegOrdenSynapsis = pUsrRegOrdenSynapsis;
            // FecRegOrdenSynapsis = pFecRegOrdenSynapsis
            TxtJsonOrden = pTxtJsonOrden;

            EstPagado = pEstPagado;
            NroOperacion = pNroOperacion;
            TipTarjeta = pTipTarjeta;
            NumTarjeta = pNumTarjeta;
            TxtJsonRpta = pTxtJsonRpta;
            // FecRecepcionPago = pFecRecepcionPago

            Orden = pOrden;
        }
    }
}
