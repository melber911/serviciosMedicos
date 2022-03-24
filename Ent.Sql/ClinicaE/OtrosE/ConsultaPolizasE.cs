using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.OtrosE
{
    public class ConsultaPolizasE
    {
        private int _Idconsulta = 0;
        public int Idconsulta
        {
            get
            {
                return _Idconsulta;
            }
            set
            {
                _Idconsulta = value;
            }
        }

        private string _Codatencion = "";
        public string Codatencion
        {
            get
            {
                return _Codatencion;
            }
            set
            {
                _Codatencion = value;
            }
        }

        private string _Linea = "";
        public string Linea
        {
            get
            {
                return _Linea;
            }
            set
            {
                _Linea = value;
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



        public ConsultaPolizasE()
        {
        }

        public ConsultaPolizasE(string pCodAtencion, string pLinea, int pIdConsulta)
        {
            Codatencion = pCodAtencion;
            Linea = pLinea;
            Idconsulta = pIdConsulta;
        }
    }
}