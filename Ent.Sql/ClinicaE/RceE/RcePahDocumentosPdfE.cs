using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahDocumentosPdfE
    {
        private int _IdeDocumentosPdf = 0;
        public int IdeDocumentosPdf
        {
            get
            {
                return _IdeDocumentosPdf;
            }
            set
            {
                _IdeDocumentosPdf = value;
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

        private string _CodTipoDocumento = "";
        public string CodTipoDocumento
        {
            get
            {
                return _CodTipoDocumento;
            }
            set
            {
                _CodTipoDocumento = value;
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



        public RcePahDocumentosPdfE()
        {
        }

        public RcePahDocumentosPdfE(int pIdeDocumentosPdf, string pCodAtencion, int pIdePreAdmision, string pCodTipoDocumento, byte[] pBlbDocumento)
        {
            IdeDocumentosPdf = pIdeDocumentosPdf;
            CodAtencion = pCodAtencion;
            IdePreAdmision = pIdePreAdmision;
            CodTipoDocumento = pCodTipoDocumento;
            BlbDocumento = pBlbDocumento;
        }

        public RcePahDocumentosPdfE(int pIdeDocumentosPdf, string pCodAtencion, int pIdePreAdmision, string pCodTipoDocumento, byte[] pBlbDocumento, int pOrden)
        {
            IdeDocumentosPdf = pIdeDocumentosPdf;
            CodAtencion = pCodAtencion;
            IdePreAdmision = pIdePreAdmision;
            CodTipoDocumento = pCodTipoDocumento;
            BlbDocumento = pBlbDocumento;
            Orden = pOrden;
        }
    }
}