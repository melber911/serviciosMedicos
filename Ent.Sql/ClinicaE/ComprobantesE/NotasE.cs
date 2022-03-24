using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.ComprobantesE
{
    public class NotasE
    {
        public string CodComprobante { get; set; } = "";
        public string CodNota { get; set; } = "";

        // EXTENSIONES
        public string SerieNC { get; set; } = "";
        public string MsgError { get; set; } = "";

        public NotasE() { }

        public NotasE(string pCodComprobante, string pSerieNC, string pCodNota)
        {
            CodComprobante = pCodComprobante;
            SerieNC = pSerieNC;
            CodNota = pCodNota;
        }
    }
}