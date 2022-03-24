using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.OtrosE
{
    public class CoberturaPolizaE
    {
        private int _Idcobertura = 0;
        public int Idcobertura
        {
            get
            {
                return _Idcobertura;
            }
            set
            {
                _Idcobertura = value;
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

        private string _TipoCobertura = "";
        public string TipoCobertura
        {
            get
            {
                return _TipoCobertura;
            }
            set
            {
                _TipoCobertura = value;
            }
        }

        private string _Nombre = "";
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        private string _Tipomonto = "";
        public string Tipomonto
        {
            get
            {
                return _Tipomonto;
            }
            set
            {
                _Tipomonto = value;
            }
        }

        private double _Monto = 0;
        public double Monto
        {
            get
            {
                return _Monto;
            }
            set
            {
                _Monto = value;
            }
        }

        private string _Moneda = "";
        public string Moneda
        {
            get
            {
                return _Moneda;
            }
            set
            {
                _Moneda = value;
            }
        }

        private string _Igv = "";
        public string Igv
        {
            get
            {
                return _Igv;
            }
            set
            {
                _Igv = value;
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

        private string _Estado = "";
        public string Estado
        {
            get
            {
                return _Estado;
            }
            set
            {
                _Estado = value;
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

        private string _Codbeneficio = "";
        public string Codbeneficio
        {
            get
            {
                return _Codbeneficio;
            }
            set
            {
                _Codbeneficio = value;
            }
        }

        private string _Csubtipocobertura = "";
        public string Csubtipocobertura
        {
            get
            {
                return _Csubtipocobertura;
            }
            set
            {
                _Csubtipocobertura = value;
            }
        }

        private string _Csitedsvs = "";
        public string Csitedsvs
        {
            get
            {
                return _Csitedsvs;
            }
            set
            {
                _Csitedsvs = value;
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



        public CoberturaPolizaE()
        {
        }

        public CoberturaPolizaE(string pCodAtencion)
        {
            CodAtencion = pCodAtencion;
        }

        public CoberturaPolizaE(string pCodAtencion, string pTipoCobertura)
        {
            CodAtencion = pCodAtencion;
            TipoCobertura = pTipoCobertura;
        }

        public CoberturaPolizaE(string pCodAtencion, string pTipoCobertura, string pCampo, string pNuevoValor)
        {
            CodAtencion = pCodAtencion;
            TipoCobertura = pTipoCobertura;
            Campo = pCampo;
            NuevoValor = pNuevoValor;
        }
    }
}
