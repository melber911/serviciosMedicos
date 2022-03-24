using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedisynE
{
    public class MdsynTablasE
    {
        private string _Codtabla = "";
        public string Codtabla
        {
            get
            {
                return _Codtabla;
            }
            set
            {
                _Codtabla = value;
            }
        }

        private string _Codigo = "";
        public string Codigo
        {
            get
            {
                return _Codigo;
            }
            set
            {
                _Codigo = value;
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

        private double _Valor = 0;
        public double Valor
        {
            get
            {
                return _Valor;
            }
            set
            {
                _Valor = value;
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



        public MdsynTablasE()
        {
        }

        public MdsynTablasE(string pCodTabla, string pCodigo, string pEstado, string pNombre, int pOrden)
        {
            Codtabla = pCodTabla;
            Codigo = pCodigo;
            Estado = pEstado;
            Nombre = pNombre;
            Orden = pOrden;
        }
    }
}
