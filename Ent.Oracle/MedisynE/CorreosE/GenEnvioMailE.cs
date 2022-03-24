using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Oracle.MedisynE.CorreosE
{
    public class GenEnvioMailE
    {
        public string IdMail { get; set; } = "";
        public int Codempresa { get; set; } = 0;
        public string MailTo { get; set; } = "";
        public string MailCC { get; set; } = "";
        public string MailBody { get; set; } = "";
        public string MailSubjet { get; set; } = "";
        public DateTime FechaIngreso { get; set; }
    }
}
