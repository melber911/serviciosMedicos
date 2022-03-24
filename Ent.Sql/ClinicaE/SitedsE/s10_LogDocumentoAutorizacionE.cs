using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.SitedsE
{
    public class s10_LogDocumentoAutorizacionE
    {
        private int _IdeDocAutorizacion = 0;
        public int IdeDocAutorizacion
        {
            get
            {
                return _IdeDocAutorizacion;
            }
            set
            {
                _IdeDocAutorizacion = value;
            }
        }

        private int _IdeDatosPagos = 0;
        public int IdeDatosPagos
        {
            get
            {
                return _IdeDatosPagos;
            }
            set
            {
                _IdeDatosPagos = value;
            }
        }

        private string _NumAutorizacionSiteds = "";
        public string NumAutorizacionSiteds
        {
            get
            {
                return _NumAutorizacionSiteds;
            }
            set
            {
                _NumAutorizacionSiteds = value;
            }
        }

        private byte[] _BlbDocumento = { };
        public byte[] BlbDocumento
        {
            get
            {
                return _BlbDocumento;
            }
            set
            {
                _BlbDocumento = value;
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

        public s10_LogDocumentoAutorizacionE() { }

        public s10_LogDocumentoAutorizacionE(int pIdeDatosPagos, string pNumAutorizacionSiteds, byte[] pBlbDocumento)
        {
            IdeDatosPagos = pIdeDatosPagos;
            NumAutorizacionSiteds = pNumAutorizacionSiteds;
            BlbDocumento = pBlbDocumento;
        }
    }
}
