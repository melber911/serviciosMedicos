using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahMedicacionItemsMaeE
    {
        public int IdeMedicacionItemsMae = 0;

        private string _DscItem = "";
        public string DscItem
        {
            get
            {
                return _DscItem;
            }
            set
            {
                _DscItem = value;
            }
        }

        private string _DscSubItem = "";
        public string DscSubItem
        {
            get
            {
                return _DscSubItem;
            }
            set
            {
                _DscSubItem = value;
            }
        }

        private string _CodTipo = "";
        public string CodTipo
        {
            get
            {
                return _CodTipo;
            }
            set
            {
                _CodTipo = value;
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

        public RcePahMedicacionItemsMaeE() { }

        public RcePahMedicacionItemsMaeE(int pOrden)
        { Orden = pOrden; }
    }
}