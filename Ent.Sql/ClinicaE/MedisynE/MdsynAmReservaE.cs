using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedisynE
{
    public class MdsynAmReservaE
    {
        public long IdeReserva { get; set; } = 0;
        public int IdeCorrelReserva { get; set; } = 0;
        public string CodSede { get; set; } = "";
        public string CodPaciente { get; set; } = "";
        public string RutPaciente { get; set; } = "";
        public string CodMedico { get; set; } = "";
        public string CodProfMedico { get; set; } = "";
        public string CodEspecialidad { get; set; } = "";
        public DateTime FecCita { get; set; } = DateTime.Now;
        public string UsrRegistroPlataforma { get; set; } = "";
        public DateTime FecRegistro { get; set; } = DateTime.Now;
        public string EstConsultaMedica { get; set; } = "";

        public decimal CntMontopago { get; set; } = 0;
        public string CodTipoPago { get; set; } = "";

        public string FlgReservaAnulada { get; set; } = "";
        public DateTime FecReservaAnulada { get; set; } = DateTime.Now;
        public int UsrReservaAnulada { get; set; } = 0;
        public int UsrReprograma { get; set; } = 0;
        public int UsrRecepciona { get; set; } = 0;
        public string FlgReprogramar { get; set; } = "";

        // ---     EXTENSIONES    ---
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public string Orden { get; set; } = "";

        public string FecInicio { get; set; } = "";
        public string FecFin { get; set; } = "";
        public string NombresPaciente { get; set; } = "";
        public string NombresMedico { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Telefono2 { get; set; } = "";

        public string DscSede { get; set; } = "";
        public string DscEspecialidad { get; set; } = "";
        public string DscTipoConsultaMedica { get; set; } = "";

        public int IdePagosBot { get; set; } = 0;

        public string DscTipoPago { get; set; } = "";
        public string CodTipoConsultaMedica { get; set; } = "";

        // flg_update_fechas
        public string CodAtencion { get; set; } = "";
        public string FlgUpdateFechas { get; set; } = "";
        public string EstPago { get; set; } = "";

        public int IdeCorrelReservaBack { get; set; } = 0;
        public int IdeCorrelReservaNew { get; set; } = 0;
        public string CodPresotor { get; set; } = "";

        public string CodSedeBack { get; set; } = "";
        public string CodSedeNew { get; set; } = "";
        public string Email { get; set; } = "";

        public string FecAnulacion { get; set; } = "";
        public string Moneda { get; set; } = "";
        public string Monto { get; set; } = "";
        public string NroOperacion { get; set; } = "";


        public MdsynAmReservaE()
        {
        }

        public MdsynAmReservaE(long pIdeReserva)
        {
            IdeReserva = pIdeReserva;
        }

        public MdsynAmReservaE(long pIdeReserva, string pNuevoValor, string pCampo)
        {
            IdeReserva = pIdeReserva;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public MdsynAmReservaE(long pIdeReserva, string pNuevoValor, string pCampo, int pIdeCorrelReserva)
        {
            IdeReserva = pIdeReserva;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
            IdeCorrelReserva = pIdeCorrelReserva;
        }

        public MdsynAmReservaE(long pIdeReserva, string pNuevoValor, string pCampo, int pIdeCorrelReserva, string pCodAtencion)
        {
            IdeReserva = pIdeReserva;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
            IdeCorrelReserva = pIdeCorrelReserva;
            CodAtencion = pCodAtencion;
        }

        /// <summary>
        ///         ''' Sirve para el store Sp_MdsynAmReserva_Consulta
        ///         ''' </summary>
        ///         ''' <param name="pIdeReserva"></param>
        ///         ''' <param name="pIdeCorrelReserva"></param>
        ///         ''' <param name="pFecInicio"></param>
        ///         ''' <param name="pFecFin"></param>
        ///         ''' <param name="pCodSede"></param>
        ///         ''' <param name="pNombresPaciente"></param>
        ///         ''' <param name="pRutPaciente"></param>
        ///         ''' <param name="pCodPaciente"></param>
        ///         ''' <param name="pOrden"></param>
        public MdsynAmReservaE(long pIdeReserva, int pIdeCorrelReserva, string pFecInicio, string pFecFin, string pCodSede, string pNombresPaciente, string pRutPaciente, string pCodPaciente, string pOrden)
        {
            IdeReserva = pIdeReserva;
            IdeCorrelReserva = pIdeCorrelReserva;
            FecInicio = pFecInicio;
            FecFin = pFecFin;
            CodSede = pCodSede;
            NombresPaciente = pNombresPaciente;
            RutPaciente = pRutPaciente;
            CodPaciente = pCodPaciente;
            Orden = pOrden;
        }

        /// <summary>
        ///         ''' Este constructor sirve para utilizar con el Store "[Sp_MdsynAmReserva_Insert]"
        ///         ''' </summary>
        ///         ''' <param name="pIdeReserva"></param>
        ///         ''' <param name="pIdeCorrelReserva"></param>
        ///         ''' <param name="pCodSede"></param>
        ///         ''' <param name="pCodPaciente"></param>
        ///         ''' <param name="pRutPaciente"></param>
        ///         ''' <param name="pCodMedico"></param>
        ///         ''' <param name="pCodProfMedico"></param>
        ///         ''' <param name="pCodEspecialidad"></param>
        ///         ''' <param name="pFecCita"></param>
        ///         ''' <param name="pUsrRegistroPlataforma"></param>
        ///         ''' <param name="pEstConsultaMedica"></param>
        public MdsynAmReservaE(long pIdeReserva, int pIdeCorrelReserva, string pCodSede, string pCodPaciente, string pRutPaciente, string pCodMedico, string pCodProfMedico, string pCodEspecialidad, DateTime pFecCita, string pUsrRegistroPlataforma, string pEstConsultaMedica)
        {
            IdeReserva = pIdeReserva;
            IdeCorrelReserva = pIdeCorrelReserva;
            CodSede = pCodSede;
            CodPaciente = pCodPaciente;
            RutPaciente = pRutPaciente;
            CodMedico = pCodMedico;
            CodProfMedico = pCodProfMedico;
            CodEspecialidad = pCodEspecialidad;
            FecCita = pFecCita;
            UsrRegistroPlataforma = pUsrRegistroPlataforma;
            EstConsultaMedica = pEstConsultaMedica;
        }

        /// <summary>
        ///         ''' Sirve para usar en el método "[Sp_MdsynAmReserva_Update]"
        ///         ''' </summary>
        ///         ''' <param name="pIdeReserva"></param>
        ///         ''' <param name="pIdeCorrelReserva"></param>
        ///         ''' <param name="pCodSede"></param>
        ///         ''' <param name="pCodPaciente"></param>
        ///         ''' <param name="pRutPaciente"></param>
        ///         ''' <param name="pCodMedico"></param>
        ///         ''' <param name="pCodProfMedico"></param>
        ///         ''' <param name="pCodEspecialidad"></param>
        ///         ''' <param name="pFecCita"></param>
        ///         ''' <param name="pUsrRegistroPlataforma"></param>
        ///         ''' <param name="pCntMontoPago"></param>
        ///         ''' <param name="pCodTipoPago"></param>
        ///         ''' <param name="pOrden"></param>
        ///         ''' <param name="pUsrReservaAnulada"></param>
        ///         ''' <param name="pFlgReservaAnulada"></param>
        public MdsynAmReservaE(long pIdeReserva, int pIdeCorrelReserva, string pCodSede, string pCodPaciente, string pRutPaciente, string pCodMedico, string pCodProfMedico, string pCodEspecialidad, DateTime pFecCita, string pUsrRegistroPlataforma, decimal pCntMontoPago, string pCodTipoPago, string pOrden, int pUsrReservaAnulada, string pFlgReservaAnulada)
        {
            IdeReserva = pIdeReserva;
            IdeCorrelReserva = pIdeCorrelReserva;
            CodSede = pCodSede;
            CodPaciente = pCodPaciente;
            RutPaciente = pRutPaciente;
            CodMedico = pCodMedico;
            CodProfMedico = pCodProfMedico;
            CodEspecialidad = pCodEspecialidad;
            FecCita = pFecCita;
            UsrRegistroPlataforma = pUsrRegistroPlataforma;
            CntMontopago = pCntMontoPago;
            CodTipoPago = pCodTipoPago;
            Orden = pOrden;
            UsrReservaAnulada = pUsrReservaAnulada;
            FlgReservaAnulada = pFlgReservaAnulada;
        }
    }
}
