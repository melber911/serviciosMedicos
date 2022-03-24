using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.SitedsE
{
    public class ProductoE
    {
        private string _codllaveProd = "";
        public string codllaveProd
        {
            get
            {
                return _codllaveProd;
            }
            set
            {
                _codllaveProd = value;
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

        private string _cProdCode = "";
        public string cProdCode
        {
            get
            {
                return _cProdCode;
            }
            set
            {
                _cProdCode = value;
            }
        }

        private string _nProdName = "";
        public string nProdName
        {
            get
            {
                return _nProdName;
            }
            set
            {
                _nProdName = value;
            }
        }

        private string _dTipoProducto = "";
        public string dTipoProducto
        {
            get
            {
                return _dTipoProducto;
            }
            set
            {
                _dTipoProducto = value;
            }
        }

        private string _cIafaCodeCia = "";
        public string cIafaCodeCia
        {
            get
            {
                return _cIafaCodeCia;
            }
            set
            {
                _cIafaCodeCia = value;
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



        public ProductoE()
        {
        }

        /// <summary>
        ///         ''' Cargar los datos para el store Sp_Comprobante_Insert
        ///         ''' </summary>
        ///         ''' <param name="pcIafasCode">B-Boleta, F-Factura</param>
        ///         ''' <param name="pcProdCode">Código de Liquidación</param>
        ///         ''' <param name="pnProdName">Monto del Comprobante</param>
        ///         ''' <param name="pdTipoProducto">Descripción del Nombre a quien corresponde</param>
        ///         ''' <param name="pcIafaCodeCia">Ruc en caso se requiera</param>
        ///         ''' <param name="pdEstado"></param>
        ///         ''' <param name="p_codllaveProd"></param>


        public ProductoE(string pcIafasCode, string pcProdCode, string pnProdName, string pdTipoProducto, string pcIafaCodeCia, string pdEstado, string p_codllaveProd)
        {
            cIafasCode = pcIafasCode;
            cProdCode = pcProdCode;
            nProdName = pnProdName;
            dTipoProducto = pdTipoProducto;
            cIafaCodeCia = pcIafaCodeCia;
            dEstado = pdEstado;
            codllaveProd = p_codllaveProd;
        }
    }
}
