using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.HospitalE
{
    public class AseguradosE
    {
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

        private string _Poliza = "";
        public string Poliza
        {
            get
            {
                return _Poliza;
            }
            set
            {
                _Poliza = value;
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

        private string _Codparentesco = "";
        public string Codparentesco
        {
            get
            {
                return _Codparentesco;
            }
            set
            {
                _Codparentesco = value;
            }
        }

        private string _Codtarifa = "";
        public string Codtarifa
        {
            get
            {
                return _Codtarifa;
            }
            set
            {
                _Codtarifa = value;
            }
        }

        private DateTime _Fechainiciovigencia = DateTime.Now;
        public DateTime Fechainiciovigencia
        {
            get
            {
                return _Fechainiciovigencia;
            }
            set
            {
                _Fechainiciovigencia = value;
            }
        }

        private DateTime _Fechafinvigencia = DateTime.Now;
        public DateTime Fechafinvigencia
        {
            get
            {
                return _Fechafinvigencia;
            }
            set
            {
                _Fechafinvigencia = value;
            }
        }

        private int _Numerodiasatencion = 0;
        public int Numerodiasatencion
        {
            get
            {
                return _Numerodiasatencion;
            }
            set
            {
                _Numerodiasatencion = value;
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

        private string _Codigoaseguradoexterno = "";
        public string Codigoaseguradoexterno
        {
            get
            {
                return _Codigoaseguradoexterno;
            }
            set
            {
                _Codigoaseguradoexterno = value;
            }
        }

        private string _Tiposeguroexterno = "";
        public string Tiposeguroexterno
        {
            get
            {
                return _Tiposeguroexterno;
            }
            set
            {
                _Tiposeguroexterno = value;
            }
        }

        private string _Codproducto = "";
        public string Codproducto
        {
            get
            {
                return _Codproducto;
            }
            set
            {
                _Codproducto = value;
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



        public AseguradosE()
        {
        }

        public AseguradosE(string pCodAtencion)
        {
            CodAtencion = pCodAtencion;
        }

        public AseguradosE(string pCodAtencion, string pCampo, string pNuevoValor)
        {
            CodAtencion = pCodAtencion;
            Campo = pCampo;
            NuevoValor = pNuevoValor;
        }
    }
}