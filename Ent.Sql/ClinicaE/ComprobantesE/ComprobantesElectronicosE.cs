using System;

namespace Entidades.ClinicaE.ComprobantesE
{
    public class ComprobantesElectronicosE
    {
        #region ATRIBUTOS
        public string Codcomprobante { get; set; }  = "";
        public string Codempresa { get; set; }  = "";
        public string Codsist { get; set; }  = "";
        public string TipocompSunat { get; set; }  = "";
        public string Codcomprobantee { get; set; }  = "";
        public string TipoOtorgamiento { get; set; }  = "";
        public int EstadoCdr { get; set; }  = 0;
        public bool FlgConfirma { get; set; }  = false;
        public bool FlgOtorgamiento { get; set; }  = false;
        public string FlgEnbaja { get; set; }  = "";
        public DateTime FechaRegistroSis { get; set; }  = DateTime.Now;
        public DateTime FechaRegistroRpta { get; set; }  = DateTime.Now;
        public string XmlRegistro { get; set; }  = "";
        public string XmlRegistroRpta { get; set; }  = "";
        public string ObservacionRegistro { get; set; }  = "";
        public string CodigoHash { get; set; }  = "";
        public byte[] CodigoBarra { get; set; }  = { };
        public DateTime FechaCdrSis { get; set; }  = DateTime.Now;
        public DateTime FechaCdrSunat { get; set; }  = DateTime.Now;
        public string ObservacionCdr { get; set; }  = "";
        public DateTime FechaConfirmaSis { get; set; }  = DateTime.Now;
        public string ObservacionConfirma { get; set; }  = "";
        public DateTime FechaOtorgamientoSis { get; set; }  = DateTime.Now;
        public DateTime FechaOtorgamiento { get; set; }  = DateTime.Now;
        public string ObservacionOtorgamiento { get; set; }  = "";
        public string Correo { get; set; }  = "";
        public string Tipoafectacionigv { get; set; }  = "";
        public int IdeTranssap { get; set; }  = 0;
        public bool FlgEnviosap { get; set; }  = false;
        public DateTime FecEnviosap { get; set; }  = DateTime.Now;
        public string IdeDocentrysap { get; set; }  = "";
        public DateTime FecDocentrysap { get; set; }  = DateTime.Now;
        public bool FlgEnviobajasap { get; set; }  = false;
        public DateTime FecEnviobajasap { get; set; }  = DateTime.Now;
        //EXTENSIONES
        public string NuevoValor { get; set; }  = "";
        public string Campo { get; set; }  = "";
        public int Orden { get; set; }  = 0;
        #endregion

        #region CONSTRUCTORES
        public ComprobantesElectronicosE()
        {}

        public ComprobantesElectronicosE(string pCodcomprobante)
        { Codcomprobante = pCodcomprobante; }

        public ComprobantesElectronicosE(string pCodComprobante, string pCodEmpresa)
        {
            Codcomprobante = pCodComprobante;
            Codempresa = pCodEmpresa;
        }

        public ComprobantesElectronicosE(string pCodcomprobante, string pNuevoValor, string pCampo)
        {
            Codcomprobante = pCodcomprobante;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public ComprobantesElectronicosE(string pCodComprobante, string pCampo, string pNuevoValor, string pXml, byte[] pCodigoBarraJpg)
        {
            Codcomprobante = pCodComprobante;
            Campo = pCampo;
            NuevoValor = pNuevoValor;
            XmlRegistro = pXml;
            CodigoBarra = pCodigoBarraJpg;
        }
        #endregion
    }

    #region CLASES ALTERNAS O RELACIONADAS A LA TABLA    
    public class ComprobanteElectronicoXMLCabE
    {
        public string CodNota { get; set; } = "";
        public string TipoPlantilla { get; set; } = "";
        public string Estado { get; set; } = "";
        public string NombreEstado { get; set; } = "";
        public string ParaQuien { get; set; } = "";
        public string EstadoCodComprobanteNota { get; set; } = "";
        public string CodLiquidacionNota { get; set; } = "";
        public string CodComprobanteNota { get; set; } = "";

        public string CodComprobante { get; set; } = "";
        public string CodComprobanteE { get; set; } = "";
        public string TipoCompSunat { get; set; } = "";
        public string TipoCompTci { get; set; } = "";
        public string CodLiquidacion { get; set; } = "";
        public string FechaEmision { get; set; } = "";
        public string ANombreDe { get; set; } = "";
        public string Direccion { get; set; } = "";
                
        public string Ruc { get; set; } = "";
        public string TipDocIdentidadSunat { get; set; } = "";
        public string RucSunat { get; set; } = "";
        public string ReceptorCorreo { get; set; } = "";
        public string EmpresaRuc { get; set; } = "";
        public string EmpresaTipoDocIdentidad { get; set; } = "";
        public string EmpresaNombre { get; set; } = "";
        public string EmpresaDireccion { get; set; } = "";
        public string EmpresaTelefono { get; set; } = "";
        public string Concepto { get; set; } = "";
        public string CodAtencion { get; set; } = "";
        public string CodPaciente { get; set; } = "";
        public string NombrePaciente { get; set; } = "";
        public string NombreTitular { get; set; } = "";
        public string NombreCia { get; set; } = "";
        public string CodPoliza { get; set; } = "";

