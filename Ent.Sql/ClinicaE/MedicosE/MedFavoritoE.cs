using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedicosE
{
    public class MedFavoritoE
    {
        private int _IdeFavorito = 0;
        private string _CodMedico = "";
        private string _DniMedico = "";
        private string _CodPaciente = "";
        private DateTime _FecRegistro;
        private DateTime _FecEliminado;
        private string _FlgEstado = "";
        // Extensiones
        private string _NuevoValor = "";
        private string _Campo = "";
        private int _Orden = 0;

        public int IdeFavorito
        {
            get
            {
                return _IdeFavorito;
            }
            set
            {
                _IdeFavorito = value;
            }
        }

        public string CodMedico
        {
            get
            {
                return _CodMedico;
            }
            set
            {
                _CodMedico = value;
            }
        }

        public string DniMedico
        {
            get
            {
                return _DniMedico;
            }
            set
            {
                _DniMedico = value;
            }
        }

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

        public DateTime FecRegistro
        {
            get
            {
                return _FecRegistro;
            }
            set
            {
                _FecRegistro = value;
            }
        }

        public DateTime FecEliminado
        {
            get
            {
                return _FecEliminado;
            }
            set
            {
                _FecEliminado = value;
            }
        }

        public string FlgEstado
        {
            get
            {
                return _FlgEstado;
            }
            set
            {
                _FlgEstado = value;
            }
        }

        private string _DscNombreMedico="";
        public string DscNombreMedico
        {
            get
            {
                return _DscNombreMedico;
            }
            set
            {
                _DscNombreMedico = value;
            }
        }

        private string _DscNombrePaciente="";
        public string DscNombrePaciente
        {
            get
            {
                return _DscNombrePaciente;
            }
            set
            {
                _DscNombrePaciente = value;
            }
        }


        // Extensiones
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
    }
}
