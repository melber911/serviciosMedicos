using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.CirugiaE
{
    public class RolSalaOperacionesE
    {
        public decimal Codrolsala { get; set; } = 0;

        public string Sala { get; set; } = "";

        public DateTime Fechaoperacion { get; set; } = DateTime.Now;

        public DateTime Horainicio { get; set; } =DateTime.Now;

        public DateTime Horafin { get; set; } = DateTime.Now;

        public string Codatencion { get; set; } = "";

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

        private string _Operacion = "";
        public string Operacion
        {
            get
            {
                return _Operacion;
            }
            set
            {
                _Operacion = value;
            }
        }

        private string _Codprestacion = "";
        public string Codprestacion
        {
            get
            {
                return _Codprestacion;
            }
            set
            {
                _Codprestacion = value;
            }
        }

        private string _Anestesia = "";
        public string Anestesia
        {
            get
            {
                return _Anestesia;
            }
            set
            {
                _Anestesia = value;
            }
        }

        private bool _Emergencia = false;
        public bool Emergencia
        {
            get
            {
                return _Emergencia;
            }
            set
            {
                _Emergencia = value;
            }
        }

        private string _Nombrepaciente = "";
        public string Nombrepaciente
        {
            get
            {
                return _Nombrepaciente;
            }
            set
            {
                _Nombrepaciente = value;
            }
        }

        private decimal _Edad = 0;
        public decimal Edad
        {
            get
            {
                return _Edad;
            }
            set
            {
                _Edad = value;
            }
        }

        private string _Cuarto = "";
        public string Cuarto
        {
            get
            {
                return _Cuarto;
            }
            set
            {
                _Cuarto = value;
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

        private DateTime _Horainicioreal = DateTime.Now;
        public DateTime Horainicioreal
        {
            get
            {
                return _Horainicioreal;
            }
            set
            {
                _Horainicioreal = value;
            }
        }

        private DateTime _Horafinreal = DateTime.Now;
        public DateTime Horafinreal
        {
            get
            {
                return _Horafinreal;
            }
            set
            {
                _Horafinreal = value;
            }
        }

        private bool _Muertexanestesia = false;
        public bool Muertexanestesia
        {
            get
            {
                return _Muertexanestesia;
            }
            set
            {
                _Muertexanestesia = value;
            }
        }

        private string _Tiempooperatorio = "";
        public string Tiempooperatorio
        {
            get
            {
                return _Tiempooperatorio;
            }
            set
            {
                _Tiempooperatorio = value;
            }
        }

        private string _Tipoanestesia = "";
        public string Tipoanestesia
        {
            get
            {
                return _Tipoanestesia;
            }
            set
            {
                _Tipoanestesia = value;
            }
        }

        private int _Laparoscopia = 0;
        public int Laparoscopia
        {
            get
            {
                return _Laparoscopia;
            }
            set
            {
                _Laparoscopia = value;
            }
        }

        private int _Electrocauterio = 0;
        public int Electrocauterio
        {
            get
            {
                return _Electrocauterio;
            }
            set
            {
                _Electrocauterio = value;
            }
        }

        private int _Oxigeno = 0;
        public int Oxigeno
        {
            get
            {
                return _Oxigeno;
            }
            set
            {
                _Oxigeno = value;
            }
        }

        private string _Tiempooxigeno = "";
        public string Tiempooxigeno
        {
            get
            {
                return _Tiempooxigeno;
            }
            set
            {
                _Tiempooxigeno = value;
            }
        }

        private string _Codpresotor = "";
        public string Codpresotor
        {
            get
            {
                return _Codpresotor;
            }
            set
            {
                _Codpresotor = value;
            }
        }

        private bool _Complicacionesintraoperatorias = false;
        public bool Complicacionesintraoperatorias
        {
            get
            {
                return _Complicacionesintraoperatorias;
            }
            set
            {
                _Complicacionesintraoperatorias = value;
            }
        }

        private bool _Intquirurgicainnecesaria = false;
        public bool Intquirurgicainnecesaria
        {
            get
            {
                return _Intquirurgicainnecesaria;
            }
            set
            {
                _Intquirurgicainnecesaria = value;
            }
        }

        private string _ClasificacionCirugia = "";
        public string ClasificacionCirugia
        {
            get
            {
                return _ClasificacionCirugia;
            }
            set
            {
                _ClasificacionCirugia = value;
            }
        }

        private string _Reprogramado = "";
        public string Reprogramado
        {
            get
            {
                return _Reprogramado;
            }
            set
            {
                _Reprogramado = value;
            }
        }

        private string _FlagSinfecha = "";
        public string FlagSinfecha
        {
            get
            {
                return _FlagSinfecha;
            }
            set
            {
                _FlagSinfecha = value;
            }
        }

        private decimal _RolsalaOrigen = 0;
        public decimal RolsalaOrigen
        {
            get
            {
                return _RolsalaOrigen;
            }
            set
            {
                _RolsalaOrigen = value;
            }
        }

        private string _Derivacion = "";
        public string Derivacion
        {
            get
            {
                return _Derivacion;
            }
            set
            {
                _Derivacion = value;
            }
        }

        private string _Anulado = "";
        public string Anulado
        {
            get
            {
                return _Anulado;
            }
            set
            {
                _Anulado = value;
            }
        }

        private string _Externo = "";
        public string Externo
        {
            get
            {
                return _Externo;
            }
            set
            {
                _Externo = value;
            }
        }

        private int _UsuCrea = 0;
        public int UsuCrea
        {
            get
            {
                return _UsuCrea;
            }
            set
            {
                _UsuCrea = value;
            }
        }

        private int _UsuModifica = 0;
        public int UsuModifica
        {
            get
            {
                return _UsuModifica;
            }
            set
            {
                _UsuModifica = value;
            }
        }

        private int _UsuReprograma = 0;
        public int UsuReprograma
        {
            get
            {
                return _UsuReprograma;
            }
            set
            {
                _UsuReprograma = value;
            }
        }

        private int _UsuRealiza = 0;
        public int UsuRealiza
        {
            get
            {
                return _UsuRealiza;
            }
            set
            {
                _UsuRealiza = value;
            }
        }

        private int _UsuAnula = 0;
        public int UsuAnula
        {
            get
            {
                return _UsuAnula;
            }
            set
            {
                _UsuAnula = value;
            }
        }

        private DateTime _FecCrea = DateTime.Now;
        public DateTime FecCrea
        {
            get
            {
                return _FecCrea;
            }
            set
            {
                _FecCrea = value;
            }
        }

        private DateTime _FecReprograma = DateTime.Now;
        public DateTime FecReprograma
        {
            get
            {
                return _FecReprograma;
            }
            set
            {
                _FecReprograma = value;
            }
        }

        private DateTime _FecRealiza = DateTime.Now;
        public DateTime FecRealiza
        {
            get
            {
                return _FecRealiza;
            }
            set
            {
                _FecRealiza = value;
            }
        }

        private DateTime _FecAnula = DateTime.Now;
        public DateTime FecAnula
        {
            get
            {
                return _FecAnula;
            }
            set
            {
                _FecAnula = value;
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

        private string _FlagRecuperacion = "";
        public string FlagRecuperacion
        {
            get
            {
                return _FlagRecuperacion;
            }
            set
            {
                _FlagRecuperacion = value;
            }
        }

        private string _Noprogramado = "";
        public string Noprogramado
        {
            get
            {
                return _Noprogramado;
            }
            set
            {
                _Noprogramado = value;
            }
        }

        private string _Parto = "";
        public string Parto
        {
            get
            {
                return _Parto;
            }
            set
            {
                _Parto = value;
            }
        }

        private string _Tipoparto = "";
        public string Tipoparto
        {
            get
            {
                return _Tipoparto;
            }
            set
            {
                _Tipoparto = value;
            }
        }

        private string _Cesarea = "";
        public string Cesarea
        {
            get
            {
                return _Cesarea;
            }
            set
            {
                _Cesarea = value;
            }
        }

        private bool _TurnoNocturno = false;
        public bool TurnoNocturno
        {
            get
            {
                return _TurnoNocturno;
            }
            set
            {
                _TurnoNocturno = value;
            }
        }

        private int _Videolaringoscopio = 0;
        public int Videolaringoscopio
        {
            get
            {
                return _Videolaringoscopio;
            }
            set
            {
                _Videolaringoscopio = value;
            }
        }

        private string _Codpresupuesto = "";
        public string Codpresupuesto
        {
            get
            {
                return _Codpresupuesto;
            }
            set
            {
                _Codpresupuesto = value;
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

        private DateTime _Horainiactoquirurgico = DateTime.Now;
        public DateTime Horainiactoquirurgico
        {
            get
            {
                return _Horainiactoquirurgico;
            }
            set
            {
                _Horainiactoquirurgico = value;
            }
        }

        private DateTime _Horafinactoquirugico = DateTime.Now;
        public DateTime Horafinactoquirugico
        {
            get
            {
                return _Horafinactoquirugico;
            }
            set
            {
                _Horafinactoquirugico = value;
            }
        }

        private string _TipoSala = "";
        public string TipoSala
        {
            get
            {
                return _TipoSala;
            }
            set
            {
                _TipoSala = value;
            }
        }

        private string _FlagComplejidad = "";
        public string FlagComplejidad
        {
            get
            {
                return _FlagComplejidad;
            }
            set
            {
                _FlagComplejidad = value;
            }
        }

        private string _TipoOperacion = "";
        public string TipoOperacion
        {
            get
            {
                return _TipoOperacion;
            }
            set
            {
                _TipoOperacion = value;
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

        public string IdePrimary { get; set; } = "";



        public RolSalaOperacionesE()
        {
        }

        public RolSalaOperacionesE(string pCodAtencion)
        {
            Codatencion = pCodAtencion;
        }

        public RolSalaOperacionesE(string pCodAtencion, string pIdePrimay, int pOrden)
        {
            Codatencion = pCodAtencion;
            IdePrimary = pIdePrimay;
            Orden = pOrden;
        }
    }
}