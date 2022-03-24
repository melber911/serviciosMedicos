using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.OtrosE
{
    public class OtrosE
    {
        public string FechaInicio { get; set; } = "";

        public string FechaFin { get; set; } = "";

        public int Intervalo { get; set; } = 0;

        public string CodAtencion { get; set; } = "";

        public string Tarifa { get; set; } = "";

        public string Orden { get; set; } = "";

        public OtrosE() { }

        public OtrosE(string pCodAtencion, string pTarifa)
        {
            CodAtencion = pCodAtencion;
            Tarifa = pTarifa;
        }
    }
}
