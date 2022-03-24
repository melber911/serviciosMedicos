using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.HospitalE
{
    public class AseguradorasE
    {
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

        private string _Nombre = "";
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        private string _Direccion = "";
        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                _Direccion = value;
            }
        }

        private string _Telefono = "";
        public string Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                _Telefono = value;
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

        private string _Contacto = "";
        public string Contacto
        {
            get
            {
                return _Contacto;
            }
            set
            {
                _Contacto = value;
            }
        }

        private bool _Estado = false;
        public bool Estado
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

        private string _Tipoaseguradora = "";
        public string Tipoaseguradora
        {
            get
            {
                return _Tipoaseguradora;
            }
            set
            {
                _Tipoaseguradora = value;
            }
        }

        private string _Tarifaambulatorio = "";
        public string Tarifaambulatorio
        {
            get
            {
                return _Tarifaambulatorio;
            }
            set
            {
                _Tarifaambulatorio = value;
            }
        }

        private string _Tarifaemergencia = "";
        public string Tarifaemergencia
        {
            get
            {
                return _Tarifaemergencia;
            }
            set
            {
                _Tarifaemergencia = value;
            }
        }

        private string _Tarifahospital = "";
        public string Tarifahospital
        {
            get
            {
                return _Tarifahospital;
            }
            set
            {
                _Tarifahospital = value;
            }
        }

        private string _Tarifaspectmedic = "";
        public string Tarifaspectmedic
        {
            get
            {
                return _Tarifaspectmedic;
            }
            set
            {
                _Tarifaspectmedic = value;
            }
        }

        private int _Diaspago = 0;
        public int Diaspago
        {
            get
            {
                return _Diaspago;
            }
            set
            {
                _Diaspago = value;
            }
        }

        private string _Correo = "";
        public string Correo
        {
            get
            {
                return _Correo;
            }
            set
            {
                _Correo = value;
            }
        }

        private string _CodEpss = "";
        public string CodEpss
        {
            get
            {
                return _CodEpss;
            }
            set
            {
                _CodEpss = value;
            }
        }

        private string _CodUbigeo = "";
        public string CodUbigeo
        {
            get
            {
                return _CodUbigeo;
            }
            set
            {
                _CodUbigeo = value;
            }
        }

        private string _Cardcode = "";
        public string Cardcode
        {
            get
            {
                return _Cardcode;
            }
            set
            {
                _Cardcode = value;
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

        private DateTime _FecRecepcionsap = DateTime.Now;
        public DateTime FecRecepcionsap
        {
            get
            {
                return _FecRecepcionsap;
            }
            set
            {
                _FecRecepcionsap = value;
            }
        }


        // ---     Extensiones    ---
        public string Buscar { get; set; } = "";
        public int Key { get; set; } = 0;
        public int NumeroLineas { get; set; } = 0;


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

        private string _CodAtencion="";
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



        public AseguradorasE()
        {
        }

        public AseguradorasE(string pCodAtencion)
        {
            CodAtencion = pCodAtencion;
        }

        public AseguradorasE(string pCodAtencion, string pCampo, string pNuevoValor)
        {
            CodAtencion = pCodAtencion;
            Campo = pCampo;
            NuevoValor = pNuevoValor;
        }
    }
}
