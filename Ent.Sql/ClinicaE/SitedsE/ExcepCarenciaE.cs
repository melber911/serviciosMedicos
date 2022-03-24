using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.SitedsE
{
    public class ExcepCarenciaE
    {
        private string _codllaveExpCar = "";
        public string codllaveExpCar
        {
            get
            {
                return _codllaveExpCar;
            }
            set
            {
                _codllaveExpCar = value;
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

        private string _cDxExcepCaren = "";
        public string cDxExcepCaren
        {
            get
            {
                return _cDxExcepCaren;
            }
            set
            {
                _cDxExcepCaren = value;
            }
        }

        private string _nDxExcepCaren = "";
        public string nDxExcepCaren
        {
            get
            {
                return _nDxExcepCaren;
            }
            set
            {
                _nDxExcepCaren = value;
            }
        }

        private string _dObsExcepCaren = "";
        public string dObsExcepCaren
        {
            get
            {
                return _dObsExcepCaren;
            }
            set
            {
                _dObsExcepCaren = value;
            }
        }



        public ExcepCarenciaE()
        {
        }

        /// <summary>
        ///         ''' Cargar los datos para el store Sp_Comprobante_Insert
        ///         ''' </summary>
        ///         ''' <param name="pcIafasCode">B-Boleta, F-Factura</param>
        ///         ''' <param name="pcAsegCode">Código de Liquidación</param>
        ///         ''' <param name="pcAutoCode">Monto del Comprobante</param>
        ///         ''' <param name="pcCoberCode">Descripción del Nombre a quien corresponde</param>
        ///         ''' <param name="pcSubtipoCober">Ruc en caso se requiera</param>
        ///         ''' <param name="pcItem">Dirección a quien se le facura el comprobante</param>
        ///         ''' <param name="pcDxExcepCaren">E-Efectivo, C-Cheque, T-Tarjeta de Credito</param>
        ///         ''' <param name="pnDxExcepCaren">Código de la entidad:BANCOS - CREDICARDS</param>
        ///         ''' <param name="pdObsExcepCaren">Número del Cheque o Tarjeta</param>
        ///         ''' <param name="pcodllaveExpCar">Número del Cheque o Tarjeta</param>


        public ExcepCarenciaE(string pcIafasCode, string pcAsegCode, string pcAutoCode, string pcCoberCode, string pcSubtipoCober, string pcItem, string pcDxExcepCaren, string pnDxExcepCaren, string pdObsExcepCaren, string pcodllaveExpCar)
        {
            cIafasCode = pcIafasCode;
            cAsegCode = pcAsegCode;
            cAutoCode = pcAutoCode;
            cCoberCode = pcCoberCode;
            cSubtipoCober = pcSubtipoCober;
            cItem = pcItem;
            cDxExcepCaren = pcDxExcepCaren;
            nDxExcepCaren = pnDxExcepCaren;
            dObsExcepCaren = pdObsExcepCaren;
            codllaveExpCar = pcodllaveExpCar;
        }
    }
}