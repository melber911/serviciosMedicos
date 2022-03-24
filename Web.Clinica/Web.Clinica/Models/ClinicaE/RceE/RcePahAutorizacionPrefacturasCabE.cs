using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahAutorizacionPrefacturasCabE
    {
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

        public RcePahAutorizacionPrefacturasDetE oAutorizacionPreDetE { get; set; } = new RcePahAutorizacionPrefacturasDetE();



        public RcePahAutorizacionPrefacturasCabE()
        {
        }

        public RcePahAutorizacionPrefacturasCabE(int pIdeAutorizacionPrefacturasCab, string pCodAtencion)
        {
            IdeAutorizacionPrefacturasCab = pIdeAutorizacionPrefacturasCab;
            CodAtencion = pCodAtencion;
        }

        public RcePahAutorizacionPrefacturasCabE(int pIdeAutorizacionPrefacturasCab, string pCodAtencion, int pOrden)
        {
            IdeAutorizacionPrefacturasCab = pIdeAutorizacionPrefacturasCab;
            CodAtencion = pCodAtencion;
            Orden = pOrden;
        }
    }
}
