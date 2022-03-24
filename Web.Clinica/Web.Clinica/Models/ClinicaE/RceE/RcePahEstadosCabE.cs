using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahEstadosCabE
    {
        private int _IdePreAdmision = 0;
        public int IdePreAdmision
        {
            get
            {
                return _IdePreAdmision;
            }
            set
            {
                _IdePreAdmision = value;
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

        private int _NumSecuencia = 0;
        public int NumSecuencia
        {
            get
            {
                return _NumSecuencia;
            }
            set
            {
                _NumSecuencia = value;
            }
        }

        private string _EstSecuencia = "";
        public string EstSecuencia
        {
            get
            {
                return _EstSecuencia;
            }
            set
            {
                _EstSecuencia = value;
            }
        }

        private int _IdeAlergiaCab = 0;
        public int IdeAlergiaCab
        {
            get
            {
                return _IdeAlergiaCab;
            }
            set
            {
                _IdeAlergiaCab = value;
            }
        }

        private int _IdeMedicacionCab = 0;
        public int IdeMedicacionCab
        {
            get
            {
                return _IdeMedicacionCab;
            }
            set
            {
                _IdeMedicacionCab = value;
            }
        }

        private DateTime _FecAlergiaMedicacion = DateTime.Now;
        public DateTime FecAlergiaMedicacion
        {
            get
            {
                return _FecAlergiaMedicacion;
            }
            set
            {
                _FecAlergiaMedicacion = value;
            }
        }

        private int _IdeDocumentoAdmisionCab = 0;
        public int IdeDocumentoAdmisionCab
        {
            get
            {
                return _IdeDocumentoAdmisionCab;
            }
            set
            {
                _IdeDocumentoAdmisionCab = value;
            }
        }

        private DateTime _FecDocumentoAdmision = DateTime.Now;
        public DateTime FecDocumentoAdmision
        {
            get
            {
                return _FecDocumentoAdmision;
            }
            set
            {
                _FecDocumentoAdmision = value;
            }
        }

        private int _IdeAutorizacionPrefacturasCab = 0;
        public int IdeAutorizacionPrefacturasCab
        {
            get
            {
                return _IdeAutorizacionPrefacturasCab;
            }
            set
            {
                _IdeAutorizacionPrefacturasCab = value;
            }
        }

        private DateTime _FecAutorizacionPrefacturas = DateTime.Now;
        public DateTime FecAutorizacionPrefacturas
        {
            get
            {
                return _FecAutorizacionPrefacturas;
            }
            set
            {
                _FecAutorizacionPrefacturas = value;
            }
        }

        private string _FlgEstado = "";
        public string FlgEstado
        {
            get
            {
                return _FlgEstado;
            }
            set
            {
                _FlgEstado = value;
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

        public string CodAtencionNueva { get; set; } = "";

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

        public string DocIdentidad { get; set; } = "";
        public string DscPacientes { get; set; } = "";
        public string FecInicio { get; set; } = "";
        public string FecFin { get; set; } = "";

        public string FecEnvio { get; set; } = "";
        public string UsrEnvio { get; set; } = "";
        public string Accion { get; set; } = "";
        public string DscSecuencia { get; set; } = "";
        public int IdeCorreoEnviado { get; set; }

        public string EstEnvioCorreo { get; set; } = "";
        public string CodEnvioCorreo { get; set; } = "";
        public string FecEnvioCorreo { get; set; } = "";

        public string FechaCirugia { get; set; } = "";


        public RcePahEstadosCabE() { }

        public RcePahEstadosCabE(int pIdePreAdmisionCab)
        {
            IdePreAdmision = pIdePreAdmisionCab;
        }

        public RcePahEstadosCabE(int pIdePreAdmisionCab, string pCodPaciente, string pCodAtencion, string pAccion)
        {
            IdePreAdmision = pIdePreAdmisionCab;
            CodPaciente = pCodPaciente;
            CodAtencion = pCodAtencion;
            Accion = pAccion;
        }

        public RcePahEstadosCabE(int pIdePreAdmisionCab, string pCodPaciente, string pCodAtencion, string pNuevoValor, string pCampo)
        {
            IdePreAdmision = pIdePreAdmisionCab;
            CodPaciente = pCodPaciente;
            CodAtencion = pCodAtencion;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public RcePahEstadosCabE(int pIdePreAdmision, string pCodPaciente, string pCodAtencion, string pNuevoValor, string pCampo, string pDocIdentidad, string pDscPacientes, string pFecInicio, string pFecFin, int pOrden)
        {
            IdePreAdmision = pIdePreAdmision;
            CodPaciente = pCodPaciente;
            CodAtencion = pCodAtencion;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
            DocIdentidad = pDocIdentidad;
            DscPacientes = pDscPacientes;
            FecInicio = pFecInicio;
            FecFin = pFecFin;
            Orden = pOrden;
        }
    }
}
