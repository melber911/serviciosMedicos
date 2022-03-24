using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.LiquidacionesE
{
    public class LiquidacionesE
    {
        private string _CodLiquidacion = "";
        public string CodLiquidacion
        {
            get
            {
                return _CodLiquidacion;
            }
            set
            {
                _CodLiquidacion = value;
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

        private string _Codcomprobante = "";
        public string Codcomprobante
        {
            get
            {
                return _Codcomprobante;
            }
            set
            {
                _Codcomprobante = value;
            }
        }

        private DateTime _Fechagenerada = DateTime.Now;
        public DateTime Fechagenerada
        {
            get
            {
                return _Fechagenerada;
            }
            set
            {
                _Fechagenerada = value;
            }
        }

        private string _Estado = "";
        public string Estado
        {
            get
            {
                return _Estado;
            }
            set
            {
                _Estado = value;
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

        private string _Paraquienseliquida = "";
        public string Paraquienseliquida
        {
            get
            {
                return _Paraquienseliquida;
            }
            set
            {
                _Paraquienseliquida = value;
            }
        }

        private DateTime _Fechaprocesada = DateTime.Now;
        public DateTime Fechaprocesada
        {
            get
            {
                return _Fechaprocesada;
            }
            set
            {
                _Fechaprocesada = value;
            }
        }

        private DateTime _Fechaanulada = DateTime.Now;
        public DateTime Fechaanulada
        {
            get
            {
                return _Fechaanulada;
            }
            set
            {
                _Fechaanulada = value;
            }
        }

        private DateTime _Fechainicio = DateTime.Now;
        public DateTime Fechainicio
        {
            get
            {
                return _Fechainicio;
            }
            set
            {
                _Fechainicio = value;
            }
        }

        private DateTime _Fechafin = DateTime.Now;
        public DateTime Fechafin
        {
            get
            {
                return _Fechafin;
            }
            set
            {
                _Fechafin = value;
            }
        }

        private string _QuienCreoRegistro = "";
        public string QuienCreoRegistro
        {
            get
            {
                return _QuienCreoRegistro;
            }
            set
            {
                _QuienCreoRegistro = value;
            }
        }

        private string _Quienmodificoregistro = "";
        public string Quienmodificoregistro
        {
            get
            {
                return _Quienmodificoregistro;
            }
            set
            {
                _Quienmodificoregistro = value;
            }
        }

        private decimal _Deducible = 0;
        public decimal Deducible
        {
            get
            {
                return _Deducible;
            }
            set
            {
                _Deducible = value;
            }
        }

        private decimal _Coaseguro = 0;
        public decimal Coaseguro
        {
            get
            {
                return _Coaseguro;
            }
            set
            {
                _Coaseguro = value;
            }
        }

        private decimal _Deduciblecarta = 0;
        public decimal Deduciblecarta
        {
            get
            {
                return _Deduciblecarta;
            }
            set
            {
                _Deduciblecarta = value;
            }
        }

        private decimal _Difcobertura = 0;
        public decimal Difcobertura
        {
            get
            {
                return _Difcobertura;
            }
            set
            {
                _Difcobertura = value;
            }
        }

        private string _Pagadeducible = "";
        public string Pagadeducible
        {
            get
            {
                return _Pagadeducible;
            }
            set
            {
                _Pagadeducible = value;
            }
        }

        private string _Pagacoaseguro = "";
        public string Pagacoaseguro
        {
            get
            {
                return _Pagacoaseguro;
            }
            set
            {
                _Pagacoaseguro = value;
            }
        }

        private string _Pagagnc = "";
        public string Pagagnc
        {
            get
            {
                return _Pagagnc;
            }
            set
            {
                _Pagagnc = value;
            }
        }

        private string _Anombredequien = "";
        public string Anombredequien
        {
            get
            {
                return _Anombredequien;
            }
            set
            {
                _Anombredequien = value;
            }
        }

        private string _Ruc = "";
        public string Ruc
        {
            get
            {
                return _Ruc;
            }
            set
            {
                _Ruc = value;
            }
        }

        private double _Montoinafecto = 0;
        public double Montoinafecto
        {
            get
            {
                return _Montoinafecto;
            }
            set
            {
                _Montoinafecto = value;
            }
        }

        private string _Codaseguradora = "";
        public string Codaseguradora
        {
            get
            {
                return _Codaseguradora;
            }
            set
            {
                _Codaseguradora = value;
            }
        }

        private string _Codcia = "";
        public string Codcia
        {
            get
            {
                return _Codcia;
            }
            set
            {
                _Codcia = value;
            }
        }

        private string _Codpoliza = "";
        public string Codpoliza
        {
            get
            {
                return _Codpoliza;
            }
            set
            {
                _Codpoliza = value;
            }
        }

        private string _Planpoliza = "";
        public string Planpoliza
        {
            get
            {
                return _Planpoliza;
            }
            set
            {
                _Planpoliza = value;
            }
        }

        private int _UsrRegistra = 0;
        public int UsrRegistra
        {
            get
            {
                return _UsrRegistra;
            }
            set
            {
                _UsrRegistra = value;
            }
        }

        private DateTime _FecRegistra = DateTime.Now;
        public DateTime FecRegistra
        {
            get
            {
                return _FecRegistra;
            }
            set
            {
                _FecRegistra = value;
            }
        }

        private int _UsrModifica = 0;
        public int UsrModifica
        {
            get
            {
                return _UsrModifica;
            }
            set
            {
                _UsrModifica = value;
            }
        }

        private DateTime _FecModifica = DateTime.Now;
        public DateTime FecModifica
        {
            get
            {
                return _FecModifica;
            }
            set
            {
                _FecModifica = value;
            }
        }

        private string _Tipoimpresion = "";
        public string Tipoimpresion
        {
            get
            {
                return _Tipoimpresion;
            }
            set
            {
                _Tipoimpresion = value;
            }
        }

        private bool _FlgGratuito = false;
        public bool FlgGratuito
        {
            get
            {
                return _FlgGratuito;
            }
            set
            {
                _FlgGratuito = value;
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

        private string _CodPresotor="";
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

        private int _Tipo;
        /// <summary>
        ///         ''' Tipo de Liquidacion 1: Crea, 2: Modifica
        ///         ''' </summary>
        ///         ''' <returns></returns>
        public int Tipo
        {
            get
            {
                return _Tipo;
            }
            set
            {
                _Tipo = value;
            }
        }



        public LiquidacionesE()
        {
        }

        public LiquidacionesE(string pCodLiquidacion)
        {
            CodLiquidacion = pCodLiquidacion;
        }

        public LiquidacionesE(string pCodAtencion, string pQuienCreoRegistro, string pCodLiquidacion)
        {
            CodAtencion = pCodAtencion;
            QuienCreoRegistro = pQuienCreoRegistro;
            CodLiquidacion = pCodLiquidacion;
        }

        public LiquidacionesE(string pCodAtencion, string pCodPresotor, string pQuien, int pTipo, string pCodLiquidacion)
        {
            CodAtencion = pCodAtencion;
            CodPresotor = pCodPresotor;
            QuienCreoRegistro = pQuien;
            Tipo = pTipo;
            CodLiquidacion = pCodLiquidacion;
        }

        public LiquidacionesE(string pCodLiquidacion, string pCodAtencion, string pCodPresotor, string pQuien, int pTipo, string pCampo, string pNuevoValor)
        {
            CodLiquidacion = pCodLiquidacion;
            CodAtencion = pCodAtencion;
            CodPresotor = pCodPresotor;
            QuienCreoRegistro = pQuien;
            Tipo = pTipo;
            Campo = pCampo;
            NuevoValor = pNuevoValor;
        }
    }
}
