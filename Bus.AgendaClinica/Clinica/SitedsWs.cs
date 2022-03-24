using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bus.Utilities;

namespace Bus.AgendaClinica.Clinica
{
    public class SitedsWs
    {
        // Public Shared Property RutaWS As String = "http://200.48.199.90/WSSITEDS/Sistema/"
        public static string RutaWS_Siteds { get; set; } = "http://softvanperu.com:8000/SANNA_SITEDS/";

        public string xRuc { get; set; } = "";
        public string xIAFAS { get; set; } = "";
        public string xSunasa { get; set; } = "";


        public class AsegNombRequest
        {
            public string RUC { get; set; } = "";
            public string SUNASA { get; set; } = "";

            /// <summary>
            ///         ''' Codigo de la aseguradora. 20002	- PACIFICO EPS, 40005 - LA POSITIVA, 40003 - PACIFICO SEGUROS
            ///         ''' </summary>
            ///         ''' <returns></returns>
            public string IAFAS { get; set; } = "";

            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string CodEspecialidad { get; set; } = "";


            public AsegNombRequest()
            {
            }

            public AsegNombRequest(string pRUC, string pSUNASA, string pIAFAS)
            {
                RUC = pRUC;
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
            }

            public AsegNombRequest(string pRUC, string pSUNASA, string pIAFAS, string pTipDocumento, string pDocIdentidad)
            {
                RUC = pRUC;
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
                CodTipoDocumentoAfiliado = pTipDocumento;
                NumeroDocumentoAfiliado = pDocIdentidad;
            }
        }

