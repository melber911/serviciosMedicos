using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahDocumentoAdmisionCabE
    {
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

        private string _DscTextoDocumento = "";
        public string DscTextoDocumento
        {
            get
            {
                return _DscTextoDocumento;
            }
            set
            {
                _DscTextoDocumento = value;
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

        public string DscRpta { get; set; } = "";

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



        public RcePahDocumentoAdmisionCabE()
        {
        }

        public RcePahDocumentoAdmisionCabE(int pIdeDocumentoAdmisionCab, string pCodAtencion, string pDscTextoDocumento, string pDscRpta, string pDscResponsableEnvio, string pFlgEstado)
        {
            IdeDocumentoAdmisionCab = pIdeDocumentoAdmisionCab;
            CodAtencion = pCodAtencion;
            DscTextoDocumento = pDscTextoDocumento;
            DscRespEnvio = pDscResponsableEnvio;
            FlgEstado = pFlgEstado;
            DscRpta = pDscRpta;
        }
    }
}
