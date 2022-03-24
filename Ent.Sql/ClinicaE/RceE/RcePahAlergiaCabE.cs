using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahAlergiaCabE
    {
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

        public string IndAlergia { get; set; } = "";

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

        private string _DscHospital = "";
        public string DscHospitalizado
        {
            get
            {
                return _DscHospital;
            }
            set
            {
                _DscHospital = value;
            }
        }

        private string _DscRepresentante = "";
        public string DscRepresentante
        {
            get
            {
                return _DscRepresentante;
            }
            set
            {
                _DscRepresentante = value;
            }
        }

        private string _DscHabitacion = "";
        public string DscHabitacion
        {
            get
            {
                return _DscHabitacion;
            }
            set
            {
                _DscHabitacion = value;
            }
        }

        private string _DscAlimentos = "";
        public string DscAlimentos
        {
            get
            {
                return _DscAlimentos;
            }
            set
            {
                _DscAlimentos = value;
            }
        }

        private string _DscOtros = "";
        public string DscOtros
        {
            get
            {
                return _DscOtros;
            }
            set
            {
                _DscOtros = value;
            }
        }

        private string _DscRespEnvio = "";
        public string DscRespEnvio
        {
            get
            {
                return _DscRespEnvio;
            }
            set
            {
                _DscRespEnvio = value;
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

        public int IdePreAdmision { get; set; } = 0;
        public int IdeMedicacionCab { get; set; } = 0;
        public string Accion { get; set; } = "";




        public RcePahAlergiaCabE()
        {
        }

        public RcePahAlergiaCabE(int pIdeAlergiaCab)
        {
            IdeAlergiaCab = pIdeAlergiaCab;
        }

        public RcePahAlergiaCabE(int pIdeAlergiaCab, string pCodAtencion, int pOrden)
        {
            IdeAlergiaCab = pIdeAlergiaCab;
            CodAtencion = pCodAtencion;
            Orden = pOrden;
        }

        public RcePahAlergiaCabE(int pIdeAlergiaCab, int pIdePreAdmision, string pIndAlergia, string pDscHospitalizado, string pDscRepresentante, string pDscHabitacion, string pDscAlimentos, string pDscOtros, string pDscRespEnvio, string pFlgEstado, string pAccion)
        {
            IndAlergia = pIndAlergia;
            IdeAlergiaCab = pIdeAlergiaCab;
            IdePreAdmision = pIdePreAdmision;
            DscHospitalizado = pDscHospitalizado;
            DscRepresentante = pDscRepresentante;
            DscHabitacion = pDscHabitacion;
            DscAlimentos = pDscAlimentos;
            DscOtros = pDscOtros;
            DscRespEnvio = pDscRespEnvio;
            FlgEstado = pFlgEstado;
            Accion = pAccion;
        }
    }
}
