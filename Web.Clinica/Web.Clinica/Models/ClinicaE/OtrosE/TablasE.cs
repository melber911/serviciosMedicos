using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.OtrosE
{
    public class TablasE
    {
        public string Codtabla { get; set; } = "";
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public double Valor { get; set; }
        public string Estado { get; set; } = "";

        public string Buscar { get; set; } = "";
        public int Key { get; set; }
        public int NumeroLineas { get; set; }

        // Extensiones
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; }
        /// <summary>
        ///         ''' Agregar registro en blanco
        ///         ''' </summary>
        ///         ''' <returns></returns>
        public bool RegistroBlanco { get; set; }


        public TablasE()
        {
        }

        public TablasE(string pCodTabla, string pCodigo, string pNuevoValor, string pCampo)
        {
            Codtabla = pCodTabla;
            Codigo = pCodigo;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public TablasE(string pCodTabla, string pBuscar, int pKey, int pNumeroLineas, int pOrden)
        {
            Codtabla = pCodTabla;
            Buscar = pBuscar;
            Key = pKey;
            NumeroLineas = pNumeroLineas;
            Orden = pOrden;
        }

        public TablasE(string pCodTabla, string pBuscar, int pKey, int pNumeroLineas, int pOrden, bool pRegistroBlanco)
        {
            Codtabla = pCodTabla;
            Buscar = pBuscar;
            Key = pKey;
            NumeroLineas = pNumeroLineas;
            Orden = pOrden;
            RegistroBlanco = pRegistroBlanco;
        }
    }
}
