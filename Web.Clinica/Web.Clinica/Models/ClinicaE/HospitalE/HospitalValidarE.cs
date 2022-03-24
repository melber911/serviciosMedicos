using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.HospitalE
{
    public class HospitalValidarE : IHospitalValidarE
    {
        private int _Idvalidar = 0;
        public int Idvalidar
        {
            get
            {
                return _Idvalidar;
            }
            set
            {
                _Idvalidar = value;
            }
        }

        private string _Descripcion = "";
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
            }
        }

        private string _Script = "";
        public string Script
        {
            get
            {
                return _Script;
            }
            set
            {
                _Script = value;
            }
        }

        private int _Idvalidarpadre = 0;
        public int Idvalidarpadre
        {
            get
            {
                return _Idvalidarpadre;
            }
            set
            {
                _Idvalidarpadre = value;
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

        private string _TipoAtencion = "";
        public string TipoAtencion
        {
            get
            {
                return _TipoAtencion;
            }
            set
            {
                _TipoAtencion = value;
            }
        }

        private string _CodAseguradora = "";
        public string CodAseguradora
        {
            get
            {
                return _CodAseguradora;
            }
            set
            {
                _CodAseguradora = value;
            }
        }

        private string _CodCobertura = "";
        public string CodCobertura
        {
            get
            {
                return _CodCobertura;
            }
            set
            {
                _CodCobertura = value;
            }
        }



        public HospitalValidarE()
        {
        }

        public HospitalValidarE(string pTipoAtencion, string pCodAseguradora, string pCodCobertura)
        {
            TipoAtencion = pTipoAtencion;
            CodAseguradora = pCodAseguradora;
            CodCobertura = pCodCobertura;
        }
    }

    public interface IHospitalValidarE
    {
        string Campo { get; set; }
        string CodAseguradora { get; set; }
        string CodCobertura { get; set; }
        string Descripcion { get; set; }
        int Idvalidar { get; set; }
        int Idvalidarpadre { get; set; }
        string NuevoValor { get; set; }
        int Orden { get; set; }
        string Script { get; set; }
        string TipoAtencion { get; set; }
    }
}
