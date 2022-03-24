using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahAutorizacionPrefacturasDetE
    {
        private int _IdeAutorizacionPrefacturasDet = 0;
        public int IdeAutorizacionPrefacturasDet
        {
            get
            {
                return _IdeAutorizacionPrefacturasDet;
            }
            set
            {
                _IdeAutorizacionPrefacturasDet = value;
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

        private string _DscApellidos = "";
        public string DscApellidos
        {
            get
            {
                return _DscApellidos;
            }
            set
            {
                _DscApellidos = value;
            }
        }

        private string _DscNombres = "";
        public string DscNombres
        {
            get
            {
                return _DscNombres;
            }
            set
            {
                _DscNombres = value;
            }
        }

        private string _NroDni = "";
        public string NroDni
        {
            get
            {
                return _NroDni;
            }
            set
            {
                _NroDni = value;
            }
        }

        private string _DscCorreos = "";
        public string DscCorreos
        {
            get
            {
                return _DscCorreos;
            }
            set
            {
                _DscCorreos = value;
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

        public string Parentesco { get; set; } = "";
        public string Telefono { get; set; } = "";

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



        public RcePahAutorizacionPrefacturasDetE()
        {
        }

        public RcePahAutorizacionPrefacturasDetE(int pIdeAutorizacionPrefacturasDet, int pIdeAutorizacionPrefacturasCab, string pDscApellidos, string pDscNombres, string pNroDni, string pDscCorreos, string pDscRespEnvio, string pFlgEstado)
        {
            IdeAutorizacionPrefacturasDet = pIdeAutorizacionPrefacturasDet;
            IdeAutorizacionPrefacturasCab = pIdeAutorizacionPrefacturasCab;
            DscApellidos = pDscApellidos;
            DscNombres = pDscNombres;
            NroDni = pNroDni;
            DscCorreos = pDscCorreos;
            DscRespEnvio = pDscRespEnvio;
            FlgEstado = pFlgEstado;
        }

        public RcePahAutorizacionPrefacturasDetE(int pIdeAutorizacionPrefacturasDet, int pIdeAutorizacionPrefacturasCab, string pDscApellidos, string pDscNombres, string pNroDni, string pDscCorreos, string pDscRespEnvio, string pFlgEstado, string pParentesco, string pTelefono)
        {
            IdeAutorizacionPrefacturasDet = pIdeAutorizacionPrefacturasDet;
            IdeAutorizacionPrefacturasCab = pIdeAutorizacionPrefacturasCab;
            DscApellidos = pDscApellidos;
            DscNombres = pDscNombres;
            NroDni = pNroDni;
            DscCorreos = pDscCorreos;
            DscRespEnvio = pDscRespEnvio;
            FlgEstado = pFlgEstado;
            Parentesco = pParentesco;
            Telefono = pTelefono;
        }
    }
}
