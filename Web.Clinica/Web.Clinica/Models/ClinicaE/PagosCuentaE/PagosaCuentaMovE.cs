using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.PagosCuentaE
{
    public class PagosaCuentaMovE
    {
        private int _IdePagosacuenta = 0;
        public int IdePagosacuenta
        {
            get
            {
                return _IdePagosacuenta;
            }
            set
            {
                _IdePagosacuenta = value;
            }
        }

        private string _CodTipopago = "";
        public string CodTipopago
        {
            get
            {
                return _CodTipopago;
            }
            set
            {
                _CodTipopago = value;
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

        private string _CodPresotor = "";
        public string CodPresotor
        {
            get
            {
                return _CodPresotor;
            }
            set
            {
                _CodPresotor = value;
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



        public PagosaCuentaMovE()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCodTipopago">'01 - POR COASEGURO, 02 - POR DEDUCIBLE, 03 - POR COPAGO, 04 - POR GASTO NO CUBIERTO</param>
        /// <param name="pMonto">Monto a Pagar</param>
        /// <param name="pCodPresotor">Prestoro</param>
        public PagosaCuentaMovE(string pCodTipopago, double pMonto, string pCodPresotor)
        {
            CodTipopago = pCodTipopago;
            Monto = pMonto;
            CodPresotor = pCodPresotor;
        }
    }
}