        public string Cama { get; set; } = "";
        public string Ciuu { get; set; } = "";
        public string Observaciones { get; set; } = "";
        public string Texto1 { get; set; } = "";
        public string SucDireccion { get; set; } = "";
        public string MontoLetras { get; set; } = "";
        public string TipoDeCambio { get; set; } = "";


        public string DocReferencia { get; set; } = "";
        public string MsgDetraccion { get; set; } = "";

        public string C_Moneda { get; set; } = "";
        public string C_NombreMoneda { get; set; } = "";
        public string C_SimboloMoneda { get; set; } = "";
        public string C_MontoAfecto { get; set; } = "";
        public string C_MontoInafecto { get; set; } = "";
        public string C_MontoExonerado { get; set; } = "";
        public string C_MontoGratuito { get; set; } = "";
        public string C_MontoIgv { get; set; } = "";
        public string C_MontoNeto { get; set; } = "";
        public string C_NetoDolares { get; set; } = "";
        public string PorcentajeImpuesto { get; set; } = "";
        public string PorcentajeCoAseguro { get; set; } = "";

        public string FlgGratuito { get; set; } = "";
        public string TipoOperacion { get; set; } = "";
        public string HoraEmision { get; set; } = "";

        public string DetraccionPorc { get; set; } = "0";
        public string DetraccionMonto { get; set; } = "0";
        public string DetraccionNroCuenta { get; set; } = "";

        public string TotalImpuesto { get; set; } = "";
        public string TotalValorVenta { get; set; } = "";
        public string TotalPrecioVenta { get; set; } = "";
        public string VsUbl { get; set; } = "";
        public string MtTotal { get; set; } = "";
        public string MtgBase { get; set; } = "";
        public string MtgValorImpuesto { get; set; } = "";
        public string MtgPorcentaje { get; set; } = "";
        public string CodigoEstabSUNAT { get; set; } = "";
        public string CodDistrito { get; set; } = "";
        public string FormaPago { get; set; } = "";
        public string CodTipoDetraccion { get; set; } = "";
        public string CodTributo { get; set; } = "";
        public string CodAfectacionIGV { get; set; } = "";
        public string DesTributo { get; set; } = "";
        public string CodUN { get; set; } = "";

        public string D_Orden { get; set; } = "";
        public string D_Unidad { get; set; } = "";
        public string D_Grupo { get; set; } = "";
        public string D_NombreGrupo { get; set; } = "";
        public string D_Cant_Sunat { get; set; } = "";
        public string D_VentaUnitario_SinIgv { get; set; } = "";
        public string D_VentaUnitario_ConIgv { get; set; } = "";
        public string D_Total_SinIgv { get; set; } = "";
        public string D_Total_ConIgv { get; set; } = "";
        public string D_Total_SinIgv2 { get; set; } = "";
        public string D_MontoIgv { get; set; } = "";
        public string D_Determinante { get; set; } = "";
        public string D_CodigoTipoPrecio { get; set; } = "";
        public string D_AfectacionIgv { get; set; } = "";
        public string Cuadre { get; set; } = "";

        public string TipoPagoTxt { get; set; } = "";
        public string RefElectronico { get; set; } = "";
        public string RefCodComprobanteE { get; set; } = "";
        public string RefTipoCompSunat { get; set; } = "";
        public string RefFechaEmision { get; set; } = "";
        public string C_CodMotivo_Sunat { get; set; } = "";
        public string C_MotivoNota { get; set; } = "";
        public string CodProductoSUNAT { get; set; } = "";


        // -------------------------------------------
        public string D_CodProducto { get; set; } = "";
        public string NombreProducto { get; set; } = "";

        public string D_StockFraccion { get; set; } = "";
        public string D_Cantidad { get; set; } = "";
        public string D_Cantidad_Fraccion { get; set; } = "";
        public string D_ValorVVP { get; set; } = "";
        public string D_PrecioVentaPVP { get; set; } = "";

        public string D_PorcDctoProducto { get; set; } = "";
        public string D_PorcDctoPlan { get; set; } = "";
        public string D_PrecioUnidadConDcto { get; set; } = "";
        public string D_MontoTotal { get; set; } = "";
        public string D_MontoPaciente { get; set; } = "";

        public string CodTipoCliente { get; set; } = "";
        public string TipoMovimiento { get; set; } = "";
        public string CodVenta { get; set; } = "";
        public string C_MontoDsctoPlan { get; set; } = "";

        public string D_Dscto_Unitario { get; set; } = "";
        public string D_Total_ConDsctoIGV { get; set; } = "";
        public string D_Dscto_MontoBase { get; set; } = "";

        public string D_Dscto_ConIGV { get; set; } = "";
        public string D_MontoAseguradora { get; set; } = "";
        public string D_Dscto_SinIGV { get; set; } = "";
        public string D_MontoBase { get; set; } = "";

        public string Sunat_Tipo_FormaPago { get; set; } = "";
        public string Sunat_Monto_PendientePago { get; set; } = "";
        public string Sunat_Cuota_Monto { get; set; } = "";
        public string Sunat_Cuota_Fecha { get; set; } = "";
        public string Sunat_Retencion_Monto { get; set; } = "";
        public string Sunat_Retencion_Porc { get; set; } = "";
        public string Sunat_Retencion_MontoBase { get; set; } = "";
    }
    #endregion
}