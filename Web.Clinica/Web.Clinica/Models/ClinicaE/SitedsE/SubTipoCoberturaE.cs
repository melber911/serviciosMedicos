using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.SitedsE
{
    public class SubTipoCoberturaE
    {
        private string _codllaveSubTipCober = "";
        public string codllaveSubTipCober
        {
            get
            {
                return _codllaveSubTipCober;
            }
            set
            {
                _codllaveSubTipCober = value;
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

        private string _cSubTipoCober = "";
        public string cSubTipoCober
        {
            get
            {
                return _cSubTipoCober;
            }
            set
            {
                _cSubTipoCober = value;
            }
        }

        private string _nSubTipoCoberName = "";
        public string nSubTipoCoberName
        {
            get
            {
                return _nSubTipoCoberName;
            }
            set
            {
                _nSubTipoCoberName = value;
            }
        }

        private string _cSitedsCode = "";
        public string cSitedsCode
        {
            get
            {
                return _cSitedsCode;
            }
            set
            {
                _cSitedsCode = value;
            }
        }

        private string _cSitedsCode2 = "";
        public string cSitedsCode2
        {
            get
            {
                return _cSitedsCode2;
            }
            set
            {
                _cSitedsCode2 = value;
            }
        }

        private string _dEstado = "";
        public string dEstado
        {
            get
            {
                return _dEstado;
            }
            set
            {
                _dEstado = value;
            }
        }



        public SubTipoCoberturaE()
        {
        }

        /// <summary>
        ///         ''' Cargar los datos para el store Sp_Comprobante_Insert
        ///         ''' </summary>
        ///         ''' <param name="pcCoberCode">B-Boleta, F-Factura</param>
        ///         ''' <param name="pcSubTipoCober">Código de Liquidación</param>
        ///         ''' <param name="pnSubTipoCoberName">Monto del Comprobante</param>
        ///         ''' <param name="pcSitedsCode">Descripción del Nombre a quien corresponde</param>
        ///         ''' <param name="pcSitedsCode2">Ruc en caso se requiera</param>
        ///         ''' <param name="pdEstado"></param>
        ///         ''' <param name="pcodllaveSubTipCober"></param>


        public SubTipoCoberturaE(string pcCoberCode, string pcSubTipoCober, string pnSubTipoCoberName, string pcSitedsCode, string pcSitedsCode2, string pdEstado, string pcodllaveSubTipCober)
        {
            cCoberCode = pcCoberCode;
            cSubTipoCober = pcSubTipoCober;
            nSubTipoCoberName = pnSubTipoCoberName;
            cSitedsCode = pcSitedsCode;
            cSitedsCode2 = pcSitedsCode2;
            dEstado = pdEstado;
            codllaveSubTipCober = pcodllaveSubTipCober;
        }
    }
}