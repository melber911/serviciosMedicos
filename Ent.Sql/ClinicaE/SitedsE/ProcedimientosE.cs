using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.SitedsE
{
    public class ProcedimientosE
    {
        private string _codllaveProc = "";
        public string codllaveProc
        {
            get
            {
                return _codllaveProc;
            }
            set
            {
                _codllaveProc = value;
            }
        }

        private string _cIafasCode = "";
        public string cIafasCode
        {
            get
            {
                return _cIafasCode;
            }
            set
            {
                _cIafasCode = value;
            }
        }

        private string _cAutoCode = "";
        public string cAutoCode
        {
            get
            {
                return _cAutoCode;
            }
            set
            {
                _cAutoCode = value;
            }
        }

        private string _cAsegCode = "";
        public string cAsegCode
        {
            get
            {
                return _cAsegCode;
            }
            set
            {
                _cAsegCode = value;
            }
        }

        private string _cCoberCode = "";
        public string cCoberCode
        {
            get
            {
                return _cCoberCode;
            }
            set
            {
                _cCoberCode = value;
            }
        }

        private string _cSubtipoCober = "";
        public string cSubtipoCober
        {
            get
            {
                return _cSubtipoCober;
            }
            set
            {
                _cSubtipoCober = value;
            }
        }

        private string _cItem = "";
        public string cItem
        {
            get
            {
                return _cItem;
            }
            set
            {
                _cItem = value;
            }
        }

        private string _cTipoProcInt = "";
        public string cTipoProcInt
        {
            get
            {
                return _cTipoProcInt;
            }
            set
            {
                _cTipoProcInt = value;
            }
        }

        private string _nTipoProcName = "";
        public string nTipoProcName
        {
            get
            {
                return _nTipoProcName;
            }
            set
            {
                _nTipoProcName = value;
            }
        }

        private string _cGeCode = "";
        public string cGeCode
        {
            get
            {
                return _cGeCode;
            }
            set
            {
                _cGeCode = value;
            }
        }

        private double _nCopgFijo = 0;
        public double nCopgFijo
        {
            get
            {
                return _nCopgFijo;
            }
            set
            {
                _nCopgFijo = value;
            }
        }


        private double _nCopgVari = 0;
        public double nCopgVari
        {
            get
            {
                return _nCopgVari;
            }
            set
            {
                _nCopgVari = value;
            }
        }

        private int _nFrecNumb = 0;
        public int nFrecNumb
        {
            get
            {
                return _nFrecNumb;
            }
            set
            {
                _nFrecNumb = value;
            }
        }

        private int _nDiasCant = 0;
        public int nDiasCant
        {
            get
            {
                return _nDiasCant;
            }
            set
            {
                _nDiasCant = value;
            }
        }

        private string _dObserProc = "";
        public string dObserProc
        {
            get
            {
                return _dObserProc;
            }
            set
            {
                _dObserProc = value;
            }
        }

        public ProcedimientosE() { }

        /// <summary>
        ///         ''' Cargar los datos para el store Sp_Comprobante_Insert
        ///         ''' </summary>
        ///         ''' <param name="pcIafasCode">B-Boleta, F-Factura</param>
        ///         ''' <param name="pcAsegCode">Código de Liquidación</param>
        ///         ''' <param name="pcAutoCode">Monto del Comprobante</param>
        ///         ''' <param name="pcCoberCode">Descripción del Nombre a quien corresponde</param>
        ///         ''' <param name="pcSubtipoCober">Ruc en caso se requiera</param>
        ///         ''' <param name="pcItem">Dirección a quien se le facura el comprobante</param>
        ///         ''' <param name="pcTipoProcInt">E-Efectivo, C-Cheque, T-Tarjeta de Credito</param>
        ///         ''' <param name="pnTipoProcName">Código de la entidad:BANCOS - CREDICARDS</param>
        ///         ''' <param name="pcGeCode">Número del Cheque o Tarjeta</param>
        ///         ''' <param name="pnCopgFijo">G-Genera, P-Paga, T-Todo</param>
        ///         ''' <param name="pnCopgVari">S-Si Varios en la 2da llamada, N-No varios</param>
        ///         ''' <param name="pnFrecNumb">Codigo del comprobante</param>
        ///         ''' <param name="pnDiasCant">S-Si Varios en la 2da llamada, N-No varios</param>
        ///         ''' <param name="pdObserProc"></param>
        ///         ''' <param name="pcodllaveProc"></param>
        public ProcedimientosE(string pcIafasCode, string pcAsegCode, string pcAutoCode, string pcCoberCode, string pcSubtipoCober, string pcItem, string pcTipoProcInt, string pnTipoProcName, string pcGeCode, double pnCopgFijo, double pnCopgVari, int pnFrecNumb, int pnDiasCant, string pdObserProc, string pcodllaveProc)
        {
            cIafasCode = pcIafasCode;
            cAsegCode = pcAsegCode;
            cAutoCode = pcAutoCode;
            cCoberCode = pcCoberCode;
            cSubtipoCober = pcSubtipoCober;
            cItem = pcItem;
            cTipoProcInt = pcTipoProcInt;
            nTipoProcName = pnTipoProcName;
            cGeCode = pcGeCode;
            nCopgFijo = pnCopgFijo;
            nCopgVari = pnCopgVari;
            nFrecNumb = pnFrecNumb;
            nDiasCant = pnDiasCant;
            dObserProc = pdObserProc;
            codllaveProc = pcodllaveProc;
        }
    }
}