        public class AsegNombResponse
        {
            public string CodProducto { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string DesParentesco { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string CodEstado { get; set; } = "";
            public string DesEstado { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string FechaNacimiento { get; set; } = "";
            public string CodGenero { get; set; } = "";
            public string DesGenero { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string DesTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string NumeroContratoAfiliado { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
            public string TipoCalificadorContratante { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string DesTipoDocumentoContratante { get; set; } = "";
        }

        public class AsegCodRequest
        {
            public string SUNASA { get; set; } = "";
            public string IAFAS { get; set; } = "";
            public string RUC { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string CodProducto { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string TipoCalificadorContratante { get; set; } = "";
            public string CodEspecialidad { get; set; } = "";

            public AsegCodRequest()
            {
            }

            public AsegCodRequest(string pSUNASA, string pIAFAS, string pRUC)
            {
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
                RUC = pRUC;
            }
        }

        public class AsegCodResponse
        {
            public DatosAfiliado_AsegCode DatosAfiliado { get; set; }
            public List<Coberturas_AsegCode> Coberturas { get; set; } = new List<Coberturas_AsegCode>();
        }

        public class DatosAfiliado_AsegCode
        {
            public string CodigoAfiliado { get; set; } = "";
            public string NumeroPoliza { get; set; } = "";
            public string NumeroContrato { get; set; } = "";
            public string NumeroCertificado { get; set; } = "";
            public string CodProducto { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string CodGenero { get; set; } = "";
            public string DesGenero { get; set; } = "";
            public string CodFechaNacimiento { get; set; } = "";
            public string FechaNacimiento { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string DesParentesco { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string DesTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string Edad { get; set; } = "";
            public string CodFechaInicioVigencia { get; set; } = "";
            public string FechaInicioVigencia { get; set; } = "";
            public string CodFechaFinVigencia { get; set; } = "";
            public string FechaFinVigencia { get; set; } = "";
            public string CodEstadoCivil { get; set; } = "";
            public string DesEstadoCivil { get; set; } = "";
            public string CodTipoPlan { get; set; } = "";
            public string DesTipoPlan { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string CodEstado { get; set; } = "";
            public string DesEstado { get; set; } = "";
            public string CodFechaActualizacionFoto { get; set; } = "";
            public string FechaActualizacionFoto { get; set; } = "";
            public string ApellidoPaternoTitular { get; set; } = "";
            public string ApellidoMaternoTitular { get; set; } = "";
            public string NombresTitular { get; set; } = "";
            public string CodigoTitular { get; set; } = "";
            public string CodTipoDocumentoTitular { get; set; } = "";
            public string DesTipoDocumentoTitular { get; set; } = "";
            public string NumeroDocumentoTitular { get; set; } = "";
            public string CodMoneda { get; set; } = "";
            public string DesMoneda { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string DesTipoDocumentoContratante { get; set; } = "";
            public string CodTipoAfiliacion { get; set; } = "";
            public string DesTipoAfiliacion { get; set; } = "";
            public string CodFechaAfiliacion { get; set; } = "";
            public string FechaAfiliacion { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
        }

        public class Coberturas_AsegCode
        {
            public string CodigoTipoCobertura { get; set; } = "";
            public string CodigoSubTipoCobertura { get; set; } = "";
            public string CodigoCobertura { get; set; } = "";
            public string Beneficios { get; set; } = "";
            public string CodIndicadorRestriccion { get; set; } = "";
            public string Restricciones { get; set; } = "";
            public string CodCopagoFijo { get; set; } = "";
            public string DesCopagoFijo { get; set; } = "";
            public string CodCopagoVariable { get; set; } = "";
            public string DesCopagoVariable { get; set; } = "";
            public string CodFechaFinCarencia { get; set; } = "";
            public string FechaFinCarencia { get; set; } = "";
            public string CondicionesEspeciales { get; set; } = "";
            public string Observaciones { get; set; } = "";
            public string CodCalificacionServicio { get; set; } = "";
            public string DesCalificacionServicio { get; set; } = "";
            public string BeneficioMaximoInicial { get; set; } = "";
            public string NumeroCobertura { get; set; } = "";
            public string CodTipoMoneda { get; set; } = "";
            public string DesTipoMoneda { get; set; } = "";

            // TMACASSI 02/03/2020
            public string cIafasCode { get; set; } = "";
            public string cAsegCode { get; set; } = "";
            public string cAutoCode { get; set; } = "";
            public string cCoberCode { get; set; } = "";
            public string cSubTipoCober { get; set; } = "";
            public string nSubTipoCober { get; set; } = "";
            public string cIndiProCode { get; set; } = "";
            public string nCopgFijo { get; set; } = "";
            public string cMoneCode { get; set; } = "";
            public string cCalifServCode { get; set; } = "";
            public string nCopgVari { get; set; } = "";
            public string dBeneficioMax { get; set; } = "";
            public string fFeCarDate { get; set; } = "";
            public string fEsperDate { get; set; } = "";
            public string cFlagCarta { get; set; } = "";
            public string cProdCode { get; set; } = "";
            public string cEspeCode { get; set; } = "";
            public string dIpssHost { get; set; } = "";
            public string cOrigenAte { get; set; } = "";
            public string cAccidentes { get; set; } = "";
            public string cTiDeclaracion { get; set; } = "";
            public string dObserva { get; set; } = "";
            public string dComercName { get; set; } = "";
            public string fAccidentes { get; set; } = "";
            public string fOrigenAten { get; set; } = "";
            public string cUserCode { get; set; } = "";
            public string nUserName { get; set; } = "";
            public string cFlagCGCode { get; set; } = "";
            public string dFlagCGName { get; set; } = "";
            public string cIndiRestriCode { get; set; } = "";
            public string dObsCarencia { get; set; } = "";
        }

        public class NumeroAutorizacionRequest
        {
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string BeneficioMaximoInicial { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string CodigoTitular { get; set; } = "";
            public string CodCalificacionServicio { get; set; } = "";
            public string CodEstado { get; set; } = "";
            public string CodEspecialidad { get; set; } = "";
            public string CodMoneda { get; set; } = "";
            public string CodCopagoFijo { get; set; } = "";
            public string CodCopagoVariable { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string CodProducto { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
            public string CodSubTipoCobertura { get; set; } = "";
            public string CodTipoCobertura { get; set; } = "";
            public string CodTipoAfiliacion { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string CodEstadoMarital { get; set; } = "";
            public string CodFechaFinCarencia { get; set; } = "";
            public string CodFechaAfiliacion { get; set; } = "";
            public string CodFechaInicioVigencia { get; set; } = "";
            public string CodFechaNacimiento { get; set; } = "";
            public string CodGenero { get; set; } = "";
            public string SUNASA { get; set; } = "";
            public string IAFAS { get; set; } = "";
            public string CondicionesEspeciales { get; set; } = "";
            public string ApellidoMaternoTitular { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string ApellidoPaternoTitular { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string NombresTitular { get; set; } = "";
            public string NumeroCertificado { get; set; } = "";
            public string NumeroContrato { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoTitular { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string NumeroPoliza { get; set; } = "";
            public string RUC { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string CodTipoDocumentoTitular { get; set; } = "";
            public string CodTipoPlan { get; set; } = "";
            public string CodIndicadorRestriccion { get; set; } = "";
            public string CodFechaActualizacionFoto { get; set; } = "";
            public string CodTipoMoneda { get; set; } = "";

            public NumeroAutorizacionRequest()
            {
            }

            public NumeroAutorizacionRequest(string pSUNASA, string pIAFAS, string pRUC)
            {
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
                RUC = pRUC;
            }
        }

        public class NumeroAutorizacionResponse
        {
            public string NumeroAutorizacion { get; set; } = "";
            public string Documento { get; set; } = "";
        }
        // I-TMACASSI 02/03/2020
        public class CoberturaRequest
        {
            public string cIafasCode { get; set; } = "";
            public string cAsegCode { get; set; } = "";
            public string cAutoCode { get; set; } = "";
            public string cCoberCode { get; set; } = "";
            public string cSubTipoCober { get; set; } = "";
            public string nSubTipoCober { get; set; } = "";
            public string cIndiProCode { get; set; } = "";
            public string nCopgFijo { get; set; } = "";
            public string cMoneCode { get; set; } = "";
            public string cCalifServCode { get; set; } = "";
            public string nCopgVari { get; set; } = "";
            public string dBeneficioMax { get; set; } = "";
            public string fFeCarDate { get; set; } = "";
            public string fEsperDate { get; set; } = "";
            public string cFlagCarta { get; set; } = "";
            public string cProdCode { get; set; } = "";
            public string cEspeCode { get; set; } = "";
            public string dIpssHost { get; set; } = "";
            public string cOrigenAte { get; set; } = "";
            public string cAccidentes { get; set; } = "";
            public string cTiDeclaracion { get; set; } = "";
            public string dObserva { get; set; } = "";
            public string dComercName { get; set; } = "";
            public string fAccidentes { get; set; } = "";
            public string fOrigenAten { get; set; } = "";
            public string cUserCode { get; set; } = "";
            public string nUserName { get; set; } = "";
            public string cFlagCGCode { get; set; } = "";
            public string dFlagCGName { get; set; } = "";
            public string cIndiRestriCode { get; set; } = "";
            public string dObsCarencia { get; set; } = "";
        }
        // F-TMACASSI 02/03/2020
        public class ObservacionRequest
        {
            public string SUNASA { get; set; } = "";
            public string IAFAS { get; set; } = "";
            public string RUC { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string CodProducto { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string TipoCalificadorContratante { get; set; } = "";
            public string CodEspecialidad { get; set; } = "";

            public ObservacionRequest()
            {
            }

            public ObservacionRequest(string pSUNASA, string pIAFAS, string pRUC)
            {
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
                RUC = pRUC;
            }
        }

        public class ObservacionResponse
        {
            public string IndObservacionAsegurado { get; set; } = "";
            public string IndObservacionesEspeciales { get; set; } = "";
            public string Observaciones { get; set; } = "";
        }

        public class DatosAdicionalesRequest
        {
            public string SUNASA { get; set; } = "";
            public string IAFAS { get; set; } = "";
            public string RUC { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string CodProducto { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string TipoCalificadorContratante { get; set; } = "";
            public string CodEspecialidad { get; set; } = "";

            public DatosAdicionalesRequest()
            {
            }

            public DatosAdicionalesRequest(string pSUNASA, string pIAFAS, string pRUC)
            {
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
                RUC = pRUC;
            }
        }

        public class DatosAdicionalesResponse
        {
            public string Direccion1 { get; set; } = "";
            public string Direccion2 { get; set; } = "";
            public string Ubigeo { get; set; } = "";
            public string Contacto { get; set; } = "";
            public string Calificador { get; set; } = "";
            public string Email { get; set; } = "";
            public string NumeroTelefono { get; set; } = "";
        }

        public class CondicionMedicaRequest
        {
            public string SUNASA { get; set; } = "";
            public string IAFAS { get; set; } = "";
            public string RUC { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string CodProducto { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string TipoCalificadorContratante { get; set; } = "";
            public string CodEspecialidad { get; set; } = "";

            public CondicionMedicaRequest()
            {
            }

            public CondicionMedicaRequest(string pSUNASA, string pIAFAS, string pRUC)
            {
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
                RUC = pRUC;
            }
        }

        public class CondicionMedicaResponse
        {
            public PreExistencia PreExistencia { get; set; } = new PreExistencia();
            public Exclusiones Exclusiones { get; set; } = new Exclusiones();
            public Carencia Carencia { get; set; } = new Carencia();
            public Antecedentes Antecedentes { get; set; } = new Antecedentes();
            public Enfermedad Enfermedad { get; set; } = new Enfermedad();
        }

        public class PreExistencia
        {
            public string CodRestriccion { get; set; } = "";
            public string DesRestriccion { get; set; } = "";
            public List<Condicion> Condicion { get; set; } = new List<Condicion>();
        }

        public class Exclusiones
        {
            public string CodRestriccion { get; set; } = "";
            public string DesRestriccion { get; set; } = "";
            public List<Condicion> Condicion { get; set; } = new List<Condicion>();
        }

        public class Carencia
        {
            public string CodRestriccion { get; set; } = "";
            public string DesRestriccion { get; set; } = "";
            public List<Condicion> Condicion { get; set; } = new List<Condicion>();
        }

        public class Antecedentes
        {
            public string CodRestriccion { get; set; } = "";
            public string DesRestriccion { get; set; } = "";
            public List<Condicion> Condicion { get; set; } = new List<Condicion>();
        }

        public class Enfermedad
        {
            public string CodRestriccion { get; set; } = "";
            public string DesRestriccion { get; set; } = "";
            public List<Condicion> Condicion { get; set; } = new List<Condicion>();
        }

        public class Condicion
        {
            public string Codigo { get; set; } = "";
            public string Diagnostico { get; set; } = "";
            public string Observaciones { get; set; } = "";
        }

        public class FotoRequest
        {
            public string IAFAS { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string CodFechaActualizacionFoto { get; set; } = "";
        }

        public class FotoResponse
        {
            public byte[] Foto { get; set; }
        }

        public class CasoTiempoEsperaRequest
        {
            public string SUNASA { get; set; } = "";
            public string IAFAS { get; set; } = "";
            public string RUC { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string CodProducto { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string NumeroCobertura { get; set; } = "";
            public string BeneficioMaximoInicial { get; set; } = "";
            public string CodigoTipoCobertura { get; set; } = "";
            public string CodigoSubTipoCobertura { get; set; } = "";
            public string CodEspecialidad { get; set; } = "";

            public CasoTiempoEsperaRequest()
            {
            }

            public CasoTiempoEsperaRequest(string pSUNASA, string pIAFAS, string pRUC)
            {
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
                RUC = pRUC;
            }
        }

        public class CasoTiempoEsperaResponse
        {
            public Procedimiento Procedimiento { get; set; } = new Procedimiento();
            public TiempoEspera TiempoEspera { get; set; } = new TiempoEspera();
            public ExcepcionCarencia ExcepcionCarencia { get; set; } = new ExcepcionCarencia();
        }

        public class ProcedimientosEspecialesRequest
        {
            public string SUNASA { get; set; } = "";
            public string IAFAS { get; set; } = "";
            public string RUC { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string CodProducto { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string NumeroCobertura { get; set; } = "";
            public string BeneficioMaximoInicial { get; set; } = "";
            public string CodigoTipoCobertura { get; set; } = "";
            public string CodigoSubTipoCobertura { get; set; } = "";
            public string CodEspecialidad { get; set; } = "";

            public ProcedimientosEspecialesRequest()
            {
            }

            public ProcedimientosEspecialesRequest(string pSUNASA, string pIAFAS, string pRUC)
            {
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
                RUC = pRUC;
            }
        }

        public class ProcedimientosEspecialesResponse
        {
            public Procedimiento Procedimiento { get; set; } = new Procedimiento();
            public List<Detalle> Detalle { get; set; } = new List<Detalle>();
        }

        public class CasoExcepcionCarenciaRequest
        {
            public string SUNASA { get; set; } = "";
            public string IAFAS { get; set; } = "";
            public string RUC { get; set; } = "";
            public string NombresAfiliado { get; set; } = "";
            public string ApellidoPaternoAfiliado { get; set; } = "";
            public string ApellidoMaternoAfiliado { get; set; } = "";
            public string CodigoAfiliado { get; set; } = "";
            public string CodTipoDocumentoAfiliado { get; set; } = "";
            public string NumeroDocumentoAfiliado { get; set; } = "";
            public string CodProducto { get; set; } = "";
            public string DesProducto { get; set; } = "";
            public string NumeroPlan { get; set; } = "";
            public string CodTipoDocumentoContratante { get; set; } = "";
            public string NumeroDocumentoContratante { get; set; } = "";
            public string NombreContratante { get; set; } = "";
            public string CodParentesco { get; set; } = "";
            public string NumeroCobertura { get; set; } = "";
            public string BeneficioMaximoInicial { get; set; } = "";
            public string CodigoTipoCobertura { get; set; } = "";
            public string CodigoSubTipoCobertura { get; set; } = "";
            public string CodEspecialidad { get; set; } = "";


            public CasoExcepcionCarenciaRequest()
            {
            }

            public CasoExcepcionCarenciaRequest(string pSUNASA, string pIAFAS, string pRUC)
            {
                SUNASA = pSUNASA;
                IAFAS = pIAFAS;
                RUC = pRUC;
            }
        }

        public class CasoExcepcionCarenciaResponse
        {
            public Procedimiento Procedimiento { get; set; } = new Procedimiento();
            public TiempoEspera TiempoEspera { get; set; } = new TiempoEspera();
            public ExcepcionCarencia ExcepcionCarencia { get; set; } = new ExcepcionCarencia();
        }

        public class Procedimiento
        {
            public string Descripcion { get; set; } = "";
            public string CodIndicadorProcedimiento { get; set; } = "";
            public string DesIndicadorProcedimiento { get; set; } = "";
            public List<Detalle> Detalle { get; set; } = new List<Detalle>();
        }

        public class TiempoEspera
        {
            public string Descripcion { get; set; } = "";
            public List<Detalle> Detalle { get; set; } = new List<Detalle>();
        }

        public class ExcepcionCarencia
        {
            public string Descripcion { get; set; } = "";
            public List<Detalle> Detalle { get; set; } = new List<Detalle>();
        }

        public class Detalle
        {
            public string Codigo { get; set; } = "";
            public string Procedimiento { get; set; } = "";
            public string Genero { get; set; } = "";
            public string CodCopagoFijo { get; set; } = "";
            public string DesCopagoFijo { get; set; } = "";
            public string CodCopagoVariable { get; set; } = "";
            public string DesCopagoVariable { get; set; } = "";
            public string Frecuencia { get; set; } = "";
            public string Tiempo { get; set; } = "";
            public string FechaFinVigencia { get; set; } = ""; // Date = Date.Now
            public string Observaciones { get; set; } = "";
        }


        public SitedsWs()
        {
        }

        public SitedsWs(string pRuc)
        {
            xRuc = pRuc;
        }

        public SitedsWs(string pRuc, string pSunasa)
        {
            xSunasa = pSunasa;
            xRuc = pRuc;
        }

        public SitedsWs(string pRuc, string pSunasa, string pIAFAS)
        {
            xSunasa = pSunasa;
            xRuc = pRuc;
            xIAFAS = pIAFAS;
        }


        public static string ConsultaAsegNom(string Url, AsegNombRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaAsegNom", new Json.Parameters("CodTipoDocumentoAfiliado", objRequest.CodTipoDocumentoAfiliado), new Json.Parameters("NumeroDocumentoAfiliado", objRequest.NumeroDocumentoAfiliado), new Json.Parameters("RUC", objRequest.RUC), new Json.Parameters("SUNASA", objRequest.SUNASA), new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("NombresAfiliado", objRequest.NombresAfiliado), new Json.Parameters("ApellidoPaternoAfiliado", objRequest.ApellidoPaternoAfiliado), new Json.Parameters("ApellidoMaternoAfiliado", objRequest.ApellidoMaternoAfiliado), new Json.Parameters("CodEspecialidad", objRequest.CodEspecialidad));
            return stringJson;
        }

        public static string ConsultaAsegCod(string Url, AsegCodRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaAsegCod", new Json.Parameters("SUNASA", objRequest.SUNASA), new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("RUC", objRequest.RUC), new Json.Parameters("NombresAfiliado", objRequest.NombresAfiliado), new Json.Parameters("ApellidoPaternoAfiliado", objRequest.ApellidoPaternoAfiliado), new Json.Parameters("ApellidoMaternoAfiliado", objRequest.ApellidoMaternoAfiliado), new Json.Parameters("CodigoAfiliado", objRequest.CodigoAfiliado), new Json.Parameters("CodTipoDocumentoAfiliado", objRequest.CodTipoDocumentoAfiliado), new Json.Parameters("NumeroDocumentoAfiliado", objRequest.NumeroDocumentoAfiliado), new Json.Parameters("CodProducto", objRequest.CodProducto), new Json.Parameters("DesProducto", objRequest.DesProducto), new Json.Parameters("NumeroPlan", objRequest.NumeroPlan), new Json.Parameters("CodTipoDocumentoContratante", objRequest.CodTipoDocumentoContratante), new Json.Parameters("NumeroDocumentoContratante", objRequest.NumeroDocumentoContratante), new Json.Parameters("NombreContratante", objRequest.NombreContratante), new Json.Parameters("CodParentesco", objRequest.CodParentesco), new Json.Parameters("TipoCalificadorContratante", objRequest.TipoCalificadorContratante), new Json.Parameters("CodEspecialidad", objRequest.CodEspecialidad));
            return stringJson;
        }

        public static string ConsultaNumeroAutorizacion(string Url, NumeroAutorizacionRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaNumeroAutorizacion", new Json.Parameters("ApellidoMaternoAfiliado", objRequest.ApellidoMaternoAfiliado), new Json.Parameters("ApellidoPaternoAfiliado", objRequest.ApellidoPaternoAfiliado), new Json.Parameters("BeneficioMaximoInicial", objRequest.BeneficioMaximoInicial), new Json.Parameters("CodigoAfiliado", objRequest.CodigoAfiliado), new Json.Parameters("CodigoTitular", objRequest.CodigoTitular), new Json.Parameters("CodCalificacionServicio", objRequest.CodCalificacionServicio), new Json.Parameters("CodEstado", objRequest.CodEstado), new Json.Parameters("CodEspecialidad", objRequest.CodEspecialidad), new Json.Parameters("CodMoneda", objRequest.CodMoneda), new Json.Parameters("CodCopagoFijo", objRequest.CodCopagoFijo), new Json.Parameters("CodCopagoVariable", objRequest.CodCopagoVariable), new Json.Parameters("CodParentesco", objRequest.CodParentesco), new Json.Parameters("CodProducto", objRequest.CodProducto), new Json.Parameters("NumeroDocumentoContratante", objRequest.NumeroDocumentoContratante), new Json.Parameters("CodSubTipoCobertura", objRequest.CodSubTipoCobertura), new Json.Parameters("CodTipoCobertura", objRequest.CodTipoCobertura), new Json.Parameters("CodTipoAfiliacion", objRequest.CodTipoAfiliacion), new Json.Parameters("DesProducto", objRequest.DesProducto), new Json.Parameters("CodEstadoMarital", objRequest.CodEstadoMarital), new Json.Parameters("CodFechaFinCarencia", objRequest.CodFechaFinCarencia), new Json.Parameters("CodFechaAfiliacion", objRequest.CodFechaAfiliacion), new Json.Parameters("CodFechaInicioVigencia", objRequest.CodFechaInicioVigencia), new Json.Parameters("CodFechaNacimiento", objRequest.CodFechaNacimiento), new Json.Parameters("CodGenero", objRequest.CodGenero), new Json.Parameters("SUNASA", objRequest.SUNASA), new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("CondicionesEspeciales", objRequest.CondicionesEspeciales), new Json.Parameters("ApellidoMaternoTitular", objRequest.ApellidoMaternoTitular), new Json.Parameters("NombreContratante", objRequest.NombreContratante), new Json.Parameters("ApellidoPaternoTitular", objRequest.ApellidoPaternoTitular), new Json.Parameters("NombresAfiliado", objRequest.NombresAfiliado), new Json.Parameters("NombresTitular", objRequest.NombresTitular), new Json.Parameters("NumeroCertificado", objRequest.NumeroCertificado), new Json.Parameters("NumeroContrato", objRequest.NumeroContrato), new Json.Parameters("NumeroDocumentoAfiliado", objRequest.NumeroDocumentoAfiliado), new Json.Parameters("NumeroDocumentoTitular", objRequest.NumeroDocumentoTitular), new Json.Parameters("NumeroPlan", objRequest.NumeroPlan), new Json.Parameters("NumeroPoliza", objRequest.NumeroPoliza), new Json.Parameters("RUC", objRequest.RUC), new Json.Parameters("CodTipoDocumentoContratante", objRequest.CodTipoDocumentoContratante), new Json.Parameters("CodTipoDocumentoAfiliado", objRequest.CodTipoDocumentoAfiliado), new Json.Parameters("CodTipoDocumentoTitular", objRequest.CodTipoDocumentoTitular), new Json.Parameters("CodTipoPlan", objRequest.CodTipoPlan), new Json.Parameters("CodIndicadorRestriccion", objRequest.CodIndicadorRestriccion), new Json.Parameters("CodFechaActualizacionFoto", objRequest.CodFechaActualizacionFoto), new Json.Parameters("CodTipoMoneda", objRequest.CodTipoMoneda));

            return stringJson;
        }

        public static string ConsultaObservacion(string Url, ObservacionRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaObservacion", new Json.Parameters("SUNASA", objRequest.SUNASA), new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("RUC", objRequest.RUC), new Json.Parameters("NombresAfiliado", objRequest.NombresAfiliado), new Json.Parameters("ApellidoPaternoAfiliado", objRequest.ApellidoPaternoAfiliado), new Json.Parameters("ApellidoMaternoAfiliado", objRequest.ApellidoMaternoAfiliado), new Json.Parameters("CodigoAfiliado", objRequest.CodigoAfiliado), new Json.Parameters("CodTipoDocumentoAfiliado", objRequest.CodTipoDocumentoAfiliado), new Json.Parameters("NumeroDocumentoAfiliado", objRequest.NumeroDocumentoAfiliado), new Json.Parameters("CodProducto", objRequest.CodProducto), new Json.Parameters("DesProducto", objRequest.DesProducto), new Json.Parameters("NumeroPlan", objRequest.NumeroPlan), new Json.Parameters("CodTipoDocumentoContratante", objRequest.CodTipoDocumentoContratante), new Json.Parameters("NumeroDocumentoContratante", objRequest.NumeroDocumentoContratante), new Json.Parameters("NombreContratante", objRequest.NombreContratante), new Json.Parameters("CodParentesco", objRequest.CodParentesco), new Json.Parameters("TipoCalificadorContratante", objRequest.TipoCalificadorContratante), new Json.Parameters("CodEspecialidad", objRequest.CodEspecialidad));
            return stringJson;
        }

        public static string ConsultaDatosAdicionales(string Url, DatosAdicionalesRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaDatosAdicionales", new Json.Parameters("SUNASA", objRequest.SUNASA), new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("RUC", objRequest.RUC), new Json.Parameters("NombresAfiliado", objRequest.NombresAfiliado), new Json.Parameters("ApellidoPaternoAfiliado", objRequest.ApellidoPaternoAfiliado), new Json.Parameters("ApellidoMaternoAfiliado", objRequest.ApellidoMaternoAfiliado), new Json.Parameters("CodigoAfiliado", objRequest.CodigoAfiliado), new Json.Parameters("CodTipoDocumentoAfiliado", objRequest.CodTipoDocumentoAfiliado), new Json.Parameters("NumeroDocumentoAfiliado", objRequest.NumeroDocumentoAfiliado), new Json.Parameters("CodProducto", objRequest.CodProducto), new Json.Parameters("DesProducto", objRequest.DesProducto), new Json.Parameters("NumeroPlan", objRequest.NumeroPlan), new Json.Parameters("CodTipoDocumentoContratante", objRequest.CodTipoDocumentoContratante), new Json.Parameters("NumeroDocumentoContratante", objRequest.NumeroDocumentoContratante), new Json.Parameters("NombreContratante", objRequest.NombreContratante), new Json.Parameters("CodParentesco", objRequest.CodParentesco), new Json.Parameters("TipoCalificadorContratante", objRequest.TipoCalificadorContratante), new Json.Parameters("CodEspecialidad", objRequest.CodEspecialidad));
            return stringJson;
        }

        public static string ConsultaCondicionMedica(string Url, CondicionMedicaRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaCondicionMedica", new Json.Parameters("SUNASA", objRequest.SUNASA), new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("RUC", objRequest.RUC), new Json.Parameters("NombresAfiliado", objRequest.NombresAfiliado), new Json.Parameters("ApellidoPaternoAfiliado", objRequest.ApellidoPaternoAfiliado), new Json.Parameters("ApellidoMaternoAfiliado", objRequest.ApellidoMaternoAfiliado), new Json.Parameters("CodigoAfiliado", objRequest.CodigoAfiliado), new Json.Parameters("CodTipoDocumentoAfiliado", objRequest.CodTipoDocumentoAfiliado), new Json.Parameters("NumeroDocumentoAfiliado", objRequest.NumeroDocumentoAfiliado), new Json.Parameters("CodProducto", objRequest.CodProducto), new Json.Parameters("DesProducto", objRequest.DesProducto), new Json.Parameters("NumeroPlan", objRequest.NumeroPlan), new Json.Parameters("CodTipoDocumentoContratante", objRequest.CodTipoDocumentoContratante), new Json.Parameters("NumeroDocumentoContratante", objRequest.NumeroDocumentoContratante), new Json.Parameters("NombreContratante", objRequest.NombreContratante), new Json.Parameters("CodParentesco", objRequest.CodParentesco), new Json.Parameters("TipoCalificadorContratante", objRequest.TipoCalificadorContratante), new Json.Parameters("CodEspecialidad", objRequest.CodEspecialidad));
            return stringJson;
        }
        // I-TMACASSI 02/03/2020
        public static string ConsultaCoberturaAcred(string Url, CoberturaRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaCondicionMedica", new Json.Parameters("cIafasCode", objRequest.cIafasCode), new Json.Parameters("cAsegCode", objRequest.cAsegCode), new Json.Parameters("cAutoCode", objRequest.cAutoCode), new Json.Parameters("cCoberCode", objRequest.cCoberCode), new Json.Parameters("cSubTipoCober", objRequest.cSubTipoCober), new Json.Parameters("nSubTipoCober", objRequest.nSubTipoCober), new Json.Parameters("cIndiProCode", objRequest.cIndiProCode), new Json.Parameters("nCopgFijo", objRequest.nCopgFijo), new Json.Parameters("cMoneCode", objRequest.cMoneCode), new Json.Parameters("cCalifServCode", objRequest.cCalifServCode), new Json.Parameters("nCopgVari", objRequest.nCopgVari), new Json.Parameters("dBeneficioMax", objRequest.dBeneficioMax), new Json.Parameters("fFeCarDate", objRequest.fFeCarDate), new Json.Parameters("fEsperDate", objRequest.fEsperDate), new Json.Parameters("cFlagCarta", objRequest.cFlagCarta), new Json.Parameters("cProdCode", objRequest.cProdCode), new Json.Parameters("cEspeCode", objRequest.cEspeCode), new Json.Parameters("dIpssHost", objRequest.dIpssHost), new Json.Parameters("cOrigenAte", objRequest.cOrigenAte), new Json.Parameters("cAccidentes", objRequest.cAccidentes), new Json.Parameters("cTiDeclaracion", objRequest.cTiDeclaracion), new Json.Parameters("cTiDeclaracion", objRequest.cTiDeclaracion), new Json.Parameters("dObserva", objRequest.dObserva), new Json.Parameters("dComercName", objRequest.dComercName), new Json.Parameters("fAccidentes", objRequest.fAccidentes), new Json.Parameters("fOrigenAten", objRequest.fOrigenAten), new Json.Parameters("cUserCode", objRequest.cUserCode), new Json.Parameters("nUserName", objRequest.nUserName), new Json.Parameters("cFlagCGCode", objRequest.cFlagCGCode), new Json.Parameters("dFlagCGName", objRequest.dFlagCGName), new Json.Parameters("cIndiRestriCode", objRequest.cIndiRestriCode), new Json.Parameters("dObsCarencia", objRequest.dObsCarencia));

            return stringJson;
        }
        // F-TMACASSI 02/03/2020
        public static string ObtenerFoto(string Url, FotoRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ObtenerFoto", new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("CodigoAfiliado", objRequest.CodigoAfiliado), new Json.Parameters("CodFechaActualizacionFoto", objRequest.CodFechaActualizacionFoto));
            return stringJson;
        }

        public static string CasoTiempoEspera(string Url, CasoTiempoEsperaRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaProcedimientosEspeciales", new Json.Parameters("SUNASA", objRequest.SUNASA), new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("RUC", objRequest.RUC), new Json.Parameters("NombresAfiliado", objRequest.NombresAfiliado), new Json.Parameters("ApellidoPaternoAfiliado", objRequest.ApellidoPaternoAfiliado), new Json.Parameters("ApellidoMaternoAfiliado", objRequest.ApellidoMaternoAfiliado), new Json.Parameters("CodigoAfiliado", objRequest.CodigoAfiliado), new Json.Parameters("CodTipoDocumentoAfiliado", objRequest.CodTipoDocumentoAfiliado), new Json.Parameters("NumeroDocumentoAfiliado", objRequest.NumeroDocumentoAfiliado), new Json.Parameters("CodProducto", objRequest.CodProducto), new Json.Parameters("DesProducto", objRequest.DesProducto), new Json.Parameters("NumeroPlan", objRequest.NumeroPlan), new Json.Parameters("CodTipoDocumentoContratante", objRequest.CodTipoDocumentoContratante), new Json.Parameters("NumeroDocumentoContratante", objRequest.NumeroDocumentoContratante), new Json.Parameters("NombreContratante", objRequest.NombreContratante), new Json.Parameters("CodParentesco", objRequest.CodParentesco), new Json.Parameters("NumeroCobertura", objRequest.NumeroCobertura), new Json.Parameters("BeneficioMaximoInicial", objRequest.BeneficioMaximoInicial), new Json.Parameters("CodigoTipoCobertura", objRequest.CodigoTipoCobertura), new Json.Parameters("CodigoSubTipoCobertura", objRequest.CodigoSubTipoCobertura), new Json.Parameters("CodEspecialidad", objRequest.CodEspecialidad));
            return stringJson;
        }

        public static string ProcedimientosEspeciales(string Url, ProcedimientosEspecialesRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaProcedimientosEspeciales", new Json.Parameters("SUNASA", objRequest.SUNASA), new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("RUC", objRequest.RUC), new Json.Parameters("NombresAfiliado", objRequest.NombresAfiliado), new Json.Parameters("ApellidoPaternoAfiliado", objRequest.ApellidoPaternoAfiliado), new Json.Parameters("ApellidoMaternoAfiliado", objRequest.ApellidoMaternoAfiliado), new Json.Parameters("CodigoAfiliado", objRequest.CodigoAfiliado), new Json.Parameters("CodTipoDocumentoAfiliado", objRequest.CodTipoDocumentoAfiliado), new Json.Parameters("NumeroDocumentoAfiliado", objRequest.NumeroDocumentoAfiliado), new Json.Parameters("CodProducto", objRequest.CodProducto), new Json.Parameters("DesProducto", objRequest.DesProducto), new Json.Parameters("NumeroPlan", objRequest.NumeroPlan), new Json.Parameters("CodTipoDocumentoContratante", objRequest.CodTipoDocumentoContratante), new Json.Parameters("NumeroDocumentoContratante", objRequest.NumeroDocumentoContratante), new Json.Parameters("NombreContratante", objRequest.NombreContratante), new Json.Parameters("CodParentesco", objRequest.CodParentesco), new Json.Parameters("NumeroCobertura", objRequest.NumeroCobertura), new Json.Parameters("BeneficioMaximoInicial", objRequest.BeneficioMaximoInicial), new Json.Parameters("CodigoTipoCobertura", objRequest.CodigoTipoCobertura), new Json.Parameters("CodigoSubTipoCobertura", objRequest.CodigoSubTipoCobertura), new Json.Parameters("CodEspecialidad", objRequest.CodEspecialidad));
            return stringJson;
        }

        public static string CasoExcepcionCarencia(string Url, CasoExcepcionCarenciaRequest objRequest)
        {
            string stringJson = Json.MethodPost(Url + "ConsultaProcedimientosEspeciales", new Json.Parameters("SUNASA", objRequest.SUNASA), new Json.Parameters("IAFAS", objRequest.IAFAS), new Json.Parameters("RUC", objRequest.RUC), new Json.Parameters("NombresAfiliado", objRequest.NombresAfiliado), new Json.Parameters("ApellidoPaternoAfiliado", objRequest.ApellidoPaternoAfiliado), new Json.Parameters("ApellidoMaternoAfiliado", objRequest.ApellidoMaternoAfiliado), new Json.Parameters("CodigoAfiliado", objRequest.CodigoAfiliado), new Json.Parameters("CodTipoDocumentoAfiliado", objRequest.CodTipoDocumentoAfiliado), new Json.Parameters("NumeroDocumentoAfiliado", objRequest.NumeroDocumentoAfiliado), new Json.Parameters("CodProducto", objRequest.CodProducto), new Json.Parameters("DesProducto", objRequest.DesProducto), new Json.Parameters("NumeroPlan", objRequest.NumeroPlan), new Json.Parameters("CodTipoDocumentoContratante", objRequest.CodTipoDocumentoContratante), new Json.Parameters("NumeroDocumentoContratante", objRequest.NumeroDocumentoContratante), new Json.Parameters("NombreContratante", objRequest.NombreContratante), new Json.Parameters("CodParentesco", objRequest.CodParentesco), new Json.Parameters("NumeroCobertura", objRequest.NumeroCobertura), new Json.Parameters("BeneficioMaximoInicial", objRequest.BeneficioMaximoInicial), new Json.Parameters("CodigoTipoCobertura", objRequest.CodigoTipoCobertura), new Json.Parameters("CodigoSubTipoCobertura", objRequest.CodigoSubTipoCobertura), new Json.Parameters("CodEspecialidad", objRequest.CodEspecialidad));
            return stringJson;
        }



        public AsegCodRequest fnAsegCod(AsegNombResponse pAsegNomb)
        {
            AsegCodRequest xAsegCodRequest = new AsegCodRequest(xSunasa, xIAFAS, xRuc);

            xAsegCodRequest.NombresAfiliado = pAsegNomb.NombresAfiliado;
            xAsegCodRequest.ApellidoPaternoAfiliado = pAsegNomb.ApellidoPaternoAfiliado;
            xAsegCodRequest.ApellidoMaternoAfiliado = pAsegNomb.ApellidoMaternoAfiliado;
            xAsegCodRequest.CodigoAfiliado = pAsegNomb.CodigoAfiliado;
            xAsegCodRequest.CodTipoDocumentoAfiliado = pAsegNomb.CodTipoDocumentoAfiliado;
            xAsegCodRequest.NumeroDocumentoAfiliado = pAsegNomb.NumeroDocumentoAfiliado;
            xAsegCodRequest.CodProducto = pAsegNomb.CodProducto;
            xAsegCodRequest.DesProducto = pAsegNomb.DesProducto;
            xAsegCodRequest.NumeroPlan = pAsegNomb.NumeroPlan;
            xAsegCodRequest.CodTipoDocumentoContratante = pAsegNomb.CodTipoDocumentoContratante;
            xAsegCodRequest.NumeroDocumentoContratante = pAsegNomb.NumeroDocumentoContratante;
            xAsegCodRequest.NombreContratante = pAsegNomb.NombreContratante;
            xAsegCodRequest.CodParentesco = pAsegNomb.CodParentesco;
            xAsegCodRequest.TipoCalificadorContratante = pAsegNomb.TipoCalificadorContratante;
            xAsegCodRequest.CodEspecialidad = "";

            return xAsegCodRequest;
        }

        public NumeroAutorizacionRequest fnNumeroAutorizacion(Coberturas_AsegCode oCoberturas, AsegCodResponse oAsegCodResponse)
        {
            NumeroAutorizacionRequest xNumAutorizacionRequest = new NumeroAutorizacionRequest(xSunasa, xIAFAS, xRuc);
            {
                var withBlock = xNumAutorizacionRequest;
                withBlock.BeneficioMaximoInicial = oCoberturas.BeneficioMaximoInicial;
                withBlock.CodCalificacionServicio = oCoberturas.CodCalificacionServicio;
                withBlock.CodCopagoFijo = oCoberturas.CodCopagoFijo;
                withBlock.CodCopagoVariable = oCoberturas.CodCopagoVariable;
                withBlock.CodSubTipoCobertura = oCoberturas.CodigoSubTipoCobertura;
                withBlock.CodTipoCobertura = oCoberturas.CodigoTipoCobertura;
                withBlock.CodFechaFinCarencia = oCoberturas.CodFechaFinCarencia;
                withBlock.CondicionesEspeciales = oCoberturas.CondicionesEspeciales;
                withBlock.CodIndicadorRestriccion = oCoberturas.CodIndicadorRestriccion;

                withBlock.ApellidoMaternoAfiliado = oAsegCodResponse.DatosAfiliado.ApellidoMaternoAfiliado;
                withBlock.ApellidoPaternoAfiliado = oAsegCodResponse.DatosAfiliado.ApellidoPaternoAfiliado;
                withBlock.CodigoAfiliado = oAsegCodResponse.DatosAfiliado.CodigoAfiliado;
                withBlock.CodigoTitular = oAsegCodResponse.DatosAfiliado.CodigoTitular;
                withBlock.CodEstado = oAsegCodResponse.DatosAfiliado.CodEstado;
                withBlock.CodEspecialidad = "";
                withBlock.CodMoneda = oAsegCodResponse.DatosAfiliado.CodMoneda;
                withBlock.CodParentesco = oAsegCodResponse.DatosAfiliado.CodParentesco;
                withBlock.CodProducto = oAsegCodResponse.DatosAfiliado.CodProducto;
                withBlock.NumeroDocumentoContratante = oAsegCodResponse.DatosAfiliado.NumeroDocumentoContratante;
                withBlock.CodTipoAfiliacion = oAsegCodResponse.DatosAfiliado.CodTipoAfiliacion;
                withBlock.DesProducto = oAsegCodResponse.DatosAfiliado.DesProducto;
                withBlock.CodEstadoMarital = oAsegCodResponse.DatosAfiliado.CodEstadoCivil;
                withBlock.CodFechaAfiliacion = oAsegCodResponse.DatosAfiliado.CodFechaAfiliacion;
                withBlock.CodFechaInicioVigencia = oAsegCodResponse.DatosAfiliado.CodFechaInicioVigencia;
                withBlock.CodFechaNacimiento = oAsegCodResponse.DatosAfiliado.CodFechaNacimiento;
                withBlock.CodGenero = oAsegCodResponse.DatosAfiliado.CodGenero;
                withBlock.ApellidoMaternoTitular = oAsegCodResponse.DatosAfiliado.ApellidoMaternoTitular;
                withBlock.NombreContratante = oAsegCodResponse.DatosAfiliado.NombreContratante;
                withBlock.ApellidoPaternoTitular = oAsegCodResponse.DatosAfiliado.ApellidoPaternoTitular;
                withBlock.NombresAfiliado = oAsegCodResponse.DatosAfiliado.NombresAfiliado;
                withBlock.NombresTitular = oAsegCodResponse.DatosAfiliado.NombresTitular;
                withBlock.NumeroCertificado = oAsegCodResponse.DatosAfiliado.NumeroCertificado;
                withBlock.NumeroContrato = oAsegCodResponse.DatosAfiliado.NumeroContrato;
                withBlock.NumeroDocumentoAfiliado = oAsegCodResponse.DatosAfiliado.NumeroDocumentoAfiliado;
                withBlock.NumeroDocumentoTitular = oAsegCodResponse.DatosAfiliado.NumeroDocumentoTitular;
                withBlock.NumeroPlan = oAsegCodResponse.DatosAfiliado.NumeroPlan;
                withBlock.NumeroPoliza = oAsegCodResponse.DatosAfiliado.NumeroPoliza;
                withBlock.CodTipoDocumentoContratante = oAsegCodResponse.DatosAfiliado.CodTipoDocumentoContratante;
                withBlock.CodTipoDocumentoAfiliado = oAsegCodResponse.DatosAfiliado.CodTipoDocumentoAfiliado;
                withBlock.CodTipoDocumentoTitular = oAsegCodResponse.DatosAfiliado.CodTipoDocumentoTitular;
                withBlock.CodTipoPlan = oAsegCodResponse.DatosAfiliado.CodTipoPlan;
                withBlock.CodFechaActualizacionFoto = oAsegCodResponse.DatosAfiliado.CodFechaActualizacionFoto;

                withBlock.CodTipoMoneda = oCoberturas.CodTipoMoneda;
            }

            return xNumAutorizacionRequest;
        }

        public ObservacionRequest fnObservacionRequest(NumeroAutorizacionRequest pNumAutorizacionRequest, AsegCodRequest pAsegCodRequest)
        {
            ObservacionRequest xObservacionRequest = new ObservacionRequest(xSunasa, xIAFAS, xRuc);
            {
                var withBlock = xObservacionRequest;
                withBlock.NombresAfiliado = pNumAutorizacionRequest.NombresAfiliado;
                withBlock.ApellidoPaternoAfiliado = pNumAutorizacionRequest.ApellidoPaternoAfiliado;
                withBlock.ApellidoMaternoAfiliado = pNumAutorizacionRequest.ApellidoMaternoAfiliado;
                withBlock.CodigoAfiliado = pNumAutorizacionRequest.CodigoAfiliado;
                withBlock.CodTipoDocumentoAfiliado = pNumAutorizacionRequest.CodTipoDocumentoAfiliado;
                withBlock.NumeroDocumentoAfiliado = pNumAutorizacionRequest.NumeroDocumentoAfiliado;
                withBlock.CodProducto = pNumAutorizacionRequest.CodProducto;
                withBlock.DesProducto = pNumAutorizacionRequest.DesProducto;
                withBlock.NumeroPlan = pNumAutorizacionRequest.NumeroPlan;
                withBlock.CodTipoDocumentoContratante = pNumAutorizacionRequest.CodTipoDocumentoContratante;
                withBlock.NumeroDocumentoContratante = pNumAutorizacionRequest.NumeroDocumentoContratante;
                withBlock.NombreContratante = pNumAutorizacionRequest.NombreContratante;
                withBlock.CodParentesco = pNumAutorizacionRequest.CodParentesco;
                withBlock.TipoCalificadorContratante = pAsegCodRequest.TipoCalificadorContratante;
                withBlock.CodEspecialidad = pAsegCodRequest.CodEspecialidad;
            }
            return xObservacionRequest;
        }

        public DatosAdicionalesRequest fnDatosAdicionalesRequest(NumeroAutorizacionRequest pNumAutorizacionRequest, AsegCodRequest pAsegCodRequest)
        {
            DatosAdicionalesRequest xDatosAdicionalesRequest = new DatosAdicionalesRequest(xSunasa, xIAFAS, xRuc);
            {
                var withBlock = xDatosAdicionalesRequest;
                withBlock.NombresAfiliado = pNumAutorizacionRequest.NombresAfiliado;
                withBlock.ApellidoPaternoAfiliado = pNumAutorizacionRequest.ApellidoPaternoAfiliado;
                withBlock.ApellidoMaternoAfiliado = pNumAutorizacionRequest.ApellidoMaternoAfiliado;
                withBlock.CodigoAfiliado = pNumAutorizacionRequest.CodigoAfiliado;
                withBlock.CodTipoDocumentoAfiliado = pNumAutorizacionRequest.CodTipoDocumentoAfiliado;
                withBlock.NumeroDocumentoAfiliado = pNumAutorizacionRequest.NumeroDocumentoAfiliado;
                withBlock.CodProducto = pNumAutorizacionRequest.CodProducto;
                withBlock.DesProducto = pNumAutorizacionRequest.DesProducto;
                withBlock.NumeroPlan = pNumAutorizacionRequest.NumeroPlan;
                withBlock.CodTipoDocumentoContratante = pNumAutorizacionRequest.CodTipoDocumentoContratante;
                withBlock.NumeroDocumentoContratante = pNumAutorizacionRequest.NumeroDocumentoContratante;
                withBlock.NombreContratante = pNumAutorizacionRequest.NombreContratante;
                withBlock.CodParentesco = pNumAutorizacionRequest.CodParentesco;
                withBlock.TipoCalificadorContratante = pAsegCodRequest.TipoCalificadorContratante;
                withBlock.CodEspecialidad = pAsegCodRequest.CodEspecialidad;
            }

            return xDatosAdicionalesRequest;
        }

        public CondicionMedicaRequest fnCondicionMedicaRequest(NumeroAutorizacionRequest pNumAutorizacionRequest, AsegCodRequest pAsegCodRequest)
        {
            CondicionMedicaRequest xCondicionMedicaRequest = new CondicionMedicaRequest(xSunasa, xIAFAS, xRuc);
            {
                var withBlock = xCondicionMedicaRequest;
                withBlock.NombresAfiliado = pNumAutorizacionRequest.NombresAfiliado;
                withBlock.ApellidoPaternoAfiliado = pNumAutorizacionRequest.ApellidoPaternoAfiliado;
                withBlock.ApellidoMaternoAfiliado = pNumAutorizacionRequest.ApellidoMaternoAfiliado;
                withBlock.CodigoAfiliado = pNumAutorizacionRequest.CodigoAfiliado;
                withBlock.CodTipoDocumentoAfiliado = pNumAutorizacionRequest.CodTipoDocumentoAfiliado;
                withBlock.NumeroDocumentoAfiliado = pNumAutorizacionRequest.NumeroDocumentoAfiliado;
                withBlock.CodProducto = pNumAutorizacionRequest.CodProducto;
                withBlock.DesProducto = pNumAutorizacionRequest.DesProducto;
                withBlock.NumeroPlan = pNumAutorizacionRequest.NumeroPlan;
                withBlock.CodTipoDocumentoContratante = pNumAutorizacionRequest.CodTipoDocumentoContratante;
                withBlock.NumeroDocumentoContratante = pNumAutorizacionRequest.NumeroDocumentoContratante;
                withBlock.NombreContratante = pNumAutorizacionRequest.NombreContratante;
                withBlock.CodParentesco = pNumAutorizacionRequest.CodParentesco;
                withBlock.TipoCalificadorContratante = pAsegCodRequest.TipoCalificadorContratante;
                withBlock.CodEspecialidad = pAsegCodRequest.CodEspecialidad;
            }

            return xCondicionMedicaRequest;
        }

        public FotoRequest fnFotoRequest(NumeroAutorizacionRequest pNumAutorizacionRequest)
        {
            FotoRequest xFotoRequest = new FotoRequest();
            {
                var withBlock = xFotoRequest;
                withBlock.CodFechaActualizacionFoto = pNumAutorizacionRequest.CodFechaActualizacionFoto;
                withBlock.CodigoAfiliado = pNumAutorizacionRequest.CodigoAfiliado;
                withBlock.IAFAS = pNumAutorizacionRequest.IAFAS;
            }

            return xFotoRequest;
        }

        public CasoTiempoEsperaRequest fnCasoTiempoEsperaRequest(NumeroAutorizacionRequest pNumAutorizacionRequest, Coberturas_AsegCode pCoberturas)
        {
            CasoTiempoEsperaRequest xCasoTiempoEsperaRequest = new CasoTiempoEsperaRequest(xSunasa, xIAFAS, xRuc);
            {
                var withBlock = xCasoTiempoEsperaRequest;
                withBlock.NombresAfiliado = pNumAutorizacionRequest.NombresAfiliado;
                withBlock.ApellidoPaternoAfiliado = pNumAutorizacionRequest.ApellidoPaternoAfiliado;
                withBlock.ApellidoMaternoAfiliado = pNumAutorizacionRequest.ApellidoMaternoAfiliado;
                withBlock.CodigoAfiliado = pNumAutorizacionRequest.CodigoAfiliado;
                withBlock.CodTipoDocumentoAfiliado = pNumAutorizacionRequest.CodTipoDocumentoAfiliado;
                withBlock.NumeroDocumentoAfiliado = pNumAutorizacionRequest.NumeroDocumentoAfiliado;
                withBlock.CodProducto = pNumAutorizacionRequest.CodProducto;
                withBlock.DesProducto = pNumAutorizacionRequest.DesProducto;
                withBlock.NumeroPlan = pNumAutorizacionRequest.NumeroPlan;
                withBlock.CodTipoDocumentoContratante = pNumAutorizacionRequest.CodTipoDocumentoContratante;
                withBlock.NumeroDocumentoContratante = pNumAutorizacionRequest.NumeroDocumentoContratante;
                withBlock.NombreContratante = pNumAutorizacionRequest.NombreContratante;
                withBlock.CodParentesco = pNumAutorizacionRequest.CodParentesco;
                withBlock.NumeroCobertura = pCoberturas.NumeroCobertura;
                withBlock.BeneficioMaximoInicial = pNumAutorizacionRequest.BeneficioMaximoInicial;
                withBlock.CodigoTipoCobertura = pNumAutorizacionRequest.CodTipoCobertura;
                withBlock.CodigoSubTipoCobertura = pNumAutorizacionRequest.CodSubTipoCobertura;
                withBlock.CodEspecialidad = pNumAutorizacionRequest.CodEspecialidad;
            }

            return xCasoTiempoEsperaRequest;
        }

        public ProcedimientosEspecialesRequest fnConsultaProcedimientosEspecialesRequest(NumeroAutorizacionRequest pNumAutorizacionRequest, Coberturas_AsegCode pCoberturas)
        {
            ProcedimientosEspecialesRequest xProcedimientosEspecialesRequest = new ProcedimientosEspecialesRequest(xSunasa, xIAFAS, xRuc);
            // Dim xProcedimientosEspecialesRequest As New ProcedimientosEspecialesRequest(xSunasa, xIAFAS, xRuc)

            {
                var withBlock = xProcedimientosEspecialesRequest;
                withBlock.NombresAfiliado = pNumAutorizacionRequest.NombresAfiliado;
                withBlock.ApellidoPaternoAfiliado = pNumAutorizacionRequest.ApellidoPaternoAfiliado;
                withBlock.ApellidoMaternoAfiliado = pNumAutorizacionRequest.ApellidoMaternoAfiliado;
                withBlock.CodigoAfiliado = pNumAutorizacionRequest.CodigoAfiliado;
                withBlock.CodTipoDocumentoAfiliado = pNumAutorizacionRequest.CodTipoDocumentoAfiliado;
                withBlock.NumeroDocumentoAfiliado = pNumAutorizacionRequest.NumeroDocumentoAfiliado;
                withBlock.CodProducto = pNumAutorizacionRequest.CodProducto;
                withBlock.DesProducto = pNumAutorizacionRequest.DesProducto;
                withBlock.NumeroPlan = pNumAutorizacionRequest.NumeroPlan;
                withBlock.CodTipoDocumentoContratante = pNumAutorizacionRequest.CodTipoDocumentoContratante;
                withBlock.NumeroDocumentoContratante = pNumAutorizacionRequest.NumeroDocumentoContratante;
                withBlock.NombreContratante = pNumAutorizacionRequest.NombreContratante;
                withBlock.CodParentesco = pNumAutorizacionRequest.CodParentesco;
                withBlock.NumeroCobertura = pCoberturas.NumeroCobertura;
                withBlock.BeneficioMaximoInicial = pNumAutorizacionRequest.BeneficioMaximoInicial;
                withBlock.CodigoTipoCobertura = pNumAutorizacionRequest.CodTipoCobertura;
                withBlock.CodigoSubTipoCobertura = pNumAutorizacionRequest.CodSubTipoCobertura;
                withBlock.CodEspecialidad = pNumAutorizacionRequest.CodEspecialidad;
            }

            return xProcedimientosEspecialesRequest;
        }

        public CasoExcepcionCarenciaRequest fnCasoExcepcionCarenciaRequest(NumeroAutorizacionRequest pNumAutorizacionRequest, Coberturas_AsegCode pCoberturas)
        {
            CasoExcepcionCarenciaRequest xCasoExcepcionCarenciaRequest = new CasoExcepcionCarenciaRequest(xSunasa, xIAFAS, xRuc);
            {
                var withBlock = xCasoExcepcionCarenciaRequest;
                withBlock.NombresAfiliado = pNumAutorizacionRequest.NombresAfiliado;
                withBlock.ApellidoPaternoAfiliado = pNumAutorizacionRequest.ApellidoPaternoAfiliado;
                withBlock.ApellidoMaternoAfiliado = pNumAutorizacionRequest.ApellidoMaternoAfiliado;
                withBlock.CodigoAfiliado = pNumAutorizacionRequest.CodigoAfiliado;
                withBlock.CodTipoDocumentoAfiliado = pNumAutorizacionRequest.CodTipoDocumentoAfiliado;
                withBlock.NumeroDocumentoAfiliado = pNumAutorizacionRequest.NumeroDocumentoAfiliado;
                withBlock.CodProducto = pNumAutorizacionRequest.CodProducto;
                withBlock.DesProducto = pNumAutorizacionRequest.DesProducto;
                withBlock.NumeroPlan = pNumAutorizacionRequest.NumeroPlan;
                withBlock.CodTipoDocumentoContratante = pNumAutorizacionRequest.CodTipoDocumentoContratante;
                withBlock.NumeroDocumentoContratante = pNumAutorizacionRequest.NumeroDocumentoContratante;
                withBlock.NombreContratante = pNumAutorizacionRequest.NombreContratante;
                withBlock.CodParentesco = pNumAutorizacionRequest.CodParentesco;
                withBlock.NumeroCobertura = pCoberturas.NumeroCobertura;
                withBlock.BeneficioMaximoInicial = pNumAutorizacionRequest.BeneficioMaximoInicial;
                withBlock.CodigoTipoCobertura = pNumAutorizacionRequest.CodTipoCobertura;
                withBlock.CodigoSubTipoCobertura = pNumAutorizacionRequest.CodSubTipoCobertura;
                withBlock.CodEspecialidad = pNumAutorizacionRequest.CodEspecialidad;
            }

            return xCasoExcepcionCarenciaRequest;
        }
    }
}