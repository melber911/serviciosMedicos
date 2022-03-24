using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedisynE
{
    public class MdsynDatosPagosE
    {
        private int _IdeDatospagos = 0;
        public int IdeDatospagos
        {
            get
            {
                return _IdeDatospagos;
            }
            set
            {
                _IdeDatospagos = value;
            }
        }

        private string _CodAsegurado = "";
        public string CodAsegurado
        {
            get
            {
                return _CodAsegurado;
            }
            set
            {
                _CodAsegurado = value;
            }
        }

        private string _TipDocumento = "";
        public string TipDocumento
        {
            get
            {
                return _TipDocumento;
            }
            set
            {
                _TipDocumento = value;
            }
        }

        private string _NumDocumento = "";
        public string NumDocumento
        {
            get
            {
                return _NumDocumento;
            }
            set
            {
                _NumDocumento = value;
            }
        }

        private string _TipPrt = "";
        public string TipPrt
        {
            get
            {
                return _TipPrt;
            }
            set
            {
                _TipPrt = value;
            }
        }

        private string _TipParentesco = "";
        public string TipParentesco
        {
            get
            {
                return _TipParentesco;
            }
            set
            {
                _TipParentesco = value;
            }
        }

        private string _NroPlan = "";
        public string NroPlan
        {
            get
            {
                return _NroPlan;
            }
            set
            {
                _NroPlan = value;
            }
        }

        private string _TipDocempresa = "";
        public string TipDocempresa
        {
            get
            {
                return _TipDocempresa;
            }
            set
            {
                _TipDocempresa = value;
            }
        }

        private string _NumDocempresa = "";
        public string NumDocempresa
        {
            get
            {
                return _NumDocempresa;
            }
            set
            {
                _NumDocempresa = value;
            }
        }

        private string _FecNacimiento = "";
        public string FecNacimiento
        {
            get
            {
                return _FecNacimiento;
            }
            set
            {
                _FecNacimiento = value;
            }
        }

        private string _FecIniciovigencia = "";
        public string FecIniciovigencia
        {
            get
            {
                return _FecIniciovigencia;
            }
            set
            {
                _FecIniciovigencia = value;
            }
        }

        private string _FecAfilicacion = "";
        public string FecAfilicacion
        {
            get
            {
                return _FecAfilicacion;
            }
            set
            {
                _FecAfilicacion = value;
            }
        }

        private string _CodCobertura = "";
        public string CodCobertura
        {
            get
            {
                return _CodCobertura;
            }
            set
            {
                _CodCobertura = value;
            }
        }

        private decimal _CoPagofijo = 0;
        public decimal CoPagofijo
        {
            get
            {
                return _CoPagofijo;
            }
            set
            {
                _CoPagofijo = value;
            }
        }

        private decimal _CoPagovariable = 0;
        public decimal CoPagovariable
        {
            get
            {
                return _CoPagovariable;
            }
            set
            {
                _CoPagovariable = value;
            }
        }

        private string _TipMoneda = "";
        public string TipMoneda
        {
            get
            {
                return _TipMoneda;
            }
            set
            {
                _TipMoneda = value;
            }
        }

        private int _IdeCorrelreserva = 0;
        public int IdeCorrelreserva
        {
            get
            {
                return _IdeCorrelreserva;
            }
            set
            {
                _IdeCorrelreserva = value;
            }
        }

        private string _CodPaciente = "";
        public string CodPaciente
        {
            get
            {
                return _CodPaciente;
            }
            set
            {
                _CodPaciente = value;
            }
        }

        private string _CodPacienteTitular = "";
        public string CodPacienteTitular
        {
            get
            {
                return _CodPacienteTitular;
            }
            set
            {
                _CodPacienteTitular = value;
            }
        }

        private string _TipAtencion = "";
        public string TipAtencion
        {
            get
            {
                return _TipAtencion;
            }
            set
            {
                _TipAtencion = value;
            }
        }

        private string _CodAseguradora = "";
        public string CodAseguradora
        {
            get
            {
                return _CodAseguradora;
            }
            set
            {
                _CodAseguradora = value;
            }
        }

        private string _CodSede = "";
        public string CodSede
        {
            get
            {
                return _CodSede;
            }
            set
            {
                _CodSede = value;
            }
        }

        private string _CodSunasa = "";
        public string CodSunasa
        {
            get
            {
                return _CodSunasa;
            }
            set
            {
                _CodSunasa = value;
            }
        }

        private string _NroOperacion = "";
        public string NroOperacion
        {
            get
            {
                return _NroOperacion;
            }
            set
            {
                _NroOperacion = value;
            }
        }

        private string _DscMensajeRespuesta = "";
        public string DscMensajeRespuesta
        {
            get
            {
                return _DscMensajeRespuesta;
            }
            set
            {
                _DscMensajeRespuesta = value;
            }
        }

        private string _EstPagoExitoso = "";
        public string EstPagoExitoso
        {
            get
            {
                return _EstPagoExitoso;
            }
            set
            {
                _EstPagoExitoso = value;
            }
        }

        private DateTime _FecRegistro = DateTime.Now;
        public DateTime FecRegistro
        {
            get
            {
                return _FecRegistro;
            }
            set
            {
                _FecRegistro = value;
            }
        }

        private string _FlgProcesoAtencion = "";
        public string FlgProcesoAtencion
        {
            get
            {
                return _FlgProcesoAtencion;
            }
            set
            {
                _FlgProcesoAtencion = value;
            }
        }

        private string _FecProcesoAtencion = "";
        public string FecProcesoAtencion
        {
            get
            {
                return _FecProcesoAtencion;
            }
            set
            {
                _FecProcesoAtencion = value;
            }
        }

        private string _CodAtencion = "";
        public string CodAtencion
        {
            get
            {
                return _CodAtencion;
            }
            set
            {
                _CodAtencion = value;
            }
        }

        private string _CodComprobante = "";
        public string CodComprobante
        {
            get
            {
                return _CodComprobante;
            }
            set
            {
                _CodComprobante = value;
            }
        }

        private string _CodIAFAS = "";
        public string CodIAFAS
        {
            get
            {
                return _CodIAFAS;
            }
            set
            {
                _CodIAFAS = value;
            }
        }

        private string _CodigoAutorizacion = "";
        public string CodigoAutorizacion
        {
            get
            {
                return _CodigoAutorizacion;
            }
            set
            {
                _CodigoAutorizacion = value;
            }
        }

        private string _DscObservaciones = "";
        public string DscObservaciones
        {
            get
            {
                return _DscObservaciones;
            }
            set
            {
                _DscObservaciones = value;
            }
        }

        private string _CodProfMedico = "";
        public string CodProfMedico
        {
            get
            {
                return _CodProfMedico;
            }
            set
            {
                _CodProfMedico = value;
            }
        }

        private string _CodMedico = "";
        public string CodMedico
        {
            get
            {
                return _CodMedico;
            }
            set
            {
                _CodMedico = value;
            }
        }

        private string _FecCita = "";
        public string FecCita
        {
            get
            {
                return _FecCita;
            }
            set
            {
                _FecCita = value;
            }
        }

        private string _Direccion = "";
        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                _Direccion = value;
            }
        }

        public string TipTarjeta { get; set; } = "";
        public string NumTarjeta { get; set; } = "";
        public string FlgAnulacion { get; set; } = "";
        public DateTime FecProcesoAnulacion { get; set; }
        public DateTime FecAnulado { get; set; }
        public string CodNota { get; set; } = "";
        public string CodEspecialidad { get; set; } = "";
        public string CodEspecialidadMedisyn { get; set; } = "";
        public int EstProcesoAtencion { get; set; } = 0;
        public string CodLiquidacion { get; set; } = "";
        public string FlgRecepcion { get; set; } = "";

        public string Comp_TipoComprobante { get; set; } = "B";
        public string Comp_TipDocIdentidad { get; set; } = "";
        public string Comp_RutDocIdentidad { get; set; } = "";
        public string Comp_DscTabla { get; set; } = "";
        public string Comp_Correo { get; set; } = "";
        public string JsonRptaVisa { get; set; } = "";
        public string TipoEnvio { get; set; } = "";
        public string ResponsableEnvio { get; set; } = "";

        // Public Property CodTipoConsultaMedicaAsegurado As String = ""
        // Public Property CodTipoComprobante As String = ""
        // Public Property TipDocIdentidad As String = ""
        // Public Property DocIdentidad As String = ""
        // Public Property DscTabla As String = ""
        // Public Property DscCorreoComprobante As String = ""
        public string NombresComprobante { get; set; } = "";
        // F	R	20100162742	C	GUSTAVO.REQUE@SOFTVAN.COM.PE	CLINICA SAN FELIPE S.A.

        // ---     EXTENSIONES    ---
        private string _NuevoValor = "";
        public string NuevoValor
        {
            get
            {
                return _NuevoValor;
            }
            set
            {
                _NuevoValor = value;
            }
        }

        private string _Campo = "";
        public string Campo
        {
            get
            {
                return _Campo;
            }
            set
            {
                _Campo = value;
            }
        }

        private int _Orden = 0;
        public int Orden
        {
            get
            {
                return _Orden;
            }
            set
            {
                _Orden = value;
            }
        }

        private string _NombresPacientes = "";
        public string NombresPacientes
        {
            get
            {
                return _NombresPacientes;
            }
            set
            {
                _NombresPacientes = value;
            }
        }

        private string _NombresPacienteTitular = "";
        public string NombresPacienteTitular
        {
            get
            {
                return _NombresPacienteTitular;
            }
            set
            {
                _NombresPacienteTitular = value;
            }
        }

        private string _DscAseguradora = "";
        public string DscAseguradora
        {
            get
            {
                return _DscAseguradora;
            }
            set
            {
                _DscAseguradora = value;
            }
        }

        private string _Sexo = "";
        public string Sexo
        {
            get
            {
                return _Sexo;
            }
            set
            {
                _Sexo = value;
            }
        }

        private string _CardCode = "";
        public string CardCode
        {
            get
            {
                return _CardCode;
            }
            set
            {
                _CardCode = value;
            }
        }

        private string _DscCorreo = "";
        public string DscCorreo
        {
            get
            {
                return _DscCorreo;
            }
            set
            {
                _DscCorreo = value;
            }
        }

        private string _FechaQR = "";
        public string FechaQR
        {
            get
            {
                return _FechaQR;
            }
            set
            {
                _FechaQR = value;
            }
        }

        private string _CodCia = "";
        public string CodCia
        {
            get
            {
                return _CodCia;
            }
            set
            {
                _CodCia = value;
            }
        }

        private string _Observaciones = "";
        public string Observaciones
        {
            get
            {
                return _Observaciones;
            }
            set
            {
                _Observaciones = value;
            }
        }

        public string CodEntidad { get; set; } = "";
        public string EstConsultaMedica { get; set; } = "";
        /// <summary>
        ///         ''' Sirve para saber si el paciente
        ///         ''' Se usa para saber si la consulta es por Aseguradora "A" / Particular "P" / Ambos *B* (Este solo usa en caso de consultar)
        ///         ''' </summary>
        ///         ''' <returns></returns>
        public string CodTipoConsultaMedica { get; set; } = "A";
        // puede_pagar_cita
        public string PuedePagarCita { get; set; } = "N";
        public string TransaccionIdNiubiz { get; set; } = "";

        public string NumAutorizacionSiteds { get; set; } = "";
        public string fAutoDate { get; set; } = "";
        public string dAutotime { get; set; } = "";

        public string NombrePaciente { get; set; } = "";
        public string ApPaternoPaciente { get; set; } = "";
        public string ApMaternoPaciente { get; set; } = "";

        public string SedeFisica { get; set; } = "";
        public string TipoAtencion { get; set; } = "";
        public string DscSede { get; set; } = "";
        public string Reprogramar { get; set; } = "";

        public string DscReprogramar { get; set; } = "";


        public MdsynDatosPagosE()
        {
        }

        public MdsynDatosPagosE(int pIdeCorrelReserva)
        {
            IdeCorrelreserva = pIdeCorrelReserva;
        }

        public MdsynDatosPagosE(int pIdeCorrelReserva, string pNuevoValor, string pCampo)
        {
            IdeCorrelreserva = pIdeCorrelReserva;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public MdsynDatosPagosE(int pIdeCorrelReserva, string pNuevoValor, string pCampo, int pIdeDatospagos)
        {
            IdeCorrelreserva = pIdeCorrelReserva;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
            IdeDatospagos = pIdeDatospagos;
        }

        public MdsynDatosPagosE(string pCodAsegurado, string pCodPaciente, string pCodPacienteTitular, int pIdeCorrelReserva, int pOrden)
        {
            CodAsegurado = pCodAsegurado;
            CodPaciente = pCodPaciente;
            CodPacienteTitular = pCodPacienteTitular;
            IdeCorrelreserva = pIdeCorrelReserva;
            Orden = pOrden;
        }

        public MdsynDatosPagosE(string pCodAsegurado, string pCodPaciente, string pCodPacienteTitular, int pIdeCorrelReserva, int pOrden, string pCodSede, string pDscNombresPaciente, string pFecInicio, string pFecFin, string pCodProfMedisyn)
        {
            CodAsegurado = pCodAsegurado;
            CodPaciente = pCodPaciente;
            CodPacienteTitular = pCodPacienteTitular;
            IdeCorrelreserva = pIdeCorrelReserva;
            Orden = pOrden;
            CodSede = pCodSede;
            NombresPacientes = pDscNombresPaciente;
            CodProfMedico = pCodProfMedisyn;
        }

        /// <summary>
        ///         ''' Sp_MdsynDatosPagos_Update_V2
        ///         ''' </summary>
        ///         ''' <param name="pIdeDatosPagos"></param>
        ///         ''' <param name="pCodAtencion"></param>
        ///         ''' <param name="pcodComprobante"></param>
        ///         ''' <param name="pCodLiquidacion"></param>
        ///         ''' <param name="pNumAutorizacionSiteds"></param>
        ///         ''' <param name="pOrden"></param>
        ///         ''' <param name="pDscMensajeRespuesta"></param>
        ///         ''' <param name="pEstPagoExitoso"></param>
        ///         ''' <param name="pTipTarjeta"></param>
        ///         ''' <param name="pNumTarjeta"></param>
        ///         ''' <param name="pNroOperacion"></param>
        ///         ''' <param name="pJsonRptaVisa"></param>
        public MdsynDatosPagosE(int pIdeDatosPagos, string pCodAtencion, string pcodComprobante, string pCodLiquidacion, string pNumAutorizacionSiteds, int pOrden, string pDscMensajeRespuesta, string pEstPagoExitoso, string pTipTarjeta, string pNumTarjeta, string pNroOperacion, string pJsonRptaVisa)
        {
            IdeDatospagos = pIdeDatosPagos;
            CodAtencion = pCodAtencion;
            CodComprobante = pcodComprobante;
            CodLiquidacion = pCodLiquidacion;
            NumAutorizacionSiteds = pNumAutorizacionSiteds;
            Orden = pOrden;
            DscMensajeRespuesta = pDscMensajeRespuesta;
            EstPagoExitoso = pEstPagoExitoso;
            TipTarjeta = pTipTarjeta;
            NumTarjeta = pNumTarjeta;
            NroOperacion = pNroOperacion;
            JsonRptaVisa = pJsonRptaVisa;
        }
    }
}
