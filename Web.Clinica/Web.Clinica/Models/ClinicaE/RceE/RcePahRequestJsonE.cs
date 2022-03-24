using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahRequestJsonE
    {
        private int _IdePahRequestJson = 0;
        public int IdePahRequestJson
        {
            get
            {
                return _IdePahRequestJson;
            }
            set
            {
                _IdePahRequestJson = value;
            }
        }

        private int _IdePahEstadosCab = 0;
        public int IdePahEstadosCab
        {
            get
            {
                return _IdePahEstadosCab;
            }
            set
            {
                _IdePahEstadosCab = value;
            }
        }

        private string _CodMetodo = "";
        public string CodMetodo
        {
            get
            {
                return _CodMetodo;
            }
            set
            {
                _CodMetodo = value;
            }
        }

        private string _DscPlataforma = "";
        public string DscPlataforma
        {
            get
            {
                return _DscPlataforma;
            }
            set
            {
                _DscPlataforma = value;
            }
        }

        private string _DscJson = "";
        public string DscJson
        {
            get
            {
                return _DscJson;
            }
            set
            {
                _DscJson = value;
            }
        }

        private DateTime _FecJson = DateTime.Now;
        public DateTime FecJson
        {
            get
            {
                return _FecJson;
            }
            set
            {
                _FecJson = value;
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

        public RcePahRequestJsonE() { }

        public RcePahRequestJsonE(int pIdePahRequestJson, int pIdePahEstadosCab)
        {
            IdePahRequestJson = pIdePahRequestJson;
            IdePahEstadosCab = pIdePahEstadosCab;
        }

        public RcePahRequestJsonE(int pIdePahRequestJson, int pIdePahEstadosCab, string pCodMetodo, string pDscPlataforma, string pDscJson)
        {
            IdePahRequestJson = pIdePahRequestJson;
            IdePahEstadosCab = pIdePahEstadosCab;
            CodMetodo = pCodMetodo;
            DscPlataforma = pDscPlataforma;
            DscJson = pDscJson;
        }

        public RcePahRequestJsonE(int pIdePahRequestJson, int pIdePahEstadosCab, string pCodMetodo, string pDscPlataforma, string pDscJson, DateTime pFecJson)
        {
            IdePahRequestJson = pIdePahRequestJson;
            IdePahEstadosCab = pIdePahEstadosCab;
            CodMetodo = pCodMetodo;
            DscPlataforma = pDscPlataforma;
            DscJson = pDscJson;
            FecJson = pFecJson;
        }
    }
}