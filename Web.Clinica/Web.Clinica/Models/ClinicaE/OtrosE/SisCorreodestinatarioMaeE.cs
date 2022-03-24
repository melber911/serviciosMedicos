using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.OtrosE
{
    public class SisCorreodestinatarioMaeE
    {
        public int IdeCorreo { get; set; } = 0;
        public string CodLista { get; set; } = "";
        public int SecLista { get; set; } = 0;
        public string CodTipo { get; set; } = "";
        public string DscDestinatario { get; set; } = "";
        public bool FlgRegistro { get; set; } = false;
        public DateTime FecRegistro { get; set; } = DateTime.Now;
        // Extensiones
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;

        public SisCorreodestinatarioMaeE()
        {
        }

        public SisCorreodestinatarioMaeE(string pCodLista, string pCodTipo)
        {
            CodLista = pCodLista;
            CodTipo = pCodTipo;
        }
    }
}
