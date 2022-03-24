using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.PresotorE
{
    public class PresotorE
    {
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

        private string _CodPrestacion = "";
        public string CodPrestacion
        {
            get
            {
                return _CodPrestacion;
            }
            set
            {
                _CodPrestacion = value;
            }
        }

        private DateTime _Fechahoraatencion = DateTime.Now;
        public DateTime Fechahoraatencion
        {
            get
            {
                return _Fechahoraatencion;
            }
            set
            {
                _Fechahoraatencion = value;
            }
        }

        private string _Codmedico = "";
        public string Codmedico
        {
            get
            {
                return _Codmedico;
            }
            set
            {
                _Codmedico = value;
            }
        }

        private string _Tipomedico = "";
        public string Tipomedico
        {
            get
            {
                return _Tipomedico;
            }
            set
            {
                _Tipomedico = value;
            }
        }

        private string _Cargomedico = "";
        public string Cargomedico
        {
            get
            {
                return _Cargomedico;
            }
            set
            {
                _Cargomedico = value;
            }
        }

        private string _CodLiqPaciente = "";
        public string CodLiqPaciente
        {
            get
            {
                return _CodLiqPaciente;
            }
            set
            {
                _CodLiqPaciente = value;
            }
        }

        private string _CodLiqAseguradora = "";
        public string CodLiqAseguradora
        {
            get
            {
                return _CodLiqAseguradora;
            }
            set
            {
                _CodLiqAseguradora = value;
            }
        }

        private string _Codliqcontratante = "";
        public string Codliqcontratante
        {
            get
            {
                return _Codliqcontratante;
            }
            set
            {
                _Codliqcontratante = value;
            }
        }

        private double _Valorprestacion = 0;
        public double Valorprestacion
        {
            get
            {
                return _Valorprestacion;
            }
            set
            {
                _Valorprestacion = value;
            }
        }

        private double _ValorCorregido = 0;
        public double ValorCorregido
        {
            get
            {
                return _ValorCorregido;
            }
            set
            {
                _ValorCorregido = value;
            }
        }

        private double _Valorgnc = 0;
        public double Valorgnc
        {
            get
            {
                return _Valorgnc;
            }
            set
            {
                _Valorgnc = value;
            }
        }

        private double _Valorcoaseguro = 0;
        public double Valorcoaseguro
        {
            get
            {
                return _Valorcoaseguro;
            }
            set
            {
                _Valorcoaseguro = value;
            }
        }

        private double _Porcentajededucible = 0;
        public double Porcentajededucible
        {
            get
            {
                return _Porcentajededucible;
            }
            set
            {
                _Porcentajededucible = value;
            }
        }

        private double _Porcentajecoaseguro = 0;
        public double Porcentajecoaseguro
        {
            get
            {
                return _Porcentajecoaseguro;
            }
            set
            {
                _Porcentajecoaseguro = value;
            }
        }

        private double _Descuento = 0;
        public double Descuento
        {
            get
            {
                return _Descuento;
            }
            set
            {
                _Descuento = value;
            }
        }

        private string _Documento = "";
        public string Documento
        {
            get
            {
                return _Documento;
            }
            set
            {
                _Documento = value;
            }
        }

        private string _Codpedido = "";
        public string Codpedido
        {
            get
            {
                return _Codpedido;
            }
            set
            {
                _Codpedido = value;
            }
        }

        private double _Deducible = 0;
        public double Deducible
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

        private string _Quiencreoregistro = "";
        public string Quiencreoregistro
        {
            get
            {
                return _Quiencreoregistro;
            }
            set
            {
                _Quiencreoregistro = value;
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

        private string _Liqtercero = "";
        public string Liqtercero
        {
            get
            {
                return _Liqtercero;
            }
            set
            {
                _Liqtercero = value;
            }
        }

        private string _Codmedicoenvia = "";
        public string Codmedicoenvia
        {
            get
            {
                return _Codmedicoenvia;
            }
            set
            {
                _Codmedicoenvia = value;
            }
        }

        private DateTime _Fechallegadocumento = DateTime.Now;
        public DateTime Fechallegadocumento
        {
            get
            {
                return _Fechallegadocumento;
            }
            set
            {
                _Fechallegadocumento = value;
            }
        }

        private string _Auxiliar = "";
        public string Auxiliar
        {
            get
            {
                return _Auxiliar;
            }
            set
            {
                _Auxiliar = value;
            }
        }

        private double _Porcentajedescuento = 0;
        public double Porcentajedescuento
        {
            get
            {
                return _Porcentajedescuento;
            }
            set
            {
                _Porcentajedescuento = value;
            }
        }

        private string _Liqterceropaciente = "";
        public string Liqterceropaciente
        {
            get
            {
                return _Liqterceropaciente;
            }
            set
            {
                _Liqterceropaciente = value;
            }
        }

        private string _Liqtercerocontratante = "";
        public string Liqtercerocontratante
        {
            get
            {
                return _Liqtercerocontratante;
            }
            set
            {
                _Liqtercerocontratante = value;
            }
        }

        private string _Codtercero = "";
        public string Codtercero
        {
            get
            {
                return _Codtercero;
            }
            set
            {
                _Codtercero = value;
            }
        }

        private double _Descuentotercero = 0;
        public double Descuentotercero
        {
            get
            {
                return _Descuentotercero;
            }
            set
            {
                _Descuentotercero = value;
            }
        }

        private string _Codpresotorpadre = "";
        public string Codpresotorpadre
        {
            get
            {
                return _Codpresotorpadre;
            }
            set
            {
                _Codpresotorpadre = value;
            }
        }

        private string _Quieneliminoregistro = "";
        public string Quieneliminoregistro
        {
            get
            {
                return _Quieneliminoregistro;
            }
            set
            {
                _Quieneliminoregistro = value;
            }
        }

        private bool _FlgEnviosap = false;
        public bool FlgEnviosap
        {
            get
            {
                return _FlgEnviosap;
            }
            set
            {
                _FlgEnviosap = value;
            }
        }

        private DateTime _FecEnviosap = DateTime.Now;
        public DateTime FecEnviosap
        {
            get
            {
                return _FecEnviosap;
            }
            set
            {
                _FecEnviosap = value;
            }
        }

        private int _IdeDocentrysap = 0;
        public int IdeDocentrysap
        {
            get
            {
                return _IdeDocentrysap;
            }
            set
            {
                _IdeDocentrysap = value;
            }
        }

        private DateTime _FecDocentrysap = DateTime.Now;
        public DateTime FecDocentrysap
        {
            get
            {
                return _FecDocentrysap;
            }
            set
            {
                _FecDocentrysap = value;
            }
        }

        private int _IdeTablainterSap = 0;
        public int IdeTablainterSap
        {
            get
            {
                return _IdeTablainterSap;
            }
            set
            {
                _IdeTablainterSap = value;
            }
        }

        // ---     EXTENSIONES    ---
        private int _CodUser;
        public int CodUser
        {
            get
            {
                return _CodUser;
            }
            set
            {
                _CodUser = value;
            }
        }

        private double _MontoTotal;
        public double MontoTotal
        {
            get
            {
                return _MontoTotal;
            }
            set
            {
                _MontoTotal = value;
            }
        }


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

        public PresotorE()
        {
        }

        public PresotorE(string pCodAtencion, double pMontoTotal, int pCodUser, string pCodPresotor)
        {
            CodAtencion = pCodAtencion;
            MontoTotal = pMontoTotal;
            CodUser = pCodUser;
            CodPresotor = pCodPresotor;
        }
    }
}
