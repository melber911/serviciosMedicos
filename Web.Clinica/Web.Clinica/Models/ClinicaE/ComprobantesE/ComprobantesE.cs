using System;

namespace Ent.Sql.ClinicaE.ComprobantesE
{
    public class ComprobantesE
    {
        #region PROPIEDADES
        public string CodComprobante { get; set; } = "";
        public string CodLiquidacion { get; set; } = "";
        public string CodAtencion { get; set; } = "";
        public string ANombreDeQuien { get; set; } = "";
        public string Ruc { get; set; } = "";
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public DateTime FechaFacturacion { get; set; } = DateTime.Now;
        public DateTime FechaCancelacion { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "";
        public Double SaldoPago { get; set; } = 0;
        public Double Interes { get; set; } = 0;
        public Double NumeroLetras { get; set; } = 0;
        public Double Porcentajeimpuesto { get; set; } = 0;
        public string CodImpuesto { get; set; } = "";
        public Double MontoImpuesto { get; set; } = 0;
        public Double Monto { get; set; } = 0;
        public DateTime Fechaanulacion { get; set; } = DateTime.Now;
        public string Codturno { get; set; } = "";
        public string Correlativo { get; set; } = "";
        public DateTime Fechagenerafactura { get; set; } = DateTime.Now;
        public bool Flagprocesada { get; set; } = false;
        public string Paraquien { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Nuevocomprobante { get; set; } = "";
        public string Observacion { get; set; } = "";
        public string Quiencreoregistro { get; set; } = "";
        public string Flagdolares { get; set; } = "";
        public Double Montodolares { get; set; } = 0;
        public Double Montoimpuestodolares { get; set; } = 0;
        public Double Tipodecambio { get; set; } = 0;
        public string Concepto { get; set; } = "";
        public string Tipoimpresion { get; set; } = "";
        public string Codaseguradora { get; set; } = "";
        public string Codpaciente { get; set; } = "";
        public string Numeroplanilla { get; set; } = "";
        public string Correlativoletra { get; set; } = "";
        public string Provision { get; set; } = "";
        public DateTime Fechaprovision { get; set; } = DateTime.Now;
        public string CodEmpresa { get; set; } = "";
        public string Codmedicotercero { get; set; } = "";
        public string Tipofactura { get; set; } = "";
        public string CodTipoFactura { get; set; } = "";
        public string Codcia { get; set; } = "";
        public string Tipooperacion { get; set; } = "";
        public DateTime Fechaoperacion { get; set; } = DateTime.Now;
        public string Codigo { get; set; } = "";
        public Double Montoinafecto { get; set; } = 0;
        public Double Montoinafectodolares { get; set; } = 0;
        public string Cuenta { get; set; } = "";
        public string Codpersonal { get; set; } = "";
        public DateTime Fechaprovisiontributaria { get; set; } = DateTime.Now;
        public string Provisiontributaria { get; set; } = "";
        public string Tipdocidentidad { get; set; } = "";
        public string Docidentidad { get; set; } = "";
        public int UsrRegistra { get; set; } = 0;
        public DateTime FecRegistra { get; set; } = DateTime.Now;
        public string Codcomprobantee { get; set; } = "";
        public bool FlgElectronico { get; set; } = false;
        public bool FlgGratuito { get; set; } = false;
        public string Cardcode { get; set; } = "";
        public int IflgOnbase { get; set; } = 0;
        public bool FlgCredito { get; set; } = false;
        public string FecPagocredito { get; set; } = "";
        public DateTime FecOnbase { get; set; } = DateTime.Now;
        //EXTENSIONES
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;

        /// <summary>
        /// Tipo de Comprobante Boleta: B; Factura: F
        /// </summary>
        public string TipoComprobante { get; set; } = "";

        /// <summary>
        ///         ''' (E)fectivo, (C)heque, (T)arjeta de Credito
        ///         ''' </summary>
        ///         ''' <returns></returns>
        public string TipoPago { get; set; } = "";

        /// <summary>
        ///         ''' (G)enera, (P)aga, (T)odo
        ///         ''' </summary>
        ///         ''' <returns></returns>
        public string Operacion { get; set; } = "";

        /// <summary>
        ///         ''' (S)i Varios en la 2da llamada, (N)o varios
        ///         ''' </summary>
        ///         ''' <returns></returns>
        public string VariosTipoPago { get; set; } = string.Empty;

        public string CodTerminal { get; set; } = "204"; // Por defecto por ahora para pruebas.

        // CUADRE DE CAJA
        /// <summary>
        /// (D)olares, (E)fectivo 
        /// </summary>
        public string Moneda { get; set; } = "";

        /// <summary>
        /// Numero del Cheque o Tarjeta
        /// </summary>
        public string NumeroEntidad { get; set; } = "";

        /// <summary>
        ///         ''' Codigo de la entidad: BANCOS - CREDICARDS
        ///         ''' </summary>
        ///         ''' <returns></returns>
        public string NombreEntidad { get; set; } = "";

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// C
        /// </summary>
        public ComprobantesE()
        { }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="pCodcomprobante">x</param>
        public ComprobantesE(string pCodcomprobante)
        { CodComprobante = pCodcomprobante; }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="pCodcomprobante">x</param>
        /// <param name="pNuevoValor">x</param>
        /// <param name="pCampo">x</param>
        public ComprobantesE(string pCodcomprobante, string pNuevoValor, string pCampo)
        {
            CodComprobante = pCodcomprobante;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        /// <summary>
        ///         ''' Cargar los datos que se necesita
        ///         ''' </summary>
        ///         ''' <param name="pCodComprobante">Cod. Comprobante</param>
        ///         ''' <param name="pCampo">Atributo de la tabla a la que hace referencia.</param>
        ///         ''' <param name="pCodEmpresa"></param>
        ///         ''' <param name="pNuevoValor">Nuevo Valor a actualizar</param>
        public ComprobantesE(string pCodComprobante, string pCampo, string pCodEmpresa, string pNuevoValor)
        {
            CodComprobante = pCodComprobante;
            Campo = pCampo;
            CodEmpresa = pCodEmpresa;
            NuevoValor = pNuevoValor;
        }

        /// <summary>
        ///         ''' Cargar los datos para el store Sp_Comprobante_Insert
        ///         ''' </summary>
        ///         ''' <param name="pTipoComprobante">B-Boleta, F-Factura</param>
        ///         ''' <param name="pCodLiquidacion">Código de Liquidación</param>
        ///         ''' <param name="pMonto">Monto del Comprobante</param>
        ///         ''' <param name="pANombreDeQuien">Descripción del Nombre a quien corresponde</param>
        ///         ''' <param name="pRuc">Ruc en caso se requiera</param>
        ///         ''' <param name="pDireccion">Dirección a quien se le facura el comprobante</param>
        ///         ''' <param name="pTipoPago">E-Efectivo, C-Cheque, T-Tarjeta de Credito</param>
        ///         ''' <param name="pNombreEntidad">Código de la entidad:BANCOS - CREDICARDS</param>
        ///         ''' <param name="pNumeroEntidad">Número del Cheque o Tarjeta</param>
        ///         ''' <param name="pOperacion">G-Genera, P-Paga, T-Todo</param>
        ///         ''' <param name="pVariosTipoPago">S-Si Varios en la 2da llamada, N-No varios</param>
        ///         ''' <param name="pCodComprobante">Codigo del comprobante</param>
        ///         ''' <param name="pMoneda">D-Dolares, E-Efectivo</param>
        ///         ''' <param name="pCodEmpresa">001-CSF San felipe</param>
        ///         ''' <param name="pCodTerminal"></param>
        public ComprobantesE(string pTipoComprobante, string pCodLiquidacion, double pMonto, string pANombreDeQuien, string pRuc, string pDireccion, string pTipoPago, string pNombreEntidad, string pNumeroEntidad, string pOperacion, string pVariosTipoPago, string pCodComprobante, string pMoneda, string pCodEmpresa, string pCodTerminal)
        {
            TipoComprobante = pTipoComprobante;
            CodLiquidacion = pCodLiquidacion;
            Monto = pMonto;
            ANombreDeQuien = pANombreDeQuien;
            Ruc = pRuc;
            Direccion = pDireccion;
            TipoPago = pTipoPago;
            NombreEntidad = pNombreEntidad;
            NumeroEntidad = pNumeroEntidad;
            Operacion = pOperacion;
            VariosTipoPago = pVariosTipoPago;
            CodComprobante = pCodComprobante;
            Moneda = pMoneda;
            CodEmpresa = pCodEmpresa;
            CodTipoFactura = pCodTerminal;
        }
        #endregion        
    }

    public class X
    {
        ComprobantesE ComprobantesE = new ComprobantesE();

        public void xx()
        {
            ComprobantesE.CodComprobante = "";
            ComprobantesE.CodComprobante = "";
        }

    }

}