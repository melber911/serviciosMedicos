using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahMedicacionDetE
    {
        private int _IdeMedicacionDet = 0;
        public int IdeMedicacionDet
        {
            get
            {
                return _IdeMedicacionDet;
            }
            set
            {
                _IdeMedicacionDet = value;
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

        private int _IdeMedicacionItemsMae = 0;
        public int IdeMedicacionItemsMae
        {
            get
            {
                return _IdeMedicacionItemsMae;
            }
            set
            {
                _IdeMedicacionItemsMae = value;
            }
        }

        private string _FlgRespuesta = "";
        public string FlgRespuesta
        {
            get
            {
                return _FlgRespuesta;
            }
            set
            {
                _FlgRespuesta = value;
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

        public string DscItem { get; set; } = "";
        public string DscSubItem { get; set; } = "";



        public RcePahMedicacionDetE() { }

        public RcePahMedicacionDetE(int pIdeMedidacionDet)
        {
            IdeMedicacionDet = pIdeMedidacionDet;
        }

        public RcePahMedicacionDetE(int pIdeMedidacionDet, int pIdeMedicacionCab, int pOrden)
        {
            IdeMedicacionDet = pIdeMedidacionDet;
            IdeMedicacionCab = pIdeMedicacionCab;
            Orden = pOrden;
        }

        public RcePahMedicacionDetE(int pIdeMedidacionDet, int pIdeMedicacionCab, int pIdeMedicacionItemsMae, string pFlgRespuesta)
        {
            IdeMedicacionDet = pIdeMedidacionDet;
            IdeMedicacionCab = pIdeMedicacionCab;
            IdeMedicacionItemsMae = pIdeMedicacionItemsMae;
            FlgRespuesta = pFlgRespuesta;
        }
    }
}
