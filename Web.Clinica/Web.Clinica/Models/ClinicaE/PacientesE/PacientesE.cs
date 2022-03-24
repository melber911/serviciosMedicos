using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.PacientesE
{
    public class PacientesE
    {
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

        private string _Nombres = "";
        public string Nombres
        {
            get
            {
                return _Nombres;
            }
            set
            {
                _Nombres = value;
            }
        }

        private string _Docidentidad = "";
        public string Docidentidad
        {
            get
            {
                return _Docidentidad;
            }
            set
            {
                _Docidentidad = value;
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

        private string _Coddistrito = "";
        public string Coddistrito
        {
            get
            {
                return _Coddistrito;
            }
            set
            {
                _Coddistrito = value;
            }
        }

        private string _Codprovincia = "";
        public string Codprovincia
        {
            get
            {
                return _Codprovincia;
            }
            set
            {
                _Codprovincia = value;
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

        private string _Codcivil = "";
        public string Codcivil
        {
            get
            {
                return _Codcivil;
            }
            set
            {
                _Codcivil = value;
            }
        }

        private DateTime _Fechanacimiento = DateTime.Now;
        public DateTime Fechanacimiento
        {
            get
            {
                return _Fechanacimiento;
            }
            set
            {
                _Fechanacimiento = value;
            }
        }

        private string _Sexo = "";
        public string Sexo
        {
            get
            {
                return _Sexo;
            }
            set
            {
                _Sexo = value;
            }
        }

        private string _Tipdocidentidad = "";
        public string Tipdocidentidad
        {
            get
            {
                return _Tipdocidentidad;
            }
            set
            {
                _Tipdocidentidad = value;
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

        private string _Observaciones = "";
        public string Observaciones
        {
            get
            {
                return _Observaciones;
            }
            set
            {
                _Observaciones = value;
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

        private string _Vip = "";
        public string Vip
        {
            get
            {
                return _Vip;
            }
            set
            {
                _Vip = value;
            }
        }

        private string _Coddireccion = "";
        public string Coddireccion
        {
            get
            {
                return _Coddireccion;
            }
            set
            {
                _Coddireccion = value;
            }
        }

        private string _Lugarnacimiento = "";
        public string Lugarnacimiento
        {
            get
            {
                return _Lugarnacimiento;
            }
            set
            {
                _Lugarnacimiento = value;
            }
        }

        private string _Restringido = "";
        public string Restringido
        {
            get
            {
                return _Restringido;
            }
            set
            {
                _Restringido = value;
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

        public string Nombre { get; set; } = "";
        public string ApPaterno { get; set; } = "";
        public string ApMaterno { get; set; } = "";
        public string Parentesco { get; set; } = "";
        // Public Property Correo As String = ""
        public string Celular { get; set; } = "";

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

        private string _Buscar = "";
        public string Buscar
        {
            get
            {
                return _Buscar;
            }
            set
            {
                _Buscar = value;
            }
        }

        private int _Key;
        public int Key
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
            }
        }

        private int _NumeroLineas;
        public int NumeroLineas
        {
            get
            {
                return _NumeroLineas;
            }
            set
            {
                _NumeroLineas = value;
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

        public string Codigo { get; set; } = "";
        public string Tabla { get; set; } = "";
        public string CodPacienteAuditor { get; set; } = "";
        public DateTime FechaRegistro { get; set; } = DateTime.Now;



        public PacientesE()
        {
        }

        public PacientesE(string pCodPaciente)
        {
            CodPaciente = pCodPaciente;
        }

        public PacientesE(string pCodPaciente, string pCampo, string pNuevoValor)
        {
            CodPaciente = pCodPaciente;
            Campo = pCampo;
            NuevoValor = pNuevoValor;
        }

        public PacientesE(string pBuscar, int pKey, int pNumeroLineas, int pOrden, string pDocIdentidad)
        {
            Buscar = pBuscar;
            Key = pKey;
            NumeroLineas = pNumeroLineas;
            Orden = pOrden;
            Docidentidad = pDocIdentidad;
        }
    }
}
