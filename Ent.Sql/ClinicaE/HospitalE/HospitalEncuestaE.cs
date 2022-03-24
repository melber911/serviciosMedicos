using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.HospitalE
{
    public class HospitalEncuestaE
    {
        private int _CodEncuesta = 0;
        public int CodEncuesta
        {
            get
            {
                return _CodEncuesta;
            }
            set
            {
                _CodEncuesta = value;
            }
        }

        private int _CodRespuesta = 0;
        public int CodRespuesta
        {
            get
            {
                return _CodRespuesta;
            }
            set
            {
                _CodRespuesta = value;
            }
        }

        private string _Respuesta = "";
        public string Respuesta
        {
            get
            {
                return _Respuesta;
            }
            set
            {
                _Respuesta = value;
            }
        }

        private int _Codlocal = 0;
        public int Codlocal
        {
            get
            {
                return _Codlocal;
            }
            set
            {
                _Codlocal = value;
            }
        }

        private string _NombreLocal = "";
        public string NombreLocal
        {
            get
            {
                return _NombreLocal;
            }
            set
            {
                _NombreLocal = value;
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

        private DateTime _FechaAtencion = DateTime.Now;
        public DateTime FechaAtencion
        {
            get
            {
                return _FechaAtencion;
            }
            set
            {
                _FechaAtencion = value;
            }
        }

        private int _CodUsuario = 0;
        public int CodUsuario
        {
            get
            {
                return _CodUsuario;
            }
            set
            {
                _CodUsuario = value;
            }
        }

        private string _NombreUsuario = "";
        public string NombreUsuario
        {
            get
            {
                return _NombreUsuario;
            }
            set
            {
                _NombreUsuario = value;
            }
        }

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

        private string _NombrePaciente = "";
        public string NombrePaciente
        {
            get
            {
                return _NombrePaciente;
            }
            set
            {
                _NombrePaciente = value;
            }
        }

        private DateTime _FechaEnvio = DateTime.Now;
        public DateTime FechaEnvio
        {
            get
            {
                return _FechaEnvio;
            }
            set
            {
                _FechaEnvio = value;
            }
        }

        private DateTime _FechaEncuesta = DateTime.Now;
        public DateTime FechaEncuesta
        {
            get
            {
                return _FechaEncuesta;
            }
            set
            {
                _FechaEncuesta = value;
            }
        }

        private string _Comentario = "";
        public string Comentario
        {
            get
            {
                return _Comentario;
            }
            set
            {
                _Comentario = value;
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

        private string _CorreoPaciente = "";
        public string CorreoPaciente
        {
            get
            {
                return _CorreoPaciente;
            }
            set
            {
                _CorreoPaciente = value;
            }
        }

        // ---     Extensiones    ---
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


        public HospitalEncuestaE()
        {
        }
    }
}
