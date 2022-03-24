using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahAlergiaMedicamentosDetE
    {
        private int _IdeAlergiaMedicamentosDet = 0;
        public int IdeAlergiaMedicamentosDet
        {
            get
            {
                return _IdeAlergiaMedicamentosDet;
            }
            set
            {
                _IdeAlergiaMedicamentosDet = value;
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

        private string _CodGenerico = "";
        public string CodGenerico
        {
            get
            {
                return _CodGenerico;
            }
            set
            {
                _CodGenerico = value;
            }
        }

        private string _DscMedicamento = "";
        public string DscMedicamento
        {
            get
            {
                return _DscMedicamento;
            }
            set
            {
                _DscMedicamento = value;
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

        public RcePahAlergiaMedicamentosDetE()
        {
        }

        public RcePahAlergiaMedicamentosDetE(int pIdeAlergiaCab, string pCodGenerico, string pDscMedicamento)
        {
            IdeAlergiaCab = pIdeAlergiaCab;
            CodGenerico = pCodGenerico;
            DscMedicamento = pDscMedicamento;
        }

        public RcePahAlergiaMedicamentosDetE(int pIdeAlergiaCab, string pCodGenerico, string pDscMedicamento, int pIdeAlergiaMedicamentosDet, int pOrden)
        {
            IdeAlergiaCab = pIdeAlergiaCab;
            CodGenerico = pCodGenerico;
            DscMedicamento = pDscMedicamento;
            IdeAlergiaMedicamentosDet = pIdeAlergiaMedicamentosDet;
            Orden = pOrden;
        }
    }
}
