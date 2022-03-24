using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.OtrosE
{
    public class CiasE
    {
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

        private string _Login = "";
        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
            }
        }

        private string _Password = "";
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        private int _Activointernet = 0;
        public int Activointernet
        {
            get
            {
                return _Activointernet;
            }
            set
            {
                _Activointernet = value;
            }
        }

        private DateTime _Fecharegistro = DateTime.Now;
        public DateTime Fecharegistro
        {
            get
            {
                return _Fecharegistro;
            }
            set
            {
                _Fecharegistro = value;
            }
        }

        private int _Codusercreo = 0;
        public int Codusercreo
        {
            get
            {
                return _Codusercreo;
            }
            set
            {
                _Codusercreo = value;
            }
        }

        private DateTime _Fechamodifico = DateTime.Now;
        public DateTime Fechamodifico
        {
            get
            {
                return _Fechamodifico;
            }
            set
            {
                _Fechamodifico = value;
            }
        }

        private int _Codusermodifico = 0;
        public int Codusermodifico
        {
            get
            {
                return _Codusermodifico;
            }
            set
            {
                _Codusermodifico = value;
            }
        }

        private string _Codciaanterior = "";
        public string Codciaanterior
        {
            get
            {
                return _Codciaanterior;
            }
            set
            {
                _Codciaanterior = value;
            }
        }

        private DateTime _Fechabaja = DateTime.Now;
        public DateTime Fechabaja
        {
            get
            {
                return _Fechabaja;
            }
            set
            {
                _Fechabaja = value;
            }
        }

        private int _Coduserbaja = 0;
        public int Coduserbaja
        {
            get
            {
                return _Coduserbaja;
            }
            set
            {
                _Coduserbaja = value;
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

        private string _CodTipopersona = "";
        public string CodTipopersona
        {
            get
            {
                return _CodTipopersona;
            }
            set
            {
                _CodTipopersona = value;
            }
        }

        private string _DscAppaterno = "";
        public string DscAppaterno
        {
            get
            {
                return _DscAppaterno;
            }
            set
            {
                _DscAppaterno = value;
            }
        }

        private string _DscApmaterno = "";
        public string DscApmaterno
        {
            get
            {
                return _DscApmaterno;
            }
            set
            {
                _DscApmaterno = value;
            }
        }

        private string _DscSegundonombre = "";
        public string DscSegundonombre
        {
            get
            {
                return _DscSegundonombre;
            }
            set
            {
                _DscSegundonombre = value;
            }
        }

        private string _DscPrimernombre = "";
        public string DscPrimernombre
        {
            get
            {
                return _DscPrimernombre;
            }
            set
            {
                _DscPrimernombre = value;
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

        private int _NumDiaspago = 0;
        public int NumDiaspago
        {
            get
            {
                return _NumDiaspago;
            }
            set
            {
                _NumDiaspago = value;
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

        private int _FlagServicio = 0;
        public int FlagServicio
        {
            get
            {
                return _FlagServicio;
            }
            set
            {
                _FlagServicio = value;
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



        public CiasE()
        {
        }

        public CiasE(string pCodCia)
        {
            Codcia = pCodCia;
        }


        public CiasE(string pCodCia, string pNuevoValor, string pCampo)
        {
            Codcia = pCodCia;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }
    }
}
